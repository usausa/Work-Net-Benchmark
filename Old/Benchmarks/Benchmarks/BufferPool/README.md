``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i5-9500 CPU 3.00GHz, 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.101
  [Host]    : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  MediumRun : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                 Method |      Mean |     Error |    StdDev |    Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
|              AlwaysNew |  4.922 ns | 0.0776 ns | 0.1162 ns |  4.906 ns | 0.0119 |     - |     - |      56 B |
|           UseArrayPool | 24.221 ns | 1.8940 ns | 2.7762 ns | 21.676 ns |      - |     - |     - |         - |
|         UseThreadLocal |  4.527 ns | 0.0462 ns | 0.0663 ns |  4.529 ns |      - |     - |     - |         - |
|      AlwaysNewStandard |  4.910 ns | 0.0258 ns | 0.0371 ns |  4.908 ns | 0.0119 |     - |     - |      56 B |
|   UseArrayPoolStandard | 21.411 ns | 0.0504 ns | 0.0724 ns | 21.402 ns |      - |     - |     - |         - |
| UseThreadLocalStandard |  4.770 ns | 0.0676 ns | 0.1013 ns |  4.778 ns |      - |     - |     - |         - |
