using System.Numerics;

namespace RNSLib
{
    public partial class RNSNumber
    {
        /// <summary>
        /// Проверяет, что все числа в массиве попарно взаимно-простые
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static bool ArrayIsOfRelativePrimes(uint[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (!AreRelativePrimes(arr[i], arr[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Проверяет два числа на взаимную простоту
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true - если два числа взаимно-просты, false иначе</returns>
        private static bool AreRelativePrimes(uint a, uint b) => GCD(a, b) == 1;

        /// <summary>
        /// Расширенный алгоритм евклида, решает уравнение
        /// x * a + y * b = НОД(a, b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x">out-parameter</param>
        /// <param name="y">out-parameter</param>
        /// <returns>НОД(a, b)</returns>
        private static BigInteger GCDExtended(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            BigInteger x1, y1;
            BigInteger d = GCDExtended(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }

        /// <summary>
        /// Находит и возвращает такое число x, что
        ///             x * a = 1 (mod m)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static BigInteger GetMultiplicativeInversion(BigInteger a, uint m)
        {
            var d = GCDExtended(a, m, out BigInteger x, out BigInteger y);
            if (d != 1)
            {
                throw new RNSException($"Не существует мультипликативной инверсии {a} по модулю {m}");
            }
            return (x % m + m) % m;
        }

        /// <summary>
        /// Реализация алгоритма Евклида для поиска НОД
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>НОД(a,b)</returns>
        private static uint GCD(uint a, uint b)
        {
            while (b > 0)
            {
                a %= b;
                SwapUINT32(ref a, ref b);
            }

            return a;
        }

        /// <summary>
        /// Меняет значения двух переменных местами
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void SwapUINT32(ref uint a, ref uint b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}