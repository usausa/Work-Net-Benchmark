namespace ColumnMetadataLookupBenchmark;

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Globalization;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

// Compares the two column-name -> group-index strategies Smart.Data.Accessor can emit, now that the
// FrozenDictionary form is out of the running (it was never fastest at any measured column count):
//
//   Direct : a String.Equals(OrdinalIgnoreCase) chain into per-group locals
//   Switch : a sampling hash (length + 3 sampled chars) switch, hash constants baked in at generation time
//
// Three questions, three benchmark classes:
//   SweepBenchmark     - where does each strategy win across 1..32 columns, and how STABLE is it
//                        across reader shapes? (measurement A - decides whether one uniform strategy works)
//   CollisionBenchmark - what does a degenerate key set cost the switch, and does choosing the sampling
//                        positions at generation time recover it? (measurement B)
//   GuardBenchmark     - what does the empty-column-name guard cost? (measurement C)
//
// All benchmarks reproduce the work of the generated __{Entity}Ordinals.__From(reader): scan the reader's
// columns once, map each name to its group id, record the ordinal, stop when every group is resolved.
public static class Program
{
    public static void Main(string[] args)
    {
        Verify();
        BenchmarkSwitcher.FromTypes([typeof(SweepBenchmark), typeof(CollisionBenchmark), typeof(GuardBenchmark), typeof(ReconcileBenchmark)]).Run(args);
    }

    // Every strategy must return the same ordinal sum for the same reader, and the reader must hand back
    // strings that are not the interned literals the lookups compare against - otherwise String.Equals
    // short-circuits on reference equality and the whole run is meaningless.
    private static void Verify()
    {
        var failures = 0;
        foreach (var shape in new[] { ReaderShape.InOrder, ReaderShape.Reversed, ReaderShape.WideSubset })
        {
            foreach (var columns in new[] { 1, 2, 4, 8, 12, 16, 24, 32 })
            {
                var names = ReaderBuilder.Build(KeySets.NoCollision, columns, shape);
                foreach (var name in names)
                {
                    if (ReferenceEquals(name, String.IsInterned(name)))
                    {
                        Console.WriteLine($"FAIL interned: {shape} {columns} '{name}'");
                        failures++;
                    }
                }

                var direct = SweepDispatch.Direct(names, columns, 1);
                var hash = SweepDispatch.Switch(names, columns, 1);
                if (direct != hash)
                {
                    Console.WriteLine($"FAIL disagree NC {shape} n={columns}: direct={direct} switch={hash}");
                    failures++;
                }
            }

            foreach (var columns in new[] { 12, 32 })
            {
                var names = ReaderBuilder.Build(KeySets.Colliding, columns, shape);
                var direct = CollisionDispatch.Direct(names, columns, 1);
                var fixedHash = CollisionDispatch.SwitchFixed(names, columns, 1);
                var searched = CollisionDispatch.SwitchSearched(names, columns, 1);
                if ((direct != fixedHash) || (direct != searched))
                {
                    Console.WriteLine($"FAIL disagree CO {shape} n={columns}: direct={direct} fixed={fixedHash} searched={searched}");
                    failures++;
                }
            }
        }

        // The guard exists because a provider can return an unnamed column (SQL Server does so for an
        // un-aliased expression). Without it the hash indexes name[0] on an empty string.
        var withEmpty = new[] { String.Empty, new string("id".AsSpan()), String.Empty };
        try
        {
            var guarded = GuardDispatch.Guard(withEmpty, 8, 1);
            Console.WriteLine($"guard OK on empty column name (result={guarded})");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("FAIL: guarded form threw on an empty column name");
            failures++;
        }

        try
        {
            GuardDispatch.NoGuard(withEmpty, 8, 1);
            Console.WriteLine("NOTE: unguarded form survived an empty column name (unexpected)");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("confirmed: unguarded form throws IndexOutOfRangeException on an empty column name");
        }

        Console.WriteLine(failures == 0 ? "verify: OK" : $"verify: {failures} FAILURES");
        Console.WriteLine();
    }
}

public enum ReaderShape
{
    // Declaration order: resolved groups are skipped by a plain int test (Direct's best case).
    InOrder,

    // Forces the full comparison chain on every column.
    Reversed,

    // The reader also returns columns the entity does not map; each runs the whole chain without ever
    // matching (Direct's worst case, and the one a hash lookup handles cheaply).
    WideSubset
}

public static class ReaderBuilder
{
    // A real DbDataReader hands back provider-allocated strings, never the interned literals the generated
    // code compares against, so every name is copied.
    public static string[] Build(string[] keys, int count, ReaderShape shape)
    {
        string[] names;
        if (shape == ReaderShape.WideSubset)
        {
            names = new string[count * 2];
            for (var i = 0; i < count; i++)
            {
                names[i * 2] = "unmapped_column_" + i.ToString(CultureInfo.InvariantCulture);
                names[(i * 2) + 1] = new string(keys[i].AsSpan());
            }
        }
        else
        {
            names = new string[count];
            for (var i = 0; i < count; i++)
            {
                names[i] = new string(keys[i].AsSpan());
            }

            if (shape == ReaderShape.Reversed)
            {
                Array.Reverse(names);
            }
        }

        return names;
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
        AddDiagnoser(MemoryDiagnoser.Default);
    }
}

// Measurement A: the 1..32 sweep. Frozen is the baseline - not because it is a candidate (it never wins)
// but because it is the thing being removed, and it sets the scale: a Direct-vs-Switch gap only matters
// if it is large relative to what replacing Frozen already buys. Ratios alone hide that.
#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class SweepBenchmark
{
    private const int N = 10_000;

    private const int MaxColumns = 32;

    private string[] names = default!;

    private FrozenDictionary<string, int> frozen = default!;

    [Params(1, 2, 4, 8, 12, 16, 24, 32)]
    public int Columns { get; set; }

    [Params(ReaderShape.InOrder, ReaderShape.Reversed, ReaderShape.WideSubset)]
    public ReaderShape Shape { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        names = ReaderBuilder.Build(KeySets.NoCollision, Columns, Shape);
        var pairs = new KeyValuePair<string, int>[Columns];
        for (var i = 0; i < Columns; i++)
        {
            pairs[i] = new KeyValuePair<string, int>(KeySets.NoCollision[i], i);
        }

        frozen = pairs.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }

    [Benchmark(Baseline = true, OperationsPerInvoke = N)]
    public int Frozen()
    {
        var total = 0;
        for (var i = 0; i < N; i++)
        {
            total += ResolveFrozen();
        }

        return total;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int Direct() => SweepDispatch.Direct(names, Columns, N);

    [Benchmark(OperationsPerInvoke = N)]
    public int Switch() => SweepDispatch.Switch(names, Columns, N);

    private int ResolveFrozen()
    {
        Span<int> ordinals = stackalloc int[MaxColumns];
        var count = Columns;
        ordinals = ordinals[..count];
        ordinals.Fill(-1);

        var resolved = 0;
        for (var i = 0; i < names.Length; i++)
        {
            if (frozen.TryGetValue(names[i], out var index) && (ordinals[index] < 0))
            {
                ordinals[index] = i;
                resolved++;
                if (resolved == count)
                {
                    break;
                }
            }
        }

        var sum = 0;
        for (var k = 0; k < ordinals.Length; k++)
        {
            sum += ordinals[k];
        }

        return sum;
    }
}

// Measurement B: a key set that degenerates the fixed first/middle/last hash.
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class CollisionBenchmark
{
    private const int N = 10_000;

    private const int MaxColumns = 32;

    private string[] names = default!;

    private FrozenDictionary<string, int> frozen = default!;

    [Params(12, 32)]
    public int Columns { get; set; }

    [Params(ReaderShape.InOrder, ReaderShape.Reversed, ReaderShape.WideSubset)]
    public ReaderShape Shape { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        names = ReaderBuilder.Build(KeySets.Colliding, Columns, Shape);
        var pairs = new KeyValuePair<string, int>[Columns];
        for (var i = 0; i < Columns; i++)
        {
            pairs[i] = new KeyValuePair<string, int>(KeySets.Colliding[i], i);
        }

        frozen = pairs.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }

    // Same role as in SweepBenchmark: the scale reference, not a candidate.
    [Benchmark(Baseline = true, OperationsPerInvoke = N)]
    public int Frozen()
    {
        var total = 0;
        for (var i = 0; i < N; i++)
        {
            Span<int> ordinals = stackalloc int[MaxColumns];
            var count = Columns;
            ordinals = ordinals[..count];
            ordinals.Fill(-1);
            var resolved = 0;
            for (var i2 = 0; i2 < names.Length; i2++)
            {
                if (frozen.TryGetValue(names[i2], out var index) && (ordinals[index] < 0))
                {
                    ordinals[index] = i2;
                    resolved++;
                    if (resolved == count)
                    {
                        break;
                    }
                }
            }

            for (var k = 0; k < ordinals.Length; k++)
            {
                total += ordinals[k];
            }
        }

        return total;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int Direct() => CollisionDispatch.Direct(names, Columns, N);

    // Fixed first/middle/last: 'item_code/name/note/type/size' all land in one bucket.
    [Benchmark(OperationsPerInvoke = N)]
    public int SwitchFixed() => CollisionDispatch.SwitchFixed(names, Columns, N);

    // Sampling positions chosen at generation time (first/last/e7 here) - collision free.
    [Benchmark(OperationsPerInvoke = N)]
    public int SwitchSearched() => CollisionDispatch.SwitchSearched(names, Columns, N);
}

// Measurement C: what the empty-column-name guard costs.
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class GuardBenchmark
{
    private const int N = 10_000;

    private string[] names = default!;

    [Params(8, 32)]
    public int Columns { get; set; }

    [Params(ReaderShape.InOrder, ReaderShape.WideSubset)]
    public ReaderShape Shape { get; set; }

    [GlobalSetup]
    public void Setup() => names = ReaderBuilder.Build(KeySets.NoCollision, Columns, Shape);

    [Benchmark(Baseline = true, OperationsPerInvoke = N)]
    public int NoGuard() => GuardDispatch.NoGuard(names, Columns, N);

    [Benchmark(OperationsPerInvoke = N)]
    public int Guard() => GuardDispatch.Guard(names, Columns, N);
}
#pragma warning restore CA1822
