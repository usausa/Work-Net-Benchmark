namespace ValueTaskBenchmark
{
    using System.Reflection;
    using System.Threading.Tasks;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);
        }
    }

    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MarkdownExporter.Default, MarkdownExporter.GitHub);
            Add(MemoryDiagnoser.Default);
            Add(Job.LongRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 10000;

        [Benchmark(OperationsPerInvoke = N)]
        public async Task TaskResult()
        {
            for (var i = 0; i < N; i++)
            {
                await DummyLogic.TaskResult();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public async ValueTask ValueTaskResult()
        {
            for (var i = 0; i < N; i++)
            {
                await DummyLogic.ValueTaskResult();
            }
        }
    }

    public static class DummyLogic
    {
        public static Task<int> TaskResult() => Task.FromResult(1);

        public static ValueTask<int> ValueTaskResult() => new ValueTask<int>(1);
    }
}
