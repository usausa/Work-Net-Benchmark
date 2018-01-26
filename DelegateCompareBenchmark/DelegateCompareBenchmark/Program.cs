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
        private Func<object> callDirect;

        private Func<object> callStaticMethod;

        private Func<object> callInstanceMethod;

        private Func<object> callDynamic;

        [GlobalSetup]
        public void Setup()
        {
            callDirect = () => null;
            callStaticMethod = Caller.CallStaticMethod;
            var caller = new Caller();
            callInstanceMethod = caller.CallInstanceMethod;
            callDynamic = Generator.Create();
        }

        [Benchmark]
        public void CallDirect()
        {
            callDirect();
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

        [Benchmark]
        public void CallDynamic()
        {
            callDynamic();
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

    public static class Generator
    {
        public static Func<object> Create()
        {
            var dynamic = new DynamicMethod(string.Empty, typeof(object), new[] { typeof(object) }, true);
            var il = dynamic.GetILGenerator();

            il.Emit(OpCodes.Ldnull);
            il.Emit(OpCodes.Ret);

            return (Func<object>)dynamic.CreateDelegate(typeof(Func<object>), null);
        }
    }
}
