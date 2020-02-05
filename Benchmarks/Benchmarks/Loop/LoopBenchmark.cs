namespace Benchmarks.Loop
{
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class LoopBenchmark
    {
        private readonly List<int> list = Enumerable.Range(1, 10).Select(x => x).ToList();

        private readonly IList<int> iList = Enumerable.Range(1, 10).Select(x => x).ToList();

        private readonly int[] array = Enumerable.Range(1, 10).Select(x => x).ToArray();

        private readonly IList<int> iArray = Enumerable.Range(1, 10).Select(x => x).ToArray();

        [Benchmark]
        public int ForList()
        {
            var total = 0;
            for (var i = 0; i < list.Count; i++)
            {
                total += list[i];
            }

            return total;
        }

        [Benchmark]
        public int ForIList()
        {
            var total = 0;
            for (var i = 0; i < iList.Count; i++)
            {
                total += iList[i];
            }

            return total;
        }

        [Benchmark]
        public int ForArray()
        {
            var total = 0;
            for (var i = 0; i < array.Length; i++)
            {
                total += array[i];
            }

            return total;
        }

        [Benchmark]
        public int ForIArray()
        {
            var total = 0;
            for (var i = 0; i < iArray.Count; i++)
            {
                total += iArray[i];
            }

            return total;
        }

        [Benchmark]
        public int ForEachList()
        {
            var total = 0;
            foreach (var value in list)
            {
                total += value;
            }

            return total;
        }

        [Benchmark]
        public int ForEachIList()
        {
            var total = 0;
            foreach (var value in iList)
            {
                total += value;
            }

            return total;
        }

        [Benchmark]
        public int ForEachArray()
        {
            var total = 0;
            foreach (var value in array)
            {
                total += value;
            }

            return total;
        }

        [Benchmark]
        public int ForEachIArray()
        {
            var total = 0;
            foreach (var value in iArray)
            {
                total += value;
            }

            return total;
        }

        [Benchmark]
        public int EnumeratorList()
        {
            var total = 0;
            using (var en = list.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    total += en.Current;
                }
            }

            return total;
        }

        [Benchmark]
        public int EnumeratorIList()
        {
            var total = 0;
            using (var en = iList.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    total += en.Current;
                }
            }

            return total;
        }

        [Benchmark]
        public int EnumeratorIArray()
        {
            var total = 0;
            using (var en = iArray.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    total += en.Current;
                }
            }

            return total;
        }
    }
}
