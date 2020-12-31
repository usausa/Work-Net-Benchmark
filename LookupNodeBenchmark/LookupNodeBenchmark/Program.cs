namespace LookupNodeBenchmark
{
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
            AddJob(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int N = 1000;

        private Holder holder;

        [GlobalSetup]
        public void Setup()
        {
            holder = new Holder();
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByNodeLink1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByNodeLink(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryArrayLoop1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryArrayLoop(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryArrayEach1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryArrayEach(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryReferenceWhile1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryReferenceWhile(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryReferenceFor1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryReferenceFor(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryArrayLoop1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryArrayLoop(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryArrayEach1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryArrayEach(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryReferenceWhile1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryReferenceWhile(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryReferenceFor1()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryReferenceFor(typeof(Class01));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByNodeLink2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByNodeLink(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryArrayLoop2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryArrayLoop(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryArrayEach2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryArrayEach(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryReferenceWhile2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryReferenceWhile(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByStructEntryReferenceFor2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByStructEntryReferenceFor(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryArrayLoop2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryArrayLoop(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryArrayEach2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryArrayEach(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryReferenceWhile2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryReferenceWhile(typeof(Class02));
            }

            return obj;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ByClassEntryReferenceFor2()
        {
            var obj = default(object);
            for (var i = 0; i < N; i++)
            {
                obj = holder.ByClassEntryReferenceFor(typeof(Class02));
            }

            return obj;
        }
    }

    public sealed class Holder
    {
        private readonly ClassNode nodeRef;

        private readonly StructEntry[] structEntriesRef;

        private readonly ClassEntry[] classEntriesRef;

        public Holder()
        {
            var node1 = new ClassNode(typeof(Class01), new Class01());
            var node2 = new ClassNode(typeof(Class02), new Class02());
            var node3 = new ClassNode(typeof(Class03), new Class03());
            node1.Next = node2;
            node2.Next = node3;
            nodeRef = node1;

            structEntriesRef = new StructEntry[3];
            structEntriesRef[0] = new StructEntry(typeof(Class01), new Class01());
            structEntriesRef[1] = new StructEntry(typeof(Class02), new Class02());
            structEntriesRef[2] = new StructEntry(typeof(Class03), new Class03());

            classEntriesRef = new ClassEntry[3];
            classEntriesRef[0] = new ClassEntry(typeof(Class01), new Class01());
            classEntriesRef[1] = new ClassEntry(typeof(Class02), new Class02());
            classEntriesRef[2] = new ClassEntry(typeof(Class03), new Class03());
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByNodeLink(Type key)
        {
            var node = nodeRef;
            do
            {
                if (node.Key == key)
                {
                    return node.Value;
                }

                node = node.Next;
            }
            while (node is not null);

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByStructEntryArrayLoop(Type key)
        {
            var entries = structEntriesRef;
            for (var i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByStructEntryArrayEach(Type key)
        {
            var entries = structEntriesRef;
            foreach (var entry in entries)
            {
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByStructEntryReferenceWhile(Type key)
        {
            var entries = structEntriesRef;
            ref var start = ref MemoryMarshal.GetReference(entries.AsSpan());
            ref var end = ref Unsafe.Add(ref start, entries.Length);
            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                if (start.Key == key)
                {
                    return start.Value;
                }

                start = ref Unsafe.Add(ref start, 1);
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByStructEntryReferenceFor(Type key)
        {
            var entries = structEntriesRef;
            ref var reference = ref MemoryMarshal.GetReference(entries.AsSpan());
            for (var i = 0; i < entries.Length; i++)
            {
                if (reference.Key == key)
                {
                    return reference.Value;
                }

                reference = ref Unsafe.Add(ref reference, 1);
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByClassEntryArrayLoop(Type key)
        {
            var entries = classEntriesRef;
            for (var i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByClassEntryArrayEach(Type key)
        {
            var entries = classEntriesRef;
            foreach (var entry in entries)
            {
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByClassEntryReferenceWhile(Type key)
        {
            var entries = classEntriesRef;
            ref var start = ref MemoryMarshal.GetReference(entries.AsSpan());
            ref var end = ref Unsafe.Add(ref start, entries.Length);
            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                if (start.Key == key)
                {
                    return start.Value;
                }

                start = ref Unsafe.Add(ref start, 1);
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public object ByClassEntryReferenceFor(Type key)
        {
            var entries = classEntriesRef;
            ref var reference = ref MemoryMarshal.GetReference(entries.AsSpan());
            for (var i = 0; i < entries.Length; i++)
            {
                if (reference.Key == key)
                {
                    return reference.Value;
                }

                reference = ref Unsafe.Add(ref reference, 1);
            }

            return null;
        }
    }

    public class Class01 { }
    public class Class02 { }
    public class Class03 { }

    public sealed class ClassNode
    {
        public readonly Type Key;

        public readonly object Value;

        public ClassNode Next;

        public ClassNode(Type key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    public readonly struct StructEntry
    {
        public readonly Type Key;

        public readonly object Value;

        public StructEntry(Type key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    public sealed class ClassEntry
    {
        public readonly Type Key;

        public readonly object Value;

        public ClassEntry(Type key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
