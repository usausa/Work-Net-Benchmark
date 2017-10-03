﻿namespace ActivatorBenchmark
{
    using System;
    using System.Reflection;

    public interface IActivator
    {
        object Create(params object[] arguments);
    }

    public class DelegateActivator : IActivator
    {
        private readonly Func<object[], object> func;

        public DelegateActivator(Func<object[], object> func)
        {
            this.func = func;
        }

        public object Create(params object[] arguments)
        {
            return func(arguments);
        }
    }

    public class ReflectionAcrivator0Activator : IActivator
    {
        private readonly Type type;

        public ReflectionAcrivator0Activator(Type type)
        {
            this.type = type;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(type);
        }
    }

    public class ReflectionAcrivatorActivator : IActivator
    {
        private readonly Type type;

        public ReflectionAcrivatorActivator(Type type)
        {
            this.type = type;
        }

        public object Create(params object[] arguments)
        {
            return Activator.CreateInstance(type, arguments);
        }
    }

    public class ReflectionConstructorActivator : IActivator
    {
        private readonly ConstructorInfo ci;

        public ReflectionConstructorActivator(ConstructorInfo ci)
        {
            this.ci = ci;
        }

        public object Create(params object[] arguments)
        {
            return ci.Invoke(arguments);
        }
    }

}
