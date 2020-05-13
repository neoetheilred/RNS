using System;
using System.IO;
using System.Linq;
using RNSLib;

namespace RNSExpressionCompiler.Compiling
{
    public class ExpressionCompiler : ExprBaseListener
    {
        private TextWriter _sw;
        private bool check = false;

        public ExpressionCompiler(TextWriter sw, uint[] modules = null, bool ch = false)
        {
            check = ch;
            _sw = sw;
            if (modules != null)
            {
                RNSNumber.SetModules(modules);
            }
            else
            {
                RNSNumber.SetModules(RNSModuleSets.GetModuleSet(RNSModuleSets.ModuleSets.Default));
            }
        }

        public override void EnterR(ExprParser.RContext context)
        {
            _sw.WriteLine($"{{{string.Join(" ", RNSNumber.Modules)}}}");
            if (check)
            {
                _sw.WriteLine("TDC");
            }
        }

        public override void EnterAtomNum(ExprParser.AtomNumContext context)
        {
            _sw.WriteLine($"PUSH {context.NUM().GetText()}");
        }

        public override void EnterRnsNum(ExprParser.RnsNumContext context)
        {
            uint[] mods = context.modList().NUM().Select(x => x.GetText()).Select(uint.Parse).ToArray();
            _sw.WriteLine($"PUSH {RNSNumber.FromRemainders(mods).ToSignedBigInteger()}");
        }

        public override void ExitUnaryMinus(ExprParser.UnaryMinusContext context)
        {
            _sw.WriteLine("POP A");
            _sw.WriteLine("NEG");
            _sw.WriteLine("PUSHR");
        }

        public override void ExitAddition(ExprParser.AdditionContext context)
        {
            _sw.WriteLine("POP B");
            _sw.WriteLine("POP A");
            if (context.op.Text == "+")
            {
                _sw.WriteLine("ADD");
            }
            else if (context.op.Text == "-")
            {
                _sw.WriteLine("SUB");
            }
            else
            {
                throw new NotSupportedException();
            }
            _sw.WriteLine("PUSHR");
        }

        public override void ExitMultiplication(ExprParser.MultiplicationContext context)
        {
            _sw.WriteLine("POP B");
            _sw.WriteLine("POP A");
            if (context.op.Text == "*")
            {
                _sw.WriteLine("MUL");
            }
            else if (context.op.Text == "/")
            {
                _sw.WriteLine("DIV");
            }
            else
            {
                throw new NotSupportedException();
            }
            _sw.WriteLine("PUSHR");
        }
    }
}