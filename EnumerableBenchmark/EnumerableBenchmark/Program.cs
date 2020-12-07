namespace EnumerableBenchmark
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using BenchmarkDotNet.Attributes;
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
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
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

        // List

        [Benchmark]
        public int ForeachList() => Loop.ForeachList(list);

        [Benchmark]
        public int ForeachListEnumerable() => Loop.ForeachEnumerable(list);

        [Benchmark]
        public int EnumeratorList() => Loop.EnumeratorList(list);

        [Benchmark]
        public int EnumeratorEnumerableList() => Loop.EnumeratorEnumerable(list);

        [Benchmark]
        public int ForList() => Loop.ForList(list);

        [Benchmark]
        public int ForListGeneric() => Loop.ForListGeneric(list);

        [Benchmark]
        public int ForIListList() => Loop.ForIList(list);

        // Array

        [Benchmark]
        public int ForeachArray() => Loop.ForeachArray(array);

        [Benchmark]
        public int ForeachArrayEnumerable() => Loop.ForeachEnumerable(array);

        [Benchmark]
        public int EnumeratorEnumerableArray() => Loop.EnumeratorEnumerable(array);

        [Benchmark]
        public int ForArray() => Loop.ForArray(array);

        [Benchmark]
        public int ForIListArray() => Loop.ForIList(array);

        // Span

        [Benchmark]
        public int ForeachSpan() => Loop.ForeachSpan(array);

        [Benchmark]
        public int ForeachReadOnlySpan() => Loop.ForeachReadOnlySpan(array);

        [Benchmark]
        public int ForeachSpanAsReadonly() => Loop.ForeachSpanAsReadonly(array);

        [Benchmark]
        public int ForeachSpanEnumerable() => Loop.ForeachEnumerable(array);

        [Benchmark]
        public int EnumeratorEnumerableSpan() => Loop.EnumeratorEnumerable(array);

        [Benchmark]
        public int ForSpan() => Loop.ForSpan(array);

        [Benchmark]
        public int ForReadOnlySpan() => Loop.ForReadOnlySpan(array);

        [Benchmark]
        public int ForSpanAsReadOnly() => Loop.ForSpanAsReadOnly(array);
    }

    public static class Loop
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
}
