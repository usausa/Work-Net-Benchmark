#pragma warning disable SA1312
namespace BoxingBenchmark;

using System.Runtime.CompilerServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
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
    [Params(1, 4, 8, 16, 64, 256, 1024)]
    public int Size { get; set; }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public int For()
    {
        var size = Size;
        var sum = 0;
        for (var i = 0; i < size; i++)
        {
            sum += i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public int For2()
    {
        var size = Size;
        var sum = 0;
        for (var i = size; i != 0; i--)
        {
            sum += i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public int While()
    {
        var size = Size;
        var sum = 0;
        var i = size;
        while (i-- > 0)
        {
            sum += i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public int While2()
    {
        var size = Size;
        var sum = 0;
        var i = size;
        while (i-- != 0)
        {
            sum += i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [Benchmark]
    public int Do()
    {
        var size = Size;
        var sum = 0;
        var i = size;

        do
        {
            sum += i;
        }
        while (i-- != 0);
        return sum;
    }
}
