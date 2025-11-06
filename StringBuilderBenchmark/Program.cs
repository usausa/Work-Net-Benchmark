#pragma warning disable SA1312
namespace StringBuilderBenchmark;

using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Text;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
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
    }
}

// TODO other impl
// TODO int mix

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
#pragma warning disable CA1822
public class Benchmark
{
    private const string Data = "12345678901234567890123456789012";

    [Benchmark]
    public string Builder()
    {
        var builder = new StringBuilder();
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        return builder.ToString();
    }

    [Benchmark]
    public string BuilderPrepared()
    {
        var builder = new StringBuilder(128);
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        return builder.ToString();
    }

    [Benchmark]
    public string Handler()
    {
        var handler = new DefaultInterpolatedStringHandler(0, 0);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        return handler.ToStringAndClear();
    }

    [Benchmark]
    public string HandlerPrepared()
    {
        var handler = new DefaultInterpolatedStringHandler(128, 0);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        return handler.ToStringAndClear();
    }

    [Benchmark]
    public string HandlerStack()
    {
        var handler = new DefaultInterpolatedStringHandler(0, 0, default, stackalloc char[128]);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        handler.AppendLiteral(Data);
        return handler.ToStringAndClear();
    }

    [Benchmark]
    public string ValueStringBuilder()
    {
        using var builder = new ValueStringBuilder(stackalloc char[128]);
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        return builder.ToString();
    }

    [Benchmark]
    public string PooledBuilder()
    {
        var builder = new PooledStringBuilder(128);
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        builder.Append(Data);
        return builder.ToString();
    }
}
#pragma warning restore CA1822

#pragma warning disable CA1051
#pragma warning disable CA1815
public ref struct ValueStringBuilder
{
    private char[]? arrayToReturnToPool;

    private Span<char> chars;

    public int Length;

    public ValueStringBuilder(Span<char> initialBuffer)
    {
        arrayToReturnToPool = null;
        chars = initialBuffer;
        Length = 0;
    }

    public ValueStringBuilder(int initialCapacity)
    {
        arrayToReturnToPool = ArrayPool<char>.Shared.Rent(initialCapacity);
        chars = arrayToReturnToPool;
        Length = 0;
    }

    public void Dispose()
    {
        var toReturn = arrayToReturnToPool;
        this = default; // for safety
        if (toReturn != null)
        {
            ArrayPool<char>.Shared.Return(toReturn);
        }
    }

    public override string ToString()
    {
        var s = chars[..Length].ToString();
        Dispose();
        return s;
    }

    public void Append(ReadOnlySpan<char> value)
    {
        var length = Length;
        if (length > chars.Length - value.Length)
        {
            Grow(value.Length);
        }

        value.CopyTo(chars[Length..]);
        Length += value.Length;
    }

    private void Grow(int additionalCapacityBeyondPos)
    {
        var poolArray = ArrayPool<char>.Shared.Rent((int)Math.Max((uint)(Length + additionalCapacityBeyondPos), (uint)chars.Length * 2));

        chars[..Length].CopyTo(poolArray);

        var toReturn = arrayToReturnToPool;
        chars = arrayToReturnToPool = poolArray;
        if (toReturn != null)
        {
            ArrayPool<char>.Shared.Return(toReturn);
        }
    }
}
#pragma warning restore CA1815
#pragma warning restore CA1051

#pragma warning disable CA1051
#pragma warning disable CA1815
public struct PooledStringBuilder
{
    [ThreadStatic]
    private static char[]? bufferCache;

    public int Length;

    private char[] buffer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PooledStringBuilder(int length)
    {
        if ((bufferCache is null) || (bufferCache.Length < length))
        {
            bufferCache = new char[length];
        }

        buffer = bufferCache;
        Length = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(ReadOnlySpan<char> value)
    {
        var length = Length;
        var buff = buffer;
        if (length > buff.Length - value.Length)
        {
            Grow(value.Length);
            buff = buffer;
        }

        value.CopyTo(buff.AsSpan(length));
        Length += value.Length;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Grow(int additional)
    {
        var buff = buffer;
        var newSize = Math.Max(buff.Length * 2, buff.Length - Length + additional);
        var newBuffer = new char[newSize];
        buff.AsSpan(0, Length).CopyTo(newBuffer.AsSpan());
        bufferCache = newBuffer;
        buffer = newBuffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override readonly string ToString()
    {
        return new(buffer, 0, Length);
    }
}
#pragma warning restore CA1815
#pragma warning restore CA1051
