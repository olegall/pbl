using System;

namespace Modbus
{
    public interface IControllerAdapter : IDisposable
    {
        bool ReadHoldingRegister(ushort registerAddress);

        ushort ReadHoldingRegisterWord(ushort registerAddress);

        void WriteSingleRegister(ushort registerAddress, bool value);

        void WriteSingleRegister(ushort registerAddress, ushort value);

        bool Connected { get; }
        
        string Address { get; }
    }
}