namespace DelegateCompareBenchmark
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MarkdownExporter.Default, MarkdownExporter.GitHub);
            Add(MemoryDiagnoser.Default);
            Add(Job.ShortRun);
        }
    }

    public class Data
    {
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private Func<object> callStaticMethod;

        private Func<object> callInstanceMethod;

        [GlobalSetup]
        public void Setup()
        {
            callStaticMethod = Caller.CallStaticMethod;
            var caller = new Caller();
            callInstanceMethod = caller.CallInstanceMethod;
        }

        [Benchmark]
        public void CallStaticMethod()
        {
            callStaticMethod();
        }

        [Benchmark]
        public void CallInstanceMethod()
        {
            callInstanceMethod();
        }
    }

    public class Caller
    {
        public static object CallStaticMethod()
        {
            return null;
        }

        public object CallInstanceMethod()
        {
            return null;
        }
    }
}
