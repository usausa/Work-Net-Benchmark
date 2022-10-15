using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace StringBuilderBenchmark
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
            AddJob(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 1000;

        private static readonly string Value1 = new(' ', 100);
        private static readonly string Value2 = new(' ', 50);
        private static readonly string Value3 = new(' ', 25);
        private static readonly string Value4 = new(' ', 25);

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public string DefaultStringBuilder()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var buffer = new StringBuilder(256);
                buffer.Append(Value1);
                buffer.Append(Value2);
                buffer.Append(Value3);
                buffer.Append(Value4);
                ret = buffer.ToString();
            }

            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PooledStringBuilder()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var buffer = new PooledBufferStringBuilder(256);
                buffer.Append(Value1);
                buffer.Append(Value2);
                buffer.Append(Value3);
                buffer.Append(Value4);
                ret = buffer.ToString();
            }

            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PooledStringBuilder2()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var buffer = new PooledBufferStringBuilder2(256);
                buffer.Append(Value1);
                buffer.Append(Value2);
                buffer.Append(Value3);
                buffer.Append(Value4);
                ret = buffer.ToString();
            }

            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string PooledStringBuilder3()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var buffer = new PooledBufferStringBuilder3(256);
                buffer.Append(Value1);
                buffer.Append(Value2);
                buffer.Append(Value3);
                buffer.Append(Value4);
                ret = buffer.ToString();
            }

            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public string ValueStringBuilderSimple()
        {
            var ret = default(string);
            for (var i = 0; i < N; i++)
            {
                var buffer = new PooledBufferStringBuilder(256);
                buffer.Append(Value1);
                buffer.Append(Value2);
                buffer.Append(Value3);
                buffer.Append(Value4);
                ret = buffer.ToString();
            }

            return ret;
        }
    }

    public struct PooledBufferStringBuilder
    {
        [ThreadStatic]
        private static char[] buffer;

        public int Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PooledBufferStringBuilder(int length)
        {
            if ((buffer is null) || (buffer.Length < length))
            {
                buffer = new char[length];
            }
            Length = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append<T>(T value)
        {
            Append(value!.ToString()!.AsSpan());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ReadOnlySpan<char> value)
        {
            var length = value.Length;
            if (buffer!.Length - Length < length)
            {
                var newSize = Math.Max(buffer.Length * 2, buffer.Length - Length + length);
                var newBuffer = new char[newSize];
                buffer.AsSpan(0, Length).CopyTo(newBuffer.AsSpan());
                buffer = newBuffer;
            }

            value.CopyTo(buffer.AsSpan(Length));
            Length += length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return new(buffer!, 0, Length);
        }
    }

    public struct PooledBufferStringBuilder2
    {
        [ThreadStatic]
        private static char[] buffer;

        public int Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PooledBufferStringBuilder2(int length)
        {
            if ((buffer is null) || (buffer.Length < length))
            {
                buffer = new char[length];
            }
            Length = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append<T>(T value)
        {
            Append(value!.ToString()!.AsSpan());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ReadOnlySpan<char> value)
        {
            var length = Length;
            if (length > buffer!.Length - value.Length)
            {
                Grow(value.Length);
            }

            value.CopyTo(buffer.AsSpan(length));
            Length += value.Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Grow(int additional)
        {
            var newSize = Math.Max(buffer.Length * 2, buffer.Length - Length + additional);
            var newBuffer = new char[newSize];
            buffer.AsSpan(0, Length).CopyTo(newBuffer.AsSpan());
            buffer = newBuffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return new(buffer!, 0, Length);
        }
    }

    public struct PooledBufferStringBuilder3
    {
        [ThreadStatic]
        private static char[] bufferCashe;

        private char[] buffer;

        public int Length;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PooledBufferStringBuilder3(int length)
        {
            if ((bufferCashe is null) || (bufferCashe.Length < length))
            {
                bufferCashe = new char[length];
            }

            buffer = bufferCashe;
            Length = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append<T>(T value)
        {
            Append(value!.ToString()!.AsSpan());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ReadOnlySpan<char> value)
        {
            var length = Length;
            var buff = buffer;
            if (length > buff!.Length - value.Length)
            {
                Grow(value.Length);
            }

            value.CopyTo(buff.AsSpan(length));
            Length += value.Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Grow(int additional)
        {
            var buff = buffer;
            var newSize = Math.Max(buff.Length * 2, buff.Length - Length + additional);
            var newBuffer = new char[newSize];
            buff.AsSpan(0, Length).CopyTo(newBuffer.AsSpan());
            buffer = newBuffer;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return new(buffer!, 0, Length);
        }
    }

    public ref struct ValueStringBuilderSimple
    {
        private Span<char> chars;
        private int pos;

        public ValueStringBuilderSimple(Span<char> buffer)
        {
            chars = buffer;
            pos = 0;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public unsafe void Append(ReadOnlySpan<char> value)
        {
            var p = pos;
            if (p > chars.Length - value.Length)
            {
                Grow(value.Length);
            }

            value.CopyTo(chars[pos..]);
            pos += value.Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Grow(int additional)
        {
            // dummy
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return chars[..pos].ToString();
        }
    }
}
