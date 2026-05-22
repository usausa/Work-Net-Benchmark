namespace NumericBenchmark;

using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
        BenchmarkRunner.Run<DecimalBitsBenchmark>();
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
    private const uint UIntValue9 = 1000000000;

    private const ulong ULongValue9 = 1000000000;

    private const ulong ULongValue19 = 10000000000000000000;

    private static readonly BigInteger BigIntegerValue9 = 1000000000;

    private static readonly BigInteger BigIntegerValue19 = 10000000000000000000;

    [Benchmark]
    public uint IntMul9()
    {
        var value = 1U;
        for (var i = 0; i < 9; i++)
        {
            value *= 10;
        }

        return value;
    }

    [Benchmark]
    public ulong LongMul9()
    {
        var value = 1UL;
        for (var i = 0; i < 9; i++)
        {
            value *= 10;
        }

        return value;
    }

    [Benchmark]
    public BigInteger BigIntegerMul9()
    {
        var value = BigInteger.One;
        for (var i = 0; i < 9; i++)
        {
            value *= 10;
        }

        return value;
    }

    [Benchmark]
    public uint IntDiv9()
    {
        var value = UIntValue9;
        for (var i = 0; i < 9; i++)
        {
            value /= 10;
        }

        return value;
    }

    [Benchmark]
    public ulong LongDiv9()
    {
        var value = ULongValue9;
        for (var i = 0; i < 9; i++)
        {
            value /= 10;
        }

        return value;
    }

    [Benchmark]
    public BigInteger BigIntegerDiv9()
    {
        var value = BigIntegerValue9;
        for (var i = 0; i < 9; i++)
        {
            value /= 10;
        }

        return value;
    }

    [Benchmark]
    public ulong LongMul19()
    {
        var value = 1UL;
        for (var i = 0; i < 19; i++)
        {
            value *= 10;
        }

        return value;
    }

    [Benchmark]
    public BigInteger BigIntegerMul19()
    {
        var value = BigInteger.One;
        for (var i = 0; i < 19; i++)
        {
            value *= 10;
        }

        return value;
    }

    [Benchmark]
    public ulong LongDiv19()
    {
        var value = ULongValue19;
        for (var i = 0; i < 19; i++)
        {
            value /= 10;
        }

        return value;
    }

    [Benchmark]
    public BigInteger BigIntegerDiv19()
    {
        var value = BigIntegerValue19;
        for (var i = 0; i < 19; i++)
        {
            value /= 10;
        }

        return value;
    }
}
#pragma warning restore CA1822

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class DecimalBitsBenchmark
{
    private const int N = 1000;

    private readonly int[] buffer = new int[4];

    private decimal value = -123.456m;

    [Benchmark(OperationsPerInvoke = N, Baseline = true)]
    public int[] GetBitsDefault()
    {
        for (var i = 0; i < N; i++)
        {
            var temp = Decimal.GetBits(value);
            Buffer.BlockCopy(temp, 0, buffer, 0, 16);
        }

        return buffer;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int[] GetBitsUnsafe()
    {
        for (var i = 0; i < N; i++)
        {
            var data = Unsafe.As<RawDecimalData>(value);
            buffer[0] = data.Lo;
            buffer[1] = data.Mid;
            buffer[2] = data.Hi;
            buffer[3] = data.Flags;
        }

        return buffer;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int[] GetBitsUnsafeWithoutCopy()
    {
        for (var i = 0; i < N; i++)
        {
            Unsafe.As<RawDecimalData>(value);
        }

        return buffer;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int[] GetBitsUnsafeCopy()
    {
        for (var i = 0; i < N; i++)
        {
            CopyBits(value, buffer);
        }

        return buffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe void CopyBits(decimal val, int[] buf)
    {
        Unsafe.CopyBlockUnaligned(Unsafe.AsPointer(ref val), Unsafe.AsPointer(ref buf[0]), 16);
    }
}

#pragma warning disable SA1401
[StructLayout(LayoutKind.Sequential)]
public sealed class RawDecimalData
{
    public int Flags;
    public int Hi;
    public int Lo;
    public int Mid;
}
#pragma warning restore SA1401
