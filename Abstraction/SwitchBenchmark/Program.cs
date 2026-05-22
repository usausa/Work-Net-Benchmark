namespace SwitchBenchmark;

using System.Runtime.CompilerServices;

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

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private Action<int> instanceAction = default!;

    private Action<int> instanceAction2 = default!;

    private Action<int> staticAction = default!;

    private Action<int> staticAction2 = default!;

    private IAction interfaceAction = default!;

    [Params(1, 2, 3)]
    public int Parameter { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        if (Parameter == 1)
        {
            instanceAction = Action1.Default.Work;
            instanceAction2 = x => Action1.Default.Work(1);
            staticAction = Action1.Default.Work;
            staticAction2 = x => Action1.Default.Work(1);
            interfaceAction = Action1.Default;
        }
        else if (Parameter == 2)
        {
            instanceAction = Action2.Default.Work;
            instanceAction2 = x => Action2.Default.Work(2);
            staticAction = Action2.Default.Work;
            staticAction2 = x => Action2.Default.Work(2);
            interfaceAction = Action2.Default;
        }
        else if (Parameter == 3)
        {
            instanceAction = Action3.Default.Work;
            instanceAction2 = x => Action3.Default.Work(3);
            staticAction = Action3.Default.Work;
            staticAction2 = x => Action3.Default.Work(3);
            interfaceAction = Action3.Default;
        }
    }

    [Benchmark]
    public void IfStatic()
    {
        if (Parameter == 1)
        {
            SharedData.Value = 1;
        }
        else if (Parameter == 2)
        {
            SharedData.Value = 2;
        }
        else if (Parameter == 3)
        {
            SharedData.Value = 3;
        }
    }

    [Benchmark]
    public void InstanceAction()
    {
        instanceAction(Parameter);
    }

    [Benchmark]
    public void InstanceAction2()
    {
        instanceAction2(Parameter);
    }

    [Benchmark]
    public void StaticAction()
    {
        staticAction(Parameter);
    }

    [Benchmark]
    public void StaticAction2()
    {
        staticAction2(Parameter);
    }

    [Benchmark]
    public void InterfaceAction()
    {
        interfaceAction.Work(Parameter);
    }
}

public static class SharedData
{
    public static int Value { get; set; }
}

public interface IAction
{
    void Work(int parameter);
}

public sealed class Action1 : IAction
{
    public static IAction Default { get; } = new Action1();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Work(int parameter)
    {
        SharedData.Value = parameter;
    }
}

public sealed class Action2 : IAction
{
    public static IAction Default { get; } = new Action2();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Work(int parameter)
    {
        SharedData.Value = parameter;
    }
}

public sealed class Action3 : IAction
{
    public static IAction Default { get; } = new Action3();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Work(int parameter)
    {
        SharedData.Value = parameter;
    }
}
