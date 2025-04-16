namespace EntryBenchmark;

using System;
using System.Buffers;

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
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
        AddJob(Job.MediumRun);
    }
}

#pragma warning disable SA1312
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    [Params(4, 8, 16)]
    public int Size { get; set; }

    [Benchmark]
    public void Class()
    {
        using var _ = new ClassEntryHolder<string>(Size, string.Empty);
    }

    [Benchmark]
    public void PooledClassPooled()
    {
        using var _ = new PooledClassEntryHolder<string>(Size, string.Empty);
    }

    [Benchmark]
    public void PooledStruct()
    {
        using var _ = new PooledStructEntryHolder<string>(Size, string.Empty);
    }
}
#pragma warning restore SA1312

// ReSharper disable CollectionNeverQueried.Local
// ReSharper disable NotAccessedField.Local
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
#pragma warning disable SA1401
public sealed class ClassEntryHolder<T> : IDisposable
{
    private sealed class Entry
    {
        public int Key;

        public T Value = default!;
    }

    private readonly Entry[] entries;

    public ClassEntryHolder(int size, T value)
    {
        entries = new Entry[size];
        for (var i = 0; i < size; i++)
        {
            entries[i] = new Entry
            {
                Key = i,
                Value = value
            };
        }
    }

    public void Dispose()
    {
    }
}

public sealed class PooledClassEntryHolder<T> : IDisposable
{
    private sealed class Entry
    {
        public int Key;

        public T Value = default!;
    }

    private readonly Entry[] entries;

    public PooledClassEntryHolder(int size, T value)
    {
        entries = ArrayPool<Entry>.Shared.Rent(size);
        for (var i = 0; i < size; i++)
        {
            entries[i] = new Entry
            {
                Key = i,
                Value = value
            };
        }
    }

    public void Dispose()
    {
        ArrayPool<Entry>.Shared.Return(entries, true);
    }
}

public sealed class PooledStructEntryHolder<T> : IDisposable
{
    private struct Entry
    {
        public int Key;

        public T Value;
    }

    private readonly Entry[] entries;

    public PooledStructEntryHolder(int size, T value)
    {
        entries = ArrayPool<Entry>.Shared.Rent(size);
        for (var i = 0; i < size; i++)
        {
            ref var entry = ref entries[i];
            entry.Key = i;
            entry.Value = value;
        }
    }

    public void Dispose()
    {
        ArrayPool<Entry>.Shared.Return(entries, true);
    }
}
