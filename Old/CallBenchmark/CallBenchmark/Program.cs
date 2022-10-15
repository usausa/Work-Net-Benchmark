namespace CallBenchmark
{
    using System;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

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
            Add(Job.LongRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly NonSealed0 classNonSealed0 = new NonSealed0();
        private readonly NonSealed1 classNonSealed1 = new NonSealed1();
        private readonly NonSealed2 classNonSealed2 = new NonSealed2();

        private readonly Sealed0 classSealed0 = new Sealed0();
        private readonly Sealed1 classSealed1 = new Sealed1();
        private readonly Sealed2 classSealed2 = new Sealed2();

        private IFunction0 ifNonSealed0;
        private IFunction1 ifNonSealed1;
        private IFunction2 ifNonSealed2;

        private IFunction0 ifSealed0;
        private IFunction1 ifSealed1;
        private IFunction2 ifSealed2;

        private readonly Func<int> funcDirect0 = () => 0;
        private readonly Func<int, int> funcDirect1 = (x) => x;
        private readonly Func<int, int, int> funcDirect2 = (x, y) => x + y;

        private Func<int> funcStatic0;
        private Func<int, int> funcStatic1;
        private Func<int, int, int> funcStatic2;

        private Func<int> funcNonSealed0;
        private Func<int, int> funcNonSealed1;
        private Func<int, int, int> funcNonSealed2;

        private Func<int> funcSealed0;
        private Func<int, int> funcSealed1;
        private Func<int, int, int> funcSealed2;

        [GlobalSetup]
        public void Setup()
        {
            ifNonSealed0 = classNonSealed0;
            ifNonSealed1 = classNonSealed1;
            ifNonSealed2 = classNonSealed2;
            ifSealed0 = classSealed0;
            ifSealed1 = classSealed1;
            ifSealed2 = classSealed2;
            funcStatic0 = StaticClass.Calc0;
            funcStatic1 = StaticClass.Calc1;
            funcStatic2 = StaticClass.Calc2;
            funcNonSealed0 = classNonSealed0.Calc;
            funcNonSealed1 = classNonSealed1.Calc;
            funcNonSealed2 = classNonSealed2.Calc;
            funcSealed0 = classSealed0.Calc;
            funcSealed1 = classSealed1.Calc;
            funcSealed2 = classSealed2.Calc;
        }

        [Benchmark] public void Static0() => StaticClass.Calc0();
        [Benchmark] public void ClassNonSealed0() => classNonSealed0.Calc();
        [Benchmark] public void ClassSealed0() => classSealed0.Calc();
        [Benchmark] public void IfNonSealed0() => ifNonSealed0.Calc();
        [Benchmark] public void IfSealed0() => ifSealed0.Calc();
        [Benchmark] public void FuncDirect0() => funcDirect0();
        [Benchmark] public void FuncStatic0() => funcStatic0();
        [Benchmark] public void FuncNonSealed0() => funcNonSealed0();
        [Benchmark] public void FuncSealed0() => funcSealed0();

        [Benchmark] public void Static1() => StaticClass.Calc1(0);
        [Benchmark] public void ClassNonSealed1() => classNonSealed1.Calc(0);
        [Benchmark] public void ClassSealed1() => classSealed1.Calc(0);
        [Benchmark] public void IfNonSealed1() => ifNonSealed1.Calc(0);
        [Benchmark] public void IfSealed1() => ifSealed1.Calc(0);
        [Benchmark] public void FuncDirect1() => funcDirect1(0);
        [Benchmark] public void FuncStatic1() => funcStatic1(0);
        [Benchmark] public void FuncNonSealed1() => funcNonSealed1(0);
        [Benchmark] public void FuncSealed1() => funcSealed1(0);

        [Benchmark] public void Static2() => StaticClass.Calc2(0, 0);
        [Benchmark] public void ClassNonSealed2() => classNonSealed2.Calc(0, 0);
        [Benchmark] public void ClassSealed2() => classSealed2.Calc(0, 0);
        [Benchmark] public void IfNonSealed2() => ifNonSealed2.Calc(0, 0);
        [Benchmark] public void IfSealed2() => ifSealed2.Calc(0, 0);
        [Benchmark] public void FuncDirect2() => funcDirect2(0, 0);
        [Benchmark] public void FuncStatic2() => funcStatic2(0, 0);
        [Benchmark] public void FuncNonSealed2() => funcNonSealed2(0, 0);
        [Benchmark] public void FuncSealed2() => funcSealed2(0, 0);
    }

    public static class StaticClass
    {
        public static int Calc0() => 0;

        public static int Calc1(int x) => x;

        public static int Calc2(int x, int y) => x + y;
    }

    public interface IFunction0
    {
        int Calc();
    }

    public interface IFunction1
    {
        int Calc(int x);
    }

    public interface IFunction2
    {
        int Calc(int x, int y);
    }

    public class NonSealed0 : IFunction0
    {
        public int Calc() => 0;
    }

    public class NonSealed1 : IFunction1
    {
        public int Calc(int x) => x;
    }

    public class NonSealed2 : IFunction2
    {
        public int Calc(int x, int y) => x + y;
    }

    public sealed class Sealed0 : IFunction0
    {
        public int Calc() => 0;
    }

    public sealed class Sealed1 : IFunction1
    {
        public int Calc(int x) => x;
    }

    public sealed class Sealed2 : IFunction2
    {
        public int Calc(int x, int y) => x + y;
    }
}
