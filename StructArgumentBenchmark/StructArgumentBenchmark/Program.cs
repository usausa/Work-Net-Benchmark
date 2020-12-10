namespace StructArgumentBenchmark
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

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
            AddJob(Job.LongRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly ClassParameter classParameter = new();
        private readonly StructParameter8 structParameter8 = new();
        private readonly StructParameter16 structParameter16 = new();
        private readonly StructParameter24 structParameter24 = new();
        private readonly ReadOnlyStructParameter8 readOnlyStructParameter8 = new();
        private readonly ReadOnlyStructParameter16 readOnlyStructParameter16 = new();
        private readonly ReadOnlyStructParameter24 readOnlyStructParameter24 = new();

        [Benchmark] public int CallFieldClass() => Functions.Call(classParameter);

        [Benchmark] public int CallFieldStruct8() => Functions.Call(structParameter8);

        [Benchmark] public int CallFieldStruct16() => Functions.Call(structParameter16);

        [Benchmark] public int CallFieldStruct24() => Functions.Call(structParameter24);

        [Benchmark] public int CallFieldReadOnlyStruct8() => Functions.Call(readOnlyStructParameter8);

        [Benchmark] public int CallFieldReadOnlyStruct16() => Functions.Call(readOnlyStructParameter16);

        [Benchmark] public int CallFieldReadOnlyStruct24() => Functions.Call(readOnlyStructParameter24);

        [Benchmark] public int CallLocalClass() => Functions.Call(new ClassParameter());

        [Benchmark] public int CallLocalStruct8() => Functions.Call(new StructParameter8());

        [Benchmark] public int CallLocalStruct16() => Functions.Call(new StructParameter16());

        [Benchmark] public int CallLocalStruct24() => Functions.Call(new StructParameter24());

        [Benchmark] public int CallRefLocalStruct8()
        {
            var p = new StructParameter8 { Value = 0 };
            return Functions.CallRef(ref p);
        }

        [Benchmark] public int CallRefLocalStruct16()
        {
            var p = new StructParameter16 { Value = 0, Value2 = 0 };
            return Functions.CallRef(ref p);
        }

        [Benchmark] public int CallRefLocalStruct24()
        {
            var p = new StructParameter24 { Value = 0, Value2 = 0, Value3 = 0 };
            return Functions.CallRef(ref p);
        }

        [Benchmark] public int CallInLocalReadOnlyStruct8()
        {
            var p = new ReadOnlyStructParameter8(0);
            return Functions.CallIn(in p);
        }

        [Benchmark] public int CallInLocalReadOnlyStruct16()
        {
            var p = new ReadOnlyStructParameter16(0, 0);
            return Functions.CallIn(in p);
        }

        [Benchmark] public int CallInLocalReadOnlyStruct24()
        {
            var p = new ReadOnlyStructParameter24(0, 0, 0);
            return Functions.CallIn(in p);
        }
    }

    public class ClassParameter
    {
        public int Value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct StructParameter8
    {
        [FieldOffset(0)]
        public int Value;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct StructParameter16
    {
        [FieldOffset(0)]
        public int Value;
        [FieldOffset(8)]
        public int Value2;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct StructParameter24
    {
        [FieldOffset(0)]
        public int Value;
        [FieldOffset(8)]
        public int Value2;
        [FieldOffset(16)]
        public int Value3;
    }

    [StructLayout(LayoutKind.Explicit)]
    public readonly struct ReadOnlyStructParameter8
    {
        [FieldOffset(0)]
        public readonly int Value;

        public ReadOnlyStructParameter8(int value)
        {
            Value = value;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public readonly struct ReadOnlyStructParameter16
    {
        [FieldOffset(0)]
        public readonly int Value;
        [FieldOffset(8)]
        public readonly int Value2;

        public ReadOnlyStructParameter16(int value, int value2)
        {
            Value = value;
            Value2 = value2;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public readonly struct ReadOnlyStructParameter24
    {
        [FieldOffset(0)]
        public readonly int Value;
        [FieldOffset(8)]
        public readonly int Value2;
        [FieldOffset(16)]
        public readonly int Value3;

        public ReadOnlyStructParameter24(int value, int value2, int value3)
        {
            Value = value;
            Value2 = value2;
            Value3 = value3;
        }
    }

    public static class Functions
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Call(ClassParameter p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Call(StructParameter8 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Call(StructParameter16 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Call(StructParameter24 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Call(ReadOnlyStructParameter8 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Call(ReadOnlyStructParameter16 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Call(ReadOnlyStructParameter24 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int CallRef(ref StructParameter8 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int CallRef(ref StructParameter16 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int CallRef(ref StructParameter24 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int CallIn(in ReadOnlyStructParameter8 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int CallIn(in ReadOnlyStructParameter16 p) => p.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int CallIn(in ReadOnlyStructParameter24 p) => p.Value;
    }
}
