using System;
using System.Collections.Generic;

namespace TypedInterfaceBenchmark
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
    public class Benchmark
    {
        private const int N = 1000;

        private readonly Resolver1 resolver1 = new();
        private readonly Resolver2 resolver2 = new();

        [Benchmark(OperationsPerInvoke = N)]
        public int Resolver1Int()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = resolver1.Get<int>();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string Resolver1String()
        {
            var ret = string.Empty;
            for (var i = 0; i < N; i++)
            {
                ret = resolver1.Get<string>();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int Resolver2Int()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = resolver2.Get<int>();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string Resolver2String()
        {
            var ret = string.Empty;
            for (var i = 0; i < N; i++)
            {
                ret = resolver2.Get<string>();
            }
            return ret;
        }
    }

    public class Resolver1
    {
        private readonly Dictionary<Type, Func<object>> factories = new();

        public Resolver1()
        {
            factories[typeof(int)] = () => 0;
            factories[typeof(string)] = () => string.Empty;
        }

        public T Get<T>()
        {
            return factories.TryGetValue(typeof(T), out var func) ? (T)func() : default;
        }
    }

    public class Resolver2
    {
        private readonly Dictionary<Type, object> factories = new();

        public Resolver2()
        {
            factories[typeof(int)] = (Func<int>)(() => 0);
            factories[typeof(string)] = (Func<string>)(() => string.Empty);
        }

        public T Get<T>()
        {
            return factories.TryGetValue(typeof(T), out var func) ? ((Func<T>)func)() : default;
        }
    }
}
