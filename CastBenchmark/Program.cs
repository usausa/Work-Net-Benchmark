namespace CastBenchmark;

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
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
public class Benchmark
{
    private object[] actions = default!;

    [GlobalSetup]
    public void Setup()
    {
        actions = new object[8];
        for (var i = 0; i < actions.Length; i++)
        {
            actions[i] = (Action<object?>)(_ => { });
        }
    }

    [Benchmark]
    public void ByCast()
    {
        foreach (var action in actions)
        {
            ((Action<object?>)action)(null);
        }
    }

    [Benchmark]
    public void ByAs()
    {
        foreach (var action in actions)
        {
            Unsafe.As<Action<object?>>(action)(null);
        }
    }
}
