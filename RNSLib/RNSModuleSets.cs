using System;
using System.Collections.Generic;

namespace RNSLib
{
    /// <summary>
    /// Содержит некоторые основания СОК
    /// </summary>
    public static class RNSModuleSets
    {
        public enum ModuleSets
        {
            Fermat,
            Mersenne,
            Simple,
            Default
        }

        private static uint[] _fermat = { 3, 5, 17, 257, 65537 };
        private static uint[] _mersenne = { 3, 7, 31, 127, 8191, 131071 };
        private static uint[] _default = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43 };
        private static uint[] _simple = { 2, 5, 11 };

        private static Dictionary<ModuleSets, uint[]> _mapping = new Dictionary<ModuleSets, uint[]>()
        {
            {ModuleSets.Fermat, _fermat},
            {ModuleSets.Mersenne, _mersenne},
            {ModuleSets.Default, _default },
            {ModuleSets.Simple, _simple }
        };

        /// <summary>
        /// Возвращает набор оснований 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static uint[] GetModuleSet(ModuleSets id)
        {
            uint[] res = new uint[_mapping[id].Length];
            Array.Copy(_mapping[id], res, _mapping[id].Length);
            return res;
        }
    }
}