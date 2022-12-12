namespace BitShiftBenchmark;

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
        _ = BenchmarkRunner.Run<Benchmark>();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        _ = AddExporter(MarkdownExporter.GitHub);
        _ = AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        _ = AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
        _ = AddJob(Job.MediumRun);
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    [Benchmark]
    public int Multiple()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.Multiple(value);
        }

        return value;
    }

    [Benchmark]
    public int MultipleUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.MultipleUnsigned(value);
        }

        return value;
    }

    [Benchmark]
    public int LeftShift()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.LeftShift(value);
        }

        return value;
    }

    [Benchmark]
    public int LeftShiftUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.LeftShiftUnsigned(value);
        }

        return value;
    }

    [Benchmark]
    public int Divide()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.Divide(value);
        }

        return value;
    }

    [Benchmark]
    public int DivideUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.DivideUnsigned(value);
        }

        return value;
    }

    [Benchmark]
    public int RightShift()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.RightShift(value);
        }

        return value;
    }

    [Benchmark]
    public int RightShiftUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.RightShiftUnsigned(value);
        }

        return value;
    }

    [Benchmark]
    public int RightShiftUnsigned2()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = Operator.RightShiftUnsigned2(value);
        }

        return value;
    }
}

public static class Operator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Multiple(int x) => x * 2;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int MultipleUnsigned(int x) => (int)((uint)x * 2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LeftShift(int x) => x << 1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LeftShiftUnsigned(int x) => (int)((uint)x << 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Divide(int x) => x / 2;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int DivideUnsigned(int x) => (int)((uint)x / 2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int RightShift(int x) => x >> 1;

    // ReSharper disable once UseUnsignedRightShiftOperator
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int RightShiftUnsigned(int x) => (int)((uint)x >> 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int RightShiftUnsigned2(int x) => x >>> 1;
}