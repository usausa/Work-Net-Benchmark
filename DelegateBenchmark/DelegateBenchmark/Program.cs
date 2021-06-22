using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DelegateBenchmark
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Columns;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    public static class Program
    {
        public static void Main()
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
        private const int N = 1000;

        private Func<int, int> sd;
        private Func<int, int> id;
        private delegate*<int, int> fp;
        private delegate*<int, int> sdfp;

        [GlobalSetup]
        public void Setup()
        {
            var method1 = new DynamicMethod("StaticDelegate", typeof(int), new[] { typeof(int) }, true);
            var il = method1.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Ret);
            sd = method1.CreateDelegate<Func<int, int>>();

            var method2 = new DynamicMethod("InstanceDelegate", typeof(int), new[] { typeof(object), typeof(int) }, true);
            il = method2.GetILGenerator();
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Ret);
            id = method2.CreateDelegate<Func<int, int>>(null);

            fp = &StaticFunction;

            var handle = (RuntimeMethodHandle)typeof(DynamicMethod).GetMethod("GetMethodDescriptor", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(method1, null);
            sdfp = (delegate*<int, int>)handle.GetFunctionPointer();
        }

        private static int StaticFunction(int value) => value + 1;

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public int StaticDelegate()
        {
            var func = sd;
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += func(i);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int InstanceDelegate()
        {
            var func = id;
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += func(i);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int FunctionPointer()
        {
            var func = fp;
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += func(i);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int DynamicMethodFunctionPointer()
        {
            var func = sdfp;
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += func(i);
            }
            return result;
        }
    }
}
