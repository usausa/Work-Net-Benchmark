namespace CallBenchmark
{
    using System;

    using BenchmarkDotNet.Attributes;

    public interface IResolver
    {
        object Resolve();
    }

    public class NonSealedResolver : IResolver
    {
        private readonly object target;

        public NonSealedResolver(object target)
        {
            this.target = target;
        }

        public object Resolve()
        {
            return target;
        }
    }

    public sealed class SealedResolver : IResolver
    {
        private readonly object target;

        public SealedResolver(object target)
        {
            this.target = target;
        }

        public object Resolve()
        {
            return target;
        }
    }

    public class NonSealedDelegateResolver : IResolver
    {
        private readonly Func<object> func;

        public NonSealedDelegateResolver(Func<object> func)
        {
            this.func = func;
        }

        public object Resolve()
        {
            return func();
        }
    }

    public sealed class SealedDelegateResolver : IResolver
    {
        private readonly Func<object> func;

        public SealedDelegateResolver(Func<object> func)
        {
            this.func = func;
        }

        public object Resolve()
        {
            return func();
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly object result = new object();

        private IResolver nonSealedResolver;

        private IResolver sealedResolver;

        private IResolver nonSealedDelegateResolver;

        private IResolver sealedDelegateResolver;

        [GlobalSetup]
        public void Setup()
        {
            nonSealedResolver = new NonSealedResolver(result);
            sealedResolver = new SealedResolver(result);
            nonSealedDelegateResolver = new NonSealedDelegateResolver(() => result);
            sealedDelegateResolver = new SealedDelegateResolver(() => result);
        }

        [Benchmark]
        public object NonSealedResolver()
        {
            return nonSealedResolver.Resolve();
        }

        [Benchmark]
        public object SealedResolver()
        {
            return sealedResolver.Resolve();
        }

        [Benchmark]
        public object NonSealedDelegateResolver()
        {
            return nonSealedDelegateResolver.Resolve();
        }

        [Benchmark]
        public object SealedDelegateResolver()
        {
            return sealedDelegateResolver.Resolve();
        }
    }
}
