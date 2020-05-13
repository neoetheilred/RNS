using System;
using System.Collections.Generic;
using System.IO;
using RNSLib;

namespace RNSMachine
{
    public partial class Machine
    {
        private byte[] _code;
        private BinaryReader _binaryReader;
        public static ushort MagicNumber { get; } = 0xBEAF;

        private bool Eof => _binaryReader.BaseStream.Position >= _binaryReader.BaseStream.Length;

        public Machine(BinaryReader binaryReader)
        {
            this._binaryReader = binaryReader;
            CheckMagicNumber();
            SetRnsBase();
            ReadCode();
        }

#if DEBUG
        public void PrintBase()
        {
            Console.Write("{ ");
            foreach (var module in RNSNumber.Modules)
            {
                Console.Write($"{module}, ");
            }
            Console.WriteLine("\b\b }");
        }
#endif
        private void ReadCode()
        {
            List<byte> bytes = new List<byte>();
            while (!Eof)
            {
                bytes.Add(_binaryReader.ReadByte());
            }

            _code = bytes.ToArray();
        }

        private void CheckMagicNumber()
        {
            ushort number = _binaryReader.ReadUInt16();
            if (number != MagicNumber)
            {
                throw new RNSRuntimeException($"Invalid input file format (Magic number was incorrect, {number} but expected {MagicNumber})");
            }
        }

        private void SetRnsBase()
        {
            int baseLength = _binaryReader.ReadInt32();
            uint[] modules = new uint[baseLength];
            for (var i = 0; i < modules.Length; i++)
            {
                modules[i] = _binaryReader.ReadUInt32();
            }
            RNSNumber.SetModules(modules);
        }
    }
}