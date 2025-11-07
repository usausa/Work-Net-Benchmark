namespace WorkArrayBenchmark;

using System;

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

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    [Benchmark]
    public void ByStructRef()
    {
        var work = new StructInfo[8];
        for (var i = 0; i < work.Length; i++)
        {
            ref var w = ref work[i];
            w.Name = "Name";
            w.Type = i;
            w.Ordinal = i;
            w.Action = () => { };
        }

        for (var j = 0; j < 100000; j++)
        {
            for (var i = 0; i < work.Length; i++)
            {
                ref var w = ref work[i];
                w.Action();
            }
        }
    }

    [Benchmark]
    public void ByClass()
    {
        var work = new ClassInfo[8];
        for (var i = 0; i < work.Length; i++)
        {
            var w = new ClassInfo();
            work[i] = w;
            w.Name = "Name";
            w.Type = i;
            w.Ordinal = i;
            w.Action = () => { };
        }

        for (var j = 0; j < 100000; j++)
        {
            for (var i = 0; i < work.Length; i++)
            {
                var w = work[i];
                w.Action();
            }
        }
    }
}

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedField.Global
// ReSharper disable UnusedType.Global
#pragma warning disable CA1051
#pragma warning disable SA1401
#pragma warning disable CA1815

public struct StructInfo
{
    public string Name;

    public int Type;

    public int Ordinal;

    public Action Action;
}

public sealed class ClassInfo
{
    public string Name = default!;

    public int Type;

    public int Ordinal;

    public Action Action = default!;
}
