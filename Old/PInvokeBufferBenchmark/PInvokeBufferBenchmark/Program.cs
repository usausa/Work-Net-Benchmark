namespace PInvokeBufferBenchmark;

using System.Runtime.InteropServices;
using System.Text;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main()
    {
        _ = BenchmarkRunner.Run<Benchmark>();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        _ = AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        _ = AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        _ = AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
        _ = AddJob(Job.ShortRun.WithJit(Jit.RyuJit).WithPlatform(Platform.X64).WithRuntime(CoreRuntime.Core60));
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    [Benchmark]
    public string ByStringBuilder()
    {
        var buffer = new StringBuilder(256);
        var size = (uint)buffer.Length;
        NativeMethods.GetComputerName(buffer, ref size);
        return buffer.ToString();
    }

    [Benchmark]
    public string BySpan()
    {
        Span<char> buffer = stackalloc char[256];
        var size = (uint)buffer.Length;
        NativeMethods.GetComputerName(ref MemoryMarshal.GetReference(buffer), ref size);
        return new string(buffer[..(int)size]);
    }
}

public static class NativeMethods
{
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    public static extern bool GetComputerName(StringBuilder buffer, ref uint size);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    public static extern bool GetComputerName(ref char buffer, ref uint size);
}