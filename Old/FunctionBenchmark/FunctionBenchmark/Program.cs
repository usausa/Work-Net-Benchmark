namespace FunctionBenchmark
{
    using System;
    using System.Reflection.Emit;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Columns;
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
    public unsafe class Benchmark
    {
        private Func<int, int, bool> staticFunction;
        private Func<int, int, bool> instanceFunction;
        private Func<int, int, bool> dynamicStaticFunction;
        private Func<int, int, bool> dynamicInstanceFunction;
        private delegate*<int, int, bool> pointerFunction;

        [GlobalSetup]
        public void Setup()
        {
            var obj = new InstanceFunction();
            staticFunction = Function.IsSame;
            instanceFunction = obj.IsSame;
            pointerFunction = &Function.IsSame;

            var method3 = new DynamicMethod(string.Empty, typeof(bool), new[] { typeof(int), typeof(int) }, true);
            var il3 = method3.GetILGenerator();
            il3.Emit(OpCodes.Ldarg_0);
            il3.Emit(OpCodes.Ldarg_1);
            il3.Emit(OpCodes.Ceq);
            il3.Emit(OpCodes.Ret);
            dynamicStaticFunction = method3.CreateDelegate<Func<int, int, bool>>();

            var method4 = new DynamicMethod(string.Empty, typeof(bool), new[] { typeof(object), typeof(int), typeof(int) }, true);
            var il4 = method4.GetILGenerator();
            il4.Emit(OpCodes.Ldarg_1);
            il4.Emit(OpCodes.Ldarg_2);
            il4.Emit(OpCodes.Ceq);
            il4.Emit(OpCodes.Ret);
            dynamicInstanceFunction = method4.CreateDelegate<Func<int, int, bool>>(null);
        }

        [Benchmark]
        public bool Static() => staticFunction(1, 1);

        [Benchmark]
        public bool Instance() => instanceFunction(1, 1);

        [Benchmark]
        public bool DynamicStatic() => dynamicStaticFunction(1, 1);

        [Benchmark]
        public bool DynamicInstance() => dynamicInstanceFunction(1, 1);

        [Benchmark]
        public bool Pointer() => pointerFunction(1, 1);
    }

    public static class Function
    {
        public static bool IsSame(int x, int y) => x == y;
    }

    public class InstanceFunction
    {
        public bool IsSame(int x, int y) => x == y;
    }
}
