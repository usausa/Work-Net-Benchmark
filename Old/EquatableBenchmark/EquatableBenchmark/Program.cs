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
            //Add(Job.ShortRun);
        }
    }

    public sealed class ClassEquatableKey : IEquatable<ClassEquatableKey>
    {
        public Type Type { get; }

        public string Profile { get; }

        public ClassEquatableKey(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public bool Equals(ClassEquatableKey other)
        {
            return String.Equals(Profile, other.Profile) && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            return obj is ClassEquatableKey other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Profile is null ? Type.GetHashCode() : Type.GetHashCode() ^ (Profile.GetHashCode() * 397);
            }
        }
    }

    public sealed class ClassKey
    {
        public Type Type { get; }

        public string Profile { get; }

        public ClassKey(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Profile is null ? Type.GetHashCode() : Type.GetHashCode() ^ (Profile.GetHashCode() * 397);
            }
        }
    }

    public sealed class ClassKeyComparer : IEqualityComparer<ClassKey>
    {
        public bool Equals(ClassKey x, ClassKey y)
        {
            return String.Equals(x.Profile, y.Profile) && x.Type == y.Type;
        }

        public int GetHashCode(ClassKey obj)
        {
            return obj.GetHashCode();
        }
    }

    public readonly struct StructEquatableKey : IEquatable<StructEquatableKey>
    {
        public Type Type { get; }

        public string Profile { get; }

        public StructEquatableKey(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public bool Equals(StructEquatableKey other)
        {
            return String.Equals(Profile, other.Profile) && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            return obj is StructEquatableKey other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Profile is null ? Type.GetHashCode() : Type.GetHashCode() ^ (Profile.GetHashCode() * 397);
            }
        }
    }

    public readonly struct StructKey
    {
        public Type Type { get; }

        public string Profile { get; }

        public StructKey(Type type, string profile)
        {
            Type = type;
            Profile = profile;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Profile is null ? Type.GetHashCode() : Type.GetHashCode() ^ (Profile.GetHashCode() * 397);
            }
        }
    }

    public readonly struct StructKeyComparer : IEqualityComparer<StructKey>
    {
        public bool Equals(StructKey x, StructKey y)
        {
            return String.Equals(x.Profile, y.Profile) && x.Type == y.Type;
        }

        public int GetHashCode(StructKey obj)
        {
            return obj.GetHashCode();
        }
    }


    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly Dictionary<ClassEquatableKey, object> dicClassEquatable = new Dictionary<ClassEquatableKey, object>();

        private readonly Dictionary<ClassKey, object> dicClassComparer = new Dictionary<ClassKey, object>(new ClassKeyComparer());

        private readonly Dictionary<StructEquatableKey, object> dicStructEquatable = new Dictionary<StructEquatableKey, object>();

        private readonly Dictionary<StructKey, object> dicStructComparer = new Dictionary<StructKey, object>(new StructKeyComparer());

        private readonly ThreadsafeHashArrayMap<ClassEquatableKey, object> hashClassEquatable = new ThreadsafeHashArrayMap<ClassEquatableKey, object>();

        private readonly ThreadsafeHashArrayMap<ClassKey, object> hashClassComparer = new ThreadsafeHashArrayMap<ClassKey, object>(new ClassKeyComparer());

        private readonly ThreadsafeHashArrayMap<StructEquatableKey, object> hashStructEquatable = new ThreadsafeHashArrayMap<StructEquatableKey, object>();

        private readonly ThreadsafeHashArrayMap<StructKey, object> hashStructComparer = new ThreadsafeHashArrayMap<StructKey, object>(new StructKeyComparer());

        private readonly object instance = new object();

        private static Type[] Types => new[]
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

        private readonly string[] profiles = { null, "xyz" };

        [GlobalSetup]
        public void Setup()
        {
            foreach (var type in Types)
            {
                for (var i = 0; i < profiles.Length; i++)
                {
                    var profile = profiles[i];

                    dicClassEquatable[new ClassEquatableKey(type, profile)] = instance;
                    dicClassComparer[new ClassKey(type, profile)] = instance;
                    dicStructEquatable[new StructEquatableKey(type, profile)] = instance;
                    dicStructComparer[new StructKey(type, profile)] = instance;
                    hashClassEquatable.AddIfNotExist(new ClassEquatableKey(type, profile), instance);
                    hashClassComparer.AddIfNotExist(new ClassKey(type, profile), instance);
                    hashStructEquatable.AddIfNotExist(new StructEquatableKey(type, profile), instance);
                    hashStructComparer.AddIfNotExist(new StructKey(type, profile), instance);
                }
            }

            if (!DictionaryClassEquatableNull()) throw new Exception();
            if (!DictionaryClassEquatableProfile()) throw new Exception();
            if (!DictionaryClassComparerNull()) throw new Exception();
            if (!DictionaryClassComparerProfile()) throw new Exception();
            if (!DictionaryStructEquatableNull()) throw new Exception();
            if (!DictionaryStructEquatableProfile()) throw new Exception();
            if (!DictionaryStructComparerNull()) throw new Exception();
            if (!DictionaryStructComparerProfile()) throw new Exception();
            if (!HashClassEquatableNull()) throw new Exception();
            if (!HashClassEquatableProfile()) throw new Exception();
            if (!HashClassComparerNull()) throw new Exception();
            if (!HashClassComparerProfile()) throw new Exception();
            if (!HashStructEquatableNull()) throw new Exception();
            if (!HashStructEquatableProfile()) throw new Exception();
            if (!HashStructComparerNull()) throw new Exception();
            if (!HashStructComparerProfile()) throw new Exception();
        }

        [Benchmark]
        public bool DictionaryClassEquatableNull() =>
            dicClassEquatable.TryGetValue(new ClassEquatableKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool DictionaryClassEquatableProfile() =>
                dicClassEquatable.TryGetValue(new ClassEquatableKey(typeof(Class00), "xyz"), out _);

        [Benchmark]
        public bool DictionaryClassComparerNull() =>
                dicClassComparer.TryGetValue(new ClassKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool DictionaryClassComparerProfile() =>
                dicClassComparer.TryGetValue(new ClassKey(typeof(Class00), "xyz"), out _);

        [Benchmark]
        public bool DictionaryStructEquatableNull() =>
                dicStructEquatable.TryGetValue(new StructEquatableKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool DictionaryStructEquatableProfile() =>
                dicStructEquatable.TryGetValue(new StructEquatableKey(typeof(Class00), "xyz"), out _);

        [Benchmark]
        public bool DictionaryStructComparerNull() =>
                dicStructComparer.TryGetValue(new StructKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool DictionaryStructComparerProfile() =>
                dicStructComparer.TryGetValue(new StructKey(typeof(Class00), "xyz"), out _);

        [Benchmark]
        public bool HashClassEquatableNull() =>
                hashClassEquatable.TryGetValue(new ClassEquatableKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool HashClassEquatableProfile() =>
                hashClassEquatable.TryGetValue(new ClassEquatableKey(typeof(Class00), "xyz"), out _);

        [Benchmark]
        public bool HashClassComparerNull() =>
                hashClassComparer.TryGetValue(new ClassKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool HashClassComparerProfile() =>
                hashClassComparer.TryGetValue(new ClassKey(typeof(Class00), "xyz"), out _);

        [Benchmark]
        public bool HashStructEquatableNull() =>
                hashStructEquatable.TryGetValue(new StructEquatableKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool HashStructEquatableProfile() =>
                hashStructEquatable.TryGetValue(new StructEquatableKey(typeof(Class00), "xyz"), out _);

        [Benchmark]
        public bool HashStructComparerNull() =>
                hashStructComparer.TryGetValue(new StructKey(typeof(Class00), null), out _);

        [Benchmark]
        public bool HashStructComparerProfile() =>
                hashStructComparer.TryGetValue(new StructKey(typeof(Class00), "xyz"), out _);
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
}
