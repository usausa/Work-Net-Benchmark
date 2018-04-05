namespace CreateBenchmark
{
    using System;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    using Smart.Reflection;

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

    public static class Factory<T> where T : new()
    {
        public static T Create()
        {
            return new T();
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private Func<object> factory;

        private Func<object[], object> factory2;

        [GlobalSetup]
        public void Setup()
        {
            factory = DelegateFactory.Default.CreateFactory0(typeof(Data).GetConstructors()[0]);
            factory2 = DelegateFactory.Default.CreateFactory(typeof(Data).GetConstructors()[0]);
        }

        private Data Create1()
        {
            return new Data();
        }

        private static Data Create2()
        {
            return new Data();
        }

        [Benchmark]
        public Data NewRaw()
        {
            return new Data();
        }

        [Benchmark]
        public Data NewIndirect1()
        {
            return Create1();
        }

        [Benchmark]
        public Data NewIndirect2()
        {
            return Create2();
        }

        [Benchmark]
        public Data NewConstraint()
        {
            return Factory<Data>.Create();
        }

        [Benchmark]
        public Data Factory()
        {
            return (Data)factory();
        }

        [Benchmark]
        public Data Factory2()
        {
            return (Data)factory2(null);
        }
    }
}
