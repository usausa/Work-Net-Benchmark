using System;
using System.Reflection.Emit;

namespace DispatchBenchmark
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

        private Func<int, int> dynamicFunc;
        private Func<int, int> directFunc;
        private delegate*<int, int> functionPointer;
        private IOperation iface;

        private bool flag;

        [GlobalSetup]
        public void Setup()
        {
            flag = true;

            functionPointer = &Increment;

            iface = new IncrementOperation();

            directFunc = x => x + 1;

            var method = new DynamicMethod("InstanceDelegate", typeof(int), new[] { typeof(object), typeof(int) }, true);
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Ldc_I4_1);
            il.Emit(OpCodes.Add);
            il.Emit(OpCodes.Ret);
            dynamicFunc = method.CreateDelegate<Func<int, int>>(null);
        }

        private static int Increment(int value) => value + 1;

        private static int Decrement(int value) => value - 1;

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public int IfStatic()
        {
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += flag ? Increment(i) : Decrement(i);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int FunctionPointer()
        {
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += functionPointer(i);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int Interface()
        {
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += iface.Process(i);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int DirectFunc()
        {
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += directFunc(i);
            }
            return result;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int DynamicFunc()
        {
            var result = 0;
            for (var i = 0; i < N; i++)
            {
                result += dynamicFunc(i);
            }
            return result;
        }
    }

    public interface IOperation
    {
        int Process(int value);
    }

    public sealed class IncrementOperation : IOperation
    {
        public int Process(int value) => value + 1;
    }

}
