namespace TextConvertBenchmark;

using System.Globalization;
using System.Text;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main()
    {
        BenchmarkSwitcher.FromTypes([typeof(EncodingBenchmark), typeof(ParseNumberBenchmark)]).RunAll();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddExporter(MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class EncodingBenchmark
{
    private static readonly byte[] Bytes = "0123456789"u8.ToArray();

    private Encoding ascii = default!;
    private Encoding utf8 = default!;
    private Encoding sjis = default!;

    [GlobalSetup]
    public void Setup()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        ascii = Encoding.ASCII;
        utf8 = Encoding.UTF8;
        sjis = Encoding.GetEncoding(932);
    }

    [Benchmark]
    public string AsciiEncode() => ascii.GetString(Bytes);

    [Benchmark]
    public string Utf8Encode() => utf8.GetString(Bytes);

    [Benchmark]
    public string SjisEncode() => sjis.GetString(Bytes);
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
#pragma warning disable CA1822
public class ParseNumberBenchmark
{
#pragma warning disable CA1802
    private static readonly string Text = "12345678";
#pragma warning restore CA1802

    // Any

    [Benchmark]
    public int Any_NumberFormat_Current() => int.Parse(Text, NumberStyles.Any, NumberFormatInfo.CurrentInfo);

    [Benchmark]
    public int Any_NumberFormat_Invariant() => int.Parse(Text, NumberStyles.Any, NumberFormatInfo.InvariantInfo);

    [Benchmark]
    public int Any_NumberFormat_Null() => int.Parse(Text, NumberStyles.Any, null);

    [Benchmark]
    public int Any_Culture_Invariant() => int.Parse(Text, NumberStyles.Any, CultureInfo.InvariantCulture);

    // Number

    [Benchmark]
    public int Number_NumberFormat_Current() => int.Parse(Text, NumberStyles.Number, NumberFormatInfo.CurrentInfo);

    [Benchmark]
    public int Number_NumberFormat_Invariant() => int.Parse(Text, NumberStyles.Number, NumberFormatInfo.InvariantInfo);

    [Benchmark]
    public int Number_Culture_Invariant() => int.Parse(Text, NumberStyles.Number, CultureInfo.InvariantCulture);

    [Benchmark]
    public int Number_Null() => int.Parse(Text, NumberStyles.Number, null);

    // Integer

    [Benchmark]
    public int Integer_NumberFormat_Current() => int.Parse(Text, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);

    [Benchmark]
    public int Integer_NumberFormat_Invariant() => int.Parse(Text, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);

    [Benchmark]
    public int Integer_Culture_Invariant() => int.Parse(Text, NumberStyles.Integer, CultureInfo.InvariantCulture);

    [Benchmark]
    public int Integer_Null() => int.Parse(Text, NumberStyles.Integer, null);

    // None

    [Benchmark]
    public int None_NumberFormat_Current() => int.Parse(Text, NumberStyles.None, NumberFormatInfo.CurrentInfo);

    [Benchmark]
    public int None_NumberFormat_Invariant() => int.Parse(Text, NumberStyles.None, NumberFormatInfo.InvariantInfo);

    [Benchmark]
    public int None_Culture_Invariant() => int.Parse(Text, NumberStyles.None, CultureInfo.InvariantCulture);

    [Benchmark]
    public int None_Null() => int.Parse(Text, NumberStyles.None, CultureInfo.InvariantCulture);

    // Custom

    [Benchmark]
    public int Custom() => ParseInt(Text);

    private static int ParseInt(string str)
    {
        var value = 0;
        for (var i = 0; i < str.Length; i++)
        {
            value *= 10;
            value += str[i] - '0';
        }

        return value;
    }
}
#pragma warning restore CA1822
