namespace Benchmarks.KeyPairHash
{
    using System;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class KeyPairHashBenchmark
    {
        private readonly StructPair<Type, Type>[] typePairKeys = Enumerable.Range(1, 10000)
            .Select(x => new StructPair<Type, Type>(Classes.Types[x / 100], Classes.Types[x % 100]))
            .ToArray();

        private readonly StructPair<Type, string>[] typeStringKeys = Enumerable.Range(1, 10000)
            .Select(x => new StructPair<Type, string>(Classes.Types[x / 100], $"{x % 100}:D3"))
            .ToArray();

        [Benchmark(OperationsPerInvoke = 100 * 100)]
        public int TypePairXorWithoutLocal()
        {
            var ret = 0;
            for (var i = 0; i < typePairKeys.Length; i++)
            {
                ret = typePairKeys[i].Key1.GetHashCode() ^ typePairKeys[i].Key2.GetHashCode();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = 100 * 100)]
        public int TypePairXor()
        {
            var ret = 0;
            for (var i = 0; i < typePairKeys.Length; i++)
            {
                var pair = typePairKeys[i];
                ret = pair.Key1.GetHashCode() ^ pair.Key2.GetHashCode();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = 100 * 100)]
        public int TypePairXor397()
        {
            var ret = 0;
            for (var i = 0; i < typePairKeys.Length; i++)
            {
                var pair = typePairKeys[i];
                ret = (pair.Key1.GetHashCode() * 397) ^ pair.Key2.GetHashCode();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = 100 * 100)]
        public int TypePairValueTuple()
        {
            var ret = 0;
            for (var i = 0; i < typePairKeys.Length; i++)
            {
                var pair = typePairKeys[i];
                ret = ValueTuple.Create(pair.Key1, pair.Key2).GetHashCode();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = 100 * 100)]
        public int TypeStringXor()
        {
            var ret = 0;
            for (var i = 0; i < typeStringKeys.Length; i++)
            {
                var pair = typeStringKeys[i];
                ret = pair.Key1.GetHashCode() ^ pair.Key2.GetHashCode();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = 100 * 100)]
        public int TypeStringXor397()
        {
            var ret = 0;
            for (var i = 0; i < typeStringKeys.Length; i++)
            {
                var pair = typeStringKeys[i];
                ret = (pair.Key1.GetHashCode() * 397) ^ pair.Key2.GetHashCode();
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = 100 * 100)]
        public int TypeStringValueTuple()
        {
            var ret = 0;
            for (var i = 0; i < typeStringKeys.Length; i++)
            {
                var pair = typeStringKeys[i];
                ret = ValueTuple.Create(pair.Key1, pair.Key2).GetHashCode();
            }
            return ret;
        }
    }

    public struct StructPair<T1, T2>
    {
        public readonly T1 Key1;

        public readonly T2 Key2;

        public StructPair(T1 key1, T2 key2)
        {
            Key1 = key1;
            Key2 = key2;
        }
    }
}
