using RNSAssembler;
using RNSExpressionCompiler;
using RNSLib;
using RNSMachine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace RNS
{
    class Program
    {
        private static string path = @"in.rns";
        private static string asm_path = @"..\..\a.asm";
        static void Main(string[] args)
        {
            RNSNumber.SetModules(RNSModuleSets.GetModuleSet(RNSModuleSets.ModuleSets.Mersenne));
            //MakeExec();
            var sw = new StringWriter();
            var sr = new StringReader("5/3");
            var expr = new RNSExpression(sw, sr);

            expr.Compile();

            string asm = "asm.asm";
            string exec = "out.bin";

            WriteToFile(sw.ToString(), asm);
            Console.WriteLine(sw);
            MakeExec(asm, exec);
            var state = Execute(exec);
            Console.WriteLine($"res = {state.R.ToSignedBigInteger()}");
        }

        static MachineState Execute(string exe)
        {
            if (!File.Exists(exe))
            {
                throw new FileNotFoundException();
            }

            try
            {
                using (var fs = File.Open(exe, FileMode.Open))
                {
                    using (var br = new BinaryReader(fs))
                    {
                        Machine machine = new Machine(br);
                        // machine.PrintBase();
                        while (!machine.End)
                        {
                            machine.StepOver();
                        }

                        return machine.GetState();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        static void WriteToFile(string s, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (var _ = File.Create(path))
                    {

                    }
                }
                using (var fs = File.Open(path, FileMode.Truncate))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.Write(s);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void MakeExec(string from, string to)
        {
            if (!File.Exists(from))
            {
                throw new FileNotFoundException();
            }
            if (!File.Exists(to))
            {
                using (var _ = File.Create(to)) { }
            }
            Assembler assembler = new Assembler();
            string asm = File.ReadAllText(from);
            using (var sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(asm))))
            {
                using (var bw = new BinaryWriter(File.Open(to, FileMode.Truncate)))
                {
                    assembler.Assembly(sr, bw);
                }
            }
        }

        static void WriteCommand(BinaryWriter bw, OpCodes opCode)
        {
            bw.Write((byte)opCode);
        }

        static void WriteReg(BinaryWriter bw, Registers reg)
        {
            bw.Write((byte)reg);
        }

        static void WriteRNS(BinaryWriter bw, RNSNumber number)
        {
            foreach (var u in number)
            {
                bw.Write(u);
            }
        }

        static void WriteDecimal(BinaryWriter bw, BigInteger bigInteger)
        {
            WriteRNS(bw, RNSNumber.FromBigInteger(bigInteger));
        }
    }

    class Disassembler
    {
        private BinaryReader _br;
        public Disassembler(BinaryReader br)
        {
            _br = br;
        }

        public string Disassemble()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"0x{_br.ReadUInt16():X}{Environment.NewLine}");
            sb.Append($"{ReadBase()}\r\n");
            while (_br.BaseStream.Position < _br.BaseStream.Length)
            {
                sb.Append($"{ReadCommand()}{Environment.NewLine}");
            }

            return sb.ToString();
        }

        private string ReadCommand()
        {
            StringBuilder sb = new StringBuilder();

            OpCodes opCode = (OpCodes)_br.ReadByte();
            switch (opCode)
            {
                case OpCodes.ADD:
                case OpCodes.SUB:
                case OpCodes.MUL:
                case OpCodes.MOD:
                case OpCodes.DIV:
                case OpCodes.TDC:
                case OpCodes.CMP:
                case OpCodes.PUSHR:
                    sb.Append($"{opCode}");
                    break;
                case OpCodes.JMP:
                case OpCodes.JEQ:
                case OpCodes.JNE:
                case OpCodes.JLT:
                case OpCodes.JLE:
                case OpCodes.JGE:
                case OpCodes.JGT:
                    sb.Append($"{opCode} {_br.ReadInt32()}");
                    break;
                case OpCodes.POP:
                    sb.Append($"{opCode} {ReadRegister()}");
                    break;
                case OpCodes.PUSH:
                    sb.Append($"{opCode} {ReadNumber()}");
                    break;
            }

            return sb.ToString();
        }

        private string ReadRegister()
        {
            byte reg = _br.ReadByte();
            return $"{(Registers)reg}";
        }

        private string ReadNumber()
        {
            List<uint> rems = new List<uint>();
            for (int i = 0; i < RNSNumber.Modules.Length; ++i)
            {
                rems.Add(_br.ReadUInt32());
            }

            return RNSNumber.FromRemainders(rems.ToArray()).ToSignedBigInteger().ToString();
        }

        private string ReadBase()
        {
            StringBuilder sb = new StringBuilder();

            List<uint> b = new List<uint>();
            int length = _br.ReadInt32();
            sb.Append("{ ");
            for (int i = 0; i < length; ++i)
            {
                uint t = _br.ReadUInt32();
                sb.Append($"{t} ");
                b.Add(t);
            }

            sb.Append($"}}{Environment.NewLine}");
            RNSNumber.SetModules(b.ToArray());

            return sb.ToString();
        }
    }
}
