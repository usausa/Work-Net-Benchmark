namespace Benchmarks.TupleType
{
    using System;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class TupleTypeBenchmark
    {
        private const int N = 1000000;

        private readonly ClassFieldKey classFieldKey = new ClassFieldKey(typeof(TupleTypeBenchmark), "Test");

        private readonly ClassPropertyKey classPropertyKey = new ClassPropertyKey(typeof(TupleTypeBenchmark), "Test");

        private readonly StructKey structKey = new StructKey(typeof(TupleTypeBenchmark), "Test");

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public int UseClassField()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = classFieldKey.Type.GetHashCode() ^ (classFieldKey.Name.GetHashCode() * 397);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseClassProperty()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = classPropertyKey.Type.GetHashCode() ^ (classPropertyKey.Name.GetHashCode() * 397);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int UseStruct()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = structKey.Type.GetHashCode() ^ (structKey.Name.GetHashCode() * 397);
            }
            return ret;
        }
    }

    public class ClassFieldKey
    {
        public readonly Type Type;

        public readonly string Name;

        public ClassFieldKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    public class ClassPropertyKey
    {
        public Type Type { get; }

        public string Name { get; }

        public ClassPropertyKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    public readonly struct StructKey
    {
        public readonly Type Type;

        public readonly string Name;

        public StructKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
