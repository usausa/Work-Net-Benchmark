#pragma warning disable SA1312
namespace FormatBenchmark;

using System.Buffers;
using System.Buffers.Text;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();
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
    }
}

[Config(typeof(BenchmarkConfig))]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net80)]
public class Benchmark
{
    private const int N = 1000;

    private readonly DateTime date = new(2023, 12, 31, 23, 59, 59);

    [Benchmark(OperationsPerInvoke = N, Baseline = true)]
    public unsafe void Format()
    {
        var buffer = (Span<byte>)stackalloc byte[14];
        for (var i = 0; i < N; i++)
        {
            DateTimeFormatter.Format(date, buffer);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public unsafe void FormatByUtfFormatter()
    {
        var buffer = (Span<byte>)stackalloc byte[14];
        for (var i = 0; i < N; i++)
        {
            DateTimeFormatter.FormatByUtfFormatter(date, buffer);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public unsafe void FormatCustom()
    {
        var buffer = (Span<byte>)stackalloc byte[14];
        for (var i = 0; i < N; i++)
        {
            DateTimeFormatter.FormatCustom(date, buffer);
        }
    }

    [Benchmark(OperationsPerInvoke = N)]
    public unsafe void FormatCustom2()
    {
        var buffer = (Span<byte>)stackalloc byte[14];
        for (var i = 0; i < N; i++)
        {
            DateTimeFormatter.FormatCustom2(date, buffer);
        }
    }
}

public static class DateTimeFormatter
{
    private static readonly StandardFormat Format2 = StandardFormat.Parse("D2");
    private static readonly StandardFormat Format4 = StandardFormat.Parse("D4");

    private static readonly byte[] Table = new byte[100 * 2];

    static DateTimeFormatter()
    {
        for (var i = 0; i < 100; i++)
        {
            var offset = i * 2;
            Table[offset] = (byte)(0x30 + (i / 10));
            Table[offset + 1] = (byte)(0x30 + (i % 10));
        }
    }

    public static void Format(DateTime value, Span<byte> buffer)
    {
        var text = value.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
        Encoding.ASCII.GetBytes(text, buffer);
    }

    public static void FormatByUtfFormatter(DateTime value, Span<byte> buffer)
    {
        Utf8Formatter.TryFormat(value.Year, buffer[..4], out _, Format4);
        Utf8Formatter.TryFormat(value.Month, buffer[4..6], out _, Format2);
        Utf8Formatter.TryFormat(value.Day, buffer[6..8], out _, Format2);
        Utf8Formatter.TryFormat(value.Hour, buffer[8..10], out _, Format2);
        Utf8Formatter.TryFormat(value.Minute, buffer[10..12], out _, Format2);
        Utf8Formatter.TryFormat(value.Second, buffer[12..14], out _, Format2);
    }

    public static void FormatCustom(DateTime value, Span<byte> buffer)
    {
        var year = value.Year;
        buffer[0] = ToByte(year / 1000);
        buffer[1] = ToByte(year / 100);
        buffer[2] = ToByte(year / 10);
        buffer[3] = ToByte(year % 10);
        var month = value.Month;
        buffer[4] = ToByte(month / 10);
        buffer[5] = ToByte(month % 10);
        var day = value.Day;
        buffer[6] = ToByte(day / 10);
        buffer[7] = ToByte(day % 10);
        var hour = value.Hour;
        buffer[8] = ToByte(hour / 10);
        buffer[9] = ToByte(hour % 10);
        var minute = value.Minute;
        buffer[10] = ToByte(minute / 10);
        buffer[11] = ToByte(minute % 10);
        var second = value.Second;
        buffer[12] = ToByte(second / 10);
        buffer[13] = ToByte(second % 10);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte ToByte(int value) => (byte)(value + 0x30);

#pragma warning disable IDE0047
    public static void FormatCustom2(DateTime value, Span<byte> buffer)
    {
        var year = value.Year;
        Table.AsSpan(year / 100 * 2, 2).CopyTo(buffer[..2]);
        Table.AsSpan((year % 100) * 2, 2).CopyTo(buffer[2..4]);
        Table.AsSpan(value.Month * 2, 2).CopyTo(buffer[4..6]);
        Table.AsSpan(value.Day * 2, 2).CopyTo(buffer[6..8]);
        Table.AsSpan(value.Hour * 2, 2).CopyTo(buffer[8..10]);
        Table.AsSpan(value.Minute * 2, 2).CopyTo(buffer[10..12]);
        Table.AsSpan(value.Second * 2, 2).CopyTo(buffer[12..14]);
    }
#pragma warning restore IDE0047
}
