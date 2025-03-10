//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from PlantUML.g4 by ANTLR 4.9.2

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
/// <see cref="PlantUMLParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IPlantUMLListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.line_ending_ows"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine_ending_ows([NotNull] PlantUMLParser.Line_ending_owsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.line_ending_ows"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine_ending_ows([NotNull] PlantUMLParser.Line_ending_owsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.optional_any_space"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptional_any_space([NotNull] PlantUMLParser.Optional_any_spaceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.optional_any_space"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptional_any_space([NotNull] PlantUMLParser.Optional_any_spaceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.ohs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOhs([NotNull] PlantUMLParser.OhsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.ohs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOhs([NotNull] PlantUMLParser.OhsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.start_end_state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart_end_state([NotNull] PlantUMLParser.Start_end_stateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.start_end_state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart_end_state([NotNull] PlantUMLParser.Start_end_stateContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.state_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterState_id([NotNull] PlantUMLParser.State_idContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.state_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitState_id([NotNull] PlantUMLParser.State_idContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.vertex"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVertex([NotNull] PlantUMLParser.VertexContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.vertex"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVertex([NotNull] PlantUMLParser.VertexContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.edge"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEdge([NotNull] PlantUMLParser.EdgeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.edge"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEdge([NotNull] PlantUMLParser.EdgeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.transition_event_guard_code"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTransition_event_guard_code([NotNull] PlantUMLParser.Transition_event_guard_codeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.transition_event_guard_code"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTransition_event_guard_code([NotNull] PlantUMLParser.Transition_event_guard_codeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.transition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTransition([NotNull] PlantUMLParser.TransitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.transition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTransition([NotNull] PlantUMLParser.TransitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.state_child_states"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterState_child_states([NotNull] PlantUMLParser.State_child_statesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.state_child_states"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitState_child_states([NotNull] PlantUMLParser.State_child_statesContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.stereotype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStereotype([NotNull] PlantUMLParser.StereotypeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.stereotype"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStereotype([NotNull] PlantUMLParser.StereotypeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.state_explicit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterState_explicit([NotNull] PlantUMLParser.State_explicitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.state_explicit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitState_explicit([NotNull] PlantUMLParser.State_explicitContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.rest_of_line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRest_of_line([NotNull] PlantUMLParser.Rest_of_lineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.rest_of_line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRest_of_line([NotNull] PlantUMLParser.Rest_of_lineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.state_contents"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterState_contents([NotNull] PlantUMLParser.State_contentsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.state_contents"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitState_contents([NotNull] PlantUMLParser.State_contentsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.ignore"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIgnore([NotNull] PlantUMLParser.IgnoreContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.ignore"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIgnore([NotNull] PlantUMLParser.IgnoreContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.diagram_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDiagram_element([NotNull] PlantUMLParser.Diagram_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.diagram_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDiagram_element([NotNull] PlantUMLParser.Diagram_elementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.note_short"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNote_short([NotNull] PlantUMLParser.Note_shortContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.note_short"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNote_short([NotNull] PlantUMLParser.Note_shortContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.note_multiline_contents_line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNote_multiline_contents_line([NotNull] PlantUMLParser.Note_multiline_contents_lineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.note_multiline_contents_line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNote_multiline_contents_line([NotNull] PlantUMLParser.Note_multiline_contents_lineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.note_multiline"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNote_multiline([NotNull] PlantUMLParser.Note_multilineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.note_multiline"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNote_multiline([NotNull] PlantUMLParser.Note_multilineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.note_floating"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNote_floating([NotNull] PlantUMLParser.Note_floatingContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.note_floating"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNote_floating([NotNull] PlantUMLParser.Note_floatingContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.note"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNote([NotNull] PlantUMLParser.NoteContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.note"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNote([NotNull] PlantUMLParser.NoteContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.startuml"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStartuml([NotNull] PlantUMLParser.StartumlContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.startuml"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStartuml([NotNull] PlantUMLParser.StartumlContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.diagram"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDiagram([NotNull] PlantUMLParser.DiagramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.diagram"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDiagram([NotNull] PlantUMLParser.DiagramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PlantUMLParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] PlantUMLParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PlantUMLParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] PlantUMLParser.IdentifierContext context);
}
