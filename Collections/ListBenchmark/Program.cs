// ReSharper disable ParameterTypeCanBeEnumerable.Global
#pragma warning disable IDE0032
namespace ListBenchmark;

using System.Collections;
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
        BenchmarkRunner.Run<ListCapacityBenchmark>();
        BenchmarkRunner.Run<ListEnumerationBenchmark>();
        BenchmarkRunner.Run<IndexLoopBenchmark>();
        BenchmarkRunner.Run<EnumerableBenchmark>();
        BenchmarkRunner.Run<EnumeratorBenchmark>();
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
public class ListCapacityBenchmark
{
    [Benchmark]
    public void Default()
    {
        _ = new List<string?>();
    }

    [Benchmark]
    public void Capacity1()
    {
        _ = new List<string?>(1);
    }

    [Benchmark]
    public void Capacity2()
    {
        _ = new List<string?>(2);
    }

    [Benchmark]
    public void DefaultAdd1()
    {
        _ = new List<string?> { null };
    }

    [Benchmark]
    public void Capacity1Add1()
    {
        _ = new List<string?>(1) { null };
    }

    [Benchmark]
    public void Capacity2Add1()
    {
        _ = new List<string?>(2) { null };
    }

    [Benchmark]
    public void DefaultAdd2()
    {
        _ = new List<string?>(1) { null, null };
    }

    [Benchmark]
    public void Capacity1Add2()
    {
        _ = new List<string?>(1) { null, null };
    }

    [Benchmark]
    public void Capacity2Add2()
    {
        _ = new List<string?>(2) { null, null };
    }

    [Benchmark]
    public void DefaultAdd3()
    {
        _ = new List<string?> { null, null, null };
    }

    [Benchmark]
    public void Capacity1Add3()
    {
        _ = new List<string?>(1) { null, null, null };
    }

    [Benchmark]
    public void Capacity2Add3()
    {
        _ = new List<string?>(2) { null, null, null };
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class ListEnumerationBenchmark
{
    private const int N = 1000;

    private List<int> list = default!;

    [Params(0, 2, 4, 8, 32, 256, 1024)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        list = new List<int>(Enumerable.Range(0, Size));
    }

    [Benchmark(OperationsPerInvoke = N, Baseline = true)]
    public void Foreach()
    {
        var l = list;
        for (var n = 0; n < N; n++)
        {
            foreach (var _ in l)
            {
            }
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void For()
    {
        var l = list;
        for (var n = 0; n < N; n++)
        {
            for (var i = 0; i < l.Count; i++)
            {
                _ = l[i];
            }
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void ForeachSpan()
    {
        var l = list;
        for (var n = 0; n < N; n++)
        {
            foreach (var _ in CollectionsMarshal.AsSpan(l))
            {
            }
        }
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class IndexLoopBenchmark
{
    private const int N = 1000;

    [Params(4, 16, 64, 256, 1024)]
    public int Size { get; set; }

    private string[] array = default!;
    private List<string> list = default!;

    [GlobalSetup]
    public void Setup()
    {
        array = Enumerable.Range(1, Size).Select(x => x.ToString()).ToArray();
        list = Enumerable.Range(1, Size).Select(x => x.ToString()).ToList();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    // ReSharper disable UnusedParameter.Local
    private static void Dummy(string value, int index)
    {
    }
    // ReSharper restore UnusedParameter.Local

    [Benchmark]
    public void ArrayFor()
    {
        for (var n = 0; n < N; n++)
        {
            var a = array;
            for (var i = 0; i < a.Length; i++)
            {
                Dummy(a[i], i);
            }
        }
    }

    [Benchmark]
    public void ArrayForEachIncrement()
    {
        for (var n = 0; n < N; n++)
        {
            var i = 0;
            foreach (var s in array)
            {
                Dummy(s, i);
                i++;
            }
        }
    }

    [Benchmark]
    public void ArrayForEachLinq()
    {
        for (var n = 0; n < N; n++)
        {
            foreach (var indexed in array.Select((name, index) => (name, index)))
            {
                Dummy(indexed.name, indexed.index);
            }
        }
    }

    [Benchmark]
    public void ListFor()
    {
        for (var n = 0; n < N; n++)
        {
            var l = list;
            for (var i = 0; i < l.Count; i++)
            {
                Dummy(l[i], i);
            }
        }
    }

    [Benchmark]
    public void ListForEachIncrement()
    {
        for (var n = 0; n < N; n++)
        {
            var i = 0;
            foreach (var s in list)
            {
                Dummy(s, i);
                i++;
            }
        }
    }

    [Benchmark]
    public void ListForEachLinq()
    {
        for (var n = 0; n < N; n++)
        {
            foreach (var indexed in list.Select((name, index) => (name, index)))
            {
                Dummy(indexed.name, indexed.index);
            }
        }
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class EnumerableBenchmark
{
    [Params(4, 32, 128)]
    public int Size { get; set; }

    private List<int> list = Enumerable.Range(1, 4).ToList();
    private int[] array = Enumerable.Range(1, 4).ToArray();

    [GlobalSetup]
    public void Setup()
    {
        list = Enumerable.Range(1, Size).ToList();
        array = Enumerable.Range(1, Size).ToArray();
    }

    [Benchmark]
    public int ForeachList() => IterationFunctions.ForeachList(list);

    [Benchmark]
    public int ForeachListEnumerable() => IterationFunctions.ForeachEnumerable(list);

    [Benchmark]
    public int EnumeratorList() => IterationFunctions.EnumeratorList(list);

    [Benchmark]
    public int EnumeratorEnumerableList() => IterationFunctions.EnumeratorEnumerable(list);

    [Benchmark]
    public int ForList() => IterationFunctions.ForList(list);

    [Benchmark]
    public int ForListGeneric() => IterationFunctions.ForListGeneric(list);

    [Benchmark]
    public int ForIListList() => IterationFunctions.ForIList(list);

    [Benchmark]
    public int ForeachArray() => IterationFunctions.ForeachArray(array);

    [Benchmark]
    public int ForeachArrayEnumerable() => IterationFunctions.ForeachEnumerable(array);

    [Benchmark]
    public int EnumeratorEnumerableArray() => IterationFunctions.EnumeratorEnumerable(array);

    [Benchmark]
    public int ForArray() => IterationFunctions.ForArray(array);

    [Benchmark]
    public int ForIListArray() => IterationFunctions.ForIList(array);

    [Benchmark]
    public int ForeachSpan() => IterationFunctions.ForeachSpan(array);

    [Benchmark]
    public int ForeachReadOnlySpan() => IterationFunctions.ForeachReadOnlySpan(array);

    [Benchmark]
    public int ForeachSpanAsReadonly() => IterationFunctions.ForeachSpanAsReadonly(array);

    [Benchmark]
    public int ForeachSpanEnumerable() => IterationFunctions.ForeachEnumerable(array);

    [Benchmark]
    public int EnumeratorEnumerableSpan() => IterationFunctions.EnumeratorEnumerable(array);

    [Benchmark]
    public int ForSpan() => IterationFunctions.ForSpan(array);

    [Benchmark]
    public int ForReadOnlySpan() => IterationFunctions.ForReadOnlySpan(array);

    [Benchmark]
    public int ForSpanAsReadOnly() => IterationFunctions.ForSpanAsReadOnly(array);
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class EnumeratorBenchmark
{
    private readonly StructArray structArray = new(CreateArray());
    private readonly StructArrayWithField structArrayWithField = new(CreateArray());
    private readonly StructArrayWithFieldNoBoundsCheck structArrayWithFieldNoBoundsCheck = new(CreateArray());
    private readonly StructArrayWithFieldLengthCache structArrayWithFieldLengthCache = new(CreateArray());
    private readonly StructArrayWithFieldLengthCacheNoBoundsCheck structArrayWithFieldLengthCacheNoBoundsCheck = new(CreateArray());
    private readonly StructArrayWithFieldLengthUnsignedCache structArrayWithFieldLengthUnsignedCache = new(CreateArray());

    private readonly CustomStructArray customStructArray = new(CreateArray());
    private readonly CustomStructArrayWithField customStructArrayWithField = new(CreateArray());
    private readonly CustomStructArrayWithFieldNoBoundsCheck customStructArrayWithFieldNoBoundsCheck = new(CreateArray());
    private readonly CustomStructArrayWithFieldLengthCache customStructArrayWithFieldLengthCache = new(CreateArray());
    private readonly CustomStructArrayWithFieldLengthCacheNoBoundsCheck customStructArrayWithFieldLengthCacheNoBoundsCheck = new(CreateArray());
    private readonly CustomStructArrayWithFieldLengthUnsignedCache customStructArrayWithFieldLengthUnsignedCache = new(CreateArray());

    private readonly ClassArray classArray = new(CreateArray());
    private readonly ClassArrayWithField classArrayWithField = new(CreateArray());
    private readonly ClassArrayWithFieldNoBoundsCheck classArrayWithFieldNoBoundsCheck = new(CreateArray());
    private readonly ClassArrayWithFieldLengthCache classArrayWithFieldLengthCache = new(CreateArray());
    private readonly ClassArrayWithFieldLengthCacheNoBoundsCheck classArrayWithFieldLengthCacheNoBoundsCheck = new(CreateArray());
    private readonly ClassArrayWithFieldLengthUnsignedCache classArrayWithFieldLengthUnsignedCache = new(CreateArray());

    private static int[] CreateArray() => Enumerable.Range(1, 16).ToArray();

    [Benchmark]
    public void StructArray() { foreach (var _ in structArray) { } }

    [Benchmark]
    public void StructArrayWithField() { foreach (var _ in structArrayWithField) { } }

    [Benchmark]
    public void StructArrayWithFieldNoBoundsCheck() { foreach (var _ in structArrayWithFieldNoBoundsCheck) { } }

    [Benchmark]
    public void StructArrayWithFieldLengthCache() { foreach (var _ in structArrayWithFieldLengthCache) { } }

    [Benchmark]
    public void StructArrayWithFieldLengthCacheNoBoundsCheck() { foreach (var _ in structArrayWithFieldLengthCacheNoBoundsCheck) { } }

    [Benchmark]
    public void StructArrayWithFieldLengthUnsignedCache() { foreach (var _ in structArrayWithFieldLengthUnsignedCache) { } }

    [Benchmark]
    public void CustomStructArray() { foreach (var _ in customStructArray) { } }

    [Benchmark]
    public void CustomStructArrayWithField() { foreach (var _ in customStructArrayWithField) { } }

    [Benchmark]
    public void CustomStructArrayWithFieldNoBoundsCheck() { foreach (var _ in customStructArrayWithFieldNoBoundsCheck) { } }

    [Benchmark]
    public void CustomStructArrayWithFieldLengthCache() { foreach (var _ in customStructArrayWithFieldLengthCache) { } }

    [Benchmark]
    public void CustomStructArrayWithFieldLengthCacheNoBoundsCheck() { foreach (var _ in customStructArrayWithFieldLengthCacheNoBoundsCheck) { } }

    [Benchmark]
    public void CustomStructArrayWithFieldLengthUnsignedCache() { foreach (var _ in customStructArrayWithFieldLengthUnsignedCache) { } }

    [Benchmark]
    public void ClassArray() { foreach (var _ in classArray) { } }

    [Benchmark]
    public void ClassArrayWithField() { foreach (var _ in classArrayWithField) { } }

    [Benchmark]
    public void ClassArrayWithFieldNoBoundsCheck() { foreach (var _ in classArrayWithFieldNoBoundsCheck) { } }

    [Benchmark]
    public void ClassArrayWithFieldLengthCache() { foreach (var _ in classArrayWithFieldLengthCache) { } }

    [Benchmark]
    public void ClassArrayWithFieldLengthCacheNoBoundsCheck() { foreach (var _ in classArrayWithFieldLengthCacheNoBoundsCheck) { } }

    [Benchmark]
    public void ClassArrayWithFieldLengthUnsignedCache() { foreach (var _ in classArrayWithFieldLengthUnsignedCache) { } }
}

public static class IterationFunctions
{
    public static int ForeachList(List<int> source)
    {
        var total = 0;
        foreach (var value in source)
        {
            total += value;
        }

        return total;
    }

    public static int ForeachArray(int[] source)
    {
        var total = 0;
        foreach (var value in source)
        {
            total += value;
        }

        return total;
    }

    public static int ForeachSpan(Span<int> source)
    {
        var total = 0;
        foreach (var value in source)
        {
            total += value;
        }

        return total;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ForeachSpanAsReadonly(Span<int> source) => ForeachReadOnlySpan(source);

    public static int ForeachReadOnlySpan(ReadOnlySpan<int> source)
    {
        var total = 0;
        foreach (var value in source)
        {
            total += value;
        }

        return total;
    }

    public static int ForeachEnumerable(IEnumerable<int> source)
    {
        var total = 0;
        foreach (var value in source)
        {
            total += value;
        }

        return total;
    }

    public static int EnumeratorList(List<int> source)
    {
        var total = 0;
        using var e = source.GetEnumerator();
        while (e.MoveNext())
        {
            total += e.Current;
        }

        return total;
    }

    public static int EnumeratorEnumerable(IEnumerable<int> source)
    {
        var total = 0;
        using var e = source.GetEnumerator();
        while (e.MoveNext())
        {
            total += e.Current;
        }

        return total;
    }

    public static int ForList(List<int> source)
    {
        var total = 0;
        for (var i = 0; i < source.Count; i++)
        {
            total += source[i];
        }

        return total;
    }

    public static int ForListGeneric<TList>(TList source)
        where TList : IReadOnlyList<int>
    {
        var total = 0;
        for (var i = 0; i < source.Count; i++)
        {
            total += source[i];
        }

        return total;
    }

    public static int ForIList(IList<int> source)
    {
        var total = 0;
        for (var i = 0; i < source.Count; i++)
        {
            total += source[i];
        }

        return total;
    }

    public static int ForArray(int[] source)
    {
        var total = 0;
        for (var i = 0; i < source.Length; i++)
        {
            total += source[i];
        }

        return total;
    }

    public static int ForSpan(Span<int> source)
    {
        var total = 0;
        for (var i = 0; i < source.Length; i++)
        {
            total += source[i];
        }

        return total;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ForSpanAsReadOnly(Span<int> source) => ForReadOnlySpan(source);

    public static int ForReadOnlySpan(ReadOnlySpan<int> source)
    {
        var total = 0;
        for (var i = 0; i < source.Length; i++)
        {
            total += source[i];
        }

        return total;
    }
}

public sealed class StructArray : IEnumerable<int>
{
    private readonly int[] array;

    public StructArray(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new StructArrayEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class StructArrayWithField : IEnumerable<int>
{
    private readonly int[] array;

    public StructArrayWithField(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class StructArrayWithFieldNoBoundsCheck : IEnumerable<int>
{
    private readonly int[] array;

    public StructArrayWithFieldNoBoundsCheck(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldNoBoundsCheckEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class StructArrayWithFieldLengthCache : IEnumerable<int>
{
    private readonly int[] array;

    public StructArrayWithFieldLengthCache(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldLengthCacheEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class StructArrayWithFieldLengthCacheNoBoundsCheck : IEnumerable<int>
{
    private readonly int[] array;

    public StructArrayWithFieldLengthCacheNoBoundsCheck(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class StructArrayWithFieldLengthUnsignedCache : IEnumerable<int>
{
    private readonly int[] array;

    public StructArrayWithFieldLengthUnsignedCache(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldLengthUnsignedCacheEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class CustomStructArray : IEnumerable<int>
{
    private readonly int[] array;

    public CustomStructArray(int[] array) => this.array = array;

    public StructArrayEnumerator GetEnumerator() => new(array);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class CustomStructArrayWithField : IEnumerable<int>
{
    private readonly int[] array;

    public CustomStructArrayWithField(int[] array) => this.array = array;

    public StructArrayWithFieldEnumerator GetEnumerator() => new(array);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class CustomStructArrayWithFieldNoBoundsCheck : IEnumerable<int>
{
    private readonly int[] array;

    public CustomStructArrayWithFieldNoBoundsCheck(int[] array) => this.array = array;

    public StructArrayWithFieldNoBoundsCheckEnumerator GetEnumerator() => new(array);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldNoBoundsCheckEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class CustomStructArrayWithFieldLengthCache : IEnumerable<int>
{
    private readonly int[] array;

    public CustomStructArrayWithFieldLengthCache(int[] array) => this.array = array;

    public StructArrayWithFieldLengthCacheEnumerator GetEnumerator() => new(array);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldLengthCacheEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class CustomStructArrayWithFieldLengthCacheNoBoundsCheck : IEnumerable<int>
{
    private readonly int[] array;

    public CustomStructArrayWithFieldLengthCacheNoBoundsCheck(int[] array) => this.array = array;

    public StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator GetEnumerator() => new(array);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class CustomStructArrayWithFieldLengthUnsignedCache : IEnumerable<int>
{
    private readonly int[] array;

    public CustomStructArrayWithFieldLengthUnsignedCache(int[] array) => this.array = array;

    public StructArrayWithFieldLengthUnsignedCacheEnumerator GetEnumerator() => new(array);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldLengthUnsignedCacheEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class ClassArray : IEnumerable<int>
{
    private readonly int[] array;

    public ClassArray(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new ClassArrayEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class ClassArrayWithField : IEnumerable<int>
{
    private readonly int[] array;

    public ClassArrayWithField(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class ClassArrayWithFieldNoBoundsCheck : IEnumerable<int>
{
    private readonly int[] array;

    public ClassArrayWithFieldNoBoundsCheck(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldNoBoundsCheckEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class ClassArrayWithFieldLengthCache : IEnumerable<int>
{
    private readonly int[] array;

    public ClassArrayWithFieldLengthCache(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldLengthCacheEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class ClassArrayWithFieldLengthCacheNoBoundsCheck : IEnumerable<int>
{
    private readonly int[] array;

    public ClassArrayWithFieldLengthCacheNoBoundsCheck(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldLengthCacheNoBoundsCheckEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class ClassArrayWithFieldLengthUnsignedCache : IEnumerable<int>
{
    private readonly int[] array;

    public ClassArrayWithFieldLengthUnsignedCache(int[] array) => this.array = array;

    public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldLengthUnsignedCacheEnumerator(array);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

#pragma warning disable CA1065
public struct StructArrayEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private int index;

    public int Current
    {
        get;
        private set;
    }

    object IEnumerator.Current => Current;

    public StructArrayEnumerator(int[] array)
    {
        this.array = array;
        index = 0;
        Current = default;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < array.Length)
        {
            Current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public struct StructArrayWithFieldEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public StructArrayWithFieldEnumerator(int[] array)
    {
        this.array = array;
        index = 0;
        current = default;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < array.Length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public struct StructArrayWithFieldNoBoundsCheckEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public StructArrayWithFieldNoBoundsCheckEnumerator(int[] array)
    {
        this.array = array;
        index = 0;
        current = default;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if ((uint)index < (uint)array.Length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public struct StructArrayWithFieldLengthCacheEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private readonly int length;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public StructArrayWithFieldLengthCacheEnumerator(int[] array)
    {
        this.array = array;
        length = array.Length;
        index = 0;
        current = default;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public struct StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private readonly int length;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator(int[] array)
    {
        this.array = array;
        length = array.Length;
        index = 0;
        current = default;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if ((uint)index < (uint)length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public struct StructArrayWithFieldLengthUnsignedCacheEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private readonly uint length;
    private int current;
    private uint index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public StructArrayWithFieldLengthUnsignedCacheEnumerator(int[] array)
    {
        this.array = array;
        length = (uint)array.Length;
        index = 0;
        current = default;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < length)
        {
            current = array[(int)index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public sealed class ClassArrayEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private int index;

    public int Current
    {
        get;
        private set;
    }

    object IEnumerator.Current => Current;

    public ClassArrayEnumerator(int[] array)
    {
        this.array = array;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < array.Length)
        {
            Current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public sealed class ClassArrayWithFieldEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public ClassArrayWithFieldEnumerator(int[] array)
    {
        this.array = array;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < array.Length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public sealed class ClassArrayWithFieldNoBoundsCheckEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public ClassArrayWithFieldNoBoundsCheckEnumerator(int[] array)
    {
        this.array = array;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if ((uint)index < (uint)array.Length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public sealed class ClassArrayWithFieldLengthCacheEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private readonly int length;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public ClassArrayWithFieldLengthCacheEnumerator(int[] array)
    {
        this.array = array;
        length = array.Length;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public sealed class ClassArrayWithFieldLengthCacheNoBoundsCheckEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private readonly int length;
    private int current;
    private int index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public ClassArrayWithFieldLengthCacheNoBoundsCheckEnumerator(int[] array)
    {
        this.array = array;
        length = array.Length;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if ((uint)index < (uint)length)
        {
            current = array[index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}

public sealed class ClassArrayWithFieldLengthUnsignedCacheEnumerator : IEnumerator<int>
{
    private readonly int[] array;
    private readonly uint length;
    private int current;
    private uint index;

    public int Current => current;

    object IEnumerator.Current => Current;

    public ClassArrayWithFieldLengthUnsignedCacheEnumerator(int[] array)
    {
        this.array = array;
        length = (uint)array.Length;
    }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (index < length)
        {
            current = array[(int)index];
            index++;
            return true;
        }

        return false;
    }

    public void Reset() => throw new NotSupportedException();
}
#pragma warning restore CA1065
