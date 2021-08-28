using System;
using System.Linq;

namespace FuncArrayBenchmark
{
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
            BenchmarkRunner.Run<MapperBenchmark>();
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

    [Config(typeof(BenchmarkConfig))]
    public class MapperBenchmark
    {
        private const int N = 1000;

        private readonly ArrayCaller arrayCaller4 = new();
        private readonly ArrayCaller arrayCaller8 = new();
        private readonly ArrayCaller arrayCaller16 = new();
        private readonly ArrayCachedCaller arrayCachedCaller4 = new();
        private readonly ArrayCachedCaller arrayCachedCaller8 = new();
        private readonly ArrayCachedCaller arrayCachedCaller16 = new();
        private readonly ArrayIndividualCaller4 arrayIndividualCaller4 = new();
        private readonly ArrayIndividualCaller8 arrayIndividualCaller8 = new();
        private readonly ArrayIndividualCaller16 arrayIndividualCaller16 = new();
        private readonly ArrayCachedIndividualCaller4 arrayCachedIndividualCaller4 = new();
        private readonly ArrayCachedIndividualCaller8 arrayCachedIndividualCaller8 = new();
        private readonly ArrayCachedIndividualCaller16 arrayCachedIndividualCaller16 = new();
        private readonly ReverseArrayCachedIndividualCaller4 reverseArrayCachedIndividualCaller4 = new();
        private readonly ReverseArrayCachedIndividualCaller8 reverseArrayCachedIndividualCaller8 = new();
        private readonly ReverseArrayCachedIndividualCaller16 reverseArrayCachedIndividualCaller16 = new();
        private readonly IndividualCaller4 individualCaller4 = new();
        private readonly IndividualCaller8 individualCaller8 = new();
        private readonly IndividualCaller16 individualCaller16 = new();

        [GlobalSetup]
        public void Setup()
        {
            void Action()
            {
            }

            SetupActionFields(arrayCaller4, Action, 4);
            SetupActionFields(arrayCaller8, Action, 8);
            SetupActionFields(arrayCaller16, Action, 16);
            SetupActionFields(arrayCachedCaller4, Action, 4);
            SetupActionFields(arrayCachedCaller8, Action, 8);
            SetupActionFields(arrayCachedCaller16, Action, 16);
            SetupActionFields(arrayIndividualCaller4, Action, 4);
            SetupActionFields(arrayIndividualCaller8, Action, 8);
            SetupActionFields(arrayIndividualCaller16, Action, 16);
            SetupActionFields(arrayCachedIndividualCaller4, Action, 4);
            SetupActionFields(arrayCachedIndividualCaller8, Action, 8);
            SetupActionFields(arrayCachedIndividualCaller16, Action, 16);
            SetupActionFields(reverseArrayCachedIndividualCaller4, Action, 4);
            SetupActionFields(reverseArrayCachedIndividualCaller8, Action, 8);
            SetupActionFields(reverseArrayCachedIndividualCaller16, Action, 16);
            SetupActionField(individualCaller4, Action);
            SetupActionField(individualCaller8, Action);
            SetupActionField(individualCaller16, Action);
        }

        private void SetupActionFields(object target, Action action, int size)
        {
            foreach (var field in target.GetType().GetFields().Where(x => x.FieldType == typeof(Action[])))
            {
                var actions = new Action[size];
                for (var i = 0; i < actions.Length; i++)
                {
                    actions[i] = action;
                }
                field.SetValue(target, actions);
            }
        }

        private void SetupActionField(object target, Action action)
        {
            foreach (var field in target.GetType().GetFields().Where(x => x.FieldType == typeof(Action)))
            {
                field.SetValue(target, action);
            }
        }

        // 4

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCaller4()
        {
            var caller = arrayCaller4;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCachedCaller4()
        {
            var caller = arrayCachedCaller4;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayIndividualCaller4()
        {
            var caller = arrayIndividualCaller4;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCachedIndividualCaller4()
        {
            var caller = arrayCachedIndividualCaller4;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ReverseArrayCachedIndividualCaller4()
        {
            var caller = reverseArrayCachedIndividualCaller4;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void IndividualCaller4()
        {
            var caller = individualCaller4;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        // 8

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCaller8()
        {
            var caller = arrayCaller8;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCachedCaller8()
        {
            var caller = arrayCachedCaller8;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayIndividualCaller8()
        {
            var caller = arrayIndividualCaller8;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCachedIndividualCaller8()
        {
            var caller = arrayCachedIndividualCaller8;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ReverseArrayCachedIndividualCaller8()
        {
            var caller = reverseArrayCachedIndividualCaller8;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void IndividualCaller8()
        {
            var caller = individualCaller8;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        // 16

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCaller16()
        {
            var caller = arrayCaller16;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCachedCaller16()
        {
            var caller = arrayCachedCaller16;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayIndividualCaller16()
        {
            var caller = arrayIndividualCaller16;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ArrayCachedIndividualCaller16()
        {
            var caller = arrayCachedIndividualCaller16;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void ReverseArrayCachedIndividualCaller16()
        {
            var caller = reverseArrayCachedIndividualCaller16;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }

        [Benchmark(OperationsPerInvoke = N)]
        public void IndividualCaller16()
        {
            var caller = individualCaller16;
            for (var i = 0; i < N; i++)
            {
                caller.Call();
            }
        }
    }

    public sealed class ArrayCaller
    {
        public Action[] actions;

        public void Call()
        {
            for (var i = 0; i < actions.Length; i++)
            {
                actions[i]();
            }
        }
    }

    public sealed class ArrayCachedCaller
    {
        public Action[] actions;

        public void Call()
        {
            var a = actions;
            for (var i = 0; i < a.Length; i++)
            {
                a[i]();
            }
        }
    }

    public sealed class ArrayIndividualCaller4
    {
        public Action[] actions;

        public void Call()
        {
            actions[0]();
            actions[1]();
            actions[2]();
            actions[3]();
        }
    }

    public sealed class ArrayIndividualCaller8
    {
        public Action[] actions;

        public void Call()
        {
            actions[0]();
            actions[1]();
            actions[2]();
            actions[3]();
            actions[4]();
            actions[5]();
            actions[6]();
            actions[7]();
        }
    }

    public sealed class ArrayIndividualCaller16
    {
        public Action[] actions;

        public void Call()
        {
            actions[0]();
            actions[1]();
            actions[2]();
            actions[3]();
            actions[4]();
            actions[5]();
            actions[6]();
            actions[7]();
            actions[8]();
            actions[9]();
            actions[10]();
            actions[11]();
            actions[12]();
            actions[13]();
            actions[14]();
            actions[15]();
        }
    }

    public sealed class ArrayCachedIndividualCaller4
    {
        public Action[] actions;

        public void Call()
        {
            var a = actions;
            a[0]();
            a[1]();
            a[2]();
            a[3]();
        }
    }

    public sealed class ArrayCachedIndividualCaller8
    {
        public Action[] actions;

        public void Call()
        {
            var a = actions;
            a[0]();
            a[1]();
            a[2]();
            a[3]();
            a[4]();
            a[5]();
            a[6]();
            a[7]();
        }
    }

    public sealed class ArrayCachedIndividualCaller16
    {
        public Action[] actions;

        public void Call()
        {
            var a = actions;
            a[0]();
            a[1]();
            a[2]();
            a[3]();
            a[4]();
            a[5]();
            a[6]();
            a[7]();
            a[8]();
            a[9]();
            a[10]();
            a[11]();
            a[12]();
            a[13]();
            a[14]();
            a[15]();
        }
    }

    public sealed class ReverseArrayCachedIndividualCaller4
    {
        public Action[] actions;

        public void Call()
        {
            var a = actions;
            a[3]();
            a[2]();
            a[1]();
            a[0]();
        }
    }

    public sealed class ReverseArrayCachedIndividualCaller8
    {
        public Action[] actions;

        public void Call()
        {
            var a = actions;
            a[7]();
            a[6]();
            a[5]();
            a[4]();
            a[3]();
            a[2]();
            a[1]();
            a[0]();
        }
    }

    public sealed class ReverseArrayCachedIndividualCaller16
    {
        public Action[] actions;

        public void Call()
        {
            var a = actions;
            a[15]();
            a[14]();
            a[13]();
            a[12]();
            a[11]();
            a[10]();
            a[9]();
            a[8]();
            a[7]();
            a[6]();
            a[5]();
            a[4]();
            a[3]();
            a[2]();
            a[1]();
            a[0]();
        }
    }

    public sealed class IndividualCaller4
    {
        public Action action0;
        public Action action1;
        public Action action2;
        public Action action3;

        public void Call()
        {
            action0();
            action1();
            action2();
            action3();
        }
    }

    public sealed class IndividualCaller8
    {
        public Action action0;
        public Action action1;
        public Action action2;
        public Action action3;
        public Action action4;
        public Action action5;
        public Action action6;
        public Action action7;

        public void Call()
        {
            action0();
            action1();
            action2();
            action3();
            action4();
            action5();
            action6();
            action7();
        }
    }

    public sealed class IndividualCaller16
    {
        public Action action0;
        public Action action1;
        public Action action2;
        public Action action3;
        public Action action4;
        public Action action5;
        public Action action6;
        public Action action7;
        public Action action8;
        public Action action9;
        public Action action10;
        public Action action11;
        public Action action12;
        public Action action13;
        public Action action14;
        public Action action15;

        public void Call()
        {
            action0();
            action1();
            action2();
            action3();
            action4();
            action5();
            action6();
            action7();
            action8();
            action9();
            action10();
            action11();
            action12();
            action13();
            action14();
            action15();
        }
    }
}
