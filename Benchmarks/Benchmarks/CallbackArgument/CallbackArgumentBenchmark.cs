namespace Benchmarks.CallbackArgument
{
    using System;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class CallbackArgumentBenchmark
    {
        private const int N = 1000;

        private static readonly Func<int> StaticCache;

        private static readonly Func<int, int> StaticCache1;

        private readonly Func<int> cache;

        private readonly Func<int, int> cache1;

        private readonly CallbackRunner runner = new CallbackRunner();

        static CallbackArgumentBenchmark()
        {
            StaticCache = CallbackFunction.Function;
            StaticCache1 = CallbackFunction.Function1;
        }

        public CallbackArgumentBenchmark()
        {
            cache = CallbackFunction.Function;
            cache1 = CallbackFunction.Function1;
        }

        // 0 static

        [Benchmark]
        public int RunStaticUseStaticCache()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(StaticCache);
            }
            return ret;
        }

        [Benchmark]
        public int RunStaticUseCache()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(cache);
            }
            return ret;
        }

        [Benchmark]
        public int RunStaticUseMethod()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(CallbackFunction.Function);
            }
            return ret;
        }

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark]
        public int RunStaticUseCall()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(() => CallbackFunction.Function());
            }
            return ret;
        }

        [Benchmark]
        public int RunStaticDirect()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(() => 0);
            }
            return ret;
        }

        // 0

        [Benchmark]
        public int RunUseStaticCache()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(StaticCache);
            }
            return ret;
        }

        [Benchmark]
        public int RunUseCache()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(cache);
            }
            return ret;
        }

        [Benchmark]
        public int RunUseMethod()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(CallbackFunction.Function);
            }
            return ret;
        }

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark]
        public int RunUseCall()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(() => CallbackFunction.Function());
            }
            return ret;
        }

        [Benchmark]
        public int RunDirect()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(() => 0);
            }
            return ret;
        }

        // 1 static

        [Benchmark]
        public int RunStaticUseStaticCache1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(i, StaticCache1);
            }
            return ret;
        }

        [Benchmark]
        public int RunStaticUseCache1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(i, cache1);
            }
            return ret;
        }

        [Benchmark]
        public int RunStaticUseMethod1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(i, CallbackFunction.Function1);
            }
            return ret;
        }

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark]
        public int RunStaticUseCall1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(i, x => CallbackFunction.Function1(x));
            }
            return ret;
        }

        [Benchmark]
        public int RunStaticDirect1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = CallbackRunner.RunStatic(i, x => x);
            }
            return ret;
        }

        // 1

        [Benchmark]
        public int RunUseStaticCache1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(i, StaticCache1);
            }
            return ret;
        }

        [Benchmark]
        public int RunUseCache1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(i, cache1);
            }
            return ret;
        }

        [Benchmark]
        public int RunUseMethod1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(i, CallbackFunction.Function1);
            }
            return ret;
        }

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark]
        public int RunUseCall1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(i, x => CallbackFunction.Function1(x));
            }
            return ret;
        }

        [Benchmark]
        public int RunDirect1()
        {
            var ret = 0;
            for (var i = 0; i < N; i++)
            {
                ret = runner.Run(i, x => x);
            }
            return ret;
        }
    }

    public static class CallbackFunction
    {
        public static int Function() => 0;

        public static int Function1(int x) => x;
    }

    public class CallbackRunner
    {
        public static int RunStatic(Func<int> callback) => callback();

        public int Run(Func<int> callback) => callback();

        public static int RunStatic(int value, Func<int, int> callback) => callback(value);

        public int Run(int value, Func<int, int> callback) => callback(value);
    }
}
