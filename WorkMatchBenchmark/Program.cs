namespace WorkMatchBenchmark;

using System;
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
        //var names = new[] { "Id", "Name", "Flag", "Value1", "Value1", "CreateAt" };
        //var types = new[] { typeof(int), typeof(string), typeof(bool), typeof(string), typeof(long), typeof(DateTime) };
        //var reader = new Reader(names, types);
        //var matcher = new Matcher(names, types);

        //var b1 = matcher.ByThreadStaticUnsafe(reader);
        //var b2 = matcher.ByThreadStaticRefLoop(reader);

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

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 10_0000;

    private Matcher matcher = default!;

    private Reader reader = default!;

    [IterationSetup]
    public void Setup()
    {
        var names = new[] { "Id", "Name", "Flag", "Value1", "Value1", "CreateAt" };
        var types = new[] { typeof(int), typeof(string), typeof(bool), typeof(string), typeof(long), typeof(DateTime) };
        reader = new Reader(names, types);
        matcher = new Matcher(names, types);
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ByThreadStaticUnsafe()
    {
        for (var i = 0; i < N; i++)
        {
            _ = matcher.ByThreadStaticUnsafe(reader);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ByThreadStaticUnsafe2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = matcher.ByThreadStaticUnsafe2(reader);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ByThreadStaticRefLoop()
    {
        for (var i = 0; i < N; i++)
        {
            _ = matcher.ByThreadStaticRefLoop(reader);
        }
    }

    // [MEMO] Best?

    [Benchmark(OperationsPerInvoke = N)]
    public void ByThreadStaticRefLoop2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = matcher.ByThreadStaticRefLoop2(reader);
        }
    }

    //[Benchmark(OperationsPerInvoke = N)]
    //public void ByAllocRefLoop2()
    //{
    //    for (var i = 0; i < N; i++)
    //    {
    //        _ = matcher.ByAllocRefLoop2(reader);
    //    }
    //}
}

public sealed class Matcher
{
    [ThreadStatic]
    private static ColumnInfo[]? columnInfoPool;

    private ColumnInfo[] columns;

    public Matcher(string[] names, Type[] types)
    {
        columns = new ColumnInfo[names.Length];
        for (var i = 0; i < names.Length; i++)
        {
            columns[i] = new ColumnInfo(names[i], types[i]);
        }
        columnInfoPool = new ColumnInfo[16];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int CalcNameHash(string value)
    {
        unchecked
        {
            var hash = 2166136261u;
            foreach (var c in value)
            {
                hash = (c ^ hash) * 16777619;
            }
            return (int)hash;
        }
    }

    //--------------------------------------------------------------------------------

    public bool ByThreadStaticUnsafe(Reader reader)
    {
        var fieldCount = reader.FieldCount;
        if ((columnInfoPool is null) || (columnInfoPool.Length < fieldCount))
        {
            columnInfoPool = new ColumnInfo[fieldCount];
        }

        var hash = 0;
        for (var i = 0; i < reader.FieldCount; i++)
        {
            var name = reader.GetName(i);
            var fieldType = reader.GetFieldType(i);
            hash = unchecked((hash * 31) + (CalcNameHash(name) ^ fieldType.GetHashCode()));
            columnInfoPool[i] = new ColumnInfo(name, fieldType);
        }

        return IsMatchColumnUnsafe(new Span<ColumnInfo>(columnInfoPool, 0, fieldCount), columns);
    }

    public bool ByThreadStaticUnsafe2(Reader reader)
    {
        var fieldCount = reader.FieldCount;
        if ((columnInfoPool is null) || (columnInfoPool.Length < fieldCount))
        {
            columnInfoPool = new ColumnInfo[fieldCount];
        }

        var hash = 0;
        for (var i = 0; i < reader.FieldCount; i++)
        {
            var name = reader.GetName(i);
            var fieldType = reader.GetFieldType(i);
            hash = unchecked((hash * 31) + (CalcNameHash(name) ^ fieldType.GetHashCode()));
            ref var column = ref columnInfoPool[i];
            column.Name = name;
            column.Type = fieldType;
        }

        return IsMatchColumnUnsafe(new Span<ColumnInfo>(columnInfoPool, 0, fieldCount), columns);
    }

    public bool ByThreadStaticRefLoop(Reader reader)
    {
        var fieldCount = reader.FieldCount;
        if ((columnInfoPool is null) || (columnInfoPool.Length < fieldCount))
        {
            columnInfoPool = new ColumnInfo[fieldCount];
        }

        var hash = 0;
        for (var i = 0; i < reader.FieldCount; i++)
        {
            var name = reader.GetName(i);
            var fieldType = reader.GetFieldType(i);
            hash = unchecked((hash * 31) + (CalcNameHash(name) ^ fieldType.GetHashCode()));
            columnInfoPool[i] = new ColumnInfo(name, fieldType);
        }

        return IsMatchColumnRefLoop(ref columnInfoPool, fieldCount, ref columns);
    }

    public bool ByThreadStaticRefLoop2(Reader reader)
    {
        var fieldCount = reader.FieldCount;
        if ((columnInfoPool is null) || (columnInfoPool.Length < fieldCount))
        {
            columnInfoPool = new ColumnInfo[fieldCount];
        }

        var hash = 0;
        for (var i = 0; i < reader.FieldCount; i++)
        {
            var name = reader.GetName(i);
            var fieldType = reader.GetFieldType(i);
            hash = unchecked((hash * 31) + (CalcNameHash(name) ^ fieldType.GetHashCode()));
            ref var column = ref columnInfoPool[i];
            column.Name = name;
            column.Type = fieldType;
        }

        return IsMatchColumnRefLoop(ref columnInfoPool, fieldCount, ref columns);
    }

    public bool ByAllocRefLoop2(Reader reader)
    {
        var fieldCount = reader.FieldCount;
        if (fieldCount > 32)
        {
            return ByThreadStaticRefLoop2(reader);
        }

        var work = new ColumnInfo[fieldCount];

        var hash = 0;
        for (var i = 0; i < reader.FieldCount; i++)
        {
            var name = reader.GetName(i);
            var fieldType = reader.GetFieldType(i);
            hash = unchecked((hash * 31) + (CalcNameHash(name) ^ fieldType.GetHashCode()));
            ref var column = ref work[i];
            column.Name = name;
            column.Type = fieldType;
        }

        return IsMatchColumnRefLoop(ref work, fieldCount, ref columns);
    }

    //--------------------------------------------------------------------------------

#pragma warning disable CA1307
#pragma warning disable CA1309
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsMatchColumnUnsafe(Span<ColumnInfo> columns1, Span<ColumnInfo> columns2)
    {
        var length = columns1.Length;
        if (length != columns2.Length)
        {
            return false;
        }

        ref var column1 = ref MemoryMarshal.GetReference(columns1);
        ref var end = ref Unsafe.Add(ref column1, length);
        ref var column2 = ref MemoryMarshal.GetReference(columns2);

        Compare:
        if ((column1.Type != column2.Type) || !String.Equals(column1.Name, column2.Name))
        {
            return false;
        }

        column1 = ref Unsafe.Add(ref column1, 1);
        if (Unsafe.IsAddressLessThan(ref column1, ref end))
        {
            column2 = ref Unsafe.Add(ref column2, 1);
            goto Compare;
        }

        return true;
    }
#pragma warning restore CA1309
#pragma warning restore CA1307

#pragma warning disable CA1307
#pragma warning disable CA1309
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsMatchColumnRefLoop(ref ColumnInfo[] columns1, int length, ref ColumnInfo[] columns2)
    {
        if (length != columns2.Length)
        {
            return false;
        }

        for (var i = 0; i < length; i++)
        {
            ref var column1 = ref columns1[i];
            ref var column2 = ref columns1[i];

            if ((column1.Type != column2.Type) || !String.Equals(column1.Name, column2.Name))
            {
                return false;
            }
        }

        return true;
    }
#pragma warning restore CA1309
#pragma warning restore CA1307
}

#pragma warning disable CA1051
#pragma warning disable CA1815
public struct ColumnInfo
{
    public string Name;

    public Type Type;

    public ColumnInfo(string name, Type type)
    {
        Name = name;
        Type = type;
    }
}
#pragma warning restore CA1815
#pragma warning restore CA1051

public sealed class Reader
{
    private readonly string[] names;

    private readonly Type[] types;

    public int FieldCount { get; }

    public Reader(string[] names, Type[] types)
    {
        FieldCount = names.Length;
        this.names = names;
        this.types = types;
    }

    public string GetName(int i) => names[i];

    public Type GetFieldType(int i) => types[i];
}
