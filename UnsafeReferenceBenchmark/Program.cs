namespace UnsafeReferenceBenchmark;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
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
