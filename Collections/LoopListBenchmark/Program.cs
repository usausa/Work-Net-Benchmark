#pragma warning disable SA1312
namespace LoopListBenchmark;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
    [Params(100, 1_000, 1_0000, 10_0000)]
    public int Size { get; set; }

    private List<int> items = new();

    [GlobalSetup]
    public void InitList()
    {
        items = Enumerable.Range(1, Size).ToList();
    }

    [Benchmark]
    public int For()
    {
        var result = 0;

        for (var i = 0; i < items.Count; i++)
        {
            result = items[i];
        }

        return result;
    }

    [Benchmark]
    public int While()
    {
        var result = 0;

        var i = 0;
        while (i < items.Count)
        {
            result = items[i];
            i++;
        }

        return result;
    }

    [Benchmark]
    public int ForEach()
    {
        var result = 0;

        foreach (var x in items)
        {
            result = x;
        }

        return result;
    }

    [Benchmark]
    public int ForSpan()
    {
        var result = 0;

        var asSpanList = CollectionsMarshal.AsSpan(items);
        for (var i = 0; i < asSpanList.Length; i++)
        {
            result = asSpanList[i];
        }

        return result;
    }

    [Benchmark]
    public int ForSpan2()
    {
        var result = 0;

        var asSpanList = CollectionsMarshal.AsSpan(items);
        var length = asSpanList.Length;
        for (var i = 0; i < length; i++)
        {
            result = asSpanList[i];
        }

        return result;
    }

    [Benchmark]
    public int ForeachSpan()
    {
        var result = 0;

        foreach (var x in CollectionsMarshal.AsSpan(items))
        {
            result = x;
        }

        return result;
    }

    [Benchmark]
    public int RefLoopSpan()
    {
        var result = 0;

        var asSpanList = CollectionsMarshal.AsSpan(items);
        ref var start = ref MemoryMarshal.GetReference(asSpanList);
        ref var end = ref Unsafe.Add(ref start, asSpanList.Length);
        while (Unsafe.IsAddressLessThan(ref start, ref end))
        {
            result = start;
            start = ref Unsafe.Add(ref start, 1);
        }

        return result;
    }
}
