namespace ContainerConverterBenchmark;

using System.Collections;

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
        BenchmarkRunner.Run<ListConverterBenchmark>();
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
public class ListConverterBenchmark
{
    private const int N = 1000;

    private long[] array = default!;
    private List<long> list = default!;

    [Params(0, 4, 16, 32, 64)]
    public int Size { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        array = new long[Size];
        list = new List<long>(array);
    }

    private static int Convert(long value) => (int)value;

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayToArray()
    {
        var source = array;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.ArrayToArray(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayToArrayWithoutSourceCheck()
    {
        var source = array;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.ArrayToArrayWithoutSourceCheck(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ListToArray()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.ListToArray(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ListToArray2()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.ListToArray2(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IListToArray()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IListToArray(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IListToArray2()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IListToArray2(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IEnumerableToArray()
    {
        var source = array;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IEnumerableToArray(new MyEnumerable<long>(source), f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IEnumerableToArray2()
    {
        var source = array;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IEnumerableToArray2(new MyEnumerable<long>(source), f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ArrayToList()
    {
        var source = array;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.ArrayToList(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ListToList()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.ListToList(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ListToList2()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.ListToList2(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IListToList()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IListToList(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IListToList2()
    {
        var source = list;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IListToList2(source, f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IEnumerableToList()
    {
        var source = array;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IEnumerableToList(new MyEnumerable<long>(source), f);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void IEnumerableToList2()
    {
        var source = array;
        Func<long, int> f = Convert;
        for (var i = 0; i < N; i++)
        {
            ContainerConverter.IEnumerableToList2(new MyEnumerable<long>(source), f);
        }
    }
}

#pragma warning disable CA1002
public static class ContainerConverter
{
    public static TDestination[] ArrayToArray<TSource, TDestination>(TSource[] source, Func<TSource, TDestination> converter)
    {
        var array = new TDestination[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            var value = source[i];
            array[i] = value is not null ? converter(value) : default!;
        }

        return array;
    }

    public static TDestination[] ArrayToArrayWithoutSourceCheck<TSource, TDestination>(TSource[] source, Func<TSource, TDestination> converter)
    {
        var array = new TDestination[source.Length];
        for (var i = 0; i < source.Length; i++)
        {
            var value = source[i];
            array[i] = converter(value);
        }

        return array;
    }

    public static TDestination[] ListToArray<TSource, TDestination>(List<TSource> source, Func<TSource, TDestination> converter)
    {
        var array = new TDestination[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            var value = source[i];
            array[i] = value is not null ? converter(value) : default!;
        }

        return array;
    }

    public static TDestination[] ListToArray2<TSource, TDestination>(List<TSource> source, Func<TSource, TDestination> converter)
    {
        var count = source.Count;
        var array = new TDestination[count];
        for (var i = 0; i < count; i++)
        {
            var value = source[i];
            array[i] = value is not null ? converter(value) : default!;
        }

        return array;
    }

    public static TDestination[] IListToArray<TSource, TDestination>(IList<TSource> source, Func<TSource, TDestination> converter)
    {
        var array = new TDestination[source.Count];
        for (var i = 0; i < source.Count; i++)
        {
            var value = source[i];
            array[i] = value is not null ? converter(value) : default!;
        }

        return array;
    }

    public static TDestination[] IListToArray2<TSource, TDestination>(IList<TSource> source, Func<TSource, TDestination> converter)
    {
        var count = source.Count;
        var array = new TDestination[count];
        for (var i = 0; i < count; i++)
        {
            var value = source[i];
            array[i] = value is not null ? converter(value) : default!;
        }

        return array;
    }

    public static TDestination[] IEnumerableToArray<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
    {
        return source.Select(x => x is not null ? converter(x) : default!).ToArray();
    }

    public static TDestination[] IEnumerableToArray2<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
    {
        var list = new List<TDestination>();
        foreach (var value in source)
        {
            list.Add(value is not null ? converter(value) : default!);
        }

        return list.ToArray();
    }

    public static List<TDestination> ArrayToList<TSource, TDestination>(TSource[] source, Func<TSource, TDestination> converter)
    {
        var list = new List<TDestination>(source.Length);
        for (var i = 0; i < source.Length; i++)
        {
            var value = source[i];
            list.Add(value is not null ? converter(value) : default!);
        }

        return list;
    }

    public static List<TDestination> ListToList<TSource, TDestination>(List<TSource> source, Func<TSource, TDestination> converter)
    {
        var list = new List<TDestination>(source.Count);
        for (var i = 0; i < source.Count; i++)
        {
            var value = source[i];
            list.Add(value is not null ? converter(value) : default!);
        }

        return list;
    }

    public static List<TDestination> ListToList2<TSource, TDestination>(List<TSource> source, Func<TSource, TDestination> converter)
    {
        var count = source.Count;
        var list = new List<TDestination>(count);
        for (var i = 0; i < count; i++)
        {
            var value = source[i];
            list.Add(value is not null ? converter(value) : default!);
        }

        return list;
    }

    public static List<TDestination> IListToList<TSource, TDestination>(IList<TSource> source, Func<TSource, TDestination> converter)
    {
        var list = new List<TDestination>(source.Count);
        for (var i = 0; i < source.Count; i++)
        {
            var value = source[i];
            list.Add(value is not null ? converter(value) : default!);
        }

        return list;
    }

    public static List<TDestination> IListToList2<TSource, TDestination>(IList<TSource> source, Func<TSource, TDestination> converter)
    {
        var count = source.Count;
        var list = new List<TDestination>(count);
        for (var i = 0; i < count; i++)
        {
            var value = source[i];
            list.Add(value is not null ? converter(value) : default!);
        }

        return list;
    }

    public static List<TDestination> IEnumerableToList<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
    {
        return source.Select(x => x is not null ? converter(x) : default!).ToList();
    }

    public static List<TDestination> IEnumerableToList2<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
    {
        var list = new List<TDestination>();
        foreach (var value in source)
        {
            list.Add(value is not null ? converter(value) : default!);
        }

        return list;
    }
}
#pragma warning restore CA1002

#pragma warning disable CA1815
public struct MyEnumerator<T> : IEnumerator<T>
{
    private readonly T[] array;

    private int index;

    public MyEnumerator(T[] array)
    {
        this.array = array;
        index = -1;
    }

    public bool MoveNext() => (uint)++index < array.Length;

    public void Reset() => throw new NotImplementedException();

    public T Current => array[index];

    object IEnumerator.Current => Current!;

    public void Dispose()
    {
    }
}
#pragma warning restore CA1815, CA1065

#pragma warning disable CA1815
public readonly struct MyEnumerable<T> : IEnumerable<T>
{
    private readonly T[] array;

    public MyEnumerable(T[] array)
    {
        this.array = array;
    }

    public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
#pragma warning restore CA1815
