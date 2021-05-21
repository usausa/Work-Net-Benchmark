namespace ListCapacityBenchmark
{
    using System.Collections.Generic;

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
            AddJob(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        [Benchmark]
        public void Default()
        {
            var _ = new List<string>();
        }

        [Benchmark]
        public void Capacity1()
        {
            var _ = new List<string>(1);
        }

        [Benchmark]
        public void Capacity2()
        {
            var _ = new List<string>(2);
        }

        [Benchmark]
        public void DefaultAdd1()
        {
            var _ = new List<string>
            {
                null
            };
        }

        [Benchmark]
        public void Capacity1Add1()
        {
            var _ = new List<string>(1)
            {
                null
            };
        }

        [Benchmark]
        public void Capacity2Add1()
        {
            var _ = new List<string>(2)
            {
                null
            };
        }

        [Benchmark]
        public void DefaultAdd2()
        {
            var _ = new List<string>(1)
            {
                null, null
            };
        }

        [Benchmark]
        public void Capacity1Add2()
        {
            var _ = new List<string>(1)
            {
                null, null
            };
        }

        [Benchmark]
        public void Capacity2Add2()
        {
            var _ = new List<string>(2)
            {
                null, null
            };
        }

        [Benchmark]
        public void DefaultAdd3()
        {
            var _ = new List<string>
            {
                null, null, null
            };
        }

        [Benchmark]
        public void Capacity1Add3()
        {
            var _ = new List<string>(1)
            {
                null, null, null
            };
        }

        [Benchmark]
        public void Capacity2Add3()
        {
            var _ = new List<string>(2)
            {
                null, null, null
            };
        }
    }
}
