namespace PropertyNameSwitchBenchmark;

using System;
using System.Runtime.CompilerServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

// BunnyTail.MemberAccessor generates a plain C# string switch for GetValue/SetValue(name).
// The question is whether replacing it with a sampling-hash switch is worth it - and unlike the DB column
// case, the opponent here is the C# compiler's own lowering, not a FrozenDictionary:
//
//   Compiler : name switch { "Id" => 0, ... }   - Roslyn lowers this to length/char tests for few cases,
//                                                 or ComputeStringHash (FNV-1a over the whole string) plus
//                                                 a jump table and one ordinal Equals for many cases.
//   Hash     : switch (SamplingHash.Calculate(name)) - length + 3 sampled chars, then ordinal Equals to verify.
//
// Property names are matched Ordinal (case sensitive), so neither side needs ToUpperInvariant.
// One operation = one full pass over every name in the set.
public static class Program
{
    public static void Main()
    {
        Verify();
        BenchmarkRunner.Run<Benchmark>();
    }

    // Both strategies must agree, and the probe strings must not be the interned literals the switches
    // compare against - otherwise String.Equals short-circuits on reference equality and the run is invalid.
    private static void Verify()
    {
        var failures = 0;
        foreach (var set in new[] { PropertySet.Small4, PropertySet.Medium12, PropertySet.Large32, PropertySet.Colliding8 })
        {
            var names = Benchmark.BuildProbeNames(set);
            foreach (var name in names)
            {
                if (ReferenceEquals(name, String.IsInterned(name)))
                {
                    Console.WriteLine($"FAIL interned: {set} '{name}'");
                    failures++;
                }
            }

            for (var i = 0; i < names.Length; i++)
            {
                var compiler = Benchmark.MatchCompiler(set, names[i]);
                var hash = Benchmark.MatchHash(set, names[i]);
                if ((compiler != i) || (hash != i))
                {
                    Console.WriteLine($"FAIL {set} '{names[i]}': expected={i} compiler={compiler} hash={hash}");
                    failures++;
                }
            }

            // A name that is not in the set must miss in both
            const string Missing = "NoSuchPropertyName";
            if ((Benchmark.MatchCompiler(set, Missing) != -1) || (Benchmark.MatchHash(set, Missing) != -1))
            {
                Console.WriteLine($"FAIL {set} miss handling");
                failures++;
            }
        }

        Console.WriteLine(failures == 0 ? "verify: OK" : $"verify: {failures} FAILURES");
        Console.WriteLine();
    }
}

public enum PropertySet
{
    Small4,
    Medium12,
    Large32,
    Colliding8
}

// Length + first/middle/last character. Ordinal, so no case folding is needed.
public static class SamplingHash
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Calculate(string value)
    {
        var length = value.Length;
        return (length << 16) ^ (value[0] << 8) ^ (value[length >> 1] << 4) ^ value[length - 1];
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

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int N = 10_000;

    private string[] names = default!;

    [Params(PropertySet.Small4, PropertySet.Medium12, PropertySet.Large32, PropertySet.Colliding8)]
    public PropertySet Set { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        names = BuildProbeNames(Set);
    }

    // A real caller passes a runtime string, never the interned literal baked into the switch.
    public static string[] BuildProbeNames(PropertySet set)
    {
        var source = set switch
        {
            PropertySet.Small4 => NamesS4,
            PropertySet.Medium12 => NamesM12,
            PropertySet.Large32 => NamesL32,
            _ => NamesC8
        };

        var result = new string[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            result[i] = new string(source[i].AsSpan());
        }

        return result;
    }

    public static int MatchCompiler(PropertySet set, string name) => set switch
    {
        PropertySet.Small4 => MatchCompilerS4(name),
        PropertySet.Medium12 => MatchCompilerM12(name),
        PropertySet.Large32 => MatchCompilerL32(name),
        _ => MatchCompilerC8(name)
    };

    public static int MatchHash(PropertySet set, string name) => set switch
    {
        PropertySet.Small4 => MatchHashS4(name),
        PropertySet.Medium12 => MatchHashM12(name),
        PropertySet.Large32 => MatchHashL32(name),
        _ => MatchHashC8(name)
    };

    [Benchmark(Baseline = true, OperationsPerInvoke = N)]
    public int CompilerSwitch() => Set switch
    {
        PropertySet.Small4 => LoopCompilerS4(),
        PropertySet.Medium12 => LoopCompilerM12(),
        PropertySet.Large32 => LoopCompilerL32(),
        _ => LoopCompilerC8()
    };

    [Benchmark(OperationsPerInvoke = N)]
    public int SamplingHashSwitch() => Set switch
    {
        PropertySet.Small4 => LoopHashS4(),
        PropertySet.Medium12 => LoopHashM12(),
        PropertySet.Large32 => LoopHashL32(),
        _ => LoopHashC8()
    };

    private int LoopCompilerS4()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchCompilerS4(probe[i]);
            }
        }

        return total;
    }

    private int LoopCompilerM12()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchCompilerM12(probe[i]);
            }
        }

        return total;
    }

    private int LoopCompilerL32()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchCompilerL32(probe[i]);
            }
        }

        return total;
    }

    private int LoopCompilerC8()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchCompilerC8(probe[i]);
            }
        }

        return total;
    }

    private int LoopHashS4()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchHashS4(probe[i]);
            }
        }

        return total;
    }

    private int LoopHashM12()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchHashM12(probe[i]);
            }
        }

        return total;
    }

    private int LoopHashL32()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchHashL32(probe[i]);
            }
        }

        return total;
    }

    private int LoopHashC8()
    {
        var total = 0;
        var probe = names;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < probe.Length; i++)
            {
                total += MatchHashC8(probe[i]);
            }
        }

        return total;
    }

    private static int MatchCompilerS4(string name) => name switch
    {
        "Id" => 0,
        "Name" => 1,
        "Value" => 2,
        "CreatedAt" => 3,
        _ => -1
    };

    private static int MatchHashS4(string name)
    {
        switch (SamplingHash.Calculate(name))
        {
            case 151332:
                if (name.Equals("Id", StringComparison.Ordinal))
                {
                    return 0;
                }

                return -1;
            case 280757:
                if (name.Equals("Name", StringComparison.Ordinal))
                {
                    return 1;
                }

                return -1;
            case 348325:
                if (name.Equals("Value", StringComparison.Ordinal))
                {
                    return 2;
                }

                return -1;
            case 607284:
                if (name.Equals("CreatedAt", StringComparison.Ordinal))
                {
                    return 3;
                }

                return -1;
            default:
                return -1;
        }
    }

    private static readonly string[] NamesS4 = ["Id", "Name", "Value", "CreatedAt"];

    private static int MatchCompilerM12(string name) => name switch
    {
        "Id" => 0,
        "TenantId" => 1,
        "Name" => 2,
        "DisplayName" => 3,
        "Email" => 4,
        "Age" => 5,
        "IsActive" => 6,
        "IsDeleted" => 7,
        "CreatedAt" => 8,
        "CreatedBy" => 9,
        "UpdatedAt" => 10,
        "Version" => 11,
        _ => -1
    };

    private static int MatchHashM12(string name)
    {
        switch (SamplingHash.Calculate(name))
        {
            case 151332:
                if (name.Equals("Id", StringComparison.Ordinal))
                {
                    return 0;
                }

                return -1;
            case 214805:
                if (name.Equals("Age", StringComparison.Ordinal))
                {
                    return 5;
                }

                return -1;
            case 280757:
                if (name.Equals("Name", StringComparison.Ordinal))
                {
                    return 2;
                }

                return -1;
            case 344956:
                if (name.Equals("Email", StringComparison.Ordinal))
                {
                    return 4;
                }

                return -1;
            case 479582:
                if (name.Equals("Version", StringComparison.Ordinal))
                {
                    return 11;
                }

                return -1;
            case 544293:
                if (name.Equals("IsActive", StringComparison.Ordinal))
                {
                    return 6;
                }

                return -1;
            case 545412:
                if (name.Equals("TenantId", StringComparison.Ordinal))
                {
                    return 1;
                }

                return -1;
            case 607284:
                if (name.Equals("CreatedAt", StringComparison.Ordinal))
                {
                    return 8;
                }

                return -1;
            case 607289:
                if (name.Equals("CreatedBy", StringComparison.Ordinal))
                {
                    return 9;
                }

                return -1;
            case 610212:
                if (name.Equals("IsDeleted", StringComparison.Ordinal))
                {
                    return 7;
                }

                return -1;
            case 610868:
                if (name.Equals("UpdatedAt", StringComparison.Ordinal))
                {
                    return 10;
                }

                return -1;
            case 737909:
                if (name.Equals("DisplayName", StringComparison.Ordinal))
                {
                    return 3;
                }

                return -1;
            default:
                return -1;
        }
    }

    private static readonly string[] NamesM12 = ["Id", "TenantId", "Name", "DisplayName", "Email", "Age", "IsActive", "IsDeleted", "CreatedAt", "CreatedBy", "UpdatedAt", "Version"];

    private static int MatchCompilerL32(string name) => name switch
    {
        "Id" => 0,
        "TenantId" => 1,
        "Name" => 2,
        "DisplayName" => 3,
        "Email" => 4,
        "PhoneNumber" => 5,
        "Age" => 6,
        "BirthDate" => 7,
        "IsActive" => 8,
        "IsDeleted" => 9,
        "StatusCode" => 10,
        "RoleId" => 11,
        "DepartmentId" => 12,
        "ManagerId" => 13,
        "Salary" => 14,
        "Bonus" => 15,
        "AddressLine1" => 16,
        "AddressLine2" => 17,
        "City" => 18,
        "State" => 19,
        "PostalCode" => 20,
        "CountryCode" => 21,
        "Note" => 22,
        "Tags" => 23,
        "CreatedAt" => 24,
        "CreatedBy" => 25,
        "UpdatedAt" => 26,
        "UpdatedBy" => 27,
        "DeletedAt" => 28,
        "DeletedBy" => 29,
        "Version" => 30,
        "RowHash" => 31,
        _ => -1
    };

    private static int MatchHashL32(string name)
    {
        switch (SamplingHash.Calculate(name))
        {
            case 151332:
                if (name.Equals("Id", StringComparison.Ordinal))
                {
                    return 0;
                }

                return -1;
            case 214805:
                if (name.Equals("Age", StringComparison.Ordinal))
                {
                    return 6;
                }

                return -1;
            case 279609:
                if (name.Equals("City", StringComparison.Ordinal))
                {
                    return 18;
                }

                return -1;
            case 280757:
                if (name.Equals("Name", StringComparison.Ordinal))
                {
                    return 2;
                }

                return -1;
            case 280869:
                if (name.Equals("Note", StringComparison.Ordinal))
                {
                    return 22;
                }

                return -1;
            case 283139:
                if (name.Equals("Tags", StringComparison.Ordinal))
                {
                    return 23;
                }

                return -1;
            case 344956:
                if (name.Equals("Email", StringComparison.Ordinal))
                {
                    return 4;
                }

                return -1;
            case 345235:
                if (name.Equals("Bonus", StringComparison.Ordinal))
                {
                    return 15;
                }

                return -1;
            case 349557:
                if (name.Equals("State", StringComparison.Ordinal))
                {
                    return 19;
                }

                return -1;
            case 414772:
                if (name.Equals("RoleId", StringComparison.Ordinal))
                {
                    return 11;
                }

                return -1;
            case 415081:
                if (name.Equals("Salary", StringComparison.Ordinal))
                {
                    return 14;
                }

                return -1;
            case 479582:
                if (name.Equals("Version", StringComparison.Ordinal))
                {
                    return 30;
                }

                return -1;
            case 481000:
                if (name.Equals("RowHash", StringComparison.Ordinal))
                {
                    return 31;
                }

                return -1;
            case 544293:
                if (name.Equals("IsActive", StringComparison.Ordinal))
                {
                    return 8;
                }

                return -1;
            case 545412:
                if (name.Equals("TenantId", StringComparison.Ordinal))
                {
                    return 1;
                }

                return -1;
            case 607028:
                if (name.Equals("DeletedAt", StringComparison.Ordinal))
                {
                    return 28;
                }

                return -1;
            case 607033:
                if (name.Equals("DeletedBy", StringComparison.Ordinal))
                {
                    return 29;
                }

                return -1;
            case 607284:
                if (name.Equals("CreatedAt", StringComparison.Ordinal))
                {
                    return 24;
                }

                return -1;
            case 607289:
                if (name.Equals("CreatedBy", StringComparison.Ordinal))
                {
                    return 25;
                }

                return -1;
            case 607461:
                if (name.Equals("BirthDate", StringComparison.Ordinal))
                {
                    return 7;
                }

                return -1;
            case 609044:
                if (name.Equals("ManagerId", StringComparison.Ordinal))
                {
                    return 13;
                }

                return -1;
            case 610212:
                if (name.Equals("IsDeleted", StringComparison.Ordinal))
                {
                    return 9;
                }

                return -1;
            case 610868:
                if (name.Equals("UpdatedAt", StringComparison.Ordinal))
                {
                    return 26;
                }

                return -1;
            case 610873:
                if (name.Equals("UpdatedBy", StringComparison.Ordinal))
                {
                    return 27;
                }

                return -1;
            case 676949:
                if (name.Equals("StatusCode", StringComparison.Ordinal))
                {
                    return 10;
                }

                return -1;
            case 677541:
                if (name.Equals("PostalCode", StringComparison.Ordinal))
                {
                    return 20;
                }

                return -1;
            case 737909:
                if (name.Equals("DisplayName", StringComparison.Ordinal))
                {
                    return 3;
                }

                return -1;
            case 738373:
                if (name.Equals("CountryCode", StringComparison.Ordinal))
                {
                    return 21;
                }

                return -1;
            case 742546:
                if (name.Equals("PhoneNumber", StringComparison.Ordinal))
                {
                    return 5;
                }

                return -1;
            case 803508:
                if (name.Equals("DepartmentId", StringComparison.Ordinal))
                {
                    return 12;
                }

                return -1;
            case 804353:
                if (name.Equals("AddressLine1", StringComparison.Ordinal))
                {
                    return 16;
                }

                return -1;
            case 804354:
                if (name.Equals("AddressLine2", StringComparison.Ordinal))
                {
                    return 17;
                }

                return -1;
            default:
                return -1;
        }
    }

    private static readonly string[] NamesL32 = ["Id", "TenantId", "Name", "DisplayName", "Email", "PhoneNumber", "Age", "BirthDate", "IsActive", "IsDeleted", "StatusCode", "RoleId", "DepartmentId", "ManagerId", "Salary", "Bonus", "AddressLine1", "AddressLine2", "City", "State", "PostalCode", "CountryCode", "Note", "Tags", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy", "DeletedAt", "DeletedBy", "Version", "RowHash"];

    private static int MatchCompilerC8(string name) => name switch
    {
        "ItemCode" => 0,
        "ItemName" => 1,
        "ItemNote" => 2,
        "ItemType" => 3,
        "ItemSize" => 4,
        "ItemRank" => 5,
        "ItemKind" => 6,
        "ItemUnit" => 7,
        _ => -1
    };

    private static int MatchHashC8(string name)
    {
        switch (SamplingHash.Calculate(name))
        {
            case 543780:
                if (name.Equals("ItemUnit", StringComparison.Ordinal))
                {
                    return 7;
                }

                return -1;
            case 543781:
                if (name.Equals("ItemType", StringComparison.Ordinal))
                {
                    return 3;
                }

                return -1;
            case 543819:
                if (name.Equals("ItemRank", StringComparison.Ordinal))
                {
                    return 5;
                }

                return -1;
            case 543829:
                if (name.Equals("ItemSize", StringComparison.Ordinal))
                {
                    return 4;
                }

                return -1;
            case 544085:
                if (name.Equals("ItemCode", StringComparison.Ordinal))
                {
                    return 0;
                }

                return -1;
            case 544133:
                if (name.Equals("ItemName", StringComparison.Ordinal))
                {
                    return 1;
                }

                if (name.Equals("ItemNote", StringComparison.Ordinal))
                {
                    return 2;
                }

                return -1;
            case 544212:
                if (name.Equals("ItemKind", StringComparison.Ordinal))
                {
                    return 6;
                }

                return -1;
            default:
                return -1;
        }
    }

    private static readonly string[] NamesC8 = ["ItemCode", "ItemName", "ItemNote", "ItemType", "ItemSize", "ItemRank", "ItemKind", "ItemUnit"];
}
#pragma warning restore CA1822
