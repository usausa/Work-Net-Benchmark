namespace AbstractCallBenchmark;

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
        _ = AddExporter(MarkdownExporter.GitHub);
        _ = AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        _ = AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
        _ = AddJob(Job.MediumRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core60));
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    private readonly IFactory interfaceFactory = new InterfaceFactory();
    private readonly FactoryBase abstractFactory = new AbstractFactory();
    private readonly Func<object> funcFactory = new FuncFactory().Create;

    private readonly IFactory interfaceFactory4 = new InterfaceFactory4();
    private readonly FactoryBase abstractFactory4 = new AbstractFactory4();
    private readonly Func<object> funcFactory4 = new FuncFactory4().Create;

    [Benchmark(OperationsPerInvoke = N)]
    public object? Interface()
    {
        var factory = interfaceFactory;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = factory.Create();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Abstract()
    {
        var factory = abstractFactory;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = factory.Create();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Func()
    {
        var factory = funcFactory;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = factory();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Interface4()
    {
        var factory = interfaceFactory4;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = factory.Create();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Abstract4()
    {
        var factory = abstractFactory4;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = factory.Create();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Func4()
    {
        var factory = funcFactory4;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = factory();
        }
        return ret;
    }
}

public interface IFactory
{
    object Create();
}

public sealed class InterfaceFactory : IFactory
{
    public object Create() => default!;
}

public sealed class InterfaceFactory4 : IFactory
{
    private readonly IFactory factory1 = new InterfaceFactory();
    private readonly IFactory factory2 = new InterfaceFactory();
    private readonly IFactory factory3 = new InterfaceFactory();
    private readonly IFactory factory4 = new InterfaceFactory();

    public object Create() => Functions.Create4(factory1.Create(), factory2.Create(), factory3.Create(), factory4.Create());
}

public abstract class FactoryBase
{
    public abstract object Create();
}

public sealed class AbstractFactory : FactoryBase
{
    public override object Create() => default!;
}

public sealed class AbstractFactory4 : FactoryBase
{
    private readonly FactoryBase factory1 = new AbstractFactory();
    private readonly FactoryBase factory2 = new AbstractFactory();
    private readonly FactoryBase factory3 = new AbstractFactory();
    private readonly FactoryBase factory4 = new AbstractFactory();

    public override object Create() => Functions.Create4(factory1.Create(), factory2.Create(), factory3.Create(), factory4.Create());
}

public class FuncFactory
{
    public object Create() => default!;
}

public class FuncFactory4
{
    private readonly Func<object> func1 = new FuncFactory().Create;
    private readonly Func<object> func2 = new FuncFactory().Create;
    private readonly Func<object> func3 = new FuncFactory().Create;
    private readonly Func<object> func4 = new FuncFactory().Create;

    public object Create() => Functions.Create4(func1(), func2(), func3(), func4());
}

public static class Functions
{
#pragma warning disable IDE0060
    public static object Create4(object arg1, object arg2, object arg3, object arg4) => default!;
#pragma warning restore IDE0060
}