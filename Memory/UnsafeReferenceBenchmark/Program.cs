namespace UnsafeReferenceBenchmark;

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
        BenchmarkRunner.Run<SpanSearchBenchmark>();
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
public class Benchmark
{
    private int[] intArray = default!;
    private string[] stringArray = default!;

    [Params(1, 4, 8, 64, 1024)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        intArray = new int[Size];
        stringArray = new string[Size];
        stringArray.AsSpan().Fill(string.Empty);
    }

    [Benchmark]
    public int SpanInt()
    {
        var span = intArray.AsSpan();
        var sum = 0;
        for (var i = 0; i < span.Length; i++)
        {
            sum += span[i];
        }

        return sum;
    }

    [Benchmark]
    public int ReferenceInt()
    {
        var span = intArray.AsSpan();
        var sum = 0;
        ref var start = ref MemoryMarshal.GetReference(span);
        for (var i = 0; i < span.Length; i++)
        {
            sum += Unsafe.Add(ref start, i);
        }

        return sum;
    }

    [Benchmark]
    public int SpanString()
    {
        var span = stringArray.AsSpan();
        var sum = 0;
        for (var i = 0; i < span.Length; i++)
        {
            sum += span[i].Length;
        }

        return sum;
    }

    [Benchmark]
    public int ReferenceString()
    {
        var span = stringArray.AsSpan();
        var sum = 0;
        ref var start = ref MemoryMarshal.GetReference(span);
        for (var i = 0; i < span.Length; i++)
        {
            sum += Unsafe.Add(ref start, i).Length;
        }

        return sum;
    }
}
#pragma warning restore CA1822

// Span 内の値検索における実装方式 (Span indexer / Unsafe.Add for / Unsafe.Add while / unsafe pointer) を比較する。
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class SpanSearchBenchmark
{
    [Params(4, 16, 64, 256)]
    public int Size { get; set; }

    private int[] intArray = default!;

    [GlobalSetup]
    public void Setup()
    {
        intArray = new int[Size];
        intArray[Size - 1] = 1;
    }

    [Benchmark(Baseline = true)]
    public int SpanFor()
    {
        var span = intArray.AsSpan();
        for (var i = 0; i < span.Length; i++)
        {
            if (span[i] == 1)
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int UnsafeAddFor()
    {
        var span = intArray.AsSpan();
        ref var head = ref MemoryMarshal.GetReference(span);
        for (var i = 0; i < span.Length; i++)
        {
            if (Unsafe.Add(ref head, i) == 1)
            {
                return i;
            }
        }

        return -1;
    }

    [Benchmark]
    public int UnsafeAddWhile()
    {
        var span = intArray.AsSpan();
        ref var cur = ref MemoryMarshal.GetReference(span);
        ref var end = ref Unsafe.Add(ref cur, span.Length);
        var i = 0;
        while (Unsafe.IsAddressLessThan(ref cur, ref end))
        {
            if (cur == 1)
            {
                return i;
            }

            cur = ref Unsafe.Add(ref cur, 1);
            i++;
        }

        return -1;
    }

    [Benchmark]
    public unsafe int PointerFor()
    {
        var span = intArray.AsSpan();
        fixed (int* ptr = span)
        {
            for (var i = 0; i < span.Length; i++)
            {
                if (ptr[i] == 1)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    [Benchmark]
    public unsafe int PointerWhile()
    {
        var span = intArray.AsSpan();
        fixed (int* ptr = span)
        {
            var p = ptr;
            var pEnd = ptr + span.Length;
            var i = 0;
            while (p < pEnd)
            {
                if (*p == 1)
                {
                    return i;
                }

                p++;
                i++;
            }
        }

        return -1;
    }
}
