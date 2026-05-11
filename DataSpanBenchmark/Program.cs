namespace DataSpanBenchmark;

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
        BenchmarkRunner.Run<IsMatchColumnBenchmark>();
        BenchmarkRunner.Run<CalcNameHashBenchmark>();
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

// ---------------------------------------------------------------------------
// IsMatchColumn
// ---------------------------------------------------------------------------

#pragma warning disable CA1051
#pragma warning disable CA1815
public struct ColumnInfo
{
    public string Name;

    public Type Type;
}
#pragma warning restore CA1815
#pragma warning restore CA1051

[Config(typeof(BenchmarkConfig))]
public class IsMatchColumnBenchmark
{
    [Params(1, 2, 5, 10, 20)]
    public int ColumnCount { get; set; }

    private ColumnInfo[] columns1 = default!;
    private ColumnInfo[] columns2 = default!;

    [GlobalSetup]
    public void Setup()
    {
        columns1 = new ColumnInfo[ColumnCount];
        columns2 = new ColumnInfo[ColumnCount];
        for (var i = 0; i < ColumnCount; i++)
        {
            var name = $"Column{i:D2}";
            var type = typeof(int);
            columns1[i] = new ColumnInfo { Name = name, Type = type };
            columns2[i] = new ColumnInfo { Name = name, Type = type };
        }
    }

    [Benchmark(Baseline = true)]
    public bool Indexer() => IsMatchColumnIndexer(columns1, columns2);

    [Benchmark]
    public bool GetRef() => IsMatchColumnGetRef(columns1, columns2);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static bool IsMatchColumnIndexer(ReadOnlySpan<ColumnInfo> cached, ReadOnlySpan<ColumnInfo> current)
    {
        if (cached.Length != current.Length)
        {
            return false;
        }

        for (var i = 0; i < cached.Length; i++)
        {
            ref readonly var column1 = ref cached[i];
            ref readonly var column2 = ref current[i];

            if ((column1.Type != column2.Type) || !String.Equals(column1.Name, column2.Name, StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static bool IsMatchColumnGetRef(ReadOnlySpan<ColumnInfo> cached, ReadOnlySpan<ColumnInfo> current)
    {
        if (cached.Length != current.Length)
        {
            return false;
        }

        ref var head1 = ref MemoryMarshal.GetReference(cached);
        ref var head2 = ref MemoryMarshal.GetReference(current);
        for (var i = 0; i < cached.Length; i++)
        {
            ref readonly var column1 = ref Unsafe.Add(ref head1, i);
            ref readonly var column2 = ref Unsafe.Add(ref head2, i);

            if ((column1.Type != column2.Type) || !String.Equals(column1.Name, column2.Name, StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }
}

// ---------------------------------------------------------------------------
// CalcNameHash
// ---------------------------------------------------------------------------

[Config(typeof(BenchmarkConfig))]
public class CalcNameHashBenchmark
{
    [Params(1, 4, 8, 16, 32)]
    public int NameLength { get; set; }

    private string columnName = default!;

    [GlobalSetup]
    public void Setup()
    {
        columnName = new string('A', NameLength);
    }

    [Benchmark(Baseline = true)]
    public int Indexer() => CalcNameHashIndexer(columnName.AsSpan());

    [Benchmark]
    public int GetRef() => CalcNameHashGetRef(columnName.AsSpan());

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static int CalcNameHashIndexer(ReadOnlySpan<char> value)
    {
        unchecked
        {
            var hash = 2166136261u;
            for (var i = 0; i < value.Length; i++)
            {
                hash = (value[i] ^ hash) * 16777619;
            }
            return (int)hash;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static int CalcNameHashGetRef(ReadOnlySpan<char> value)
    {
        unchecked
        {
            var hash = 2166136261u;
            ref var head = ref MemoryMarshal.GetReference(value);
            for (var i = 0; i < value.Length; i++)
            {
                hash = (Unsafe.Add(ref head, i) ^ hash) * 16777619;
            }
            return (int)hash;
        }
    }
}
