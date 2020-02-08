namespace Benchmarks.CallbackArgument
{
    using System;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class CallbackArgumentBenchmark
    {
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

        [Benchmark] public int RunStaticUseStaticCache() => CallbackRunner.RunStatic(StaticCache);

        [Benchmark] public int RunStaticUseCache() => CallbackRunner.RunStatic(cache);

        [Benchmark] public int RunStaticUseMethod() => CallbackRunner.RunStatic(CallbackFunction.Function);

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark] public int RunStaticUseCall() => CallbackRunner.RunStatic(() => CallbackFunction.Function());

        [Benchmark] public int RunStaticDirect() => CallbackRunner.RunStatic(() => 0);

        // 0

        [Benchmark] public int RunUseStaticCache() => runner.Run(StaticCache);

        [Benchmark] public int RunUseCache() => runner.Run(cache);

        [Benchmark] public int RunUseMethod() => runner.Run(CallbackFunction.Function);

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark] public int RunUseCall() => runner.Run(() => CallbackFunction.Function());

        [Benchmark] public int RunDirect() => runner.Run(() => 0);

        // 1 static

        [Benchmark] public int RunStaticUseStaticCache1() => CallbackRunner.RunStatic(1, StaticCache1);

        [Benchmark] public int RunStaticUseCache1() => CallbackRunner.RunStatic(1, cache1);

        [Benchmark] public int RunStaticUseMethod1() => CallbackRunner.RunStatic(1, CallbackFunction.Function1);

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark] public int RunStaticUseCall1() => CallbackRunner.RunStatic(1, x => CallbackFunction.Function1(x));

        [Benchmark] public int RunStaticDirect1() => CallbackRunner.RunStatic(1, x => x);

        // 1

        [Benchmark] public int RunUseStaticCache1() => runner.Run(1, StaticCache1);

        [Benchmark] public int RunUseCache1() => runner.Run(1, cache1);

        [Benchmark] public int RunUseMethod1() => runner.Run(1, CallbackFunction.Function1);

        // ReSharper disable once ConvertClosureToMethodGroup
        [Benchmark] public int RunUseCall1() => runner.Run(1, x => CallbackFunction.Function1(x));

        [Benchmark] public int RunDirect1() => runner.Run(1, x => x);
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
