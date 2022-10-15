using System;

namespace TryBenchmark
{
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
            Add(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        [Benchmark]
        public void Using1()
        {
            using (var o = new Disposable())
            {
                o.Dummy();
            }
        }

        [Benchmark]
        public void Using2()
        {
            using (var o1 = new Disposable())
            using (var o2 = new Disposable())
            {
                o1.Dummy();
                o2.Dummy();
            }
        }

        [Benchmark]
        public void Try1()
        {
            var o = new Disposable();
            try
            {
                o.Dummy();
            }
            finally
            {
                o.Dispose();
            }
        }

        [Benchmark]
        public void Try2()
        {
            var o1 = new Disposable();
            try
            {
                var o2 = new Disposable();
                try
                {
                    o1.Dummy();
                    o2.Dummy();
                }
                finally
                {
                    o2.Dispose();
                }
            }
            finally
            {
                o1.Dispose();
            }
        }

        [Benchmark]
        public void UsingNotDispose()
        {
            var o = new Disposable();
            using (var d = new DelegateDisposable(o))
            {
                o.Dummy();
                d.SetNull();
            }
        }
    }

    public sealed class Disposable : IDisposable
    {
        public void Dummy()
        {
        }

        public void Dispose()
        {
        }
    }

    public struct DelegateDisposable : IDisposable
    {
        private IDisposable source;

        public DelegateDisposable(IDisposable source)
        {
            this.source = source;
        }

        public void SetNull()
        {
            source = null;
        }

        public void Dispose()
        {
            source?.Dispose();
        }
    }

}
