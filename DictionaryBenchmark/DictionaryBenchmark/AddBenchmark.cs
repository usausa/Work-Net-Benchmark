namespace DictionaryBenchmark
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;

    using DictionaryBenchmark.Library;

    [Config(typeof(BenchmarkConfig))]
    public class AddBenchmark
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static object Factory(Type type)
        {
            return new object();
        }

        [Benchmark]
        public void Dictionary()
        {
            // ReSharper disable once CollectionNeverQueried.Local
            var dictionary = new Dictionary<Type, object>();
            foreach (var type in Classes.Types)
            {
                dictionary[type] = new object();
            }
        }

        [Benchmark]
        public void DictionaryWithLock()
        {
            var sync = new object();
            // ReSharper disable once CollectionNeverQueried.Local
            var dictionary = new Dictionary<Type, object>();
            foreach (var type in Classes.Types)
            {
                lock (sync)
                {
                    dictionary[type] = new object();
                }
            }
        }

        [Benchmark]
        public void ConcurrentDictionary()
        {
            var concurrentDictionary = new ConcurrentDictionary<Type, object>();
            foreach (var type in Classes.Types)
            {
                concurrentDictionary.GetOrAdd(type, Factory);
            }
        }

        [Benchmark]
        public void AvlTree()
        {
            var imMap = ImMap<Type, object>.Empty;
            foreach (var type in Classes.Types)
            {
                imMap = imMap.AddOrUpdate(type, null);
            }
        }

        [Benchmark]
        public void ConcurrentHashArrayMap()
        {
            var hashArrayMap = new ConcurrentHashArrayMap<Type, object>(new GrowthHashArrayMapStrategy(64));
            foreach (var type in Classes.Types)
            {
                hashArrayMap.AddIfNotExist(type, Factory);
            }
        }

        [Benchmark]
        public void ConcurrentHashArrayMapBulk()
        {
            var hashArrayMap = new ConcurrentHashArrayMap<Type, object>(new GrowthHashArrayMapStrategy(64));
            hashArrayMap.AddRangeIfNotExist(Classes.Types, Factory);
        }
    }
}
