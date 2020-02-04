using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.StringCompare
{
    [Config(typeof(BenchmarkConfig))]
    public class StringCompareBenchmark
    {
        private readonly string value = "01234567890ABCDEF";

        private readonly string valueSame = "01234567890ABCDEF";

        private readonly string valueNotSameLast = "01234567890ABCDE0";

        private readonly string valueEmpty = string.Empty;

        private readonly string valueShort = "01234567890ABCDE";

        private readonly string valueLong = "01234567890ABCDEF0";

        [Benchmark]
        public bool EqualsSame() => value == valueSame;

        [Benchmark]
        public bool StringEqualsSame() => String.Equals(value, valueSame);

        [Benchmark]
        public bool StringEqualsSameOrdinal() => String.Equals(value, valueSame, StringComparison.Ordinal);
    }
}
