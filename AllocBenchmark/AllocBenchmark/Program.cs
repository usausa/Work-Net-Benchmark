using System.Runtime.InteropServices;

namespace AllocBenchmark;

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
public unsafe class Benchmark
{
    private const int N = 1000;
    private const int Size = 1024 * 10_0000;

    [Benchmark(OperationsPerInvoke = N)]
    public void AllocManaged()
    {
        for (var i = 0; i < N; i++)
        {
            _ = new byte[Size];
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void AllocUnmanaged()
    {
        for (var i = 0; i < N; i++)
        {
            var ptr = Marshal.AllocHGlobal(Size);

            _ = new Span<byte>(ptr.ToPointer(), Size);

            Marshal.FreeHGlobal(ptr);
        }
    }

    [Benchmark]
    public void AllocManagedCount()
    {
        var buffer = new byte[Size];
        Sum(buffer);
    }

    [Benchmark]
    public void AllocUnmanagedCount()
    {
        var ptr = Marshal.AllocHGlobal(Size);

        var span = new Span<byte>(ptr.ToPointer(), Size);
        Sum(span);

        Marshal.FreeHGlobal(ptr);
    }

    private static int Sum(Span<byte> span)
    {
        var total = 0;
        foreach (var value in span)
        {
            total += value;
        }
        return total;
    }
}
