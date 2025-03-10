﻿using StateSmith.output.C99BalancedCoder1;
using Xunit;
using System.Linq;
using StateSmith.Compiling;
using StateSmith.Runner;
using StateSmith.compiler;
using System;
using FluentAssertions;

namespace StateSmithTest.C99BalancedCoder1;

#nullable enable

public class EventHandlerBuilderTest
{
    [Fact]
    public void InfiniteLoopDetection1()
    {
        var plantUmlText = @"
@startuml ExampleSm
state c1 <<choice>>
state c2 <<choice>>
state c3 <<choice>>
[*] --> c1
c1 --> s1 : [a]
c1 --> c2 : else

c2 --> s2 : else
c2 --> c3 : [b]

c3 --> s3 : [c]
c3 --> c1 : else
@enduml
";
        var expectedWildcardPattern = "*loop*ROOT.ChoicePoint(c1) -> ROOT.ChoicePoint(c2) -> ROOT.ChoicePoint(c3) -> ROOT.ChoicePoint(c1)*";
        CompileAndExpectException(plantUmlText: plantUmlText, expectedWildcardPattern);
    }

    [Fact]
    public void InfiniteLoopDetection2()
    {
        var plantUmlText = @"
@startuml ExampleSm
[*] --> group1
state c3 <<choice>>

state group1 {
    state c1 <<choice>>
    state c2 <<choice>>
    [*] --> c1
    c1 --> s1 : [a]
    c1 --> c2 : else

    c2 --> s2 : else
    c2 --> c3 : [b]

    c3 --> s3 : [c]
    c3 --> group1 : else
}
@enduml
";
        var expectedWildcardPattern = "*loop*group1.InitialState -> group1.ChoicePoint(c1) -> group1.ChoicePoint(c2) -> ROOT.ChoicePoint(c3) -> group1.InitialState*";
        CompileAndExpectException(plantUmlText: plantUmlText, expectedWildcardPattern);
    }


    private static void CompileAndExpectException(string plantUmlText, string expectedWildcardPattern)
    {
        CompilerRunner compilerRunner = new();
        compilerRunner.CompilePlantUmlTextNodesToVertices(plantUmlText);

        Action action = () => {
            compilerRunner.FinishRunningCompiler();
        };
        action.Should().Throw<VertexValidationException>().WithMessage(expectedWildcardPattern);
    }
}
