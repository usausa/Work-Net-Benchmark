namespace Benchmarks.MethodType
{
    using System;
    using System.Runtime.CompilerServices;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class MethodTypeBenchmark
    {
        private const int N = 1000;

        private readonly Function function;

        private readonly InlineFunction inlineFunction;

        private readonly Func<int, int, int> func;

        private readonly Func<int, int, int> staticFunc;

        private readonly Func<int, int, int> staticInlineFunc;

        private readonly Func<int, int, int> instanceFunc;

        private readonly Func<int, int, int> instanceInlineFunc;

        private readonly IFunction iFunction;

        private readonly IFunction iInlineFunction;

        private readonly IFunction iSealedFunction;

        private readonly IFunction iSealedInlineFunction;

        public MethodTypeBenchmark()
        {
            function = new Function();
            inlineFunction = new InlineFunction();
            func = (a, b) => a + b;
            staticFunc = StaticFunction.Op;
            staticInlineFunc = StaticInlineFunction.Op;
            instanceFunc = function.Op;
            instanceInlineFunc = inlineFunction.Op;
            iFunction = new FunctionImpl();
            iInlineFunction = new InlineFunctionImpl();
            iSealedFunction = new SealedFunctionsImpl();
            iSealedInlineFunction = new SealedInlineFunctionsImpl();
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int Direct()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = ret + i;
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int Func()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = func(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int Static()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = StaticFunction.Op(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int StaticInline()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = StaticInlineFunction.Op(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int Instance()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = function.Op(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int InstanceInline()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = inlineFunction.Op(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int StaticFunc()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = staticFunc(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int StaticInlineFunc()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = staticInlineFunc(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int InstanceFunc()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = instanceFunc(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int InstanceInlineFunc()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = instanceInlineFunc(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int Interface()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = iFunction.Op(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int InterfaceInline()
        {
            var ret = 0;
            for (var i = 0; i<N; i++)
            {
                ret = iInlineFunction.Op(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int SealedInterface()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = iSealedFunction.Op(ret, i);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public int SealedInterfaceInline()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = iSealedInlineFunction.Op(ret, i);
            }
            return ret;
        }
    }

    public static class StaticFunction
    {
        public static int Op(int a, int b) => a + b;
    }

    public static class StaticInlineFunction
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Op(int a, int b) => a + b;
    }

    public class Function
    {
        public int Op(int a, int b) => a + b;
    }

    public class InlineFunction
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Op(int a, int b) => a + b;
    }

    public interface IFunction
    {
        int Op(int a, int b);
    }

    public class FunctionImpl : IFunction
    {
        public int Op(int a, int b) => a + b;
    }

    public class InlineFunctionImpl : IFunction
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Op(int a, int b) => a + b;
    }


    public sealed class SealedFunctionsImpl : IFunction
    {
        public int Op(int a, int b) => a + b;
    }

    public sealed class SealedInlineFunctionsImpl : IFunction
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Op(int a, int b) => a + b;
    }
}
