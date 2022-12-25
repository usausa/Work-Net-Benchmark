namespace LengthCheckBenchmark;

using System.Runtime.CompilerServices;

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
        AddJob(Job.MediumRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core60));
         AddJob(Job.MediumRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core70));
        //AddJob(Job.MediumRun);
        //AddJob(Job.ShortRun);
    }
}

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    private static readonly int[] Array = new int[N];

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArrayWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.ArrayWithoutCast(Array, i);
        }
        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArrayWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.ArrayWithCast(Array, i);
        }
        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArraySpanWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithoutCast(Array, i);
        }
        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArraySpanWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithCast(Array, i);
        }
        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool SpanWithoutCast()
    {
        var span = Array.AsSpan();
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithoutCast(span, i);
        }
        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool SpanWithCast()
    {
        var span = Array.AsSpan();
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithCast(span, i);
        }
        return ret;
    }

    [BenchmarkCategory("Minus")]
    [Benchmark]
    public bool MinusWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.MinusWithoutCast(Array, i);
        }
        return ret;
    }

    [BenchmarkCategory("Minus")]
    [Benchmark]
    public bool MinusWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.MinusWithCast(Array, i);
        }
        return ret;
    }

    [BenchmarkCategory("NotEqualZero")]
    [Benchmark]
    public bool NotEqualZeroWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.NotEqualZeroWithoutCast(Array);
        }
        return ret;
    }

    [BenchmarkCategory("NotEqualZero")]
    [Benchmark]
    public bool NotEqualZeroWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.NotEqualZeroWithCast(Array);
        }
        return ret;
    }

    [BenchmarkCategory("GraterThan")]
    [Benchmark]
    public bool GraterThanZeroWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.GraterThanZeroWithoutCast(Array);
        }
        return ret;
    }

    [BenchmarkCategory("GraterThan")]
    [Benchmark]
    public bool GraterThanZeroWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.GraterThanZeroWithCast(Array);
        }
        return ret;
    }

    [BenchmarkCategory("LessThan")]
    [Benchmark]
    public bool LessThanWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.LessThanWithoutCast(Array);
        }
        return ret;
    }

    [BenchmarkCategory("LessThan")]
    [Benchmark]
    public bool LessThanWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.LessThanWithCast(Array);
        }
        return ret;
    }
}

public static class Checker
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool ArrayWithoutCast(int[] array, int compare) => array.Length < compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool ArrayWithCast(int[] array, int compare) => (uint)array.Length < (uint)compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool SpanWithoutCast(ReadOnlySpan<int> span, int compare) => span.Length < compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool SpanWithCast(ReadOnlySpan<int> span, int compare) => (uint)span.Length < (uint)compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool MinusWithoutCast(int[] array, int compare) => array.Length < compare - 1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool MinusWithCast(int[] array, int compare) => (uint)array.Length < (uint)(compare - 1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool NotEqualZeroWithoutCast(int[] array) => array.Length != 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool NotEqualZeroWithCast(int[] array) => (uint)array.Length != 0u;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool GraterThanZeroWithoutCast(int[] array) => array.Length > 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool GraterThanZeroWithCast(int[] array) => (uint)array.Length > 0u;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool LessThanWithoutCast(int[] array) => array.Length < 256;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool LessThanWithCast(int[] array) => (uint)array.Length < 256u;
}
