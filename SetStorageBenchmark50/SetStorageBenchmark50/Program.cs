namespace SetStorageBenchmark
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;
    using System;

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
            AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly Model model = new Model();

        [Benchmark]
        public void Set() => model.Set(1);

        [Benchmark]
        public void SetCallback() => model.SetCallback(1);

        [Benchmark]
        public void SetModelCallback() => model.SetModelCallback(1);

        [Benchmark]
        public void SetByAccessor() => model.SetByAccessor(1);
    }

    public delegate ref T FieldAccessor<T>();

    public class NotificationObject
    {
        public void Set<T>(ref T storage, T value)
        {
            storage = value;
        }

        public void SetCallback<T>(T value, Action<T> callback)
        {
            callback(value);
        }

        public void SetCallback<TModel, T>(T value, TModel model, Action<TModel, T> callback)
        {
            callback(model, value);
        }

        public void SetByAccessor<T>(T value, FieldAccessor<T> accessor)
        {
            accessor() = value;
        }
    }

    public class Model : NotificationObject
    {
        private int storage;

        public void Set(int value)
        {
            Set(ref storage, value);
        }

        public void SetCallback(int value)
        {
            SetCallback(value, x => storage = x);
        }

        public void SetModelCallback(int value)
        {
            SetCallback(value, this, (m, x) => m.storage = x);
        }

        public void SetByAccessor(int value)
        {
            SetByAccessor(value, () => ref storage);
        }
    }
}
