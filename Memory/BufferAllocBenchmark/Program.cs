namespace BufferAllocBenchmark;

using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
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
        BenchmarkRunner.Run<AllocBenchmark>();
        BenchmarkRunner.Run<CharBufferBenchmark>();
        BenchmarkRunner.Run<TemporaryBenchmark>();
        if (OperatingSystem.IsWindows())
        {
            BenchmarkRunner.Run<PInvokeBufferBenchmark>();
        }
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
public unsafe class AllocBenchmark
{
    private const int N = 1000;
    private const int Size = 1024 * 10_0000;

    [Benchmark(OperationsPerInvoke = N)]
    public void AllocManaged()
    {
        for (var i = 0; i < N; i++)
        {
            _ = new byte[Size];
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void AllocUnmanaged()
    {
        for (var i = 0; i < N; i++)
        {
            var ptr = Marshal.AllocHGlobal(Size);
            _ = new Span<byte>(ptr.ToPointer(), Size);
            Marshal.FreeHGlobal(ptr);
        }
    }

    [Benchmark]
    public void AllocManagedCount()
    {
        var buffer = new byte[Size];
        Sum(buffer);
    }

    [Benchmark]
    public void AllocUnmanagedCount()
    {
        var ptr = Marshal.AllocHGlobal(Size);
        var span = new Span<byte>(ptr.ToPointer(), Size);
        Sum(span);
        Marshal.FreeHGlobal(ptr);
    }

    private static int Sum(Span<byte> span)
    {
        var total = 0;
        foreach (var value in span)
        {
            total += value;
        }

        return total;
    }
}
#pragma warning restore CA1822

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class CharBufferBenchmark
{
    [Benchmark]
    [BenchmarkCategory("32", "New")]
    public int New32() => CharBufferOperator.New(32);

    [Benchmark]
    [BenchmarkCategory("32", "StackOrNew")]
    public int StackOrNew32() => CharBufferOperator.StackOrNew(32);

    [Benchmark]
    [BenchmarkCategory("32", "StackOrPool")]
    public int StackOrPool32() => CharBufferOperator.StackOrPool(32);

    [Benchmark]
    [BenchmarkCategory("256", "New")]
    public int New256() => CharBufferOperator.New(256);

    [Benchmark]
    [BenchmarkCategory("256", "StackOrNew")]
    public int StackOrNew256() => CharBufferOperator.StackOrNew(256);

    [Benchmark]
    [BenchmarkCategory("256", "StackOrPool")]
    public int StackOrPool256() => CharBufferOperator.StackOrPool(256);

    [Benchmark]
    [BenchmarkCategory("1024", "New")]
    public int New1024() => CharBufferOperator.New(1024);

    [Benchmark]
    [BenchmarkCategory("1024", "StackOrNew")]
    public int StackOrNew1024() => CharBufferOperator.StackOrNew(1024);

    [Benchmark]
    [BenchmarkCategory("1024", "StackOrPool")]
    public int StackOrPool1024() => CharBufferOperator.StackOrPool(1024);

    [Benchmark]
    [BenchmarkCategory("2048", "New")]
    public int New2048() => CharBufferOperator.New(2048);

    [Benchmark]
    [BenchmarkCategory("2048", "StackOrNew")]
    public int StackOrNew2048() => CharBufferOperator.StackOrNew(2048);

    [Benchmark]
    [BenchmarkCategory("2048", "StackOrPool")]
    public int StackOrPool2048() => CharBufferOperator.StackOrPool(2048);
}
#pragma warning restore CA1822

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class TemporaryBenchmark
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

#pragma warning disable CA1822
[SupportedOSPlatform("windows")]
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class PInvokeBufferBenchmark
{
    [Benchmark]
    public string ByStringBuilder()
    {
        var buffer = new StringBuilder(256);
        var size = (uint)buffer.Length;
        NativeMethods.GetComputerName(buffer, ref size);
        return buffer.ToString();
    }

    [Benchmark]
    public string BySpan()
    {
        Span<char> buffer = stackalloc char[256];
        var size = (uint)buffer.Length;
        NativeMethods.GetComputerName(ref MemoryMarshal.GetReference(buffer), ref size);
        return new string(buffer[..(int)size]);
    }
}
#pragma warning restore CA1822

public static class CharBufferOperator
{
    public static int New(int size)
    {
        var buffer = new char[size];
        return buffer.Length;
    }

    public static unsafe int StackOrNew(int size)
    {
        Span<char> buffer = size < 2048 ? stackalloc char[size] : new char[size];
        return buffer.Length;
    }

    public static unsafe int StackOrPool(int size)
    {
        var pool = default(char[]);
        Span<char> buffer = size < 2048 ? stackalloc char[size] : (pool = ArrayPool<char>.Shared.Rent(size));
        var ret = buffer.Length;
        if (pool != null)
        {
            ArrayPool<char>.Shared.Return(pool);
        }

        return ret;
    }
}

public ref struct TemporaryBuffer<T>
{
    private readonly Span<T> span;

    private T[]? pool;

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

[SupportedOSPlatform("windows")]
internal static class NativeMethods
{
#pragma warning disable CA1838
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    internal static extern bool GetComputerName(StringBuilder buffer, ref uint size);
#pragma warning restore CA1838

    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    internal static extern bool GetComputerName(ref char buffer, ref uint size);
}
