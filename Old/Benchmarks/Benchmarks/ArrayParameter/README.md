``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i5-9500 CPU 3.00GHz, 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.200
  [Host]    : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  MediumRun : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|           Method |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
|              New | 52.09 ns | 0.165 ns | 0.237 ns | 0.0187 |     - |     - |      88 B |
|  ThreadLocalPool | 49.47 ns | 0.160 ns | 0.235 ns |      - |     - |     - |         - |
| ThreadLocalPool2 | 47.90 ns | 0.090 ns | 0.132 ns |      - |     - |     - |         - |
