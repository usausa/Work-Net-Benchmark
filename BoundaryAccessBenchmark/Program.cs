namespace BoundaryAccessBenchmark;

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

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private int[] array = default!;

    [Params(1, 4, 8, 64, 1024)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        array = new int[Size];
    }

    [Benchmark]
    public void Calc() => Service.Calc(array);

    [Benchmark]
    public void CalcByLength() => Service.CalcByLength(array, array.Length);

    [Benchmark]
    public void CalcByLengthReverse() => Service.CalcByLengthReverse(array, array.Length);

    [Benchmark]
    public void CalcByLengthWithAccess() => Service.CalcByLengthWithAccess(array, array.Length);

    [Benchmark]
    public void CalcByLengthWithAccess2() => Service.CalcByLengthWithAccess2(array, array.Length);
}
#pragma warning restore CA1822

public static class Service
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Calc(int[] array)
    {
        var result = 0;
        for (var i = 0; i < array.Length; i++)
        {
            result += array[i];
        }
        return result;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CalcByLength(int[] array, int length)
    {
        var result = 0;
        for (var i = 0; i < length; i++)
        {
            result += array[i];
        }
        return result;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CalcByLengthReverse(int[] array, int length)
    {
        var result = 0;
        for (var i = length - 1; i >= 0; i--)
        {
            result += array[i];
        }
        return result;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CalcByLengthWithAccess(int[] array, int length)
    {
        if (array.Length > length)
        {
            throw new ArgumentOutOfRangeException();
        }

        var result = 0;
        for (var i = 0; i < length; i++)
        {
            result += array[i];
        }
        return result;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CalcByLengthWithAccess2(int[] array, int length)
    {
        _ = array[length - 1];
        var result = 0;
        for (var i = 0; i < length; i++)
        {
            result += array[i];
        }
        return result;
    }
}
