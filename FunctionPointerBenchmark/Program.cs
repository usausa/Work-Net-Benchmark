namespace FunctionPointerBenchmark;

using System.Reflection;
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
public unsafe class Benchmark
{
    private const int N = 1000000;

    private Func<string> func = default!;

    private delegate*<string> pointer = default!;

    private delegate*<string> pointer2 = default!;

    private delegate*<string> pointer3 = default!;

    private delegate*<string> pointer4 = default!;

    private delegate*<string> pointer5 = default!;

    [GlobalSetup]
    public void Setup()
    {
        func = Message;
        pointer = &Message;
        var method = typeof(Benchmark).GetMethod(nameof(Benchmark.Message), BindingFlags.Static | BindingFlags.NonPublic);
        pointer2 = (delegate*<string>)method!.MethodHandle.GetFunctionPointer();
        pointer3 = &StaticClass.Message;

        pointer4 = &Accessor;
        pointer5 = &StaticClass.Accessor;
    }

    private static string Message() => "Hello, world!";

    private static string Accessor() => StaticHolder.Value;

    [Benchmark]
    public void Func()
    {
        for (var i = 0; i < N; i++)
        {
            _ = func();
        }
    }

    [Benchmark]
    public void Pointer()
    {
        for (var i = 0; i < N; i++)
        {
            _ = pointer();
        }
    }

    [Benchmark]
    public void Pointer2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = pointer2();
        }
    }

    [Benchmark]
    public void Pointer3()
    {
        for (var i = 0; i < N; i++)
        {
            _ = pointer3();
        }
    }

    [Benchmark]
    public void Pointer4()
    {
        for (var i = 0; i < N; i++)
        {
            _ = pointer4();
        }
    }

    [Benchmark]
    public void Pointer5()
    {
        for (var i = 0; i < N; i++)
        {
            _ = pointer5();
        }
    }
}
#pragma warning restore CA1822

public static class StaticClass
{
    public static string Message() => "Hello, world!";

    public static string Accessor() => StaticHolder.Value;
}

public static class StaticHolder
{
#pragma warning disable SA1401
#pragma warning disable CA2211
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    public static string Value = "Hello, world!";
#pragma warning restore CA2211
#pragma warning restore SA1401
}
