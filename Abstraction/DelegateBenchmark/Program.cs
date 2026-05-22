namespace DelegateBenchmark;

using System.Reflection;
using System.Reflection.Emit;

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
        BenchmarkRunner.Run<DelegateInvokeBenchmark>();
        BenchmarkRunner.Run<DelegateCompareBenchmark>();
        BenchmarkRunner.Run<CallBridgeBenchmark>();
        BenchmarkRunner.Run<CallbackSortBenchmark>();
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
public unsafe class DelegateInvokeBenchmark
{
    private const int N = 1000;

    private Func<int, int> sd = default!;
    private Func<int, int> id = default!;
    private delegate*<int, int> fp;
    private delegate*<int, int> sdfp;

    [GlobalSetup]
    public void GlobalSetup()
    {
        var method1 = new DynamicMethod("StaticDelegate", typeof(int), [typeof(int)], true);
        var il = method1.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldc_I4_1);
        il.Emit(OpCodes.Add);
        il.Emit(OpCodes.Ret);
        sd = method1.CreateDelegate<Func<int, int>>();

        var method2 = new DynamicMethod("InstanceDelegate", typeof(int), [typeof(object), typeof(int)], true);
        il = method2.GetILGenerator();
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Ldc_I4_1);
        il.Emit(OpCodes.Add);
        il.Emit(OpCodes.Ret);
        id = method2.CreateDelegate<Func<int, int>>(null);

        fp = &StaticFunction;

        var handle = (RuntimeMethodHandle)typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(method1, null)!;
        sdfp = (delegate*<int, int>)handle.GetFunctionPointer();
    }

    private static int StaticFunction(int value) => value + 1;

    [Benchmark(OperationsPerInvoke = N, Baseline = true)]
    public int StaticDelegate()
    {
        var func = sd;
        var result = 0;
        for (var i = 0; i < N; i++)
        {
            result += func(i);
        }

        return result;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int InstanceDelegate()
    {
        var func = id;
        var result = 0;
        for (var i = 0; i < N; i++)
        {
            result += func(i);
        }

        return result;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int FunctionPointer()
    {
        var func = fp;
        var result = 0;
        for (var i = 0; i < N; i++)
        {
            result += func(i);
        }

        return result;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int DynamicMethodFunctionPointer()
    {
        var func = sdfp;
        var result = 0;
        for (var i = 0; i < N; i++)
        {
            result += func(i);
        }

        return result;
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class DelegateCompareBenchmark
{
    private Func<object?> callDirect = default!;
    private Func<object?> callStaticMethod = default!;
    private Func<object?> callInstanceMethod = default!;
    private Func<object?> callDynamic = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        callDirect = static () => null;
        callStaticMethod = DelegateMethodCaller.CallStaticMethod;
        var caller = new DelegateMethodCaller();
        callInstanceMethod = caller.CallInstanceMethod;
        callDynamic = DelegateMethodGenerator.Create();
    }

    [Benchmark]
    public void CallDirect()
    {
        callDirect();
    }

    [Benchmark]
    public void CallStaticMethod()
    {
        callStaticMethod();
    }

    [Benchmark]
    public void CallInstanceMethod()
    {
        callInstanceMethod();
    }

    [Benchmark]
    public void CallDynamic()
    {
        callDynamic();
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class CallBridgeBenchmark
{
    private Func<object> provider1 = default!;
    private Func<object, object> provider2 = default!;
    private Func<object, object> provider3 = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        provider1 = static () => new object();
        provider2 = static _ => new object();
        provider3 = _ => provider1();
    }

    [Benchmark]
    public object Provider1() => provider1();

    [Benchmark]
    public object Provider2() => provider2(this);

    [Benchmark]
    public object Provider3() => provider3(this);
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class CallbackSortBenchmark
{
    private const int N = 1000;

    private List<int> list = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        list = Enumerable.Range(1, 1024).ToList();
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort1()
    {
        list.Sort(SortComparer.Instance);
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort2()
    {
        list.Sort(SortComparer.StaticCompare);
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort3()
    {
        list.Sort(SortComparer.Comparison);
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Sort4()
    {
        list.Sort(static (x, y) => SortComparer.StaticCompare(x, y));
    }
}

public sealed class DelegateMethodCaller
{
    private readonly bool created;

    public DelegateMethodCaller() => created = true;

    public static object? CallStaticMethod() => null;

    public object? CallInstanceMethod() => created ? null : new object();
}

public static class DelegateMethodGenerator
{
    public static Func<object?> Create()
    {
        var dynamic = new DynamicMethod(string.Empty, typeof(object), [typeof(object)], true);
        var il = dynamic.GetILGenerator();
        il.Emit(OpCodes.Ldnull);
        il.Emit(OpCodes.Ret);
        return (Func<object?>)dynamic.CreateDelegate(typeof(Func<object?>), null);
    }
}

public sealed class SortComparer : IComparer<int>
{
    public static SortComparer Instance { get; } = new();

    public static Comparison<int> Comparison { get; } = Instance.Compare;

    public int Compare(int x, int y) => x.CompareTo(y);

    public static int StaticCompare(int x, int y) => x.CompareTo(y);
}
