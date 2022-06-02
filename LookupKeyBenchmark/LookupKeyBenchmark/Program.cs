namespace LookupKeyBenchmark;

using BenchmarkDotNet.Attributes;
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
        AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        AddDiagnoser(MemoryDiagnoser.Default);
        AddJob(Job.MediumRun);
    }
}

public readonly record struct RecordKey(Type Type1, Type Type2);

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private readonly Dictionary<(Type, Type), object> tupleDictionary = new();
    private readonly Dictionary<RecordKey, object> recordDictionary = new();

    [GlobalSetup]
    public void Setup()
    {
        foreach (var key in Classes.Types)
        {
            tupleDictionary[(key, key)] = key;
            recordDictionary[new RecordKey(key, key)] = key;
        }
    }

    [Benchmark]
    public void TupleKey()
    {
        foreach (var key in Classes.Types)
        {
            tupleDictionary.TryGetValue((key, key), out _);
        }
    }

    [Benchmark]
    public void RecordKey()
    {
        foreach (var key in Classes.Types)
        {
            recordDictionary.TryGetValue(new RecordKey(key, key), out _);
        }
    }

}