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

        private IActivator newActivator0;
        private IActivator ctorActivator0;
        private IActivator activatorActivator0;
        private IActivator expressionActivator0;
        private IActivator emitActivator0;
        private IActivator emitActivator0B;

        private IActivator newActivator1;
        private IActivator ctorActivator1;
        private IActivator activatorActivator1;
        private IActivator expressionActivator1;
        private IActivator emitActivator1;
        private IActivator emitActivator1B;

        private IActivator newActivator8;
        private IActivator ctorActivator8;
        private IActivator activatorActivator8;
        private IActivator expressionActivator8;
        private IActivator emitActivator8;
        private IActivator emitActivator8B;

        [GlobalSetup]
        public void Setup()
        {
            var type0 = typeof(Class0);
            var ctor0 = type0.GetConstructors()[0];

            var type1 = typeof(Class1);
            var ctor1 = type1.GetConstructors()[0];

            var type8 = typeof(Class8);
            var ctor8 = type8.GetConstructors()[0];

            newActivator0 = new New0Activator();
            ctorActivator0 = new ReflectionConstructorActivator(ctor0);
            activatorActivator0 = new ReflectionAcrivator0Activator(type0);
            expressionActivator0 = new DelegateActivator(CreateExpressionActivator(ctor0));
            emitActivator0 = new DelegateActivator(CreateEmitActivator(ctor0));
            emitActivator0B = CreateDynamicActivator(ctor0);

            newActivator1 = new New1Activator();
            ctorActivator1 = new ReflectionConstructorActivator(ctor1);
            activatorActivator1 = new ReflectionAcrivatorActivator(type1);
            expressionActivator1 = new DelegateActivator(CreateExpressionActivator(ctor1));
            emitActivator1 = new DelegateActivator(CreateEmitActivator(ctor1));
            emitActivator1B = CreateDynamicActivator(ctor1);

            newActivator8 = new New8Activator();
            ctorActivator8 = new ReflectionConstructorActivator(ctor8);
            activatorActivator8 = new ReflectionAcrivatorActivator(type8);
            expressionActivator8 = new DelegateActivator(CreateExpressionActivator(ctor8));
            emitActivator8 = new DelegateActivator(CreateEmitActivator(ctor8));
            emitActivator8B = CreateDynamicActivator(ctor8);
        }

        //--------------------------------------------------------------------------------
        // Builder
        //--------------------------------------------------------------------------------

        private class New0Activator : IActivator
        {
            public object Create(params object[] arguments)
            {
                return new Class0();
            }
        }

        private class New1Activator : IActivator
        {
            public object Create(params object[] arguments)
            {
                return new Class1((int)arguments[0]);
            }
        }

        private class New8Activator : IActivator
        {
            public object Create(params object[] arguments)
            {
                return new Class8(
                    (int)arguments[0], (int)arguments[1], (int)arguments[2], (int)arguments[3],
                    (int)arguments[4], (int)arguments[5], (int)arguments[6], (int)arguments[7]);
            }
        }

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
                    case 0:
                        il.Emit(OpCodes.Ldc_I4_0);
                        break;
                    case 1:
                        il.Emit(OpCodes.Ldc_I4_1);
                        break;
                    case 2:
                        il.Emit(OpCodes.Ldc_I4_2);
                        break;
                    case 3:
                        il.Emit(OpCodes.Ldc_I4_3);
                        break;
                    case 4:
                        il.Emit(OpCodes.Ldc_I4_4);
                        break;
                    case 5:
                        il.Emit(OpCodes.Ldc_I4_5);
                        break;
                    case 6:
                        il.Emit(OpCodes.Ldc_I4_6);
                        break;
                    case 7:
                        il.Emit(OpCodes.Ldc_I4_7);
                        break;
                    case 8:
                        il.Emit(OpCodes.Ldc_I4_8);
                        break;
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

        private static IActivator CreateDynamicActivator(ConstructorInfo ctor)
        {
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName("DynamicActivator"),
                AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicActivator");

            var typeBuilder = moduleBuilder.DefineType(ctor.DeclaringType.FullName + "_Activator");

            typeBuilder.AddInterfaceImplementation(typeof(IActivator));
            var methodBuilder = typeBuilder.DefineMethod(
                nameof(IActivator.Create),
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof(object),
                new[] { typeof(object[]) });
            typeBuilder.DefineMethodOverride(methodBuilder, typeof(IActivator).GetMethod(nameof(IActivator.Create)));

            var il = methodBuilder.GetILGenerator();

            for (var i = 0; i < ctor.GetParameters().Length; i++)
            {
                il.Emit(OpCodes.Ldarg_1);
                switch (i)
                {
                    case 0:
                        il.Emit(OpCodes.Ldc_I4_0);
                        break;
                    case 1:
                        il.Emit(OpCodes.Ldc_I4_1);
                        break;
                    case 2:
                        il.Emit(OpCodes.Ldc_I4_2);
                        break;
                    case 3:
                        il.Emit(OpCodes.Ldc_I4_3);
                        break;
                    case 4:
                        il.Emit(OpCodes.Ldc_I4_4);
                        break;
                    case 5:
                        il.Emit(OpCodes.Ldc_I4_5);
                        break;
                    case 6:
                        il.Emit(OpCodes.Ldc_I4_6);
                        break;
                    case 7:
                        il.Emit(OpCodes.Ldc_I4_7);
                        break;
                    case 8:
                        il.Emit(OpCodes.Ldc_I4_8);
                        break;
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

            var type = typeBuilder.CreateType();

            return (IActivator)Activator.CreateInstance(type);
        }

        //--------------------------------------------------------------------------------
        // Benchmark.0
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object New0()
        {
            return newActivator0.Create(null);
        }

        [Benchmark]
        public object Ctor0()
        {
            return ctorActivator0.Create(null);
        }

        [Benchmark]
        public object Activator0()
        {
            return activatorActivator0.Create(null);
        }

        [Benchmark]
        public object Expression0()
        {
            return expressionActivator0.Create(null);
        }

        [Benchmark]
        public object Emit0()
        {
            return emitActivator0.Create(null);
        }

        [Benchmark]
        public object Emit0B()
        {
            return emitActivator0B.Create(null);
        }

        //--------------------------------------------------------------------------------
        // Benchmark.1
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object New1()
        {
            return newActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object Ctor1()
        {
            return ctorActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object Activator1()
        {
            return activatorActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object Expression1()
        {
            return expressionActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object Emit1()
        {
            return emitActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object Emit1B()
        {
            return emitActivator1B.Create(Parameters1);
        }

        //--------------------------------------------------------------------------------
        // Benchmark.8
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object New8()
        {
            return newActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object Ctor8()
        {
            return ctorActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object Activator8()
        {
            return activatorActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object Expression8()
        {
            return expressionActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object Emit8()
        {
            return emitActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object Emit8B()
        {
            return emitActivator8B.Create(Parameters8);
        }
    }
}
