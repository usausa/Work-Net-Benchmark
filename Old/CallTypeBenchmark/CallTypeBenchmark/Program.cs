namespace CallTypeBenchmark
{
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);
        }
    }

    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MarkdownExporter.Default, MarkdownExporter.GitHub);
            Add(MemoryDiagnoser.Default);
            Add(Job.LongRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private IExecute iface;

        private Execute impl;

        [GlobalSetup]
        public void Setup()
        {
            impl = new Execute();
            iface = impl;
        }

        [Benchmark]
        public int IfExecute1() => iface.Execute1();

        [Benchmark]
        public int IfExecute2() => iface.Execute2();

        [Benchmark]
        public int ImplExecute1() => impl.Execute1();

        [Benchmark]
        public int ImplExecute2() => impl.Execute2();

        [Benchmark]
        public int ImplExecute3() => impl.Execute3();

        [Benchmark]
        public int ImplExecute4() => impl.Execute4();
    }

    public interface IExecute
    {
        int Execute1();

        int Execute2();
    }

    public sealed class Execute : IExecute
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Execute1() => 0;

        public int Execute2() => 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Execute3() => 0;

        public int Execute4() => 0;
    }
}
