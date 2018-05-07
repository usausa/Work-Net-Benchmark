namespace CopyBenchmark
{
    using System;
    using System.Runtime.CompilerServices;

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
            Add(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private byte[] source;

        private byte[] destination;

        [Params(4, 32, 64, 128, 1024)]
        public int Length { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            source = new byte[Length];
            destination = new byte[Length];
        }

        [Benchmark]
        public void ArrayCopy()
        {
            Array.Copy(source, 0, destination, 0, source.Length);
        }

        [Benchmark]
        public void BlockCopy()
        {
            Buffer.BlockCopy(source, 0, destination, 0, source.Length);
        }

        [Benchmark]
        public void MemoryCopy()
        {
            FastCopy(source, 0, destination, 0, source.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe void FastCopy(byte[] src, int srcOffset, byte[] dst, int dstOffset, int length)
        {
            if (length > 0)
            {
                fixed (byte* pSource = &src[srcOffset])
                fixed (byte* pDestination = &dst[dstOffset])
                {
                    Buffer.MemoryCopy(pSource, pDestination, length, length);
                }
            }
        }
    }
}
