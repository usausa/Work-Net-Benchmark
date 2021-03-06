﻿using System;
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
        public int UnsafeForFindByte() => Helper.UnsafeForFind(bytes, 0);

        [Benchmark]
        public int UnsafeWhileFindByte() => Helper.UnsafeWhileFind(bytes, 0);

        [Benchmark]
        public int PointerForFindByte() => Helper.PointerForFind(bytes, 0);

        [Benchmark]
        public int PointerWhileFindByte() => Helper.PointerWhileFind(bytes, 0);

        [Benchmark]
        public int FindInt() => Helper.Find(numbers, 0);

        [Benchmark]
        public int UnsafeForFindInt() => Helper.UnsafeForFind(numbers, 0);

        [Benchmark]
        public int UnsafeWhileFindInt() => Helper.UnsafeWhileFind(numbers, 0);

        [Benchmark]
        public int PointerForFindInt() => Helper.PointerForFind(numbers, 0);

        [Benchmark]
        public int PointerWhileFindInt() => Helper.PointerWhileFind(numbers, 0);
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

        public static int UnsafeForFind(ReadOnlySpan<byte> span, byte value)
        {
            ref var reference = ref MemoryMarshal.GetReference(span);

            for (var i = 0; i < span.Length; i++)
            {
                if (Unsafe.Add(ref reference, i) == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int UnsafeForFind(ReadOnlySpan<int> span, int value)
        {
            ref var reference = ref MemoryMarshal.GetReference(span);

            for (var i = 0; i < span.Length; i++)
            {
                if (Unsafe.Add(ref reference, i) == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int UnsafeWhileFind(ReadOnlySpan<int> span, int value)
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

        public static int UnsafeWhileFind(ReadOnlySpan<byte> span, byte value)
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

        public static unsafe int PointerForFind(ReadOnlySpan<int> span, int value)
        {
            fixed (int* ptr = span)
            {
                var p = ptr;
                for (var i = 0; i < span.Length; i++)
                {
                    if (*p == value)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

        public static unsafe int PointerForFind(ReadOnlySpan<byte> span, byte value)
        {
            fixed (byte* ptr = span)
            {
                var p = ptr;
                for (var i = 0; i < span.Length; i++)
                {
                    if (*p == value)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

        public static unsafe int PointerWhileFind(ReadOnlySpan<int> span, int value)
        {
            fixed (int* ptr = span)
            {
                var p = ptr;
                var pEnd = ptr + span.Length;
                var i = 0;
                while (p < pEnd)
                {
                    if (*p == value)
                    {
                        return i;
                    }

                    p++;
                    i++;
                }

                return -1;
            }
        }

        public static unsafe int PointerWhileFind(ReadOnlySpan<byte> span, byte value)
        {
            fixed (byte* ptr = span)
            {
                var p = ptr;
                var pEnd = ptr + span.Length;
                var i = 0;
                while (p < pEnd)
                {
                    if (*p == value)
                    {
                        return i;
                    }

                    p++;
                    i++;
                }

                return -1;
            }
        }
    }
}
