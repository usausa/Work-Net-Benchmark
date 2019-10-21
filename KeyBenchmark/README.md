``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]    : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  MediumRun : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                 Method |      Mean |     Error |    StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |----------:|----------:|----------:|------:|------:|------:|----------:|
|         StructFieldKey |  14.19 ns | 0.0820 ns | 0.1202 ns |     - |     - |     - |         - |
|      StructPropertyKey |  14.46 ns | 0.2352 ns | 0.3448 ns |     - |     - |     - |         - |
|          ClassFieldKey |  14.19 ns | 0.1006 ns | 0.1411 ns |     - |     - |     - |         - |
|       ClassPropertyKey |  14.29 ns | 0.0966 ns | 0.1446 ns |     - |     - |     - |         - |
|    StructFieldMultiKey | 152.30 ns | 0.9226 ns | 1.3810 ns |     - |     - |     - |         - |
| StructPropertyMultiKey | 149.69 ns | 1.3361 ns | 1.9999 ns |     - |     - |     - |         - |
|     ClassFieldMultiKey | 145.62 ns | 2.6036 ns | 3.8163 ns |     - |     - |     - |         - |
|  ClassPropertyMultiKey | 143.16 ns | 1.1157 ns | 1.6699 ns |     - |     - |     - |         - |
