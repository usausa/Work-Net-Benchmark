namespace DisposableBenchmark;

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
        AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default);
        AddJob(Job.MediumRun);
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    private readonly State state = new();

    [Benchmark(OperationsPerInvoke = N)]
    public void Default()
    {
        for (var i = 0; i < N; i++)
        {
            using var _ = new StateScope(state);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Struct()
    {
        for (var i = 0; i < N; i++)
        {
            using var _ = new StructStateScope(state);
        }
    }
}

public class State
{
    public bool IsBusy { get; set; }
}

public sealed class StateScope : IDisposable
{
    private readonly State state;

    public StateScope(State state)
    {
        this.state = state;
        state.IsBusy = true;
    }

    public void Dispose()
    {
        state.IsBusy = false;
    }
}

public readonly struct StructStateScope : IDisposable
{
    private readonly State state;

    public StructStateScope(State state)
    {
        this.state = state;
        state.IsBusy = true;
    }

    public void Dispose()
    {
        state.IsBusy = false;
    }
}
