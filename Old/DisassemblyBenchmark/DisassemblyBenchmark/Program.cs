namespace DisassemblyBenchmark;

using System.Runtime.CompilerServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main()
    {
        _ = BenchmarkRunner.Run<Benchmark>();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        _ = AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        _ = AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        _ = AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
        _ = AddJob(Job.ShortRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core60));
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private int a = 17;
    private int b = 19;

    [Benchmark]
    public int MinInline() => Functions.MinInline(a, b);

    [Benchmark]
    public int MinNoinline() => Functions.MinNoinline(a, b);
}

public class Functions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int MinInline(int x, int y) => x > y ? y : x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int MinNoinline(int x, int y) => x > y ? y : x;
}