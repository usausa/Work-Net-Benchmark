namespace StringAppendBenchmark;

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Text;

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
        BenchmarkRunner.Run<PooledBuilderBenchmark>();
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
    private const int N = 1000;

    private readonly string token40 = new('A', 40);
    private readonly string token20 = new('B', 20);
    private readonly string token10 = new('C', 10);
    private readonly string token400 = new('A', 400);
    private readonly string token200 = new('B', 200);
    private readonly string token100 = new('C', 100);

    private readonly bool conditionA = true;
    private readonly bool conditionB = true;
    private readonly bool conditionB2 = true;
    private readonly bool conditionB3 = true;
    private readonly bool conditionB4 = true;

    [Benchmark(OperationsPerInvoke = N)]
    public string StringLen32Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            ret = token20;
            if (conditionA)
            {
                ret += token10;
            }
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringBuilderLen32Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new StringBuilder(32);
            sb.Append(token20);
            if (conditionA)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PoolBufferLen32Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            using var sb = new PoolBuffer(32);
            sb.Append(token20);
            if (conditionA)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string ThreadStaticBufferLen32Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new ThreadStaticBuffer(32);
            sb.Append(token20);
            if (conditionA)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringLen64Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            ret = token40;
            if (conditionA)
            {
                ret += token20;
            }
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringBuilderLen64Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new StringBuilder(64);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PoolBufferLen64Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            using var sb = new PoolBuffer(64);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string ThreadStaticBufferLen64Add1()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new ThreadStaticBuffer(64);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringLen128Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            ret = token40;
            if (conditionA)
            {
                ret += token20;
            }

            if (conditionB)
            {
                ret += token10;
            }
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringBuilderLen128Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new StringBuilder(128);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            if (conditionB)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PoolBufferLen128Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            using var sb = new PoolBuffer(128);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            if (conditionB)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string ThreadStaticBufferLen128Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new ThreadStaticBuffer(128);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            if (conditionB)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringLen128Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            ret = token40;
            if (conditionA)
            {
                ret += token20;
            }

            if (conditionB)
            {
                ret += token10;
            }

            if (conditionB2)
            {
                ret += token10;
            }

            if (conditionB3)
            {
                ret += token10;
            }

            if (conditionB4)
            {
                ret += token10;
            }
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringBuilderLen128Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new StringBuilder(128);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            if (conditionB)
            {
                sb.Append(token10);
            }

            if (conditionB2)
            {
                sb.Append(token10);
            }

            if (conditionB3)
            {
                sb.Append(token10);
            }

            if (conditionB4)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PoolBufferLen128Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            using var sb = new PoolBuffer(128);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            if (conditionB)
            {
                sb.Append(token10);
            }

            if (conditionB2)
            {
                sb.Append(token10);
            }

            if (conditionB3)
            {
                sb.Append(token10);
            }

            if (conditionB4)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string ThreadStaticBufferLen128Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new ThreadStaticBuffer(128);
            sb.Append(token40);
            if (conditionA)
            {
                sb.Append(token20);
            }

            if (conditionB)
            {
                sb.Append(token10);
            }

            if (conditionB2)
            {
                sb.Append(token10);
            }

            if (conditionB3)
            {
                sb.Append(token10);
            }

            if (conditionB4)
            {
                sb.Append(token10);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringLen1024Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            ret = token400;
            if (conditionA)
            {
                ret += token200;
            }

            if (conditionB)
            {
                ret += token100;
            }
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringBuilderLen1024Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new StringBuilder(1024);
            sb.Append(token400);
            if (conditionA)
            {
                sb.Append(token200);
            }

            if (conditionB)
            {
                sb.Append(token100);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PoolBufferLen1024Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            using var sb = new PoolBuffer(1024);
            sb.Append(token400);
            if (conditionA)
            {
                sb.Append(token200);
            }

            if (conditionB)
            {
                sb.Append(token100);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string ThreadStaticBufferLen1024Add2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new ThreadStaticBuffer(1024);
            sb.Append(token400);
            if (conditionA)
            {
                sb.Append(token200);
            }

            if (conditionB)
            {
                sb.Append(token100);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringLen1024Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            ret = token400;
            if (conditionA)
            {
                ret += token200;
            }

            if (conditionB)
            {
                ret += token100;
            }

            if (conditionB2)
            {
                ret += token100;
            }

            if (conditionB3)
            {
                ret += token100;
            }

            if (conditionB4)
            {
                ret += token100;
            }
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string StringBuilderLen1024Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new StringBuilder(1024);
            sb.Append(token400);
            if (conditionA)
            {
                sb.Append(token200);
            }

            if (conditionB)
            {
                sb.Append(token100);
            }

            if (conditionB2)
            {
                sb.Append(token100);
            }

            if (conditionB3)
            {
                sb.Append(token100);
            }

            if (conditionB4)
            {
                sb.Append(token100);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PoolBufferLen1024Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            using var sb = new PoolBuffer(1024);
            sb.Append(token400);
            if (conditionA)
            {
                sb.Append(token200);
            }

            if (conditionB)
            {
                sb.Append(token100);
            }

            if (conditionB2)
            {
                sb.Append(token100);
            }

            if (conditionB3)
            {
                sb.Append(token100);
            }

            if (conditionB4)
            {
                sb.Append(token100);
            }

            ret = sb.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string ThreadStaticBufferLen1024Add5()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var sb = new ThreadStaticBuffer(1024);
            sb.Append(token400);
            if (conditionA)
            {
                sb.Append(token200);
            }

            if (conditionB)
            {
                sb.Append(token100);
            }

            if (conditionB2)
            {
                sb.Append(token100);
            }

            if (conditionB3)
            {
                sb.Append(token100);
            }

            if (conditionB4)
            {
                sb.Append(token100);
            }

            ret = sb.ToString();
        }

        return ret;
    }
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class PooledBuilderBenchmark
{
    private const int N = 1000;

    private static readonly string Value1 = new(' ', 100);
    private static readonly string Value2 = new(' ', 50);
    private static readonly string Value3 = new(' ', 25);
    private static readonly string Value4 = new(' ', 25);

    [Benchmark(OperationsPerInvoke = N, Baseline = true)]
    public string DefaultStringBuilder()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var buffer = new StringBuilder(256);
            buffer.Append(Value1);
            buffer.Append(Value2);
            buffer.Append(Value3);
            buffer.Append(Value4);
            ret = buffer.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PooledStringBuilder()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var buffer = new PooledBufferStringBuilder(256);
            buffer.Append(Value1);
            buffer.Append(Value2);
            buffer.Append(Value3);
            buffer.Append(Value4);
            ret = buffer.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PooledStringBuilder2()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var buffer = new PooledBufferStringBuilder2(256);
            buffer.Append(Value1);
            buffer.Append(Value2);
            buffer.Append(Value3);
            buffer.Append(Value4);
            ret = buffer.ToString();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public string PooledStringBuilder3()
    {
        var ret = string.Empty;
        for (var i = 0; i < N; i++)
        {
            var buffer = new PooledBufferStringBuilder3(256);
            buffer.Append(Value1);
            buffer.Append(Value2);
            buffer.Append(Value3);
            buffer.Append(Value4);
            ret = buffer.ToString();
        }

        return ret;
    }
}
#pragma warning restore CA1822

#pragma warning disable CA1815, CA1051
public struct PoolBuffer : IDisposable
{
    private char[] buffer;
    private int index;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PoolBuffer(int length)
    {
        buffer = ArrayPool<char>.Shared.Rent(length);
        index = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        ArrayPool<char>.Shared.Return(buffer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(string value)
    {
        var length = value.Length;
        if (buffer.Length - index < length)
        {
            var newSize = Math.Max(buffer.Length * 2, buffer.Length - index + length);
            var newBuffer = ArrayPool<char>.Shared.Rent(newSize);
            buffer.AsSpan(0, index).CopyTo(newBuffer.AsSpan());
            ArrayPool<char>.Shared.Return(buffer);
            buffer = newBuffer;
        }

        value.AsSpan().CopyTo(buffer.AsSpan(index));
        index += length;
    }

    public override string ToString() => new(buffer, 0, index);
}

public struct ThreadStaticBuffer
{
    [ThreadStatic]
    private static char[]? threadBuffer;

    private int index;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ThreadStaticBuffer(int length)
    {
        if ((threadBuffer is null) || (threadBuffer.Length < length))
        {
            threadBuffer = new char[length];
        }

        index = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(string value)
    {
        var length = value.Length;
        if (threadBuffer!.Length - index < length)
        {
            var newSize = Math.Max(threadBuffer.Length * 2, threadBuffer.Length - index + length);
            var newBuffer = new char[newSize];
            threadBuffer.AsSpan(0, index).CopyTo(newBuffer.AsSpan());
            threadBuffer = newBuffer;
        }

        value.AsSpan().CopyTo(threadBuffer.AsSpan(index));
        index += length;
    }

    public override string ToString() => new(threadBuffer!, 0, index);
}

public struct PooledBufferStringBuilder
{
    [ThreadStatic]
    private static char[]? threadBuffer;

    public int Length;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PooledBufferStringBuilder(int length)
    {
        if ((threadBuffer is null) || (threadBuffer.Length < length))
        {
            threadBuffer = new char[length];
        }

        Length = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append<T>(T value)
    {
        Append(value!.ToString()!.AsSpan());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(ReadOnlySpan<char> value)
    {
        var length = value.Length;
        if (threadBuffer!.Length - Length < length)
        {
            var newSize = Math.Max(threadBuffer.Length * 2, threadBuffer.Length - Length + length);
            var newBuffer = new char[newSize];
            threadBuffer.AsSpan(0, Length).CopyTo(newBuffer.AsSpan());
            threadBuffer = newBuffer;
        }

        value.CopyTo(threadBuffer.AsSpan(Length));
        Length += length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => new(threadBuffer!, 0, Length);
}

public struct PooledBufferStringBuilder2
{
    [ThreadStatic]
    private static char[]? threadBuffer;

    public int Length;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PooledBufferStringBuilder2(int length)
    {
        if ((threadBuffer is null) || (threadBuffer.Length < length))
        {
            threadBuffer = new char[length];
        }

        Length = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append<T>(T value)
    {
        Append(value!.ToString()!.AsSpan());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(ReadOnlySpan<char> value)
    {
        var length = Length;
        if (length > threadBuffer!.Length - value.Length)
        {
            Grow(value.Length);
        }

        value.CopyTo(threadBuffer.AsSpan(length));
        Length += value.Length;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void Grow(int additional)
    {
        var newSize = Math.Max(threadBuffer!.Length * 2, threadBuffer.Length - Length + additional);
        var newBuffer = new char[newSize];
        threadBuffer.AsSpan(0, Length).CopyTo(newBuffer.AsSpan());
        threadBuffer = newBuffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => new(threadBuffer!, 0, Length);
}

public struct PooledBufferStringBuilder3
{
    [ThreadStatic]
    private static char[]? threadBufferCache;

    private char[] buffer;

    public int Length;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public PooledBufferStringBuilder3(int length)
    {
        if ((threadBufferCache is null) || (threadBufferCache.Length < length))
        {
            threadBufferCache = new char[length];
        }

        buffer = threadBufferCache;
        Length = 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append<T>(T value)
    {
        Append(value!.ToString()!.AsSpan());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(ReadOnlySpan<char> value)
    {
        var length = Length;
        var buff = buffer;
        if (length > buff.Length - value.Length)
        {
            Grow(value.Length);
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
        buffer = newBuffer;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => new(buffer, 0, Length);
}
#pragma warning restore CA1815, CA1051
