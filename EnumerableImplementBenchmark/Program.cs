namespace EnumerableImplementBenchmark;

using System.Collections;
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
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private const int N = 1000;

    [Benchmark(OperationsPerInvoke = N)]
    public void Net73Struct()
    {
        for (var i = 0; i < N; i++)
        {
            var range = new Net73RangeEnumerable(1, 10);
            foreach (var n in range)
            {
            }
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Struct()
    {
        for (var i = 0; i < N; i++)
        {
            var range = new StructRangeEnumerable(1, 10);
            foreach (var n in range)
            {
            }
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Class()
    {
        for (var i = 0; i < N; i++)
        {
            var range = new ClassRangeEnumerable(1, 10);
            foreach (var n in range)
            {
            }
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public void Yield()
    {
        for (var i = 0; i < N; i++)
        {
            foreach (var n in Range(1, 10))
            {
            }
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static IEnumerable<int> Range(int start, int count)
    {
        var end = start + count;
        for (var i = start; i < end; i++)
        {
            yield return i;
        }
    }
}
#pragma warning restore CA1822

#pragma warning disable CA1815

// Net73

public struct Net73RangeEnumerator
{
    private readonly int end;
    private int current;

    public Net73RangeEnumerator(int start, int count)
    {
        end = start + count - 1;
        current = start - 1;
    }

    public int Current => current;

    public bool MoveNext()
    {
        if (current < end)
        {
            current++;
            return true;
        }
        return false;
    }
}

public readonly struct Net73RangeEnumerable
{
    private readonly int start;
    private readonly int count;

    public Net73RangeEnumerable(int start, int count)
    {
        this.start = start;
        this.count = count;
    }

    public Net73RangeEnumerator GetEnumerator() => new(start, count);
}

// Struct

public struct StructRangeEnumerator : IEnumerator<int>
{
    private readonly int end;
    private int current;

    public StructRangeEnumerator(int start, int count)
    {
        end = start + count - 1;
        current = start - 1;
    }

    public int Current => current;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (current < end)
        {
            current++;
            return true;
        }
        return false;
    }

    public void Reset() => throw new NotSupportedException();

    public void Dispose()
    {
    }
}

public class StructRangeEnumerable : IEnumerable<int>
{
    private readonly int start;
    private readonly int count;

    public StructRangeEnumerable(int start, int count)
    {
        this.start = start;
        this.count = count;
    }

    public StructRangeEnumerator GetEnumerator() => new(start, count);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Class

public struct ClassRangeEnumerator : IEnumerator<int>
{
    private readonly int end;
    private int current;

    public ClassRangeEnumerator(int start, int count)
    {
        end = start + count - 1;
        current = start - 1;
    }

    public int Current => current;

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (current < end)
        {
            current++;
            return true;
        }
        return false;
    }

    public void Reset() => throw new NotSupportedException();

    public void Dispose()
    {
    }
}

public class ClassRangeEnumerable : IEnumerable<int>
{
    private readonly int start;
    private readonly int count;

    public ClassRangeEnumerable(int start, int count)
    {
        this.start = start;
        this.count = count;
    }

    public ClassRangeEnumerator GetEnumerator() => new(start, count);

    IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
