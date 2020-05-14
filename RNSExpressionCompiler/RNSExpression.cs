using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RNSExpressionCompiler.Compiling;
using RNSLib;

namespace RNSExpressionCompiler
{
    /// <summary>
    /// Предоставляет функционал для обработки арифметических выражений
    /// </summary>
    public class RNSExpression
    {
        private TextWriter _sw;
        private TextReader _source;
        private bool _check;

        public RNSExpression(TextWriter sw, TextReader sr, bool ch = false)
        {
            _sw = sw;
            _source = sr;
            _check = ch;
        }

        public void Compile()
        {
            AntlrInputStream stream = new AntlrInputStream(_source);
            ExprLexer lexer = new ExprLexer(stream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            ExprParser parser = new ExprParser(tokenStream);

            ExpressionCompiler listener;
            if (RNSNumber.ModulesAreSet)
            {
                listener = new ExpressionCompiler(_sw, RNSNumber.Modules, _check);
            }
            else
            {
                listener = new ExpressionCompiler(_sw, RNSModuleSets.GetModuleSet(RNSModuleSets.ModuleSets.Default), _check);
            }

            IParseTree r = parser.r();
            ParseTreeWalker walker = new ParseTreeWalker();
            walker.Walk(listener, parser.r());
        }
    }
}