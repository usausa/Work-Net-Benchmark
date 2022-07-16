``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.302
  [Host]    : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT
  MediumRun : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method |     Mean |    Error |   StdDev |      Min |      Max |      P90 | Allocated |
|------- |---------:|---------:|---------:|---------:|---------:|---------:|----------:|
|  Sort1 | 15.86 ns | 0.137 ns | 0.196 ns | 15.67 ns | 16.54 ns | 16.09 ns |         - |
|  Sort2 | 16.02 ns | 0.029 ns | 0.041 ns | 15.92 ns | 16.09 ns | 16.07 ns |         - |
|  Sort3 | 14.38 ns | 0.070 ns | 0.100 ns | 14.22 ns | 14.53 ns | 14.51 ns |         - |
|  Sort4 | 14.24 ns | 0.027 ns | 0.036 ns | 14.19 ns | 14.34 ns | 14.27 ns |         - |
