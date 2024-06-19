using StateSmith.Output;
using StateSmith.Output.UserConfig;
using StateSmith.Runner;
using StateSmithTest.Output;
using System.IO;

#nullable enable

namespace StateSmithTest;

public class TestHelper
{
    public static string GetThisDir([System.Runtime.CompilerServices.CallerFilePath] string? callerFilePath = null)
    {
        return Path.GetDirectoryName(callerFilePath) + "/";
    }

    public static SmRunner BuildSmRunnerForPlantUmlString(string plantUmlText)
    {
        SmRunner smRunner = new(diagramPath: "no-actual-file.plantuml");
        smRunner.GetExperimentalAccess().DiServiceProvider.AddSingletonT<ICodeFileWriter>(new DiscardingCodeFileWriter());
        InputSmBuilder inputSmBuilder = smRunner.GetExperimentalAccess().DiServiceProvider.GetInstanceOf<InputSmBuilder>();
        inputSmBuilder.ConvertPlantUmlTextNodesToVertices(plantUmlText);
        inputSmBuilder.FindSingleStateMachine();
        smRunner.Settings.propagateExceptions = true;
        return smRunner;
    }

    public static (SmRunner, CapturingCodeFileWriter) CaptureSmRun(string diagramPath, IRenderConfig? renderConfig = null, TranspilerId transpilerId = TranspilerId.Default, [System.Runtime.CompilerServices.CallerFilePath] string? callerFilePath = null)
    {
        SmRunner runner = new(diagramPath: diagramPath, renderConfig: renderConfig, transpilerId: transpilerId, callingFilePath: callerFilePath);
        runner.GetExperimentalAccess().Settings.propagateExceptions = true;
        var fakeFileSystem = new CapturingCodeFileWriter();
        runner.GetExperimentalAccess().DiServiceProvider.AddSingletonT<ICodeFileWriter>(fakeFileSystem);
        runner.Run();

        return (runner, fakeFileSystem);
    }

    public static CapturingCodeFileWriter CaptureSmRunnerFiles(string diagramPath, IRenderConfig? renderConfig = null, TranspilerId transpilerId = TranspilerId.Default, [System.Runtime.CompilerServices.CallerFilePath] string? callerFilePath = null)
    {
        var (_, fakeFileSystem) = CaptureSmRun(diagramPath, renderConfig, transpilerId, callerFilePath: callerFilePath);
        return fakeFileSystem;
    }

    public static void RunSmRunnerForPlantUmlString(string plantUmlText)
    {
        BuildSmRunnerForPlantUmlString(plantUmlText).Run();
    }
}
