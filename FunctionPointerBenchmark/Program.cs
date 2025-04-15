namespace FunctionPointerBenchmark;

using System.Reflection;
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
        var b = new Benchmark();
        b.Setup();

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
public unsafe class Benchmark
{
    private const int N = 1000000;

    private Func<string> func = default!;

    private delegate*<string> pointer = default!;

    private delegate*<string> pointer2 = default!;

    private delegate*<string> pointer3 = default!;

    [GlobalSetup]
    public void Setup()
    {
        func = Generator;
        pointer = &Generator;
        var method = typeof(Benchmark).GetMethod(nameof(Benchmark.Generator), BindingFlags.Static | BindingFlags.NonPublic);
        pointer2 = (delegate*<string>)method!.MethodHandle.GetFunctionPointer();
        pointer3 = &StaticClass.Generator;
    }

    private static string Generator() => "Hello, world!";

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
}
#pragma warning restore CA1822

public static class StaticClass
{
    public static string Generator() => "Hello, world!";
}
