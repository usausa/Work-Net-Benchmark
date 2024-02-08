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

    //private readonly Action lambdaAction = () => { };

    //private readonly Action staticAction = StaticAction.Execute;

    //private readonly Action curryAction = default(object)!.Execute;

    private readonly IAction interfaceAction = new InterfaceActionImplement();

    private readonly AbstractAction abstractAction = new AbstractActionImplement();

    [Benchmark]
    public void Lambda() => ActionExecutor.Execute(N, LambdaAction.Action);

    [Benchmark]
    public void Static() => ActionExecutor.Execute(N, StaticAction.Action);

    [Benchmark]
    public void Curry() => ActionExecutor.Execute(N, CurryAction.Action);

    [Benchmark]
    public void Interface() => InterfaceExecutor.Execute(N, interfaceAction);

    [Benchmark]
    public void Abstract() => AbstractExecutor.Execute(N, abstractAction);
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
}

//public static class StaticAction
//{
//    public static void Execute()
//    {
//    }
//}

//public static class CurriedAction
//{
//#pragma warning disable IDE0060
//    public static void Execute(this object dummy)
//    {
//    }
//#pragma warning restore IDE0060
//}

public static class LambdaAction
{
    public static Action Action { get; } = () => { };
}

public static class StaticAction
{
    public static Action Action { get; } = Execute;

    private static void Execute()
    {
    }
}

public static class CurryAction
{
    public static Action Action { get; } = default(object)!.Execute;

    private static void Execute(this object dummy)
    {
    }
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
