using RNSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RNSMachine
{
    public class MachineState
    {
        public RNSNumber A { get; }
        public RNSNumber B { get; }
        public RNSNumber R { get; }
        public int C { get; }
        public IEnumerable<RNSNumber> StackBlueprint { get; }
        public string LastExecuted { get; }

        public MachineState(RNSNumber a, RNSNumber b, RNSNumber r, int c, string lastExecuted, IEnumerable<RNSNumber> stack)
        {
            A = a;
            B = b;
            R = r;
            C = c;
            LastExecuted = lastExecuted;
            StackBlueprint = stack;
        }

        private static string Indent { get; } = "  ";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"A = {A}{Environment.NewLine}");
            sb.Append($"B = {B}{Environment.NewLine}");
            sb.Append($"R = {R}{Environment.NewLine}");
            sb.Append($"C = {C}{Environment.NewLine}");
            sb.Append($"Last executed = {LastExecuted}{Environment.NewLine}");
            sb.Append("Stack: ");
            if (!StackBlueprint.Any())
            {
                sb.Append("{}");
                return sb.ToString();
            }

            sb.Append("\r\n");
            foreach (var rnsNumber in StackBlueprint)
            {
                sb.Append($"{Indent}{rnsNumber}\r\n");
            }


            return sb.ToString();
        }
    }
}