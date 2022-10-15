namespace DynamicMethodBenshmark
{
    using System;
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
            BenchmarkRunner.Run<Benchmark>();
        }
    }
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MarkdownExporter.Default, MarkdownExporter.GitHub);
            Add(MemoryDiagnoser.Default);
            Add(Job.Core, Job.Clr);
        }
    }

    public class Data
    {
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private Func<object> funcByTypeBuilder;

        private Func<object> funcByDyanmicMethod;

        [GlobalSetup]
        public void Setup()
        {
            var ci = typeof(Data).GetConstructor(Type.EmptyTypes);
            funcByTypeBuilder = Generator.CreateFactoryByTypeBuilder(ci);
            funcByDyanmicMethod = Generator.CreateFactoryByDynamicMethod(ci);
        }

        [Benchmark]
        public void ByTypeBuilder()
        {
            funcByTypeBuilder();
        }

        [Benchmark]
        public void ByDynamicMethod()
        {
            funcByDyanmicMethod();
        }
    }

    public interface IFactory0
    {
        object Create();
    }

    // default constructor only
    public static class Generator
    {
        public static Func<object> CreateFactoryByTypeBuilder(ConstructorInfo ci)
        {
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName("DynamicMethodBenshmark"),
                AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule(
                "DynamicMethodBenshmark");

            var typeBuilder = moduleBuilder.DefineType(
                "Factory0",
                TypeAttributes.Public | TypeAttributes.AutoLayout | TypeAttributes.AnsiClass | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit);
            typeBuilder.AddInterfaceImplementation(typeof(IFactory0));

            // Constructor
            var ctor = typeBuilder.DefineConstructor(
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName,
                CallingConventions.Standard,
                Type.EmptyTypes);

            var ilGenerator = ctor.GetILGenerator();

            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));

            ilGenerator.Emit(OpCodes.Ret);

            // Method:Create
            var method = typeBuilder.DefineMethod(
                nameof(IFactory0.Create),
                MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final,
                typeof(object),
                Type.EmptyTypes);
            typeBuilder.DefineMethodOverride(method, typeof(IFactory0).GetMethod(nameof(IFactory0.Create)));

            ilGenerator = method.GetILGenerator();

            ilGenerator.Emit(OpCodes.Newobj, ci);
            ilGenerator.Emit(OpCodes.Ret);

            var typeInfo = typeBuilder.CreateTypeInfo();
            var factory = (IFactory0)Activator.CreateInstance(typeInfo.AsType());

            return factory.Create;
        }

        public static Func<object> CreateFactoryByDynamicMethod(ConstructorInfo ci)
        {
            var dynamic = new DynamicMethod(string.Empty, typeof(object), new[] { typeof(object) }, true);
            var il = dynamic.GetILGenerator();

            il.Emit(OpCodes.Newobj, ci);
            il.Emit(OpCodes.Ret);

            return (Func<object>)dynamic.CreateDelegate(typeof(Func<object>), null);
        }
    }
}
