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
        private sealed class Holder
        {
            public Func<object[], object> Func { get; set; }
        }

        private static readonly object[] Parameters1 = { 1 };

        private static readonly object[] Parameters8 = { 1, 1, 1, 1, 1, 1, 1, 1 };

        private IActivator newActivator0;
        private IActivator ctorActivator0;
        private IActivator activatorActivator0;
        private IActivator expressionDelegateActivator0;
        private IActivator emitDelegateActivator0;
        private IActivator emitActivator0B;
        private Func<object[], object> expression0;
        private Func<object[], object> dynamicMethod0;
        private readonly Holder holder0 = new Holder();

        private IActivator newActivator1;
        private IActivator ctorActivator1;
        private IActivator activatorActivator1;
        private IActivator expressionDelegateActivator1;
        private IActivator emitDelegateActivator1;
        private IActivator emitActivator1B;
        private Func<object[], object> expression1;
        private Func<object[], object> dynamicMethod1;
        private readonly Holder holder1 = new Holder();

        private IActivator newActivator8;
        private IActivator ctorActivator8;
        private IActivator activatorActivator8;
        private IActivator expressionDelegateActivator8;
        private IActivator emitDelegateActivator8;
        private IActivator emitActivator8B;
        private Func<object[], object> expression8;
        private Func<object[], object> dynamicMethod8;
        private readonly Holder holder8 = new Holder();

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
            activatorActivator0 = new ReflectionNoParameterAcrivatorActivator(type0);   // specilized
            expression0 = CreateExpressionActivator(ctor0);
            expressionDelegateActivator0 = new DelegateActivator(expression0);
            dynamicMethod0 = CreateEmitActivator(ctor0);
            emitDelegateActivator0 = new DelegateActivator(dynamicMethod0);
            emitActivator0B = CreateDynamicActivator(ctor0);
            holder0.Func = dynamicMethod0;

            newActivator1 = new New1Activator();
            ctorActivator1 = new ReflectionConstructorActivator(ctor1);
            activatorActivator1 = new ReflectionAcrivatorActivator(type1);
            expression1 = CreateExpressionActivator(ctor1);
            expressionDelegateActivator1 = new DelegateActivator(expression1);
            dynamicMethod1 = CreateEmitActivator(ctor1);
            emitDelegateActivator1 = new DelegateActivator(dynamicMethod1);
            emitActivator1B = CreateDynamicActivator(ctor1);
            holder1.Func = dynamicMethod1;

            newActivator8 = new New8Activator();
            ctorActivator8 = new ReflectionConstructorActivator(ctor8);
            activatorActivator8 = new ReflectionAcrivatorActivator(type8);
            expression8 = CreateExpressionActivator(ctor8);
            expressionDelegateActivator8 = new DelegateActivator(expression8);
            dynamicMethod8 = CreateEmitActivator(ctor8);
            emitDelegateActivator8 = new DelegateActivator(dynamicMethod8);
            emitActivator8B = CreateDynamicActivator(ctor8);
            holder8.Func = dynamicMethod8;
        }

        //--------------------------------------------------------------------------------
        // Builder
        //--------------------------------------------------------------------------------

        private sealed class New0Activator : IActivator
        {
            public object Create(params object[] arguments)
            {
                return new Class0();
            }
        }

        private sealed class New1Activator : IActivator
        {
            public object Create(params object[] arguments)
            {
                return new Class1((int)arguments[0]);
            }
        }

        private sealed class New8Activator : IActivator
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
                EmitLdcI4(il, i);
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

            var typeBuilder = moduleBuilder.DefineType(
                ctor.DeclaringType.FullName + "_Activator",
                TypeAttributes.Public | TypeAttributes.Sealed);

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
                EmitLdcI4(il, i);
                il.Emit(OpCodes.Ldelem_Ref);
                var paramType = ctor.GetParameters()[i].ParameterType;
                il.Emit(paramType.GetTypeInfo().IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, paramType);
            }

            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Ret);

            var type = typeBuilder.CreateType();

            return (IActivator)Activator.CreateInstance(type);
        }

        private static void EmitLdcI4(ILGenerator il, int i)
        {
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
        }

        //--------------------------------------------------------------------------------
        // Benchmark.0
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object NewActivator0()
        {
            return newActivator0.Create(null);
        }

        [Benchmark]
        public object ReflactionCtorActivator0()
        {
            return ctorActivator0.Create(null);
        }

        [Benchmark]
        public object ReflectionActivatorActivator0()
        {
            return activatorActivator0.Create(null);
        }

        [Benchmark]
        public object ExpressionDelegateActivator0()
        {
            return expressionDelegateActivator0.Create(null);
        }

        [Benchmark]
        public object EmitDelegateActivator0()
        {
            return emitDelegateActivator0.Create(null);
        }

        [Benchmark]
        public object EmitActivator0()
        {
            return emitActivator0B.Create(null);
        }

        [Benchmark]
        public object ExpressionDirect0()
        {
            return expression0(null);
        }

        [Benchmark]
        public object EmitDirect0()
        {
            return dynamicMethod0(null);
        }

        [Benchmark]
        public object EmitIndirect0()
        {
            return holder0.Func(null);
        }

        //--------------------------------------------------------------------------------
        // Benchmark.1
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object NewActivator1()
        {
            return newActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object ReflactionCtorActivator1()
        {
            return ctorActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object ReflectionActivatorActivator1()
        {
            return activatorActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object ExpressionDelegateActivator1()
        {
            return expressionDelegateActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object EmitDelegateActivator1()
        {
            return emitDelegateActivator1.Create(Parameters1);
        }

        [Benchmark]
        public object EmitActivator1()
        {
            return emitActivator1B.Create(Parameters1);
        }

        [Benchmark]
        public object ExpressionDirect1()
        {
            return expression1(Parameters1);
        }

        [Benchmark]
        public object EmitDirect1()
        {
            return dynamicMethod1(Parameters1);
        }

        [Benchmark]
        public object EmitIndirect1()
        {
            return holder1.Func(Parameters1);
        }

        //--------------------------------------------------------------------------------
        // Benchmark.8
        //--------------------------------------------------------------------------------

        [Benchmark]
        public object NewActivator8()
        {
            return newActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object ReflactionCtorActivator8()
        {
            return ctorActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object ReflectionActivatorActivator8()
        {
            return activatorActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object ExpressionDelegateActivator8()
        {
            return expressionDelegateActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object EmitDelegateActivator8()
        {
            return emitDelegateActivator8.Create(Parameters8);
        }

        [Benchmark]
        public object EmitActivator8()
        {
            return emitActivator8B.Create(Parameters8);
        }

        [Benchmark]
        public object ExpressionDirect8()
        {
            return expression8(Parameters8);
        }

        [Benchmark]
        public object EmitDirect8()
        {
            return dynamicMethod8(Parameters8);
        }

        [Benchmark]
        public object EmitIndirect8()
        {
            return holder8.Func(Parameters8);
        }
    }
}
