namespace InlineBenchmark;

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
        BenchmarkRunner.Run<MethodInlineBenchmark>();
        BenchmarkRunner.Run<LocalsInitBenchmark>();
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
public class MethodInlineBenchmark
{
    private int a = 17;

    private int b = 19;

    [Benchmark]
    public int MinInline() => InlineFunctions.MinInline(a, b);

    [Benchmark]
    public int MinNoinline() => InlineFunctions.MinNoinline(a, b);
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class LocalsInitBenchmark
{
    public static IEnumerable<int> Size() => new[] { 4, 16, 64, 256, 1024, 2048 };

    [Benchmark]
    [ArgumentsSource(nameof(Size))]
    public string InitCharSpan(int size) => Allocator.InitCharSpan(size);

    [Benchmark]
    [ArgumentsSource(nameof(Size))]
    public string SkipInitCharSpan(int size) => Allocator.SkipInitCharSpan(size);

    [Benchmark]
    public int InitInt() => Allocator.InitInt();

    [Benchmark]
    public int SkipInitInt() => Allocator.SkipInitInt();
}
#pragma warning restore CA1822

public static class InlineFunctions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int MinInline(int x, int y) => x > y ? y : x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int MinNoinline(int x, int y) => x > y ? y : x;
}

public static unsafe class Allocator
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string InitCharSpan(int length)
    {
        var buffer = stackalloc char[length];
        return new string(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [SkipLocalsInit]
    public static string SkipInitCharSpan(int length)
    {
        var buffer = stackalloc char[length];
        return new string(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int InitInt()
    {
        Out(out var value);
        return value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [SkipLocalsInit]
    public static int SkipInitInt()
    {
        Out(out var value);
        return value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Out(out int value)
    {
        value = 0;
    }
}
