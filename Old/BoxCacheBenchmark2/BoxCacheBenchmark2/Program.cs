namespace BoxCacheBenchmark2
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

        [Benchmark(OperationsPerInvoke = N)]
        public object IntToBool1()
        {
            object value = default;
            for (var i = 0; i < N; i++)
            {
                value = Converter.IntToBool1(1);
            }

            return value;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object IntToBool2()
        {
            object value = default;
            for (var i = 0; i < N; i++)
            {
                value = Converter.IntToBool2(1);
            }

            return value;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object BoolToInt1()
        {
            object value = default;
            for (var i = 0; i < N; i++)
            {
                value = Converter.BoolToInt1(true);
            }

            return value;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object BoolToInt2()
        {
            object value = default;
            for (var i = 0; i < N; i++)
            {
                value = Converter.BoolToInt2(true);
            }

            return value;
        }
    }

    public static class Converter
    {
        private static readonly object BoolFalse = false;
        private static readonly object BoolTrue = true;

        private static readonly object IntFalse = 0;
        private static readonly object IntTrue = 1;

        public static object IntToBool1(object value) => (int)value != default;

        public static object BoolToInt1(object value) => (bool)value ? 1 : 0;

        public static object IntToBool2(object value) => (int)value != default ? BoolTrue : BoolFalse;

        public static object BoolToInt2(object value) => (bool)value ? IntTrue : IntFalse;
    }
}
