namespace ProjectionBenchmark;

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
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
        AddJob(Job.MediumRun);
    }
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private readonly Source source = new();

    [Benchmark]
    public void Mapping()
    {
        Service.Execute(source.Map());
    }

    [Benchmark]
    public void MappingInterface()
    {
        Service.ExecuteByIf(source.Map());
    }

    [Benchmark]
    public void ProjectClass()
    {
        Service.ExecuteByIf(source.ProjectClass());
    }

    [Benchmark]
    public void ProjectStruct()
    {
        Service.ExecuteByIf(source.ProjectStruct());
    }
}
#pragma warning restore CA1822

public static class Service
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Execute(Destination d)
    {
        _ = d.Value1;
        _ = d.Value2;
        _ = d.Value3;
        _ = d.Value4;
        _ = d.Value5;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ExecuteByIf(IDestination d)
    {
        _ = d.Value1;
        _ = d.Value2;
        _ = d.Value3;
        _ = d.Value4;
        _ = d.Value5;
    }
}

public static class Generator
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Destination Map(this Source source) =>
        new()
        {
            Value1 = source.Value1,
            Value2 = source.Value2,
            Value3 = source.Value3,
            Value4 = source.Value4,
            Value5 = source.Value5
        };

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ClassProjection ProjectClass(this Source source) =>
        new(source);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StructProjection ProjectStruct(this Source source) =>
        new(source);
}

// ReSharper disable StructCanBeMadeReadOnly
#pragma warning disable CA1815
public sealed class Source
{
    public int Value1 { get; set; }
    public string Value2 { get; set; } = default!;
    public long Value3 { get; set; }
    public bool Value4 { get; set; }
    public DateTime Value5 { get; set; }
}

public interface IDestination
{
    int Value1 { get; }
    string Value2 { get; }
    long Value3 { get; }
    bool Value4 { get; }
    DateTime Value5 { get; }
}

public class Destination : IDestination
{
    public int Value1 { get; set; }
    public string Value2 { get; set; } = default!;
    public long Value3 { get; set; }
    public bool Value4 { get; set; }
    public DateTime Value5 { get; set; }
}

public struct StructProjection : IDestination
{
    private readonly Source source;

    public int Value1 => source.Value1;
    public string Value2 => source.Value2;
    public long Value3 => source.Value3;
    public bool Value4 => source.Value4;
    public DateTime Value5 => source.Value5;

    public StructProjection(Source source)
    {
        this.source = source;
    }
}

public class ClassProjection : IDestination
{
    private readonly Source source;

    public int Value1 => source.Value1;
    public string Value2 => source.Value2;
    public long Value3 => source.Value3;
    public bool Value4 => source.Value4;
    public DateTime Value5 => source.Value5;

    public ClassProjection(Source source)
    {
        this.source = source;
    }
}
#pragma warning restore CA1815
