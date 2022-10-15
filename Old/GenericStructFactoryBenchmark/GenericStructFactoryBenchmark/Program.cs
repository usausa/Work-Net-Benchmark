namespace GenericStructFactoryBenchmark;

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
    private const int N = 1000;

#pragma warning disable CS8618
    private IFactory data0Factory;
    private IFactory data1Factory;
    private IFactory data2Factory;

    private Func<object> data0Func;
    private Func<object> data1Func;
    private Func<object> data2Func;
#pragma warning restore CS8618

    [GlobalSetup]
    public void Setup()
    {
        data0Factory = new Data0Factory();
        data1Factory = new Data1Factory { data0Factory = (Data0Factory)data0Factory };
        data2Factory = new Data2Factory { data0Factory = (Data0Factory)data0Factory, data1Factory = (Data1Factory)data1Factory };

        data0Func = () => new Data0();
        data1Func = () => new Data1((Data0)data0Func());
        data2Func = () => new Data2((Data0)data0Func(), (Data1)data1Func());
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object ByData0Factory()
    {
        object ret = default!;
        for (var n = 0; n < N; n++)
        {
            ret = ((Data0Factory)data0Factory).Create();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object ByData1Factory()
    {
        object ret = default!;
        for (var n = 0; n < N; n++)
        {
            ret = ((Data1Factory)data1Factory).Create();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object ByData2Factory()
    {
        object ret = default!;
        for (var n = 0; n < N; n++)
        {
            ret = ((Data2Factory)data2Factory).Create();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object ByData0Func()
    {
        object ret = default!;
        for (var n = 0; n < N; n++)
        {
            ret = data0Func();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object ByData1Func()
    {
        object ret = default!;
        for (var n = 0; n < N; n++)
        {
            ret = data1Func();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object ByData2Func()
    {
        object ret = default!;
        for (var n = 0; n < N; n++)
        {
            ret = data2Func();
        }
        return ret;
    }
}

public interface IFactory
{
    object Create();
}

public struct Data0Factory : IFactory
{
    public object Create() => new Data0();
}

public struct Data1Factory : IFactory
{
    // ReSharper disable InconsistentNaming
    public Data0Factory data0Factory;
    // ReSharper restore InconsistentNaming

    public object Create() => new Data1((Data0)data0Factory.Create());
}

public struct Data2Factory : IFactory
{
    // ReSharper disable InconsistentNaming
    public Data0Factory data0Factory;
    public Data1Factory data1Factory;
    // ReSharper restore InconsistentNaming

    public object Create() => new Data2((Data0)data0Factory.Create(), (Data1)data1Factory.Create());
}

public class Data0
{
}

public class Data1
{
    public Data0 Data0 { get; }

    public Data1(Data0 data0)
    {
        Data0 = data0;
    }
}

public class Data2
{
    public Data0 Data0 { get; }

    public Data1 Data1 { get; }

    public Data2(Data0 data0, Data1 data1)
    {
        Data0 = data0;
        Data1 = data1;
    }
}