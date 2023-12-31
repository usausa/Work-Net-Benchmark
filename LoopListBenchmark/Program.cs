#pragma warning disable SA1312
namespace LoopListBenchmark;

using System.Runtime.InteropServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
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
    }
}

[Config(typeof(BenchmarkConfig))]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net80)]
public class Benchmark
{
    [Params(100, 1_0000, 10_0000, 100_0000)]
    public int Size { get; set; }

    private List<int> items = new();

    [GlobalSetup]
    public void InitList()
    {
        items = Enumerable.Range(1, Size).ToList();
    }

    [Benchmark]
    public void For()
    {
        for (var i = 0; i < items.Count; i++)
        {
            _ = items[i];
        }
    }

    [Benchmark]
    public void While()
    {
        var i = 0;
        while (i < items.Count)
        {
            _ = items[i];
            i++;
        }
    }

    [Benchmark]
    public void ForEach()
    {
        foreach (var _ in items)
        {
        }
    }

    [Benchmark]
    public void ForEachLinq()
    {
        items.ForEach(_ => { });
    }

    [Benchmark]
    public void ParallelForEach()
    {
        Parallel.ForEach(items, _ => { });
    }

    [Benchmark]
    public void ParallelForAll()
    {
        items.AsParallel().ForAll(_ => { });
    }

    [Benchmark]
    public void ForSpan()
    {
        var asSpanList = CollectionsMarshal.AsSpan(items);

        for (var i = 0; i < asSpanList.Length; i++)
        {
            _ = asSpanList[i];
        }
    }

    [Benchmark]
    public void ForeachSpan()
    {
        foreach (var _ in CollectionsMarshal.AsSpan(items))
        {
        }
    }
}
