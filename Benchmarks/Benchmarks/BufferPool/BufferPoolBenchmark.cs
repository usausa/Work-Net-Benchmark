namespace Benchmarks.BufferPool
{
    using System;
    using System.Buffers;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class BufferPoolBenchmark
    {
        private const int N = 1000;

        [ThreadStatic]
        private static byte[] threadLocalPool;

        [Benchmark(OperationsPerInvoke = N)]
        public int AlwaysNew()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                var buffer = new byte[32];
                ret = Function.UseSpan(buffer.AsSpan(0, 32));
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseArrayPool()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                var buffer = ArrayPool<byte>.Shared.Rent(32);
                ret = Function.UseSpan(buffer.AsSpan(0, 32));
                ArrayPool<byte>.Shared.Return(buffer);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseThreadLocal()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                if ((threadLocalPool == null) || (threadLocalPool.Length < 32))
                {
                    threadLocalPool = new byte[32];
                }

                ret = Function.UseSpan(threadLocalPool.AsSpan(0, 32));
            }
            return ret;
        }
    }

    public static class Function
    {
        public static int UseSpan(Span<byte> buffer) => buffer.Length;
    }
}
