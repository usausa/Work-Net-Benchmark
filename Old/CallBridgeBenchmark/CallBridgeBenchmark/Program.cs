namespace CallBridgeBenchmark
{
    using System;
    using System.Reflection;

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
        private Func<object> provider1;

        private Func<object, object> provider2;

        private Func<object, object> provider3;

        [GlobalSetup]
        public void Setup()
        {
            provider1 = () => new object();
            provider2 = o => new object();
            provider3 = o => provider1();
        }

        [Benchmark]
        public object Provider1()
        {
            return provider1();
        }

        [Benchmark]
        public object Provider2()
        {
            return provider2(this);
        }

        [Benchmark]
        public object Provider3()
        {
            return provider3(this);
        }
    }
}
