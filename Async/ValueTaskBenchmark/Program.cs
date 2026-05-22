namespace ValueTaskBenchmark;

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
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
#pragma warning disable CA1822
public class Benchmark
{
    private const int N = 1000;

    [Benchmark(OperationsPerInvoke = N)]
    public async Task TaskResult()
    {
        for (var i = 0; i < N; i++)
        {
            await AsyncLogic.TaskResult().ConfigureAwait(false);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public async ValueTask ValueTaskResult()
    {
        for (var i = 0; i < N; i++)
        {
            await AsyncLogic.ValueTaskResult().ConfigureAwait(false);
        }
    }
}
#pragma warning restore CA1822

public static class AsyncLogic
{
    public static Task<int> TaskResult() => Task.FromResult(1);

    public static ValueTask<int> ValueTaskResult() => new(1);
}
