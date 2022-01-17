using Microsoft.Extensions.DependencyInjection;

namespace BuildServiceProviderBenchmark;

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
        AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default);
        AddJob(Job.MediumRun);
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    [Benchmark]
    public IServiceProvider Single()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IService, Service>();
        return services.BuildServiceProvider();
    }

    [Benchmark]
    public IServiceProvider Multi8()
    {
        var services = new ServiceCollection();
        services.AddSingleton<Service1>();
        services.AddSingleton<Service2>();
        services.AddSingleton<Service3>();
        services.AddSingleton<Service4>();
        services.AddSingleton<Service5>();
        services.AddSingleton<Service6>();
        services.AddSingleton<Service7>();
        services.AddSingleton<Service8>();
        return services.BuildServiceProvider();
    }
}

public interface IService
{
}

public class Service : IService
{
}

public class Service1
{
}

public class Service2
{
}

public class Service3
{
}

public class Service4
{
}

public class Service5
{
}

public class Service6
{
}

public class Service7
{
}

public class Service8
{
}
