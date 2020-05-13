using System.Numerics;

namespace RNSLib
{
    public partial class RNSNumber
    {
        /// <summary>
        /// Реализация IComparable<RNSNumber>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(RNSNumber other)
        {
            return ToUnsignedBigInteger().CompareTo(other.ToUnsignedBigInteger());
        }

        /// <summary>
        /// Реализация IComparable<BigInteger>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(BigInteger other)
        {
            return ToUnsignedBigInteger().CompareTo(other);
        }
    }
}