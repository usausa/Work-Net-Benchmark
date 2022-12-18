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
        //AddJob(Job.MediumRun);
        AddJob(Job.ShortRun);
    }
}

#pragma warning disable CA1822
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
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

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByPointerToPointer1() => HexEncoder.EncodeByPointerToPointer(Bytes);

    // TODO 5

    //--------------------------------------------------------------------------------
    // Encode
    //--------------------------------------------------------------------------------

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByIndexToPointer2() => HexEncoder.EncodeByIndexToPointer(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByIndexToReference2() => HexEncoder.EncodeByIndexToReference(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByPointerToPointer2() => HexEncoder.EncodeByPointerToPointer(Bytes, stackalloc char[512]);

    // TODO 5

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    [BenchmarkCategory("Decode1")]
    [Benchmark]
    public byte[] DecodeByPointerToIndex1() => HexEncoder.DecodeByPointerToIndex(Hex);

    [BenchmarkCategory("Decode1")]
    [Benchmark]
    public byte[] DecodeByPointerToPointer1() => HexEncoder.DecodeByPointerToPointer(Hex);

    // TODO 6

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    [BenchmarkCategory("Decode2")]
    [Benchmark]
    public void DecodeByPointerToIndex2() => HexEncoder.DecodeByPointerToIndex(Hex, stackalloc byte[256]);

    [BenchmarkCategory("Decode2")]
    [Benchmark]
    public void DecodeByPointerToPointer2() => HexEncoder.DecodeByPointerToPointer(Hex, stackalloc byte[256]);

    // TODO 6
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

        var length = source.Length << 1;
        var buffer = length < 512 ? stackalloc char[length] : new char[length];

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

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

        var length = source.Length << 1;
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

    [SkipLocalsInit]
    public static unsafe string EncodeByPointerToPointer(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        var sourceLength = source.Length;
        var length = sourceLength << 1;
        var buffer = length < 512 ? stackalloc char[length] : new char[length];

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        fixed (byte* pSource = source)
        fixed (char* pBuffer = buffer)
        {
            var ps = pSource;
            var pb = pBuffer;

            for (var i = 0; i < sourceLength; i++)
            {
                var b = *ps;
                *pb = (char)Unsafe.Add(ref hex, b >> 4);
                pb++;
                *pb = (char)Unsafe.Add(ref hex, b & 0xF);
                pb++;
                ps++;
            }

            return new string(pBuffer, 0, length);
        }
    }

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
        if (length > destination.Length)
        {
            return -1;
        }

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        fixed (char* pBuffer = destination)
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
        }

        return length;
    }

    public static int EncodeByIndexToReference(ReadOnlySpan<byte> source, Span<char> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var length = source.Length << 1;
        if (length > destination.Length)
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

    public static unsafe int EncodeByPointerToPointer(ReadOnlySpan<byte> source, Span<char> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var sourceLength = source.Length;
        var length = sourceLength << 1;
        if (length > destination.Length)
        {
            return -1;
        }

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        fixed (byte* pSource = source)
        fixed (char* pBuffer = destination)
        {
            var ps = pSource;
            var pb = pBuffer;

            for (var i = 0; i < sourceLength; i++)
            {
                var b = *ps;
                *pb = (char)Unsafe.Add(ref hex, b >> 4);
                pb++;
                *pb = (char)Unsafe.Add(ref hex, b & 0xF);
                pb++;
                ps++;
            }
        }

        return length;
    }

    // TODO PR

    // TODO RI
    // TODO RP
    // TODO RR

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    // TODO IP
    // TODO IR

    [SkipLocalsInit]
    public static unsafe byte[] DecodeByPointerToIndex(ReadOnlySpan<char> source)
    {
        if (source.IsEmpty)
        {
            return Array.Empty<byte>();
        }

        var buffer = new byte[source.Length >> 1];

        fixed (char* pSource = source)
        {
            var ps = pSource;

            for (var i = 0; i < buffer.Length; i++)
            {
                var b = CharToNumber(*ps) << 4;
                ps++;
                buffer[i] = (byte)(b + CharToNumber(*ps));
                ps++;
            }
        }

        return buffer;
    }

    [SkipLocalsInit]
    public static unsafe byte[] DecodeByPointerToPointer(ReadOnlySpan<char> source)
    {
        if (source.IsEmpty)
        {
            return Array.Empty<byte>();
        }

        var buffer = new byte[source.Length >> 1];

        fixed (char* pSource = source)
        fixed (byte* pBuffer = &buffer[0])
        {
            var pb = pBuffer;
            var ps = pSource;

            for (var i = 0; i < buffer.Length; i++)
            {
                var b = CharToNumber(*ps) << 4;
                ps++;
                *pb = (byte)(b + CharToNumber(*ps));
                ps++;
                pb++;
            }
        }

        return buffer;
    }

    // TODO PR 2

    // TODO RI 1
    // TODO RP
    // TODO RR

    //--------------------------------------------------------------------------------
    // Decode
    //--------------------------------------------------------------------------------

    // TODO stackalloc
    // TODO -1

    // TODO IP
    // TODO IR

    public static unsafe int DecodeByPointerToIndex(ReadOnlySpan<char> source, Span<byte> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var length = source.Length >> 1;
        if (length > destination.Length)
        {
            return -1;
        }

        fixed (char* pSource = source)
        {
            var ps = pSource;

            for (var i = 0; i < length; i++)
            {
                var b = CharToNumber(*ps) << 4;
                ps++;
                destination[i] = (byte)(b + CharToNumber(*ps));
                ps++;
            }
        }

        return length;
    }

    public static unsafe int DecodeByPointerToPointer(ReadOnlySpan<char> source, Span<byte> destination)
    {
        if (source.IsEmpty)
        {
            return 0;
        }

        var length = source.Length >> 1;
        if (length > destination.Length)
        {
            return -1;
        }

        fixed (char* pSource = source)
        fixed (byte* pBuffer = destination)
        {
            var pb = pBuffer;
            var ps = pSource;

            for (var i = 0; i < length; i++)
            {
                var b = CharToNumber(*ps) << 4;
                ps++;
                *pb = (byte)(b + CharToNumber(*ps));
                ps++;
                pb++;
            }
        }

        return length;
    }

    // TODO PR 2

    // TODO RI 1
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
