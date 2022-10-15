``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.17763.1282 (1809/October2018Update/Redstone5)
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]  : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  LongRun : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=LongRun  IterationCount=100  LaunchCount=3  
WarmupCount=15  

```
|               Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |---------:|----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|               Direct | 3.762 ns | 0.0197 ns | 0.0992 ns | 3.769 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
|     CallStaticInline | 3.759 ns | 0.0186 ns | 0.0943 ns | 3.753 ns |  1.00 |    0.04 | 0.0057 |     - |     - |      24 B |
|   CallStaticNoInline | 5.318 ns | 0.0334 ns | 0.1685 ns | 5.297 ns |  1.41 |    0.05 | 0.0057 |     - |     - |      24 B |
|   CallInstanceInline | 3.879 ns | 0.0197 ns | 0.1003 ns | 3.877 ns |  1.03 |    0.04 | 0.0057 |     - |     - |      24 B |
| CallInstanceNoInline | 5.287 ns | 0.0240 ns | 0.1232 ns | 5.293 ns |  1.41 |    0.05 | 0.0057 |     - |     - |      24 B |
|            Interface | 6.195 ns | 0.0281 ns | 0.1414 ns | 6.201 ns |  1.65 |    0.06 | 0.0057 |     - |     - |      24 B |
|      InterfaceSealed | 6.196 ns | 0.0307 ns | 0.1563 ns | 6.188 ns |  1.65 |    0.06 | 0.0057 |     - |     - |      24 B |
|       DelegateDirect | 5.465 ns | 0.0248 ns | 0.1280 ns | 5.471 ns |  1.45 |    0.05 | 0.0057 |     - |     - |      24 B |
|       DelegateStatic | 6.409 ns | 0.0276 ns | 0.1405 ns | 6.419 ns |  1.70 |    0.06 | 0.0057 |     - |     - |      24 B |
|     DelegateInstance | 5.498 ns | 0.0232 ns | 0.1180 ns | 5.512 ns |  1.46 |    0.05 | 0.0057 |     - |     - |      24 B |
|    DelegateInterface | 5.575 ns | 0.0378 ns | 0.1938 ns | 5.540 ns |  1.48 |    0.07 | 0.0057 |     - |     - |      24 B |
|           EmitStatic | 6.236 ns | 0.0246 ns | 0.1241 ns | 6.238 ns |  1.66 |    0.06 | 0.0057 |     - |     - |      24 B |
|         EmitInstance | 5.279 ns | 0.0258 ns | 0.1317 ns | 5.286 ns |  1.40 |    0.05 | 0.0057 |     - |     - |      24 B |
|        PointerStatic | 5.479 ns | 0.0217 ns | 0.1096 ns | 5.490 ns |  1.46 |    0.05 | 0.0057 |     - |     - |      24 B |
