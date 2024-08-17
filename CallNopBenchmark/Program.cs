namespace CallNopBenchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddExporter(MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
    }
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net60)]
[MediumRunJob(RuntimeMoniker.Net80)]
public class Benchmark
{
    private const int N = 100_0000;

    private readonly Action lambdaAction = () => { };

    private readonly Action staticAction = StaticAction.Execute;

    private readonly Action curryAction = default(object)!.Execute;

    private readonly IAction interfaceAction = new InterfaceActionImplement();

    private readonly AbstractAction abstractAction = new AbstractActionImplement();

    private readonly Func<object?, object?> lambdaFunction = x => x;

    private readonly Func<object?, object?> staticFunction = StaticFunction.Execute;

    private readonly Func<object?, object?> curryFunction = default(object)!.Execute;

    private readonly IFunction interfaceFunction = new InterfaceFunctionImplement();

    private readonly AbstractFunction abstractFunction = new AbstractFunctionImplement();

    [BenchmarkCategory("Action")]
    [Benchmark]
    public void ActionLambda() => ActionExecutor.Execute(N, lambdaAction);

    [BenchmarkCategory("Action")]
    [Benchmark]
    public void ActionStatic() => ActionExecutor.Execute(N, staticAction);

    [BenchmarkCategory("Action")]
    [Benchmark]
    public void ActionCurry() => ActionExecutor.Execute(N, curryAction);

    [BenchmarkCategory("Action")]
    [Benchmark]
    public void ActionInterface() => InterfaceExecutor.Execute(N, interfaceAction);

    [BenchmarkCategory("Action")]
    [Benchmark]
    public void ActionAbstract() => AbstractExecutor.Execute(N, abstractAction);

    [BenchmarkCategory("Function")]
    [Benchmark]
    public void FunctionLambda() => ActionExecutor.Execute(N, lambdaFunction);

    [BenchmarkCategory("Function")]
    [Benchmark]
    public void FunctionStatic() => ActionExecutor.Execute(N, staticFunction);

    [BenchmarkCategory("Function")]
    [Benchmark]
    public void FunctionCurry() => ActionExecutor.Execute(N, curryFunction);

    [BenchmarkCategory("Function")]
    [Benchmark]
    public void FunctionInterface() => InterfaceExecutor.Execute(N, interfaceFunction);

    [BenchmarkCategory("Function")]
    [Benchmark]
    public void FunctionAbstract() => AbstractExecutor.Execute(N, abstractFunction);
}

public static class ActionExecutor
{
    public static void Execute(int loop, Action action)
    {
        for (var i = 0; i < loop; i++)
        {
            action();
        }
    }

    public static void Execute(int loop, Func<object?, object?> func)
    {
        for (var i = 0; i < loop; i++)
        {
            func(null);
        }
    }
}

public static class InterfaceExecutor
{
    public static void Execute(int loop, IAction action)
    {
        for (var i = 0; i < loop; i++)
        {
            action.Execute();
        }
    }

    public static void Execute(int loop, IFunction func)
    {
        for (var i = 0; i < loop; i++)
        {
            func.Execute(null);
        }
    }
}

public static class AbstractExecutor
{
    public static void Execute(int loop, AbstractAction action)
    {
        for (var i = 0; i < loop; i++)
        {
            action.Execute();
        }
    }

    public static void Execute(int loop, AbstractFunction func)
    {
        for (var i = 0; i < loop; i++)
        {
            func.Execute(null);
        }
    }
}

public static class LambdaAction
{
    public static Action Action { get; } = () => { };
}

public static class StaticAction
{
    public static void Execute()
    {
    }
}

public static class StaticFunction
{
    public static object? Execute(object? parameter) => parameter;
}

public static class CurryAction
{
    public static Action Action { get; } = default(object)!.Execute;

    public static void Execute(this object dummy)
    {
    }
}

public static class CurryFunction
{
    public static Func<object?, object?> Function { get; } = default(object)!.Execute;

    public static object? Execute(this object dummy, object? parameter) => parameter;
}

public interface IAction
{
    void Execute();
}

public sealed class InterfaceActionImplement : IAction
{
    public void Execute()
    {
    }
}

public interface IFunction
{
    object? Execute(object? parameter);
}

public sealed class InterfaceFunctionImplement : IFunction
{
    public object? Execute(object? parameter) => parameter;
}

public abstract class AbstractAction
{
    public abstract void Execute();
}

public sealed class AbstractActionImplement : AbstractAction
{
    public override void Execute()
    {
    }
}

public abstract class AbstractFunction
{
    public abstract object? Execute(object? parameter);
}

public sealed class AbstractFunctionImplement : AbstractFunction
{
    public override object? Execute(object? parameter) => parameter;
}
