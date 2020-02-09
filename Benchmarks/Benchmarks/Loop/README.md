``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i5-9500 CPU 3.00GHz, 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.101
  [Host]    : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  MediumRun : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|           Method |       Mean |    Error |    StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |-----------:|---------:|----------:|-----------:|-------:|------:|------:|----------:|
|          ForList |   880.7 ns |  4.43 ns |   6.35 ns |   878.6 ns |      - |     - |     - |         - |
|         ForIList | 3,278.2 ns |  7.11 ns |  10.64 ns | 3,275.1 ns |      - |     - |     - |         - |
|         ForArray |   496.6 ns |  1.54 ns |   2.21 ns |   496.6 ns |      - |     - |     - |         - |
|        ForIArray | 3,631.7 ns | 81.41 ns | 119.33 ns | 3,733.2 ns |      - |     - |     - |         - |
|      ForEachList | 1,780.3 ns | 73.69 ns | 103.30 ns | 1,871.1 ns |      - |     - |     - |         - |
|     ForEachIList | 5,068.8 ns | 85.10 ns | 122.05 ns | 5,161.1 ns | 0.0076 |     - |     - |      40 B |
|     ForEachArray |   346.8 ns |  0.69 ns |   0.98 ns |   347.0 ns |      - |     - |     - |         - |
|    ForEachIArray | 3,295.5 ns |  6.92 ns |   9.92 ns | 3,294.9 ns | 0.0038 |     - |     - |      32 B |
|   EnumeratorList | 1,662.2 ns |  3.39 ns |   4.76 ns | 1,662.5 ns |      - |     - |     - |         - |
|  EnumeratorIList | 4,941.1 ns | 11.34 ns |  16.97 ns | 4,937.9 ns | 0.0076 |     - |     - |      40 B |
| EnumeratorIArray | 3,764.9 ns | 15.75 ns |  23.57 ns | 3,755.9 ns | 0.0038 |     - |     - |      32 B |
