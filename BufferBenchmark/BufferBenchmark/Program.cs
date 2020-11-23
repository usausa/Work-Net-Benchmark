namespace BufferBenchmark
{
    using System.Buffers;

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
        [Benchmark]
        [BenchmarkCategory("32", "New")]
        public int New32() => CharBufferOperator.New(32);

        [Benchmark]
        [BenchmarkCategory("32", "StackOrNew")]
        public int StackOrNew32() => CharBufferOperator.StackOrNew(32);

        [Benchmark]
        [BenchmarkCategory("32", "StackOrPool")]
        public int StackOrPool32() => CharBufferOperator.StackOrPool(32);

        [Benchmark]
        [BenchmarkCategory("256", "New")]
        public int New256() => CharBufferOperator.New(256);

        [Benchmark]
        [BenchmarkCategory("256", "StackOrNew")]
        public int StackOrNew256() => CharBufferOperator.StackOrNew(256);

        [Benchmark]
        [BenchmarkCategory("256", "StackOrPool")]
        public int StackOrPool256() => CharBufferOperator.StackOrPool(256);

        [Benchmark]
        [BenchmarkCategory("1024", "New")]
        public int New1024() => CharBufferOperator.New(1024);

        [Benchmark]
        [BenchmarkCategory("1024", "StackOrNew")]
        public int StackOrNew1024() => CharBufferOperator.StackOrNew(1024);

        [Benchmark]
        [BenchmarkCategory("1024", "StackOrPool")]
        public int StackOrPool1024() => CharBufferOperator.StackOrPool(1024);

        [Benchmark]
        [BenchmarkCategory("2048", "New")]
        public int New2048() => CharBufferOperator.New(2048);

        [Benchmark]
        [BenchmarkCategory("2048", "StackOrNew")]
        public int StackOrNew2048() => CharBufferOperator.StackOrNew(2048);

        [Benchmark]
        [BenchmarkCategory("2048", "StackOrPool")]
        public int StackOrPool2048() => CharBufferOperator.StackOrPool(2048);
    }

    public static class CharBufferOperator
    {
        public static int New(int size)
        {
            var buffer = new char[size];
            return buffer.Length;
        }

        public static unsafe int StackOrNew(int size)
        {
            var buffer = size < 2048 ? stackalloc char[size] : new char[size];
            return buffer.Length;
        }

        public static unsafe int StackOrPool(int size)
        {
            var pool = default(char[]);
            var buffer = size < 2048 ? stackalloc char[size] : (pool = ArrayPool<char>.Shared.Rent(size));
            var ret = buffer.Length;
            if (pool != null)
            {
                ArrayPool<char>.Shared.Return(pool);
            }
            return ret;
        }
    }
}
