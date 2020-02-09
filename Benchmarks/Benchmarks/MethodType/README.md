``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i5-9500 CPU 3.00GHz, 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.101
  [Host]    : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  MediumRun : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                Method |      Mean |     Error |    StdDev |    Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |----------:|----------:|----------:|----------:|------:|------:|------:|----------:|
|                Direct | 0.2394 ns | 0.0005 ns | 0.0008 ns | 0.2394 ns |     - |     - |     - |         - |
|                  Func | 1.6770 ns | 0.1614 ns | 0.2262 ns | 1.8710 ns |     - |     - |     - |         - |
|                Static | 0.2397 ns | 0.0004 ns | 0.0005 ns | 0.2399 ns |     - |     - |     - |         - |
|          StaticInline | 0.2412 ns | 0.0015 ns | 0.0023 ns | 0.2406 ns |     - |     - |     - |         - |
|              Instance | 0.2981 ns | 0.0006 ns | 0.0009 ns | 0.2982 ns |     - |     - |     - |         - |
|        InstanceInline | 0.2979 ns | 0.0007 ns | 0.0010 ns | 0.2978 ns |     - |     - |     - |         - |
|            StaticFunc | 1.9929 ns | 0.0047 ns | 0.0068 ns | 1.9916 ns |     - |     - |     - |         - |
|      StaticInlineFunc | 2.0504 ns | 0.0399 ns | 0.0597 ns | 2.0504 ns |     - |     - |     - |         - |
|          InstanceFunc | 1.8812 ns | 0.0080 ns | 0.0120 ns | 1.8757 ns |     - |     - |     - |         - |
|    InstanceInlineFunc | 1.5293 ns | 0.0838 ns | 0.1175 ns | 1.6315 ns |     - |     - |     - |         - |
|             Interface | 1.6436 ns | 0.0055 ns | 0.0081 ns | 1.6422 ns |     - |     - |     - |         - |
|       InterfaceInline | 1.7551 ns | 0.0843 ns | 0.1182 ns | 1.6505 ns |     - |     - |     - |         - |
|       SealedInterface | 1.7582 ns | 0.0794 ns | 0.1188 ns | 1.7545 ns |     - |     - |     - |         - |
| SealedInterfaceInline | 1.7481 ns | 0.0823 ns | 0.1180 ns | 1.6476 ns |     - |     - |     - |         - |
