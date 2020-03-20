namespace Benchmarks.Find
{
    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class FindBenchmark
    {
        private const int N = 1000;

        private EntryStruct[] structEntries;

        private EntryClass[] classEntries;

        private EntryClassWithNext firstClassEntry;

        [GlobalSetup]
        public void Setup()
        {
            structEntries = new EntryStruct[8];
            classEntries = new EntryClass[8];
            var lastClassEntry = default(EntryClassWithNext);
            for (var i = 0; i < structEntries.Length; i++)
            {
                structEntries[i] = new EntryStruct(i + 1, null);
                classEntries[i] = new EntryClass(i + 1, null);
                var entry = new EntryClassWithNext(i + 1, null);
                if (lastClassEntry is null)
                {
                    firstClassEntry = entry;
                    lastClassEntry = entry;
                }
                else
                {
                    lastClassEntry.Next = entry;
                }
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForStruct1()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForStruct(1);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForStruct2()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForStruct(2);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForStruct3()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForStruct(3);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForStruct4()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForStruct(4);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForClass1()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForClass(1);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForClass2()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForClass(2);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForClass3()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForClass(3);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object ForClass4()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindForClass(4);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object Do1()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindDo(1);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object Do2()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindDo(2);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object Do3()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindDo(3);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object Do4()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindDo(4);
            }
            return ret;
        }

        private object FindForStruct(int key)
        {
            for (var i = 0; i < structEntries.Length; i++)
            {
                var entry = structEntries[i];
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }

            return null;
        }

        private object FindForClass(int key)
        {
            for (var i = 0; i < classEntries.Length; i++)
            {
                var entry = classEntries[i];
                if (entry.Key == key)
                {
                    return entry.Value;
                }
            }

            return null;
        }

        private object FindDo(int key)
        {
            var entry = firstClassEntry;
            do
            {
                if (entry.Key == key)
                {
                    return entry.Value;
                }

                entry = entry.Next;
            }
            while (entry != null);

            return null;
        }
    }

    public readonly struct EntryStruct
    {
        public readonly int Key;

        public readonly object Value;

        public EntryStruct(int key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    public sealed class EntryClass
    {
        public readonly int Key;

        public readonly object Value;

        public EntryClass(int key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    public sealed class EntryClassWithNext
    {
        public readonly int Key;

        public readonly object Value;

        public EntryClassWithNext Next;

        public EntryClassWithNext(int key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
