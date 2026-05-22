#pragma warning disable CA1051
#pragma warning disable CA1815
// ReSharper disable UnusedMethodReturnValue.Local
namespace ParameterBenchmark;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
        BenchmarkRunner.Run<StructSizeBenchmark>();
        BenchmarkRunner.Run<StructRefBenchmark>();
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
    private const int N = 1000;

    //[Benchmark]
    //public void CallClass()
    //{
    //    var value = new object();
    //    for (var i = 0; i < N; i++)
    //    {
    //        var parameter = new ClassParameter(0, value, TimeSpan.Zero);
    //        Call(parameter);
    //    }
    //}

    //[Benchmark]
    //public void CallStruct()
    //{
    //    var value = new object();
    //    for (var i = 0; i < N; i++)
    //    {
    //        var parameter = new StructParameter { Type = 0, Value = value, Duration = TimeSpan.Zero };
    //        Call(in parameter);
    //    }
    //}

    //[Benchmark]
    //public void CallRefStruct()
    //{
    //    var value = new object();
    //    for (var i = 0; i < N; i++)
    //    {
    //        var parameter = new RefStructParameter { Type = 0, Value = value, Duration = TimeSpan.Zero };
    //        Call(in parameter);
    //    }
    //}

    [Benchmark]
    public void CallReadonlyStruct()
    {
        var value = new object();
        for (var i = 0; i < N; i++)
        {
            var parameter = new ReadonlyStructParameter(0, value, TimeSpan.Zero);
            Call(in parameter);
        }
    }

    [Benchmark]
    public void CallReadonlyStruct2()
    {
        var value = new object();
        for (var i = 0; i < N; i++)
        {
            Call(new ReadonlyStructParameter(0, value, TimeSpan.Zero));
        }
    }

    [Benchmark]
    public void CallReadonlyRefStruct()
    {
        var value = new object();
        for (var i = 0; i < N; i++)
        {
            var parameter = new ReadonlyRefStructParameter(0, value, TimeSpan.Zero);
            Call(in parameter);
        }
    }

    [Benchmark]
    public void CallReadonlyRefStruct2()
    {
        var value = new object();
        for (var i = 0; i < N; i++)
        {
            Call(new ReadonlyRefStructParameter(0, value, TimeSpan.Zero));
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool Call(ClassParameter parameter) => parameter.Type == 0 && parameter.Duration > TimeSpan.Zero;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool Call(in StructParameter parameter) => parameter.Type == 0 && parameter.Duration > TimeSpan.Zero;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool Call(in RefStructParameter parameter) => parameter.Type == 0 && parameter.Duration > TimeSpan.Zero;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool Call(in ReadonlyStructParameter parameter) => parameter.Type == 0 && parameter.Duration > TimeSpan.Zero;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool Call(in ReadonlyRefStructParameter parameter) => parameter.Type == 0 && parameter.Duration > TimeSpan.Zero;
}

public sealed class ClassParameter
{
    public int Type { get; }

    public object Value { get; }

    public TimeSpan Duration { get; }

    public ClassParameter(int type, object value, TimeSpan duration)
    {
        Type = type;
        Value = value;
        Duration = duration;
    }
}

public struct StructParameter
{
    public int Type;

    public object Value;

    public TimeSpan Duration;
}

public ref struct RefStructParameter
{
    public int Type;

    public object Value;

    public TimeSpan Duration;
}

public readonly struct ReadonlyStructParameter
{
    public int Type { get; }

    public object Value { get; }

    public TimeSpan Duration { get; }

    public ReadonlyStructParameter(int type, object value, TimeSpan duration)
    {
        Type = type;
        Value = value;
        Duration = duration;
    }
}

public readonly ref struct ReadonlyRefStructParameter
{
    public int Type { get; }

    public object Value { get; }

    public TimeSpan Duration { get; }

    public ReadonlyRefStructParameter(int type, object value, TimeSpan duration)
    {
        Type = type;
        Value = value;
        Duration = duration;
    }
}

// 構造体のサイズ (8/16/24 バイト) が値渡し・ref 渡し・in 渡しのコストに与える影響を検証する。
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class StructSizeBenchmark
{
    private readonly SizedStruct8 field8 = new() { Value = 1 };
    private readonly SizedStruct16 field16 = new() { Value = 1 };
    private readonly SizedStruct24 field24 = new() { Value = 1 };
    private readonly ReadOnlySizedStruct8 readonlyField8 = new(1);
    private readonly ReadOnlySizedStruct16 readonlyField16 = new(1, 0);
    private readonly ReadOnlySizedStruct24 readonlyField24 = new(1, 0, 0);

    [Benchmark]
    public int ByValue8() => SizedFunctions.Call(field8);

    [Benchmark]
    public int ByValue16() => SizedFunctions.Call(field16);

    [Benchmark]
    public int ByValue24() => SizedFunctions.Call(field24);

    [Benchmark]
    public int ByValueReadonly8() => SizedFunctions.Call(readonlyField8);

    [Benchmark]
    public int ByValueReadonly16() => SizedFunctions.Call(readonlyField16);

    [Benchmark]
    public int ByValueReadonly24() => SizedFunctions.Call(readonlyField24);

    [Benchmark]
    public int ByRef8()
    {
        SizedStruct8 p = default;
        return SizedFunctions.CallRef(ref p);
    }

    [Benchmark]
    public int ByRef16()
    {
        SizedStruct16 p = default;
        return SizedFunctions.CallRef(ref p);
    }

    [Benchmark]
    public int ByRef24()
    {
        SizedStruct24 p = default;
        return SizedFunctions.CallRef(ref p);
    }

    [Benchmark]
    public int ByIn8()
    {
        var p = new ReadOnlySizedStruct8(0);
        return SizedFunctions.CallIn(in p);
    }

    [Benchmark]
    public int ByIn16()
    {
        var p = new ReadOnlySizedStruct16(0, 0);
        return SizedFunctions.CallIn(in p);
    }

    [Benchmark]
    public int ByIn24()
    {
        var p = new ReadOnlySizedStruct24(0, 0, 0);
        return SizedFunctions.CallIn(in p);
    }
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct SizedStruct8
{
    [FieldOffset(0)]
    public int Value;
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct SizedStruct16
{
    [FieldOffset(0)]
    public int Value;

    [FieldOffset(8)]
    public int Value2;
}

[StructLayout(LayoutKind.Explicit, Size = 24)]
public struct SizedStruct24
{
    [FieldOffset(0)]
    public int Value;

    [FieldOffset(8)]
    public int Value2;

    [FieldOffset(16)]
    public int Value3;
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public readonly struct ReadOnlySizedStruct8
{
    [FieldOffset(0)]
    public readonly int Value;

    public ReadOnlySizedStruct8(int value)
    {
        Value = value;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 16)]
public readonly struct ReadOnlySizedStruct16
{
    [FieldOffset(0)]
    public readonly int Value;

    [FieldOffset(8)]
    public readonly int Value2;

    public ReadOnlySizedStruct16(int value, int value2)
    {
        Value = value;
        Value2 = value2;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 24)]
public readonly struct ReadOnlySizedStruct24
{
    [FieldOffset(0)]
    public readonly int Value;

    [FieldOffset(8)]
    public readonly int Value2;

    [FieldOffset(16)]
    public readonly int Value3;

    public ReadOnlySizedStruct24(int value, int value2, int value3)
    {
        Value = value;
        Value2 = value2;
        Value3 = value3;
    }
}

public static class SizedFunctions
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Call(SizedStruct8 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Call(SizedStruct16 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Call(SizedStruct24 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Call(ReadOnlySizedStruct8 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Call(ReadOnlySizedStruct16 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Call(ReadOnlySizedStruct24 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CallRef(ref SizedStruct8 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CallRef(ref SizedStruct16 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CallRef(ref SizedStruct24 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CallIn(in ReadOnlySizedStruct8 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CallIn(in ReadOnlySizedStruct16 p) => p.Value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CallIn(in ReadOnlySizedStruct24 p) => p.Value;
}

// 大きな構造体の引数渡し (by value vs in) とスタティックフィールドの更新方式 (代入 vs ref) を検証する。
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class StructRefBenchmark
{
    private const int N = 1000;

    [Benchmark(OperationsPerInvoke = N)]
    public void UpdateHolderByAssign()
    {
        for (var i = 0; i < N; i++)
        {
            StructValueHolder.Value24 = new StructValue24 { X = 1d, Y = 2d, Z = 3d };
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void UpdateHolderByRef()
    {
        for (var i = 0; i < N; i++)
        {
            ref var v = ref StructValueHolder.Value24Ref;
            v.X = 1d;
            v.Y = 2d;
            v.Z = 3d;
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallDecimalByValue()
    {
        var a = 2m;
        var b = 1m;
        for (var i = 0; i < N; i++)
        {
            StructValueFunctions.CallDecimal(a, b);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallDecimalByIn()
    {
        var a = 2m;
        var b = 1m;
        for (var i = 0; i < N; i++)
        {
            StructValueFunctions.CallDecimalIn(in a, in b);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue24ByValue()
    {
        var a = new StructValue24 { X = 2d };
        var b = new StructValue24 { X = 1d };
        for (var i = 0; i < N; i++)
        {
            StructValueFunctions.CallValue24(a, b);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue24ByIn()
    {
        var a = new StructValue24 { X = 2d };
        var b = new StructValue24 { X = 1d };
        for (var i = 0; i < N; i++)
        {
            StructValueFunctions.CallValue24In(in a, in b);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue64ByValue()
    {
        var a = new StructValue64 { V1 = 2d };
        var b = new StructValue64 { V1 = 1d };
        for (var i = 0; i < N; i++)
        {
            StructValueFunctions.CallValue64(a, b);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void CallValue64ByIn()
    {
        var a = new StructValue64 { V1 = 2d };
        var b = new StructValue64 { V1 = 1d };
        for (var i = 0; i < N; i++)
        {
            StructValueFunctions.CallValue64In(in a, in b);
        }
    }
}

public static class StructValueHolder
{
    private static StructValue24 value24;
    public static ref StructValue24 Value24 => ref value24;
    public static ref StructValue24 Value24Ref => ref value24;
}

public static class StructValueFunctions
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static decimal CallDecimal(decimal a, decimal b) => a - b;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static decimal CallDecimalIn(in decimal a, in decimal b) => a - b;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallValue24(StructValue24 a, StructValue24 b) => a.X - b.X;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallValue24In(in StructValue24 a, in StructValue24 b) => a.X - b.X;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallValue64(StructValue64 a, StructValue64 b) => a.V1 - b.V1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double CallValue64In(in StructValue64 a, in StructValue64 b) => a.V1 - b.V1;
}

// 24 bytes (3 doubles)
public struct StructValue24
{
    public double X;
    public double Y;
    public double Z;
}

// 64 bytes (8 doubles)
public struct StructValue64
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
