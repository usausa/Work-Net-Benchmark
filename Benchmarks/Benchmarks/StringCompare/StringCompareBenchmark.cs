namespace Benchmarks.StringCompare
{
    using System;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class StringCompareBenchmark
    {
        private readonly string value = "01234567890ABCDEF";

        private readonly string valueSame = "01234567890ABCDEF";

        private readonly string valueNotSameLast = "01234567890ABCDE0";

        private readonly string valueShort = "01234567890ABCDE";

        private readonly string valueLong = "01234567890ABCDEF0";

        private readonly string valueNull = null;

        [Benchmark]
        public bool EqualsSame() => value == valueSame;

        [Benchmark]
        public bool StringEqualsSame() => String.Equals(value, valueSame);

        [Benchmark]
        public bool StringEqualsSameOrdinal() => String.Equals(value, valueSame, StringComparison.Ordinal);

        [Benchmark]
        public bool EqualsNotSameLast() => value == valueNotSameLast;

        [Benchmark]
        public bool StringEqualsNotSameLast() => String.Equals(value, valueNotSameLast);

        [Benchmark]
        public bool StringEqualsNotSameLastOrdinal() => String.Equals(value, valueNotSameLast, StringComparison.Ordinal);

        [Benchmark]
        public bool EqualsShort() => value == valueShort;

        [Benchmark]
        public bool StringEqualsShort() => String.Equals(value, valueShort);

        [Benchmark]
        public bool StringEqualsShortOrdinal() => String.Equals(value, valueShort, StringComparison.Ordinal);

        [Benchmark]
        public bool EqualsLong() => value == valueLong;

        [Benchmark]
        public bool StringEqualsLong() => String.Equals(value, valueLong);

        [Benchmark]
        public bool StringEqualsLongOrdinal() => String.Equals(value, valueLong, StringComparison.Ordinal);

        [Benchmark]
        public bool EqualsNull() => value == valueNull;

        [Benchmark]
        public bool StringEqualsNull() => String.Equals(value, valueNull);

        [Benchmark]
        public bool StringEqualsNullOrdinal() => String.Equals(value, valueNull, StringComparison.Ordinal);
    }
}
