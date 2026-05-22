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
        BenchmarkRunner.Run<TryBenchmark>();
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

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
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

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class TryBenchmark
{
    [Benchmark]
    public void Using1()
    {
        using (var o = new Disposable())
        {
            o.Dummy();
        }
    }

    [Benchmark]
    public void Using2()
    {
        using (var o1 = new Disposable())
        using (var o2 = new Disposable())
        {
            o1.Dummy();
            o2.Dummy();
        }
    }

    [Benchmark]
    public void Try1()
    {
        var o = new Disposable();
        try
        {
            o.Dummy();
        }
        finally
        {
            o.Dispose();
        }
    }

    [Benchmark]
    public void Try2()
    {
        var o1 = new Disposable();
        try
        {
            var o2 = new Disposable();
            try
            {
                o1.Dummy();
                o2.Dummy();
            }
            finally
            {
                o2.Dispose();
            }
        }
        finally
        {
            o1.Dispose();
        }
    }

    [Benchmark]
    public void UsingNotDispose()
    {
        var o = new Disposable();
        using (var d = new DelegateDisposable(o))
        {
            o.Dummy();
            d.SetNull();
        }
    }
}
#pragma warning restore CA1822

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

public sealed class Disposable : IDisposable
{
    public void Dummy()
    {
    }

    public void Dispose()
    {
    }
}

public struct DelegateDisposable : IDisposable
{
    private IDisposable? source;

    public DelegateDisposable(IDisposable source)
    {
        this.source = source;
    }

    public void SetNull()
    {
        source = null;
    }

    public void Dispose()
    {
        source?.Dispose();
    }
}
