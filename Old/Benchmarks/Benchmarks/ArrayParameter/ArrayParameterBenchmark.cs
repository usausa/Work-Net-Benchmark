namespace Benchmarks.ArrayParameter
{
    using System;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class ArrayParameterBenchmark
    {
        private const int N = 1000;

        [ThreadStatic]
        public static Key[] KeyPool;

        private readonly Key[] data =
        {
            new Key(typeof(object), "Aaa123"),
            new Key(typeof(object), "Bbb123"),
            new Key(typeof(object), "Ccc123"),
            new Key(typeof(object), "Ddd123"),
        };

        [Benchmark(OperationsPerInvoke = N)]
        public int New()
        {
            var ret = 0;
            for (var loop = 0; loop < N; loop++)
            {
                var parameters = data;
                var keys = new Key[parameters.Length];
                for (var i = 0; i < keys.Length; i++)
                {
                    var parameter = parameters[i];
                    keys[i] = new Key(parameter.Type, parameter.Name);
                }

                ret = Calc(keys);
            }

            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int ThreadLocalPool()
        {
            var ret = 0;
            for (var loop = 0; loop < N; loop++)
            {
                var parameters = data;
                var length = parameters.Length;
                if ((KeyPool == null) || (KeyPool.Length < length))
                {
                    KeyPool = new Key[length];
                }

                var keys = new Span<Key>(KeyPool, 0, length);
                for (var i = 0; i < keys.Length; i++)
                {
                    var parameter = parameters[i];
                    keys[i] = new Key(parameter.Type, parameter.Name);
                }

                ret = Calc(keys);
            }

            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int ThreadLocalPool2()
        {
            var ret = 0;
            for (var loop = 0; loop < N; loop++)
            {
                var parameters = data;
                var length = parameters.Length;
                if ((KeyPool == null) || (KeyPool.Length < length))
                {
                    KeyPool = new Key[length];
                }

                for (var i = 0; i < length; i++)
                {
                    var parameter = parameters[i];
                    KeyPool[i] = new Key(parameter.Type, parameter.Name);
                }

                ret = Calc(new Span<Key>(KeyPool, 0, length));
            }

            return ret;
        }

        private static int Calc(Span<Key> keys)
        {
            var hash = 0;
            for (var i = 0; i < keys.Length; i++)
            {
                var key = keys[i];
                hash ^= key.Type.GetHashCode();
                hash ^= key.Name.GetHashCode(StringComparison.Ordinal);
            }

            return hash;
        }
    }

    public readonly struct Key
    {
        public readonly Type Type;

        public readonly string Name;

        public Key(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }

}
