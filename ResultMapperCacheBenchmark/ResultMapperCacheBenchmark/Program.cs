using System;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ResultMapperCacheBenchmark
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);
        }
    }

    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MarkdownExporter.Default, MarkdownExporter.GitHub);
            Add(MemoryDiagnoser.Default);
            Add(Job.MediumRun);
            //Add(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]

    public class Benchmark
    {
        private const int N = 1000;

        private readonly Type targetType = typeof(Data);

        private readonly ClassFieldResultMapperCache classFieldCache = new ClassFieldResultMapperCache();

        private readonly ClassPropertyResultMapperCache classPropertyCache = new ClassPropertyResultMapperCache();

        private readonly StructFieldResultMapperCache structFieldCache = new StructFieldResultMapperCache();

        private readonly StructPropertyResultMapperCache structPropertyCache = new StructPropertyResultMapperCache();

        private readonly ClassFieldColumnInfo[] classFieldColumns =
        {
            new ClassFieldColumnInfo("Id", typeof(long)),
            new ClassFieldColumnInfo("Name", typeof(string)),
        };

        private readonly ClassPropertyColumnInfo[] classPropertyColumns =
        {
            new ClassPropertyColumnInfo("Id", typeof(long)),
            new ClassPropertyColumnInfo("Name", typeof(string)),
        };

        private readonly StructFieldColumnInfo[] structFieldColumns =
        {
            new StructFieldColumnInfo("Id", typeof(long)),
            new StructFieldColumnInfo("Name", typeof(string)),
        };

        private readonly StructPropertyColumnInfo[] structPropertyColumns =
        {
            new StructPropertyColumnInfo("Id", typeof(long)),
            new StructPropertyColumnInfo("Name", typeof(string)),
        };

        [GlobalSetup]
        public void Setup()
        {
            classFieldCache.AddIfNotExist(
                targetType,
                new Span<ClassFieldColumnInfo>(classFieldColumns, 0, classFieldColumns.Length),
                (t, c) => new object());
            classPropertyCache.AddIfNotExist(
                targetType,
                new Span<ClassPropertyColumnInfo>(classPropertyColumns, 0, classPropertyColumns.Length),
                (t, c) => new object());
            structFieldCache.AddIfNotExist(
                targetType,
                new Span<StructFieldColumnInfo>(structFieldColumns, 0, classFieldColumns.Length),
                (t, c) => new object());
            structPropertyCache.AddIfNotExist(
                targetType,
                new Span<StructPropertyColumnInfo>(structPropertyColumns, 0, classFieldColumns.Length),
                (t, c) => new object());
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ClassField()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                classFieldCache.TryGetValue(
                    targetType,
                    new Span<ClassFieldColumnInfo>(classFieldColumns, 0, classFieldColumns.Length),
                    out ret);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ClassProperty()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                classPropertyCache.TryGetValue(
                    targetType,
                    new Span<ClassPropertyColumnInfo>(classPropertyColumns, 0, classPropertyColumns.Length),
                    out ret);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object StructField()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                structFieldCache.TryGetValue(
                    targetType,
                    new Span<StructFieldColumnInfo>(structFieldColumns, 0, structFieldColumns.Length),
                    out ret);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object StructProperty()
        {
            object ret = null;
            for (var i = 0; i < N; i++)
            {
                structPropertyCache.TryGetValue(
                    targetType,
                    new Span<StructPropertyColumnInfo>(structPropertyColumns, 0, structPropertyColumns.Length),
                    out ret);
            }
            return ret;
        }
    }

    public class Data
    {
    }
}
