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
        private readonly List<int> listS = Enumerable.Range(1, 4).ToList();
        private readonly List<int> listM = Enumerable.Range(1, 32).ToList();
        private readonly List<int> listL = Enumerable.Range(1, 128).ToList();

        private readonly int[] arrayS = Enumerable.Range(1, 4).ToArray();
        private readonly int[] arrayM = Enumerable.Range(1, 32).ToArray();
        private readonly int[] arrayL = Enumerable.Range(1, 128).ToArray();

        // List

        [Benchmark]
        public int ForeachListS() => Loop.ForeachList(listS);

        [Benchmark]
        public int ForeachListEnumerableS() => Loop.ForeachEnumerable(listS);

        [Benchmark]
        public int EnumeratorListS() => Loop.EnumeratorList(listS);

        [Benchmark]
        public int EnumeratorEnumerableListS() => Loop.EnumeratorEnumerable(listS);

        [Benchmark]
        public int ForListS() => Loop.ForList(listS);

        [Benchmark]
        public int ForListGenericS() => Loop.ForListGeneric(listS);

        [Benchmark]
        public int ForIListListS() => Loop.ForIList(listS);

        [Benchmark]
        public int ForeachListM() => Loop.ForeachList(listM);

        [Benchmark]
        public int ForeachListEnumerableM() => Loop.ForeachEnumerable(listM);

        [Benchmark]
        public int EnumeratorListM() => Loop.EnumeratorList(listM);

        [Benchmark]
        public int EnumeratorEnumerableListM() => Loop.EnumeratorEnumerable(listM);

        [Benchmark]
        public int ForListM() => Loop.ForList(listM);

        [Benchmark]
        public int ForListGenericM() => Loop.ForListGeneric(listM);

        [Benchmark]
        public int ForIListListM() => Loop.ForIList(listM);

        [Benchmark]
        public int ForeachListL() => Loop.ForeachList(listL);

        [Benchmark]
        public int ForeachListEnumerableL() => Loop.ForeachEnumerable(listL);

        [Benchmark]
        public int EnumeratorListL() => Loop.EnumeratorList(listL);

        [Benchmark]
        public int EnumeratorEnumerableListL() => Loop.EnumeratorEnumerable(listL);

        [Benchmark]
        public int ForListL() => Loop.ForList(listL);

        [Benchmark]
        public int ForListGenericL() => Loop.ForListGeneric(listL);

        [Benchmark]
        public int ForIListListL() => Loop.ForIList(listL);

        // Array

        [Benchmark]
        public int ForeachArrayS() => Loop.ForeachArray(arrayS);

        [Benchmark]
        public int ForeachArrayEnumerableS() => Loop.ForeachEnumerable(arrayS);

        [Benchmark]
        public int EnumeratorEnumerableArrayS() => Loop.EnumeratorEnumerable(arrayS);

        [Benchmark]
        public int ForArrayS() => Loop.ForArray(arrayS);

        [Benchmark]
        public int ForIListArrayS() => Loop.ForIList(arrayS);

        [Benchmark]
        public int ForeachArrayM() => Loop.ForeachArray(arrayM);

        [Benchmark]
        public int ForeachArrayEnumerableM() => Loop.ForeachEnumerable(arrayM);

        [Benchmark]
        public int EnumeratorEnumerableArrayM() => Loop.EnumeratorEnumerable(arrayM);

        [Benchmark]
        public int ForArrayM() => Loop.ForArray(arrayM);

        [Benchmark]
        public int ForIListArrayM() => Loop.ForIList(arrayM);

        [Benchmark]
        public int ForeachArrayL() => Loop.ForeachArray(arrayL);

        [Benchmark]
        public int ForeachArrayEnumerableL() => Loop.ForeachEnumerable(arrayL);

        [Benchmark]
        public int EnumeratorEnumerableArrayL() => Loop.EnumeratorEnumerable(arrayL);

        [Benchmark]
        public int ForArrayL() => Loop.ForArray(arrayL);

        [Benchmark]
        public int ForIListArrayL() => Loop.ForIList(arrayL);

        // Span

        [Benchmark]
        public int ForeachSpanS() => Loop.ForeachSpan(arrayS);

        [Benchmark]
        public int ForeachReadOnlySpanS() => Loop.ForeachReadOnlySpan(arrayS);

        [Benchmark]
        public int ForeachSpanAsReadonlyS() => Loop.ForeachSpanAsReadonly(arrayS);

        [Benchmark]
        public int ForeachSpanEnumerableS() => Loop.ForeachEnumerable(arrayS);

        [Benchmark]
        public int EnumeratorEnumerableSpanS() => Loop.EnumeratorEnumerable(arrayS);

        [Benchmark]
        public int ForSpanS() => Loop.ForSpan(arrayS);

        [Benchmark]
        public int ForReadOnlySpanS() => Loop.ForReadOnlySpan(arrayS);

        [Benchmark]
        public int ForSpanAsReadOnlyS() => Loop.ForSpanAsReadOnly(arrayS);

        [Benchmark]
        public int ForeachSpanM() => Loop.ForeachSpan(arrayM);

        [Benchmark]
        public int ForeachReadOnlySpanM() => Loop.ForeachReadOnlySpan(arrayM);

        [Benchmark]
        public int ForeachSpanAsReadonlyM() => Loop.ForeachSpanAsReadonly(arrayM);

        [Benchmark]
        public int ForeachSpanEnumerableM() => Loop.ForeachEnumerable(arrayM);

        [Benchmark]
        public int EnumeratorEnumerableSpanM() => Loop.EnumeratorEnumerable(arrayM);

        [Benchmark]
        public int ForSpanM() => Loop.ForSpan(arrayM);

        [Benchmark]
        public int ForReadOnlySpanM() => Loop.ForReadOnlySpan(arrayM);

        [Benchmark]
        public int ForSpanAsReadOnlyM() => Loop.ForSpanAsReadOnly(arrayM);

        [Benchmark]
        public int ForeachSpanL() => Loop.ForeachSpan(arrayL);

        [Benchmark]
        public int ForeachReadOnlySpanL() => Loop.ForeachReadOnlySpan(arrayL);

        [Benchmark]
        public int ForeachSpanAsReadonlyL() => Loop.ForeachSpanAsReadonly(arrayL);

        [Benchmark]
        public int ForeachSpanEnumerableL() => Loop.ForeachEnumerable(arrayL);

        [Benchmark]
        public int EnumeratorEnumerableSpanL() => Loop.EnumeratorEnumerable(arrayL);

        [Benchmark]
        public int ForSpanL() => Loop.ForSpan(arrayL);

        [Benchmark]
        public int ForReadOnlySpanL() => Loop.ForReadOnlySpan(arrayL);

        [Benchmark]
        public int ForSpanAsReadOnlyL() => Loop.ForSpanAsReadOnly(arrayL);
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
