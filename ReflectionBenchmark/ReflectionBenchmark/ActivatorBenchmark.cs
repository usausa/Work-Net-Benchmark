using System;
using System.Reflection;

namespace ReflectionBenchmark
{
    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class ActivatorBenchmark
    {
        private static readonly Type Type0 = typeof(Class0);

        private static readonly Type Type1 = typeof(Class1);

        private static readonly Type Type2 = typeof(Class2);

        private static readonly Type Type8 = typeof(Class8);

        private static readonly ConstructorInfo Ctor0 = typeof(Class0).GetConstructors()[0];

        private static readonly ConstructorInfo Ctor1 = typeof(Class1).GetConstructors()[0];

        private static readonly ConstructorInfo Ctor2 = typeof(Class2).GetConstructors()[0];

        private static readonly ConstructorInfo Ctor8 = typeof(Class8).GetConstructors()[0];

        private static readonly object[] Args0 = {};

        private static readonly object[] Args1 = { 0 };

        private static readonly object[] Args2 = { 0, 0 };

        private static readonly object[] Args8 = { 0, 0, 0, 0, 0, 0, 0, 0 };

        [Benchmark]
        public object New0()
        {
            return new Class0();
        }

        [Benchmark]
        public object Activator0()
        {
            return Activator.CreateInstance(Type0);
        }

        [Benchmark]
        public object ConstructorInfo0()
        {
            return Ctor0.Invoke(Args0);
        }

        [Benchmark]
        public object ConstructorInfo0WithNull()
        {
            return Ctor0.Invoke(null);
        }

        [Benchmark]
        public object New1()
        {
            return new Class1(0);
        }

        [Benchmark]
        public object Activator1()
        {
            return Activator.CreateInstance(Type1, Args1);
        }

        [Benchmark]
        public object ConstructorInfo1()
        {
            return Ctor1.Invoke(Args1);
        }

        [Benchmark]
        public object New2()
        {
            return new Class2(0, 0);
        }

        [Benchmark]
        public object Activator2()
        {
            return Activator.CreateInstance(Type2, Args2);
        }

        [Benchmark]
        public object ConstructorInfo2()
        {
            return Ctor2.Invoke(Args2);
        }

        [Benchmark]
        public object New8()
        {
            return new Class8(0, 0, 0, 0, 0, 0, 0, 0);
        }

        [Benchmark]
        public object Activator8()
        {
            return Activator.CreateInstance(Type8, Args8);
        }

        [Benchmark]
        public object ConstructorInfo8()
        {
            return Ctor8.Invoke(Args8);
        }
    }
}
