namespace DefaultLookupBenchmark
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
            //Add(Job.MediumRun);
            Add(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private static readonly Type BoolType = typeof(bool);
        private static readonly Type ByteType = typeof(byte);
        private static readonly Type SByteType = typeof(sbyte);
        private static readonly Type ShortType = typeof(short);
        private static readonly Type UShortType = typeof(ushort);
        private static readonly Type IntType = typeof(int);
        private static readonly Type UIntType = typeof(uint);
        private static readonly Type LongType = typeof(long);
        private static readonly Type ULongType = typeof(ulong);
        private static readonly Type IntPtrType = typeof(IntPtr);
        private static readonly Type UIntPtrType = typeof(UIntPtr);
        private static readonly Type CharType = typeof(char);
        private static readonly Type DoubleType = typeof(double);
        private static readonly Type FloatType = typeof(float);
        private static readonly Type DecimalType = typeof(decimal);

        private const int NumOfTypes = 28;

        private static readonly Type[] Types =
        {
            IntType, IntType, IntType, IntType, IntType, IntType, IntType, IntType, IntType, IntType,
            BoolType, BoolType, BoolType, BoolType,
            LongType, LongType, LongType, LongType,
            ShortType, ShortType,
            ByteType,
            CharType,
            DoubleType, DoubleType,
            FloatType, FloatType,
            DecimalType, DecimalType
        };

        private const int NumOfFlatTypes = 15;

        private static readonly Type[] FlatTypes =
        {
            BoolType,
            ByteType,
            SByteType,
            ShortType,
            UShortType,
            IntType,
            UIntType,
            LongType,
            ULongType,
            IntPtrType,
            UIntPtrType,
            CharType,
            DoubleType,
            FloatType,
            DecimalType
        };

        // Dictionary

        [Benchmark(OperationsPerInvoke = NumOfTypes)]
        public void Dictionary()
        {
            for (var i = 0; i < Types.Length; i++)
            {
                Types[i].GetDefaultByDictionary();
            }
        }

        [Benchmark(OperationsPerInvoke = NumOfFlatTypes)]
        public void DictionaryFlat()
        {
            for (var i = 0; i < FlatTypes.Length; i++)
            {
                FlatTypes[i].GetDefaultByDictionary();
            }
        }

        // HashArrayMap

        [Benchmark(OperationsPerInvoke = NumOfTypes)]
        public void HashArrayMap()
        {
            for (var i = 0; i < Types.Length; i++)
            {
                Types[i].GetDefaultByHashArrayMap();
            }
        }

        [Benchmark(OperationsPerInvoke = NumOfFlatTypes)]
        public void HashArrayMapFlat()
        {
            for (var i = 0; i < FlatTypes.Length; i++)
            {
                FlatTypes[i].GetDefaultByHashArrayMap();
            }
        }

        // Sequence

        [Benchmark(OperationsPerInvoke = NumOfTypes)]
        public void Sequence()
        {
            for (var i = 0; i < Types.Length; i++)
            {
                Types[i].GetDefaultBySequence();
            }
        }

        [Benchmark(OperationsPerInvoke = NumOfFlatTypes)]
        public void SequenceFlat()
        {
            for (var i = 0; i < FlatTypes.Length; i++)
            {
                FlatTypes[i].GetDefaultBySequence();
            }
        }

        [Benchmark]
        public void SequenceBest()
        {
            IntType.GetDefaultBySequence();
        }

        [Benchmark]
        public void SequenceWorst()
        {
            UIntPtrType.GetDefaultBySequence();
        }

        // Sequence2

        [Benchmark(OperationsPerInvoke = NumOfTypes)]
        public void Sequence2()
        {
            for (var i = 0; i < Types.Length; i++)
            {
                Types[i].GetDefaultBySequence2();
            }
        }

        [Benchmark(OperationsPerInvoke = NumOfFlatTypes)]
        public void SequenceFlat2()
        {
            for (var i = 0; i < FlatTypes.Length; i++)
            {
                FlatTypes[i].GetDefaultBySequence2();
            }
        }

        [Benchmark]
        public void SequenceBest2()
        {
            IntType.GetDefaultBySequence2();
        }

        [Benchmark]
        public void SequenceWorst2()
        {
            UIntPtrType.GetDefaultBySequence2();
        }

        // Sequence3

        [Benchmark(OperationsPerInvoke = NumOfTypes)]
        public void Sequence3()
        {
            for (var i = 0; i < Types.Length; i++)
            {
                Types[i].GetDefaultBySequence3();
            }
        }

        [Benchmark(OperationsPerInvoke = NumOfFlatTypes)]
        public void SequenceFlat3()
        {
            for (var i = 0; i < FlatTypes.Length; i++)
            {
                FlatTypes[i].GetDefaultBySequence3();
            }
        }

        [Benchmark]
        public void SequenceBest3()
        {
            IntType.GetDefaultBySequence3();
        }

        [Benchmark]
        public void SequenceWorst3()
        {
            UIntPtrType.GetDefaultBySequence3();
        }
    }

    public static class TypeExtensions
    {
        private static readonly Type BoolType = typeof(bool);
        private static readonly Type ByteType = typeof(byte);
        private static readonly Type SByteType = typeof(sbyte);
        private static readonly Type ShortType = typeof(short);
        private static readonly Type UShortType = typeof(ushort);
        private static readonly Type IntType = typeof(int);
        private static readonly Type UIntType = typeof(uint);
        private static readonly Type LongType = typeof(long);
        private static readonly Type ULongType = typeof(ulong);
        private static readonly Type IntPtrType = typeof(IntPtr);
        private static readonly Type UIntPtrType = typeof(UIntPtr);
        private static readonly Type CharType = typeof(char);
        private static readonly Type DoubleType = typeof(double);
        private static readonly Type FloatType = typeof(float);
        private static readonly Type DecimalType = typeof(decimal);

        private static readonly int BoolTypeHash = BoolType.GetHashCode();
        private static readonly int ByteTypeHash = ByteType.GetHashCode();
        private static readonly int SByteTypeHash = SByteType.GetHashCode();
        private static readonly int ShortTypeHash = ShortType.GetHashCode();
        private static readonly int UShortTypeHash = UShortType.GetHashCode();
        private static readonly int IntTypeHash = IntType.GetHashCode();
        private static readonly int UIntTypeHash = UIntType.GetHashCode();
        private static readonly int LongTypeHash = LongType.GetHashCode();
        private static readonly int ULongTypeHash = ULongType.GetHashCode();
        private static readonly int IntPtrTypeHash = IntPtrType.GetHashCode();
        private static readonly int UIntPtrTypeHash = UIntPtrType.GetHashCode();
        private static readonly int CharTypeHash = CharType.GetHashCode();
        private static readonly int DoubleTypeHash = DoubleType.GetHashCode();
        private static readonly int FloatTypeHash = FloatType.GetHashCode();
        private static readonly int DecimalTypeHash = DecimalType.GetHashCode();

        // Dictionary

        private static readonly Dictionary<Type, object> DefaultValueDictionary = new Dictionary<Type, object>
        {
            { typeof(bool), false },
            { typeof(byte), (byte)0 },
            { typeof(sbyte), (sbyte)0 },
            { typeof(short), (short)0 },
            { typeof(ushort), (ushort)0 },
            { typeof(int), 0 },
            { typeof(uint), 0U },
            { typeof(long), 0L },
            { typeof(ulong), 0UL },
            { typeof(IntPtr), IntPtr.Zero },
            { typeof(UIntPtr), UIntPtr.Zero },
            { typeof(char), '\0' },
            { typeof(double), 0.0 },
            { typeof(float), 0.0f },
            { typeof(decimal), 0m }
        };

        public static object GetDefaultByDictionary(this Type type)
        {
            if (DefaultValueDictionary.TryGetValue(type, out var value))
            {
                return value;
            }

            return null;
        }

        // HashArray

        private static readonly ThreadsafeTypeHashArrayMap<object> DefaultValueMap = new ThreadsafeTypeHashArrayMap<object>();

        private static readonly Func<Type, object> Factory = Activator.CreateInstance;

        static TypeExtensions()
        {
            DefaultValueMap.AddIfNotExist(typeof(bool), false);
            DefaultValueMap.AddIfNotExist(typeof(byte), (byte)0);
            DefaultValueMap.AddIfNotExist(typeof(sbyte), (sbyte)0);
            DefaultValueMap.AddIfNotExist(typeof(short), (short)0);
            DefaultValueMap.AddIfNotExist(typeof(ushort), (ushort)0);
            DefaultValueMap.AddIfNotExist(typeof(int), 0);
            DefaultValueMap.AddIfNotExist(typeof(uint), 0U);
            DefaultValueMap.AddIfNotExist(typeof(long), 0L);
            DefaultValueMap.AddIfNotExist(typeof(ulong), 0UL);
            DefaultValueMap.AddIfNotExist(typeof(IntPtr), IntPtr.Zero);
            DefaultValueMap.AddIfNotExist(typeof(UIntPtr), UIntPtr.Zero);
            DefaultValueMap.AddIfNotExist(typeof(char), '\0');
            DefaultValueMap.AddIfNotExist(typeof(double), 0.0);
            DefaultValueMap.AddIfNotExist(typeof(float), 0.0f);
            DefaultValueMap.AddIfNotExist(typeof(decimal), 0m);
        }

        public static object GetDefaultByHashArrayMap(this Type type)
        {
            if (DefaultValueMap.TryGetValue(type, out var value))
            {
                return value;
            }

            return DefaultValueMap.AddIfNotExist(type, Factory);
        }

        // Sequence

        public sealed class Holder
        {
            public Type Type { get; }

            public int Hash { get; }

            public object DefaultValue { get; }

            public Holder(Type type, object defaultValue)
            {
                Type = type;
                Hash = type.GetHashCode();
                DefaultValue = defaultValue;
            }
        }

        private static readonly Holder[] DefaultValueHolders =
        {
            new Holder(typeof(int), 0),
            new Holder(typeof(bool), false),
            new Holder(typeof(long), 0L),
            new Holder(typeof(short), (short)0),
            new Holder(typeof(decimal), 0),
            new Holder(typeof(double), 0.0),
            new Holder(typeof(float), 0.0f),
            new Holder(typeof(byte), (byte)0),
            new Holder(typeof(char), '\0'),
            new Holder(typeof(uint), 0U),
            new Holder(typeof(ulong), 0UL),
            new Holder(typeof(ushort), (ushort)0),
            new Holder(typeof(sbyte), (sbyte)0),
            new Holder(typeof(IntPtr), IntPtr.Zero),
            new Holder(typeof(UIntPtr), UIntPtr.Zero)
        };

        public static object GetDefaultBySequence(this Type type)
        {
            for (var i = 0; i < DefaultValueHolders.Length; i++)
            {
                var holder = DefaultValueHolders[i];
                if (holder.Type == type)
                {
                    return holder.DefaultValue;
                }
            }

            return null;
        }

        public static object GetDefaultBySequence2(this Type type)
        {
            var hash = type.GetHashCode();
            for (var i = 0; i < DefaultValueHolders.Length; i++)
            {
                var holder = DefaultValueHolders[i];
                if (holder.Hash == hash && holder.Type == type)
                {
                    return holder.DefaultValue;
                }
            }

            return null;
        }



        public static object GetDefaultBySequence3(this Type type)
        {
            var hash = type.GetHashCode();
            if ((hash == IntTypeHash) && (type == IntType)) return default(int);
            if ((hash == BoolTypeHash) && (type == BoolType)) return default(bool);
            if ((hash == LongTypeHash) && (type == LongType)) return default(long);
            if ((hash == ShortTypeHash) && (type == ShortType)) return default(short);
            if ((hash == DecimalTypeHash) && (type == DecimalType)) return default(decimal);
            if ((hash == DoubleTypeHash) && (type == DoubleType)) return default(double);
            if ((hash == FloatTypeHash) && (type == FloatType)) return default(float);
            if ((hash == ByteTypeHash) && (type == ByteType)) return default(byte);
            if ((hash == CharTypeHash) && (type == CharType)) return default(char);
            if ((hash == UIntTypeHash) && (type == UIntType)) return default(uint);
            if ((hash == ULongTypeHash) && (type == ULongType)) return default(ulong);
            if ((hash == UShortTypeHash) && (type == UShortType)) return default(ushort);
            if ((hash == SByteTypeHash) && (type == SByteType)) return default(sbyte);
            if ((hash == IntPtrTypeHash) && (type == IntPtrType)) return default(IntPtr);
            if ((hash == UIntPtrTypeHash) && (type == UIntPtrType)) return default(UIntPtr);

            return null;
        }
    }
}
