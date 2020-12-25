using System;

namespace PblService.BLL
{
    public class BinaryService
    {
        private enum Bits { Min = 0, Max = 15}

        /// <summary>
        /// Проверяет установлен ли бит в слове (0 - 15)
        /// </summary>
        public bool IsBitSet(ushort word, int bitNum)
        {
            CheckBitNum(bitNum);
            return (word >> bitNum & 1) == 1;
        }

        /// <summary>
        /// Устанавливает бит в слове (0 - 15)
        /// </summary>
        public ushort SetBit(ushort word, int bitNum)
        {
            CheckBitNum(bitNum);
            return (ushort)(word | 1 << bitNum);
        }

        /// <summary>
        /// Сбрасывает бит в слове (0 - 15)
        /// </summary>
        public ushort ClearBit(ushort word, int bitNum)
        {
            CheckBitNum(bitNum);
            return (ushort)(word & ~(1 << bitNum));
        }

        private void CheckBitNum(int bitNum) 
        {
            if (bitNum < (ushort)Bits.Min || bitNum > (ushort)Bits.Max)
                throw new ArgumentOutOfRangeException($"Номер бита должен быть от 0 до 15 {nameof(bitNum)}");
        }
    }
}