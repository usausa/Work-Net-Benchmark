namespace Benchmarks.StandardLib.BufferPool
{
    using System;
    using System.Buffers;

    public static class BufferPoolStandardFunctions
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
