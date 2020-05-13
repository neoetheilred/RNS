using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RNSLib
{
    public partial class RNSNumber : IEnumerable<uint>, IComparable<RNSNumber>, IComparable<BigInteger>
    {
        /// <summary>
        /// Массив для представления числа в виде набора отстатков от деления на модули из Modules
        /// </summary>
        private uint[] _remainders;

        /// <summary>
        /// Основания СОК
        /// </summary>
        public static uint[] Modules { get; private set; }

        /// <summary>
        /// Хранит произведение модулей системы
        /// </summary>
        public static BigInteger M { get; private set; }

        /// <summary>
        /// true - если было установлено основание СОК
        /// </summary>
        public static bool ModulesAreSet { get; private set; } = false;

        public delegate void RnsHandler();

        public static event RnsHandler ModulesChanged;

        /// <summary>
        /// Устанавливает общие для всех чисел основания СОК.
        /// При этом числа из modules проверяются на взаимную простоту
        /// </summary>
        /// <param name="modules">Массив с основаниями СОК</param>
        /// <exception cref="RNSException">Если хотя бы два числа не взаимно просты</exception>
        public static void SetModules(uint[] modules)
        {
            if (ArrayIsOfRelativePrimes(modules))
            {
                Modules = new uint[modules.Length];
                Array.Copy(modules, Modules, modules.Length);
                Array.Sort(Modules);
                ModulesAreSet = true;
                M = 1;
                foreach (var module in Modules)
                {
                    M *= module;
                }

                ModulesChanged?.Invoke();
            }
            else
            {
                throw new RNSException($"Переданные модули не взаимно-просты");
            }
        }

        /// <summary>
        /// Переводит число из СОК в десятичную систему без учета знака числа
        /// </summary>
        /// <returns></returns>
        public BigInteger ToUnsignedBigInteger()
        {
            BigInteger res = new BigInteger(0);
            for (int i = 0; i < _remainders.Length; ++i)
            {
                BigInteger Mi = M / Modules[i];
                res += (_remainders[i] * Mi * GetMultiplicativeInversion(Mi, Modules[i])) % M;
            }

            return res % M;
        }

        /// <summary>
        /// Переводит число из СОК в десятичную систему с учетом знака числа
        /// </summary>
        /// <returns></returns>
        public BigInteger ToSignedBigInteger()
        {
            var unsigned = ToUnsignedBigInteger();
            if (IsPositive(unsigned))
            {
                return unsigned;
            }

            return unsigned - M;
        }

        public bool IsPositive() => IsPositive(ToUnsignedBigInteger());

        /// <summary>
        /// Определяет знак десятичного числа в СОК
        /// </summary>
        /// <param name="b"></param>
        /// <returns>true если число положительное</returns>
        private static bool IsPositive(BigInteger b)
        {
            if (b < 0)
            {
                throw new ArgumentException("Expected to face positive integer, but negative was provided");
            }

            if (b % 2 != 0 && b <= (M - 1) / 2 + 1 || b <= M / 2 - 1)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Преобразует число в строку из остатков
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[{");
            foreach (var remainder in _remainders)
            {
                sb.Append($"{remainder}, ");
            }

            if (sb.Length > 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append("}; ");
            sb.Append($"Signed: {ToSignedBigInteger()}, Unsigned: {ToUnsignedBigInteger()}]");
            return sb.ToString();
        }
    }
}