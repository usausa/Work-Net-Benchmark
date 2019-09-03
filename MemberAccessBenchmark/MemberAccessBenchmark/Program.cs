using System;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace MemberAccessBenchmark
{
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
            Add(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly FieldContainer fieldContainer = new FieldContainer(new[]
        {
            typeof(Class00), typeof(Class01),typeof(Class02),typeof(Class03),typeof(Class04),
            typeof(Class05), typeof(Class06),typeof(Class07),typeof(Class08),typeof(Class09)
        });

        private readonly PropertyContainer propertyContainer = new PropertyContainer(new[]
        {
            typeof(Class00), typeof(Class01),typeof(Class02),typeof(Class03),typeof(Class04),
            typeof(Class05), typeof(Class06),typeof(Class07),typeof(Class08),typeof(Class09)
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
            public Type Key;
        }
    }

    public class PropertyContainer
    {
        private readonly Entry[] entries;

        public PropertyContainer(Type[] types)
        {
            entries = types.Select(x => new Entry { Key = x } ).ToArray();
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
            public Type Key { get; set; }
        }
    }

    public class Class00 { }
    public class Class01 { }
    public class Class02 { }
    public class Class03 { }
    public class Class04 { }
    public class Class05 { }
    public class Class06 { }
    public class Class07 { }
    public class Class08 { }
    public class Class09 { }
}
