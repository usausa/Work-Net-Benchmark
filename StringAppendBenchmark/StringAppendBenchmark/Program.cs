namespace StringAppendBenchmark
{
    using System;
    using System.Buffers;
    using System.Runtime.CompilerServices;
    using System.Text;

    using BenchmarkDotNet.Attributes;
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
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 1000;

        private readonly string token40 = new string('A', 40);
        private readonly string token20 = new string('B', 20);
        private readonly string token10 = new string('C', 10);
        private readonly string token400 = new string('A', 400);
        private readonly string token200 = new string('B', 200);
        private readonly string token100 = new string('C', 100);

        private readonly bool conditionA = true;
        private readonly bool conditionB = true;
        private readonly bool conditionB2 = true;
        private readonly bool conditionB3 = true;
        private readonly bool conditionB4 = true;

        // Len32Add1

        [Benchmark(OperationsPerInvoke = N)]
        public string StringLen32Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                ret = token20;
                if (conditionA)
                {
                    ret += token10;
                }
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string StringBuilderLen32Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new StringBuilder(32);
                sb.Append(token20);
                if (conditionA)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PoolBufferLen32Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                using var sb = new PoolBuffer(32);
                sb.Append(token20);
                if (conditionA)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string ThreadStaticBufferLen32Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new ThreadStaticBuffer(32);
                sb.Append(token20);
                if (conditionA)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        // Len64Add1

        [Benchmark(OperationsPerInvoke = N)]
        public string StringLen64Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                ret = token40;
                if (conditionA)
                {
                    ret += token20;
                }
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string StringBuilderLen64Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new StringBuilder(64);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PoolBufferLen64Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                using var sb = new PoolBuffer(64);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string ThreadStaticBufferLen64Add1()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new ThreadStaticBuffer(64);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        // Len128Add2

        [Benchmark(OperationsPerInvoke = N)]
        public string StringLen128Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                ret = token40;
                if (conditionA)
                {
                    ret += token20;
                }
                if (conditionB)
                {
                    ret += token10;
                }
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string StringBuilderLen128Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new StringBuilder(128);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                if (conditionB)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PoolBufferLen128Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                using var sb = new PoolBuffer(128);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                if (conditionB)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string ThreadStaticBufferLen128Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new ThreadStaticBuffer(128);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                if (conditionB)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        // Len128Add5

        [Benchmark(OperationsPerInvoke = N)]
        public string StringLen128Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                ret = token40;
                if (conditionA)
                {
                    ret += token20;
                }
                if (conditionB)
                {
                    ret += token10;
                }
                if (conditionB2)
                {
                    ret += token10;
                }
                if (conditionB3)
                {
                    ret += token10;
                }
                if (conditionB4)
                {
                    ret += token10;
                }
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string StringBuilderLen128Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new StringBuilder(128);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                if (conditionB)
                {
                    sb.Append(token10);
                }
                if (conditionB2)
                {
                    sb.Append(token10);
                }
                if (conditionB3)
                {
                    sb.Append(token10);
                }
                if (conditionB4)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PoolBufferLen128Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                using var sb = new PoolBuffer(128);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                if (conditionB)
                {
                    sb.Append(token10);
                }
                if (conditionB2)
                {
                    sb.Append(token10);
                }
                if (conditionB3)
                {
                    sb.Append(token10);
                }
                if (conditionB4)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string ThreadStaticBufferLen128Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new ThreadStaticBuffer(128);
                sb.Append(token40);
                if (conditionA)
                {
                    sb.Append(token20);
                }
                if (conditionB)
                {
                    sb.Append(token10);
                }
                if (conditionB2)
                {
                    sb.Append(token10);
                }
                if (conditionB3)
                {
                    sb.Append(token10);
                }
                if (conditionB4)
                {
                    sb.Append(token10);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        // Len1024Add2

        [Benchmark(OperationsPerInvoke = N)]
        public string StringLen1024Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                ret = token400;
                if (conditionA)
                {
                    ret += token200;
                }
                if (conditionB)
                {
                    ret += token100;
                }
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string StringBuilderLen1024Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new StringBuilder(1024);
                sb.Append(token400);
                if (conditionA)
                {
                    sb.Append(token200);
                }
                if (conditionB)
                {
                    sb.Append(token100);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PoolBufferLen1024Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                using var sb = new PoolBuffer(1024);
                sb.Append(token400);
                if (conditionA)
                {
                    sb.Append(token200);
                }
                if (conditionB)
                {
                    sb.Append(token100);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string ThreadStaticBufferLen1024Add2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new ThreadStaticBuffer(1024);
                sb.Append(token400);
                if (conditionA)
                {
                    sb.Append(token200);
                }
                if (conditionB)
                {
                    sb.Append(token100);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        // Len1024Add5

        [Benchmark(OperationsPerInvoke = N)]
        public string StringLen1024Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                ret = token400;
                if (conditionA)
                {
                    ret += token200;
                }
                if (conditionB)
                {
                    ret += token100;
                }
                if (conditionB2)
                {
                    ret += token100;
                }
                if (conditionB3)
                {
                    ret += token100;
                }
                if (conditionB4)
                {
                    ret += token100;
                }
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string StringBuilderLen1024Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new StringBuilder(1024);
                sb.Append(token400);
                if (conditionA)
                {
                    sb.Append(token200);
                }
                if (conditionB)
                {
                    sb.Append(token100);
                }
                if (conditionB2)
                {
                    sb.Append(token100);
                }
                if (conditionB3)
                {
                    sb.Append(token100);
                }
                if (conditionB4)
                {
                    sb.Append(token100);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PoolBufferLen1024Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                using var sb = new PoolBuffer(1024);
                sb.Append(token400);
                if (conditionA)
                {
                    sb.Append(token200);
                }
                if (conditionB)
                {
                    sb.Append(token100);
                }
                if (conditionB2)
                {
                    sb.Append(token100);
                }
                if (conditionB3)
                {
                    sb.Append(token100);
                }
                if (conditionB4)
                {
                    sb.Append(token100);
                }
                ret = sb.ToString();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string ThreadStaticBufferLen1024Add5()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var sb = new ThreadStaticBuffer(1024);
                sb.Append(token400);
                if (conditionA)
                {
                    sb.Append(token200);
                }
                if (conditionB)
                {
                    sb.Append(token100);
                }
                if (conditionB2)
                {
                    sb.Append(token100);
                }
                if (conditionB3)
                {
                    sb.Append(token100);
                }
                if (conditionB4)
                {
                    sb.Append(token100);
                }
                ret = sb.ToString();
            }
            return ret;
        }
    }

    public struct PoolBuffer : IDisposable
    {
        private char[] buffer;

        private int index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PoolBuffer(int length)
        {
            buffer = ArrayPool<char>.Shared.Rent(length);
            index = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            ArrayPool<char>.Shared.Return(buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(string value)
        {
            var length = value.Length;
            if (buffer.Length - index < length)
            {
                var newSize = Math.Max(buffer.Length * 2, buffer.Length - index + length);
                var newBuffer = ArrayPool<char>.Shared.Rent(newSize);
                buffer.AsSpan(0, index).CopyTo(newBuffer.AsSpan());
                ArrayPool<char>.Shared.Return(buffer);
                buffer = newBuffer;
            }

            value.AsSpan().CopyTo(buffer.AsSpan(index));
            index += length;
        }

        public override string ToString()
        {
            return new string(buffer, 0, index);
        }
    }

    public struct ThreadStaticBuffer
    {
        [ThreadStatic]
        private static char[] buffer;

        private int index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ThreadStaticBuffer(int length)
        {
            if ((buffer is null) || (buffer.Length < length))
            {
                buffer = new char[length];
            }
            index = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(string value)
        {
            var length = value.Length;
            if (buffer.Length - index < length)
            {
                var newSize = Math.Max(buffer.Length * 2, buffer.Length - index + length);
                var newBuffer = new char[newSize];
                buffer.AsSpan(0, index).CopyTo(newBuffer.AsSpan());
                buffer = newBuffer;
            }

            value.AsSpan().CopyTo(buffer.AsSpan(index));
            index += length;
        }

        public override string ToString()
        {
            return new string(buffer, 0, index);
        }
    }
}
