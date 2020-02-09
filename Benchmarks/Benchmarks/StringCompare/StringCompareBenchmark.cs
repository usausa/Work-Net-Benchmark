namespace Benchmarks.StringCompare
{
    using System;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class StringCompareBenchmark
    {
        private const int N = 1000;

        private readonly string value = "01234567890ABCDEF";

        private readonly string valueSame = "01234567890ABCDEF";

        private readonly string valueNotSameLast = "01234567890ABCDE0";

        private readonly string valueShort = "01234567890ABCDE";

        private readonly string valueLong = "01234567890ABCDEF0";

        private readonly string valueNull = null;

        [Benchmark(OperationsPerInvoke = N)]
        public bool EqualsSame()
        {
            var ret = false;
            for (var i = 0; i < N; i++)
            {
                ret = value == valueSame;
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsSame()
        {
            var ret = false;
            for (var i = 0; i < N; i++)
            {
                ret = String.Equals(value, valueSame);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsSameOrdinal()
        {
            var ret = false;
            for (var i = 0; i < N; i++)
            {
                ret = String.Equals(value, valueSame, StringComparison.Ordinal);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool EqualsNotSameLast()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = value == valueNotSameLast;
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsNotSameLast()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueNotSameLast);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsNotSameLastOrdinal()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueNotSameLast, StringComparison.Ordinal);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool EqualsShort()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = value == valueShort;
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsShort()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueShort);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsShortOrdinal()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueShort, StringComparison.Ordinal);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool EqualsLong()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = value == valueLong;
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsLong()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueLong);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsLongOrdinal()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueLong, StringComparison.Ordinal);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool EqualsNull()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = value == valueNull;
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsNull()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueNull);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool StringEqualsNullOrdinal()
        {
            var ret = false;
            for (var i = 0; i<N; i++)
            {
                ret = String.Equals(value, valueNull, StringComparison.Ordinal);
            }
            return ret;
        }
    }
}
