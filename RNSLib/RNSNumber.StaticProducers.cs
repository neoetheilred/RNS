using System.Numerics;

namespace RNSLib
{
    public partial class RNSNumber
    {
        /// <summary>
        /// Создает и возвращает число в СОК на основе десятичного числа
        /// </summary>
        /// <param name="integer">число в десятичной СС</param>
        /// <returns></returns>
        public static RNSNumber FromBigInteger(BigInteger integer)
        {
            if (!ModulesAreSet)
            {
                throw new RNSException("Не были заданы основания СОК");
            }

            integer = integer % M;
            if (integer < 0)
            {
                integer += M;
            }

            return new RNSNumber(integer);
        }

        /// <summary>
        /// Создает и возвращает число в СОК на основе набора остатков по модулям СОК
        /// </summary>
        /// <param name="reminders">набор остатков по модулям СОК</param>
        /// <returns></returns>
        public static RNSNumber FromRemainders(uint[] reminders)
        {
            if (reminders.Length != Modules.Length)
            {
                throw new RNSException("Количество остатков должно быть равно количеству модулей в основании");
            }
            return new RNSNumber(reminders);
        }
    }
}