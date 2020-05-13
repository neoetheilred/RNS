using System.Collections;
using System.Collections.Generic;

namespace RNSLib
{
    public partial class RNSNumber
    {
        /// <summary>
        /// Реализация интерфейса IEnumerable<uint>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<uint> GetEnumerator()
        {
            foreach (var remainder in _remainders)
            {
                yield return remainder;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}