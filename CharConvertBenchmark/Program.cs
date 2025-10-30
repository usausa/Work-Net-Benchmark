namespace CharConvertBenchmark;

using System;
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
    private string source = default!;

    [Params(4, 8, 16, 256)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        source = new string('あ', Size);
    }

    [Benchmark]
    public string ByUnsafe() => Converter.ByUnsafe(source);

    [Benchmark]
    public string ByRef() => Converter.ByRef(source);
}

public static class Converter
{
    public static string ByUnsafe(ReadOnlySpan<char> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        var length = source.Length;
        var bufferSize = length << 1;
        var buffer = bufferSize < 512 ? stackalloc char[bufferSize] : new char[bufferSize];

        ref var start = ref MemoryMarshal.GetReference(buffer);
        ref var b = ref start;

        ref var c = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref c, length);

        while (Unsafe.IsAddressLessThan(ref c, ref end))
        {
            b = c;
            b = ref Unsafe.Add(ref b, 1);
            c = ref Unsafe.Add(ref c, 1);
        }

        return new string(buffer[..((int)Unsafe.ByteOffset(ref start, ref b) >> 1)]);
    }

    public static string ByRef(ReadOnlySpan<char> source)
    {
        if (source.IsEmpty)
        {
            return string.Empty;
        }

        var length = source.Length;
        var bufferSize = length << 1;
        var buffer = bufferSize < 512 ? stackalloc char[bufferSize] : new char[bufferSize];

        var bufferOffset = 0;
        for (var i = 0; i < length; i++)
        {
            ref var b = ref buffer[bufferOffset];
            b = source[i];
            bufferOffset++;
        }

        return new string(buffer[..bufferOffset]);
    }
}
