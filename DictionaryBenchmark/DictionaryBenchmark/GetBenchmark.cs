﻿namespace DictionaryBenchmark
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;

    using DictionaryBenchmark.Library;

    [Config(typeof(BenchmarkConfig))]
    public class GetBenchmark
    {
        private const int Loop = 1000;

        private readonly Type type00 = typeof(Class00);
        private readonly Type type01 = typeof(Class01);
        private readonly Type type02 = typeof(Class02);
        private readonly Type type03 = typeof(Class03);
        private readonly Type type04 = typeof(Class04);
        private readonly Type type05 = typeof(Class05);
        private readonly Type type06 = typeof(Class06);
        private readonly Type type07 = typeof(Class07);
        private readonly Type type08 = typeof(Class08);
        private readonly Type type09 = typeof(Class09);

        private readonly Dictionary<Type, object> dictionary = new Dictionary<Type, object>();

        private readonly Dictionary<Type, object> dictionaryWithLock = new Dictionary<Type, object>();

        private readonly ConcurrentDictionary<Type, object> concurrentDictionary = new ConcurrentDictionary<Type, object>();

        private ImMap<Type, object> imMap = ImMap<Type, object>.Empty;

        private readonly ConcurrentHashArrayMap<Type, object> hashArrayMap = new ConcurrentHashArrayMap<Type, object>(new GrowthHashArrayMapStrategy(64));

        [GlobalSetup]
        public void Setup()
        {
            lock (dictionaryWithLock)
            {
                foreach (var type in Classes.Types)
                {
                    dictionary[type] = new object();
                    dictionaryWithLock[type] = new object();
                    concurrentDictionary[type] = new object();
                    hashArrayMap.AddIfNotExist(type, new object());
                    imMap = imMap.AddOrUpdate(type, new object());
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static object Factory(Type type)
        {
            return new object();
        }

        [Benchmark]
        public void Dictionary()
        {
            for (var count = 0; count < Loop; count++)
            {
                DictionaryAction(type00);
                DictionaryAction(type01);
                DictionaryAction(type02);
                DictionaryAction(type03);
                DictionaryAction(type04);
                DictionaryAction(type05);
                DictionaryAction(type06);
                DictionaryAction(type07);
                DictionaryAction(type08);
                DictionaryAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DictionaryAction(Type key)
        {
            if (!dictionary.TryGetValue(key, out object _))
            {
                dictionary[key] = Factory(key);
            }
        }

        [Benchmark]
        public void DictionaryWithLock()
        {
            for (var count = 0; count < Loop; count++)
            {
                DictionaryWithLockAction(type00);
                DictionaryWithLockAction(type01);
                DictionaryWithLockAction(type02);
                DictionaryWithLockAction(type03);
                DictionaryWithLockAction(type04);
                DictionaryWithLockAction(type05);
                DictionaryWithLockAction(type06);
                DictionaryWithLockAction(type07);
                DictionaryWithLockAction(type08);
                DictionaryWithLockAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DictionaryWithLockAction(Type key)
        {
            lock (dictionaryWithLock)
            {
                if (!dictionaryWithLock.TryGetValue(key, out object _))
                {
                    dictionaryWithLock[key] = Factory(key);
                }
            }
        }

        [Benchmark]
        public void ConcurrentDictionary()
        {
            for (var count = 0; count < Loop; count++)
            {
                ConcurrentDictionaryAction(type00);
                ConcurrentDictionaryAction(type01);
                ConcurrentDictionaryAction(type02);
                ConcurrentDictionaryAction(type03);
                ConcurrentDictionaryAction(type04);
                ConcurrentDictionaryAction(type05);
                ConcurrentDictionaryAction(type06);
                ConcurrentDictionaryAction(type07);
                ConcurrentDictionaryAction(type08);
                ConcurrentDictionaryAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ConcurrentDictionaryAction(Type key)
        {
            concurrentDictionary.GetOrAdd(key, Factory);
        }

        [Benchmark]
        public void AvlTree()
        {
            for (var count = 0; count < Loop; count++)
            {
                AvlTreeAction(type00);
                AvlTreeAction(type01);
                AvlTreeAction(type02);
                AvlTreeAction(type03);
                AvlTreeAction(type04);
                AvlTreeAction(type05);
                AvlTreeAction(type06);
                AvlTreeAction(type07);
                AvlTreeAction(type08);
                AvlTreeAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AvlTreeAction(Type key)
        {
            if (imMap.GetValueOrDefault(key) is null)
            {
                imMap = imMap.AddOrUpdate(key, null);
            }
        }

        [Benchmark]
        public void ConcurrentHashArryMap()
        {
            for (var count = 0; count < Loop; count++)
            {
                ConcurrentHashArrayMapAction(type00);
                ConcurrentHashArrayMapAction(type01);
                ConcurrentHashArrayMapAction(type02);
                ConcurrentHashArrayMapAction(type03);
                ConcurrentHashArrayMapAction(type04);
                ConcurrentHashArrayMapAction(type05);
                ConcurrentHashArrayMapAction(type06);
                ConcurrentHashArrayMapAction(type07);
                ConcurrentHashArrayMapAction(type08);
                ConcurrentHashArrayMapAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ConcurrentHashArrayMapAction(Type key)
        {
            if (!hashArrayMap.TryGetValue(key, out object _))
            {
                hashArrayMap.AddIfNotExist(key, Factory);
            }
        }
    }
}
