namespace ParseBenchmark;

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

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

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CA1822
#pragma warning disable CA1307
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1_000;

    [Params("0", "1234", "12345678", "x")]
    public string Value { get; set; } = default!;

    [Benchmark(OperationsPerInvoke = N)]
    public void ParseByTryParse()
    {
        var value = Value;
        for (var i = 0; i < N; i++)
        {
            _ = Operation.TryParse(value);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ParseByParse()
    {
        var value = Value;
        for (var i = 0; i < N; i++)
        {
            _ = Operation.Parse(value);
        }
    }
}

public static class Operation
{
    public static int TryParse(ReadOnlySpan<char> value)
    {
        return Int32.TryParse(value, CultureInfo.InvariantCulture, out var result) ? result : default;
    }

    public static int Parse(ReadOnlySpan<char> value)
    {
#pragma warning disable CA1031
        try
        {
            return Int32.Parse(value, CultureInfo.InvariantCulture);
        }
        catch
        {
            return default;
        }
#pragma warning restore CA1031
    }
}
