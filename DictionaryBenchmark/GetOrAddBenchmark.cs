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

        private readonly HashListLookupTable<Type, object> lookupTable1 = new HashListLookupTable<Type, object>(1024);

        private readonly HashListLookupTable<Type, object> lookupTable1WithLock = new HashListLookupTable<Type, object>(1024);

        private readonly HashArrayLookupTable<Type, object> lookupTable2 = new HashArrayLookupTable<Type, object>(1024);

        private readonly HashArrayLookupTable<Type, object> lookupTable2WithLock = new HashArrayLookupTable<Type, object>(1024);

        private readonly LookupTable<Type, object> lookupTable = new LookupTable<Type, object>(1024);

        private readonly LookupTable<Type, object> lookupTableWithLock = new LookupTable<Type, object>(1024);

        private readonly ImMap<Type, object> imMap = ImMap<Type, object>.Empty;

        private readonly ImMap<Type, object> imMapWithLocked = ImMap<Type, object>.Empty;

        public GetOrAddBenchmark()
        {
            foreach (var type in Classes.Types)
            {
                dictionary[type] = new object();
                dictionaryWithLock[type] = new object();
                concurrentDictionary[type] = new object();
                lookupTable1.Add(type, new object());
                lookupTable1WithLock.Add(type, new object());
                lookupTable2.Add(type, new object());
                lookupTable2WithLock.Add(type, new object());
                lookupTable.Add(type, new object());
                lookupTableWithLock.Add(type, new object());
                imMap = imMap.AddOrUpdate(type, new object());
                imMapWithLocked = imMapWithLocked.AddOrUpdate(type, new object());
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
                dictionaryWithLock.TryGetValue(key, out object _);
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
            concurrentDictionary.TryGetValue(key, out object _);
        }

        [Benchmark]
        public void LookupTable1()
        {
            for (var count = 0; count < Loop; count++)
            {
                LookupTable1Action(type00);
                LookupTable1Action(type01);
                LookupTable1Action(type02);
                LookupTable1Action(type03);
                LookupTable1Action(type04);
                LookupTable1Action(type05);
                LookupTable1Action(type06);
                LookupTable1Action(type07);
                LookupTable1Action(type08);
                LookupTable1Action(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LookupTable1Action(Type key)
        {
            lookupTable.TryGetValue(key, out object _);
        }

        [Benchmark]
        public void LookupTable1WithLock()
        {
            for (var count = 0; count < Loop; count++)
            {
                LookupTable1WithLock(type00);
                LookupTable1WithLock(type01);
                LookupTable1WithLock(type02);
                LookupTable1WithLock(type03);
                LookupTable1WithLock(type04);
                LookupTable1WithLock(type05);
                LookupTable1WithLock(type06);
                LookupTable1WithLock(type07);
                LookupTable1WithLock(type08);
                LookupTable1WithLock(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LookupTable1WithLock(Type key)
        {
            lock (lookupTable1WithLock)
            {
                lookupTable1WithLock.TryGetValue(key, out object _);
            }
        }

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

        [Benchmark]
        public void LookupTable2WithLock()
        {
            for (var count = 0; count < Loop; count++)
            {
                LookupTable2WithLock(type00);
                LookupTable2WithLock(type01);
                LookupTable2WithLock(type02);
                LookupTable2WithLock(type03);
                LookupTable2WithLock(type04);
                LookupTable2WithLock(type05);
                LookupTable2WithLock(type06);
                LookupTable2WithLock(type07);
                LookupTable2WithLock(type08);
                LookupTable2WithLock(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LookupTable2WithLock(Type key)
        {
            lock (lookupTable2WithLock)
            {
                lookupTable2WithLock.TryGetValue(key, out object _);
            }
        }

        [Benchmark]
        public void LookupTable()
        {
            for (var count = 0; count < Loop; count++)
            {
                LookupTableAction(type00);
                LookupTableAction(type01);
                LookupTableAction(type03);
                LookupTableAction(type03);
                LookupTableAction(type04);
                LookupTableAction(type05);
                LookupTableAction(type06);
                LookupTableAction(type07);
                LookupTableAction(type08);
                LookupTableAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LookupTableAction(Type key)
        {
            lookupTable.TryGetValue(key, out object _);
        }

        [Benchmark]
        public void LookupTableWithLock()
        {
            for (var count = 0; count < Loop; count++)
            {
                LookupTableWithLockAction(type00);
                LookupTableWithLockAction(type01);
                LookupTableWithLockAction(type03);
                LookupTableWithLockAction(type03);
                LookupTableWithLockAction(type04);
                LookupTableWithLockAction(type05);
                LookupTableWithLockAction(type06);
                LookupTableWithLockAction(type07);
                LookupTableWithLockAction(type08);
                LookupTableWithLockAction(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LookupTableWithLockAction(Type key)
        {
            lock (lookupTable)
            {
                lookupTableWithLock.TryGetValue(key, out object _);
            }
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
            imMap.GetValueOrDefault(key);
        }

        [Benchmark]
        public void ImMapWithLocked()
        {
            for (var count = 0; count < Loop; count++)
            {
                ImMapActionWithLocked(type00);
                ImMapActionWithLocked(type01);
                ImMapActionWithLocked(type02);
                ImMapActionWithLocked(type03);
                ImMapActionWithLocked(type04);
                ImMapActionWithLocked(type05);
                ImMapActionWithLocked(type06);
                ImMapActionWithLocked(type07);
                ImMapActionWithLocked(type08);
                ImMapActionWithLocked(type09);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ImMapActionWithLocked(Type key)
        {
            lock (imMapWithLocked)
            {
                imMapWithLocked.GetValueOrDefault(key);
            }
        }
    }
}
