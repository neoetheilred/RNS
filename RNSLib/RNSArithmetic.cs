using System;
using System.Linq;

namespace RNSLib
{
    public static class RNSArithmetic
    {
        #region Arithmetic
        /// <summary>
        /// Складывает два числа в CОК
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>результат сложения a и b</returns>
        public static RNSNumber Add(RNSNumber a, RNSNumber b)
        {
            uint[] result = new uint[RNSNumber.Modules.Length];
            uint[] aMods = a.ToArray();
            uint[] bMods = b.ToArray();
            if (aMods.Length != result.Length || bMods.Length != result.Length)
            {
                throw new RNSException($"Числа были представлены в СОК с разными основаниями");
            }

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = (aMods[i] + bMods[i]) % RNSNumber.Modules[i];
            }

            return RNSNumber.FromRemainders(result);
        }

        /// <summary>
        /// Умножает два числа в CОК
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>результат умножения a и b</returns>
        public static RNSNumber Mul(RNSNumber a, RNSNumber b)
        {
            uint[] result = new uint[RNSNumber.Modules.Length];
            uint[] aMods = a.ToArray();
            uint[] bMods = b.ToArray();
            if (aMods.Length != result.Length || bMods.Length != result.Length)
            {
                throw new RNSException($"Числа были представлены в СОК с разными основаниями");
            }

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = (uint)(((ulong)aMods[i] * bMods[i]) % RNSNumber.Modules[i]);
            }

            var res = RNSNumber.FromRemainders(result);

            return res;
        }

        /// <summary>
        /// Вычитает два числа
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>результат вычитания b из a</returns>
        public static RNSNumber Sub(RNSNumber a, RNSNumber b)
        {
            uint[] result = new uint[RNSNumber.Modules.Length];
            uint[] aMods = a.ToArray();
            uint[] bMods = b.ToArray();
            if (aMods.Length != result.Length || bMods.Length != result.Length)
            {
                throw new RNSException($"Числа были представлены в СОК с разными основаниями");
            }

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = (aMods[i] - bMods[i] + RNSNumber.Modules[i]) % RNSNumber.Modules[i];
            }

            return RNSNumber.FromRemainders(result);
        }

        /// <summary>
        /// Делит число a на число b, предполагая, что деление нацело возможно
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static RNSNumber Div(RNSNumber a, RNSNumber b)
        {
            uint[] result = new uint[RNSNumber.Modules.Length];
            uint[] aMods = a.ToArray();
            uint[] bMods = b.ToArray();
            if (aMods.Length != result.Length || bMods.Length != result.Length)
            {
                throw new RNSException($"Числа были представлены в СОК с разными основаниями");
            }

            for (var i = 0; i < result.Length; i++)
            {
                try
                {
                    result[i] =
                        (uint) ((aMods[i] * RNSNumber.GetMultiplicativeInversion(bMods[i], RNSNumber.Modules[i])) %
                                RNSNumber.Modules[i]);
                }
                catch (RNSException e)
                {
                    throw new RNSException($"Целочисленное деление невозможно: {e.Message}");
                }
            }

            return RNSNumber.FromRemainders(result);
        }

        /// <summary>
        /// Вычисляет остаток от деления a на b, используя перевод из СОК в позиционную СС
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static RNSNumber Mod(RNSNumber a, RNSNumber b)
        {
            return RNSNumber.FromBigInteger(a.ToSignedBigInteger() % b.ToSignedBigInteger());
        }
#endregion
        /// <summary>
        /// Сравнивает два числа в СОК
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// отрицательное целое, если a меньше b
        /// положительное целое, если a больше b
        /// 0 если a == b
        /// </returns>
        public static int Compare(RNSNumber a, RNSNumber b)
        {
            return a.ToUnsignedBigInteger().CompareTo(b.ToUnsignedBigInteger());
        }
    }
}