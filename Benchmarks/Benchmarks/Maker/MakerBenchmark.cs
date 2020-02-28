namespace Benchmarks.Maker
{
    using System;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class MakerBenchmark
    {
        private const int N = 1000;

        private readonly TypeHashArrayMap<object> map = new TypeHashArrayMap<object>();

        private readonly Type targetType = typeof(Target);

        private readonly Type markerType = typeof(ITarget);

        public MakerBenchmark()
        {
            map.AddIfNotExist(targetType, new object());
        }

        [Benchmark(OperationsPerInvoke = N, Baseline = true)]
        public bool Attribute()
        {
            var ret = false;
            for (var i = 0; i < N; i++)
            {
                ret = targetType.GetCustomAttribute<TargetAttribute>() != null;
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool Interface()
        {
            var ret = false;
            for (var i = 0; i < N; i++)
            {
                ret = markerType.IsAssignableFrom(targetType);
            }
            return ret;
        }

        [Benchmark(OperationsPerInvoke = N)]
        public bool Dictionary()
        {
            var ret = false;
            for (var i = 0; i < N; i++)
            {
                ret = map.TryGetValue(targetType, out _);
            }
            return ret;
        }
    }

    public sealed class TargetAttribute : Attribute
    {
    }

    public interface ITarget
    {
    }

    [Target]
    public sealed class Target : ITarget
    {
    }
}
