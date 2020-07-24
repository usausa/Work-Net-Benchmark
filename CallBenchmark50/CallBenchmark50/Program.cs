namespace CallBenchmark50
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
            AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.MediumRun);
            //AddJob(Job.LongRun);
        }
    }

    public static class StaticFactory
    {
        public static object Create() => new object();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInline() => new object();
    }

    public class InstanceFactory
    {
        public object Create() => new object();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object CreateInline() => new object();
    }

    public interface IFactory
    {
        object Create();
    }

    public class InterfaceFactory : IFactory
    {
        public object Create() => new object();
    }

    public class InterfaceInlineFactory : IFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Create() => new object();
    }

    public sealed class InterfaceSealedFactory : IFactory
    {
        public object Create() => new object();
    }

    public sealed class InterfaceSealedInlineFactory : IFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Create() => new object();
    }

    [Config(typeof(BenchmarkConfig))]
    public unsafe class Benchmark
    {
        private const int N = 1000;

        private InstanceFactory instanceFactory;

        private IFactory interfaceFactory;
        private IFactory interfaceInlineFactory;
        private IFactory interfaceSealedFactory;
        private IFactory interfaceSealedInlineFactory;

        private Func<object> directDelegate;
        private Func<object> staticDelegate;
        private Func<object> staticInlineDelegate;
        private Func<object> instanceDelegate;
        private Func<object> instanceInlineDelegate;
        private Func<object> interfaceDelegate;
        private Func<object> interfaceInlineDelegate;
        private Func<object> interfaceSealedDelegate;
        private Func<object> interfaceSealedInlineDelegate;

        private delegate*<object> pointerStatic;
        private delegate*<object> pointerStaticInline;

        [GlobalSetup]
        public void Setup()
        {
            instanceFactory = new InstanceFactory();
            interfaceFactory = new InterfaceFactory();
            interfaceInlineFactory = new InterfaceInlineFactory();
            interfaceSealedFactory = new InterfaceSealedFactory();
            interfaceSealedInlineFactory = new InterfaceSealedInlineFactory();

            directDelegate = () => new object();
            staticDelegate = StaticFactory.Create;
            staticInlineDelegate = StaticFactory.CreateInline;
            instanceDelegate = instanceFactory.Create;
            instanceInlineDelegate = instanceFactory.CreateInline;
            interfaceDelegate = interfaceFactory.Create;
            interfaceInlineDelegate = interfaceInlineFactory.Create;
            interfaceSealedDelegate = interfaceSealedFactory.Create;
            interfaceSealedInlineDelegate = interfaceSealedInlineFactory.Create;

            pointerStatic = &StaticFactory.Create;
            pointerStaticInline = &StaticFactory.CreateInline;
        }

        // Direct

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public object Direct()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = new object();
            }
            return ret;
        }

        // Call

        [Benchmark(OperationsPerInvoke = N)]
        public object CallStatic()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = StaticFactory.Create();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object CallStaticInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = StaticFactory.CreateInline();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object CallInstance()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = instanceFactory.Create();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object CallInstanceInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = instanceFactory.CreateInline();
            }
            return ret;
        }

        // Interface

        [Benchmark(OperationsPerInvoke = N)]
        public object Interface()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceFactory.Create();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object InterfaceInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceInlineFactory.Create();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object InterfaceSealed()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceSealedFactory.Create();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object InterfaceSealedInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceSealedInlineFactory.Create();
            }
            return ret;
        }

        // Delegate

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateDirect()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = directDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateStatic()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = staticDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateStaticInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = staticInlineDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateInstance()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = instanceDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateInstanceInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = instanceInlineDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateInterface()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateInterfaceInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceInlineDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateInterfaceSealed()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceSealedDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object DelegateInterfaceSealedInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceSealedInlineDelegate();
            }
            return ret;
        }

        // Pointer

        [Benchmark(OperationsPerInvoke = N)]
        public object PointerStatic()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = pointerStatic();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object PointerStaticInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = pointerStaticInline();
            }
            return ret;
        }
    }
}
