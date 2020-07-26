namespace CallBenchmark50
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;
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
            AddJob(Job.LongRun);
        }
    }

    public static class StaticFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInline() => new object();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateNoInline() => new object();
    }

    public class InstanceFactory
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object CreateInline() => new object();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public object CreateNoInline() => new object();
    }

    public interface IFactory
    {
        object Create();
    }

    public class InterfaceFactory : IFactory
    {
        public object Create() => new object();
    }

    public sealed class InterfaceSealedFactory : IFactory
    {
        public object Create() => new object();
    }

    public static class DynamicFactoryGenerator
    {
        public static Func<object> CreateStaticActivator()
        {
            var dynamic = new DynamicMethod(string.Empty, typeof(object), Type.EmptyTypes, true);
            var il = dynamic.GetILGenerator();

            il.Emit(OpCodes.Newobj, typeof(object).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Ret);

            return (Func<object>)dynamic.CreateDelegate(typeof(Func<object>));
        }

        public static Func<object> CreateInstanceActivator()
        {
            var dynamic = new DynamicMethod(string.Empty, typeof(object), new[] { typeof(object) }, true);
            var il = dynamic.GetILGenerator();

            il.Emit(OpCodes.Newobj, typeof(object).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Ret);

            return (Func<object>)dynamic.CreateDelegate(typeof(Func<object>));
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public unsafe class Benchmark
    {
        private const int N = 1000;

        private InstanceFactory instanceFactory;

        private IFactory interfaceFactory;
        private IFactory interfaceSealedFactory;

        private Func<object> directDelegate;
        private Func<object> staticDelegate;
        private Func<object> instanceDelegate;
        private Func<object> interfaceDelegate;

        private Func<object> staticEmitDelegate;
        private Func<object> instanceEmitDelegate;

        private delegate*<object> pointerStatic;

        [GlobalSetup]
        public void Setup()
        {
            instanceFactory = new InstanceFactory();
            interfaceFactory = new InterfaceFactory();
            interfaceSealedFactory = new InterfaceSealedFactory();

            directDelegate = () => new object();
            staticDelegate = StaticFactory.CreateInline;
            instanceDelegate = instanceFactory.CreateInline;
            interfaceDelegate = interfaceFactory.Create;

            staticEmitDelegate = DynamicFactoryGenerator.CreateStaticActivator();
            instanceEmitDelegate = DynamicFactoryGenerator.CreateInstanceActivator();

            pointerStatic = &StaticFactory.CreateInline;
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
        public object CallStaticNoInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = StaticFactory.CreateNoInline();
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

        [Benchmark(OperationsPerInvoke = N)]
        public object CallInstanceNoInline()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = instanceFactory.CreateNoInline();
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
        public object InterfaceSealed()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceSealedFactory.Create();
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
        public object DelegateInterface()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = interfaceDelegate();
            }
            return ret;
        }

        // Emit

        [Benchmark(OperationsPerInvoke = N)]
        public object EmitStatic()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = staticEmitDelegate();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object EmitInstance()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                ret = instanceEmitDelegate();
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
    }
}
