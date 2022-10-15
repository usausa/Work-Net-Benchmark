using System.Globalization;

namespace ChangeTypeBenchmark
{
    using System;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    using Smart.Converter;

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);
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
        private static readonly int IntValue = 1234;
        private static readonly long LongValue = 1234L;
        private static readonly string StringValue = "1234";

        private static readonly IObjectConverter Converter = ObjectConverter.Default;

        private Func<object, object> converter1;
        private Func<object, object> converter2;
        private Func<object, object> converter3;
        private Func<object, object> converter4;

        [GlobalSetup]
        public void Setup()
        {
            converter1 = Converter.CreateConverter(typeof(int), typeof(long));
            converter2 = Converter.CreateConverter(typeof(long), typeof(int));
            converter3 = Converter.CreateConverter(typeof(string), typeof(int));
            converter4 = Converter.CreateConverter(typeof(int), typeof(string));
        }

        // Raw

        [Benchmark]
        public long RawIntToLong() => IntValue;

        [Benchmark]
        public int RawLongToInt() => (int)LongValue;

        [Benchmark]
        public int RawStringToInt() => Int32.TryParse(StringValue, out var value) ? value : default;

        [Benchmark]
        public string RawIntToString() => IntValue.ToString();

        // Default

        [Benchmark]
        public long ConvertIntToLong() => (long)Convert.ChangeType(IntValue, typeof(long), CultureInfo.InvariantCulture);

        [Benchmark]
        public int ConvertLongToInt() => (int)Convert.ChangeType(LongValue, typeof(int), CultureInfo.InvariantCulture);

        [Benchmark]
        public int ConvertStringToInt() => (int)Convert.ChangeType(StringValue, typeof(int), CultureInfo.InvariantCulture);

        [Benchmark]
        public string ConvertIntToString() => (string)Convert.ChangeType(IntValue, typeof(string), CultureInfo.InvariantCulture);

        // Smart

        [Benchmark]
        public long SmartIntToLong() => Converter.Convert<long>(IntValue);

        [Benchmark]
        public int SmartLongToInt() => Converter.Convert<int>(LongValue);

        [Benchmark]
        public int SmartStringToInt() => Converter.Convert<int>(StringValue);

        [Benchmark]
        public string SmartIntToString() => Converter.Convert<string>(IntValue);

        // Smart prepared

        [Benchmark]
        public long PreparedSmartIntToLong() => (long)converter1(IntValue);

        [Benchmark]
        public int PreparedSmartLongToInt() => (int)converter2(LongValue);

        [Benchmark]
        public int PreparedSmartStringToInt() => (int)converter3(StringValue);

        [Benchmark]
        public string PreparedSmartIntToString() => (string)converter4(IntValue);
    }
}
