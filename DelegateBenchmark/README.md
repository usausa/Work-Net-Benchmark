``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.301
  [Host]    : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT
  MediumRun : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                       Method |     Mean |     Error |    StdDev |      Min |      Max |      P90 | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |---------:|----------:|----------:|---------:|---------:|---------:|------:|------:|------:|------:|----------:|
|               StaticDelegate | 1.302 ns | 0.0015 ns | 0.0021 ns | 1.300 ns | 1.307 ns | 1.306 ns |  1.00 |     - |     - |     - |         - |
|             InstanceDelegate | 1.083 ns | 0.0056 ns | 0.0081 ns | 1.077 ns | 1.105 ns | 1.094 ns |  0.83 |     - |     - |     - |         - |
|              FunctionPointer | 1.287 ns | 0.0030 ns | 0.0044 ns | 1.282 ns | 1.299 ns | 1.294 ns |  0.99 |     - |     - |     - |         - |
| DynamicMethodFunctionPointer | 1.075 ns | 0.0015 ns | 0.0021 ns | 1.072 ns | 1.080 ns | 1.078 ns |  0.83 |     - |     - |     - |         - |
