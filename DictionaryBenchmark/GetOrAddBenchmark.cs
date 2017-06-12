namespace DictionaryBenchmark
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    using BenchmarkDotNet.Attributes;

    using DictionaryBenchmark.Library;

    public class GetOrAddBenchmark
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

        private readonly HashArrayMap<Type, object> hashArrayMap = new HashArrayMap<Type, object>(1024);

        private ImMap<Type, object> imMap = ImMap<Type, object>.Empty;

        public GetOrAddBenchmark()
        {
            foreach (var type in Classes.Types)
            {
                dictionary[type] = new object();
                dictionaryWithLock[type] = new object();
                concurrentDictionary[type] = new object();
                hashArrayMap.Add(type, new object());
                imMap = imMap.AddOrUpdate(type, new object());
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static object Factory(Type type)
        {
            return new object();
        }

        //[Benchmark]
        //public void Dictionary()
        //{
        //    for (var count = 0; count < Loop; count++)
        //    {
        //        DictionaryAction(type00);
        //        DictionaryAction(type01);
        //        DictionaryAction(type02);
        //        DictionaryAction(type03);
        //        DictionaryAction(type04);
        //        DictionaryAction(type05);
        //        DictionaryAction(type06);
        //        DictionaryAction(type07);
        //        DictionaryAction(type08);
        //        DictionaryAction(type09);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void DictionaryAction(Type key)
        //{
        //    if (!dictionary.TryGetValue(key, out object _))
        //    {
        //        dictionary[key] = Factory(key);
        //    }
        //}

        //[Benchmark]
        //public void DictionaryWithLock()
        //{
        //    for (var count = 0; count < Loop; count++)
        //    {
        //        DictionaryWithLockAction(type00);
        //        DictionaryWithLockAction(type01);
        //        DictionaryWithLockAction(type02);
        //        DictionaryWithLockAction(type03);
        //        DictionaryWithLockAction(type04);
        //        DictionaryWithLockAction(type05);
        //        DictionaryWithLockAction(type06);
        //        DictionaryWithLockAction(type07);
        //        DictionaryWithLockAction(type08);
        //        DictionaryWithLockAction(type09);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void DictionaryWithLockAction(Type key)
        //{
        //    lock (dictionaryWithLock)
        //    {
        //        if (!dictionaryWithLock.TryGetValue(key, out object _))
        //        {
        //            dictionaryWithLock[key] = Factory(key);
        //        }
        //    }
        //}

        //[Benchmark]
        //public void ConcurrentDictionary()
        //{
        //    for (var count = 0; count < Loop; count++)
        //    {
        //        ConcurrentDictionaryAction(type00);
        //        ConcurrentDictionaryAction(type01);
        //        ConcurrentDictionaryAction(type02);
        //        ConcurrentDictionaryAction(type03);
        //        ConcurrentDictionaryAction(type04);
        //        ConcurrentDictionaryAction(type05);
        //        ConcurrentDictionaryAction(type06);
        //        ConcurrentDictionaryAction(type07);
        //        ConcurrentDictionaryAction(type08);
        //        ConcurrentDictionaryAction(type09);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void ConcurrentDictionaryAction(Type key)
        //{
        //    concurrentDictionary.GetOrAdd(key, Factory);
        //}

        [Benchmark]
        public void HashArrayMap()
        {
            for (var count = 0; count < Loop; count++)
            {
                HashArrayMapAction(type00);
                HashArrayMapAction(type01);
                HashArrayMapAction(type02);
                HashArrayMapAction(type03);
                HashArrayMapAction(type04);
                HashArrayMapAction(type05);
                HashArrayMapAction(type06);
                HashArrayMapAction(type07);
                HashArrayMapAction(type08);
                HashArrayMapAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void HashArrayMapAction(Type key)
        {
            hashArrayMap.TryGetValue(key, out object _);
        }

        [Benchmark]
        public void ImMap()
        {
            for (var count = 0; count < Loop; count++)
            {
                ImMapAction(type00);
                ImMapAction(type01);
                ImMapAction(type02);
                ImMapAction(type03);
                ImMapAction(type04);
                ImMapAction(type05);
                ImMapAction(type06);
                ImMapAction(type07);
                ImMapAction(type08);
                ImMapAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ImMapAction(Type key)
        {
            if (imMap.GetValueOrDefault(key) == null)
            {
                imMap = imMap.AddOrUpdate(key, Factory(key));
            }
        }
    }
}
