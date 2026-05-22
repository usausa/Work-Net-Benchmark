namespace MemberAccessBenchmark;

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
        BenchmarkRunner.Run<FieldPropertyBenchmark>();
        BenchmarkRunner.Run<SetStorageBenchmark>();
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
public class FieldPropertyBenchmark
{
    private readonly FieldContainer fieldContainer = new FieldContainer(new[]
    {
        typeof(Class00), typeof(Class01), typeof(Class02), typeof(Class03), typeof(Class04),
        typeof(Class05), typeof(Class06), typeof(Class07), typeof(Class08), typeof(Class09)
    });

    private readonly PropertyContainer propertyContainer = new PropertyContainer(new[]
    {
        typeof(Class00), typeof(Class01), typeof(Class02), typeof(Class03), typeof(Class04),
        typeof(Class05), typeof(Class06), typeof(Class07), typeof(Class08), typeof(Class09)
    });

    private readonly Type key = typeof(object);

    [Benchmark]
    public void Field()
    {
        for (var i = 0; i < 100; i++)
        {
            fieldContainer.Find(key);
        }
    }

    [Benchmark]
    public void Property()
    {
        for (var i = 0; i < 100; i++)
        {
            propertyContainer.Find(key);
        }
    }
}

[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class SetStorageBenchmark
{
    private readonly Model model = new();

    [Benchmark]
    public void Set() => model.Set(1);

    [Benchmark]
    public void SetCallback() => model.SetCallback(1);

    [Benchmark]
    public void SetModelCallback() => model.SetModelCallback(1);

    [Benchmark]
    public void SetByAccessor() => model.SetByAccessor(1);
}

#pragma warning disable SA1401, CA1051
public class FieldContainer
{
    private readonly Entry[] entries;

    public FieldContainer(Type[] types)
    {
        entries = types.Select(x => new Entry { Key = x }).ToArray();
    }

    public void Find(Type type)
    {
        for (var i = 0; i < entries.Length; i++)
        {
            if (entries[i].Key == type)
            {
                break;
            }
        }
    }

    public class Entry
    {
        public Type Key = default!;
    }
}
#pragma warning restore SA1401, CA1051

public class PropertyContainer
{
    private readonly Entry[] entries;

    public PropertyContainer(Type[] types)
    {
        entries = types.Select(x => new Entry { Key = x }).ToArray();
    }

    public void Find(Type type)
    {
        for (var i = 0; i < entries.Length; i++)
        {
            if (entries[i].Key == type)
            {
                break;
            }
        }
    }

    public class Entry
    {
        public Type Key { get; set; } = default!;
    }
}

public delegate ref T FieldAccessor<T>();

#pragma warning disable CA1822
public class NotificationObject
{
    public void Set<T>(ref T storage, T value)
    {
        storage = value;
    }

    public void SetCallback<T>(T value, Action<T> callback)
    {
        callback(value);
    }

    public void SetCallback<TModel, T>(T value, TModel model, Action<TModel, T> callback)
    {
        callback(model, value);
    }

    public void SetByAccessor<T>(T value, FieldAccessor<T> accessor)
    {
        accessor() = value;
    }
}
#pragma warning restore CA1822

public class Model : NotificationObject
{
    private int storage;

    public void Set(int value)
    {
        Set(ref storage, value);
    }

    public void SetCallback(int value)
    {
        SetCallback(value, x => storage = x);
    }

    public void SetModelCallback(int value)
    {
        SetCallback(value, this, (m, x) => m.storage = x);
    }

    public void SetByAccessor(int value)
    {
        SetByAccessor(value, () => ref storage);
    }
}

public class Class00
{
}

public class Class01
{
}

public class Class02
{
}

public class Class03
{
}

public class Class04
{
}

public class Class05
{
}

public class Class06
{
}

public class Class07
{
}

public class Class08
{
}

public class Class09
{
}
