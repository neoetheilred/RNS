//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ASM.g4 by ANTLR 4.7.2

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
/// <see cref="ASMParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IASMListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.asm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAsm([NotNull] ASMParser.AsmContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.asm"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAsm([NotNull] ASMParser.AsmContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.base"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBase([NotNull] ASMParser.BaseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.base"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBase([NotNull] ASMParser.BaseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.commands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommands([NotNull] ASMParser.CommandsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.commands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommands([NotNull] ASMParser.CommandsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabel([NotNull] ASMParser.LabelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabel([NotNull] ASMParser.LabelContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.command"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommand([NotNull] ASMParser.CommandContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.command"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommand([NotNull] ASMParser.CommandContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.arithmetic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArithmetic([NotNull] ASMParser.ArithmeticContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.arithmetic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArithmetic([NotNull] ASMParser.ArithmeticContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.control_flow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterControl_flow([NotNull] ASMParser.Control_flowContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.control_flow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitControl_flow([NotNull] ASMParser.Control_flowContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.tdc"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTdc([NotNull] ASMParser.TdcContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.tdc"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTdc([NotNull] ASMParser.TdcContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ASMParser.num_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNum_list([NotNull] ASMParser.Num_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ASMParser.num_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNum_list([NotNull] ASMParser.Num_listContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>pushNum</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPushNum([NotNull] ASMParser.PushNumContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>pushNum</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPushNum([NotNull] ASMParser.PushNumContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>popReg</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPopReg([NotNull] ASMParser.PopRegContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>popReg</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPopReg([NotNull] ASMParser.PopRegContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>pushR</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPushR([NotNull] ASMParser.PushRContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>pushR</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPushR([NotNull] ASMParser.PushRContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>dup</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDup([NotNull] ASMParser.DupContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>dup</c>
	/// labeled alternative in <see cref="ASMParser.stack"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDup([NotNull] ASMParser.DupContext context);
}
