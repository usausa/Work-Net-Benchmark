namespace BinarySearchBenchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

// TODO 6/7

public static class Program
{
    public static void Main()
    {
        _ = BenchmarkRunner.Run<Benchmark>();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        _ = AddExporter(MarkdownExporter.GitHub);
        _ = AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        _ = AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
        _ = AddJob(Job.MediumRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core60));
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    [Params(10, 100, 1000, 10000)]
    public int Size { get; set; }

    private int[] array = default!;

    [GlobalSetup]
    public void Setup()
    {
        array = Enumerable.Range(0, Size).ToArray();
    }

    [Benchmark]
    public int ByArray() => Array.BinarySearch(array, 1);

    [Benchmark]
    public int BySpan() => array.AsSpan().BinarySearch(1);
}