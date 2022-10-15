namespace CallbackBenchmark;

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

    [GlobalSetup]
    public void Setup()
    {
        list = Enumerable.Range(1, 1024).ToList();
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort1()
    {
        list.Sort(Comparer.Instance);
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort2()
    {
        list.Sort(Comparer.StaticCompare);
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort3()
    {
        list.Sort(Comparer.Comparison);
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort4()
    {
        list.Sort(static (x, y) => Comparer.StaticCompare(x, y));
    }
}

public sealed class Comparer : IComparer<int>
{
    public static Comparer Instance = new();

    public static Comparison<int> Comparison = Instance.Compare;

    public int Compare(int x, int y) => x.CompareTo(y);

    public static int StaticCompare(int x, int y) => x.CompareTo(y);
}