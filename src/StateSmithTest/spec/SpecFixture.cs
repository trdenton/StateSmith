﻿using StateSmith.Input.Expansions;
using StateSmith.output.UserConfig;
using StateSmith.Runner;
using System;

/*
 * This file is intended to provide language agnostic helpers and expansions for all specification tests
 */

namespace Spec;

public class SpecFixture
{
    public static string SpecInputDirectoryPath = AppDomain.CurrentDomain.BaseDirectory + "../../../spec/";

    public static void CompileAndRun(IRenderConfigC renderConfigC, string diagramFile, string srcDirectory, bool useTracingModder = true)
    {
        RunnerSettings settings = new(renderConfigC, diagramFile: diagramFile, outputDirectory: srcDirectory);
        SmRunner runner = new(settings);
        settings.propagateExceptions = true;
        if (useTracingModder)
        {
            runner.compilerRunner.postParentAliasValidation = new TracingModder().AddTracingBehaviors;
        }
        runner.Run();
    }
}

public class SpecGenericVarExpansions : UserExpansionScriptBase
{
    #pragma warning disable IDE1006 // Naming Styles
    public string clear_output() => "trace(\"IGNORE_OUTPUT_BEFORE_THIS\");";
    public string clear_dispatch_output() => "trace(\"CLEAR_OUTPUT_BEFORE_THIS_AND_FOR_THIS_EVENT_DISPATCH\");";
    #pragma warning restore IDE1006 // Naming Styles
}

