namespace Benchmarks.Find
{
    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class FindBenchmark
    {
        private const int N = 1000;

        private EntryStruct[] structEntries;

        private EntryClass firstClassEntry;

        [GlobalSetup]
        public void Setup()
        {
            var lastClassEntry = default(EntryClass);
            structEntries = new EntryStruct[8];
            for (var i = 0; i < structEntries.Length; i++)
            {
                structEntries[i] = new EntryStruct(i + 1, null);
                var entry = new EntryClass(i + 1, null);
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
        public object For1()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindFor(1);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object For2()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindFor(2);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object For3()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindFor(3);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object For4()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindFor(4);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public object For5()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindFor(5);
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

        [Benchmark(OperationsPerInvoke = N)]
        public object Do5()
        {
            var ret = default(object);
            for (var i = 0; i < N; i++)
            {
                ret = FindDo(5);
            }
            return ret;
        }

        private object FindFor(int key)
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

        public EntryClass Next;

        public EntryClass(int key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
