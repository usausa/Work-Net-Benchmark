namespace KeyBenchmark
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

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
            Add(MarkdownExporter.Default, MarkdownExporter.GitHub);
            Add(MemoryDiagnoser.Default);
            Add(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 1000;

        private static readonly string Name = "Test";

        private static readonly Type Type = typeof(object);

        private ClassPropertyKey[] keys;

        private KeyManager keyManager;

        [GlobalSetup]
        public void Setup()
        {

            keys = Enumerable.Range(1, 8)
                .Select(x => new ClassPropertyKey { Name = Name, Type = Type })
                .ToArray();
            keyManager = new KeyManager(Name, Type, keys);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void StructFieldKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByStructFieldKey(Name, Type);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void StructPropertyKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByStructPropertyKey(Name, Type);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ClassFieldKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByClassFieldKey(Name, Type);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ClassPropertyKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByClassPropertyKey(Name, Type);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void StructFieldMultiKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByStructFieldMultiKey(keys);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void StructPropertyMultiKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByStructPropertyMultiKey(keys);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ClassFieldMultiKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByClassFieldMultiKey(keys);
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ClassPropertyMultiKey()
        {
            for (var i = 0; i < N; i++) keyManager.ByClassPropertyMultiKey(keys);
        }
    }

    public sealed class KeyManager
    {
        private readonly StructFieldKey[] structFieldKey;
        private readonly StructPropertyKey[] structPropertyKey;
        private readonly ClassFieldKey[] classFieldKey;
        private readonly ClassPropertyKey[] classPropertyKey;

        private readonly StructFieldKey[] structFieldKeys;
        private readonly StructPropertyKey[] structPropertyKeys;
        private readonly ClassFieldKey[] classFieldKeys;
        private readonly ClassPropertyKey[] classPropertyKeys;

        [ThreadStatic]
        private static StructFieldKey[] structFieldPool;
        [ThreadStatic]
        private static StructPropertyKey[] structPropertyPool;
        [ThreadStatic]
        private static ClassFieldKey[] classFieldPool;
        [ThreadStatic]
        private static ClassPropertyKey[] classPropertyPool;

        private readonly int multiKeyHash;

        public KeyManager(string name, Type type, ClassPropertyKey[] multiKey)
        {
            var hash = CalcHash(name, type);
            var index = hash & 1;
            structFieldKey = new StructFieldKey[2];
            structFieldKey[index].Name = name;
            structFieldKey[index].Type = type;
            structPropertyKey = new StructPropertyKey[2];
            structPropertyKey[index].Name = name;
            structPropertyKey[index].Type = type;
            classFieldKey = new[] { new ClassFieldKey(), new ClassFieldKey() };
            classFieldKey[index].Name = name;
            classFieldKey[index].Type = type;
            classPropertyKey = new[] { new ClassPropertyKey(), new ClassPropertyKey() };
            classPropertyKey[index].Name = name;
            classPropertyKey[index].Type = type;

            structFieldKeys = multiKey.Select(x => new StructFieldKey { Name = x.Name, Type = x.Type }).ToArray();
            structPropertyKeys = multiKey.Select(x => new StructPropertyKey { Name = x.Name, Type = x.Type }).ToArray();
            classFieldKeys = multiKey.Select(x => new ClassFieldKey { Name = x.Name, Type = x.Type }).ToArray();
            classPropertyKeys = multiKey.Select(x => new ClassPropertyKey { Name = x.Name, Type = x.Type }).ToArray();

            structFieldPool = new StructFieldKey[multiKey.Length];
            structPropertyPool = new StructPropertyKey[multiKey.Length];
            classFieldPool = Enumerable.Range(1, multiKey.Length).Select(x => new ClassFieldKey()).ToArray();
            classPropertyPool = Enumerable.Range(1, multiKey.Length).Select(x => new ClassPropertyKey()).ToArray();

            multiKeyHash = multiKey.Length;
            for (var i = 0; i < multiKey.Length; i++)
            {
                var key = multiKey[i];
                multiKeyHash = (multiKeyHash * 31) + (key.Name.GetHashCode() ^ key.Type.GetHashCode());
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CalcHash(string name, Type type)
        {
            return name.GetHashCode() ^ type.GetHashCode();
        }

        public void ByStructFieldKey(string name, Type type)
        {
            ref var entry = ref structFieldKey[CalcHash(name, type) & (structFieldKey.Length - 1)];
            if ((entry.Name == name) && (entry.Type == type))
            {
                return;
            }

            throw new Exception();
        }

        public void ByStructPropertyKey(string name, Type type)
        {
            ref var entry = ref structPropertyKey[CalcHash(name, type) & (structPropertyKey.Length - 1)];
            if ((entry.Name == name) && (entry.Type == type))
            {
                return;
            }

            throw new Exception();
        }

        public void ByClassFieldKey(string name, Type type)
        {
            var entry = classFieldKey[CalcHash(name, type) & (classFieldKey.Length - 1)];
            if ((entry.Name == name) && (entry.Type == type))
            {
                return;
            }

            throw new Exception();
        }

        public void ByClassPropertyKey(string name, Type type)
        {
            var entry = classPropertyKey[CalcHash(name, type) & (classPropertyKey.Length - 1)];
            if ((entry.Name == name) && (entry.Type == type))
            {
                return;
            }

            throw new Exception();
        }

        public void ByStructFieldMultiKey(ClassPropertyKey[] multiKey)
        {
            for (var i = 0; i < multiKey.Length; i++)
            {
                var item = multiKey[i];
                ref var key = ref structFieldPool[i];
                key.Name = item.Name;
                key.Type = item.Type;
            }

            var columns = new Span<StructFieldKey>(structFieldPool, 0, multiKey.Length);

            var hash = columns.Length;
            for (var i = 0; i < columns.Length; i++)
            {
                ref var key = ref columns[i];
                hash = (hash * 31) + (key.Name.GetHashCode() ^ key.Type.GetHashCode());
            }

            if (hash != multiKeyHash)
            {
                throw new Exception();
            }

            if (structFieldKeys.Length != columns.Length)
            {
                throw new Exception();
            }

            for (var i = 0; i < structFieldKeys.Length; i++)
            {
                ref var entry1 = ref structFieldKeys[i];
                ref var entry2 = ref columns[i];
                if ((entry1.Name != entry2.Name) || (entry1.Type != entry2.Type))
                {
                    throw new Exception();
                }
            }
        }

        public void ByStructPropertyMultiKey(ClassPropertyKey[] multiKey)
        {
            for (var i = 0; i < multiKey.Length; i++)
            {
                var item = multiKey[i];
                ref var key = ref structPropertyPool[i];
                key.Name = item.Name;
                key.Type = item.Type;
            }

            var columns = new Span<StructPropertyKey>(structPropertyPool, 0, multiKey.Length);

            var hash = columns.Length;
            for (var i = 0; i < columns.Length; i++)
            {
                ref var key = ref columns[i];
                hash = (hash * 31) + (key.Name.GetHashCode() ^ key.Type.GetHashCode());
            }

            if (hash != multiKeyHash)
            {
                throw new Exception();
            }

            if (structPropertyKeys.Length != columns.Length)
            {
                throw new Exception();
            }

            for (var i = 0; i < structPropertyKeys.Length; i++)
            {
                ref var entry1 = ref structPropertyKeys[i];
                ref var entry2 = ref columns[i];
                if ((entry1.Name != entry2.Name) || (entry1.Type != entry2.Type))
                {
                    throw new Exception();
                }
            }
        }

        public void ByClassFieldMultiKey(ClassPropertyKey[] multiKey)
        {
            for (var i = 0; i < multiKey.Length; i++)
            {
                var item = multiKey[i];
                var key = classFieldPool[i];
                key.Name = item.Name;
                key.Type = item.Type;
            }

            var columns = new Span<ClassFieldKey>(classFieldPool, 0, multiKey.Length);

            var hash = columns.Length;
            for (var i = 0; i < columns.Length; i++)
            {
                var key = columns[i];
                hash = (hash * 31) + (key.Name.GetHashCode() ^ key.Type.GetHashCode());
            }

            if (hash != multiKeyHash)
            {
                throw new Exception();
            }

            if (classFieldKeys.Length != columns.Length)
            {
                throw new Exception();
            }

            for (var i = 0; i < classFieldKeys.Length; i++)
            {
                var entry1 = classFieldKeys[i];
                var entry2 = columns[i];
                if ((entry1.Name != entry2.Name) || (entry1.Type != entry2.Type))
                {
                    throw new Exception();
                }
            }
        }

        public void ByClassPropertyMultiKey(ClassPropertyKey[] multiKey)
        {
            for (var i = 0; i < multiKey.Length; i++)
            {
                var item = multiKey[i];
                var key = classPropertyPool[i];
                key.Name = item.Name;
                key.Type = item.Type;
            }

            var columns = new Span<ClassPropertyKey>(classPropertyPool, 0, multiKey.Length);

            var hash = columns.Length;
            for (var i = 0; i < columns.Length; i++)
            {
                var key = columns[i];
                hash = (hash * 31) + (key.Name.GetHashCode() ^ key.Type.GetHashCode());
            }

            if (hash != multiKeyHash)
            {
                throw new Exception();
            }

            if (classPropertyKeys.Length != columns.Length)
            {
                throw new Exception();
            }

            for (var i = 0; i < classPropertyKeys.Length; i++)
            {
                var entry1 = classPropertyKeys[i];
                var entry2 = columns[i];
                if ((entry1.Name != entry2.Name) || (entry1.Type != entry2.Type))
                {
                    throw new Exception();
                }
            }
        }
    }


    public struct StructFieldKey
    {
        public string Name;

        public Type Type;
    }

    public struct StructPropertyKey
    {
        public string Name { get; set; }

        public Type Type { get; set; }
    }

    public sealed class ClassFieldKey
    {
        public string Name;

        public Type Type;
    }

    public sealed class ClassPropertyKey
    {
        public string Name { get; set; }

        public Type Type { get; set; }
    }
}
