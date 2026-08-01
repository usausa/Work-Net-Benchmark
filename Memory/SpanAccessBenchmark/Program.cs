namespace SpanAccessBenchmark;

using System.Globalization;
using System.Reflection;
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
        BenchmarkRunner.Run<ArrayAccessBenchmark>();
        BenchmarkRunner.Run<FieldArrayAccessBenchmark>();
        BenchmarkRunner.Run<RefLoopBenchmark>();
        BenchmarkRunner.Run<LengthCheckBenchmark>();
        BenchmarkRunner.Run<MapperBenchmark>();
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

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class ArrayAccessBenchmark
{
    private readonly int[] array = new int[16];

    [Benchmark]
    public int Single() => array[0];

    [Benchmark]
    public int SingleByHelper() => ArrayHelper.GetItemReference(array, 0);

    [Benchmark]
    public int Loop()
    {
        var total = 0;
        for (var i = 0; i < array.Length; i++)
        {
            total += array[i];
        }

        return total;
    }

    [Benchmark]
    public int LoopWithCheck()
    {
        var total = 0;
        for (var i = 0; i < 16; i++)
        {
            total += array[i];
        }

        return total;
    }

    [Benchmark]
    public int LoopByHelper()
    {
        var total = 0;
        for (var i = 0; i < 16; i++)
        {
            total += ArrayHelper.GetItemReference(array, i);
        }

        return total;
    }

    [Benchmark]
    public unsafe int LoopByPointer()
    {
        var total = 0;
        fixed (int* ptr = &array[0])
        {
            for (var i = 0; i < 16; i++)
            {
                total += *(ptr + i);
            }
        }

        return total;
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class FieldArrayAccessBenchmark
{
    private const int N = 1000;

    [Params(0, 1, 2, 4, 8, 16, 32, 64, 256, 1024)]
    public int Size { get; set; }

    private int[] valueArray = default!;
    private string[] classArray = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        valueArray = Enumerable.Range(0, Size).ToArray();
        classArray = Enumerable.Range(0, Size).Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray();
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int ValueNoLocal()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            var hash = 0;
            for (var j = 0; j < valueArray.Length; j++)
            {
                hash = hash ^ valueArray[j].GetHashCode();
            }

            ret = hash;
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int ValueLocal()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            var hash = 0;
            var array = valueArray;
            for (var j = 0; j < array.Length; j++)
            {
                hash = hash ^ array[j].GetHashCode();
            }

            ret = hash;
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int ClassNoLocal()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            var hash = 0;
            for (var j = 0; j < classArray.Length; j++)
            {
                hash = hash ^ classArray[j].GetHashCode(StringComparison.Ordinal);
            }

            ret = hash;
        }

        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int ClassLocal()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            var hash = 0;
            var array = classArray;
            for (var j = 0; j < array.Length; j++)
            {
                hash = hash ^ array[j].GetHashCode(StringComparison.Ordinal);
            }

            ret = hash;
        }

        return ret;
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class RefLoopBenchmark
{
    private const int N = 1000;

    [Params(2, 4, 8, 16, 32, 64, 128, 256)]
    public int Size { get; set; }

    private byte[] byteArray1 = default!;
    private byte[] byteArray2 = default!;
    private char[] charArray1 = default!;
    private char[] charArray2 = default!;
    private int[] intArray1 = default!;
    private int[] intArray2 = default!;
    private long[] longArray1 = default!;
    private long[] longArray2 = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        byteArray1 = new byte[Size];
        byteArray2 = new byte[Size];
        charArray1 = new char[Size];
        charArray2 = new char[Size];
        intArray1 = new int[Size];
        intArray2 = new int[Size];
        longArray1 = new long[Size];
        longArray2 = new long[Size];
    }

    [BenchmarkCategory("Single", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(byteArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(charArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(intArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByIndex()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndex(longArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(byteArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(charArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(intArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRef()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRef(longArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(byteArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(charArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(intArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Single", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRefLength()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLength(longArray1);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(byteArray1, byteArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(charArray1, charArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(intArray1, intArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByIndexTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByIndexTwin(longArray1, longArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(byteArray1, byteArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(charArray1, charArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(intArray1, intArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRefTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefTwin(longArray1, longArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Byte")]
    [Benchmark(OperationsPerInvoke = N)]
    public int ByteCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(byteArray1, byteArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Char")]
    [Benchmark(OperationsPerInvoke = N)]
    public int CharCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(charArray1, charArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Int")]
    [Benchmark(OperationsPerInvoke = N)]
    public int IntCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(intArray1, intArray2);
        }

        return ret;
    }

    [BenchmarkCategory("Twin", "Long")]
    [Benchmark(OperationsPerInvoke = N)]
    public int LongCountByRefLengthTwin()
    {
        var ret = 0;
        for (var i = 0; i < N; i++)
        {
            ret = CountOperator.CountByRefLengthTwin(longArray1, longArray2);
        }

        return ret;
    }
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class LengthCheckBenchmark
{
    private const int N = 1000;

    private static readonly int[] Array = new int[N];

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArrayWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.ArrayWithoutCast(Array, i);
        }

        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArrayWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.ArrayWithCast(Array, i);
        }

        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArraySpanWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithoutCast(Array, i);
        }

        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool ArraySpanWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithCast(Array, i);
        }

        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool SpanWithoutCast()
    {
        var span = Array.AsSpan();
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithoutCast(span, i);
        }

        return ret;
    }

    [BenchmarkCategory("Simple")]
    [Benchmark]
    public bool SpanWithCast()
    {
        var span = Array.AsSpan();
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.SpanWithCast(span, i);
        }

        return ret;
    }

    [BenchmarkCategory("Minus")]
    [Benchmark]
    public bool MinusWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.MinusWithoutCast(Array, i);
        }

        return ret;
    }

    [BenchmarkCategory("Minus")]
    [Benchmark]
    public bool MinusWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.MinusWithCast(Array, i);
        }

        return ret;
    }

    [BenchmarkCategory("NotEqualZero")]
    [Benchmark]
    public bool NotEqualZeroWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.NotEqualZeroWithoutCast(Array);
        }

        return ret;
    }

    [BenchmarkCategory("NotEqualZero")]
    [Benchmark]
    public bool NotEqualZeroWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.NotEqualZeroWithCast(Array);
        }

        return ret;
    }

    [BenchmarkCategory("GraterThan")]
    [Benchmark]
    public bool GraterThanZeroWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.GraterThanZeroWithoutCast(Array);
        }

        return ret;
    }

    [BenchmarkCategory("GraterThan")]
    [Benchmark]
    public bool GraterThanZeroWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.GraterThanZeroWithCast(Array);
        }

        return ret;
    }

    [BenchmarkCategory("LessThan")]
    [Benchmark]
    public bool LessThanWithoutCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.LessThanWithoutCast(Array);
        }

        return ret;
    }

    [BenchmarkCategory("LessThan")]
    [Benchmark]
    public bool LessThanWithCast()
    {
        var ret = false;
        for (var i = 0; i < N; i++)
        {
            ret = Checker.LessThanWithCast(Array);
        }

        return ret;
    }
}
#pragma warning restore CA1822

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class MapperBenchmark
{
    private const int N = 1000;

    private readonly ArrayCaller arrayCaller4 = new();
    private readonly ArrayCaller arrayCaller8 = new();
    private readonly ArrayCaller arrayCaller16 = new();
    private readonly ArrayCachedCaller arrayCachedCaller4 = new();
    private readonly ArrayCachedCaller arrayCachedCaller8 = new();
    private readonly ArrayCachedCaller arrayCachedCaller16 = new();
    private readonly ArrayIndividualCaller4 arrayIndividualCaller4 = new();
    private readonly ArrayIndividualCaller8 arrayIndividualCaller8 = new();
    private readonly ArrayIndividualCaller16 arrayIndividualCaller16 = new();
    private readonly ArrayCachedIndividualCaller4 arrayCachedIndividualCaller4 = new();
    private readonly ArrayCachedIndividualCaller8 arrayCachedIndividualCaller8 = new();
    private readonly ArrayCachedIndividualCaller16 arrayCachedIndividualCaller16 = new();
    private readonly ReverseArrayCachedIndividualCaller4 reverseArrayCachedIndividualCaller4 = new();
    private readonly ReverseArrayCachedIndividualCaller8 reverseArrayCachedIndividualCaller8 = new();
    private readonly ReverseArrayCachedIndividualCaller16 reverseArrayCachedIndividualCaller16 = new();
    private readonly IndividualCaller4 individualCaller4 = new();
    private readonly IndividualCaller8 individualCaller8 = new();
    private readonly IndividualCaller16 individualCaller16 = new();

    [GlobalSetup]
    public void GlobalSetup()
    {
        static void NoOp()
        {
        }

        SetupActionFields(arrayCaller4, NoOp, 4);
        SetupActionFields(arrayCaller8, NoOp, 8);
        SetupActionFields(arrayCaller16, NoOp, 16);
        SetupActionFields(arrayCachedCaller4, NoOp, 4);
        SetupActionFields(arrayCachedCaller8, NoOp, 8);
        SetupActionFields(arrayCachedCaller16, NoOp, 16);
        SetupActionFields(arrayIndividualCaller4, NoOp, 4);
        SetupActionFields(arrayIndividualCaller8, NoOp, 8);
        SetupActionFields(arrayIndividualCaller16, NoOp, 16);
        SetupActionFields(arrayCachedIndividualCaller4, NoOp, 4);
        SetupActionFields(arrayCachedIndividualCaller8, NoOp, 8);
        SetupActionFields(arrayCachedIndividualCaller16, NoOp, 16);
        SetupActionFields(reverseArrayCachedIndividualCaller4, NoOp, 4);
        SetupActionFields(reverseArrayCachedIndividualCaller8, NoOp, 8);
        SetupActionFields(reverseArrayCachedIndividualCaller16, NoOp, 16);
        SetupActionField(individualCaller4, NoOp);
        SetupActionField(individualCaller8, NoOp);
        SetupActionField(individualCaller16, NoOp);
    }

    private static void SetupActionFields(object target, Action action, int size)
    {
        foreach (var field in target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.FieldType == typeof(Action[])))
        {
            var actions = new Action[size];
            for (var i = 0; i < actions.Length; i++)
            {
                actions[i] = action;
            }

            field.SetValue(target, actions);
        }
    }

    private static void SetupActionField(object target, Action action)
    {
        foreach (var field in target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.FieldType == typeof(Action)))
        {
            field.SetValue(target, action);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCaller4()
    {
        var caller = arrayCaller4;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCachedCaller4()
    {
        var caller = arrayCachedCaller4;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayIndividualCaller4()
    {
        var caller = arrayIndividualCaller4;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCachedIndividualCaller4()
    {
        var caller = arrayCachedIndividualCaller4;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ReverseArrayCachedIndividualCaller4()
    {
        var caller = reverseArrayCachedIndividualCaller4;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IndividualCaller4()
    {
        var caller = individualCaller4;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCaller8()
    {
        var caller = arrayCaller8;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCachedCaller8()
    {
        var caller = arrayCachedCaller8;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayIndividualCaller8()
    {
        var caller = arrayIndividualCaller8;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCachedIndividualCaller8()
    {
        var caller = arrayCachedIndividualCaller8;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ReverseArrayCachedIndividualCaller8()
    {
        var caller = reverseArrayCachedIndividualCaller8;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IndividualCaller8()
    {
        var caller = individualCaller8;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCaller16()
    {
        var caller = arrayCaller16;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCachedCaller16()
    {
        var caller = arrayCachedCaller16;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayIndividualCaller16()
    {
        var caller = arrayIndividualCaller16;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayCachedIndividualCaller16()
    {
        var caller = arrayCachedIndividualCaller16;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ReverseArrayCachedIndividualCaller16()
    {
        var caller = reverseArrayCachedIndividualCaller16;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IndividualCaller16()
    {
        var caller = individualCaller16;
        for (var i = 0; i < N; i++)
        {
            caller.Call();
        }
    }
}

public static class ArrayHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetItemReference<T>(T[] array, int index)
    {
        ref var data = ref MemoryMarshal.GetArrayDataReference(array);
        return ref Unsafe.Add(ref data, index);
    }
}

public static class CountOperator
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<byte> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<char> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<int> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndex(ReadOnlySpan<long> source)
    {
        var count = 0;
        for (var i = 0; i < source.Length; i++)
        {
            if (source[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<byte> source1, ReadOnlySpan<byte> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }

            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<char> source1, ReadOnlySpan<char> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }

            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<int> source1, ReadOnlySpan<int> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }

            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByIndexTwin(ReadOnlySpan<long> source1, ReadOnlySpan<long> source2)
    {
        var count = 0;
        for (var i = 0; i < source1.Length; i++)
        {
            if (source1[i] != 0)
            {
                count++;
            }

            if (source2[i] != 0)
            {
                count++;
            }
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<byte> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<char> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<int> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRef(ReadOnlySpan<long> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        ref var end = ref Unsafe.Add(ref sr, source.Length);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr, ref end))
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<byte> source1, ReadOnlySpan<byte> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<char> source1, ReadOnlySpan<char> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<int> source1, ReadOnlySpan<int> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefTwin(ReadOnlySpan<long> source1, ReadOnlySpan<long> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var end = ref Unsafe.Add(ref sr1, source1.Length);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);

        var count = 0;
        while (Unsafe.IsAddressLessThan(ref sr1, ref end))
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<byte> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<char> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<int> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLength(ReadOnlySpan<long> source)
    {
        ref var sr = ref MemoryMarshal.GetReference(source);
        var length = source.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr != 0)
            {
                count++;
            }

            sr = ref Unsafe.Add(ref sr, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<byte> source1, ReadOnlySpan<byte> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<char> source1, ReadOnlySpan<char> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<int> source1, ReadOnlySpan<int> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int CountByRefLengthTwin(ReadOnlySpan<long> source1, ReadOnlySpan<long> source2)
    {
        ref var sr1 = ref MemoryMarshal.GetReference(source1);
        ref var sr2 = ref MemoryMarshal.GetReference(source2);
        var length = source1.Length;

        var count = 0;
        while (length != 0)
        {
            if (sr1 != 0)
            {
                count++;
            }

            if (sr2 != 0)
            {
                count++;
            }

            sr2 = ref Unsafe.Add(ref sr2, 1);
            sr1 = ref Unsafe.Add(ref sr1, 1);
            length--;
        }

        return count;
    }
}

public static class Checker
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool ArrayWithoutCast(int[] array, int compare) => array.Length < compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool ArrayWithCast(int[] array, int compare) => (uint)array.Length < (uint)compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool SpanWithoutCast(ReadOnlySpan<int> span, int compare) => span.Length < compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool SpanWithCast(ReadOnlySpan<int> span, int compare) => (uint)span.Length < (uint)compare;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool MinusWithoutCast(int[] array, int compare) => array.Length < compare - 1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool MinusWithCast(int[] array, int compare) => (uint)array.Length < (uint)(compare - 1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool NotEqualZeroWithoutCast(int[] array) => array.Length != 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool NotEqualZeroWithCast(int[] array) => (uint)array.Length != 0u;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool GraterThanZeroWithoutCast(int[] array) => array.Length > 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool GraterThanZeroWithCast(int[] array) => (uint)array.Length > 0u;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool LessThanWithoutCast(int[] array) => array.Length < 256;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool LessThanWithCast(int[] array) => (uint)array.Length < 256u;
}

public sealed class ArrayCaller
{
    private Action[] actions = default!;

    public void Call()
    {
        for (var i = 0; i < actions.Length; i++)
        {
            actions[i]();
        }
    }
}

public sealed class ArrayCachedCaller
{
    private Action[] actions = default!;

    public void Call()
    {
        var a = actions;
        for (var i = 0; i < a.Length; i++)
        {
            a[i]();
        }
    }
}

public sealed class ArrayIndividualCaller4
{
    private Action[] actions = default!;

    public void Call()
    {
        actions[0]();
        actions[1]();
        actions[2]();
        actions[3]();
    }
}

public sealed class ArrayIndividualCaller8
{
    private Action[] actions = default!;

    public void Call()
    {
        actions[0]();
        actions[1]();
        actions[2]();
        actions[3]();
        actions[4]();
        actions[5]();
        actions[6]();
        actions[7]();
    }
}

public sealed class ArrayIndividualCaller16
{
    private Action[] actions = default!;

    public void Call()
    {
        actions[0]();
        actions[1]();
        actions[2]();
        actions[3]();
        actions[4]();
        actions[5]();
        actions[6]();
        actions[7]();
        actions[8]();
        actions[9]();
        actions[10]();
        actions[11]();
        actions[12]();
        actions[13]();
        actions[14]();
        actions[15]();
    }
}

public sealed class ArrayCachedIndividualCaller4
{
    private Action[] actions = default!;

    public void Call()
    {
        var a = actions;
        a[0]();
        a[1]();
        a[2]();
        a[3]();
    }
}

public sealed class ArrayCachedIndividualCaller8
{
    private Action[] actions = default!;

    public void Call()
    {
        var a = actions;
        a[0]();
        a[1]();
        a[2]();
        a[3]();
        a[4]();
        a[5]();
        a[6]();
        a[7]();
    }
}

public sealed class ArrayCachedIndividualCaller16
{
    private Action[] actions = default!;

    public void Call()
    {
        var a = actions;
        a[0]();
        a[1]();
        a[2]();
        a[3]();
        a[4]();
        a[5]();
        a[6]();
        a[7]();
        a[8]();
        a[9]();
        a[10]();
        a[11]();
        a[12]();
        a[13]();
        a[14]();
        a[15]();
    }
}

public sealed class ReverseArrayCachedIndividualCaller4
{
    private Action[] actions = default!;

    public void Call()
    {
        var a = actions;
        a[3]();
        a[2]();
        a[1]();
        a[0]();
    }
}

public sealed class ReverseArrayCachedIndividualCaller8
{
    private Action[] actions = default!;

    public void Call()
    {
        var a = actions;
        a[7]();
        a[6]();
        a[5]();
        a[4]();
        a[3]();
        a[2]();
        a[1]();
        a[0]();
    }
}

public sealed class ReverseArrayCachedIndividualCaller16
{
    private Action[] actions = default!;

    public void Call()
    {
        var a = actions;
        a[15]();
        a[14]();
        a[13]();
        a[12]();
        a[11]();
        a[10]();
        a[9]();
        a[8]();
        a[7]();
        a[6]();
        a[5]();
        a[4]();
        a[3]();
        a[2]();
        a[1]();
        a[0]();
    }
}

public sealed class IndividualCaller4
{
    private Action action0 = default!;
    private Action action1 = default!;
    private Action action2 = default!;
    private Action action3 = default!;

    public void Call()
    {
        action0();
        action1();
        action2();
        action3();
    }
}

public sealed class IndividualCaller8
{
    private Action action0 = default!;
    private Action action1 = default!;
    private Action action2 = default!;
    private Action action3 = default!;
    private Action action4 = default!;
    private Action action5 = default!;
    private Action action6 = default!;
    private Action action7 = default!;

    public void Call()
    {
        action0();
        action1();
        action2();
        action3();
        action4();
        action5();
        action6();
        action7();
    }
}

public sealed class IndividualCaller16
{
    private Action action0 = default!;
    private Action action1 = default!;
    private Action action2 = default!;
    private Action action3 = default!;
    private Action action4 = default!;
    private Action action5 = default!;
    private Action action6 = default!;
    private Action action7 = default!;
    private Action action8 = default!;
    private Action action9 = default!;
    private Action action10 = default!;
    private Action action11 = default!;
    private Action action12 = default!;
    private Action action13 = default!;
    private Action action14 = default!;
    private Action action15 = default!;

    public void Call()
    {
        action0();
        action1();
        action2();
        action3();
        action4();
        action5();
        action6();
        action7();
        action8();
        action9();
        action10();
        action11();
        action12();
        action13();
        action14();
        action15();
    }
}
