namespace DictionaryBenchmark
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

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

        private readonly HashListLookupTable<Type, object> lookupTable = new HashListLookupTable<Type, object>(1024);

        private readonly HashListLookupTable<Type, object> lookupTableWithLock = new HashListLookupTable<Type, object>(1024);

        private readonly HashArrayLookupTable<Type, object> lookupTable2 = new HashArrayLookupTable<Type, object>(1024);

        private readonly HashArrayLookupTable<Type, object> lookupTable2WithLock = new HashArrayLookupTable<Type, object>(1024);

        private readonly ImMap<Type, object> imMap = ImMap<Type, object>.Empty;

        private readonly ImTreeMap<Type, object> imTreeMap = ImTreeMap<Type, object>.Empty;

        public GetOrAddBenchmark()
        {
            foreach (var type in Classes.Types)
            {
                dictionary[type] = new object();
                dictionaryWithLock[type] = new object();
                concurrentDictionary[type] = new object();
                lookupTable.Add(type, new object());
                lookupTableWithLock.Add(type, new object());
                lookupTable2.Add(type, new object());
                lookupTable2WithLock.Add(type, new object());
                imMap.AddOrUpdate(type, new object());
                imTreeMap.AddOrUpdate(type, new object());
            }
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
            dictionary.TryGetValue(key, out object _);
        }

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
        //        dictionaryWithLock.TryGetValue(key, out object _);
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
        //    concurrentDictionary.TryGetValue(key, out object _);
        //}

        //[Benchmark]
        //public void LookupTable()
        //{
        //    for (var count = 0; count < Loop; count++)
        //    {
        //        LookupTableAction(type00);
        //        LookupTableAction(type01);
        //        LookupTableAction(type02);
        //        LookupTableAction(type03);
        //        LookupTableAction(type04);
        //        LookupTableAction(type05);
        //        LookupTableAction(type06);
        //        LookupTableAction(type07);
        //        LookupTableAction(type08);
        //        LookupTableAction(type09);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void LookupTableAction(Type key)
        //{
        //    lookupTable.TryGetValue(key, out object _);
        //}

        //[Benchmark]
        //public void LookupTableWithLock()
        //{
        //    for (var count = 0; count < Loop; count++)
        //    {
        //        LookupTableWithLock(type00);
        //        LookupTableWithLock(type01);
        //        LookupTableWithLock(type02);
        //        LookupTableWithLock(type03);
        //        LookupTableWithLock(type04);
        //        LookupTableWithLock(type05);
        //        LookupTableWithLock(type06);
        //        LookupTableWithLock(type07);
        //        LookupTableWithLock(type08);
        //        LookupTableWithLock(type09);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void LookupTableWithLock(Type key)
        //{
        //    lock (lookupTableWithLock)
        //    {
        //        lookupTableWithLock.TryGetValue(key, out object _);
        //    }
        //}

        [Benchmark]
        public void LookupTable2()
        {
            for (var count = 0; count < Loop; count++)
            {
                LookupTable2Action(type00);
                LookupTable2Action(type01);
                LookupTable2Action(type02);
                LookupTable2Action(type03);
                LookupTable2Action(type04);
                LookupTable2Action(type05);
                LookupTable2Action(type06);
                LookupTable2Action(type07);
                LookupTable2Action(type08);
                LookupTable2Action(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LookupTable2Action(Type key)
        {
            lookupTable2.TryGetValue(key, out object _);
        }

        //[Benchmark]
        //public void LookupTable2WithLock()
        //{
        //    for (var count = 0; count < Loop; count++)
        //    {
        //        LookupTable2WithLock(type00);
        //        LookupTable2WithLock(type01);
        //        LookupTable2WithLock(type02);
        //        LookupTable2WithLock(type03);
        //        LookupTable2WithLock(type04);
        //        LookupTable2WithLock(type05);
        //        LookupTable2WithLock(type06);
        //        LookupTable2WithLock(type07);
        //        LookupTable2WithLock(type08);
        //        LookupTable2WithLock(type09);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void LookupTable2WithLock(Type key)
        //{
        //    lock (lookupTable2WithLock)
        //    {
        //        lookupTable2WithLock.TryGetValue(key, out object _);
        //    }
        //}

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
            imMap.GetValueOrDefault(key);
        }

        //[Benchmark]
        //public void ImTreeMap()
        //{
        //    for (var count = 0; count < Loop; count++)
        //    {
        //        ImTreeMapAction(type00);
        //        ImTreeMapAction(type01);
        //        ImTreeMapAction(type02);
        //        ImTreeMapAction(type03);
        //        ImTreeMapAction(type04);
        //        ImTreeMapAction(type05);
        //        ImTreeMapAction(type06);
        //        ImTreeMapAction(type07);
        //        ImTreeMapAction(type08);
        //        ImTreeMapAction(type09);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private void ImTreeMapAction(Type key)
        //{
        //    imTreeMap.GetValueOrDefault(key);
        //}
    }
}
