using System.Reflection;

namespace AccessorBenchmark
{
    using System;


    public interface IAccessor
    {
        object GetValue(object target);

        void SetValue(object target, object value);
    }

    public class NoTypedAccsessor : IAccessor
    {
        private readonly Func<object, object> getter;

        private readonly Action<object, object> setter;

        public NoTypedAccsessor(Func<object, object> getter, Action<object, object> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }

        public object GetValue(object target)
        {
            return getter(target);
        }

        public void SetValue(object target, object value)
        {
            setter(target, value);
        }
    }

    public class TypedAccsessor<TTarget, TMember> : IAccessor
    {
        private readonly Func<TTarget, TMember> getter;

        private readonly Action<TTarget, TMember> setter;

        public TypedAccsessor(Func<TTarget, TMember> getter, Action<TTarget, TMember> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }

        public object GetValue(object target)
        {
            return getter((TTarget)target);
        }

        public void SetValue(object target, object value)
        {
            setter((TTarget)target, (TMember)value);
        }
    }

    public class ReflectionAccessor : IAccessor
    {
        private readonly PropertyInfo pi;

        public ReflectionAccessor(PropertyInfo pi)
        {
            this.pi = pi;
        }

        public object GetValue(object target)
        {
            return pi.GetValue(target);
        }

        public void SetValue(object target, object value)
        {
            pi.SetValue(target, value);
        }
    }
}
