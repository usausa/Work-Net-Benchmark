namespace SwitchBenchmark
{
    using System;
    using System.Runtime.CompilerServices;

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
            BenchmarkRunner.Run<Benchmark>();
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
    public class Benchmark
    {
        private Action<int> instanceAction;

        private Action<int> instanceAction2;

        private Action<int> staticAction;

        private Action<int> staticAction2;

        private IAction interfaceAction;

        [Params(1, 2, 3)]
        public int Parameter { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            if (Parameter == 1)
            {
                instanceAction = Action1.Default.Work;
                instanceAction2 = x => Action1.Default.Work(1);
                staticAction = Action1.Default.Work;
                staticAction2 = x => Action1.Default.Work(1);
                interfaceAction = Action1.Default;
            }
            else if (Parameter == 2)
            {
                instanceAction = Action2.Default.Work;
                instanceAction2 = x => Action2.Default.Work(2);
                staticAction = Action2.Default.Work;
                staticAction2 = x => Action2.Default.Work(2);
                interfaceAction = Action2.Default;
            }
            else if (Parameter == 3)
            {
                instanceAction = Action3.Default.Work;
                instanceAction2 = x => Action3.Default.Work(3);
                staticAction = Action3.Default.Work;
                staticAction2 = x => Action3.Default.Work(3);
                interfaceAction = Action3.Default;
            }
        }

        [Benchmark]
        public void IfStatic()
        {
            if (Parameter == 1)
            {
                Data.Value = 1;
            }
            else if (Parameter == 2)
            {
                Data.Value = 2;
            }
            else if (Parameter == 3)
            {
                Data.Value = 3;
            }
        }

        [Benchmark]
        public void InstanceAction()
        {
            instanceAction(Parameter);
        }


        [Benchmark]
        public void InstanceAction2()
        {
            instanceAction2(Parameter);
        }

        [Benchmark]
        public void StaticAction()
        {
            staticAction(Parameter);
        }


        [Benchmark]
        public void StaticAction2()
        {
            staticAction2(Parameter);
        }

        [Benchmark]
        public void InterfaceAction()
        {
            interfaceAction.Work(Parameter);
        }
    }

    public static class Data
    {
        public static int Value { get; set; }
    }

    public interface IAction
    {
        void Work(int parameter);
    }

    public sealed class Action1 : IAction
    {
        public static IAction Default { get; } = new Action1();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Work(int parameter)
        {
            Data.Value = parameter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WorkStatic(int parameter)
        {
            Data.Value = parameter;
        }
    }

    public sealed class Action2 : IAction
    {
        public static IAction Default { get; } = new Action2();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Work(int parameter)
        {
            Data.Value = parameter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WorkStatic(int parameter)
        {
            Data.Value = parameter;
        }
    }

    public sealed class Action3 : IAction
    {
        public static IAction Default { get; } = new Action3();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Work(int parameter)
        {
            Data.Value = parameter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WorkStatic(int parameter)
        {
            Data.Value = parameter;
        }
    }
}
