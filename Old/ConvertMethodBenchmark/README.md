``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.401
  [Host]    : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  MediumRun : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|     Method |     Mean |     Error |    StdDev |      Min |      Max |      P90 | Allocated |
|----------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|
|     Direct | 1.073 μs | 0.0008 μs | 0.0011 μs | 1.071 μs | 1.075 μs | 1.074 μs |         - |
|     Method | 1.072 μs | 0.0011 μs | 0.0017 μs | 1.068 μs | 1.075 μs | 1.074 μs |         - |
| Expression | 1.072 μs | 0.0016 μs | 0.0024 μs | 1.067 μs | 1.075 μs | 1.075 μs |         - |
