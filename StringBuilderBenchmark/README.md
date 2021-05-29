``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.300
  [Host]    : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  MediumRun : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                   Method |     Mean |    Error |   StdDev |      Min |      Max |      P90 | Ratio |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |---------:|---------:|---------:|---------:|---------:|---------:|------:|-------:|-------:|------:|----------:|
|     DefaultStringBuilder | 55.56 ns | 0.322 ns | 0.471 ns | 54.78 ns | 56.26 ns | 56.01 ns |  1.00 | 0.0602 | 0.0002 |     - |   1,008 B |
|      PooledStringBuilder | 34.81 ns | 0.250 ns | 0.358 ns | 34.15 ns | 35.32 ns | 35.22 ns |  0.63 | 0.0253 |      - |     - |     424 B |
|     PooledStringBuilder2 | 34.39 ns | 0.207 ns | 0.310 ns | 34.02 ns | 35.24 ns | 34.87 ns |  0.62 | 0.0253 |      - |     - |     424 B |
| ValueStringBuilderSimple | 34.76 ns | 0.204 ns | 0.305 ns | 34.31 ns | 35.33 ns | 35.23 ns |  0.63 | 0.0253 |      - |     - |     424 B |
