namespace EquatableBenchmark
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
            Add(Job.MediumRun);
        }
    }

    public sealed class MapperKey
    {
        public Type Type { get; }

        public string Profile { get; }

        public MapperKey(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is MapperKey other)
            {
                return Type == other.Type && Profile == other.Profile;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = Type.GetHashCode();
            hash = hash ^ Profile.GetHashCode();
            return hash;
        }
    }

    public sealed class MapperKey2 : IEquatable<MapperKey2>
    {
        public Type Type { get; }

        public string Profile { get; }

        public MapperKey2(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public bool Equals(MapperKey2 other) => Type == other.Type && Profile == other.Profile;

        public override bool Equals(object obj) => obj is MapperKey2 other && Equals(other);

        public override int GetHashCode() => (Type, Profile).GetHashCode();
    }

    public sealed class MapperKey3
    {
        public Type Type { get; }

        public string Profile { get; }

        public MapperKey3(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public override bool Equals(object obj) => obj is MapperKey3 other && Type == other.Type && Profile == other.Profile;

        public override int GetHashCode() => (Type, Profile).GetHashCode();
    }

    public readonly struct MapperKeyStruct
    {
        public Type Type { get; }

        public string Profile { get; }

        public MapperKeyStruct(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is MapperKeyStruct other)
            {
                return Type == other.Type && Profile == other.Profile;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = Type.GetHashCode();
            hash = hash ^ Profile.GetHashCode();
            return hash;
        }
    }

    public readonly struct MapperKeyStruct2 : IEquatable<MapperKeyStruct2>
    {
        public Type Type { get; }

        public string Profile { get; }

        public MapperKeyStruct2(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public bool Equals(MapperKeyStruct2 other) => Type == other.Type && Profile == other.Profile;

        public override bool Equals(object obj) => obj is MapperKeyStruct2 other && Equals(other);

        public override int GetHashCode() => (Type, Profile).GetHashCode();
    }

    public readonly struct MapperKeyStruct3
    {
        public Type Type { get; }

        public string Profile { get; }

        public MapperKeyStruct3(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public override bool Equals(object obj) => obj is MapperKeyStruct3 other && Type == other.Type && Profile == other.Profile;

        public override int GetHashCode() => (Type, Profile).GetHashCode();
    }


    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly Dictionary<MapperKey, object> dic = new Dictionary<MapperKey, object>();
        private readonly Dictionary<MapperKey2, object> dic2 = new Dictionary<MapperKey2, object>();
        private readonly Dictionary<MapperKey3, object> dic3 = new Dictionary<MapperKey3, object>();
        private readonly Dictionary<MapperKeyStruct, object> dicS = new Dictionary<MapperKeyStruct, object>();
        private readonly Dictionary<MapperKeyStruct2, object> dic2S = new Dictionary<MapperKeyStruct2, object>();
        private readonly Dictionary<MapperKeyStruct3, object> dic3S = new Dictionary<MapperKeyStruct3, object>();

        private readonly ThreadsafeHashArrayMap<MapperKey, object> map = new ThreadsafeHashArrayMap<MapperKey, object>();
        private readonly ThreadsafeHashArrayMap<MapperKey2, object> map2 = new ThreadsafeHashArrayMap<MapperKey2, object>();
        private readonly ThreadsafeHashArrayMap<MapperKey3, object> map3 = new ThreadsafeHashArrayMap<MapperKey3, object>();
        private readonly ThreadsafeHashArrayMap<MapperKeyStruct, object> mapS = new ThreadsafeHashArrayMap<MapperKeyStruct, object>();
        private readonly ThreadsafeHashArrayMap<MapperKeyStruct2, object> map2S = new ThreadsafeHashArrayMap<MapperKeyStruct2, object>();
        private readonly ThreadsafeHashArrayMap<MapperKeyStruct3, object> map3S = new ThreadsafeHashArrayMap<MapperKeyStruct3, object>();

        private readonly ThreadsafeObjectHashArrayMap<MapperKey, object> mapO = new ThreadsafeObjectHashArrayMap<MapperKey, object>();
        private readonly ThreadsafeObjectHashArrayMap<MapperKey2, object> mapO2 = new ThreadsafeObjectHashArrayMap<MapperKey2, object>();
        private readonly ThreadsafeObjectHashArrayMap<MapperKey3, object> mapO3 = new ThreadsafeObjectHashArrayMap<MapperKey3, object>();

        private readonly MapperKey key = new MapperKey(typeof(Class00), "0");
        private readonly MapperKey2 key2 = new MapperKey2(typeof(Class00), "0");
        private readonly MapperKey3 key3 = new MapperKey3(typeof(Class00), "0");
        private readonly MapperKeyStruct keyS = new MapperKeyStruct(typeof(Class00), "0");
        private readonly MapperKeyStruct2 keyS2 = new MapperKeyStruct2(typeof(Class00), "0");
        private readonly MapperKeyStruct3 keyS3 = new MapperKeyStruct3(typeof(Class00), "0");

        private readonly object instance = new object();

        [GlobalSetup]
        public void Setup()
        {
            foreach (var type in Classes.Types)
            {
                for (var i = 0; i < 2; i++)
                {
                    var name = i.ToString();

                    dic[new MapperKey(type, name)] = instance;
                    dic2[new MapperKey2(type, name)] = instance;
                    dic3[new MapperKey3(type, name)] = instance;
                    dicS[new MapperKeyStruct(type, name)] = instance;
                    dic2S[new MapperKeyStruct2(type, name)] = instance;
                    dic3S[new MapperKeyStruct3(type, name)] = instance;
                    map.AddIfNotExist(new MapperKey(type, name), instance);
                    map2.AddIfNotExist(new MapperKey2(type, name), instance);
                    map3.AddIfNotExist(new MapperKey3(type, name), instance);
                    mapS.AddIfNotExist(new MapperKeyStruct(type, name), instance);
                    map2S.AddIfNotExist(new MapperKeyStruct2(type, name), instance);
                    map3S.AddIfNotExist(new MapperKeyStruct3(type, name), instance);
                    mapO.AddIfNotExist(new MapperKey(type, name), instance);
                    mapO2.AddIfNotExist(new MapperKey2(type, name), instance);
                    mapO3.AddIfNotExist(new MapperKey3(type, name), instance);
                }
            }
        }

        // Key cached

        [Benchmark]
        public void CachedDictionary() => dic.TryGetValue(key, out _);

        [Benchmark]
        public void CachedDictionary2() => dic2.TryGetValue(key2, out _);

        [Benchmark]
        public void CachedDictionary3() => dic3.TryGetValue(key3, out _);

        [Benchmark]
        public void CachedDictionaryS() => dicS.TryGetValue(keyS, out _);

        [Benchmark]
        public void CachedDictionary2S() => dic2S.TryGetValue(keyS2, out _);

        [Benchmark]
        public void CachedDictionary3S() => dic3S.TryGetValue(keyS3, out _);

        [Benchmark]
        public void CachedArrayMap() => map.TryGetValue(key, out _);

        [Benchmark]
        public void CachedArrayMap2() => map2.TryGetValue(key2, out _);

        [Benchmark]
        public void CachedArrayMap3() => map3.TryGetValue(key3, out _);

        [Benchmark]
        public void CachedArrayMapS() => mapS.TryGetValue(keyS, out _);

        [Benchmark]
        public void CachedArrayMap2S() => map2S.TryGetValue(keyS2, out _);

        [Benchmark]
        public void CachedArrayMap3S() => map3S.TryGetValue(keyS3, out _);

        [Benchmark]
        public void CachedArrayMapO() => mapO.TryGetValue(key, out _);

        [Benchmark]
        public void CachedArrayMapO2() => mapO2.TryGetValue(key2, out _);

        [Benchmark]
        public void CachedArrayMapO3() => mapO3.TryGetValue(key3, out _);

        // Loop

        [Benchmark(OperationsPerInvoke = 10)]
        public void Dictionary()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                dic.TryGetValue(new MapperKey(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void Dictionary2()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                dic2.TryGetValue(new MapperKey2(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void Dictionary3()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                dic3.TryGetValue(new MapperKey3(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void DictionaryS()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                dicS.TryGetValue(new MapperKeyStruct(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void Dictionary2S()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                dic2S.TryGetValue(new MapperKeyStruct2(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void Dictionary3S()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                dic3S.TryGetValue(new MapperKeyStruct3(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMap()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                map.TryGetValue(new MapperKey(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMap2()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                map2.TryGetValue(new MapperKey2(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMap3()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                map3.TryGetValue(new MapperKey3(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMapS()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                mapS.TryGetValue(new MapperKeyStruct(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMap2S()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                map2S.TryGetValue(new MapperKeyStruct2(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMap3S()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                map3S.TryGetValue(new MapperKeyStruct3(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMapO()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                mapO.TryGetValue(new MapperKey(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMapO2()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                mapO2.TryGetValue(new MapperKey2(Classes.Types[i], "0"), out _);
            }
        }

        [Benchmark(OperationsPerInvoke = 10)]
        public void ArrayMapO3()
        {
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                mapO3.TryGetValue(new MapperKey3(Classes.Types[i], "0"), out _);
            }
        }
    }

    public class Class00 { }
    public class Class01 { }
    public class Class02 { }
    public class Class03 { }
    public class Class04 { }
    public class Class05 { }
    public class Class06 { }
    public class Class07 { }
    public class Class08 { }
    public class Class09 { }

    public static class Classes
    {
        public static Type[] Types => new[]
        {
            typeof(Class00),
            typeof(Class01),
            typeof(Class02),
            typeof(Class03),
            typeof(Class04),
            typeof(Class05),
            typeof(Class06),
            typeof(Class07),
            typeof(Class08),
            typeof(Class09),
        };
    }
}
