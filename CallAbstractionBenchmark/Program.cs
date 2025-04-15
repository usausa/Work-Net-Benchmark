namespace CallAbstractionBenchmark;

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
public unsafe class Benchmark
{
    private const int N = 1000000;

    private Func<object> factoryFunc = default!;

    private ClassFactoryDelegate factoryDelegate = default!;

#pragma warning disable CA1859
    private IFactory factoryImplement = default!;
    private IFactory sealedFactoryImplement = default!;
#pragma warning restore CA1859
    private AbstractFactory abstractFactoryImplement = default!;
    private AbstractFactory sealedAbstractFactoryImplement = default!;

    private delegate*<object> staticFactory = default!;

    [GlobalSetup]
    public void Setup()
    {
        var value = new object();

        factoryFunc = () => value;
        factoryDelegate = () => value;
        factoryImplement = new FactoryImplement(value);
        sealedFactoryImplement = new SealedFactoryImplement(value);
        abstractFactoryImplement = new AbstractFactoryImplement(value);
        sealedAbstractFactoryImplement = new SealedAbstractFactoryImplement(value);

        StaticFactory.SetValue(value);
        staticFactory = &StaticFactory.Create;
    }

    [Benchmark]
    public object Func()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = factoryFunc();
        }
        return ret;
    }

    [Benchmark]
    public object Delegate()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = factoryDelegate();
        }
        return ret;
    }

    [Benchmark]
    public object FactoryImplement()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = factoryImplement.Create();
        }
        return ret;
    }

    [Benchmark]
    public object SealedFactoryImplement()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = sealedFactoryImplement.Create();
        }
        return ret;
    }

    [Benchmark]
    public object AbstractFactoryImplement()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = abstractFactoryImplement.Create();
        }
        return ret;
    }

    [Benchmark]
    public object SealedAbstractFactoryImplement()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = sealedAbstractFactoryImplement.Create();
        }
        return ret;
    }

    [Benchmark]
    public object StaticDirect()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = StaticFactory.Create();
        }
        return ret;
    }

    [Benchmark]
    public object StaticPointer()
    {
        var ret = default(object)!;
        for (var i = 0; i < N; i++)
        {
            ret = staticFactory();
        }
        return ret;
    }
}
#pragma warning restore CA1822

#pragma warning disable CA1711
public delegate object ClassFactoryDelegate();
#pragma warning restore CA1711

public interface IFactory
{
    public object Create();
}

public class FactoryImplement : IFactory
{
    private readonly object value;

    public FactoryImplement(object value)
    {
        this.value = value;
    }

    public object Create() => value;
}

public sealed class SealedFactoryImplement : IFactory
{
    private readonly object value;

    public SealedFactoryImplement(object value)
    {
        this.value = value;
    }

    public object Create() => value;
}

public abstract class AbstractFactory
{
    public abstract object Create();
}

public class AbstractFactoryImplement : AbstractFactory
{
    private readonly object value;

    public AbstractFactoryImplement(object value)
    {
        this.value = value;
    }

    public override object Create() => value;
}

public sealed class SealedAbstractFactoryImplement : AbstractFactory
{
    private readonly object value;

    public SealedAbstractFactoryImplement(object value)
    {
        this.value = value;
    }

    public override object Create() => value;
}

public static class StaticFactory
{
    private static object value = default!;

    public static void SetValue(object obj)
    {
        value = obj;
    }

    public static object Create() => value;
}
