``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.755)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.402
  [Host]    : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  MediumRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Job=MediumRun  Jit=RyuJit  Platform=X64  
Runtime=.NET 6.0  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|  Method |  Size |      Mean |     Error |    StdDev |    Median |       Min |       Max |       P90 | Code Size | Allocated |
|-------- |------ |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| **ByArray** |    **10** |  **5.754 ns** | **0.0366 ns** | **0.0536 ns** |  **5.740 ns** |  **5.689 ns** |  **5.868 ns** |  **5.819 ns** |     **201 B** |         **-** |
|  BySpan |    10 |  2.561 ns | 0.0092 ns | 0.0137 ns |  2.559 ns |  2.543 ns |  2.584 ns |  2.581 ns |     132 B |         - |
| **ByArray** |   **100** | **15.221 ns** | **0.3332 ns** | **0.4779 ns** | **15.283 ns** | **14.292 ns** | **16.009 ns** | **15.838 ns** |     **201 B** |         **-** |
|  BySpan |   100 | 10.646 ns | 0.4171 ns | 0.6113 ns | 11.172 ns |  9.916 ns | 11.277 ns | 11.257 ns |     132 B |         - |
| **ByArray** |  **1000** | **19.983 ns** | **0.3234 ns** | **0.4841 ns** | **20.098 ns** | **19.068 ns** | **21.046 ns** | **20.493 ns** |     **201 B** |         **-** |
|  BySpan |  1000 | 15.042 ns | 0.7804 ns | 1.1439 ns | 14.125 ns | 13.811 ns | 16.436 ns | 16.286 ns |     132 B |         - |
| **ByArray** | **10000** | **20.300 ns** | **0.7969 ns** | **1.1680 ns** | **21.375 ns** | **19.042 ns** | **21.452 ns** | **21.428 ns** |     **201 B** |         **-** |
|  BySpan | 10000 | 13.814 ns | 0.0200 ns | 0.0286 ns | 13.813 ns | 13.765 ns | 13.889 ns | 13.841 ns |     132 B |         - |
