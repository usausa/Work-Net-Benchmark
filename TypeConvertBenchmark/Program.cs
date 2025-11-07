namespace TypeConvertBenchmark;

using System;
using System.ComponentModel;
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

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CA1822
#pragma warning disable CA1307
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int N = 1_000;

    [Params("0", "12345678", "X")]
    public string Value { get; set; } = default!;

    [Benchmark(OperationsPerInvoke = N)]
    public void OnDemand()
    {
        var value = Value;
        for (var i = 0; i < N; i++)
        {
            OnDemandConvert.TryConvert<int>(value, out _);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Cached()
    {
        var value = Value;
        for (var i = 0; i < N; i++)
        {
            CachedConvert<int>.TryConvert(value, out _);
        }
    }
}

public static class OnDemandConvert
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryConvert<TResult>(string? value, out TResult result)
    {
        if (value is null)
        {
            result = default!;
            return true;
        }

        var converter = TypeDescriptor.GetConverter(typeof(TResult));
        if (converter.CanConvertFrom(typeof(string)))
        {
#pragma warning disable CA1031
            try
            {
                var converted = converter.ConvertFrom(value);
                result = converted is null ? default! : Unsafe.As<object, TResult>(ref converted);
                return true;
            }
            catch
            {
                result = default!;
                return false;
            }
#pragma warning restore CA1031
        }

        result = default!;
        return false;
    }
}

public static class CachedConvert<T>
{
#pragma warning disable CA2211
    public static readonly TypeConverter? Converter;
#pragma warning restore CA2211

    static CachedConvert()
    {
        var type = typeof(T);
        var converter = TypeDescriptor.GetConverter(type);
        Converter = converter.CanConvertFrom(typeof(string)) ? converter : null;
    }

    public static bool TryConvert(string? value, out T result)
    {
        if (Converter is not null)
        {
            if (value is null)
            {
                result = default!;
                return true;
            }

#pragma warning disable CA1031
            try
            {
                var converted = Converter.ConvertFrom(value);
                result = converted is null ? default! : Unsafe.As<object, T>(ref converted);
                return true;
            }
            catch (Exception)
            {
                result = default!;
                return false;
            }
#pragma warning restore CA1031
        }

        result = default!;
        return false;
    }
}
