namespace LookupBenchmark
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
            Add(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private static readonly Type[] Types =
        {
            typeof(bool), typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint),
            typeof(long), typeof(ulong), typeof(IntPtr), typeof(UIntPtr), typeof(char), typeof(double), typeof(float),
            typeof(decimal)
        };

        private static readonly Dictionary<Type, object> DefaultValues = new Dictionary<Type, object>
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

        private static readonly ThreadsafeTypeHashArrayMap<object> DevaultValues2 = new ThreadsafeTypeHashArrayMap<object>();

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

        private static readonly bool DefaultBool = default;
        private static readonly byte DefaultByte = default;
        private static readonly sbyte DefaultSByte = default;
        private static readonly short DefaultShort = default;
        private static readonly ushort DefaultUShort = default;
        private static readonly int DefaultInt = default;
        private static readonly uint DefaultUInt = default;
        private static readonly long DefaultLong = default;
        private static readonly ulong DefaultULong = default;
        private static readonly IntPtr DefaultIntPtr = default;
        private static readonly UIntPtr DefaultUIntPtr = default;
        private static readonly char DefaultChar = default;
        private static readonly double DefaultDouble = default;
        private static readonly float DefaultFloat = default;
        private static readonly decimal DefaultDecimal = default;

        static Benchmark()
        {
            foreach (var pair in DefaultValues)
            {
                DevaultValues2.AddIfNotExist(pair.Key, pair.Value);
            }
        }

        [Benchmark]
        public void Current()
        {
            for (var i = 0; i < 15; i++)
            {
                DefaultValues.TryGetValue(Types[i], out var _);
            }
        }

        [Benchmark]
        public void ThreadSafe()
        {
            for (var i = 0; i < 15; i++)
            {
                DefaultValues.TryGetValue(Types[i], out var _);
            }
        }

        [Benchmark]
        public void If()
        {
            for (var i = 0; i < 15; i++)
            {
                GetDefaultValue(Types[i]);
            }
        }

        [Benchmark]
        public void If2()
        {
            for (var i = 0; i < 5; i++)
            {
                GetDefaultValue(Types[i]);
            }

            for (var i = 0; i < 5; i++)
            {
                GetDefaultValue(Types[i]);
            }

            for (var i = 0; i < 5; i++)
            {
                GetDefaultValue(Types[i]);
            }
        }

        // ReSharper disable once UnusedMethodReturnValue.Local
        private static object GetDefaultValue(Type type)
        {
            if (type == IntType) return DefaultInt;
            if (type == LongType) return DefaultLong;
            if (type == ShortType) return DefaultShort;
            if (type == ByteType) return DefaultByte;
            if (type == BoolType) return DefaultBool;
            if (type == DecimalType) return DefaultDecimal;
            if (type == CharType) return DefaultChar;
            if (type == DoubleType) return DefaultDouble;
            if (type == FloatType) return DefaultFloat;
            if (type == UIntType) return DefaultUInt;
            if (type == ULongType) return DefaultULong;
            if (type == UShortType) return DefaultUShort;
            if (type == SByteType) return DefaultSByte;
            if (type == IntPtrType) return DefaultIntPtr;
            if (type == UIntPtrType) return DefaultUIntPtr;

            return null;
        }
    }
}
