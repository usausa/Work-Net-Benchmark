namespace ReadOnlyFieldBenchmark;

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
    private readonly PublicResolver publicResolver = new();
    private readonly ReadOnlyResolver readonlyResolver = new(0);
    private readonly Public4Resolver public4Resolver = new();
    private readonly ReadOnly4Resolver readonly4Resolver = new(0, 0, 0, 0);

    [Benchmark]
    public void ReadOnly() => readonlyResolver.Resolve();

    [Benchmark]
    public void Public() => publicResolver.Resolve();

    [Benchmark]
    public void ReadOnly4() => readonly4Resolver.Resolve();

    [Benchmark]
    public void Public4() => public4Resolver.Resolve();
}

public interface IResolver
{
    int Resolve();
}

public sealed class PublicResolver : IResolver
{
#pragma warning disable CA1051
#pragma warning disable SA1401
    public int Value;
#pragma warning restore SA1401
#pragma warning restore CA1051

    public int Resolve() => Value;
}

public sealed class ReadOnlyResolver : IResolver
{
    private readonly int value;

    public ReadOnlyResolver(int value)
    {
        this.value = value;
    }

    public int Resolve() => value;
}

public sealed class Public4Resolver : IResolver
{
#pragma warning disable CA1051
#pragma warning disable SA1401
    public int Value1;
    public int Value2;
    public int Value3;
    public int Value4;
#pragma warning restore SA1401
#pragma warning restore CA1051

    public int Resolve() => Value1 + Value2 + Value3 + Value4;
}

public sealed class ReadOnly4Resolver : IResolver
{
    private readonly int value1;
    private readonly int value2;
    private readonly int value3;
    private readonly int value4;

    public ReadOnly4Resolver(int value1, int value2, int value3, int value4)
    {
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
        this.value4 = value4;
    }

    public int Resolve() => value1 + value2 + value3 + value4;
}
