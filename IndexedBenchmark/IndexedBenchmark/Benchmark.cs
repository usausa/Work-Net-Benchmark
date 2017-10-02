namespace IndexedBenchmark
{
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly List<int> list = Enumerable.Range(1, 10).ToList();

        private readonly int[] array = Enumerable.Range(1, 10).ToArray();

        [GlobalSetup]
        public void Setup()
        {
        }

        // Array

        [Benchmark]
        public int ArrayFor()
        {
            var sum = 0;
            for (var i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        [Benchmark]
        public int ArrayIndexedList()
        {
            var sum = 0;
            foreach (var indexed in array.IndexedList())
            {
                sum += indexed.Item;
            }
            return sum;
        }

        [Benchmark]
        public int ArrayIndexedArray()
        {
            var sum = 0;
            foreach (var indexed in array.IndexedArray())
            {
                sum += indexed.Item;
            }
            return sum;
        }

        [Benchmark]
        public int ArrayIndexedEnumerable()
        {
            var sum = 0;
            foreach (var indexed in array.IndexedEnumerable())
            {
                sum += indexed.Item;
            }
            return sum;
        }

        [Benchmark]
        public int ArraySelect()
        {
            var sum = 0;
            foreach (var indexed in array.Select((x, i) => new Indexed<int>(x, i)))
            {
                sum += indexed.Item;
            }
            return sum;
        }

        // List

        [Benchmark]
        public int ListFor()
        {
            var sum = 0;
            for (var i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        [Benchmark]
        public int ListIndexedList()
        {
            var sum = 0;
            foreach (var indexed in list.IndexedList())
            {
                sum += indexed.Item;
            }
            return sum;
        }

        [Benchmark]
        public int ListIndexedEnumerable()
        {
            var sum = 0;
            foreach (var indexed in list.IndexedEnumerable())
            {
                sum += indexed.Item;
            }
            return sum;
        }

        [Benchmark]
        public int ListSelect()
        {
            var sum = 0;
            foreach (var indexed in list.Select((x, i) => new Indexed<int>(x, i)))
            {
                sum += indexed.Item;
            }
            return sum;
        }
    }
}
