namespace BasicBenchmark;

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
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

#pragma warning disable CA1711
public delegate void CustomDelegate(EventArgs args);
#pragma warning restore CA1711

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int N = 1_000_000;

    public event EventHandler<EventArgs>? Handler;

    public event EventHandler<EventArgs>? Handler2;

    public event EventHandler<EventArgs>? Handler4;

#pragma warning disable CA1003
    public event CustomDelegate? Delegate;

    public event CustomDelegate? Delegate2;

    public event CustomDelegate? Delegate4;
#pragma warning restore CA1003

    private readonly Action<EventArgs> action;

    private readonly Caller caller = new();

    private readonly VolatileHandlers volatileHandlers;

    private readonly VolatileHandlers volatileHandlers2;

    private readonly VolatileHandlers volatileHandlers4;

    // ReSharper disable once ChangeFieldTypeToSystemThreadingLock
    private readonly object objectSync = new();

    private readonly Lock lockSync = new();

    private object[] array = new object[1];

    public Benchmark()
    {
        Handler += static (_, _) => { };
        Handler2 += static (_, _) => { };
        Handler2 += static (_, _) => { };
        Handler4 += static (_, _) => { };
        Handler4 += static (_, _) => { };
        Handler4 += static (_, _) => { };
        Handler4 += static (_, _) => { };
        Delegate += static _ => { };
        Delegate2 += static _ => { };
        Delegate2 += static _ => { };
        Delegate4 += static _ => { };
        Delegate4 += static _ => { };
        Delegate4 += static _ => { };
        Delegate4 += static _ => { };
        action = static _ => { };
        volatileHandlers = new VolatileHandlers(1, static _ => { });
        volatileHandlers2 = new VolatileHandlers(2, static _ => { });
        volatileHandlers4 = new VolatileHandlers(4, static _ => { });
    }

    [Benchmark]
    public void CallInstance()
    {
        var c = caller;
        for (var i = 0; i < N; i++)
        {
            c.Execute(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallAction()
    {
        var a = action;
        for (var i = 0; i < N; i++)
        {
            a(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallHandler()
    {
        var h = Handler!;
        for (var i = 0; i < N; i++)
        {
            h.Invoke(null, EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallHandler2()
    {
        var h = Handler2!;
        for (var i = 0; i < N; i++)
        {
            h.Invoke(null, EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallHandler4()
    {
        var h = Handler4!;
        for (var i = 0; i < N; i++)
        {
            h.Invoke(null, EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallDelegate()
    {
        var h = Delegate!;
        for (var i = 0; i < N; i++)
        {
            h.Invoke(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallDelegate2()
    {
        var h = Delegate2!;
        for (var i = 0; i < N; i++)
        {
            h.Invoke(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallDelegate4()
    {
        var h = Delegate4!;
        for (var i = 0; i < N; i++)
        {
            h.Invoke(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallCustomHandler()
    {
        var h = volatileHandlers;
        for (var i = 0; i < N; i++)
        {
            h.Execute(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallCustomHandler2()
    {
        var h = volatileHandlers2;
        for (var i = 0; i < N; i++)
        {
            h.Execute(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void CallCustomHandler4()
    {
        var h = volatileHandlers4;
        for (var i = 0; i < N; i++)
        {
            h.Execute(EventArgs.Empty);
        }
    }

    [Benchmark]
    public void LockObject()
    {
        for (var i = 0; i < N; i++)
        {
            lock (objectSync)
            {
            }
        }
    }

    [Benchmark]
    public void LockLock()
    {
        for (var i = 0; i < N; i++)
        {
            lock (lockSync)
            {
            }
        }
    }

    [Benchmark]
    public void LockVolatileRead()
    {
        for (var i = 0; i < N; i++)
        {
            _ = Volatile.Read(ref array);
        }
    }
}

public sealed class Caller
{
    public void Execute(EventArgs args)
    {
    }
}

public sealed class VolatileHandlers
{
    private Action<EventArgs>[] handlers;

    public VolatileHandlers(int size, Action<EventArgs> action)
    {
        handlers = new Action<EventArgs>[size];
        for (var i = 0; i < size; i++)
        {
            handlers[i] = action;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Execute(EventArgs args)
    {
        var hs = Volatile.Read(ref handlers);
        foreach (var handler in hs)
        {
            handler(args);
        }
    }
}
