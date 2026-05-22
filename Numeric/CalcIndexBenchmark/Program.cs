namespace CalcIndexBenchmark;

using System;
using System.Globalization;
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
        BenchmarkRunner.Run<BitShiftBenchmark>();
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

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CA1822
#pragma warning disable CA1307
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int N = 1_000;

    private readonly ArrayHolder holder = new(64);

    public int Key1 { get; set; } = 1;

    public int Key2 { get; set; } = 2;

    public uint UKey1 { get; set; } = 1;

    public uint UKey2 { get; set; } = 2;

    [Benchmark(OperationsPerInvoke = N)]
    public void IntKey()
    {
        var h = holder;
        var k1 = Key1;
        var k2 = Key2;
        for (var i = 0; i < N; i++)
        {
            _ = h.GetItem1(k1, k2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void UIntKey()
    {
        var h = holder;
        var k1 = UKey1;
        var k2 = UKey2;
        for (var i = 0; i < N; i++)
        {
            _ = h.GetItem2(k1, k2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void UIntToIntKey()
    {
        var h = holder;
        var k1 = UKey1;
        var k2 = UKey2;
        for (var i = 0; i < N; i++)
        {
            _ = h.GetItem1((int)k1, (int)k2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IntToUIntKey()
    {
        var h = holder;
        var k1 = Key1;
        var k2 = Key2;
        for (var i = 0; i < N; i++)
        {
            _ = h.GetItem2((uint)k1, (uint)k2);
        }
    }
}

public sealed class ArrayHolder
{
    private readonly int[] array;

    public ArrayHolder(int size)
    {
        array = new int[size];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int CalcIndex1(int key1, int key2)
    {
        unchecked
        {
            return key1 ^ (key2 * 397);
        }
    }

    public ref int GetItem1(int key1, int key2)
    {
        return ref array[CalcIndex1(key1, key2) & (array.Length - 1)];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint CalcIndex2(uint key1, uint key2)
    {
        return key1 ^ (key2 * 397);
    }

    public ref int GetItem2(uint key1, uint key2)
    {
        return ref array[CalcIndex2(key1, key2) & (array.Length - 1)];
    }
}

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class BitShiftBenchmark
{
    private const int N = 1_000;

    [Benchmark(OperationsPerInvoke = N)]
    public int Multiple()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.Multiple(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int MultipleUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.MultipleUnsigned(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int LeftShift()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.LeftShift(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int LeftShiftUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.LeftShiftUnsigned(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int Divide()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.Divide(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int DivideUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.DivideUnsigned(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int RightShift()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.RightShift(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int RightShiftUnsigned()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.RightShiftUnsigned(value);
        }

        return value;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int RightShiftUnsigned2()
    {
        var value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ArithmeticOperator.RightShiftUnsigned2(value);
        }

        return value;
    }
}
#pragma warning restore CA1822

public static class ArithmeticOperator
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
