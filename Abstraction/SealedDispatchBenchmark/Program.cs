namespace SealedDispatchBenchmark;

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

// sealed / non-sealed の JIT によるデスバーチャライズ効果を検証する。
// 変数の静的型 (具体型 / 基底型 / インターフェース) によって最適化が変わる点も含む。

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int N = 1000;

    private readonly NonSealedDerived nonSealedDerived = new();
    private readonly SealedDerived sealedDerived = new();
    private readonly NonSealedImplement nonSealedImplement = new();
    private readonly SealedImplement sealedImplement = new();

    private readonly TargetBase nonSealedTargetBase = new NonSealedDerived();
    private readonly TargetBase sealedTargetBase = new SealedDerived();
    private readonly ITarget nonSealedInterface = new NonSealedImplement();
    private readonly ITarget sealedInterface = new SealedImplement();

    // Concrete type ---------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public object? InvokeNonSealedDerived()
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
    public object? InvokeSealedDerived()
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
    public object? InvokeNonSealedImplement()
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
    public object? InvokeSealedImplement()
    {
        var target = sealedImplement;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }

        return ret;
    }

    // TargetBase class variable ---------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public object? InvokeNonSealedAsTargetBase()
    {
        var target = nonSealedTargetBase;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? InvokeSealedAsTargetBase()
    {
        var target = sealedTargetBase;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }

        return ret;
    }

    // Interface variable ----------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public object? InvokeNonSealedAsInterface()
    {
        var target = nonSealedInterface;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? InvokeSealedAsInterface()
    {
        var target = sealedInterface;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target.Method();
        }

        return ret;
    }

    // Func variable ---------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public object? InvokeNonSealedAsFunc()
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
    public object? InvokeSealedAsFunc()
    {
        Func<object> target = sealedDerived.Method;
        var ret = default(object);
        for (var i = 0; i < N; i++)
        {
            ret = target();
        }

        return ret;
    }
}
#pragma warning restore CA1822

public class TargetBase
{
    public virtual object Method() => string.Empty;
}

public class NonSealedDerived : TargetBase
{
    public override object Method() => string.Empty;
}

public sealed class SealedDerived : TargetBase
{
    public override object Method() => string.Empty;
}

public interface ITarget
{
    object Method();
}

public class NonSealedImplement : ITarget
{
    public object Method() => string.Empty;
}

public sealed class SealedImplement : ITarget
{
    public object Method() => string.Empty;
}
