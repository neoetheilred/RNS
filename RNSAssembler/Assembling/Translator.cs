using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using RNSLib;

namespace RNSAssembler.Assembling
{
    internal class Translator : ASMBaseListener
    {
        private Dictionary<string, int> _labels;
        private BinaryWriter _binaryWriter;

        private bool _checkDivision;

        public Translator(Dictionary<string, int> labels, BinaryWriter bw, bool check_div = false)
        {
            _labels = labels;
            _binaryWriter = bw;
            _checkDivision = check_div;
        }

        private void WriteMagicNumber()
        {
            _binaryWriter.Write(RNSMachine.Machine.MagicNumber);
        }

        private void WriteBase()
        {
            if (!RNSNumber.ModulesAreSet)
            {
                throw new RNSAssemblyException("No base for RNS was set");
            }
            _binaryWriter.Write(RNSNumber.Modules.Length);
        }

        public override void EnterAsm(ASMParser.AsmContext context)
        {
            WriteMagicNumber();
            WriteBase();
            if (_checkDivision)
            {
                WriteOpCode("TDC");
            }
        }

        public override void EnterArithmetic(ASMParser.ArithmeticContext context)
        {
            WriteOpCode(context.cmd.Text);
        }

        public override void EnterDup(ASMParser.DupContext context)
        {
            WriteOpCode(context.DUP().GetText());
        }

        public override void EnterNum_list(ASMParser.Num_listContext context)
        {
            var rems = new List<uint>();
            foreach (var terminalNode in context.NUMBER())
            {
                rems.Add(uint.Parse(terminalNode.GetText()));
            }

            WriteRnsNumber(RNSNumber.FromRemainders(rems.ToArray()));
        }

        public override void EnterPushNum(ASMParser.PushNumContext context)
        {
            WriteOpCode(context.PUSH().GetText());
            if (context.NUMBER() != null)
            {
                WriteRnsNumber(RNSNumber.FromBigInteger(BigInteger.Parse(context.NUMBER().GetText())));
            }
        }

        public override void EnterPopReg(ASMParser.PopRegContext context)
        {
            WriteOpCode(context.POP().GetText());
            WriteReg(context.reg.Text);
        }

        public override void EnterPushR(ASMParser.PushRContext context)
        {
            WriteOpCode(context.PUSHR().GetText());
        }

        public override void EnterTdc(ASMParser.TdcContext context)
        {
            WriteOpCode(context.TDC().GetText());
        }

        public override void EnterControl_flow(ASMParser.Control_flowContext context)
        {
            WriteOpCode(context.cmd.Text);
            WriteLabelAddress(context.LABEL().GetText());
        }



        private void WriteLabelAddress(string lbl)
        {
            _binaryWriter.Write(_labels[lbl]);
        }

        private void WriteOpCode(string s)
        {
            _binaryWriter.Write((byte)Enum.Parse(typeof(RNSMachine.OpCodes), s));
        }

        private void WriteReg(string s)
        {
            _binaryWriter.Write((byte)Enum.Parse(typeof(RNSMachine.Registers), s));
        }

        private void WriteRnsNumber(RNSNumber number)
        {
            foreach (var u in number)
            {
                _binaryWriter.Write(u);
            }
        }
    }
}