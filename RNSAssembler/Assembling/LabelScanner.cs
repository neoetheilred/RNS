using System.Collections.Generic;
using RNSLib;

namespace RNSAssembler.Assembling
{
    internal class LabelScanner : ASMBaseListener
    {
        public Dictionary<string, int> Labels { get; } = new Dictionary<string, int>();
        private int _byteOffset = 0;

        public override void EnterBase(ASMParser.BaseContext context)
        {
            List<uint> basement = new List<uint>();
            foreach (var terminalNode in context.num_list().NUMBER())
            {
                basement.Add(uint.Parse(terminalNode.GetText()));
            }

            RNSNumber.SetModules(basement.ToArray());
        }

        public override void EnterLabel(ASMParser.LabelContext context)
        {
            Labels[context.LABEL().GetText()] = _byteOffset;
        }

        public override void EnterArithmetic(ASMParser.ArithmeticContext context)
        {
            ++_byteOffset;
        }

        public override void EnterControl_flow(ASMParser.Control_flowContext context)
        {
            _byteOffset += 5; // 1 - длина команды, 4 - длина адреса команды
        }

        public override void EnterTdc(ASMParser.TdcContext context)
        {
            ++_byteOffset;
        }

        public override void EnterPopReg(ASMParser.PopRegContext context)
        {
            _byteOffset += 2; // Длина команды + длина названия регистра
        }

        public override void EnterPushR(ASMParser.PushRContext context)
        {
            ++_byteOffset;
        }

        public override void EnterPushNum(ASMParser.PushNumContext context)
        {
            ++_byteOffset; // Длина команды
            _byteOffset += 4 * RNSNumber.Modules.Length; // Длина числа в СОК 
        }

        public override void EnterDup(ASMParser.DupContext context)
        {
            ++_byteOffset;
        }
    }
}