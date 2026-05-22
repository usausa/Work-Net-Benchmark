#pragma warning disable SA1312
namespace BoxingBenchmark;

using System.Runtime.CompilerServices;

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
        BenchmarkRunner.Run<BoxCacheBenchmark>();
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
    // ReSharper disable once ConvertToConstant.Local
#pragma warning disable IDE0044
    private int value = 691;
#pragma warning restore IDE0044

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public int NoBoxing()
    {
        return value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public object BoxedToHeap()
    {
        // Boxed
        return value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public int BoxedToStack()
    {
        // エスケープ解析による最適化
        object obj = value;
        return (int)obj;
    }
}

// よく使う値 (0, 1, -1) をあらかじめボックス化してキャッシュしておくことで
// ヒープ割り当てを回避できるかを検証する。
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class BoxCacheBenchmark
{
    private const int N = 1000;

    [Params(0, 1, -1)]
    public int Value { get; set; }

    [Benchmark(OperationsPerInvoke = N, Baseline = true)]
    public object BasicBox()
    {
        var result = default(object);
        for (var i = 0; i < N; i++)
        {
            result = BoxCache.BasicBox(Value);
        }

        return result!;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object CachedBox()
    {
        var result = default(object);
        for (var i = 0; i < N; i++)
        {
            result = BoxCache.CachedBox(Value);
        }

        return result!;
    }
}

public static class BoxCache
{
    private static readonly object Int0 = 0;
    private static readonly object Int1 = 1;
    private static readonly object IntMinus1 = -1;

    public static object BasicBox(int value) => value;

    public static object CachedBox(int value)
    {
        if (value == 0)
        {
            return Int0;
        }

        if (value == 1)
        {
            return Int1;
        }

        if (value == -1)
        {
            return IntMinus1;
        }

        return value;
    }
}
