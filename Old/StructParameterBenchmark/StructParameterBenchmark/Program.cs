namespace StructParameterBenchmark;

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
public class Benchmark
{
    private const int N = 1000;

    //--------------------------------------------------------------------------------
    // ref access
    //--------------------------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public void UpdateHolderValue3()
    {
        for (var i = 0; i < N; i++)
        {
            StructHolder.Value3 = new Value3 { X = 1d, Y = 2d, Z = 3d };
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void UpdateHolderValue3ByRef()
    {
        for (var i = 0; i < N; i++)
        {
            ref var value = ref StructHolder.Value3Ref;
            value.X = 1d;
            value.Y = 2d;
            value.Z = 3d;
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void UpdateHolderValue8()
    {
        for (var i = 0; i < N; i++)
        {
            StructHolder.Value8 = new Value8 { V1 = 1d, V2 = 2d, V3 = 3d, V4 = 4d, V5 = 5d, V6 = 6d, V7 = 7d, V8 = 8d };
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void UpdateHolderValue8ByRef()
    {
        for (var i = 0; i < N; i++)
        {
            ref var value = ref StructHolder.Value8Ref;
            value.V1 = 1d;
            value.V2 = 2d;
            value.V3 = 3d;
            value.V4 = 4d;
            value.V5 = 5d;
            value.V6 = 6d;
            value.V7 = 7d;
            value.V8 = 8d;
        }
    }

    //--------------------------------------------------------------------------------
    // in parameter
    //--------------------------------------------------------------------------------

    [Benchmark(OperationsPerInvoke = N)]
    public void CallDecimal()
    {
        var value1 = 2m;
        var value2 = 1m;
        for (var i = 0; i < N; i++)
        {
            Functions.Call(value1, value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallDecimalIn()
    {
        var value1 = 2m;
        var value2 = 1m;
        for (var i = 0; i < N; i++)
        {
            Functions.CallIn(in value1, in value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue3()
    {
        var value1 = new Value3 { X = 2d };
        var value2 = new Value3 { X = 1d };
        for (var i = 0; i < N; i++)
        {
            Functions.Call(value1, value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue3In()
    {
        var value1 = new Value3 { X = 2d };
        var value2 = new Value3 { X = 1d };
        for (var i = 0; i < N; i++)
        {
            Functions.CallIn(in value1, in value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallReadonlyRefValue3()
    {
        var value1 = new ReadonlyRefValue3(2d, 0d, 0d);
        var value2 = new ReadonlyRefValue3(1d, 0d, 0d);
        for (var i = 0; i < N; i++)
        {
            Functions.Call(value1, value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallReadonlyRefValue3Ref()
    {
        var value1 = new ReadonlyRefValue3(2d, 0d, 0d);
        var value2 = new ReadonlyRefValue3(1d, 0d, 0d);
        for (var i = 0; i < N; i++)
        {
            Functions.CallRef(ref value1, ref value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue8()
    {
        var value1 = new Value8 { V1 = 2d };
        var value2 = new Value8 { V1 = 1d };
        for (var i = 0; i < N; i++)
        {
            Functions.Call(value1, value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue8In()
    {
        var value1 = new Value8 { V1 = 2d };
        var value2 = new Value8 { V1 = 1d };
        for (var i = 0; i < N; i++)
        {
            Functions.CallIn(in value1, in value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallReadonlyRefValue8()
    {
        var value1 = new ReadonlyRefValue8(2d, 0d, 0d, 0d, 0d, 0d, 0d, 0d);
        var value2 = new ReadonlyRefValue8(1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d);
        for (var i = 0; i < N; i++)
        {
            Functions.Call(value1, value2);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallReadonlyRefValue8Ref()
    {
        var value1 = new ReadonlyRefValue8(2d, 0d, 0d, 0d, 0d, 0d, 0d, 0d);
        var value2 = new ReadonlyRefValue8(1d, 0d, 0d, 0d, 0d, 0d, 0d, 0d);
        for (var i = 0; i < N; i++)
        {
            Functions.CallRef(ref value1, ref value2);
        }
    }
}

public static class StructHolder
{
    public static Value3 Value3;

    public static ref Value3 Value3Ref => ref Value3;

    public static Value8 Value8;

    public static ref Value8 Value8Ref => ref Value8;
}

public static class Functions
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static decimal Call(decimal value1, decimal value2) => value1 - value2;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static decimal CallIn(in decimal value1, in decimal value2) => value1 - value2;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double Call(Value3 value1, Value3 value2) => value1.X - value2.X;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallIn(in Value3 value1, in Value3 value2) => value1.X - value2.X;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double Call(ReadonlyRefValue3 value1, ReadonlyRefValue3 value2) => value1.X - value2.X;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallRef(ref ReadonlyRefValue3 value1, ref ReadonlyRefValue3 value2) => value1.X - value2.X;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double Call(Value8 value1, Value8 value2) => value1.V1 - value2.V1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallIn(in Value8 value1, in Value8 value2) => value1.V1 - value2.V1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double Call(ReadonlyRefValue8 value1, ReadonlyRefValue8 value2) => value1.V1 - value2.V1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallRef(ref ReadonlyRefValue8 value1, ref ReadonlyRefValue8 value2) => value1.V1 - value2.V1;
}

// Size 24
public struct Value3
{
    public double X;
    public double Y;
    public double Z;
}

public readonly ref struct ReadonlyRefValue3
{
    public readonly double X;
    public readonly double Y;
    public readonly double Z;

    public ReadonlyRefValue3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

// Size 64
public struct Value8
{
    public double V1;
    public double V2;
    public double V3;
    public double V4;
    public double V5;
    public double V6;
    public double V7;
    public double V8;
}

public readonly ref struct ReadonlyRefValue8
{
    public readonly double V1;
    public readonly double V2;
    public readonly double V3;
    public readonly double V4;
    public readonly double V5;
    public readonly double V6;
    public readonly double V7;
    public readonly double V8;

    public ReadonlyRefValue8(double v1, double v2, double v3, double v4, double v5, double v6, double v7, double v8)
    {
        V1 = v1;
        V2 = v2;
        V3 = v3;
        V4 = v4;
        V5 = v5;
        V6 = v6;
        V7 = v7;
        V8 = v8;
    }
}
