namespace BufferWriteBenchmark;

using System.Buffers.Binary;
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

[Config(typeof(BenchmarkConfig))]
public unsafe class Benchmark
{
    [Params(1, 4, 64)]
    public int Loop { get; set; }

    [Benchmark]
    public void WriteBinaryPrimitive()
    {
        var buffer = (Span<byte>)stackalloc byte[Loop * 4];

        for (var i = 0; i < Loop; i++)
        {
            BinaryPrimitives.WriteInt32BigEndian(buffer[(i * 4)..], i);
        }
    }

    [Benchmark]
    public void WriteBinaryPrimitive2()
    {
        var buffer = (Span<byte>)stackalloc byte[Loop * 4];

        for (var i = 0; i < Loop; i++)
        {
            BinaryPrimitives.WriteInt32BigEndian(buffer.Slice(i * 4, 4), i);
        }
    }

    [Benchmark]
    public void WriteMemoryMarshal()
    {
        var buffer = (Span<byte>)stackalloc byte[Loop * 4];

        for (var i = 0; i < Loop; i++)
        {
            MemoryMarshal.Write(buffer[(i * 4)..], i);
        }
    }

    [Benchmark]
    public void WriteMemoryMarshal2()
    {
        var buffer = (Span<byte>)stackalloc byte[Loop * 4];

        for (var i = 0; i < Loop; i++)
        {
            MemoryMarshal.Write(buffer.Slice(i * 4, 4), i);
        }
    }

    [Benchmark]
    public void WriteUnsafe()
    {
        var buffer = (Span<byte>)stackalloc byte[Loop * 4];
        ref var offset = ref MemoryMarshal.GetReference(buffer);

        for (var i = 0; i < Loop; i++)
        {
            Unsafe.WriteUnaligned(ref offset, i);
            offset = ref Unsafe.Add(ref offset, 4);
        }
    }
}
