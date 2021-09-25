namespace ContainerConverterBenchmark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

    // IE fast LINQ
    // List/IList fast 2
    // IList / List 20%?
    // with source check equal ?
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
            AddColumn(
                StatisticColumn.Mean,
                StatisticColumn.Min,
                StatisticColumn.Max,
                StatisticColumn.P90,
                StatisticColumn.Error,
                StatisticColumn.StdDev);
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 1000;

        private long[] array;

        private List<long> list;

        [Params(0, 4, 16, 32, 64)]
        //[Params(4)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
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
            var source = list;
            Func<long, int> f = Convert;
            for (var i = 0; i < N; i++)
            {
                ContainerConverter.IEnumerableToArray(source, f);
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void IEnumerableToArray2()
        {
            var source = list;
            Func<long, int> f = Convert;
            for (var i = 0; i < N; i++)
            {
                ContainerConverter.IEnumerableToArray2(source, f);
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
            var source = list;
            Func<long, int> f = Convert;
            for (var i = 0; i < N; i++)
            {
                ContainerConverter.IEnumerableToList(source, f);
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void IEnumerableToList2()
        {
            var source = list;
            Func<long, int> f = Convert;
            for (var i = 0; i < N; i++)
            {
                ContainerConverter.IEnumerableToList2(source, f);
            }
        }
    }

    public static class ContainerConverter
    {
        public static TDestination[] ArrayToArray<TSource, TDestination>(TSource[] source, Func<TSource, TDestination> converter)
        {
            var array = new TDestination[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                var value = source[i];
                array[i] = value is not null ? converter(value) : default;
            }
            return array;
        }

        // TSourceがstructなら最適化するからvalue is not null不要かどうかの検証用
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

        // TSourceがNullable用バージョン
        public static TDestination[] NullableArrayToArray<TSource, TDestination>(TSource?[] source, Func<TSource, TDestination> converter)
            where TSource : struct
        {
            var array = new TDestination[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                var value = source[i];
                array[i] = value.HasValue ? converter(value.Value) : default;
            }
            return array;
        }

        //public static TDestination?[] ArrayToNullableArray<TSource, TDestination>(TSource[] source, Func<TSource, TDestination> converter)
        //    where TDestination : struct
        //{
        //    var array = new TDestination?[source.Length];
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        var value = source[i];
        //        array[i] = value is not null ? converter(value) : default;
        //
        //    }

        //    return array;
        //}

        //public static TDestination?[] NullableArrayToNullableArray<TSource, TDestination>(TSource?[] source, Func<TSource, TDestination> converter)
        //    where TSource : struct
        //    where TDestination : struct
        //{
        //    var array = new TDestination?[source.Length];
        //    for (var i = 0; i < source.Length; i++)
        //    {
        //        var value = source[i];
        //        array[i] = value is not null ? converter(value) : default;
        //    }

        //    return array;
        //}

        public static TDestination[] ListToArray<TSource, TDestination>(List<TSource> source, Func<TSource, TDestination> converter)
        {
            var array = new TDestination[source.Count];
            for (var i = 0; i < source.Count; i++)
            {
                var value = source[i];
                array[i] = value is not null ? converter(value) : default;
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
                array[i] = value is not null ? converter(value) : default;
            }
            return array;
        }

        public static TDestination[] IListToArray<TSource, TDestination>(IList<TSource> source, Func<TSource, TDestination> converter)
        {
            var array = new TDestination[source.Count];
            for (var i = 0; i < source.Count; i++)
            {
                var value = source[i];
                array[i] = value is not null ? converter(value) : default;
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
                array[i] = value is not null ? converter(value) : default;
            }
            return array;
        }

        public static TDestination[] IEnumerableToArray<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
        {
            return source.Select(x => x is not null ? converter(x) : default).ToArray();
        }

        public static TDestination[] IEnumerableToArray2<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
        {
            var list = new List<TDestination>();
            foreach (var value in source)
            {
                list.Add(value is not null ? converter(value) : default);
            }
            return list.ToArray();
        }

        // IReadOnlyList, IList, ICollection, IEnumerable ...
        public static List<TDestination> ArrayToList<TSource, TDestination>(TSource[] source, Func<TSource, TDestination> converter)
        {
            var list = new List<TDestination>(source.Length);
            for (var i = 0; i < source.Length; i++)
            {
                var value = source[i];
                list.Add(value is not null ? converter(value) : default);
            }
            return list;
        }

        public static List<TDestination> ListToList<TSource, TDestination>(List<TSource> source, Func<TSource, TDestination> converter)
        {
            var list = new List<TDestination>(source.Count);
            for (var i = 0; i < source.Count; i++)
            {
                var value = source[i];
                list.Add(value is not null ? converter(value) : default);
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
                list.Add(value is not null ? converter(value) : default);
            }
            return list;
        }

        public static List<TDestination> IListToList<TSource, TDestination>(IList<TSource> source, Func<TSource, TDestination> converter)
        {
            var list = new List<TDestination>(source.Count);
            for (var i = 0; i < source.Count; i++)
            {
                var value = source[i];
                list.Add(value is not null ? converter(value) : default);
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
                list.Add(value is not null ? converter(value) : default);
            }
            return list;
        }

        public static List<TDestination> IEnumerableToList<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
        {
            return source.Select(x => x is not null ? converter(x) : default).ToList();
        }

        public static List<TDestination> IEnumerableToList2<TSource, TDestination>(IEnumerable<TSource> source, Func<TSource, TDestination> converter)
        {
            var list = new List<TDestination>();
            foreach (var value in source)
            {
                list.Add(value is not null ? converter(value) : default);
            }
            return list;
        }
    }
}
