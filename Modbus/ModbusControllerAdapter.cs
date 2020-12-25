using System;
using System.Globalization;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonHelpers;
using NModbus;
using NLog;

namespace Modbus
{
    public class ModbusControllerAdapter : IControllerAdapter
    {
        private const ushort RegisterForPoll = 1;
        private const ushort RegisterOffset = 511;
        private const decimal VersionWithCommunicationState = 0.5m;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly string _connectionErrorMessage = "Connection is not established: ";
        private readonly long _controllerId;
        private readonly byte _slaveAddress;
        private readonly string _host;
        private readonly int _port;
        private volatile bool _connectionEstablished;
        private int _receiveTimeout;
        private int _sendTimeout;
        private decimal _firmwareVersion;
        private IModbusMaster _client;

        public delegate void PollingHandler();
        public static event PollingHandler PollingFinished;

        public ModbusControllerAdapter(long id, byte slaveAddress, string host, int port)
        {
            _controllerId = id;
            _slaveAddress = slaveAddress;
            _host = host;
            _port = port;
            _connectionErrorMessage += _controllerId;
        }

        public void Init(int receiveTimeout, int sendTimeout)
        {
            _receiveTimeout = receiveTimeout;
            _sendTimeout = sendTimeout;

            EstablishConnection();
            Task.Factory.StartNew(ProcessPolling);
        }

        public static void InvokePollingFinished() 
        {
            PollingFinished?.Invoke();
        }

        public bool Connected
        {
            get
            {
                return _connectionEstablished;
            }
        }
        
        public string Address
        {
            get
            {
                return _host;
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        /// <summary>
        /// Устанавливает состояние дискретного выхода в заданное значение
        /// </summary>
        /// <param name="registerAddress">Адрес дискретного выхода</param>
        /// <param name="value">Значение выхода</param>
        public void WriteSingleRegister(ushort registerAddress, bool value)
        {
            if (!_connectionEstablished)
            {
                throw new InvalidOperationException(_connectionErrorMessage);
            }

            try
            {
                ushort address = (ushort)(registerAddress);
                ushort write = (ushort)(value ? 1 : 0);
                _logger.Trace($"Controller: {_controllerId}|WriteSingleRegister ({address}, {write})");
                _client.WriteSingleRegister(_slaveAddress, address, write);
            }
            catch
            {
                _connectionEstablished = false;
                throw;
            }
        }

        /// <summary>
        /// Устанавливает состояние дискретного выхода модуля расширения в заданное значение
        /// </summary>
        /// <param name="registerAddress">Адрес дискретного выхода</param>
        /// <param name="value">Значение выхода</param>
        public void WriteSingleRegister(ushort registerAddress, ushort value)
        {
            if (!_connectionEstablished)
            {
                throw new InvalidOperationException(_connectionErrorMessage);
            }

            try
            {
                ushort address = (ushort)(registerAddress);
                ushort write = value;
                _logger.Trace($"Controller: {_controllerId}|WriteSingleRegister ({address}, {write})");
                _client.WriteSingleRegister(_slaveAddress, address, write);
            }
            catch
            {
                _connectionEstablished = false;
                throw;
            }
        }

        /// <summary>
        /// Возвращает состояние дискретного выхода
        /// </summary>
        /// <param name="registerAddress">Адрес дискретного выхода</param>
        public bool ReadHoldingRegister(ushort registerAddress)
        {
            if (!_connectionEstablished)
            {
                throw new InvalidOperationException(_connectionErrorMessage);
            }

            try
            {
                _logger.Trace($"Controller: {_controllerId}|ReadHoldingRegister ({registerAddress})");
                var value = _client.ReadHoldingRegisters(_slaveAddress, (ushort)(registerAddress), 1)[0] == 1;
                _logger.Trace($"Controller: {_controllerId}|{registerAddress} == {value}");
                return value;
            }
            catch
            {
                _connectionEstablished = false;
                throw;
            }
        }

        /// <summary>
        /// Возвращает значение дискретного выхода (слово)
        /// </summary>
        public ushort ReadHoldingRegisterWord(ushort registerAddress)
        {
            if (!_connectionEstablished)
            {
                throw new InvalidOperationException(_connectionErrorMessage);
            }

            try
            {
                _logger.Trace($"Controller: {_controllerId}|ReadHoldingRegister ({registerAddress})");
                var value = _client.ReadHoldingRegisters(_slaveAddress, (ushort)(registerAddress), 1)[0];
                _logger.Trace($"Controller: {_controllerId}|{registerAddress} == {value}");
                return value;
            }
            catch
            {
                _connectionEstablished = false;
                throw;
            }
        }

        private static decimal ParseFirmwareVersion(string version)
        {
            try
            {
                return decimal.Parse(version.Substring(1), CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.FullErrorMessage());
                return 0;
            }
        }

        private void ProcessPolling()
        {
            while (true)
            {
                if (_connectionEstablished)
                {
                    Poll();
                }
                else
                {
                    EstablishConnection();
                }

                Thread.Sleep(_connectionEstablished ? 5000 : 1000);
                PollingFinished?.Invoke();
            }
        }

        private void Poll()
        {
            try
            {
                if (_firmwareVersion < VersionWithCommunicationState)
                {
                    ReadHoldingRegister(RegisterForPoll);
                }
                else
                {
                    RequestCommunicationState();
                }
            }
            catch
            {
                _connectionEstablished = false;
            }
        }

        private void RequestCommunicationState()
        {
            if (!_connectionEstablished)
            {
                throw new InvalidOperationException(_connectionErrorMessage);
            }

            try
            {
                var requestsAmount = _client.ReadInputRegisters(_slaveAddress, 0x0D, 1)[0];
                var responsesAmount = _client.ReadInputRegisters(_slaveAddress, 0x0E, 1)[0];
                var checkSumErrorsAmount = _client.ReadInputRegisters(_slaveAddress, 0x0F, 1)[0];

                var firstDiscreteInput = _client.ReadHoldingRegisters(_slaveAddress, 0x80, 1)[0];
                var secondDiscreteInput = _client.ReadHoldingRegisters(_slaveAddress, 0x81, 1)[0];
                var thirdDiscreteInput = _client.ReadHoldingRegisters(_slaveAddress, 0x82, 1)[0];
                var fourthDiscreteInput = _client.ReadHoldingRegisters(_slaveAddress, 0x83, 1)[0];

                _logger.Trace($@"Controller: {_controllerId}|Requests: {requestsAmount}; Responses: {responsesAmount}; Check sum errors: {checkSumErrorsAmount}; 
                                 di1: {firstDiscreteInput}; di2: {secondDiscreteInput}; di3: {thirdDiscreteInput}; di4: {fourthDiscreteInput}"); 
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.FullErrorMessage());
                _connectionEstablished = false;
                throw;
            }
        }

        private void EstablishConnection()
        {
            try
            {
                InitConnection();
                _connectionEstablished = true;
                ReadControllerInfo();
                if (_firmwareVersion >= VersionWithCommunicationState)
                {
                    RequestCommunicationState();
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Controller: {_controllerId}|Connection was not established");
                _logger.Error(ex, ex.FullErrorMessage());
            }
        }

        private void InitConnection()
        {
            _logger.Info($"Controller: {_controllerId}|Trying to establish connection");
            _client = new ModbusFactory().CreateMaster(CreateTcpClient());
            _logger.Info($"Controller: {_controllerId}| Connection was successfully established");
        }

        private TcpClient CreateTcpClient()
        {
            return new TcpClient(_host, _port) { ReceiveTimeout = _receiveTimeout, SendTimeout = _sendTimeout };
        }

        private void ReadControllerInfo()
        {
            if (!_connectionEstablished)
            {
                throw new InvalidOperationException(_connectionErrorMessage);
            }

            try
            {
                var deviceIdBuf = new byte[4];
                var firmwareVersionBuf = new byte[4];
                var controllerIdBuf = new byte[12];
                Buffer.BlockCopy(_client.ReadInputRegisters(_slaveAddress, 0, 2), 0, deviceIdBuf, 0, deviceIdBuf.Length);
                Array.Reverse(deviceIdBuf);
                Buffer.BlockCopy(_client.ReadInputRegisters(_slaveAddress, 2, 2), 0, firmwareVersionBuf, 0, firmwareVersionBuf.Length);
                Array.Reverse(firmwareVersionBuf);
                Buffer.BlockCopy(_client.ReadInputRegisters(_slaveAddress, 7, 6), 0, controllerIdBuf, 0, controllerIdBuf.Length);
                var deviceId = Encoding.ASCII.GetString(deviceIdBuf);
                var firmwareVersion = Encoding.ASCII.GetString(firmwareVersionBuf);
                _firmwareVersion = ParseFirmwareVersion(firmwareVersion);
                var controllerId = BitConverter.ToString(controllerIdBuf);

                _logger.Trace($"Controller: {_controllerId}|Device id: {deviceId}");
                _logger.Trace($"Controller: {_controllerId}|Firmware version: {firmwareVersion}");
                _logger.Trace($"Controller: {_controllerId}|Controller id: {controllerId}");
            }
            catch (Exception ex)
            {
                _logger.Error($"Controller: {_controllerId}|Connection was not established");
                _logger.Error(ex, ex.FullErrorMessage());
            }
        }
    }
}