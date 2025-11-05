namespace HandlersBenchmark;

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
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
    }
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark
{
    private static readonly ArrayHandler ArrayHandler = new(8, _ => { });

    private static readonly LinkHandler LinkHandler = new(8, _ => { });

    [Benchmark]
    public void ByArrayHandler()
    {
        ArrayHandler.Execute(null);
    }

    [Benchmark]
    public void ByLinkHandler()
    {
        LinkHandler.Execute(null);
    }
}

public sealed class ArrayHandler
{
    private readonly Action<object?>[] handlers;

    public ArrayHandler(int size, Action<object?> action)
    {
        handlers = new Action<object?>[size];
        for (var i = 0; i < handlers.Length; i++)
        {
            handlers[i] = action;
        }
    }

    public void Execute(object? parameter)
    {
        foreach (var handler in handlers)
        {
            handler(parameter);
        }
    }
}

public sealed class LinkHandler
{
#pragma warning disable SA1401
    private class Node
    {
        public Action<object?> Action = default!;

        public Node? Next;
    }
#pragma warning restore SA1401

    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    private Node? root;

    public LinkHandler(int size, Action<object?> action)
    {
        var last = default(Node?);
        for (var i = 0; i < size; i++)
        {
            var node = new Node { Action = action };
            if (root is null)
            {
                root = node;
            }
            else
            {
                last!.Next = node;
            }
            last = node;
        }
    }

    public void Execute(object? parameter)
    {
        var node = root;
        while (node is not null)
        {
            node.Action(parameter);
            node = node.Next;
        }
    }
}
