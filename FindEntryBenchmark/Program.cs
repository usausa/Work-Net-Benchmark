namespace FindEntryBenchmark;

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

// TODO struct ref

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CA1822
#pragma warning disable CA1307
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    private readonly ArrayContainer arrayContainer1 = new(
    [
        typeof(Class00), typeof(Class01), typeof(Class02), typeof(Class03), typeof(Class04),
        typeof(Class05), typeof(Class06), typeof(Class07), typeof(Class08), typeof(Class09)
    ]);

    private readonly StructArrayContainer arrayContainer2 = new(
    [
        typeof(Class00), typeof(Class01), typeof(Class02), typeof(Class03), typeof(Class04),
        typeof(Class05), typeof(Class06), typeof(Class07), typeof(Class08), typeof(Class09)
    ]);

    private readonly LinkContainer linkContainer = new(
    [
        typeof(Class00), typeof(Class01), typeof(Class02), typeof(Class03), typeof(Class04),
        typeof(Class05), typeof(Class06), typeof(Class07), typeof(Class08), typeof(Class09)
    ]);

    private readonly Type key1 = typeof(Class00);

    private readonly Type key2 = typeof(Class01);

    private readonly Type key4 = typeof(Class03);

    private readonly Type key8 = typeof(Class07);

    private Type key = default!;

    [Params(1, 2, 4, 8)]
    public int Parameter { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        key = Parameter switch
        {
            1 => key1,
            2 => key2,
            4 => key4,
            8 => key8,
            _ => default!
        };
    }

    [Benchmark]
    public void ArrayC1()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer1.Find(k);
        }
    }

    [Benchmark]
    public void ArrayC2()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer1.Find2(k);
        }
    }

    [Benchmark]
    public void ArrayC3()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer1.Find3(k);
        }
    }

    [Benchmark]
    public void ArrayS1()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find(k);
        }
    }

    [Benchmark]
    public void ArrayS2()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find2(k);
        }
    }

    [Benchmark]
    public void ArrayS3()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find3(k);
        }
    }

    [Benchmark]
    public void ArrayS4()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find4(k);
        }
    }

    [Benchmark]
    public void ArrayS5()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find5(k);
        }
    }

    [Benchmark]
    public void Link1()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find(k);
        }
    }

    [Benchmark]
    public void Link2()
    {
        var k = key;
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find2(k);
        }
    }
}

#pragma warning disable CA1051
#pragma warning disable SA1401
// ReSharper disable FieldCanBeMadeReadOnly.Global

public sealed class ArrayContainer
{
    private readonly Entry[] entries;

    public ArrayContainer(IEnumerable<Type> types)
    {
        entries = types.Select(x => new Entry { Key = x }).ToArray();
    }

    public object? Find(Type type)
    {
        for (var i = 0; i < entries.Length; i++)
        {
            var entry = entries[i];
            if (entry.Key == type)
            {
                return entry.Data;
            }
        }

        return null;
    }

    public object? Find2(Type type)
    {
        var span = new Span<Entry>(entries);
        for (var i = 0; i < span.Length; i++)
        {
            if (span[i].Key == type)
            {
                return span[i].Data;
            }
        }

        return null;
    }

    public object? Find3(Type type)
    {
        var span = new Span<Entry>(entries);
        for (var i = 0; i < span.Length; i++)
        {
            var entry = span[i];
            if (entry.Key == type)
            {
                return entry.Data;
            }
        }

        return null;
    }

    public class Entry
    {
        public Type Key = default!;

        public object Data = default!;
    }
}

public sealed class StructArrayContainer
{
    private readonly Entry[] entries;

    public StructArrayContainer(IEnumerable<Type> types)
    {
        entries = types.Select(x => new Entry { Key = x }).ToArray();
    }

    public object? Find(Type type)
    {
        for (var i = 0; i < entries.Length; i++)
        {
            var entry = entries[i];
            if (entry.Key == type)
            {
                return entry.Data;
            }
        }

        return null;
    }

    public object? Find2(Type type)
    {
        var span = new Span<Entry>(entries);
        for (var i = 0; i < span.Length; i++)
        {
            if (span[i].Key == type)
            {
                return span[i].Data;
            }
        }

        return null;
    }

    public object? Find3(Type type)
    {
        var span = new Span<Entry>(entries);
        for (var i = 0; i < span.Length; i++)
        {
            var entry = span[i];
            if (entry.Key == type)
            {
                return entry.Data;
            }
        }

        return null;
    }

    public object? Find4(Type type)
    {
        var i = 0;
        do
        {
            ref var entry = ref entries[i];
            if (entry.Key == type)
            {
                return entry.Data;
            }

            i++;
        }
        while (i < entries.Length);

        return null;
    }

    public object? Find5(Type type)
    {
        ref var entry = ref MemoryMarshal.GetArrayDataReference(entries);
        do
        {
            if (entry.Key == type)
            {
                return entry.Data;
            }

            entry = ref Unsafe.Add(ref entry, 1);
            ref var end = ref Unsafe.Add(ref entry, entries.Length);
            if (Unsafe.IsAddressLessThan(ref entry, ref end))
            {
                continue;
            }

            break;
        }
        while (true);

        return null;
    }

#pragma warning disable CA1815
    [StructLayout(LayoutKind.Auto)]
    public struct Entry
    {
        public Type Key = default!;

        public object Data = default!;

        public Entry(Type key, object data)
        {
            Key = key;
            Data = data;
        }
    }
#pragma warning restore CA1815
}

public sealed class LinkContainer
{
    private readonly Entry first = default!;

    public LinkContainer(Type[] types)
    {
        Entry? previous = null;
        for (var i = 0; i < types.Length; i++)
        {
            var entry = new Entry { Key = types[i] };
            if (previous != null)
            {
                previous.Next = entry;
            }
            else
            {
                first = entry;
            }

            previous = entry;
        }
    }

    public object? Find(Type type)
    {
        var entry = first;
        do
        {
            if (entry.Key == type)
            {
                return entry.Data;
            }

            entry = entry.Next;
        }
        while (entry != null);

        return null;
    }

    public object? Find2(Type type)
    {
        var entry = first;
        while (entry != null)
        {
            if (entry.Key == type)
            {
                return entry.Data;
            }

            entry = entry.Next;
        }

        return null;
    }

    public class Entry
    {
        public Type Key = default!;

        public Entry? Next;

        public object Data = default!;
    }
}

#pragma warning disable SA1502
// ReSharper disable RedundantTypeDeclarationBody
public class Class00 { }
public class Class01 { }
public class Class02 { }
public class Class03 { }
public class Class04 { }
public class Class05 { }
public class Class06 { }
public class Class07 { }
public class Class08 { }
public class Class09 { }
