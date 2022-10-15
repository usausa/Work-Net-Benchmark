namespace DecimalBitsBenchmark
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

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
            // decimal is LayoutKind.Sequential
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
    public class MethodTypeBenchmark
    {
        private const int N = 1000;

        private readonly int[] buffer = new int[4];

        private decimal value = -123.456m;

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public int[] GetBitsDefault()
        {
            for (var i = 0; i < N; i++)
            {
                var temp = Decimal.GetBits(value);
                Buffer.BlockCopy(temp, 0, buffer, 0, 16);
            }

            return buffer;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int[] GetBitsUnsafe()
        {
            for (var i = 0; i < N; i++)
            {
                var data = Unsafe.As<RawDecimalData>(value);
                buffer[0] = data.Lo;
                buffer[1] = data.Mid;
                buffer[2] = data.Hi;
                buffer[3] = data.Flags;
            }

            return buffer;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int[] GetBitsUnsafeWithoutCopy()
        {
            for (var i = 0; i < N; i++)
            {
                Unsafe.As<RawDecimalData>(value);
            }

            return buffer;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int[] GetBitsUnsafeCopy()
        {
            for (var i = 0; i < N; i++)
            {
                GetBitsUnsafe(value, buffer);
            }

            return buffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void GetBitsUnsafe(decimal value, int[] buffer)
        {
            Unsafe.CopyBlockUnaligned(Unsafe.AsPointer(ref value), Unsafe.AsPointer(ref buffer[0]), 16);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public sealed class RawDecimalData
    {
        public int Flags;
        public int Hi;
        public int Lo;
        public int Mid;
    }
}
