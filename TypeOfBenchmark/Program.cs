#pragma warning disable SA1312
namespace TypeOfBenchmark;

using System.Runtime.CompilerServices;

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
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 4, printSource: true, printInstructionAddresses: true, exportDiff: true)));
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private readonly Type type = typeof(object);

    [Benchmark]
    public bool DefinedMember() =>
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type) &&
        Matcher.DefinedMember(type);

    [Benchmark]
    public bool EachTime() =>
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type) &&
        Matcher.EachTime(type);
}

public static class Matcher
{
    private static readonly Type ObjectType = typeof(object);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool DefinedMember(Type type) => type == ObjectType;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool EachTime(Type type) => type == typeof(object);
}
