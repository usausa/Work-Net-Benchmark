namespace HexBenchmark;

using System;
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

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private static readonly byte[] Bytes = Enumerable.Range(0, 256).Select(x => (byte)x).ToArray();

    private static readonly string Hex = Convert.ToHexString(Bytes).Replace("-", string.Empty, StringComparison.CurrentCultureIgnoreCase);

    //--------------------------------------------------------------------------------
    // Encode
    //--------------------------------------------------------------------------------

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByIndexToPointer1() => HexEncoder.EncodeByIndexToPointer(Bytes);

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByIndexToReference1() => HexEncoder.EncodeByIndexToReference(Bytes);

    //--------------------------------------------------------------------------------
    // Encode
    //--------------------------------------------------------------------------------

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByIndexToPointer2() => HexEncoder.EncodeByIndexToPointer(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByIndexToReference2() => HexEncoder.EncodeByIndexToReference(Bytes, stackalloc char[512]);

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    // TODO

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    // TODO
}
#pragma warning restore CA1822

public static class HexEncoder
{
    private static ReadOnlySpan<byte> HexTable => "0123456789ABCDEF"u8;

    //--------------------------------------------------------------------------------
    // Encode
    //--------------------------------------------------------------------------------

    [SkipLocalsInit]
    public static unsafe string EncodeByIndexToPointer(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        var length = source.Length << 1;
        var buffer = length < 512 ? stackalloc char[length] : new char[length];

        fixed (char* pBuffer = buffer)
        {
            var pb = pBuffer;

            for (var i = 0; i < source.Length; i++)
            {
                var b = source[i];
                *pb = (char)Unsafe.Add(ref hex, b >> 4);
                pb++;
                *pb = (char)Unsafe.Add(ref hex, b & 0xF);
                pb++;
            }

            return new string(pBuffer, 0, length);
        }
    }

    [SkipLocalsInit]
    public static unsafe string EncodeByIndexToReference(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        var length = source.Length * 2;
        var span = length < 512 ? stackalloc char[length] : new char[length];
        ref var buffer = ref MemoryMarshal.GetReference(span);
        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < source.Length; i++)
        {
            var b = source[i];
            buffer = (char)Unsafe.Add(ref hex, b >> 4);
            buffer = ref Unsafe.Add(ref buffer, 1);
            buffer = (char)Unsafe.Add(ref hex, b & 0xF);
            buffer = ref Unsafe.Add(ref buffer, 1);
        }

        return new string(span);
    }

    // TODO PI
    // TODO PP
    // TODO PR

    // TODO RI
    // TODO RP
    // TODO RR

    //--------------------------------------------------------------------------------
    // Encode
    //--------------------------------------------------------------------------------

    public static unsafe int EncodeByIndexToPointer(ReadOnlySpan<byte> source, Span<char> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var length = source.Length << 1;
        if (destination.Length > length)
        {
            return -1;
        }

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        fixed (char* pDestination = destination)
        {
            var pd = pDestination;
            for (var i = 0; i < source.Length; i++)
            {
                var b = source[i];
                *pd = (char)Unsafe.Add(ref hex, b >> 4);
                pd++;
                *pd = (char)Unsafe.Add(ref hex, b & 0xF);
                pd++;
            }
        }

        return length;
    }

    public static int EncodeByIndexToReference(ReadOnlySpan<byte> source, Span<char> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var length = source.Length << 2;
        if (destination.Length > length)
        {
            return -1;
        }

        ref var buffer = ref MemoryMarshal.GetReference(destination);
        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < source.Length; i++)
        {
            var b = source[i];
            buffer = (char)Unsafe.Add(ref hex, b >> 4);
            buffer = ref Unsafe.Add(ref buffer, 1);
            buffer = (char)Unsafe.Add(ref hex, b & 0xF);
            buffer = ref Unsafe.Add(ref buffer, 1);
        }

        return length;
    }

    // TODO PI
    // TODO PP
    // TODO PR

    // TODO RI
    // TODO RP
    // TODO RR

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    // TODO stackalloc

    // TODO IP
    // TODO IR

    // TODO PI
    // TODO PP 1
    // TODO PR

    // TODO RI
    // TODO RP
    // TODO RR

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    // TODO stackalloc
    // TODO -1

    // TODO IP
    // TODO IR

    // TODO PI
    // TODO PP 1
    // TODO PR

    // TODO RI
    // TODO RP
    // TODO RR

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int CharToNumber(char c)
    {
        if ((c <= '9') && (c >= '0'))
        {
            return c - '0';
        }

        if ((c <= 'F') && (c >= 'A'))
        {
            return c - 'A' + 10;
        }

        if ((c <= 'f') && (c >= 'a'))
        {
            return c - 'a' + 10;
        }

        return 0;
    }
}
