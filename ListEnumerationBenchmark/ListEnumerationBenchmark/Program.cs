using System.Runtime.InteropServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ListEnumerationBenchmark;

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
        AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default);
        AddJob(Job.MediumRun);
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    private List<int> list = default!;

    [Params(0, 2, 4, 8, 32, 256, 1024)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        list = new List<int>(Enumerable.Range(0, Size));
    }

    [Benchmark(OperationsPerInvoke = N, Baseline = true)]
    public void Foreach()
    {
        var l = list;
        for (var n = 0; n < N; n++)
        {
            foreach (var _ in l)
            {
            }
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void For()
    {
        var l = list;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < l.Count; i++)
            {
                _ = l[i];
            }
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ForeachSpan()
    {
        var l = list;
        for (var n = 0; n < N; n++)
        {
            foreach (var _ in CollectionsMarshal.AsSpan(l))
            {
            }
        }
    }
}