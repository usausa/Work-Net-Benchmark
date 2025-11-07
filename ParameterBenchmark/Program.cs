#pragma warning disable CA1051
#pragma warning disable CA1815
// ReSharper disable UnusedMethodReturnValue.Local
namespace ParameterBenchmark;

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
