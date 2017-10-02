namespace AccessorBenchmark
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly Data target = new Data();

        private readonly string value = string.Empty;

        private IAccessor generativeAccessor;

        private IAccessor dynaicMethodAccessor;

        private IAccessor expressionAccessor;

        private IAccessor delegateAccessor;

        private IAccessor reflectionAccessor;

        [GlobalSetup]
        public void Setup()
        {
            var pi = typeof(Data).GetProperty("Value");

            generativeAccessor = new GenerativeDataValieAccessor();
            dynaicMethodAccessor = CreateDynamicMethodAccessor(pi);
            expressionAccessor = CreateExpressionAccessor<Data, string>(pi);
            delegateAccessor = CreateDelegateAccessor<Data, string>(pi);
            reflectionAccessor = new ReflectionAccessor(pi);
        }

        //--------------------------------------------------------------------------------
        // Builder
        //--------------------------------------------------------------------------------

        // Raw

        private sealed class GenerativeDataValieAccessor : IAccessor
        {
            public object GetValue(object target)
            {
                return ((Data)target).Value;
            }

            public void SetValue(object target, object value)
            {
                ((Data)target).Value = (string)value;
            }
        }

        // DynamicMethod

        private IAccessor CreateDynamicMethodAccessor(PropertyInfo pi)
        {
            return (IAccessor)Activator.CreateInstance(
                typeof(NoTypedAccsessor),
                CreateDynamicMethodGetter(pi),
                CreateDynamicMethodSetter(pi));
        }

        private static Func<object, object> CreateDynamicMethodGetter(PropertyInfo pi)
        {
            var method = new DynamicMethod(string.Empty, typeof(object), new[] { typeof(object) }, true);
            var generator = method.GetILGenerator();
            var getter = pi.GetGetMethod(true);

            generator.DeclareLocal(typeof(object));
            generator.Emit(OpCodes.Ldarg_0);
            EmitTypeConversion(generator, pi.DeclaringType, true);
            EmitCall(generator, getter);
            if (pi.PropertyType.IsValueType)
            {
                generator.Emit(OpCodes.Box, pi.PropertyType);
            }

            generator.Emit(OpCodes.Ret);

            return (Func<object, object>)method.CreateDelegate(typeof(Func<object, object>));
        }

        private static Action<object, object> CreateDynamicMethodSetter(PropertyInfo pi)
        {
            var method = new DynamicMethod(string.Empty, typeof(void), new[] { typeof(object), typeof(object) }, true);
            var generator = method.GetILGenerator();
            var setter = pi.GetSetMethod(true);

            generator.Emit(OpCodes.Ldarg_0);
            EmitTypeConversion(generator, pi.DeclaringType, true);
            generator.Emit(OpCodes.Ldarg_1);
            EmitTypeConversion(generator, pi.PropertyType, false);
            EmitCall(generator, setter);
            generator.Emit(OpCodes.Ret);

            return (Action<object, object>)method.CreateDelegate(typeof(Action<object, object>));
        }

        private static void EmitTypeConversion(ILGenerator generator, Type castType, bool isContainer)
        {
            if (castType == typeof(object))
            {
            }
            else if (castType.IsValueType)
            {
                generator.Emit(isContainer ? OpCodes.Unbox : OpCodes.Unbox_Any, castType);
            }
            else
            {
                generator.Emit(OpCodes.Castclass, castType);
            }
        }

        private static void EmitCall(ILGenerator generator, MethodInfo method)
        {
            var opcode = (method.IsStatic || method.DeclaringType.IsValueType) ? OpCodes.Call : OpCodes.Callvirt;
            generator.EmitCall(opcode, method, null);
        }

        // Expression

        private IAccessor CreateExpressionAccessor<TTarget, TMember>(PropertyInfo pi)
        {
            return (IAccessor)Activator.CreateInstance(
                typeof(TypedAccsessor<TTarget, TMember>),
                CreateExpressionGetter<TTarget, TMember>(pi),
                CreateExpressionSetter<TTarget, TMember>(pi));
        }

        private static Func<TTarget, TMember> CreateExpressionGetter<TTarget, TMember>(PropertyInfo pi)
        {
            var parameterExpression = Expression.Parameter(typeof(TTarget));
            var propertyExpression = Expression.Property(parameterExpression, pi);
            return Expression.Lambda<Func<TTarget, TMember>>(
                propertyExpression,
                parameterExpression).Compile();
        }

        private static Action<TTarget, TMember> CreateExpressionSetter<TTarget, TMember>(PropertyInfo pi)
        {
            var parameterExpression = Expression.Parameter(typeof(TTarget));
            var parameterExpression2 = Expression.Parameter(typeof(TMember));
            var propertyExpression = Expression.Property(parameterExpression, pi);
            return Expression.Lambda<Action<TTarget, TMember>>(
                Expression.Assign(propertyExpression, parameterExpression2),
                parameterExpression,
                parameterExpression2).Compile();
        }

        // Delegate

        private IAccessor CreateDelegateAccessor<TTarget, TMember>(PropertyInfo pi)
        {
            return (IAccessor)Activator.CreateInstance(
                typeof(TypedAccsessor<TTarget, TMember>),
                CreateDelegateGetter<TTarget, TMember>(pi),
                CreateDelegateSetter<TTarget, TMember>(pi));
        }

        public static Func<TTarget, TMember> CreateDelegateGetter<TTarget, TMember>(PropertyInfo pi)
        {
            var getter = pi.GetMethod;
            var getterDelegateType = typeof(Func<,>).MakeGenericType(pi.DeclaringType, pi.PropertyType);
            return (Func<TTarget, TMember>)getter.CreateDelegate(getterDelegateType, null);
        }

        public static Action<TTarget, TMember> CreateDelegateSetter<TTarget, TMember>(PropertyInfo pi)
        {
            var setter = pi.SetMethod;
            var setterDelegateType = typeof(Action<,>).MakeGenericType(pi.DeclaringType, pi.PropertyType);
            return (Action<TTarget, TMember>)setter.CreateDelegate(setterDelegateType, null);
        }

        //--------------------------------------------------------------------------------
        // Getter
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object GenerativeGetter()
        {
            return generativeAccessor.GetValue(target);
        }

        [Benchmark]
        public object DynamicMethodGetter()
        {
            return dynaicMethodAccessor.GetValue(target);
        }

        [Benchmark]
        public object ExpressionGetter()
        {
            return expressionAccessor.GetValue(target);
        }

        [Benchmark]
        public object DelegateGetter()
        {
            return delegateAccessor.GetValue(target);
        }

        [Benchmark]
        public object ReflectionGetter()
        {
            return reflectionAccessor.GetValue(target);
        }

        //--------------------------------------------------------------------------------
        // Setter
        //--------------------------------------------------------------------------------

        [Benchmark]
        public void GenerativeSetter()
        {
            generativeAccessor.SetValue(target, value);
        }

        [Benchmark]
        public void DynamicMethodSetter()
        {
            dynaicMethodAccessor.SetValue(target, value);
        }

        [Benchmark]
        public void ExpressionSetter()
        {
            expressionAccessor.SetValue(target, value);
        }

        [Benchmark]
        public void DelegateSetter()
        {
            delegateAccessor.SetValue(target, value);
        }

        [Benchmark]
        public void ReflectionSetter()
        {
            reflectionAccessor.SetValue(target, value);
        }
    }
}
