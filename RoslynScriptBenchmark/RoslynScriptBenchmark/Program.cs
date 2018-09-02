namespace RoslynScriptBenchmark
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using Microsoft.CodeAnalysis.Scripting;

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
            Add(Job.MediumRun);
        }
    }

    public interface IFactory
    {
        object Create();
    }

    public sealed class PreCompiledFactory : IFactory
    {
        public object Create() => new object();
    }

    public class ScriptGlobals
    {
        public Dictionary<string, Type> Types { get; } = new Dictionary<string, Type>();
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private IFactory preCompiled;

        private IFactory runtimeCompiled;

        [GlobalSetup]
        public void Setup()
        {
            preCompiled = new PreCompiledFactory();

            var script = CSharpScript.Create(
                @"using RoslynScriptBenchmark;" +
                @"public sealed class RuntimeCompiledFactory : IFactory { public object Create() => new object(); }" +
                @"Types.Add(typeof(RuntimeCompiledFactory).Name, typeof(RuntimeCompiledFactory));",
                ScriptOptions.Default.WithReferences(Assembly.GetExecutingAssembly()),
                typeof(ScriptGlobals));
            script.Compile();

            var globals = new ScriptGlobals();
            script.RunAsync(globals).Wait();

            runtimeCompiled = (IFactory)Activator.CreateInstance(globals.Types["RuntimeCompiledFactory"]);
        }

        [Benchmark]
        public object PreCompiled() => preCompiled.Create();

        [Benchmark]
        public object RuntimeCompiled() => runtimeCompiled.Create();
    }
}
