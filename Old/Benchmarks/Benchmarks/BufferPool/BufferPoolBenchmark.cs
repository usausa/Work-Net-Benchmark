namespace Benchmarks.BufferPool
{
    using System;
    using System.Buffers;

    using BenchmarkDotNet.Attributes;
    using Benchmarks.StandardLib.BufferPool;

    [Config(typeof(BenchmarkConfig))]
    public class BufferPoolBenchmark
    {
        private const int N = 1000;

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public int AlwaysNew()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = BufferPoolCoreFunction.AlwaysNew();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseArrayPool()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = BufferPoolCoreFunction.UseArrayPool();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseThreadLocal()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = BufferPoolCoreFunction.UseThreadLocal();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int AlwaysNewStandard()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = BufferPoolStandardFunctions.AlwaysNew();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseArrayPoolStandard()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = BufferPoolStandardFunctions.UseArrayPool();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseThreadLocalStandard()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = BufferPoolStandardFunctions.UseThreadLocal();
            }
            return ret;
        }
    }

    public static class BufferPoolCoreFunction
    {
        [ThreadStatic]
        private static byte[] threadLocalPool;

        public static int AlwaysNew()
        {
            var buffer = new byte[32];
            return UseSpan(buffer.AsSpan(0, 32));
        }

        public static int UseArrayPool()
        {
            var buffer = ArrayPool<byte>.Shared.Rent(32);
            var ret = UseSpan(buffer.AsSpan(0, 32));
            ArrayPool<byte>.Shared.Return(buffer);
            return ret;
        }

        public static int UseThreadLocal()
        {
            if ((threadLocalPool == null) || (threadLocalPool.Length < 32))
            {
                threadLocalPool = new byte[32];
            }

            return UseSpan(threadLocalPool.AsSpan(0, 32));
        }

        private static int UseSpan(Span<byte> buffer) => buffer.Length;
    }
}
