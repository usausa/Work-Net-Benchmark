﻿namespace SmallLookupBenchmark
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
        private readonly LockArray<object> lockArray = new LockArray<object>();
        private readonly NumberLockArray<object> numberLockArray = new NumberLockArray<object>();
        private readonly Dictionary<Type, object> dictionary = new Dictionary<Type, object>();
        private readonly ThreadsafeTypeHashArrayMap<object> hashArrayMap = new ThreadsafeTypeHashArrayMap<object>();

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
            lockArray.GetOrCreate(Extension1.Token, Factory);
            lockArray.GetOrCreate(Extension2.Token, Factory);
            lockArray.GetOrCreate(Extension3.Token, Factory);
            numberLockArray.GetOrCreate(0, Factory);
            numberLockArray.GetOrCreate(1, Factory);
            numberLockArray.GetOrCreate(2, Factory);
            lock (dictionary)
            {
                dictionary[Extension1.TypeToken] = Factory();
                dictionary[Extension2.TypeToken] = Factory();
                dictionary[Extension3.TypeToken] = Factory();
            }
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, Factory);
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, Factory);
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, Factory);
        }

        [Benchmark]
        public void LockArray1()
        {
            lockArray.GetOrCreate(Extension1.Token, Factory);
        }

        [Benchmark]
        public void LockArray2()
        {
            lockArray.GetOrCreate(Extension2.Token, Factory);
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void LockArrayN()
        {
            lockArray.GetOrCreate(Extension1.Token, Factory);
            lockArray.GetOrCreate(Extension2.Token, Factory);
            lockArray.GetOrCreate(Extension3.Token, Factory);
        }

        [Benchmark]
        public void NumberLockArray1()
        {
            numberLockArray.GetOrCreate(0, Factory);
        }

        [Benchmark]
        public void NumberLockArray2()
        {
            numberLockArray.GetOrCreate(1, Factory);
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void NumberLockArrayN()
        {
            numberLockArray.GetOrCreate(0, Factory);
            numberLockArray.GetOrCreate(1, Factory);
            numberLockArray.GetOrCreate(2, Factory);
        }

        [Benchmark]
        public void LockDictionary1()
        {
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension1.TypeToken, out _))
                {
                    dictionary[Extension1.TypeToken] = Factory();
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
                    dictionary[Extension2.TypeToken] = Factory();
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
                    dictionary[Extension1.TypeToken] = Factory();
                }
            }
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension2.TypeToken, out _))
                {
                    dictionary[Extension2.TypeToken] = Factory();
                }
            }
            lock (dictionary)
            {
                if (!dictionary.TryGetValue(Extension3.TypeToken, out _))
                {
                    dictionary[Extension3.TypeToken] = Factory();
                }
            }
        }

        [Benchmark]
        public void ThreadsafeHashArray1()
        {
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, Factory);
        }

        [Benchmark]
        public void ThreadsafeHashArray2()
        {
            hashArrayMap.AddIfNotExist(Extension2.TypeToken, Factory);
        }

        [Benchmark(OperationsPerInvoke = 3)]
        public void ThreadsafeHashArrayN()
        {
            hashArrayMap.AddIfNotExist(Extension1.TypeToken, Factory);
            hashArrayMap.AddIfNotExist(Extension2.TypeToken, Factory);
            hashArrayMap.AddIfNotExist(Extension3.TypeToken, Factory);
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
