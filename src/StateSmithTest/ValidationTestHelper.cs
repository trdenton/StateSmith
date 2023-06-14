using System;
using FluentAssertions;
using StateSmith.SmGraph;
using StateSmith.Runner;
using StateSmith.SmGraph.Validation;

#nullable enable

namespace StateSmithTest
{
    public class ValidationTestHelper
    {
        public DiagramToSmConverter diagramToSmConverter;
        public InputSmBuilder inputSmBuilder;

        public ValidationTestHelper()
        {
            inputSmBuilder = new InputSmBuilder();
            diagramToSmConverter = inputSmBuilder.diagramToSmConverter;
            inputSmBuilder.sp.GetInstanceOf<RunnerSettings>().nameConflictResolution = RunnerSettings.NameConflictResolution.Manual; // required for old duplicate state name detection
        }

        public void ExpectBehaviorValidationException(string exceptionMessagePart, Action? additionalAction = null)
        {
            Action action = () =>
            {
                RunCompiler();
                additionalAction?.Invoke();
            };
            action.Should().Throw<BehaviorValidationException>()
                .Where(e => e.Message.Contains(exceptionMessagePart));
        }

        public void ExpectVertexValidationException(string exceptionMessagePart, Action? additionalAction = null)
        {
            Action action = () =>
            {
                RunCompiler();
                additionalAction?.Invoke();
            };
            action.Should().Throw<VertexValidationException>()
                .Where(e => e.Message.Contains(exceptionMessagePart));
        }

        public void ExpectVertexValidationExceptionWildcard(string wildcardMessage)
        {
            Action action = () => RunCompiler();
            action.Should().Throw<VertexValidationException>()
                .WithMessage(wildcardMessage);
        }

        public void ExpectVertexValidationExceptionWildcard(Vertex vertex, string wildcardMessage)
        {
            Action action = () => RunCompiler();
            action.Should().Throw<VertexValidationException>()
                .WithMessage(wildcardMessage)
                .Where(e => e.vertex == vertex)
                ;
        }

        public void RunCompiler()
        {
            inputSmBuilder.FinishRunning();
        }
    }
}
