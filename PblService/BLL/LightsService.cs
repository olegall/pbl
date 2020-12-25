using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using PblDAL.Models;
using PblDAL.Reps;
using Modbus;
using PblService.Models;

namespace PblService.BLL
{
    public class LightsService
    {
        #region Fields
        private readonly IGenericRepository<Color> _colorRep;
        private readonly IGenericRepository<Light> _lightRep;
        private readonly BinaryService binaryService;
        #endregion

        #region Controller
        private static ConcurrentDictionary<long, IControllerAdapter> _controllers;
        private readonly int highNumMin = 17;
        private static IList<ControllerCache> _controllerCacheData;

        private static class Address
        {
            public static ushort Low { get; } = 0x300;
            public static ushort High { get; } = 0x320;
        }
        #endregion

        #region Ctor
        public LightsService(ApplicationContext context)
        {
            _colorRep = new ColorRepository(context);
            _lightRep = new LightRepository(context);

            binaryService = new BinaryService();
        }
        #endregion

        public static void Init()
        {
            ModbusControllerAdapter.PollingFinished += UpdateCacheReady;
            _controllers = Program.GetControllers();
        }

        #region API GET
        /// <summary>
        /// Получить цвета
        /// </summary>
        public async Task<IEnumerable<Color>> GetColors()
        {
            IEnumerable<Color> colors = await _colorRep.GetAllAsync();
            return colors;
        }

        /// <summary>
        /// Получить доступные для управления лампы
        /// </summary>
        public async Task<object> Get(string selectedColors)
        {
            IEnumerable<Light> lights = selectedColors == null ? 
                               (await _lightRep.GetAllAsync()) :
                               (await _lightRep.GetAllAsync()).Where(x => x.ColorId == selectedColors).ToArray();
            return lights.Select(x => new { x.Id, 
                                            x.ColorId,
                                            status = GetStatus(x.Id).Result })
                         .ToArray();
        }

        /// <summary>
        /// Получить состояние одной лампы
        /// </summary>
        public async Task<object> GetOne(string id)
        {
            Light l = await GetById(id);
            if (l == null)
                return null;

            return new { l.Id,
                         l.ColorId, 
                         status = GetStatus(l.Id).Result };
        }
        #endregion

        #region API POST
        /// <summary>
        /// Вкл/выкл все лампы
        /// </summary>
        public async Task ToggleAll(string idColor, bool onOff)
        {
            if (idColor == null)
                ToggleAll(onOff);
            else
                await ToggleAll(onOff, idColor);
        }
        #endregion

        #region Light
        private async Task<bool> GetStatus(string lightId)
        {
            Light light = await GetById(lightId);
            if (light == null)
                throw new Exception("Нет лампы с таким Id");

            ushort address = (ushort)light.Address;
            CheckAddress(address);

            ushort value = (ushort)GetCacheReg(light.ControllerId, address).Value;
            light.Num = NormalizeNumIfHigh(light.Num);
            bool status = binaryService.IsBitSet(value, light.Num - 1);
            return status;
        }

        /// <summary>
        /// Вкл/выкл лампу
        /// </summary>
        public async Task Toggle(string lightId, bool onOff)
        {
            Light light = await GetById(lightId);
            if (light == null)
                throw new Exception("Нет лампы с таким Id");

            ushort address = (ushort)light.Address;
            CheckAddress(address);
            
            ushort value = (ushort)GetCacheReg(light.ControllerId, address).Value;
            ushort newValue = onOff ? binaryService.SetBit(value, light.Num - 1) :
                                       binaryService.ClearBit(value, light.Num - 1);
            
            _controllers[light.ControllerId].WriteSingleRegister(address, newValue);
            UpdateCacheRegValue(light.ControllerId, address, newValue);
        }

        /// <summary>
        /// Вкл/выкл все лампы
        /// </summary>
        private void ToggleAll(bool onOff)
        {
            foreach (IControllerAdapter a in _controllers.Values.Where(x => x.Connected))
            {
                for (ushort address = Address.Low; address <= Address.High; address++)
                {
                    a.WriteSingleRegister(address, GetValue(onOff));
                }
            }
        }

        /// <summary>
        /// Вкл/выкл все лампы одного цвета
        /// </summary>
        private async Task ToggleAll(bool onOff, string colorId)
        {
            IEnumerable<Light> lights = await GetByColor(colorId);
            foreach (Light l in lights)
            {
                l.Num = NormalizeNumIfHigh(l.Num);
                await Toggle(l.Id, onOff);
            }
        }

        private async Task<Light> GetById(string id) 
        {
            return (await _lightRep.GetAllAsync()).FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получить лампы по коду цвета
        /// </summary>
        private async Task<IEnumerable<Light>> GetByColor(string colorId)
        {
            return (await _lightRep.GetAllAsync()).Where(x => x.ColorId == colorId)
                                                 .ToArray();
        }

        private int NormalizeNumIfHigh(int num)
        {
            if (num >= highNumMin)
                num = num - highNumMin + 1;

            return num;
        }
        #endregion

        #region Controller
        private ushort GetValue(bool onOff)
        {
            return (ushort)(onOff ? 0xFFFF : 0);
        }

        private void CheckAddress(ushort address)
        {
            if (address < Address.Low && address > Address.High)
                throw new ArgumentOutOfRangeException(nameof(address));
        }

        public IEnumerable<ControllerVM> GetControllers()
        {
            IList<ControllerVM> models = new List<ControllerVM>();
            foreach (ControllerCache c in _controllerCacheData)
            {
                models.Add(new ControllerVM
                {
                    Address = c.Address,
                    Online = c.Online
                });
            }
            return models;
        }
        #endregion

        #region Cache
        static void UpdateCacheReady()
        {
            UpdateCache(_controllers);
        }

        /// <summary>
        /// Обновить кэшированные данные контроллеров
        /// </summary>
        /// <param name="controllers">Уже проинициализированные контроллеры при запуске службы</param>
        private static void UpdateCache(ConcurrentDictionary<long, IControllerAdapter> controllers)
        {
            if (controllers == null) return;

            _controllerCacheData = new List<ControllerCache>();
            foreach (var c in controllers)
            {
                IList<Register> registers = new List<Register>();
                bool isOnline = true;
                for (ushort address = Address.Low; address <= Address.High; address++)
                {
                    int value = 0;
                    try
                    {
                        value = c.Value.ReadHoldingRegisterWord(address);
                    }
                    catch 
                    {
                        isOnline = false;
                    }
                    registers.Add(new Register
                    {
                        Address = address,
                        Value = value
                    });
                }
                _controllerCacheData.Add(new ControllerCache 
                { 
                    Id = (int)c.Key, 
                    Address = c.Value.Address,
                    Online = isOnline, 
                    Registers = registers
                });
            }
        }

        /// <summary>
        /// Получить значение регистра
        /// </summary>
        private Register GetCacheReg(int controllerId, ushort address)
        {
            return _controllerCacheData.First(x => x.Id == controllerId)
                                       .Registers
                                       .First(x => x.Address == address);
        }

        /// <summary>
        /// Обновить значение регистра контроллера по адресу из кеша, до обновления кеша по таймеру
        /// </summary>
        private void UpdateCacheRegValue(int controllerId, ushort address, int value)
        {
            GetCacheReg(controllerId, address).Value = value;
        }
        #endregion
    }
}