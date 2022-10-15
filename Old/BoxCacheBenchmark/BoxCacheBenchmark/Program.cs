using System;

namespace BoxCacheBenchmark
{
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
            AddJob(Job.LongRun);
        }
    }

        [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 1000;

        [Params(0, 1, -1, Int32.MaxValue)]
        public int Value { get; set; }

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public object BasicBox()
        {
            object value = default;
            for (var i = 0; i < N; i++)
            {
                value = Converter.BasicBox(Value);
            }

            return value;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object CachedBox()
        {
            object value = default;
            for (var i = 0; i < N; i++)
            {
                value = Converter.CachedBox(Value);
            }

            return value;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object CachedBox2()
        {
            object value = default;
            for (var i = 0; i < N; i++)
            {
                value = Converter.CachedBox2(Value);
            }

            return value;
        }
    }

    public static class Converter
    {
        public static object BasicBox(int value) => value;

        private static readonly object Int0 = 0;
        private static readonly object Int1 = 1;
        private static readonly object IntMinus1= -1;

        public static object CachedBox(int value)
        {
            if (value == 0)
            {
                return Int0;
            }

            if (value == 1)
            {
                return Int1;
            }

            if (value == -1)
            {
                return IntMinus1;
            }

            return value;
        }

        public static object CachedBox2(int value)
        {
            if (value == 0)
            {
                return Int0;
            }

            if (value == 1)
            {
                return Int1;
            }

            return value;
        }
    }
}
