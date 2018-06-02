namespace ConvertBenchmark
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Text;
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
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);
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
    public class EncodingBenchmark
    {
        private static readonly byte[] Bytes = { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };

        private Encoding ascii;

        private Encoding utf8;

        private Encoding sjis;

        [GlobalSetup]
        public void Setup()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ascii = Encoding.ASCII;
            utf8 = Encoding.UTF8;
            sjis = Encoding.GetEncoding(932);
        }

        [Benchmark]
        public string Ascii()
        {
            return ascii.GetString(Bytes);
        }

        [Benchmark]
        public string Utf8()
        {
            return utf8.GetString(Bytes);
        }

        [Benchmark]
        public string Sjis()
        {
            return sjis.GetString(Bytes);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class ParseNumberBenchmark
    {
        private static readonly string Text = "12345678";

        // Any

        [Benchmark]
        public int Any_NumberFormat_Current()
        {
            return Int32.Parse(Text, NumberStyles.Any, NumberFormatInfo.CurrentInfo);
        }

        [Benchmark]
        public int Any_NumberFormat_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.Any, NumberFormatInfo.InvariantInfo);
        }

        [Benchmark]
        public int Any_NumberFormat_Null()
        {
            return Int32.Parse(Text, NumberStyles.Any, null);
        }

        [Benchmark]
        public int Any_Culture_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.Any, CultureInfo.InvariantCulture);
        }

        // Number

        [Benchmark]
        public int Number_NumberFormat_Current()
        {
            return Int32.Parse(Text, NumberStyles.Number, NumberFormatInfo.CurrentInfo);
        }

        [Benchmark]
        public int Number_NumberFormat_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.Number, NumberFormatInfo.InvariantInfo);
        }

        [Benchmark]
        public int Number_Culture_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.Number, CultureInfo.InvariantCulture);
        }

        [Benchmark]
        public int Number_Null()
        {
            return Int32.Parse(Text, NumberStyles.Number, null);
        }

        // Integer

        [Benchmark]
        public int Integer_NumberFormat_Current()
        {
            return Int32.Parse(Text, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
        }

        [Benchmark]
        public int Integer_NumberFormat_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
        }

        [Benchmark]
        public int Integer_Culture_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.Integer, CultureInfo.InvariantCulture);
        }

        [Benchmark]
        public int Integer_Null()
        {
            return Int32.Parse(Text, NumberStyles.Integer, null);
        }

        // None

        [Benchmark]
        public int None_NumberFormat_Current()
        {
            return Int32.Parse(Text, NumberStyles.None, NumberFormatInfo.CurrentInfo);
        }

        [Benchmark]
        public int None_NumberFormat_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.None, NumberFormatInfo.InvariantInfo);
        }

        [Benchmark]
        public int None_Culture_Invariant()
        {
            return Int32.Parse(Text, NumberStyles.None, CultureInfo.InvariantCulture);
        }

        [Benchmark]
        public int None_Null()
        {
            return Int32.Parse(Text, NumberStyles.None, CultureInfo.InvariantCulture);
        }

        // Custom

        [Benchmark]
        public int Custom()
        {
            return ParseInt(Text);
        }

        private static int ParseInt(string str)
        {
            // No check
            var value = 0;
            for (var i = 0; i < str.Length; i++)
            {
                value *= 10;
                value += str[i] - '0';
            }

            return value;
        }
    }
}
