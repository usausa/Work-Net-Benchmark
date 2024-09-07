#pragma warning disable SA1312
namespace DictionaryMarshalBenchmark;

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
        AddJob(Job.MediumRun);
    }
}

[CategoriesColumn]
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    [Params(1, 1000)]
    public int Loop { get; set; }

    private readonly Dictionary<string, int> map = new();

    [IterationSetup]
    public void Setup()
    {
        map.Clear();
        map["key0"] = 0;
    }

    [BenchmarkCategory("Add")]
    [Benchmark]
    public void AddDefault()
    {
        var loop = Loop;
        for (var i = 0; i < loop; i++)
        {
            map.TryAdd("key1", 1);
        }
    }

    [BenchmarkCategory("Add")]
    [Benchmark]
    public void AddByReference()
    {
        var loop = Loop;
        for (var i = 0; i < loop; i++)
        {
            ref var valueRef = ref CollectionsMarshal.GetValueRefOrAddDefault(map, "key1", out var exists);
            if (!exists)
            {
                valueRef = 1;
            }
        }
    }

    [BenchmarkCategory("Update")]
    [Benchmark]
    public void UpdateDefault()
    {
        var loop = Loop;
        for (var i = 0; i < loop; i++)
        {
            map["key0"] += 1;
        }
    }

    [BenchmarkCategory("Update")]
    [Benchmark]
    public void UpdateByReference()
    {
        var loop = Loop;
        for (var i = 0; i < loop; i++)
        {
            ref var valueRef = ref CollectionsMarshal.GetValueRefOrNullRef(map, "key0");
            valueRef++;
        }
    }

    [BenchmarkCategory("Update")]
    [Benchmark]
    public void UpdateByReferenceWithCheck()
    {
        var loop = Loop;
        for (var i = 0; i < loop; i++)
        {
            ref var valueRef = ref CollectionsMarshal.GetValueRefOrNullRef(map, "key0");
            if (!Unsafe.IsNullRef(in valueRef))
            {
                valueRef++;
            }
        }
    }
}
