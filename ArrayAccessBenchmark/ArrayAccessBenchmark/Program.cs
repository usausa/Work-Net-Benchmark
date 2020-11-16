namespace ArrayAccessBenchmark
{
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
        private readonly int[] array = new int[16];

        [Benchmark]
        public int Single() => array[0];

        [Benchmark]
        public int SingleByHelper() => ArrayHelper.GetItemReference(array, 0);

        [Benchmark]
        public int Loop()
        {
            var total = 0;
            for (var i = 0; i < array.Length; i++)
            {
                total += array[i];
            }
            return total;
        }

        [Benchmark]
        public int LoopWithCheck()
        {
            var total = 0;
            for (var i = 0; i < 16; i++)
            {
                total += array[i];
            }
            return total;
        }

        [Benchmark]
        public int LoopByHelper()
        {
            var total = 0;
            for (var i = 0; i < 16; i++)
            {
                total += ArrayHelper.GetItemReference(array, i);
            }
            return total;
        }

        [Benchmark]
        public unsafe int LoopByPointer()
        {
            var total = 0;
            fixed (int* ptr = &array[0])
            {
                for (var i = 0; i < 16; i++)
                {
                    total += *(ptr + i);
                }
            }
            return total;
        }
    }

    public static class ArrayHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T GetItemReference<T>(T[] array, int index)
        {
            ref var data = ref MemoryMarshal.GetArrayDataReference(array);
            return ref Unsafe.Add(ref data, index);
        }
    }
}
