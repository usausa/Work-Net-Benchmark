#pragma warning disable SA1312
namespace FrozenBenchmark;

using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

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

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private KeyValuePair<string, int>[] items = default!;
    private string[] keys = default!;

    private Dictionary<string, int> dictionary = default!;
    private ReadOnlyDictionary<string, int> readOnlyDictionary = default!;
    private ImmutableDictionary<string, int> immutableDictionary = default!;
    private FrozenDictionary<string, int> frozenDictionary = default!;

    [Params(32, 256, 1024)]
    public int Items { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        items = Enumerable
            .Range(0, Items)
            .Select(_ => new KeyValuePair<string, int>(Guid.NewGuid().ToString(), 0))
            .ToArray();

        keys = items.Select(k => k.Key).ToArray();

        dictionary = new Dictionary<string, int>(items);
        readOnlyDictionary = new ReadOnlyDictionary<string, int>(items.ToDictionary(i => i.Key, i => i.Value));
        immutableDictionary = items.ToImmutableDictionary();
        frozenDictionary = items.ToFrozenDictionary();
    }

    [BenchmarkCategory("Construct")]
    [Benchmark]
    public Dictionary<string, int> ConstructDictionary() => new(items);

    [BenchmarkCategory("Construct")]
    [Benchmark]
    public ReadOnlyDictionary<string, int> ConstructReadOnlyDictionary() => new(items.ToDictionary(i => i.Key, i => i.Value));

    [BenchmarkCategory("Construct")]
    [Benchmark]
    public ImmutableDictionary<string, int> ConstructImmutableDictionary() => items.ToImmutableDictionary();

    [BenchmarkCategory("Construct")]
    [Benchmark]
    public FrozenDictionary<string, int> ConstructFrozenDictionary() => items.ToFrozenDictionary();

    [BenchmarkCategory("TryGetValue")]
    [Benchmark]
    public bool DictionaryTryGetValueFound()
    {
        var allFound = true;
        foreach (var key in keys)
        {
            allFound &= dictionary.TryGetValue(key, out _);
        }

        return allFound;
    }

    [BenchmarkCategory("TryGetValue")]
    [Benchmark]
    public bool ReadOnlyDictionaryTryGetValueFound()
    {
        var allFound = true;
        foreach (var key in keys)
        {
            allFound &= readOnlyDictionary.TryGetValue(key, out _);
        }

        return allFound;
    }

    [BenchmarkCategory("TryGetValue")]
    [Benchmark]
    public bool ImmutableDictionaryTryGetValueFound()
    {
        var allFound = true;
        foreach (var key in keys)
        {
            allFound &= immutableDictionary.TryGetValue(key, out _);
        }

        return allFound;
    }

    [BenchmarkCategory("TryGetValue")]
    [Benchmark]
    public bool FrozenDictionaryTryGetValueFound()
    {
        var allFound = true;
        foreach (var key in keys)
        {
            allFound &= frozenDictionary.TryGetValue(key, out _);
        }

        return allFound;
    }
}
