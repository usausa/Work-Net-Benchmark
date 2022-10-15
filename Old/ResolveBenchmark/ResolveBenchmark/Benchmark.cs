namespace ResolveBenchmark
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

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly object result = new object();

        private IResolver nonSealedResolver;

        private IResolver sealedResolver;

        private Func<object> funcNonSealed;

        private Func<object> funcSealed;

        private Func<object> funcDirect;

        [GlobalSetup]
        public void Setup()
        {
            nonSealedResolver = new NonSealedResolver(result);
            sealedResolver = new SealedResolver(result);
            funcNonSealed = nonSealedResolver.Resolve;
            funcSealed = sealedResolver.Resolve;
            funcDirect = () => result;
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
        public object FuncNonSealed()
        {
            return funcNonSealed();
        }

        [Benchmark]
        public object FuncSealed()
        {
            return funcSealed();
        }

        [Benchmark]
        public object FuncDirect()
        {
            return funcDirect();
        }
    }
}
