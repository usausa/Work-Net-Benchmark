using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ArrayAccessBenchmark
{
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
        private readonly int[] array4 = new int[4];
        private readonly int[] array16 = new int[16];
        private readonly int[] array64 = new int[64];
        private readonly int[] array256 = new int[256];
        private readonly NativeArray<int> nativeArray4 = new(4);
        private readonly NativeArray<int> nativeArray16 = new(16);
        private readonly NativeArray<int> nativeArray64 = new(64);
        private readonly NativeArray<int> nativeArray256 = new(2564);

        // Read

        [Benchmark]
        public void ReadArray4() => ArrayAccessor.ReadArray(array4);

        [Benchmark]
        public void ReadArrayAsSpan4() => ArrayAccessor.ReadSpan(array4.AsSpan());

        [Benchmark]
        public void ReadArrayByPointer4() => ArrayAccessor.ReadArrayByPointer(array4);

        [Benchmark]
        public void ReadArrayAsSpanByPointer4() => ArrayAccessor.ReadSpanByPointer(array4.AsSpan());

        [Benchmark]
        public void ReadNativeArray4() => ArrayAccessor.ReadNativeArray(nativeArray4);

        [Benchmark]
        public void ReadArray16() => ArrayAccessor.ReadArray(array16);

        [Benchmark]
        public void ReadArrayAsSpan16() => ArrayAccessor.ReadSpan(array16.AsSpan());

        [Benchmark]
        public void ReadArrayByPointer16() => ArrayAccessor.ReadArrayByPointer(array16);

        [Benchmark]
        public void ReadArrayAsSpanByPointer16() => ArrayAccessor.ReadSpanByPointer(array16.AsSpan());

        [Benchmark]
        public void ReadNativeArray16() => ArrayAccessor.ReadNativeArray(nativeArray16);

        [Benchmark]
        public void ReadArray64() => ArrayAccessor.ReadArray(array64);

        [Benchmark]
        public void ReadArrayAsSpan64() => ArrayAccessor.ReadSpan(array64.AsSpan());

        [Benchmark]
        public void ReadArrayByPointer64() => ArrayAccessor.ReadArrayByPointer(array64);

        [Benchmark]
        public void ReadArrayAsSpanByPointer64() => ArrayAccessor.ReadSpanByPointer(array64.AsSpan());

        [Benchmark]
        public void ReadNativeArray64() => ArrayAccessor.ReadNativeArray(nativeArray64);

        [Benchmark]
        public void ReadArray256() => ArrayAccessor.ReadArray(array256);

        [Benchmark]
        public void ReadArrayAsSpan256() => ArrayAccessor.ReadSpan(array256.AsSpan());

        [Benchmark]
        public void ReadArrayByPointer256() => ArrayAccessor.ReadArrayByPointer(array256);

        [Benchmark]
        public void ReadArrayAsSpanByPointer256() => ArrayAccessor.ReadSpanByPointer(array256.AsSpan());

        [Benchmark]
        public void ReadNativeArray256() => ArrayAccessor.ReadNativeArray(nativeArray256);

        // Write

        [Benchmark]
        public void WriteArray4() => ArrayAccessor.WriteArray(array4);

        [Benchmark]
        public void WriteArrayAsSpan4() => ArrayAccessor.WriteSpan(array4.AsSpan());

        [Benchmark]
        public void WriteArrayByPointer4() => ArrayAccessor.WriteArrayByPointer(array4);

        [Benchmark]
        public void WriteArrayAsSpanByPointer4() => ArrayAccessor.WriteSpanByPointer(array4.AsSpan());

        [Benchmark]
        public void WriteNativeArray4() => ArrayAccessor.WriteNativeArray(nativeArray4);

        [Benchmark]
        public void WriteArray16() => ArrayAccessor.WriteArray(array16);

        [Benchmark]
        public void WriteArrayAsSpan16() => ArrayAccessor.WriteSpan(array16.AsSpan());

        [Benchmark]
        public void WriteArrayByPointer16() => ArrayAccessor.WriteArrayByPointer(array16);

        [Benchmark]
        public void WriteArrayAsSpanByPointer16() => ArrayAccessor.WriteSpanByPointer(array16.AsSpan());

        [Benchmark]
        public void WriteNativeArray16() => ArrayAccessor.WriteNativeArray(nativeArray16);

        [Benchmark]
        public void WriteArray64() => ArrayAccessor.WriteArray(array64);

        [Benchmark]
        public void WriteArrayAsSpan64() => ArrayAccessor.WriteSpan(array64.AsSpan());

        [Benchmark]
        public void WriteArrayByPointer64() => ArrayAccessor.WriteArrayByPointer(array64);

        [Benchmark]
        public void WriteArrayAsSpanByPointer64() => ArrayAccessor.WriteSpanByPointer(array64.AsSpan());

        [Benchmark]
        public void WriteNativeArray64() => ArrayAccessor.WriteNativeArray(nativeArray64);

        [Benchmark]
        public void WriteArray256() => ArrayAccessor.WriteArray(array256);

        [Benchmark]
        public void WriteArrayAsSpan256() => ArrayAccessor.WriteSpan(array256.AsSpan());

        [Benchmark]
        public void WriteArrayByPointer256() => ArrayAccessor.WriteArrayByPointer(array256);

        [Benchmark]
        public void WriteArrayAsSpanByPointer256() => ArrayAccessor.WriteSpanByPointer(array256.AsSpan());

        [Benchmark]
        public void WriteNativeArray256() => ArrayAccessor.WriteNativeArray(nativeArray256);
    }

    public static class ArrayAccessor
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSpan(Span<int> span)
        {
            for (var i = 0; i < span.Length; i++)
            {
                span[i] = i;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ReadSpan(Span<int> span)
        {
            for (var i = 0; i < span.Length; i++)
            {
                _ = span[i];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteSpanByPointer(Span<int> span)
        {
            fixed (int* pointer = span)
            {
                var p = pointer;
                var length = span.Length;
                for (var i = 0; i < length; i++)
                {
                    *p = i;
                    p++;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void ReadSpanByPointer(Span<int> span)
        {
            fixed (int* pointer = span)
            {
                var p = pointer;
                var length = span.Length;
                for (var i = 0; i < length; i++)
                {
                    _ = *p;
                    p++;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteArray(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ReadArray(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                _ = array[i];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void WriteArrayByPointer(int[] array)
        {
            fixed (int* pointer = &array[0])
            {
                var p = pointer;
                var length = array.Length;
                for (var i = 0; i < length; i++)
                {
                    *p = i;
                    p++;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void ReadArrayByPointer(int[] array)
        {
            fixed (int* pointer = &array[0])
            {
                var p = pointer;
                var length = array.Length;
                for (var i = 0; i < length; i++)
                {
                    _ = *p;
                    p++;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteNativeArray(NativeArray<int> array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ReadNativeArray(NativeArray<int> array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                _ = array[i];
            }
        }
    }

    public sealed unsafe class NativeArray<T> : IDisposable
        where T : unmanaged
    {
        private readonly int length;

        private IntPtr pointer;

        public static NativeArray<T> Empty => new();

        public int Length => length;

        public IntPtr Pointer => pointer;

        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => GetReference(i);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => GetReference(i) = value;
        }

        private NativeArray()
        {
        }

        public NativeArray(int length)
        {
            this.length = length;
            var size = sizeof(T) * length;
            pointer = Marshal.AllocHGlobal(size);
        }

        public NativeArray(Span<T> span)
        {
            length = span.Length;
            var size = sizeof(T) * length;
            pointer = Marshal.AllocHGlobal(size);
            span.CopyTo(new Span<T>((void*)pointer, length));
        }

        public void Dispose()
        {
            if (pointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pointer);
                pointer = IntPtr.Zero;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T GetReference(int i) => ref Unsafe.AsRef<T>((T*)pointer + i);

        public Span<T> AsSpan() => new((T*)pointer, length);
    }
}
