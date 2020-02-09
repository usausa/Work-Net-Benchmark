//namespace Benchmarks.BufferPool
//{
//    using System;

//    using BenchmarkDotNet.Attributes;

//    [Config(typeof(BenchmarkConfig))]
//    public class BufferPoolBenchmark
//    {
//        private static readonly Func<int> StaticCache;

//        private static readonly Func<int, int> StaticCache1;

//        private readonly Func<int> cache;

//        private readonly Func<int, int> cache1;

//        private readonly CallbackRunner runner = new CallbackRunner();

//        static CallbackArgumentBenchmark()
//        {
//            StaticCache = CallbackFunction.Function;
//            StaticCache1 = CallbackFunction.Function1;
//        }

//        public CallbackArgumentBenchmark()
//        {
//            cache = CallbackFunction.Function;
//            cache1 = CallbackFunction.Function1;
//        }

//        [Benchmark] public int RunStaticUseStaticCache() => CallbackRunner.RunStatic(StaticCache);
//    }

//    public static class CallbackFunction
//    {
//        public static int Function() => 0;

//        public static int Function1(int x) => x;
//    }

//    public class CallbackRunner
//    {
//        public static int RunStatic(Func<int> callback) => callback();

//        public int Run(Func<int> callback) => callback();

//        public static int RunStatic(int value, Func<int, int> callback) => callback(value);

//        public int Run(int value, Func<int, int> callback) => callback(value);
//    }
//}
