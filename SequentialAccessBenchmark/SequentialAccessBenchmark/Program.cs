using System;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace SequentialAccessBenchmark
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
        private readonly ArrayContainer arrayContainer = new ArrayContainer(new[]
        {
            typeof(Class00), typeof(Class01),typeof(Class02),typeof(Class03),typeof(Class04),
            typeof(Class05), typeof(Class06),typeof(Class07),typeof(Class08),typeof(Class09)
        });

        private readonly LinkContainer linkContainer = new LinkContainer(new[]
        {
            typeof(Class00), typeof(Class01),typeof(Class02),typeof(Class03),typeof(Class04),
            typeof(Class05), typeof(Class06),typeof(Class07),typeof(Class08),typeof(Class09)
        });

        private readonly Type key1 = typeof(Class00);

        private readonly Type key2 = typeof(Class01);

        private readonly Type key4 = typeof(Class03);

        private readonly Type key8 = typeof(Class07);

        [Benchmark]
        public void Array1() => arrayContainer.Find(key1);

        [Benchmark]
        public void Array2() => arrayContainer.Find(key2);

        [Benchmark]
        public void Array4() => arrayContainer.Find(key4);

        [Benchmark]
        public void Array8() => arrayContainer.Find(key8);

        [Benchmark]
        public void Link1() => linkContainer.Find(key1);

        [Benchmark]
        public void Link2() => linkContainer.Find(key2);

        [Benchmark]
        public void Link4() => linkContainer.Find(key4);

        [Benchmark]
        public void Link8() => linkContainer.Find(key8);

        [Benchmark]
        public void LinkB1() => linkContainer.Find2(key1);

        [Benchmark]
        public void LinkB2() => linkContainer.Find2(key2);

        [Benchmark]
        public void LinkB4() => linkContainer.Find2(key4);

        [Benchmark]
        public void LinkB8() => linkContainer.Find2(key8);
    }

    public class ArrayContainer
    {
        private readonly Entry[] entries;

        public ArrayContainer(Type[] types)
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

    public class LinkContainer
    {
        private readonly Entry first;

        public LinkContainer(Type[] types)
        {
            Entry previous = null;
            for (var i = 0; i < types.Length; i++)
            {
                var entry = new Entry { Key = types[i] };
                if (previous != null)
                {
                    previous.Next = entry;
                }
                else
                {
                    first = entry;
                }

                previous = entry;
            }
        }

        public void Find(Type type)
        {
            var entry = first;
            do
            {
                if (entry.Key == type)
                {
                    return;
                }

                entry = entry.Next;
            } while (entry != null);
        }

        public void Find2(Type type)
        {
            var entry = first;
            while (entry != null)
            {
                if (entry.Key == type)
                {
                    return;
                }

                entry = entry.Next;
            }
        }

        public class Entry
        {
            public Type Key;

            public Entry Next;
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
