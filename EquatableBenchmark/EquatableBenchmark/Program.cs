namespace EquatableBenchmark
{
    using System;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    using Smart.Collections.Concurrent;

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

    public struct Info1 : IEquatable<Info1>
    {
        public Type Type { get; }
        public string Name { get; }
        public Info1(Type type, string name) => (Type, Name) = (type, name);

        public override int GetHashCode() => (Type, Name).GetHashCode();
        public override bool Equals(object other) => other is Info1 l && Equals(l);
        public bool Equals(Info1 other) => Type == other.Type && Name == other.Name;
    }

    public struct Info2 : IEquatable<Info2>
    {
        public Type Type { get; }
        public string Name { get; }
        public Info2(Type type, string name) => (Type, Name) = (type, name);

        public override int GetHashCode() => (Name, Type).GetHashCode();
        public override bool Equals(object other) => other is Info2 l && Equals(l);
        public bool Equals(Info2 other) => Type == other.Type && Name == other.Name;
    }

    public struct Info3 : IEquatable<Info3>
    {
        private readonly int hash;

        public Type Type { get; }
        public string Name { get; }

        public Info3(Type type, string name)
        {
            Type = type;
            Name = name;
            hash = (Type, Name).GetHashCode();
        }

        public override int GetHashCode() => hash;
        public override bool Equals(object other) => other is Info3 l && Equals(l);
        public bool Equals(Info3 other) => Type == other.Type && Name == other.Name;
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly ThreadsafeHashArrayMap<Info1, object> infomations1 = new ThreadsafeHashArrayMap<Info1, object>();
        private readonly ThreadsafeHashArrayMap<Info2, object> infomations2 = new ThreadsafeHashArrayMap<Info2, object>();
        private readonly ThreadsafeHashArrayMap<Info3, object> infomations3 = new ThreadsafeHashArrayMap<Info3, object>();

        private readonly object instance = new object();

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < 256; i++)
            {
                var name = i.ToString();
                infomations1.AddIfNotExist(new Info1(typeof(object), name), instance);
                infomations2.AddIfNotExist(new Info2(typeof(object), name), instance);
                infomations3.AddIfNotExist(new Info3(typeof(object), name), instance);
            }
        }

        [Benchmark]
        public void Key1()
        {
            var key1 = new Info1(typeof(object), "100");
            infomations1.AddIfNotExist(key1, instance);
        }

        [Benchmark]
        public void Key2()
        {
            var key2 = new Info2(typeof(object), "100");
            infomations2.AddIfNotExist(key2, instance);
        }

        [Benchmark]
        public void Key3()
        {
            var key3 = new Info3(typeof(object), "100");
            infomations3.AddIfNotExist(key3, instance);
        }
    }
}
