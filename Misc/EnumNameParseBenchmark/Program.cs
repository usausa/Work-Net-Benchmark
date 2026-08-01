namespace EnumNameParseBenchmark;

using System;
using System.Runtime.CompilerServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

// Smart.AspNetCore / AmazonLambdaExtension / AzureFunctionsExtension all bind enum parameters through
// DefaultStringConverter.ToEnum/TryToEnum, which is:
//
//     Enum.TryParse<T>(ReadOnlySpan<char> value, ignoreCase: true, out result)
//
// The source generators know the concrete enum type, so they could emit a specialised parser instead.
// The question is whether anything beats the BCL span overload:
//
//   Bcl         : Enum.TryParse<T>(span, ignoreCase: true, out T)   - the current implementation
//   EqualsChain : a chain of value.Equals("Name", OrdinalIgnoreCase)
//   HashSwitch  : sampling hash (length + 3 sampled chars, upper-cased) then Equals to verify
//
// ignoreCase: true rules out a plain span switch, which would be Ordinal and change behaviour.
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

        failures += VerifyE4();
        failures += VerifyE12();
        failures += VerifyE32();

        Console.WriteLine(failures == 0 ? "verify: OK" : $"verify: {failures} FAILURES");
        Console.WriteLine();
    }

    private static int VerifyE4()
    {
        var failures = 0;
        var names = Benchmark.CopyNames(EnumParsers.NamesE4);
        for (var i = 0; i < names.Length; i++)
        {
            if (ReferenceEquals(names[i], String.IsInterned(names[i])))
            {
                Console.WriteLine($"FAIL interned: E4 '{names[i]}'");
                failures++;
            }

            Enum.TryParse<E4>(names[i], ignoreCase: true, out var bcl);
            EnumParsers.TryEqualsE4(names[i], out var chain);
            EnumParsers.TryHashE4(names[i], out var hash);
            if ((bcl != (E4)i) || (chain != (E4)i) || (hash != (E4)i))
            {
                Console.WriteLine($"FAIL E4 '{names[i]}': bcl={bcl} chain={chain} hash={hash}");
                failures++;
            }
        }

        // Lower case input must still resolve, and an unknown name must fail in all three
        if (!EnumParsers.TryEqualsE4("normal", out _) || !EnumParsers.TryHashE4("normal", out _))
        {
            Console.WriteLine($"FAIL E4 ignore-case (members={names.Length})");
            failures++;
        }

        if (EnumParsers.TryEqualsE4("Nope", out _) || EnumParsers.TryHashE4("Nope", out _) || EnumParsers.TryHashE4(String.Empty, out _))
        {
            Console.WriteLine($"FAIL E4 miss handling (members={names.Length})");
            failures++;
        }

        return failures;
    }

    private static int VerifyE12()
    {
        var failures = 0;
        var names = Benchmark.CopyNames(EnumParsers.NamesE12);
        for (var i = 0; i < names.Length; i++)
        {
            Enum.TryParse<E12>(names[i], ignoreCase: true, out var bcl);
            EnumParsers.TryEqualsE12(names[i], out var chain);
            EnumParsers.TryHashE12(names[i], out var hash);
            if ((bcl != (E12)i) || (chain != (E12)i) || (hash != (E12)i))
            {
                Console.WriteLine($"FAIL E12 '{names[i]}': bcl={bcl} chain={chain} hash={hash}");
                failures++;
            }
        }

        return failures;
    }

    private static int VerifyE32()
    {
        var failures = 0;
        var names = Benchmark.CopyNames(EnumParsers.NamesE32);
        for (var i = 0; i < names.Length; i++)
        {
            Enum.TryParse<E32>(names[i], ignoreCase: true, out var bcl);
            EnumParsers.TryEqualsE32(names[i], out var chain);
            EnumParsers.TryHashE32(names[i], out var hash);
            if ((bcl != (E32)i) || (chain != (E32)i) || (hash != (E32)i))
            {
                Console.WriteLine($"FAIL E32 '{names[i]}': bcl={bcl} chain={chain} hash={hash}");
                failures++;
            }
        }

        return failures;
    }
}

// Length + first/middle/last character, upper-cased so it matches OrdinalIgnoreCase semantics.
public static class SamplingHash
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Calculate(ReadOnlySpan<char> value)
    {
        var length = value.Length;
        return (length << 16) ^
               (Char.ToUpperInvariant(value[0]) << 8) ^
               (Char.ToUpperInvariant(value[length >> 1]) << 4) ^
               Char.ToUpperInvariant(value[length - 1]);
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
    Members12,
    Members32
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int N = 10_000;

    private string[] names = default!;

    [Params(EnumSize.Members4, EnumSize.Members12, EnumSize.Members32)]
    public EnumSize Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        names = CopyNames(Size switch
        {
            EnumSize.Members4 => EnumParsers.NamesE4,
            EnumSize.Members12 => EnumParsers.NamesE12,
            _ => EnumParsers.NamesE32
        });
    }

    // A real binder receives a runtime string from the request, never the interned literal.
    public static string[] CopyNames(string[] source)
    {
        var result = new string[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            result[i] = new string(source[i].AsSpan());
        }

        return result;
    }

    [Benchmark(Baseline = true, OperationsPerInvoke = N)]
    public int Bcl() => Size switch
    {
        EnumSize.Members4 => LoopBclE4(),
        EnumSize.Members12 => LoopBclE12(),
        _ => LoopBclE32()
    };

    [Benchmark(OperationsPerInvoke = N)]
    public int EqualsChain() => Size switch
    {
        EnumSize.Members4 => LoopEqualsE4(),
        EnumSize.Members12 => LoopEqualsE12(),
        _ => LoopEqualsE32()
    };

    [Benchmark(OperationsPerInvoke = N)]
    public int HashSwitch() => Size switch
    {
        EnumSize.Members4 => LoopHashE4(),
        EnumSize.Members12 => LoopHashE12(),
        _ => LoopHashE32()
    };

    private int LoopBclE4()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                Enum.TryParse<E4>(probe[i], ignoreCase: true, out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopBclE12()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                Enum.TryParse<E12>(probe[i], ignoreCase: true, out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopBclE32()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                Enum.TryParse<E32>(probe[i], ignoreCase: true, out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopEqualsE4()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                EnumParsers.TryEqualsE4(probe[i], out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopEqualsE12()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                EnumParsers.TryEqualsE12(probe[i], out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopEqualsE32()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                EnumParsers.TryEqualsE32(probe[i], out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopHashE4()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                EnumParsers.TryHashE4(probe[i], out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopHashE12()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                EnumParsers.TryHashE12(probe[i], out var r);
                total += (int)r;
            }
        }

        return total;
    }

    private int LoopHashE32()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                EnumParsers.TryHashE32(probe[i], out var r);
                total += (int)r;
            }
        }

        return total;
    }
}
#pragma warning restore CA1822

public enum E4
{
    None = 0,
    Low = 1,
    Normal = 2,
    High = 3,
}

public enum E12
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
}

public enum E32
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
}

public static class EnumParsers
{
    public static readonly string[] NamesE4 = ["None", "Low", "Normal", "High"];

    public static bool TryEqualsE4(ReadOnlySpan<char> value, out E4 result)
    {
        if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
        {
            result = E4.None;
            return true;
        }

        if (value.Equals("Low", StringComparison.OrdinalIgnoreCase))
        {
            result = E4.Low;
            return true;
        }

        if (value.Equals("Normal", StringComparison.OrdinalIgnoreCase))
        {
            result = E4.Normal;
            return true;
        }

        if (value.Equals("High", StringComparison.OrdinalIgnoreCase))
        {
            result = E4.High;
            return true;
        }

        result = default;
        return false;
    }

    public static bool TryHashE4(ReadOnlySpan<char> value, out E4 result)
    {
        if (!value.IsEmpty)
        {
            switch (SamplingHash.Calculate(value))
            {
                case 215207:
                    if (value.Equals("Low", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E4.Low;
                        return true;
                    }

                    break;
                case 281253:
                    if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E4.None;
                        return true;
                    }

                    break;
                case 281656:
                    if (value.Equals("High", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E4.High;
                        return true;
                    }

                    break;
                case 412316:
                    if (value.Equals("Normal", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E4.Normal;
                        return true;
                    }

                    break;
                default:
                    break;
            }
        }

        result = default;
        return false;
    }

    public static readonly string[] NamesE12 = ["None", "Created", "Updated", "Deleted", "Archived", "Pending", "Approved", "Rejected", "Cancelled", "Expired", "Suspended", "Completed"];

    public static bool TryEqualsE12(ReadOnlySpan<char> value, out E12 result)
    {
        if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.None;
            return true;
        }

        if (value.Equals("Created", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Created;
            return true;
        }

        if (value.Equals("Updated", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Updated;
            return true;
        }

        if (value.Equals("Deleted", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Deleted;
            return true;
        }

        if (value.Equals("Archived", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Archived;
            return true;
        }

        if (value.Equals("Pending", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Pending;
            return true;
        }

        if (value.Equals("Approved", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Approved;
            return true;
        }

        if (value.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Rejected;
            return true;
        }

        if (value.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Cancelled;
            return true;
        }

        if (value.Equals("Expired", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Expired;
            return true;
        }

        if (value.Equals("Suspended", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Suspended;
            return true;
        }

        if (value.Equals("Completed", StringComparison.OrdinalIgnoreCase))
        {
            result = E12.Completed;
            return true;
        }

        result = default;
        return false;
    }

    public static bool TryHashE12(ReadOnlySpan<char> value, out E12 result)
    {
        if (!value.IsEmpty)
        {
            switch (SamplingHash.Calculate(value))
            {
                case 281253:
                    if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.None;
                        return true;
                    }

                    break;
                case 475156:
                    if (value.Equals("Deleted", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Deleted;
                        return true;
                    }

                    break;
                case 475604:
                    if (value.Equals("Expired", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Expired;
                        return true;
                    }

                    break;
                case 477012:
                    if (value.Equals("Created", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Created;
                        return true;
                    }

                    break;
                case 479572:
                    if (value.Equals("Updated", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Updated;
                        return true;
                    }

                    break;
                case 480263:
                    if (value.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Pending;
                        return true;
                    }

                    break;
                case 542132:
                    if (value.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Approved;
                        return true;
                    }

                    break;
                case 542164:
                    if (value.Equals("Archived", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Archived;
                        return true;
                    }

                    break;
                case 546420:
                    if (value.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Rejected;
                        return true;
                    }

                    break;
                case 608020:
                    if (value.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Cancelled;
                        return true;
                    }

                    break;
                case 608132:
                    if (value.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Completed;
                        return true;
                    }

                    break;
                case 612116:
                    if (value.Equals("Suspended", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E12.Suspended;
                        return true;
                    }

                    break;
                default:
                    break;
            }
        }

        result = default;
        return false;
    }

    public static readonly string[] NamesE32 = ["None", "Created", "Updated", "Deleted", "Archived", "Pending", "Approved", "Rejected", "Cancelled", "Expired", "Suspended", "Completed", "Draft", "Review", "Published", "Retired", "Queued", "Running", "Paused", "Stopped", "Failed", "Succeeded", "Skipped", "Timeout", "Blocked", "Unblocked", "Locked", "Unlocked", "Verified", "Unverified", "Migrated", "Purged"];

    public static bool TryEqualsE32(ReadOnlySpan<char> value, out E32 result)
    {
        if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.None;
            return true;
        }

        if (value.Equals("Created", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Created;
            return true;
        }

        if (value.Equals("Updated", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Updated;
            return true;
        }

        if (value.Equals("Deleted", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Deleted;
            return true;
        }

        if (value.Equals("Archived", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Archived;
            return true;
        }

        if (value.Equals("Pending", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Pending;
            return true;
        }

        if (value.Equals("Approved", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Approved;
            return true;
        }

        if (value.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Rejected;
            return true;
        }

        if (value.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Cancelled;
            return true;
        }

        if (value.Equals("Expired", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Expired;
            return true;
        }

        if (value.Equals("Suspended", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Suspended;
            return true;
        }

        if (value.Equals("Completed", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Completed;
            return true;
        }

        if (value.Equals("Draft", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Draft;
            return true;
        }

        if (value.Equals("Review", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Review;
            return true;
        }

        if (value.Equals("Published", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Published;
            return true;
        }

        if (value.Equals("Retired", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Retired;
            return true;
        }

        if (value.Equals("Queued", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Queued;
            return true;
        }

        if (value.Equals("Running", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Running;
            return true;
        }

        if (value.Equals("Paused", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Paused;
            return true;
        }

        if (value.Equals("Stopped", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Stopped;
            return true;
        }

        if (value.Equals("Failed", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Failed;
            return true;
        }

        if (value.Equals("Succeeded", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Succeeded;
            return true;
        }

        if (value.Equals("Skipped", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Skipped;
            return true;
        }

        if (value.Equals("Timeout", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Timeout;
            return true;
        }

        if (value.Equals("Blocked", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Blocked;
            return true;
        }

        if (value.Equals("Unblocked", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Unblocked;
            return true;
        }

        if (value.Equals("Locked", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Locked;
            return true;
        }

        if (value.Equals("Unlocked", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Unlocked;
            return true;
        }

        if (value.Equals("Verified", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Verified;
            return true;
        }

        if (value.Equals("Unverified", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Unverified;
            return true;
        }

        if (value.Equals("Migrated", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Migrated;
            return true;
        }

        if (value.Equals("Purged", StringComparison.OrdinalIgnoreCase))
        {
            result = E32.Purged;
            return true;
        }

        result = default;
        return false;
    }

    public static bool TryHashE32(ReadOnlySpan<char> value, out E32 result)
    {
        if (!value.IsEmpty)
        {
            switch (SamplingHash.Calculate(value))
            {
                case 281253:
                    if (value.Equals("None", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.None;
                        return true;
                    }

                    break;
                case 344132:
                    if (value.Equals("Draft", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Draft;
                        return true;
                    }

                    break;
                case 410244:
                    if (value.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Failed;
                        return true;
                    }

                    break;
                case 411892:
                    if (value.Equals("Locked", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Locked;
                        return true;
                    }

                    break;
                case 414740:
                    if (value.Equals("Queued", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Queued;
                        return true;
                    }

                    break;
                case 414772:
                    if (value.Equals("Purged", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Purged;
                        return true;
                    }

                    break;
                case 415092:
                    if (value.Equals("Paused", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Paused;
                        return true;
                    }

                    break;
                case 415431:
                    if (value.Equals("Review", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Review;
                        return true;
                    }

                    break;
                case 475156:
                    if (value.Equals("Deleted", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Deleted;
                        return true;
                    }

                    break;
                case 475604:
                    if (value.Equals("Expired", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Expired;
                        return true;
                    }

                    break;
                case 476788:
                    if (value.Equals("Blocked", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Blocked;
                        return true;
                    }

                    break;
                case 477012:
                    if (value.Equals("Created", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Created;
                        return true;
                    }

                    break;
                case 479236:
                    if (value.Equals("Timeout", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Timeout;
                        return true;
                    }

                    break;
                case 479572:
                    if (value.Equals("Updated", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Updated;
                        return true;
                    }

                    break;
                case 480263:
                    if (value.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Pending;
                        return true;
                    }

                    break;
                case 480836:
                    if (value.Equals("Stopped", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Stopped;
                        return true;
                    }

                    if (value.Equals("Skipped", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Skipped;
                        return true;
                    }

                    break;
                case 480935:
                    if (value.Equals("Running", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Running;
                        return true;
                    }

                    break;
                case 480980:
                    if (value.Equals("Retired", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Retired;
                        return true;
                    }

                    break;
                case 542132:
                    if (value.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Approved;
                        return true;
                    }

                    break;
                case 542164:
                    if (value.Equals("Archived", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Archived;
                        return true;
                    }

                    break;
                case 543060:
                    if (value.Equals("Migrated", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Migrated;
                        return true;
                    }

                    break;
                case 545140:
                    if (value.Equals("Unlocked", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Unlocked;
                        return true;
                    }

                    break;
                case 545316:
                    if (value.Equals("Verified", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Verified;
                        return true;
                    }

                    break;
                case 546420:
                    if (value.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Rejected;
                        return true;
                    }

                    break;
                case 608020:
                    if (value.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Cancelled;
                        return true;
                    }

                    break;
                case 608132:
                    if (value.Equals("Completed", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Completed;
                        return true;
                    }

                    break;
                case 610740:
                    if (value.Equals("Unblocked", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Unblocked;
                        return true;
                    }

                    break;
                case 611540:
                    if (value.Equals("Published", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Published;
                        return true;
                    }

                    break;
                case 612116:
                    if (value.Equals("Suspended", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Suspended;
                        return true;
                    }

                    if (value.Equals("Succeeded", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Succeeded;
                        return true;
                    }

                    break;
                case 676308:
                    if (value.Equals("Unverified", StringComparison.OrdinalIgnoreCase))
                    {
                        result = E32.Unverified;
                        return true;
                    }

                    break;
                default:
                    break;
            }
        }

        result = default;
        return false;
    }
}
