namespace FactoryEntryBenchmark;

using System;
using System.Runtime.CompilerServices;

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
    private const int N = 1_000_000;

    private readonly Type1Resolver type1Resolver = new();

    private readonly Type2Resolver type2Resolver = new();

    [Benchmark(OperationsPerInvoke = N)]
    [BenchmarkCategory("Typed")]
    public void Type1Typed()
    {
        var resolver = type1Resolver;
        for (var i = 0; i < N; i++)
        {
            _ = resolver.Resolve<Target>();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    [BenchmarkCategory("Typed")]
    public void Type2Typed()
    {
        var resolver = type2Resolver;
        for (var i = 0; i < N; i++)
        {
            _ = resolver.Resolve<Target>();
        }
    }

#pragma warning disable CA2263
    [Benchmark(OperationsPerInvoke = N)]
    [BenchmarkCategory("Object")]
    public void Type1Object()
    {
        var resolver = type1Resolver;
        for (var i = 0; i < N; i++)
        {
            _ = resolver.Resolve(typeof(Target));
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    [BenchmarkCategory("Object")]
    public void Type2Object()
    {
        var resolver = type2Resolver;
        for (var i = 0; i < N; i++)
        {
            _ = resolver.Resolve(typeof(Target));
        }
    }
#pragma warning restore CA2263
}

public sealed class Target
{
}

public sealed class Type1Resolver
{
    private readonly Type key = typeof(Target);

    private readonly Func<object> factory;

    public Type1Resolver()
    {
        var target = new Target();
        factory = () => target;
    }

    public object Resolve(Type type)
    {
        if (type == key)
        {
            return factory();
        }

        return default!;
    }

    public T Resolve<T>()
    {
        if (typeof(T) == key)
        {
            return (T)factory();
        }

        return default!;
    }
}

public sealed class Type2Resolver
{
    private readonly Type key = typeof(Target);

    private readonly object factory;

    public Type2Resolver()
    {
        var target = new Target();
        factory = () => target;
    }

    public object Resolve(Type type)
    {
        if (type == key)
        {
            return Unsafe.As<Func<Target>>(factory)();
        }

        return default!;
    }

    public T Resolve<T>()
    {
        if (typeof(T) == key)
        {
            return Unsafe.As<Func<T>>(factory)();
        }

        return default!;
    }
}
