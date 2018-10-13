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

        //private static readonly Thew

        // Sequence

        public sealed class Holder
        {
            public Type Type { get; }

            public object DefaultValue { get; }

            public Holder(Type type, object defaultValue)
            {
                Type = type;
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

        // [MEMO] slow
        //public static object GetDefaultBySequence2(this Type type)
        //{
        //    if (type == IntType) return default(int);
        //    if (type == BoolType) return default(bool);
        //    if (type == LongType) return default(long);
        //    if (type == ShortType) return default(short);
        //    if (type == DecimalType) return default(decimal);
        //    if (type == DoubleType) return default(double);
        //    if (type == FloatType) return default(float);
        //    if (type == ByteType) return default(byte);
        //    if (type == CharType) return default(char);
        //    if (type == UIntType) return default(uint);
        //    if (type == ULongType) return default(ulong);
        //    if (type == UShortType) return default(ushort);
        //    if (type == SByteType) return default(sbyte);
        //    if (type == IntPtrType) return default(IntPtr);
        //    if (type == UIntPtrType) return default(UIntPtr);

        //    return null;
        //}
    }
}
