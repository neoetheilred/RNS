using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RNSAssembler.Assembling;

namespace RNSAssembler
{
    public class Assembler
    {
        public void Assembly(StreamReader sr, BinaryWriter bw, bool check_div = false)
        {
            AntlrInputStream inputStream = new AntlrInputStream(sr);
            ASMLexer lexer = new ASMLexer(inputStream);
            CommonTokenStream cts = new CommonTokenStream(lexer);
            ASMParser parser = new ASMParser(cts);

            LabelScanner scanner = new LabelScanner();
            ParseTreeWalker walker = new ParseTreeWalker();
            IParseTree parseTree = parser.asm();
            walker.Walk(scanner, parseTree);
            Translator translator = new Translator(scanner.Labels, bw, check_div);
            walker.Walk(translator, parseTree);
        }
    }
}