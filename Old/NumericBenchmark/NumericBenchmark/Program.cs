namespace NumericBenchmark
{
    using System.Numerics;

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
            Add(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const uint UIntValue9 = 1000000000;

        private const ulong ULongValue9 = 1000000000;

        private static readonly BigInteger BigIntegerValue9 = 1000000000;

        private const ulong ULongValue19 = 10000000000000000000;

        private static readonly BigInteger BigIntegerValue19 = 10000000000000000000;

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public uint IntMul9()
        {
            var value = 1U;
            for (var i = 0; i < 9; i++)
            {
                value *= 10;
            }

            return value;
        }

        [Benchmark]
        public ulong LongMul9()
        {
            var value = 1UL;
            for (var i = 0; i < 9; i++)
            {
                value *= 10;
            }

            return value;
        }

        [Benchmark]
        public BigInteger BigIntegerMul9()
        {
            var value = BigInteger.One;
            for (var i = 0; i < 9; i++)
            {
                value *= 10;
            }

            return value;
        }

        [Benchmark]
        public uint IntDiv9()
        {
            var value = UIntValue9;
            for (var i = 0; i < 9; i++)
            {
                value /= 10;
            }

            return value;
        }

        [Benchmark]
        public ulong LongDiv9()
        {
            var value = ULongValue9;
            for (var i = 0; i < 9; i++)
            {
                value /= 10;
            }

            return value;
        }

        [Benchmark]
        public BigInteger BigIntegerDiv9()
        {
            var value = BigIntegerValue9;
            for (var i = 0; i < 9; i++)
            {
                value /= 10;
            }

            return value;
        }

        [Benchmark]
        public ulong LongMul19()
        {
            var value = 1UL;
            for (var i = 0; i < 19; i++)
            {
                value *= 10;
            }

            return value;
        }

        [Benchmark]
        public BigInteger BigIntegerMul19()
        {
            var value = BigInteger.One;
            for (var i = 0; i < 19; i++)
            {
                value *= 10;
            }

            return value;
        }

        [Benchmark]
        public ulong LongDiv19()
        {
            var value = ULongValue19;
            for (var i = 0; i < 19; i++)
            {
                value /= 10;
            }

            return value;
        }

        [Benchmark]
        public BigInteger BigIntegerDiv19()
        {
            var value = BigIntegerValue19;
            for (var i = 0; i < 19; i++)
            {
                value /= 10;
            }

            return value;
        }
    }
}
