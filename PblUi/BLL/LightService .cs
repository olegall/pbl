using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PblDAL.Models;
using PblUi.Models;
using PblDAL.Reps;
using System;

namespace PblUi.BLL
{
    public class LightService
    {
        private readonly _lightRepository _rep;
        private readonly IGenericRepository<Color> _colorRep;
        private readonly IGenericRepository<Controller> _controllerRep;

        #region Default data
        private enum ModuleNums
        {
            FirstMin = 1,
            FirstMax = 16,
            LastMin = FirstMax + 1,
            LastMax = 28
        }

        public static class Addr
        {
            public static ushort Low { get; set; } = 0x300;
            public static ushort High { get; set; } = 0x320;
        }
        #endregion

        public LightService(ApplicationContext context)
        {
            _colorRep = new ColorRepository(context);
            _rep = new _lightRepository(context);
            _controllerRep = new ControllerRepository(context);
        }

        private async Task<IEnumerable<Controller>> GetControllers() 
        {
            return await _controllerRep.GetAllAsync();
        }

        private async Task<IEnumerable<Color>> GetColors()
        {
            return await _colorRep.GetAllAsync();
        }

        private async Task<IEnumerable<Light>> GetAll()
        {
            return (await _rep.GetAllAsync()).OrderBy(x => x.Address).ThenBy(x => x.Num);
        }

        public async Task CreateAsync(Light l) 
        {
            l.Id = Guid.NewGuid().ToString();
            await _rep.CreateAsync(l);
        }

        public Task UpdateAsync(Light l)
        {
            return _rep.UpdateAsync(l);
        }

        public Task DeleteAsync(string id)
        {
            return _rep.DeleteAsync(id);
        }

        /// <summary>
        /// Модель для CRUD ламп по одной
        /// </summary>
        public async Task<LightVM> GetVm()
        {
            return new LightVM
            {
                Lights = await GetAll(),
                Controllers = await GetControllers(),
                Colors = await GetColors(),
                Addrs = GetAddrs(),
                ModuleNums = new ModuleNum((int)ModuleNums.FirstMin, (int)ModuleNums.FirstMax, (int)ModuleNums.LastMin, (int)ModuleNums.LastMax)
            };
        }

        #region CRUD Many
        public async Task CreateManyAsync(CreateMany m)
        {
            for (int addr = m.AddressMin; addr <= m.AddressMax; addr++)
            {
                int numMin = GetNums(addr).Min;
                int numMax = GetNums(addr).Max;
                for (int num = numMin; num <= numMax; num++)
                {
                    Light l = new Light
                    {
                        Id = Guid.NewGuid().ToString(),
                        ControllerId = m.ControllerId,
                        ColorId = m.ColorId,
                        Address = addr,
                        Num = num
                    };
                    await _rep.CreateAsync(l);
                }
            }
        }

        public async Task UpdateManyAsync(UpdateMany m)
        {
            m.DefaultNumber = GetDefaultNumber(m.Address);
            bool isAddressPartChanged = IsAddressPartChanged(m.Address, m.OldAddress);
            foreach (string id in m.Id.Where(x => x != null))
            {
                await _rep.UpdateManyAsync(id, m.Address, m.DefaultNumber, m.ColorId, isAddressPartChanged);
                m.DefaultNumber++;
            }
        }

        private bool IsAddressPartChanged(int address, int oldAddress) 
        {
            return oldAddress == Addr.Low && IsAddressEven(address) || address == Addr.Low && IsAddressEven(oldAddress) || !(IsAddressEven(address) && IsAddressEven(oldAddress));
        }

        private bool IsAddressEven(int address)
        {
            return address % 2 == 0;
        }

        public async Task DeleteManyAsync(DeleteMany m)
        {
            foreach (string id in m.Id.Where(x => x != null))
            {
                await _rep.DeleteAsync(id);
            }
        }

        /// <summary>
        /// Получить диапазон номеров для каждого адреса для множественного заполнения
        /// </summary>
        private Num GetNums(int addr)
        {
            return addr == Addr.Low || addr % 2 != 0 ? new Num((int)ModuleNums.FirstMin, (int)ModuleNums.FirstMax) : new Num((int)ModuleNums.LastMin, (int)ModuleNums.LastMax);
        }

        /// <summary>
        /// Получить номер лампы по умолчанию при переносе адреса(ов)
        /// при множественном редактировании
        /// </summary>
        private int GetDefaultNumber(int address)
        {
            return address == Addr.Low || address % 2 != 0 ? (int)ModuleNums.FirstMin : (int)ModuleNums.LastMin;
        }

        public async Task<UpdateMany> GetUpdateManyModel(UpdateMany m) 
        {
            m.AddrLow = Addr.Low;
            m.AddrHigh = Addr.High;
            m.OldAddress = (ushort)m.Address;
            m.Colors = await _colorRep.GetAllAsync();
            return m;
        }
        #endregion

        private IEnumerable<int> GetAddrs()
        {
            IList<int> addrs = new List<int>();
            for (int addr = Addr.Low; addr <= Addr.High; addr++)
            {
                addrs.Add(addr);
            }
            return addrs;
        }
    }
}