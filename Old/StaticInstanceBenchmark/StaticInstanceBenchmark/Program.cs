namespace StaticInstanceBenchmark
{
    using System;
    using System.Runtime.CompilerServices;

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
            Add(Job.MediumRun);
        }
    }

    public static class StaticFactory
    {
        public static object Create() => new object();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInline() => new object();
    }

    public class InstanceFactory
    {
        public object Create() => new object();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public object CreateInline() => new object();
    }

    public interface IFactory
    {
        object Create();
    }

    public class VirtualFactory : IFactory
    {
        public object Create() => new object();
    }

    public class VirtualInlineFactory : IFactory
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public object Create() => new object();
    }

    public sealed class SealedFactory : IFactory
    {
        public object Create() => new object();
    }

    public sealed class SealedInlineFactory : IFactory
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public object Create() => new object();
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private InstanceFactory instanceFactory;

        private IFactory virtualFactory;

        private IFactory virtualInlineFactory;

        private IFactory sealedFactory;

        private IFactory sealedInlineFactory;

        private Func<object> directDelegate;

        private Func<object> staticDelegate;

        private Func<object> staticInlineDelegate;

        private Func<object> instanceDelegate;

        private Func<object> instanceInlineDelegate;

        private Func<object> virtualDelegate;

        private Func<object> virtualInlineDelegate;

        private Func<object> sealedDelegate;

        private Func<object> sealedInlineDelegate;

        [GlobalSetup]
        public void Setup()
        {
            instanceFactory = new InstanceFactory();
            virtualFactory = new VirtualFactory();
            virtualInlineFactory = new VirtualInlineFactory();
            sealedFactory = new SealedFactory();
            sealedInlineFactory = new SealedInlineFactory();

            directDelegate = () => new object();
            staticDelegate = StaticFactory.Create;
            staticInlineDelegate = StaticFactory.CreateInline;
            instanceDelegate = instanceFactory.Create;
            instanceInlineDelegate = instanceFactory.CreateInline;
            virtualDelegate = virtualFactory.Create;
            virtualInlineDelegate = virtualInlineFactory.Create;
            sealedDelegate = sealedFactory.Create;
            sealedInlineDelegate = sealedInlineFactory.Create;
        }

        [Benchmark]
        public object FactoryStatic() => StaticFactory.Create();

        [Benchmark]
        public object FactoryStaticInline() => StaticFactory.CreateInline();

        [Benchmark]
        public object FactoryInstance() => instanceFactory.Create();

        [Benchmark]
        public object FactoryInstanceInline() => instanceFactory.CreateInline();

        [Benchmark]
        public object FactoryVirtual() => virtualFactory.Create();

        [Benchmark]
        public object FactoryVirtualInline() => virtualFactory.Create();

        [Benchmark]
        public object FactorySealed() => sealedFactory.Create();

        [Benchmark]
        public object FactorySealedInline() => sealedFactory.Create();

        [Benchmark]
        public object DelegateDirect() => directDelegate();

        [Benchmark]
        public object DelegateStatic() => staticDelegate();

        [Benchmark]
        public object DelegateStaticInline() => staticInlineDelegate();

        [Benchmark]
        public object DelegateInstance() => instanceDelegate();

        [Benchmark]
        public object DelegateInstanceInline() => instanceInlineDelegate();

        [Benchmark]
        public object DelegateVirtual() => virtualDelegate();

        [Benchmark]
        public object DelegateVirtualInline() => virtualInlineDelegate();

        [Benchmark]
        public object DelegateSealed() => sealedDelegate();

        [Benchmark]
        public object DelegateSealedInline() => sealedInlineDelegate();
    }
}
