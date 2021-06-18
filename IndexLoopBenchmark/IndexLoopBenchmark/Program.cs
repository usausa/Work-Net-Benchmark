namespace IndexLoopBenchmark
{
    using System.Collections.Generic;
    using System.Linq;
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

        [Params(4, 16, 64, 256, 1024)]
        public int Size { get; set; }

        private string[] array;
        private List<string> list;

        [GlobalSetup]
        public void Setup()
        {
            array = Enumerable.Range(1, Size).Select(x => x.ToString()).ToArray();
            list = Enumerable.Range(1, Size).Select(x => x.ToString()).ToList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Dummy(string value, int index)
        {
        }

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
}
