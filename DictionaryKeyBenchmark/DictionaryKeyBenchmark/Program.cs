namespace DictionaryKeyBenchmark
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

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly Dictionary<ClassTypePair, object> classDictionary = new Dictionary<ClassTypePair, object>(new ClassTypePairComparer());

        private readonly Dictionary<StructTypePair, object> structDictionary = new Dictionary<StructTypePair, object>(new StructTypePairComparer());

        private readonly Dictionary<EquatableClassTypePair, object> equatableClassDictionary = new Dictionary<EquatableClassTypePair, object>();

        private readonly Dictionary<EquatableStructTypePair, object> equatableStructDictionary = new Dictionary<EquatableStructTypePair, object>();

        private readonly Dictionary<EquatableClassTypePair2, object> equatableClassDictionary2 = new Dictionary<EquatableClassTypePair2, object>();

        private readonly Dictionary<EquatableStructTypePair2, object> equatableStructDictionary2 = new Dictionary<EquatableStructTypePair2, object>();

        private readonly ThreadsafeHashArrayMap<ClassTypePair, object> classHashArray = new ThreadsafeHashArrayMap<ClassTypePair, object>(new ClassTypePairComparer(), 512);

        private readonly ThreadsafeHashArrayMap<StructTypePair, object> structHashArray = new ThreadsafeHashArrayMap<StructTypePair, object>(new StructTypePairComparer(), 512);

        private readonly ThreadsafeHashArrayMap<EquatableClassTypePair, object> equatableClassHashArray = new ThreadsafeHashArrayMap<EquatableClassTypePair, object>(512);

        private readonly ThreadsafeHashArrayMap<EquatableStructTypePair, object> equatableStructHashArray = new ThreadsafeHashArrayMap<EquatableStructTypePair, object>(512);

        private readonly ThreadsafeHashArrayMap<EquatableClassTypePair2, object> equatableClassHashArray2 = new ThreadsafeHashArrayMap<EquatableClassTypePair2, object>(512);

        private readonly ThreadsafeHashArrayMap<EquatableStructTypePair2, object> equatableStructHashArray2 = new ThreadsafeHashArrayMap<EquatableStructTypePair2, object>(512);

        [GlobalSetup]
        public void Setup()
        {
            var obj = new object();

            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    classDictionary[new ClassTypePair(Classes.Types[i], Classes.Types[j])] = obj;
                    structDictionary[new StructTypePair(Classes.Types[i], Classes.Types[j])] = obj;
                    equatableClassDictionary[new EquatableClassTypePair(Classes.Types[i], Classes.Types[j])] = obj;
                    equatableStructDictionary[new EquatableStructTypePair(Classes.Types[i], Classes.Types[j])] = obj;
                    equatableClassDictionary2[new EquatableClassTypePair2(Classes.Types[i], Classes.Types[j])] = obj;
                    equatableStructDictionary2[new EquatableStructTypePair2(Classes.Types[i], Classes.Types[j])] = obj;

                    classHashArray.AddIfNotExist(new ClassTypePair(Classes.Types[i], Classes.Types[j]), obj);
                    structHashArray.AddIfNotExist(new StructTypePair(Classes.Types[i], Classes.Types[j]), obj);
                    equatableClassHashArray.AddIfNotExist(new EquatableClassTypePair(Classes.Types[i], Classes.Types[j]), obj);
                    equatableStructHashArray.AddIfNotExist(new EquatableStructTypePair(Classes.Types[i], Classes.Types[j]), obj);
                    equatableClassHashArray2.AddIfNotExist(new EquatableClassTypePair2(Classes.Types[i], Classes.Types[j]), obj);
                    equatableStructHashArray2.AddIfNotExist(new EquatableStructTypePair2(Classes.Types[i], Classes.Types[j]), obj);
                }
            }
        }

        [Benchmark]
        public object DictionaryClassKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = classDictionary[new ClassTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object DictionaryStructKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = structDictionary[new StructTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object DictionaryEquatableClassKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableClassDictionary[new EquatableClassTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object DictionaryEquatableStructKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableStructDictionary[new EquatableStructTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object DictionaryEquatableClassKey2()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableClassDictionary2[new EquatableClassTypePair2(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object DictionaryEquatableStructKey2()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableStructDictionary2[new EquatableStructTypePair2(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object HashArrayClassKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = classHashArray[new ClassTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object HashArrayStructKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = structHashArray[new StructTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object HashArrayEquatableClassKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableClassHashArray[new EquatableClassTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object HashArrayEquatableStructKey()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableStructHashArray[new EquatableStructTypePair(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object HashArrayEquatableClassKey2()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableClassHashArray2[new EquatableClassTypePair2(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }

        [Benchmark]
        public object HashArrayEquatableStructKey2()
        {
            var obj = default(object);
            for (var i = 0; i < Classes.Types.Length; i++)
            {
                for (var j = 0; j < Classes.Types.Length; j++)
                {
                    obj = equatableStructHashArray2[new EquatableStructTypePair2(Classes.Types[i], Classes.Types[j])];
                }
            }

            return obj;
        }
    }

    public sealed class ClassTypePair
    {
        public Type Type1 { get; }

        public Type Type2 { get; }

        public ClassTypePair(Type type1, Type type2)
        {
            Type1 = type1;
            Type2 = type2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Type1.GetHashCode() * 397) ^ Type2.GetHashCode();
            }
        }
    }


    public sealed class ClassTypePairComparer : IEqualityComparer<ClassTypePair>
    {
        public bool Equals(ClassTypePair x, ClassTypePair y)
        {
            return x.Type1 == y.Type1 && x.Type2 == y.Type2;
        }

        public int GetHashCode(ClassTypePair obj)
        {
            return obj.GetHashCode();
        }
    }

    public struct StructTypePair
    {
        public Type Type1 { get; }

        public Type Type2 { get; }

        public StructTypePair(Type type1, Type type2)
        {
            Type1 = type1;
            Type2 = type2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Type1.GetHashCode() * 397) ^ Type2.GetHashCode();
            }
        }
    }

    public sealed class StructTypePairComparer : IEqualityComparer<StructTypePair>
    {
        public bool Equals(StructTypePair x, StructTypePair y)
        {
            return x.Type1 == y.Type1 && x.Type2 == y.Type2;
        }

        public int GetHashCode(StructTypePair obj)
        {
            return obj.GetHashCode();
        }
    }

    public sealed class EquatableClassTypePair : IEquatable<EquatableClassTypePair>
    {
        public Type Type1 { get; }

        public Type Type2 { get; }

        public EquatableClassTypePair(Type type1, Type type2)
        {
            Type1 = type1;
            Type2 = type2;
        }

        public bool Equals(EquatableClassTypePair other)
        {
            return Type1 == other.Type1 && Type2 == other.Type2;
        }

        public override bool Equals(object obj)
        {
            return obj is EquatableStructTypePair2 pair && Type1 == pair.Type1 && Type2 == pair.Type2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Type1.GetHashCode() * 397) ^ Type2.GetHashCode();
            }
        }
    }

    public struct EquatableStructTypePair : IEquatable<EquatableStructTypePair>
    {
        public Type Type1 { get; }

        public Type Type2 { get; }

        public EquatableStructTypePair(Type type1, Type type2)
        {
            Type1 = type1;
            Type2 = type2;
        }

        public bool Equals(EquatableStructTypePair other)
        {
            return Type1 == other.Type1 && Type2 == other.Type2;
        }

        public override bool Equals(object obj)
        {
            return obj is EquatableStructTypePair2 pair && Type1 == pair.Type1 && Type2 == pair.Type2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Type1.GetHashCode() * 397) ^ Type2.GetHashCode();
            }
        }
    }

    public sealed class EquatableClassTypePair2 : IEquatable<EquatableClassTypePair2>
    {
        public Type Type1 { get; }

        public Type Type2 { get; }

        public EquatableClassTypePair2(Type type1, Type type2)
        {
            Type1 = type1;
            Type2 = type2;
        }

        public bool Equals(EquatableClassTypePair2 other)
        {
            return Type1 == other.Type1 && Type2 == other.Type2;
        }

        public override bool Equals(object obj)
        {
            return obj is EquatableStructTypePair2 pair && Type1 == pair.Type1 && Type2 == pair.Type2;
        }

        public override int GetHashCode() => ValueTuple.Create(Type1, Type2).GetHashCode();
    }

    public struct EquatableStructTypePair2 : IEquatable<EquatableStructTypePair2>
    {
        public Type Type1 { get; }

        public Type Type2 { get; }

        public EquatableStructTypePair2(Type type1, Type type2)
        {
            Type1 = type1;
            Type2 = type2;
        }

        public bool Equals(EquatableStructTypePair2 other)
        {
            return Type1 == other.Type1 && Type2 == other.Type2;
        }

        public override bool Equals(object obj)
        {
            return obj is EquatableStructTypePair2 pair && Type1 == pair.Type1 && Type2 == pair.Type2;
        }

        public override int GetHashCode() => ValueTuple.Create(Type1, Type2).GetHashCode();
    }
}
