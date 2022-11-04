``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.675)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.402
  [Host]    : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  MediumRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Job=MediumRun  Jit=RyuJit  Platform=X64  
Runtime=.NET 6.0  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|     Method |     Mean |     Error |    StdDev |   Median |      Min |      Max |      P90 | Code Size | Allocated |
|----------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|----------:|----------:|
|  Interface | 1.481 ns | 0.1214 ns | 0.1741 ns | 1.535 ns | 1.295 ns | 1.733 ns | 1.695 ns |      48 B |         - |
|   Abstract | 1.192 ns | 0.0752 ns | 0.1102 ns | 1.111 ns | 1.077 ns | 1.319 ns | 1.308 ns |      44 B |         - |
|       Func | 1.311 ns | 0.0072 ns | 0.0101 ns | 1.309 ns | 1.297 ns | 1.340 ns | 1.324 ns |      39 B |         - |
| Interface4 | 5.681 ns | 0.0245 ns | 0.0351 ns | 5.676 ns | 5.630 ns | 5.750 ns | 5.727 ns |      48 B |         - |
|  Abstract4 | 4.825 ns | 0.0654 ns | 0.0959 ns | 4.799 ns | 4.743 ns | 5.109 ns | 5.029 ns |      44 B |         - |
|      Func4 | 5.854 ns | 0.2064 ns | 0.2960 ns | 5.677 ns | 5.602 ns | 6.574 ns | 6.259 ns |      39 B |         - |
