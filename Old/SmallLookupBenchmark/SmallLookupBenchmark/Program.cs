namespace SmallLookupBenchmark
{
    using System;
    using System.Collections.Generic;

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
            Add(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private static readonly Type TypeKey = typeof(object);

        private readonly LockArray<object> lockArray = new LockArray<object>();
        private readonly NumberLockArray<object> numberLockArray = new NumberLockArray<object>();
        private readonly Dictionary<Type, object> dictionary = new Dictionary<Type, object>();
        private readonly ThreadsafeTypeHashArrayMap<object> hashArrayMap = new ThreadsafeTypeHashArrayMap<object>();

        private readonly MetadataHashArray metadataHashArray = new MetadataHashArray();

        private readonly Func<object> factory;
        private readonly Func<Type, object> factoryByType;

        public Benchmark()
        {
            factory = Factory;
            factoryByType = Factory;
        }

        private object Factory()
        {
            return new object();
        }

        private object Factory(Type type)
        {
            return new object();
        }

        [GlobalSetup]
        public void Setup()
        {
            lockArray.GetOrCreate(Extension1.Token, factory);
            lockArray.GetOrCreate(Extension2.Token, factory);
            lockArray.GetOrCreate(Extension3.Token, factory);
            numberLockArray.GetOrCreate(0, factory);
            numberLockArray.GetOrCreate(1, factory);
            numberLockArray.GetOrCreate(2, factory);
            lock (dictionary)
            {
                dictionary[Extension1.TypeToken] = factory();
                dictionary[Extension2.TypeToken] = factory();
                dictionary[Extension3.TypeToken] = factory();
            }
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, factory);
            hashArrayMap.AddIfNotExist(Extension2.TypeToken, factory);
            hashArrayMap.AddIfNotExist(Extension3.TypeToken, factory);

            metadataHashArray.AddIfNotExist(0, TypeKey, factoryByType);
            metadataHashArray.AddIfNotExist(1, TypeKey, factoryByType);
            metadataHashArray.AddIfNotExist(2, TypeKey, factoryByType);
        }

        [Benchmark]
        public void LockArray1()
        {
            lockArray.GetOrCreate(Extension1.Token, factory);
        }

        [Benchmark]
        public void LockArray2()
        {
            lockArray.GetOrCreate(Extension2.Token, factory);
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void LockArrayN()
        {
            lockArray.GetOrCreate(Extension1.Token, factory);
            lockArray.GetOrCreate(Extension2.Token, factory);
            lockArray.GetOrCreate(Extension3.Token, factory);
        }

        [Benchmark]
        public void NumberLockArray1()
        {
            numberLockArray.GetOrCreate(0, factory);
        }

        [Benchmark]
        public void NumberLockArray2()
        {
            numberLockArray.GetOrCreate(1, factory);
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void NumberLockArrayN()
        {
            numberLockArray.GetOrCreate(0, factory);
            numberLockArray.GetOrCreate(1, factory);
            numberLockArray.GetOrCreate(2, factory);
        }

        [Benchmark]
        public void LockDictionary1()
        {
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension1.TypeToken, out _))
                {
                    dictionary[Extension1.TypeToken] = factory();
                }
            }
        }

        [Benchmark]
        public void LockDictionary2()
        {
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension2.TypeToken, out _))
                {
                    dictionary[Extension2.TypeToken] = factory();
                }
            }
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void LockDictionaryN()
        {
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension1.TypeToken, out _))
                {
                    dictionary[Extension1.TypeToken] = factory();
                }
            }
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension2.TypeToken, out _))
                {
                    dictionary[Extension2.TypeToken] = factory();
                }
            }
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension3.TypeToken, out _))
                {
                    dictionary[Extension3.TypeToken] = factory();
                }
            }
        }

        [Benchmark]
        public void ThreadsafeHashArray1()
        {
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, factory);
        }

        [Benchmark]
        public void ThreadsafeHashArray2()
        {
            hashArrayMap.AddIfNotExist(Extension2.TypeToken, factory);
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void ThreadsafeHashArrayN()
        {
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, factory);
            hashArrayMap.AddIfNotExist(Extension2.TypeToken, factory);
            hashArrayMap.AddIfNotExist(Extension3.TypeToken, factory);
        }

        [Benchmark]
        public void MetadataHashArray1()
        {
            metadataHashArray.AddIfNotExist(0, TypeKey, factoryByType);
        }

        [Benchmark]
        public void MetadataHashArray2()
        {
            metadataHashArray.AddIfNotExist(1, TypeKey, factoryByType);
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void MetadataHashArrayN()
        {
            metadataHashArray.AddIfNotExist(0, TypeKey, factoryByType);
            metadataHashArray.AddIfNotExist(1, TypeKey, factoryByType);
            metadataHashArray.AddIfNotExist(2, TypeKey, factoryByType);
        }
    }

    public sealed class LockArray<TValue>
    {
        private sealed class Entry
        {
            public object Token { get; set; }

            public TValue Value { get; set; }
        }

        private readonly object sync = new object();

        private Entry[] array = new Entry[0];

        public object GetOrCreate(object token, Func<TValue> factory)
        {
            lock (sync)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    if (ReferenceEquals(array[i].Token, token))
                    {
                        return array[i].Value;
                    }
                }

                var newArray = new Entry[array.Length + 1];
                Array.Copy(array, 0, newArray, 0, array.Length);
                array = newArray;
                var entry = new Entry { Token = token, Value = factory() };
                array[array.Length - 1] = entry;
                return entry;
            }
        }
    }

    public sealed class NumberLockArray<TValue>
    {
        private sealed class Entry
        {
            public int Token { get; set; }

            public TValue Value { get; set; }
        }

        private readonly object sync = new object();

        private Entry[] array = new Entry[0];

        public object GetOrCreate(int token, Func<TValue> factory)
        {
            lock (sync)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    if (array[i].Token == token)
                    {
                        return array[i].Value;
                    }
                }

                var newArray = new Entry[array.Length + 1];
                Array.Copy(array, 0, newArray, 0, array.Length);
                array = newArray;
                var entry = new Entry { Token = token, Value = factory() };
                array[array.Length - 1] = entry;
                return entry;
            }
        }
    }

    public static class Extension1
    {
        public static object Token { get; } = new object();

        public static Type TypeToken { get; } = typeof(Extension1);
    }

    public static class Extension2
    {
        public static object Token { get; } = new object();

        public static Type TypeToken { get; } = typeof(Extension2);
    }

    public static class Extension3
    {
        public static object Token { get; } = new object();

        public static Type TypeToken { get; } = typeof(Extension3);
    }
}
