﻿using System.Collections.Generic;
using StateSmith.Compiling;
using FluentAssertions;
using System;

namespace StateSmithTest
{
    public static class VertexTestExtensionMethods
    {
        [Obsolete($"See {nameof(VertexTestHelper.BuildFluentAssertionBehaviorMatcher)}")]
        public static void ShouldBeExactly(this Behavior behavior, string diagramId = null, Vertex owningVertex = null, Vertex transitionTarget = null,
                    string actionCode = "", string guardCode = "", List<string> triggers = null, double order = Behavior.DEFAULT_ORDER)
        {
            VertexTestHelper.ExpectBehaviorExact(behavior, diagramId: diagramId, owningVertex: owningVertex, transitionTarget: transitionTarget,
                actionCode: actionCode, guardCode: guardCode, triggers: triggers, order: order);
        }

        public static void ShouldHaveNoIncomingTransitions(this Vertex vertex)
        {
            vertex.IncomingTransitions.Should().BeEmpty();
        }
    }
}
