namespace HexBenchmark;

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
            StatisticColumn.StdDev,
            CategoriesColumn.Default);
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
    }
}

#pragma warning disable CA1822
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private static readonly byte[] Bytes = Enumerable.Range(0, 256).Select(x => (byte)x).ToArray();

    private static readonly string Hex = Convert.ToHexString(Bytes).Replace("-", string.Empty, StringComparison.CurrentCultureIgnoreCase);

    [BenchmarkCategory("Default")]
    [Benchmark]
    public string EncodeDefault() => Convert.ToHexString(Bytes);

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByIndexToPointer1() => HexEncoder.EncodeByIndexToPointer(Bytes);

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByIndexToReference1() => HexEncoder.EncodeByIndexToReference(Bytes);

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByPointerToIndex1() => HexEncoder.EncodeByPointerToIndex(Bytes);

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByPointerToPointer1() => HexEncoder.EncodeByPointerToPointer(Bytes);

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByReferenceToIndex1() => HexEncoder.EncodeByReferenceToIndex(Bytes);

    [BenchmarkCategory("Encode1")]
    [Benchmark]
    public string EncodeByReferenceToReference1() => HexEncoder.EncodeByReferenceToReference(Bytes);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByIndexToPointer2() => HexEncoder.EncodeByIndexToPointer(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByIndexToReference2() => HexEncoder.EncodeByIndexToReference(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByPointerToIndex2() => HexEncoder.EncodeByPointerToIndex(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByPointerToPointer2() => HexEncoder.EncodeByPointerToPointer(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByReferenceToIndex2() => HexEncoder.EncodeByReferenceToIndex(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Encode2")]
    [Benchmark]
    public void EncodeByReferenceToReference2() => HexEncoder.EncodeByReferenceToReference(Bytes, stackalloc char[512]);

    [BenchmarkCategory("Default")]
    [Benchmark]
    public byte[] DecodeDefault() => Convert.FromHexString(Hex);

    [BenchmarkCategory("Decode1")]
    [Benchmark]
    public byte[] DecodeByPointerToIndex1() => HexEncoder.DecodeByPointerToIndex(Hex);

    [BenchmarkCategory("Decode1")]
    [Benchmark]
    public byte[] DecodeByPointerToPointer1() => HexEncoder.DecodeByPointerToPointer(Hex);

    [BenchmarkCategory("Decode1")]
    [Benchmark]
    public byte[] DecodeByReferenceToIndex1() => HexEncoder.DecodeByReferenceToIndex(Hex);

    [BenchmarkCategory("Decode1")]
    [Benchmark]
    public byte[] DecodeByReferenceToReference1() => HexEncoder.DecodeByReferenceToReference(Hex);

    [BenchmarkCategory("Decode2")]
    [Benchmark]
    public void DecodeByPointerToIndex2() => HexEncoder.DecodeByPointerToIndex(Hex, stackalloc byte[256]);

    [BenchmarkCategory("Decode2")]
    [Benchmark]
    public void DecodeByPointerToPointer2() => HexEncoder.DecodeByPointerToPointer(Hex, stackalloc byte[256]);

    [BenchmarkCategory("Decode2")]
    [Benchmark]
    public void DecodeByReferenceToIndex2() => HexEncoder.DecodeByReferenceToIndex(Hex, stackalloc byte[256]);

    [BenchmarkCategory("Decode2")]
    [Benchmark]
    public void DecodeByReferenceToReference2() => HexEncoder.DecodeByReferenceToReference(Hex, stackalloc byte[256]);
}
#pragma warning restore CA1822

public static class HexEncoder
{
    private static ReadOnlySpan<byte> HexTable => "0123456789ABCDEF"u8;

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
    public static string EncodeByIndexToReference(ReadOnlySpan<byte> source)
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

    [SkipLocalsInit]
    public static unsafe string EncodeByPointerToIndex(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        var length = source.Length << 1;
        var buffer = length < 512 ? stackalloc char[length] : new char[length];

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        fixed (byte* pSource = source)
        {
            var ps = pSource;

            for (var i = 0; i < buffer.Length; i += 2)
            {
                var b = *ps;
                buffer[i] = (char)Unsafe.Add(ref hex, b >> 4);
                buffer[i + 1] = (char)Unsafe.Add(ref hex, b & 0xF);
                ps++;
            }

            return new string(buffer);
        }
    }

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

    [SkipLocalsInit]
    public static string EncodeByReferenceToIndex(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        var length = source.Length << 1;
        var buffer = length < 512 ? stackalloc char[length] : new char[length];
        ref var sr = ref MemoryMarshal.GetReference(source);

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < buffer.Length; i += 2)
        {
            var b = sr;
            buffer[i] = (char)Unsafe.Add(ref hex, b >> 4);
            buffer[i + 1] = (char)Unsafe.Add(ref hex, b & 0xF);
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return new string(buffer);
    }

    [SkipLocalsInit]
    public static string EncodeByReferenceToReference(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        var length = source.Length << 1;
        var buffer = length < 512 ? stackalloc char[length] : new char[length];
        ref var dr = ref MemoryMarshal.GetReference(buffer);
        ref var sr = ref MemoryMarshal.GetReference(source);

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < buffer.Length; i += 2)
        {
            var b = sr;
            dr = (char)Unsafe.Add(ref hex, b >> 4);
            dr = ref Unsafe.Add(ref dr, 1);
            dr = (char)Unsafe.Add(ref hex, b & 0xF);
            dr = ref Unsafe.Add(ref dr, 1);
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return new string(buffer);
    }

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

    public static unsafe int EncodeByPointerToIndex(ReadOnlySpan<byte> source, Span<char> destination)
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

        fixed (byte* pSource = source)
        {
            var ps = pSource;

            for (var i = 0; i < destination.Length; i += 2)
            {
                var b = *ps;
                destination[i] = (char)Unsafe.Add(ref hex, b >> 4);
                destination[i + 1] = (char)Unsafe.Add(ref hex, b & 0xF);
                ps++;
            }
        }

        return length;
    }

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

    public static int EncodeByReferenceToIndex(ReadOnlySpan<byte> source, Span<char> destination)
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

        ref var sr = ref MemoryMarshal.GetReference(source);

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < destination.Length; i += 2)
        {
            var b = sr;
            destination[i] = (char)Unsafe.Add(ref hex, b >> 4);
            destination[i + 1] = (char)Unsafe.Add(ref hex, b & 0xF);
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return length;
    }

    public static int EncodeByReferenceToReference(ReadOnlySpan<byte> source, Span<char> destination)
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

        ref var dr = ref MemoryMarshal.GetReference(destination);
        ref var sr = ref MemoryMarshal.GetReference(source);

        ref var hex = ref MemoryMarshal.GetReference(HexTable);

        for (var i = 0; i < destination.Length; i += 2)
        {
            var b = sr;
            dr = (char)Unsafe.Add(ref hex, b >> 4);
            dr = ref Unsafe.Add(ref dr, 1);
            dr = (char)Unsafe.Add(ref hex, b & 0xF);
            dr = ref Unsafe.Add(ref dr, 1);
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return length;
    }

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

        var length = source.Length >> 1;
        var buffer = new byte[length];

        fixed (char* pSource = source)
        fixed (byte* pBuffer = &buffer[0])
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

        return buffer;
    }

    [SkipLocalsInit]
    public static byte[] DecodeByReferenceToIndex(ReadOnlySpan<char> source)
    {
        if (source.IsEmpty)
        {
            return Array.Empty<byte>();
        }

        var buffer = new byte[source.Length >> 1];
        ref var sr = ref MemoryMarshal.GetReference(source);

        for (var i = 0; i < buffer.Length; i++)
        {
            var b = CharToNumber(sr) << 4;
            sr = ref Unsafe.Add(ref sr, 1);
            buffer[i] = (byte)(b + CharToNumber(sr));
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return buffer;
    }

    [SkipLocalsInit]
    public static byte[] DecodeByReferenceToReference(ReadOnlySpan<char> source)
    {
        if (source.IsEmpty)
        {
            return Array.Empty<byte>();
        }

        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length >> 1;
        var buffer = new byte[length];
        ref var dr = ref MemoryMarshal.GetReference<byte>(buffer);

        for (var i = 0; i < length; i++)
        {
            var b = CharToNumber(sr) << 4;
            sr = ref Unsafe.Add(ref sr, 1);
            dr = (byte)(b + CharToNumber(sr));
            sr = ref Unsafe.Add(ref sr, 1);
            dr = ref Unsafe.Add(ref dr, 1);
        }

        return buffer;
    }

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

    public static int DecodeByReferenceToIndex(ReadOnlySpan<char> source, Span<byte> destination)
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

        ref var sr = ref MemoryMarshal.GetReference(source);

        for (var i = 0; i < length; i++)
        {
            var b = CharToNumber(sr) << 4;
            sr = ref Unsafe.Add(ref sr, 1);
            destination[i] = (byte)(b + CharToNumber(sr));
            sr = ref Unsafe.Add(ref sr, 1);
        }

        return length;
    }

    public static int DecodeByReferenceToReference(ReadOnlySpan<char> source, Span<byte> destination)
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

        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var dr = ref MemoryMarshal.GetReference(destination);

        for (var i = 0; i < length; i++)
        {
            var b = CharToNumber(sr) << 4;
            sr = ref Unsafe.Add(ref sr, 1);
            dr = (byte)(b + CharToNumber(sr));
            sr = ref Unsafe.Add(ref sr, 1);
            dr = ref Unsafe.Add(ref dr, 1);
        }

        return length;
    }

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
