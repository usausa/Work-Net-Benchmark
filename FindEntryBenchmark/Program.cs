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

    private readonly ArrayContainer arrayContainer = new(
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

    [Benchmark]
    public void Array1()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer.Find(key1);
        }
    }

    [Benchmark]
    public void Array2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer.Find(key2);
        }
    }

    [Benchmark]
    public void Array4()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer.Find(key4);
        }
    }

    [Benchmark]
    public void Array8()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer.Find(key8);
        }
    }

    [Benchmark]
    public void ArrayB1()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find(key1);
        }
    }

    [Benchmark]
    public void ArrayB2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find(key2);
        }
    }

    [Benchmark]
    public void ArrayB4()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find(key4);
        }
    }

    [Benchmark]
    public void ArrayB8()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find(key8);
        }
    }

    [Benchmark]
    public void ArrayC1()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find2(key1);
        }
    }

    [Benchmark]
    public void ArrayC2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find2(key2);
        }
    }

    [Benchmark]
    public void ArrayC4()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find2(key4);
        }
    }

    [Benchmark]
    public void ArrayC8()
    {
        for (var i = 0; i < N; i++)
        {
            _ = arrayContainer2.Find2(key8);
        }
    }

    [Benchmark]
    public void Link1()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find(key1);
        }
    }

    [Benchmark]
    public void Link2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find(key2);
        }
    }

    [Benchmark]
    public void Link4()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find(key4);
        }
    }

    [Benchmark]
    public void Link8()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find(key8);
        }
    }

    [Benchmark]
    public void LinkB1()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find2(key1);
        }
    }

    [Benchmark]
    public void LinkB2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find2(key2);
        }
    }

    [Benchmark]
    public void LinkB4()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find2(key4);
        }
    }

    [Benchmark]
    public void LinkB8()
    {
        for (var i = 0; i < N; i++)
        {
            _ = linkContainer.Find2(key8);
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

    public object? Find2(Type type)
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
