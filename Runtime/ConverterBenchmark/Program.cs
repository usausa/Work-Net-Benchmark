namespace ConverterBenchmark;

using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
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
        BenchmarkRunner.Run<ConvertMethodBenchmark>();
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
    [Benchmark]
    public int Default() => DefaultConverter.TryConvert<int>("0", out var result) ? result : default;

    [Benchmark]
    public int Delegate() => DelegateConverter<int>.TryConverter("0", out var result) ? result : default;
}
#pragma warning restore CA1822

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class ConvertMethodBenchmark
{
    private const int N = 1000;

    private readonly Func<long, int> direct = Factory.ByDirect();

    private readonly Func<long, int> method = Factory.ByMethod();

    private readonly Func<long, int> expression = Factory.ByExpression();

    [Benchmark]
    public int Direct()
    {
        var ret = 0;
        var f = direct;
        for (var i = 0; i < N; i++)
        {
            ret = f(-1);
        }

        return ret;
    }

    [Benchmark]
    public int Method()
    {
        var ret = 0;
        var f = method;
        for (var i = 0; i < N; i++)
        {
            ret = f(-1);
        }

        return ret;
    }

    [Benchmark]
    public int Expression()
    {
        var ret = 0;
        var f = expression;
        for (var i = 0; i < N; i++)
        {
            ret = f(-1);
        }

        return ret;
    }
}

public static class DefaultConverter
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#pragma warning disable CA1031
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
#pragma warning restore CA1031
}

public delegate bool TryConverter<T>(string value, out T result);

public static class DelegateConverter<T>
{
    public static TryConverter<T> TryConverter { get; private set; } = default!;

#pragma warning disable CA1065
    static DelegateConverter()
    {
        if (typeof(T) == typeof(int))
        {
            TryConverter = (TryConverter<T>)(object)(TryConverter<int>)int.TryParse;
        }
        else
        {
            throw new NotSupportedException();
        }
    }
#pragma warning restore CA1065
}

public static class Factory
{
    public static Func<long, int> ByDirect()
    {
        var dynamicMethod = new DynamicMethod(string.Empty, typeof(int), new[] { typeof(object), typeof(long) }, true);
        var ilGenerator = dynamicMethod.GetILGenerator();

        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Conv_I4);
        ilGenerator.Emit(OpCodes.Ret);

        return dynamicMethod.CreateDelegate<Func<long, int>>(null);
    }

    public static Func<long, int> ByMethod()
    {
        var dynamicMethod = new DynamicMethod(string.Empty, typeof(int), new[] { typeof(object), typeof(long) }, true);
        var ilGenerator = dynamicMethod.GetILGenerator();

        var mi = typeof(ConvertMethods).GetMethod("Int64ToInt32")!;
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Call, mi);
        ilGenerator.Emit(OpCodes.Ret);

        return dynamicMethod.CreateDelegate<Func<long, int>>(null);
    }

    public static Func<long, int> ByExpression()
    {
        var arg = Expression.Parameter(typeof(long), "value");
        var mi = typeof(ConvertMethods).GetMethod("Int64ToInt32")!;
        var body = Expression.Call(mi, arg);
        var lambda = Expression.Lambda<Func<long, int>>(body, arg);
        return lambda.Compile();
    }
}

public static class ConvertMethods
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Int64ToInt32(long value) => (int)value;
}
