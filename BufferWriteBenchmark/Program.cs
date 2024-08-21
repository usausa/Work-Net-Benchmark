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
    private readonly byte[] memory = new byte[1024];

    [Params(1, 4, 64, 256)]
    public int Loop { get; set; }

    [Benchmark]
    public void WriteBinaryPrimitive()
    {
        var buffer = memory.AsSpan();
        for (var i = 0; i < Loop; i++)
        {
            BinaryPrimitives.WriteInt32BigEndian(buffer[(i * 4)..], i);
        }
    }

    [Benchmark]
    public void WriteBinaryPrimitive2()
    {
        var buffer = memory.AsSpan();
        for (var i = 0; i < Loop; i++)
        {
            BinaryPrimitives.WriteInt32BigEndian(buffer.Slice(i * 4, 4), i);
        }
    }

    [Benchmark]
    public void WriteMemoryMarshal()
    {
        var buffer = memory.AsSpan();
        for (var i = 0; i < Loop; i++)
        {
            MemoryMarshal.Write(buffer[(i * 4)..], i);
        }
    }

    [Benchmark]
    public void WriteMemoryMarshal2()
    {
        var buffer = memory.AsSpan();
        for (var i = 0; i < Loop; i++)
        {
            MemoryMarshal.Write(buffer.Slice(i * 4, 4), i);
        }
    }

    [Benchmark]
    public void WriteUnsafe()
    {
        var buffer = memory.AsSpan();
        ref var offset = ref MemoryMarshal.GetReference(buffer);
        for (var i = 0; i < Loop; i++)
        {
            Unsafe.WriteUnaligned(ref offset, i);
            offset = ref Unsafe.Add(ref offset, 4);
        }
    }

    [Benchmark]
    public void WriteUnsafe2()
    {
        // [MEMO] Reverse
        var buffer = memory.AsSpan();
        ref var p = ref MemoryMarshal.GetReference(buffer);
        ref var offset = ref Unsafe.As<byte, int>(ref p);
        for (var i = 0; i < Loop; i++)
        {
            offset = i;
            offset = ref Unsafe.Add(ref offset, 1);
        }
    }

    [Benchmark]
    public void WritePointer()
    {
        fixed (byte* p = memory.AsSpan())
        {
            var offset = (int*)p;
            for (var i = 0; i < Loop; i++)
            {
                *offset = i;
                offset += 1;
            }
        }
    }
}
