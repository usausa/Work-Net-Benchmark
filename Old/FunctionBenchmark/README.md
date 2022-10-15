``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=5.0.101
  [Host]    : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  MediumRun : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|          Method |      Mean |     Error |    StdDev |       Min |       Max |       P90 | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |----------:|----------:|----------:|----------:|----------:|----------:|------:|------:|------:|----------:|
|          Static | 0.8061 ns | 0.0121 ns | 0.0166 ns | 0.7851 ns | 0.8382 ns | 0.8280 ns |     - |     - |     - |         - |
|        Instance | 0.5938 ns | 0.0047 ns | 0.0071 ns | 0.5809 ns | 0.6088 ns | 0.6019 ns |     - |     - |     - |         - |
|   DynamicStatic | 1.0565 ns | 0.0139 ns | 0.0185 ns | 1.0341 ns | 1.0985 ns | 1.0896 ns |     - |     - |     - |         - |
| DynamicInstance | 0.6236 ns | 0.0141 ns | 0.0197 ns | 0.5965 ns | 0.6784 ns | 0.6455 ns |     - |     - |     - |         - |
|         Pointer | 0.6054 ns | 0.0126 ns | 0.0173 ns | 0.5829 ns | 0.6335 ns | 0.6267 ns |     - |     - |     - |         - |
