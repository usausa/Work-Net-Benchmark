namespace LambdaLocalBenchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
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

// ReSharper disable ConvertToLocalFunction
#pragma warning disable CA1822
#pragma warning disable IDE0039
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    [Benchmark]
    public int LambdaFunction()
    {
        var lambda = static (int x) => x * x;
        return lambda(0);
    }

    [Benchmark]
    public int LocalFunction()
    {
        return Square(3);

        static int Square(int x)
        {
            return x * x;
        }
    }
}
