﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using StateSmith.Compiling;
using Xunit;

namespace StateSmithTest
{
    public class VertexTests
    {
        [Fact]
        public void Describe_Statemachine()
        {
            var v = new Statemachine("Sm1");
            Vertex.Describe(v).Should().Be("ROOT");
        }

        [Fact]
        public void Describe_State()
        {
            var v = new State("S1");
            Vertex.Describe(v).Should().Be("S1");
        }

        [Fact]
        public void Describe_InitialState()
        {
            var s1 = new State("S1");
            var i = new InitialState();
            s1.AddChild(i);
            Vertex.Describe(i).Should().Be("S1.InitialState");
        }

        [Fact]
        public void Describe_InitialStateNullParent()
        {
            var i = new InitialState();
            Vertex.Describe(i).Should().Be("<null>.InitialState");
        }

        [Fact]
        public void Describe_EntryPoint()
        {
            var s1 = new State("S1");
            var v = new EntryPoint("entry1");
            s1.AddChild(v);
            Vertex.Describe(v).Should().Be("S1.EntryPoint(entry1)");
        }

        [Fact]
        public void Describe_EntryPointNullParent()
        {
            var v = new EntryPoint("entry1");
            Vertex.Describe(v).Should().Be("<null>.EntryPoint(entry1)");
        }

        [Fact]
        public void Describe_ExitPoint()
        {
            var s1 = new State("S1");
            var v = new ExitPoint("exit1");
            s1.AddChild(v);
            Vertex.Describe(v).Should().Be("S1.ExitPoint(exit1)");
        }

        [Fact]
        public void Describe_ExitPointNullParent()
        {
            var v = new ExitPoint("exit1");
            Vertex.Describe(v).Should().Be("<null>.ExitPoint(exit1)");
        }
    }
}
