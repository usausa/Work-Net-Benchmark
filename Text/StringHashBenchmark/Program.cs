namespace StringHashBenchmark;

using System;
using System.IO.Hashing;
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

    [Params("Id", "Name", "12345678", "Hello world!", "XxxxXxxxXxxxXxxx")]
    public string Value { get; set; } = default!;

    [Benchmark(OperationsPerInvoke = N)]
    public void XxHash3()
    {
        var value = Value;
        for (var i = 0; i < N; i++)
        {
            _ = Hasher.CalcXxHash3(value);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void XxHash3b()
    {
        var value = Value;
        for (var i = 0; i < N; i++)
        {
            _ = Hasher.CalcXxHash3b(value);
        }
    }

    //[Benchmark(OperationsPerInvoke = N)]
    //public void DefaultOrdinal()
    //{
    //    var value = Value;
    //    for (var i = 0; i < N; i++)
    //    {
    //        _ = value.GetHashCode(StringComparison.Ordinal);
    //    }
    //}

    //[Benchmark(OperationsPerInvoke = N)]
    //public void DefaultOrdinalIgnoreCase()
    //{
    //    var value = Value;
    //    for (var i = 0; i < N; i++)
    //    {
    //        _ = value.GetHashCode(StringComparison.OrdinalIgnoreCase);
    //    }
    //}

    //[Benchmark(OperationsPerInvoke = N)]
    //public void CustomOrdinal()
    //{
    //    var value = Value;
    //    for (var i = 0; i < N; i++)
    //    {
    //        _ = Hasher.CalcHash(value);
    //    }
    //}

    //[Benchmark(OperationsPerInvoke = N)]
    //public void CustomOrdinalIgnoreCase()
    //{
    //    var value = Value;
    //    for (var i = 0; i < N; i++)
    //    {
    //        _ = Hasher.CalcHashIgnoreCase(value);
    //    }
    //}
}

public static class Hasher
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint CalcHash(string value)
    {
        var hash = 2166136261u;
        foreach (var c in value)
        {
            hash = (c ^ hash) * 16777619;
        }
        return hash;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint CalcHashIgnoreCase(string value)
    {
        var hash = 2166136261u;
        foreach (var c in value)
        {
            hash = (Char.ToLowerInvariant(c) ^ hash) * 16777619;
        }
        return hash;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CalcXxHash3(ReadOnlySpan<char> value)
    {
        var bytes = MemoryMarshal.Cast<char, byte>(value);
        return unchecked((int)XxHash3.HashToUInt64(bytes));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe int CalcXxHash3b(string value)
    {
        fixed (char* pChar = value)
        {
            return unchecked((int)XxHash3.HashToUInt64(new ReadOnlySpan<byte>(pChar, value.Length * sizeof(char))));
        }
    }
}
