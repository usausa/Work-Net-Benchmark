namespace ActivatorBenchmark
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;

    using BenchmarkDotNet.Attributes;

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private static readonly object[] Parameters1 = { 1 };

        private static readonly object[] Parameters8 = { 1, 1, 1, 1, 1, 1, 1, 1 };

        private Func<object[], object> newFunc0;
        private Func<object[], object> ctorFunc0;
        private Func<object[], object> activatorFunc0;
        private Func<object> activatorFunc0B;
        private Func<object[], object> expressionFunc0;
        private Func<object> expressionFunc0B;
        private Func<object[], object> emitFunc0;
        private Func<object> emitFunc0B;

        private Func<object[], object> newFunc1;
        private Func<object[], object> ctorFunc1;
        private Func<object[], object> activatorFunc1;
        private Func<object[], object> expressionFunc1;
        private Func<object[], object> emitFunc1;

        private Func<object[], object> newFunc8;
        private Func<object[], object> ctorFunc8;
        private Func<object[], object> activatorFunc8;
        private Func<object[], object> expressionFunc8;
        private Func<object[], object> emitFunc8;

        [GlobalSetup]
        public void Setup()
        {
            var type0 = typeof(Class0);
            var ctor0 = type0.GetConstructors()[0];

            var type1 = typeof(Class1);
            var ctor1 = type1.GetConstructors()[0];

            var type8 = typeof(Class8);
            var ctor8 = type8.GetConstructors()[0];

            newFunc0 = parameters => new Class0();
            ctorFunc0 = parameters => ctor0.Invoke(null);
            activatorFunc0 = parameters => Activator.CreateInstance(type0);
            activatorFunc0B = () => Activator.CreateInstance(type0);
            expressionFunc0 = CreateExpressionActivator(ctor0);
            expressionFunc0B = CreateExpressionActivator0(ctor0);
            emitFunc0 = CreateEmitActivator(ctor0);
            emitFunc0B = CreateEmitActivator0(ctor0);

            newFunc1 = parameters => new Class1((int)parameters[0]);
            ctorFunc1 = parameters => ctor1.Invoke(parameters);
            activatorFunc1 = parameters => Activator.CreateInstance(type1, parameters);
            expressionFunc1 = CreateExpressionActivator(ctor1);
            emitFunc1 = CreateEmitActivator(ctor1);

            newFunc8 = parameters => new Class8(
                (int) parameters[0], (int) parameters[1], (int) parameters[2], (int) parameters[3],
                (int) parameters[4], (int) parameters[5], (int) parameters[6], (int) parameters[7]);
            ctorFunc8 = parameters => ctor8.Invoke(parameters);
            activatorFunc8 = parameters => Activator.CreateInstance(type8, parameters);
            expressionFunc8 = CreateExpressionActivator(ctor8);
            emitFunc8 = CreateEmitActivator(ctor8);
        }

        //--------------------------------------------------------------------------------
        // Builder
        //--------------------------------------------------------------------------------

        private static readonly Type ObjectArrayType = typeof(object[]);

        public static Func<object[], object> CreateExpressionActivator(ConstructorInfo ci)
        {
            var parameters = ci.GetParameters();

            var parametersExpression = Expression.Parameter(ObjectArrayType, "args");
            var argumentsExpression = new Expression[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
            {
                var parameterType = parameters[i].ParameterType;

                var parameterIndexExpression = Expression.ArrayIndex(parametersExpression, Expression.Constant(i));
                argumentsExpression[i] = Expression.ArrayIndex(parametersExpression, Expression.Constant(i));
                var convertExpression = Expression.Convert(parameterIndexExpression, parameterType);
                argumentsExpression[i] = convertExpression;

                //if (parameterType.GetTypeInfo().IsValueType)
                //{
                //    argumentsExpression[i] = Expression.Condition(
                //        Expression.Equal(parameterIndexExpression, Expression.Constant(null)),
                //        Expression.Default(parameterType),
                //        convertExpression);
                //}
                //else
                //{
                //    argumentsExpression[i] = convertExpression;
                //}
            }

            return Expression.Lambda<Func<object[], object>>(
                Expression.New(ci, argumentsExpression),
                parametersExpression).Compile();
        }

        // MEMO 特殊化した方が速い
        public static Func<object> CreateExpressionActivator0(ConstructorInfo ci)
        {
            return Expression.Lambda<Func<object>>(Expression.New(ci)).Compile();
        }

        public static Func<object[], object> CreateEmitActivator(ConstructorInfo ctor)
        {
            var dynamic = new DynamicMethod(
                string.Empty,
                typeof(object),
                new[] { typeof(object[]) },
                true);
            var il = dynamic.GetILGenerator();

            for (var i = 0; i < ctor.GetParameters().Length; i++)
            {
                il.Emit(OpCodes.Ldarg_0);
                switch (i)
                {
                    case 0: il.Emit(OpCodes.Ldc_I4_0); break;
                    case 1: il.Emit(OpCodes.Ldc_I4_1); break;
                    case 2: il.Emit(OpCodes.Ldc_I4_2); break;
                    case 3: il.Emit(OpCodes.Ldc_I4_3); break;
                    case 4: il.Emit(OpCodes.Ldc_I4_4); break;
                    case 5: il.Emit(OpCodes.Ldc_I4_5); break;
                    case 6: il.Emit(OpCodes.Ldc_I4_6); break;
                    case 7: il.Emit(OpCodes.Ldc_I4_7); break;
                    case 8: il.Emit(OpCodes.Ldc_I4_8); break;
                    default:
                        if (i < 128)
                        {
                            il.Emit(OpCodes.Ldc_I4_S, (sbyte)i);
                        }
                        else
                        {
                            il.Emit(OpCodes.Ldc_I4, i);
                        }
                        break;
                }
                il.Emit(OpCodes.Ldelem_Ref);
                var paramType = ctor.GetParameters()[i].ParameterType;
                il.Emit(paramType.GetTypeInfo().IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, paramType);
            }

            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Ret);

            return (Func<object[], object>)dynamic.CreateDelegate(typeof(Func<object[], object>));
        }

        public static Func<object> CreateEmitActivator0(ConstructorInfo ci)
        {
            var dynamic = new DynamicMethod(
                string.Empty,
                typeof(object),
                Type.EmptyTypes);
            var il = dynamic.GetILGenerator();

            il.Emit(OpCodes.Newobj, ci);
            il.Emit(OpCodes.Ret);

            return (Func<object>)dynamic.CreateDelegate(typeof(Func<object>));
        }

        //--------------------------------------------------------------------------------
        // Benchmark.0
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object New0()
        {
            return newFunc0(null);
        }

        [Benchmark]
        public object Ctor0()
        {
            return ctorFunc0(null);
        }

        [Benchmark]
        public object Activator0()
        {
            return activatorFunc0(null);
        }

        [Benchmark]
        public object Activator0B()
        {
            return activatorFunc0B();
        }

        [Benchmark]
        public object Expression0()
        {
            return expressionFunc0(null);
        }

        [Benchmark]
        public object Expression0B()
        {
            return expressionFunc0B();
        }

        [Benchmark]
        public object Emit0()
        {
            return emitFunc0(null);
        }

        [Benchmark]
        public object Emit0B()
        {
            return emitFunc0B();
        }

        //--------------------------------------------------------------------------------
        // Benchmark.1
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object New1()
        {
            return newFunc1(Parameters1);
        }

        [Benchmark]
        public object Ctor1()
        {
            return ctorFunc1(Parameters1);
        }

        [Benchmark]
        public object Activator1()
        {
            return activatorFunc1(Parameters1);
        }

        [Benchmark]
        public object Expression1()
        {
            return expressionFunc1(Parameters1);
        }

        [Benchmark]
        public object Emit1()
        {
            return emitFunc1(Parameters1);
        }

        //--------------------------------------------------------------------------------
        // Benchmark.8
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object New8()
        {
            return newFunc8(Parameters8);
        }

        [Benchmark]
        public object Ctor8()
        {
            return ctorFunc8(Parameters8);
        }

        [Benchmark]
        public object Activator8()
        {
            return activatorFunc8(Parameters8);
        }

        [Benchmark]
        public object Expression8()
        {
            return expressionFunc8(Parameters8);
        }

        [Benchmark]
        public object Emit8()
        {
            return emitFunc8(Parameters8);
        }
    }
}
