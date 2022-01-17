namespace ConverterBenchmark;

using System.Globalization;
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
    public int Default() => DefaultConverter.TryConvert<int>("0", out var result) ? result : default;

    [Benchmark]
    public int Delegate() => DelegateConverter<int>.TryConverter("0", out var result) ? result : default;
}

public static class DefaultConverter
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryConvert<T>(string value, out T result)
    {
        try
        {
            result = (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            return true;
        }
        catch (Exception)
        {
            result = default!;
            return false;
        }
    }

}


public delegate bool TryConverter<T>(string value, out T result);

public static class DelegateConverter<T>
{
    public static readonly TryConverter<T> TryConverter;

    static DelegateConverter()
    {
        if (typeof(T) == typeof(int))
        {
            TryConverter = (TryConverter<T>)(object)(TryConverter<int>)Int32.TryParse;
        }
        else
        {
            throw new NotSupportedException();
        }
    }
}