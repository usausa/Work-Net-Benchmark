using System.Buffers;
using System.Runtime.CompilerServices;

namespace TemporaryBenchmark;

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
        AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default);
        AddJob(Job.MediumRun);
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    [Params(16, 64, 256, 512, 1024, 4096)]
    public int Size { get; set; }

    [Benchmark(OperationsPerInvoke = N)]
    public void WithTemporaryFill1()
    {
        for (var i = 0; i < N; i++)
        {
            WithTemporaryFill1(Size);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void WithoutTemporaryFill1()
    {
        for (var i = 0; i < N; i++)
        {
            WithoutTemporaryFill1(Size);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void WithTemporaryFill2()
    {
        for (var i = 0; i < N; i++)
        {
            WithTemporaryFill2(Size);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void WithoutTemporaryFill2()
    {
        for (var i = 0; i < N; i++)
        {
            WithoutTemporaryFill2(Size);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void WithTemporaryFill3()
    {
        for (var i = 0; i < N; i++)
        {
            WithTemporaryFill3(Size);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void WithoutTemporaryFill3()
    {
        for (var i = 0; i < N; i++)
        {
            WithoutTemporaryFill3(Size);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void WithTemporaryFill1(int size)
    {
        using var temporary = size < 512
            ? new TemporaryBuffer<char>(stackalloc char[size])
            : new TemporaryBuffer<char>(size);
        var buffer = temporary.Buffer;
        Fill1(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void WithoutTemporaryFill1(int size)
    {
        var buffer = size < 512 ? stackalloc char[size] : new char[size];
        Fill1(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void WithTemporaryFill2(int size)
    {
        using var temporary = size < 512
            ? new TemporaryBuffer<char>(stackalloc char[size])
            : new TemporaryBuffer<char>(size);
        var buffer = temporary.Buffer;
        Fill2(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void WithoutTemporaryFill2(int size)
    {
        var buffer = size < 512 ? stackalloc char[size] : new char[size];
        Fill2(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void WithTemporaryFill3(int size)
    {
        using var temporary = size < 512
            ? new TemporaryBuffer<char>(stackalloc char[size])
            : new TemporaryBuffer<char>(size);
        var buffer = temporary.Buffer;
        Fill3(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void WithoutTemporaryFill3(int size)
    {
        var buffer = size < 512 ? stackalloc char[size] : new char[size];
        Fill3(buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void Fill1(Span<char> span)
    {
        for (var i = 0; i < span.Length; i++)
        {
            span[i] = ' ';
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static unsafe void Fill2(Span<char> span)
    {
        fixed (char* pBuffer = span)
        {
            for (var i = 0; i < span.Length; i++)
            {
                pBuffer[i] = ' ';
            }
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static unsafe void Fill3(Span<char> span)
    {
        fixed (char* pBuffer = span)
        {
            var p = pBuffer;
            for (var i = 0; i < span.Length; i++)
            {
                *p = ' ';
                p++;
            }
        }
    }
}

public ref struct TemporaryBuffer<T>
{
    private readonly Span<T> span;

    private T[]? pool;

    // ReSharper disable once ConvertToAutoProperty
    public Span<T> Buffer
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => span;
    }

    public TemporaryBuffer(Span<T> span)
    {
        this.span = span;
        pool = null;
    }

    public TemporaryBuffer(int size)
    {
        pool = ArrayPool<T>.Shared.Rent(size);
        span = pool;
    }

    public void Dispose()
    {
        if (pool is not null)
        {
            ArrayPool<T>.Shared.Return(pool);
            pool = null;
        }
    }
}