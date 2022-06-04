using BenchmarkDotNet.Columns;

namespace LoopStructBenchmark;

using System.Runtime.CompilerServices;

using BenchmarkDotNet.Attributes;
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
        AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default);
        AddJob(Job.MediumRun);
    }
}

public sealed class Node
{
    public readonly Type Type;

    public readonly string Constraint;

    public readonly object Value;

    public Node? Next;

    public Node(Type type, string constraint, object value)
    {
        Type = type;
        Constraint = constraint;
        Value = value;
    }
}

public readonly struct StructNode
{
    public readonly Type Type;

    public readonly string Constraint;

    public readonly object Value;

    public StructNode(Type type, string constraint, object value)
    {
        Type = type;
        Constraint = constraint;
        Value = value;
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1000;

    private static readonly Type KeyType = typeof(string);

    private Node node1 = default!;

    private Node node2 = default!;

    private Node node4 = default!;

    private Node node1B = default!;
    private Node[] nodes1B = default!;

    private Node node2B = default!;
    private Node[] nodes2B = default!;

    private Node node4B = default!;
    private Node[] nodes4B = default!;

    private StructNode[] structNodeArray1 = default!;

    private StructNode[] structNodeArray2 = default!;

    private StructNode[] structNodeArray4 = default!;

    [GlobalSetup]
    public void Setup()
    {
        node1 = new Node(typeof(string), string.Empty, new object());
        node2 = new Node(typeof(object), string.Empty, new object())
        {
            Next = new Node(typeof(string), string.Empty, new object())
        };
        node4 = new Node(typeof(object), string.Empty, new object())
        {
            Next = new Node(typeof(object), string.Empty, new object())
            {
                Next = new Node(typeof(string), string.Empty, new object())
            }
        };

        nodes1B = new[]
        {
            new Node(typeof(string), string.Empty, new object())
        };
        node1B = nodes1B[0];
        nodes2B = new[]
        {
            new Node(typeof(object), string.Empty, new object()),
            new Node(typeof(string), string.Empty, new object())
        };
        node2B = nodes2B[0];
        node2B.Next = nodes2B[1];
        nodes4B = new[]
        {
            new Node(typeof(object), string.Empty, new object()),
            new Node(typeof(object), string.Empty, new object()),
            new Node(typeof(string), string.Empty, new object())
        };
        node4B = nodes4B[0];
        node4B.Next = nodes4B[1];
        node4B.Next.Next = nodes4B[2];

        structNodeArray1 = new[]
        {
            new StructNode(typeof(string), string.Empty, new object())
        };
        structNodeArray2 = new[]
        {
            new StructNode(typeof(object), string.Empty, new object()),
            new StructNode(typeof(string), string.Empty, new object())
        };
        structNodeArray4 = new[]
        {
            new StructNode(typeof(object), string.Empty, new object()),
            new StructNode(typeof(object), string.Empty, new object()),
            new StructNode(typeof(string), string.Empty, new object())
        };
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Node1()
    {
        object? ret = null;
        var node = node1;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = NodeFinder.Find(node, key);
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Node2()
    {
        object? ret = null;
        var node = node2;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = NodeFinder.Find(node, key);
        }
        return ret;
    }


    [Benchmark(OperationsPerInvoke = N)]
    public object? Node4()
    {
        object? ret = null;
        var node = node4;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = NodeFinder.Find(node, key);
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Node1B()
    {
        object? ret = null;
        var node = node1B;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = NodeFinder.Find(node, key);
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? Node2B()
    {
        object? ret = null;
        var node = node2B;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = NodeFinder.Find(node, key);
        }
        return ret;
    }


    [Benchmark(OperationsPerInvoke = N)]
    public object? Node4B()
    {
        object? ret = null;
        var node = node4B;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = NodeFinder.Find(node, key);
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? StructNode1()
    {
        object? ret = null;
        var nodes = structNodeArray1;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = StructNodeFinder.Find(nodes, key);
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? StructNode2()
    {
        object? ret = null;
        var nodes = structNodeArray2;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = StructNodeFinder.Find(nodes, key);
        }
        return ret;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public object? StructNode4()
    {
        object? ret = null;
        var nodes = structNodeArray4;
        var key = KeyType;
        for (var i = 0; i < N; i++)
        {
            ret = StructNodeFinder.Find(nodes, key);
        }
        return ret;
    }
}

public static class NodeFinder
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object? Find(Node node, Type type)
    {
        Next:
        if (node.Type == type)
        {
            return node.Value;
        }

        if (node.Next is null)
        {
            return null;
        }

        node = node.Next;
        goto Next;
    }
}

public static class StructNodeFinder
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object? Find(StructNode[] nodes, Type type)
    {
        foreach (ref var node in nodes.AsSpan())
        {
            if (node.Type == type)
            {
                return node.Value;
            }
        }

        return null;
    }

}
