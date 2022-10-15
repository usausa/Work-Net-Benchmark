using System.Linq.Expressions;

namespace ConvertMethodBenchmark
{
    using System;
    using System.Reflection.Emit;
    using System.Runtime.CompilerServices;

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
    public class Benchmark
    {
        private const int N = 1000;

        private readonly Func<long, int> direct = Factory.ByDirect();
        private readonly Func<long, int> method = Factory.ByMethod();
        private readonly Func<long, int> expression = Factory.ByExpression();

        [Benchmark]
        public int Direct()
        {
            var ret = 0;
            var f = direct;
            for (var i = 0; i < N; i++)
            {
                ret = f(-1);
            }

            return ret;
        }

        [Benchmark]
        public int Method()
        {
            var ret = 0;
            var f = method;
            for (var i = 0; i < N; i++)
            {
                ret = f(-1);
            }

            return ret;
        }

        [Benchmark]
        public int Expression()
        {
            var ret = 0;
            var f = expression;
            for (var i = 0; i < N; i++)
            {
                ret = f(-1);
            }

            return ret;
        }
    }

    public static class Factory
    {
        public static Func<long, int> ByDirect()
        {
            var dynamicMethod = new DynamicMethod(string.Empty, typeof(int), new[] { typeof(object), typeof(long) }, true);
            var ilGenerator = dynamicMethod.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Conv_I4);
            ilGenerator.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate<Func<long, int>>(null);
        }

        public static Func<long, int> ByMethod()
        {
            var dynamicMethod = new DynamicMethod(string.Empty, typeof(int), new[] { typeof(object), typeof(long) }, true);
            var ilGenerator = dynamicMethod.GetILGenerator();

            var method = typeof(ConvertMethods).GetMethod("Int64ToInt32");
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, method);
            ilGenerator.Emit(OpCodes.Ret);

            return dynamicMethod.CreateDelegate<Func<long, int>>(null);
        }

        public static Func<long, int> ByExpression()
        {
            var arg = Expression.Parameter(typeof(long), "value");
            var method = typeof(ConvertMethods).GetMethod("Int64ToInt32");
            var body = Expression.Call(method, arg);
            var lambda = Expression.Lambda<Func<long, int>>(body, arg);
            return lambda.Compile();
        }
    }

    public static class ConvertMethods
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Int64ToInt32(long value) => (int)value;
    }
}
