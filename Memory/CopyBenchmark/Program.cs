namespace CopyBenchmark;

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
        BenchmarkRunner.Run<ReverseBenchmark>();
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
public class Benchmark
{
    private byte[] source = default!;

    private byte[] destination = default!;

    [Params(4, 32, 64, 128, 1024)]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        source = new byte[Length];
        destination = new byte[Length];
    }

    [Benchmark]
    public void ArrayCopy()
    {
        Array.Copy(source, 0, destination, 0, source.Length);
    }

    [Benchmark]
    public void BlockCopy()
    {
        Buffer.BlockCopy(source, 0, destination, 0, source.Length);
    }

    [Benchmark]
    public void MemoryCopy()
    {
        FastCopy(source, 0, destination, 0, source.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe void FastCopy(byte[] src, int srcOffset, byte[] dst, int dstOffset, int length)
    {
        if (length > 0)
        {
            fixed (byte* pSource = &src[srcOffset])
            fixed (byte* pDestination = &dst[dstOffset])
            {
                Buffer.MemoryCopy(pSource, pDestination, length, length);
            }
        }
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class ReverseBenchmark
{
    private readonly int[] intArray = Enumerable.Range(0, 256).ToArray();

    private readonly byte[] byteArray = Enumerable.Range(0, 256).Select(x => (byte)x).ToArray();

    [Benchmark]
    public void ReverseInt4() => ReverseOperator.Reverse(intArray.AsSpan(0, 4));

    [Benchmark]
    public void ReverseUnsafeInt4() => ReverseOperator.ReverseUnsafe(intArray.AsSpan(0, 4));

    [Benchmark]
    public void ReversePointerInt4() => ReverseOperator.ReversePointer(intArray.AsSpan(0, 4));

    [Benchmark]
    public void ReverseInt8() => ReverseOperator.Reverse(intArray.AsSpan(0, 8));

    [Benchmark]
    public void ReverseUnsafeInt8() => ReverseOperator.ReverseUnsafe(intArray.AsSpan(0, 8));

    [Benchmark]
    public void ReversePointerInt8() => ReverseOperator.ReversePointer(intArray.AsSpan(0, 8));

    [Benchmark]
    public void ReverseInt32() => ReverseOperator.Reverse(intArray.AsSpan(0, 32));

    [Benchmark]
    public void ReverseUnsafeInt32() => ReverseOperator.ReverseUnsafe(intArray.AsSpan(0, 32));

    [Benchmark]
    public void ReversePointerInt32() => ReverseOperator.ReversePointer(intArray.AsSpan(0, 32));

    [Benchmark]
    public void ReverseInt256() => ReverseOperator.Reverse(intArray.AsSpan(0, 256));

    [Benchmark]
    public void ReverseUnsafeInt256() => ReverseOperator.ReverseUnsafe(intArray.AsSpan(0, 256));

    [Benchmark]
    public void ReversePointerInt256() => ReverseOperator.ReversePointer(intArray.AsSpan(0, 256));

    [Benchmark]
    public void ReverseByte4() => ReverseOperator.Reverse(byteArray.AsSpan(0, 4));

    [Benchmark]
    public void ReverseUnsafeByte4() => ReverseOperator.ReverseUnsafe(byteArray.AsSpan(0, 4));

    [Benchmark]
    public void ReversePointerByte4() => ReverseOperator.ReversePointer(byteArray.AsSpan(0, 4));

    [Benchmark]
    public void ReverseByte8() => ReverseOperator.Reverse(byteArray.AsSpan(0, 8));

    [Benchmark]
    public void ReverseUnsafeByte8() => ReverseOperator.ReverseUnsafe(byteArray.AsSpan(0, 8));

    [Benchmark]
    public void ReversePointerByte8() => ReverseOperator.ReversePointer(byteArray.AsSpan(0, 8));

    [Benchmark]
    public void ReverseByte32() => ReverseOperator.Reverse(byteArray.AsSpan(0, 32));

    [Benchmark]
    public void ReverseUnsafeByte32() => ReverseOperator.ReverseUnsafe(byteArray.AsSpan(0, 32));

    [Benchmark]
    public void ReversePointerByte32() => ReverseOperator.ReversePointer(byteArray.AsSpan(0, 32));

    [Benchmark]
    public void ReverseByte256() => ReverseOperator.Reverse(byteArray.AsSpan(0, 256));

    [Benchmark]
    public void ReverseUnsafeByte256() => ReverseOperator.ReverseUnsafe(byteArray.AsSpan(0, 256));

    [Benchmark]
    public void ReversePointerByte256() => ReverseOperator.ReversePointer(byteArray.AsSpan(0, 256));
}

public static class ReverseOperator
{
    public static void Reverse<T>(Span<T> array)
    {
        for (var i = 0; i < array.Length >> 1; i++)
        {
            T temp = array[i];
            array[i] = array[array.Length - i - 1];
            array[array.Length - i - 1] = temp;
        }
    }

    public static void ReverseUnsafe<T>(Span<T> array)
    {
        ref T p = ref MemoryMarshal.GetReference(array);
        var i = 0;
        var j = array.Length - 1;
        while (i < j)
        {
            T temp = Unsafe.Add(ref p, i);
            Unsafe.Add(ref p, i) = Unsafe.Add(ref p, j);
            Unsafe.Add(ref p, j) = temp;
            i++;
            j--;
        }
    }

    public static unsafe void ReversePointer(Span<byte> array)
    {
        var i = 0;
        var j = array.Length - 1;
        fixed (byte* p = array)
        {
            while (i < j)
            {
                var temp = *(p + i);
                *(p + i) = *(p + j);
                *(p + j) = temp;
                i++;
                j--;
            }
        }
    }

    public static unsafe void ReversePointer(Span<int> array)
    {
        var i = 0;
        var j = array.Length - 1;
        fixed (int* p = array)
        {
            while (i < j)
            {
                var temp = *(p + i);
                *(p + i) = *(p + j);
                *(p + j) = temp;
                i++;
                j--;
            }
        }
    }
}
