﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using StateSmith.Input.Expansions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateSmith.Input.antlr4
{
    public class LabelParser
    {
        public ErrorListener errorListener = new ErrorListener();

        public Node ParseNodeLabel(string stateLabel)
        {
            StateSmithLabelGrammarParser parser = BuildParserForString(stateLabel);

            IParseTree tree = parser.node();
            NodeEdgeWalker walker = WalkTree(tree);
            walker.node.tree = tree;

            if (walker.node is StateNode stateNode)
            {
                stateNode.behaviors = walker.behaviors;
            }

            return walker.node;
        }

        public bool HasError()
        {
            return errorListener.errors.Count > 0;
        }

        public List<Error> GetErrors()
        {
            return errorListener.errors;
        }

        public List<NodeBehavior> ParseEdgeLabel(string edgeLabel)
        {
            StateSmithLabelGrammarParser parser = BuildParserForString(edgeLabel);

            IParseTree tree = parser.edge();
            NodeEdgeWalker walker = WalkTree(tree);
            return walker.behaviors;
        }

        public string ParseAndVisitAnyCode(StateSmithLabelGrammarBaseVisitor<string> visitor, string code)
        {
            StateSmithLabelGrammarParser parser = BuildParserForString(code);
            IParseTree tree = parser.any_code();
            return visitor.Visit(tree);
        }

        private NodeEdgeWalker WalkTree(IParseTree tree)
        {
            NodeEdgeWalker walker = new NodeEdgeWalker();
            ParseTreeWalker.Default.Walk(walker, tree);
            return walker;
        }

        private StateSmithLabelGrammarParser BuildParserForString(string inputString)
        {
            ICharStream stream = CharStreams.fromString(inputString);
            var lexer = new StateSmithLabelGrammarLexer(stream);
            lexer.RemoveErrorListeners(); // prevent antlr4 error output to console
            lexer.AddErrorListener(errorListener);

            ITokenStream tokens = new CommonTokenStream(lexer);
            StateSmithLabelGrammarParser parser = new StateSmithLabelGrammarParser(tokens)
            {
                BuildParseTree = true
            };
            parser.RemoveErrorListeners(); // prevent antlr4 error output to console
            parser.AddErrorListener(errorListener);

            return parser;
        }
    }
}
