using System;

namespace RNSLib
{
    public partial class RNSNumber
    {
        #region ArithmeticOperators
        /// <summary>
        /// Перегруженный оператор сложения
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Результат сложения a и b</returns>
        public static RNSNumber operator +(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Add(a, b);
        }

        /// <summary>
        /// Перегруженный оператор умножения
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>результат умножения a на b</returns>
        public static RNSNumber operator *(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Mul(a, b);
        }

        /// <summary>
        /// Перегруженный оператор вычитания
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>результат вычитания b из a</returns>
        public static RNSNumber operator -(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Sub(a, b);
        }

        /// <summary>
        /// Перегруженный оператор целочисленного деления
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>результат деления b на a</returns>
        public static RNSNumber operator /(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Div(a, b);
        }

        /// <summary>
        /// Перегруженный оператор взятия остатка
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>остаток от целочисленного деления a на b </returns>
        public static RNSNumber operator %(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Mod(a, b);
        }

        /// <summary>
        /// Перегруженный унарный минус
        /// </summary>
        /// <param name="a"></param>
        /// <returns>-a</returns>
        public static RNSNumber operator -(RNSNumber a)
        {
            return new RNSNumber(0) - a;
        }
        #endregion

        #region CmpOperators
        public static bool operator >(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Compare(a, b) > 0;
        }

        public static bool operator <(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Compare(a, b) < 0;
        }

        public static bool operator ==(RNSNumber a, RNSNumber b)
        {
            return RNSArithmetic.Compare(a, b) == 0;
        }

        public static bool operator !=(RNSNumber a, RNSNumber b)
        {
            return !(a == b);
        }

        public static bool operator <=(RNSNumber a, RNSNumber b)
        {
            return a < b || a == b;
        }

        public static bool operator >=(RNSNumber a, RNSNumber b)
        {
            return a > b || a == b;
        }
#endregion
    }
}