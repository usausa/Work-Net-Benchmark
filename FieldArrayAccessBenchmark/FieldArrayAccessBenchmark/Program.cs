namespace FieldArrayAccessBenchmark
{
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

        [Params(0, 1, 2, 4, 8, 16, 32, 64, 256, 1024)]
        public int Size { get; set; }

        private int[] valueArray;

        private string[] classArray;

        [GlobalSetup]
        public void Setup()
        {
            valueArray = Enumerable.Range(0, Size).ToArray();
            classArray = Enumerable.Range(0, Size).Select(x => x.ToString()).ToArray();
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int ValueNoLocal()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                var hash = 0;
                for (var j = 0; j < valueArray.Length; j++)
                {
                    hash = hash ^ valueArray[j].GetHashCode();
                }
                ret = hash;
            }

            return ret;
        }


        [Benchmark(OperationsPerInvoke = N)]
        public int ValueLocal()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                var hash = 0;
                var array = valueArray;
                for (var j = 0; j < array.Length; j++)
                {
                    hash = hash ^ array[j].GetHashCode();
                }
                ret = hash;
            }

            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int ClassNoLocal()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                var hash = 0;
                for (var j = 0; j < classArray.Length; j++)
                {
                    hash = hash ^ classArray[j].GetHashCode();
                }
                ret = hash;
            }

            return ret;
        }


        [Benchmark(OperationsPerInvoke = N)]
        public int ClassLocal()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                var hash = 0;
                var array = classArray;
                for (var j = 0; j < array.Length; j++)
                {
                    hash = hash ^ array[j].GetHashCode();
                }
                ret = hash;
            }

            return ret;
        }
    }
}
