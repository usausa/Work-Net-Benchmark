namespace SortBenchmark;

using System.Buffers;
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

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private readonly int[] source = new int[1024];
    private readonly int[] buffer = new int[1024];

    [GlobalSetup]
    public void GlobalSetup()
    {
        var rand = new Random();
        for (var i = 0; i < source.Length; i++)
        {
#pragma warning disable CA5394
            source[i] = rand.Next();
#pragma warning restore CA5394
        }
    }

    [IterationSetup]
    public void IterationSetup()
    {
        source.AsSpan().CopyTo(buffer);
    }

    [Benchmark]
    public void BySort()
    {
        buffer.AsSpan().Sort();
    }

    [Benchmark]
    public void ByMergeSort()
    {
        buffer.AsSpan().MergeSort();
    }
}

public static class MemoryExtensions
{
    public static void MergeSort<T>(this Span<T> span)
        where T : IComparable<T>
    {
        if (span.Length <= 1)
        {
            return;
        }

        var buffer = ArrayPool<T>.Shared.Rent(span.Length);
        var temp = buffer.AsSpan(0, span.Length);
        span.CopyTo(temp);
        MergeSortRecursive(span, temp, 0, span.Length - 1);
        ArrayPool<T>.Shared.Return(buffer);
    }

    private static void MergeSortRecursive<T>(Span<T> span, Span<T> temp, int left, int right)
        where T : IComparable<T>
    {
        if (left < right)
        {
            var middle = (left + right) / 2;
            MergeSortRecursive(span, temp, left, middle);
            MergeSortRecursive(span, temp, middle + 1, right);
            Merge(span, temp, left, middle, right);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Merge<T>(Span<T> span, Span<T> temp, int left, int middle, int right)
        where T : IComparable<T>
    {
        var leftEnd = middle;
        var rightStart = middle + 1;
        var size = right - left + 1;

        var leftIndex = left;
        var rightIndex = rightStart;
        var index = left;

        while ((leftIndex <= leftEnd) && (rightIndex <= right))
        {
            if (span[leftIndex].CompareTo(span[rightIndex]) <= 0)
            {
                temp[index] = span[leftIndex];
                leftIndex++;
            }
            else
            {
                temp[index] = span[rightIndex];
                rightIndex++;
            }
            index++;
        }

        span.Slice(leftIndex, leftEnd - leftIndex + 1).CopyTo(temp[index..]);
        span.Slice(rightIndex, right - rightIndex + 1).CopyTo(temp[(index + (leftEnd - leftIndex + 1))..]);

        temp.Slice(left, size).CopyTo(span[left..]);
    }
}
