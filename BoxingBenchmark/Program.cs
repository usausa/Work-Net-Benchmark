#pragma warning disable SA1312
namespace BoxingBenchmark;

using System.Buffers;
using System.Buffers.Text;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

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
