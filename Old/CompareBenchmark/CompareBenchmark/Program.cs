using System.Runtime.CompilerServices;

namespace CompareBenchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

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
        _ = AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
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
    private const int N = 1000;

    private readonly Data[] values = Enumerable.Range(0, 64).Select(x => new Data { Id = x }).ToArray();

    [Benchmark(OperationsPerInvoke = N)]
    public void ByComparable()
    {
        for (var i = 0; i < N; i++)
        {
            Array.Sort(values);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ByComparer()
    {
        for (var i = 0; i < N; i++)
        {
            Array.Sort(values, DataComparer.Default);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ByDelegate()
    {
        for (var i = 0; i < N; i++)
        {
            Array.Sort(values, DataFunctions.Compare);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ByDelegate2()
    {
        for (var i = 0; i < N; i++)
        {
            Array.Sort(values, static (x, y) => DataFunctions.Compare(x, y));
        }
    }
}

public sealed class Data : IComparable<Data>
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public int CompareTo(Data? other) => Id.CompareTo(other!.Id);
}

public sealed class DataComparer : IComparer<Data>
{
    public static DataComparer Default => new();

    public int Compare(Data? x, Data? y) => x!.Id.CompareTo(y!.Id);
}

public static class DataFunctions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Compare(Data? x, Data? y) => x!.Id.CompareTo(y!.Id);
}
