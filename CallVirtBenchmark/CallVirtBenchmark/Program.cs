namespace CallVirtBenchmark
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
            AddJob(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 1000;

        [Benchmark(OperationsPerInvoke = N)]
        public void InvokerCallVirt()
        {
            for (var i = 0; i < N; i++)
            {
                var invoker = new Invoker();
                invoker.Invoke();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void InvokerCall()
        {
            for (var i = 0; i < N; i++)
            {
                new Invoker().Invoke();
            }
        }
    }

    public sealed class Invoker
    {
        public void Invoke()
        {
        }
    }
}
