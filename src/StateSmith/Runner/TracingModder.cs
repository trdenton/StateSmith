﻿using StateSmith.Common;
using StateSmith.compiler.Visitors;
using StateSmith.Compiling;
using StateSmith.output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateSmith.Runner
{
    public class TracingModder : NamedVisitor
    {
        public void AddTracingBehaviors(Statemachine statemachine)
        {
            Visit(statemachine);
        }

        public override void Visit(Vertex v)
        {
            var transitions = v.Behaviors.Where(b => b.HasTransition());

            foreach (var t in transitions)
            {
                var tracingCode = $"trace(\"Transition action `{StringUtils.EscapeCharsForString(t.actionCode)}` for {Vertex.Describe(v)} to {Vertex.Describe(t.TransitionTarget)}.\");";

                if (t.HasActionCode())
                {
                    t.actionCode = tracingCode + "\n" + t.actionCode;
                }
                else
                {
                    t.actionCode = tracingCode;
                }
            }

            VisitChildren(v);
        }

        public override void Visit(NamedVertex v)
        {
            foreach (var b in v.Behaviors)
            {
                var uml = b.DescribeAsUml();
                var originalGuard = b.guardCode ?? "";

                if (originalGuard.Length == 0)
                {
                    originalGuard = "true";
                }

                string escapedUml = StringUtils.EscapeCharsForString(uml);
                var newGuard = $"trace_guard(\"State {v.Name}: check behavior `{escapedUml}`.\", {originalGuard})";
                b.guardCode = newGuard;
            }

            Visit((Vertex)v);
            v.AddBehavior(index: 0, behavior: new Behavior(trigger: TriggerHelper.TRIGGER_ENTER, guardCode: null, actionCode: $"trace(\"Enter {v.Name}.\");"));
            v.AddBehavior(index: 0, behavior: new Behavior(trigger: TriggerHelper.TRIGGER_EXIT, guardCode: null, actionCode: $"trace(\"Exit {v.Name}.\");"));
        }

        public override void Visit(NotesVertex v)
        {
            // ignore
        }

        public override void Visit(InitialState v)
        {
            Visit((Vertex)v);
        }
    }
}
