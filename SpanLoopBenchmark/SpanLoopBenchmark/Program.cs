using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpanLoopBenchmark
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
            AddJob(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        [Params(4, 8, 16, 32, 64, 128, 256)]
        public int Size { get; set; }

        private byte[] bytes;
        private int[] numbers;

        [GlobalSetup]
        public void Setup()
        {
            bytes = Enumerable.Range(0, Size).Reverse().Select(x => (byte)x).ToArray();
            numbers = Enumerable.Range(0, Size).Reverse().ToArray();
        }

        [Benchmark]
        public int FindByte() => Helper.Find(bytes, 0);

        [Benchmark]
        public int UnsafeFindByte() => Helper.UnsafeFind(bytes, 0);

        [Benchmark]
        public int FindInt() => Helper.Find(numbers, 0);

        [Benchmark]
        public int UnsafeFindInt() => Helper.UnsafeFind(numbers, 0);
    }

    public static class Helper
    {
        public static int Find(ReadOnlySpan<int> span, int value)
        {
            for (var i = 0; i < span.Length; i++)
            {
                if (span[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int Find(ReadOnlySpan<byte> span, byte value)
        {
            for (var i = 0; i < span.Length; i++)
            {
                if (span[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int UnsafeFind(ReadOnlySpan<int> span, int value)
        {
            ref var start = ref MemoryMarshal.GetReference(span);
            ref var end = ref Unsafe.Add(ref start, span.Length);

            var i = 0;
            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                if (start == value)
                {
                    return i;
                }

                start = ref Unsafe.Add(ref start, 1);
                i++;
            }

            return -1;
        }

        public static int UnsafeFind(ReadOnlySpan<byte> span, byte value)
        {
            ref var start = ref MemoryMarshal.GetReference(span);
            ref var end = ref Unsafe.Add(ref start, span.Length);

            var i = 0;
            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                if (start == value)
                {
                    return i;
                }

                start = ref Unsafe.Add(ref start, 1);
                i++;
            }

            return -1;
        }
    }
}
