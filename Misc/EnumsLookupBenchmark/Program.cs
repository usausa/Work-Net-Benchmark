namespace EnumsLookupBenchmark;

using System;
using System.Collections.Frozen;
using System.Collections.Generic;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

// Smart.Enums<T> holds Dictionary<string, T> NameToValues as a fast path, falling back to
// Enum.Parse / Enum.TryParse (which also accepts numeric strings and flag combinations).
// Three open questions from the checklist, one benchmark group each:
//
//   Q1 : is a ReadOnlySpan<char> overload worth adding?  StringDict / SpanToStringDict / SpanAlternateDict
//   Q2 : Dictionary vs FrozenDictionary on the hit path? StringDict vs StringFrozen, SpanAlternate* pair
//   Q3 : does (T)Enum.Parse(Type, name) really box?      ParseBoxing vs ParseGeneric
//
// One operation = one full pass over every member name of the enum.
public static class Program
{
    public static void Main()
    {
        Verify();
        BenchmarkRunner.Run<Benchmark>();
    }

    private static void Verify()
    {
        var failures = 0;
        failures += VerifyOne<E4>();
        failures += VerifyOne<E16>();
        failures += VerifyOne<E64>();

        Console.WriteLine(failures == 0 ? "verify: OK" : $"verify: {failures} FAILURES");
        Console.WriteLine();
    }

    private static int VerifyOne<T>()
        where T : struct, Enum
    {
        var failures = 0;
        var probe = Probe<T>.ProbeNames;
        for (var i = 0; i < probe.Length; i++)
        {
            var name = probe[i];
            if (ReferenceEquals(name, String.IsInterned(name)))
            {
                Console.WriteLine($"FAIL interned: {typeof(T).Name} '{name}'");
                failures++;
            }

            var found = Probe<T>.Dict.TryGetValue(name, out var d);
            found &= Probe<T>.Frozen.TryGetValue(name, out var f);
            found &= Probe<T>.DictAlt.TryGetValue(name.AsSpan(), out var da);
            found &= Probe<T>.FrozenAlt.TryGetValue(name.AsSpan(), out var fa);
            found &= Enum.TryParse<T>(name.AsSpan(), out var b);

            var expected = Probe<T>.Values[i];
            if (!found || !d.Equals(expected) || !f.Equals(expected) || !da.Equals(expected) || !fa.Equals(expected) || !b.Equals(expected))
            {
                Console.WriteLine($"FAIL {typeof(T).Name} '{name}': found={found} dict={d} frozen={f} dictAlt={da} frozenAlt={fa} bcl={b}");
                failures++;
            }

            // The two fallback forms must agree as well. The non-generic overload is the thing being
            // measured, so it is called through a Type variable rather than typeof(T) inline.
            var enumType = typeof(T);
            var boxed = (T)Enum.Parse(enumType, name);
            var generic = Enum.Parse<T>(name);
            if (!boxed.Equals(expected) || !generic.Equals(expected))
            {
                Console.WriteLine($"FAIL {typeof(T).Name} parse '{name}': boxed={boxed} generic={generic}");
                failures++;
            }
        }

        return failures;
    }
}

// Mirrors how Enums<T> builds its lookup, plus the alternate-lookup and frozen variants.
internal static class Probe<T>
    where T : struct, Enum
{
    public static readonly T[] Values = Enum.GetValues<T>();

    public static readonly string[] Names = Enum.GetNames<T>();

    // A caller receives runtime strings, never the interned literals baked into the enum metadata.
    public static readonly string[] ProbeNames;

    public static readonly Dictionary<string, T> Dict;

    public static readonly FrozenDictionary<string, T> Frozen;

    public static readonly Dictionary<string, T>.AlternateLookup<ReadOnlySpan<char>> DictAlt;

    public static readonly FrozenDictionary<string, T>.AlternateLookup<ReadOnlySpan<char>> FrozenAlt;

    static Probe()
    {
        Dict = new Dictionary<string, T>(Values.Length);
        for (var i = 0; i < Values.Length; i++)
        {
            Dict[Names[i]] = Values[i];
        }

        Frozen = Dict.ToFrozenDictionary();
        DictAlt = Dict.GetAlternateLookup<ReadOnlySpan<char>>();
        FrozenAlt = Frozen.GetAlternateLookup<ReadOnlySpan<char>>();

        ProbeNames = new string[Names.Length];
        for (var i = 0; i < Names.Length; i++)
        {
            ProbeNames[i] = new string(Names[i].AsSpan());
        }
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

public enum EnumSize
{
    Members4,
    Members16,
    Members64
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int N = 10_000;

    [Params(EnumSize.Members4, EnumSize.Members16, EnumSize.Members64)]
    public EnumSize Size { get; set; }

    //--------------------------------------------------------------------------------
    // Q1 / Q2 : lookup strategies
    //--------------------------------------------------------------------------------

    // Today's API: the caller already holds a string.
    [Benchmark(Baseline = true, OperationsPerInvoke = N)]
    public int StringDict() => Size switch
    {
        EnumSize.Members4 => LoopStringDict<E4>(),
        EnumSize.Members16 => LoopStringDict<E16>(),
        _ => LoopStringDict<E64>()
    };

    [Benchmark(OperationsPerInvoke = N)]
    public int StringFrozen() => Size switch
    {
        EnumSize.Members4 => LoopStringFrozen<E4>(),
        EnumSize.Members16 => LoopStringFrozen<E16>(),
        _ => LoopStringFrozen<E64>()
    };

    // What a span-holding caller must do today: materialise a string first.
    [Benchmark(OperationsPerInvoke = N)]
    public int SpanToStringDict() => Size switch
    {
        EnumSize.Members4 => LoopSpanToStringDict<E4>(),
        EnumSize.Members16 => LoopSpanToStringDict<E16>(),
        _ => LoopSpanToStringDict<E64>()
    };

    // The proposed overload.
    [Benchmark(OperationsPerInvoke = N)]
    public int SpanAlternateDict() => Size switch
    {
        EnumSize.Members4 => LoopSpanAlternateDict<E4>(),
        EnumSize.Members16 => LoopSpanAlternateDict<E16>(),
        _ => LoopSpanAlternateDict<E64>()
    };

    [Benchmark(OperationsPerInvoke = N)]
    public int SpanAlternateFrozen() => Size switch
    {
        EnumSize.Members4 => LoopSpanAlternateFrozen<E4>(),
        EnumSize.Members16 => LoopSpanAlternateFrozen<E16>(),
        _ => LoopSpanAlternateFrozen<E64>()
    };

    // Reference: the BCL span overload with no dictionary at all.
    [Benchmark(OperationsPerInvoke = N)]
    public int SpanBcl() => Size switch
    {
        EnumSize.Members4 => LoopSpanBcl<E4>(),
        EnumSize.Members16 => LoopSpanBcl<E16>(),
        _ => LoopSpanBcl<E64>()
    };

    //--------------------------------------------------------------------------------
    // Q3 : the ParseValue fallback
    //--------------------------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public int ParseBoxing() => Size switch
    {
        EnumSize.Members4 => LoopParseBoxing<E4>(),
        EnumSize.Members16 => LoopParseBoxing<E16>(),
        _ => LoopParseBoxing<E64>()
    };

    [Benchmark(OperationsPerInvoke = N)]
    public int ParseGeneric() => Size switch
    {
        EnumSize.Members4 => LoopParseGeneric<E4>(),
        EnumSize.Members16 => LoopParseGeneric<E16>(),
        _ => LoopParseGeneric<E64>()
    };

    //--------------------------------------------------------------------------------
    // Loops
    //--------------------------------------------------------------------------------

    private static int LoopStringDict<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                if (Probe<T>.Dict.TryGetValue(probe[i], out _))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static int LoopStringFrozen<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                if (Probe<T>.Frozen.TryGetValue(probe[i], out _))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static int LoopSpanToStringDict<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                var span = probe[i].AsSpan();
                if (Probe<T>.Dict.TryGetValue(span.ToString(), out _))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static int LoopSpanAlternateDict<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                if (Probe<T>.DictAlt.TryGetValue(probe[i].AsSpan(), out _))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static int LoopSpanAlternateFrozen<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                if (Probe<T>.FrozenAlt.TryGetValue(probe[i].AsSpan(), out _))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static int LoopSpanBcl<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                if (Enum.TryParse<T>(probe[i].AsSpan(), out _))
                {
                    total++;
                }
            }
        }

        return total;
    }

    private static int LoopParseBoxing<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        var type = typeof(T);
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += ((T)Enum.Parse(type, probe[i])).GetHashCode();
            }
        }

        return total;
    }

    private static int LoopParseGeneric<T>()
        where T : struct, Enum
    {
        var total = 0;
        var probe = Probe<T>.ProbeNames;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += Enum.Parse<T>(probe[i]).GetHashCode();
            }
        }

        return total;
    }
}
#pragma warning restore CA1822

public enum E4
{
    None = 0,
    Created = 1,
    Updated = 2,
    Deleted = 3,
}

public enum E16
{
    None = 0,
    Created = 1,
    Updated = 2,
    Deleted = 3,
    Archived = 4,
    Pending = 5,
    Approved = 6,
    Rejected = 7,
    Cancelled = 8,
    Expired = 9,
    Suspended = 10,
    Completed = 11,
    Draft = 12,
    Review = 13,
    Published = 14,
    Retired = 15,
}

public enum E64
{
    None = 0,
    Created = 1,
    Updated = 2,
    Deleted = 3,
    Archived = 4,
    Pending = 5,
    Approved = 6,
    Rejected = 7,
    Cancelled = 8,
    Expired = 9,
    Suspended = 10,
    Completed = 11,
    Draft = 12,
    Review = 13,
    Published = 14,
    Retired = 15,
    Queued = 16,
    Running = 17,
    Paused = 18,
    Stopped = 19,
    Failed = 20,
    Succeeded = 21,
    Skipped = 22,
    Timeout = 23,
    Blocked = 24,
    Unblocked = 25,
    Locked = 26,
    Unlocked = 27,
    Verified = 28,
    Unverified = 29,
    Migrated = 30,
    Purged = 31,
    Alpha = 32,
    Beta = 33,
    Gamma = 34,
    Delta = 35,
    Epsilon = 36,
    Zeta = 37,
    Eta = 38,
    Theta = 39,
    Iota = 40,
    Kappa = 41,
    Lambda = 42,
    Mu = 43,
    Nu = 44,
    Xi = 45,
    Omicron = 46,
    Pi = 47,
    Rho = 48,
    Sigma = 49,
    Tau = 50,
    Upsilon = 51,
    Phi = 52,
    Chi = 53,
    Psi = 54,
    Omega = 55,
    First = 56,
    Second = 57,
    Third = 58,
    Fourth = 59,
    Fifth = 60,
    Sixth = 61,
    Seventh = 62,
    Eighth = 63,
}
