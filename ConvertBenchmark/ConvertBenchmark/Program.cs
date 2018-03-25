namespace ConvertBenchmark
{
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
            Add(Job.ShortRun);
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
        public void Ascii()
        {
            ascii.GetString(Bytes);
        }

        [Benchmark]
        public void Utf8()
        {
            utf8.GetString(Bytes);
        }

        [Benchmark]
        public void Sjis()
        {
            sjis.GetString(Bytes);
        }
    }

}
