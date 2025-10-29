namespace GenericConverterBenchmark;

using System;
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

    [Benchmark(OperationsPerInvoke = N)]
    public void Default()
    {
        for (var i = 0; i < N; i++)
        {
            _ = DefaultConverter.ConvertAs<int>("0");
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void DelegateConverter()
    {
        for (var i = 0; i < N; i++)
        {
            _ = DelegateConverter<int>.ConvertAs("0");
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Generic()
    {
        for (var i = 0; i < N; i++)
        {
            _ = GenericConverter.ConvertAs<int>("0");
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Generic2()
    {
        for (var i = 0; i < N; i++)
        {
            _ = GenericConverter2.ConvertAs<int>("0");
        }
    }
}

public static class DefaultConverter
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ConvertAs<T>(object value)
    {
        return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
    }
}

public static class DelegateConverter<T>
{
    public static readonly Func<object, T> ConvertAs;

    static DelegateConverter()
    {
        if (typeof(T) == typeof(int))
        {
            ConvertAs = (Func<object, T>)(object)(Func<object, int>)(static x => Convert.ToInt32(x, CultureInfo.InvariantCulture));
        }
        else
        {
#pragma warning disable CA1065
            throw new NotSupportedException();
#pragma warning restore CA1065
        }
    }
}

public static class GenericConverter
{
    public static T ConvertAs<T>(object value)
    {
        if (typeof(T) == typeof(int))
        {
            var t = Convert.ToInt32(value, CultureInfo.InvariantCulture);
            return Unsafe.As<int, T>(ref t);
        }
        throw new NotSupportedException();
    }
}

public static class GenericConverter2
{
    public static T ConvertAs<T>(object value)
    {
        if (typeof(T) == typeof(bool))
        {
            var t = Convert.ToBoolean(value, CultureInfo.InvariantCulture);
            return Unsafe.As<bool, T>(ref t);
        }
        if (typeof(T) == typeof(sbyte))
        {
            var t = Convert.ToSByte(value, CultureInfo.InvariantCulture);
            return Unsafe.As<sbyte, T>(ref t);
        }
        if (typeof(T) == typeof(byte))
        {
            var t = Convert.ToByte(value, CultureInfo.InvariantCulture);
            return Unsafe.As<byte, T>(ref t);
        }
        if (typeof(T) == typeof(char))
        {
            var t = Convert.ToChar(value, CultureInfo.InvariantCulture);
            return Unsafe.As<char, T>(ref t);
        }
        if (typeof(T) == typeof(ulong))
        {
            var t = Convert.ToUInt64(value, CultureInfo.InvariantCulture);
            return Unsafe.As<ulong, T>(ref t);
        }
        if (typeof(T) == typeof(long))
        {
            var t = Convert.ToInt64(value, CultureInfo.InvariantCulture);
            return Unsafe.As<long, T>(ref t);
        }
        if (typeof(T) == typeof(ushort))
        {
            var t = Convert.ToUInt16(value, CultureInfo.InvariantCulture);
            return Unsafe.As<ushort, T>(ref t);
        }
        if (typeof(T) == typeof(short))
        {
            var t = Convert.ToInt16(value, CultureInfo.InvariantCulture);
            return Unsafe.As<short, T>(ref t);
        }
        if (typeof(T) == typeof(uint))
        {
            var t = Convert.ToUInt32(value, CultureInfo.InvariantCulture);
            return Unsafe.As<uint, T>(ref t);
        }
        // last
        if (typeof(T) == typeof(int))
        {
            var t = Convert.ToInt32(value, CultureInfo.InvariantCulture);
            return Unsafe.As<int, T>(ref t);
        }
        throw new NotSupportedException();
    }
}
