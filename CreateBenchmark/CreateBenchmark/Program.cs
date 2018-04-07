namespace CreateBenchmark
{
    using System;
    using System.Runtime.CompilerServices;

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

    public class InstanceDataFactory
    {
        public object Create()
        {
            return new Data();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object CreateInline()
        {
            return new Data();
        }
    }

    public static class StaticDataFactory
    {
        public static object Create()
        {
            return new Data();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInline()
        {
            return new Data();
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly InstanceDataFactory o = new InstanceDataFactory();

        private Func<object> instanceFactory;

        private Func<object> instanceInlineFactory;

        private Func<object> staticFactory;

        private Func<object> staticInlineFactory;

        private Func<object> delegateFactory1;

        private Func<object[], object> delegateFactory2;

        [GlobalSetup]
        public void Setup()
        {
            instanceFactory = o.Create;
            instanceInlineFactory = o.CreateInline;
            staticFactory = StaticDataFactory.Create;
            staticInlineFactory = StaticDataFactory.CreateInline;

            delegateFactory1 = DelegateFactory.Default.CreateFactory0(typeof(Data).GetConstructors()[0]);
            delegateFactory2 = DelegateFactory.Default.CreateFactory(typeof(Data).GetConstructors()[0]);
        }

        // Raw

        [Benchmark]
        public object Raw()
        {
            return new Data();
        }

        // Class

        [Benchmark]
        public object DirectInstanceFactory()
        {
            return o.Create();
        }

        [Benchmark]
        public object DirectInstanceFactoryInline()
        {
            return o.CreateInline();
        }

        [Benchmark]
        public object DirectStaticFactory()
        {
            return StaticDataFactory.Create();
        }

        [Benchmark]
        public object DirectStaticFactoryInline()
        {
            return StaticDataFactory.CreateInline();
        }

        // Func

        [Benchmark]
        public object InstanceFactory()
        {
            return instanceFactory();
        }

        [Benchmark]
        public object InstanceFactoryInline()
        {
            return instanceInlineFactory();
        }

        [Benchmark]
        public object StaticFactory()
        {
            return staticFactory();
        }

        [Benchmark]
        public object StaticFactoryInline()
        {
            return staticInlineFactory();
        }

        // Delegate

        [Benchmark]
        public object DelegateFactory1()
        {
            return delegateFactory1();
        }

        [Benchmark]
        public object DelegateFactory2()
        {
            return delegateFactory2(null);
        }

        // Delegate with cast

        [Benchmark]
        public Data DelegateFactory1WithCast()
        {
            return (Data)delegateFactory1();
        }

        [Benchmark]
        public Data DelegateFactory2WithCast()
        {
            return (Data)delegateFactory2(null);
        }
    }
}
