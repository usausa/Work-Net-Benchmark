namespace FunctionPointerBenchmark;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

using System.Runtime.CompilerServices;

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
        _ = AddDiagnoser(MemoryDiagnoser.Default);
        _ = AddJob(Job.MediumRun);
    }
}

[Config(typeof(BenchmarkConfig))]
public unsafe class Benchmark
{
    private const int N = 1000;

    public class Entry
    {
        public delegate*<IFactory, object> FactoryPointer;
        public IFactory Factory = default!;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Create() => FactoryPointer(Factory);
    }

    public class StaticEntry
    {
        public delegate*<object> FactoryPointer;
    }

    private readonly Entry entry;

    private readonly IFactory factory;

    private readonly StaticEntry staticEntry;

    public Benchmark()
    {
        var method = typeof(TargetFactory).GetMethod(nameof(TargetFactory.Create));
        var pointer = (delegate*<IFactory, object>)method!.MethodHandle.GetFunctionPointer();
        var instance = new TargetFactory();
        entry = new Entry
        {
            FactoryPointer = pointer,
            Factory = instance
        };
        factory = instance;

        staticEntry = new StaticEntry
        {
            FactoryPointer = &StaticTargetFactory.Create
        };
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void InterfaceMethod()
    {
        for (var i = 0; i < N; i++)
        {
            _ = factory.Create();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void FunctionPointer()
    {
        for (var i = 0; i < N; i++)
        {
            _ = entry.Create();
        }
    }

    // Dynamic only

    [Benchmark(OperationsPerInvoke = N)]
    public void StaticFunctionPointer()
    {
        for (var i = 0; i < N; i++)
        {
            _ = staticEntry.FactoryPointer();
        }
    }
}

public interface IFactory
{
    public object Create();
}

public sealed class TargetFactory : IFactory
{
    public object Create() => new Target();
}

public static class StaticTargetFactory
{
    public static object Create() => new Target();
}

public class Target
{
}

