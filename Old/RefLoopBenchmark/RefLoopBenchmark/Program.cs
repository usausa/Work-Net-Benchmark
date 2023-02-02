namespace RefLoopBenchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
        AddJob(Job.MediumRun);
    }
}

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    [Params(2, 4, 8, 16, 32, 64, 128, 256)]
    public int Size { get; set; }

    private byte[] byteArray1 = default!;
    private byte[] byteArray2 = default!;
    private char[] charArray1 = default!;
    private char[] charArray2 = default!;
    private int[] intArray1 = default!;
    private int[] intArray2 = default!;
    private long[] longArray1 = default!;
    private long[] longArray2 = default!;

    [GlobalSetup]
    public void Setup()
    {
        byteArray1 = new byte[Size];
        byteArray2 = new byte[Size];
        charArray1 = new char[Size];
        charArray2 = new char[Size];
        intArray1 = new int[Size];
        intArray2 = new int[Size];
        longArray1 = new long[Size];
        longArray2 = new long[Size];
    }

    [BenchmarkCategory("Single", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(byteArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(charArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(intArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(longArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(byteArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(charArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(intArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(longArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(byteArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(charArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(intArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Single", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(longArray1);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(byteArray1, byteArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(charArray1, charArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(intArray1, intArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(longArray1, longArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(byteArray1, byteArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(charArray1, charArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(intArray1, intArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(longArray1, longArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(byteArray1, byteArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(charArray1, charArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(intArray1, intArray2);
        }
        return ret;
    }

    [BenchmarkCategory("Twin", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(longArray1, longArray2);
        }
        return ret;
    }
}

public static class CountOperator
{
    // Index

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<byte> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<char> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<int> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<long> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    // Index twin

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<byte> source1, ReadOnlySpan<byte> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }
            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<char> source1, ReadOnlySpan<char> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }
            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<int> source1, ReadOnlySpan<int> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }
            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<long> source1, ReadOnlySpan<long> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }
            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    // Ref

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<byte> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<char> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<int> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<long> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    // Ref twin

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<byte> source1, ReadOnlySpan<byte> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<char> source1, ReadOnlySpan<char> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<int> source1, ReadOnlySpan<int> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<long> source1, ReadOnlySpan<long> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    // Ref and length

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<byte> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);

            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<char> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);

            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<int> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);

            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<long> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }
            sr = ref Unsafe.Add(ref sr, 1);

            length--;
        }

        return count;
    }

    // Ref and length twin

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<byte> source1, ReadOnlySpan<byte> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<char> source1, ReadOnlySpan<char> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<int> source1, ReadOnlySpan<int> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<long> source1, ReadOnlySpan<long> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }
            if (sr2 != 0)
            {
                count++;
            }
            sr2 = ref Unsafe.Add(ref sr1, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }
}
