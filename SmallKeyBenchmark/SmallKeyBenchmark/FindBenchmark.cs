namespace SmallKeyBenchmark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;

    using Smart.Collections.Generic;
    using Smart.Collections.Generic.Concurrent;

    public class FindBenchmark
    {
        private const int Loop = 100;

        private readonly Type type00 = typeof(Class00);
        private readonly Type type10 = typeof(Class10);
        private readonly Type type20 = typeof(Class20);
        private readonly Type type30 = typeof(Class30);
        private readonly Type type40 = typeof(Class40);
        private readonly Type type50 = typeof(Class50);
        private readonly Type type60 = typeof(Class60);
        private readonly Type type70 = typeof(Class70);
        private readonly Type type80 = typeof(Class80);
        private readonly Type type90 = typeof(Class90);

        private readonly Dictionary<Type, object> dic1 = new Dictionary<Type, object>();
        private readonly Dictionary<Type, object> dic2 = new Dictionary<Type, object>();
        private readonly Dictionary<Type, object> dic3 = new Dictionary<Type, object>();

        private readonly ConcurrentHashArrayMap<Type, object> map1 = new ConcurrentHashArrayMap<Type, object>();
        private readonly ConcurrentHashArrayMap<Type, object> map2 = new ConcurrentHashArrayMap<Type, object>();
        private readonly ConcurrentHashArrayMap<Type, object> map3 = new ConcurrentHashArrayMap<Type, object>();

        private readonly KeyValuePair<Type, object>[] ary1;
        private readonly KeyValuePair<Type, object>[] ary2;
        private readonly KeyValuePair<Type, object>[] ary3;

        public FindBenchmark()
        {
            // 4.0us(キーが綺麗な時)
            dic1.AddRange(Classes.Types.Take(2).Select(x => new KeyValuePair<Type, object>(x, null)));
            dic2.AddRange(Classes.Types.Take(4).Select(x => new KeyValuePair<Type, object>(x, null)));
            dic3.AddRange(Classes.Types.Take(8).Select(x => new KeyValuePair<Type, object>(x, null)));

            // 1.6us(キーが綺麗な時)
            map1.AddRangeIfNotExist(Classes.Types.Take(2).Select(x => new KeyValuePair<Type, object>(x, null)));
            map2.AddRangeIfNotExist(Classes.Types.Take(4).Select(x => new KeyValuePair<Type, object>(x, null)));
            map3.AddRangeIfNotExist(Classes.Types.Take(8).Select(x => new KeyValuePair<Type, object>(x, null)));

            // 2us, 4us, 8us(4つまでならArrayの方が速い？)
            ary1 = Classes.Types.Take(2).Select(x => new KeyValuePair<Type, object>(x, null)).ToArray();
            ary2 = Classes.Types.Take(4).Select(x => new KeyValuePair<Type, object>(x, null)).ToArray();
            ary3 = Classes.Types.Take(8).Select(x => new KeyValuePair<Type, object>(x, null)).ToArray();
        }

        [Benchmark]
        public void Dictionary1()
        {
            for (var i = 0; i < Loop; i++)
            {
                dic1.TryGetValue(type00, out object _);
                dic1.TryGetValue(type10, out object _);
                dic1.TryGetValue(type20, out object _);
                dic1.TryGetValue(type30, out object _);
                dic1.TryGetValue(type40, out object _);
                dic1.TryGetValue(type50, out object _);
                dic1.TryGetValue(type60, out object _);
                dic1.TryGetValue(type70, out object _);
                dic1.TryGetValue(type80, out object _);
                dic1.TryGetValue(type90, out object _);
            }
        }

        [Benchmark]
        public void Dictionary2()
        {
            for (var i = 0; i < Loop; i++)
            {
                dic2.TryGetValue(type00, out object _);
                dic2.TryGetValue(type10, out object _);
                dic2.TryGetValue(type20, out object _);
                dic2.TryGetValue(type30, out object _);
                dic2.TryGetValue(type40, out object _);
                dic2.TryGetValue(type50, out object _);
                dic2.TryGetValue(type60, out object _);
                dic2.TryGetValue(type70, out object _);
                dic2.TryGetValue(type80, out object _);
                dic2.TryGetValue(type90, out object _);
            }
        }

        [Benchmark]
        public void Dictionary3()
        {
            for (var i = 0; i < Loop; i++)
            {
                dic3.TryGetValue(type00, out object _);
                dic3.TryGetValue(type10, out object _);
                dic3.TryGetValue(type20, out object _);
                dic3.TryGetValue(type30, out object _);
                dic3.TryGetValue(type40, out object _);
                dic3.TryGetValue(type50, out object _);
                dic3.TryGetValue(type60, out object _);
                dic3.TryGetValue(type70, out object _);
                dic3.TryGetValue(type80, out object _);
                dic3.TryGetValue(type90, out object _);
            }
        }

        [Benchmark]
        public void Map1()
        {
            for (var i = 0; i < Loop; i++)
            {
                map1.TryGetValue(type00, out object _);
                map1.TryGetValue(type10, out object _);
                map1.TryGetValue(type20, out object _);
                map1.TryGetValue(type30, out object _);
                map1.TryGetValue(type40, out object _);
                map1.TryGetValue(type50, out object _);
                map1.TryGetValue(type60, out object _);
                map1.TryGetValue(type70, out object _);
                map1.TryGetValue(type80, out object _);
                map1.TryGetValue(type90, out object _);
            }
        }

        [Benchmark]
        public void Map2()
        {
            for (var i = 0; i < Loop; i++)
            {
                map2.TryGetValue(type00, out object _);
                map2.TryGetValue(type10, out object _);
                map2.TryGetValue(type20, out object _);
                map2.TryGetValue(type30, out object _);
                map2.TryGetValue(type40, out object _);
                map2.TryGetValue(type50, out object _);
                map2.TryGetValue(type60, out object _);
                map2.TryGetValue(type70, out object _);
                map2.TryGetValue(type80, out object _);
                map2.TryGetValue(type90, out object _);
            }
        }

        [Benchmark]
        public void Map3()
        {
            for (var i = 0; i < Loop; i++)
            {
                map3.TryGetValue(type00, out object _);
                map3.TryGetValue(type10, out object _);
                map3.TryGetValue(type20, out object _);
                map3.TryGetValue(type30, out object _);
                map3.TryGetValue(type40, out object _);
                map3.TryGetValue(type50, out object _);
                map3.TryGetValue(type60, out object _);
                map3.TryGetValue(type70, out object _);
                map3.TryGetValue(type80, out object _);
                map3.TryGetValue(type90, out object _);
            }
        }

        [Benchmark]
        public void Array1()
        {
            for (var i = 0; i < Loop; i++)
            {
                Find(ary1, type00, out object _);
                Find(ary1, type10, out object _);
                Find(ary1, type20, out object _);
                Find(ary1, type30, out object _);
                Find(ary1, type40, out object _);
                Find(ary1, type50, out object _);
                Find(ary1, type60, out object _);
                Find(ary1, type70, out object _);
                Find(ary1, type80, out object _);
                Find(ary1, type90, out object _);
            }
        }

        [Benchmark]
        public void Array2()
        {
            for (var i = 0; i < Loop; i++)
            {
                Find(ary2, type00, out object _);
                Find(ary2, type10, out object _);
                Find(ary2, type20, out object _);
                Find(ary2, type30, out object _);
                Find(ary2, type40, out object _);
                Find(ary2, type50, out object _);
                Find(ary2, type60, out object _);
                Find(ary2, type70, out object _);
                Find(ary2, type80, out object _);
                Find(ary2, type90, out object _);
            }
        }

        [Benchmark]
        public void Array3()
        {
            for (var i = 0; i < Loop; i++)
            {
                Find(ary3, type00, out object _);
                Find(ary3, type10, out object _);
                Find(ary3, type20, out object _);
                Find(ary3, type30, out object _);
                Find(ary3, type40, out object _);
                Find(ary3, type50, out object _);
                Find(ary3, type60, out object _);
                Find(ary3, type70, out object _);
                Find(ary3, type80, out object _);
                Find(ary3, type90, out object _);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool Find(KeyValuePair<Type, object>[] array, Type key, out object value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var pair = array[i];
                if (ReferenceEquals(pair.Key, key) || pair.Key.Equals(key))
                //if (ReferenceEquals(pair.Key, key))
                {
                    value = pair.Value;
                    return true;
                }
            }

            value = null;
            return false;
        }
    }
}
