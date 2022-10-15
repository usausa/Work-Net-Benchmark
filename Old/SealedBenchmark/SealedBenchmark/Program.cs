namespace SealedBenchmark;

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

public class BaseClass
{
    public virtual object Method() => string.Empty;
}

public class NonSealedDerivedClass : BaseClass
{
    public override object Method() => string.Empty;
}

public sealed class SealedDerivedClass : BaseClass
{
    public override object Method() => string.Empty;
}

public interface IBase
{
    object Method();
}

public class NonSealedImplementClass : IBase
{
    public object Method() => string.Empty;
}

public sealed class SealedImplementClass : IBase
{
    public object Method() => string.Empty;
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    private readonly NonSealedDerivedClass nonSealedDerived = new();
    private readonly SealedDerivedClass sealedDerived = new();
    private readonly NonSealedImplementClass nonSealedImplement = new();
    private readonly SealedImplementClass sealedImplement = new();

    //--------------------------------------------------------------------------------
    // Invoke
    //--------------------------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeNonSealedDerived()
    {
        var target = nonSealedDerived;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeSealedDerived()
    {
        var target = sealedDerived;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeNonSealedImplement()
    {
        var target = nonSealedImplement;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }


    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeSealedImplement()
    {
        var target = sealedImplement;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }

    //--------------------------------------------------------------------------------
    // Invoke as base
    //--------------------------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeNonSealedDerivedAsBase()
    {
        BaseClass target = nonSealedDerived;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeSealedDerivedAsBase()
    {
        BaseClass target = sealedDerived;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeNonSealedImplementAsBase()
    {
        IBase target = nonSealedImplement;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }


    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeSealedImplementAsBase()
    {
        IBase target = sealedImplement;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }
        return ret;
    }

    //--------------------------------------------------------------------------------
    // Invoke as func
    //--------------------------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeNonSealedDerivedAsFunc()
    {
        Func<object> target = nonSealedDerived.Method;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeSealedDerivedAsFunc()
    {
        Func<object> target = sealedDerived.Method;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target();
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeNonSealedImplementAsFunc()
    {
        Func<object> target = nonSealedImplement.Method;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target();
        }
        return ret;
    }


    [Benchmark(OperationsPerInvoke = N)]
    public object InvokeSealedImplementAsFunc()
    {
        Func<object> target = sealedImplement.Method;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target();
        }
        return ret;
    }
}