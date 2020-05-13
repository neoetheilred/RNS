using System.Numerics;

namespace RNSLib
{
    public partial class RNSNumber
    {
        /// <summary>
        /// Приватный конструктор для пролучения RNS-числа из длинного числа
        /// </summary>
        /// <param name="bigInteger"></param>
        private RNSNumber(BigInteger bigInteger)
        {
            _remainders = new uint[Modules.Length];
            for (int i = 0; i < Modules.Length; ++i)
            {
                _remainders[i] = (uint) (bigInteger % Modules[i]);
            }
        }

        /// <summary>
        /// Приватный конструктор для получения RNS-числа из набора остатков
        /// </summary>
        /// <param name="remainders"></param>
        private RNSNumber(uint[] remainders)
        {
            _remainders = new uint[Modules.Length];
            for (var i = 0; i < _remainders.Length; i++)
            {
                _remainders[i] = remainders[i];
            }
        }
    }
}