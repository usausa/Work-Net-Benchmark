namespace DynamicMethodBenchmark
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);
        }
    }

    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MarkdownExporter.Default, MarkdownExporter.GitHub);
            Add(MemoryDiagnoser.Default);
            Add(Job.ShortRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private const int Loop = 1000;

        private static readonly object[] Parameter1 = { "1" };

        private static readonly object[] Parameter4 = { "1", "2", "3", "4" };

        private static readonly object[] Parameter8 = { "1", "2", "3", "4", "5", "5", "7", "8" };

        private Func<object[], object> method00;
        private Func<object[], object> method01;
        private Func<object[], object> method02;
        private Func<object[], object> method03;

        private Func<object[], object> method10;
        private Func<object[], object> method11;
        private Func<object[], object> method12;
        private Func<object[], object> method13;

        private Func<object[], object> method40;
        private Func<object[], object> method41;
        private Func<object[], object> method42;
        private Func<object[], object> method43;

        private Func<object[], object> method80;
        private Func<object[], object> method81;
        private Func<object[], object> method82;
        private Func<object[], object> method83;

        [GlobalSetup]
        public void Setup()
        {
            var ctor0 = typeof(Data0).GetConstructors().First();
            method00 = CreateExpressionMethod(ctor0);
            method01 = CreateDynamicMethod1(ctor0);
            method02 = CreateDynamicMethod2(ctor0);
            method03 = CreateDynamicMethod3(ctor0);

            var ctor1 = typeof(Data1).GetConstructors().First();
            method10 = CreateExpressionMethod(ctor1);
            method11 = CreateDynamicMethod1(ctor1);
            method12 = CreateDynamicMethod2(ctor1);
            method13 = CreateDynamicMethod3(ctor1);

            var ctor4 = typeof(Data4).GetConstructors().First();
            method40 = CreateExpressionMethod(ctor4);
            method41 = CreateDynamicMethod1(ctor4);
            method42 = CreateDynamicMethod2(ctor4);
            method43 = CreateDynamicMethod3(ctor4);

            var ctor8 = typeof(Data8).GetConstructors().First();
            method80 = CreateExpressionMethod(ctor8);
            method81 = CreateDynamicMethod1(ctor8);
            method82 = CreateDynamicMethod2(ctor8);
            method83 = CreateDynamicMethod3(ctor8);
        }

        [Benchmark]
        public void CreateByExpression0()
        {
            for (var i = 0; i < Loop; i++)
            {
                method00(null);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod01()
        {
            for (var i = 0; i < Loop; i++)
            {
                method01(null);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod02()
        {
            for (var i = 0; i < Loop; i++)
            {
                method02(null);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod03()
        {
            for (var i = 0; i < Loop; i++)
            {
                method03(null);
            }
        }

        [Benchmark]
        public void CreateByExpression1()
        {
            for (var i = 0; i < Loop; i++)
            {
                method10(Parameter1);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod11()
        {
            for (var i = 0; i < Loop; i++)
            {
                method11(Parameter1);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod12()
        {
            for (var i = 0; i < Loop; i++)
            {
                method12(Parameter1);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod13()
        {
            for (var i = 0; i < Loop; i++)
            {
                method13(Parameter1);
            }
        }

        [Benchmark]
        public void CreateByExpression4()
        {
            for (var i = 0; i < Loop; i++)
            {
                method40(Parameter4);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod41()
        {
            for (var i = 0; i < Loop; i++)
            {
                method41(Parameter4);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod42()
        {
            for (var i = 0; i < Loop; i++)
            {
                method42(Parameter4);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod43()
        {
            for (var i = 0; i < Loop; i++)
            {
                method43(Parameter4);
            }
        }

        [Benchmark]
        public void CreateByExpression8()
        {
            for (var i = 0; i < Loop; i++)
            {
                method80(Parameter8);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod81()
        {
            for (var i = 0; i < Loop; i++)
            {
                method81(Parameter8);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod82()
        {
            for (var i = 0; i < Loop; i++)
            {
                method82(Parameter8);
            }
        }

        [Benchmark]
        public void CreateByDynamicMethod83()
        {
            for (var i = 0; i < Loop; i++)
            {
                method83(Parameter8);
            }
        }

        public static Func<object[], object> CreateDynamicMethod1(ConstructorInfo ctor)
        {
            var dynamic = new DynamicMethod(
                string.Empty,
                typeof(object),
                new[] { typeof(object[]) });
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

        public static Func<object[], object> CreateDynamicMethod2(ConstructorInfo ctor)
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

        public static Func<object[], object> CreateDynamicMethod3(ConstructorInfo ctor)
        {
            var dynamic = new DynamicMethod(
                string.Empty,
                typeof(object),
                new[] { typeof(object), typeof(object[]) },
                true);
            var il = dynamic.GetILGenerator();

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

            return (Func<object[], object>)dynamic.CreateDelegate(typeof(Func<object[], object>), null);
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

        public static Func<object[], object> CreateExpressionMethod(ConstructorInfo ci)
        {
            var parameters = ci.GetParameters();

            var parametersExpression = Expression.Parameter(typeof(object[]), "args");
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
    }

    public class Data0
    {
    }

    public class Data1
    {
        public Data1(string p1)
        {
        }
    }

    public class Data4
    {
        public Data4(string p1, string p2, string p3, string p4)
        {
        }
    }

    public class Data8
    {
        public Data8(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8)
        {
        }
    }
}
