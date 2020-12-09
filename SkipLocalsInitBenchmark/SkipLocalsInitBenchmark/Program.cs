namespace SkipLocalsInitBenchmark
{
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
            AddJob(Job.LongRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        [Benchmark]
        [Arguments(4, 16, 64, 256, 1024, 2048)]
        public string InitCharSpan(int size) => Allocator.InitCharSpan(size);

        [Benchmark]
        [Arguments(4, 16, 64, 256, 1024, 2048)]
        public string SkipInitCharSpan(int size) => Allocator.SkipInitCharSpan(size);

        [Benchmark]
        public int InitInt() => Allocator.InitInt();

        [Benchmark]
        public int SkipInitInt() => Allocator.SkipInitInt();
    }

    public static unsafe class Allocator
    {
        public static string InitCharSpan(int length)
        {
            var buffer = stackalloc char[length];
            return new string(buffer);
        }

        [SkipLocalsInit]
        public static string SkipInitCharSpan(int length)
        {
            var buffer = stackalloc char[length];
            return new string(buffer);
        }

        public static int InitInt()
        {
            Out(out var value);
            return value;
        }

        [SkipLocalsInit]
        public static int SkipInitInt()
        {
            Out(out var value);
            return value;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void Out(out int value)
        {
            value = 0;
        }
    }
}
