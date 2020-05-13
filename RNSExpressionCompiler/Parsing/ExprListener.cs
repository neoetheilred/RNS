//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Expr.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="ExprParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IExprListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="ExprParser.r"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterR([NotNull] ExprParser.RContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ExprParser.r"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitR([NotNull] ExprParser.RContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>parentheses</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParentheses([NotNull] ExprParser.ParenthesesContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parentheses</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParentheses([NotNull] ExprParser.ParenthesesContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>rnsNum</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRnsNum([NotNull] ExprParser.RnsNumContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>rnsNum</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRnsNum([NotNull] ExprParser.RnsNumContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>unaryMinus</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryMinus([NotNull] ExprParser.UnaryMinusContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>unaryMinus</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryMinus([NotNull] ExprParser.UnaryMinusContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>atomNum</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtomNum([NotNull] ExprParser.AtomNumContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>atomNum</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtomNum([NotNull] ExprParser.AtomNumContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>multiplication</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplication([NotNull] ExprParser.MultiplicationContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multiplication</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplication([NotNull] ExprParser.MultiplicationContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>addition</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddition([NotNull] ExprParser.AdditionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addition</c>
	/// labeled alternative in <see cref="ExprParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddition([NotNull] ExprParser.AdditionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ExprParser.modList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterModList([NotNull] ExprParser.ModListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ExprParser.modList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitModList([NotNull] ExprParser.ModListContext context);
}