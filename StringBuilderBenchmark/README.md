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
|     DefaultStringBuilder | 56.49 ns | 0.383 ns | 0.574 ns | 55.26 ns | 57.41 ns | 57.28 ns |  1.00 | 0.0602 | 0.0002 |     - |   1,008 B |
|      PooledStringBuilder | 34.59 ns | 0.219 ns | 0.321 ns | 34.16 ns | 35.55 ns | 35.04 ns |  0.61 | 0.0253 |      - |     - |     424 B |
|     PooledStringBuilder2 | 34.53 ns | 0.119 ns | 0.174 ns | 34.34 ns | 34.97 ns | 34.80 ns |  0.61 | 0.0253 |      - |     - |     424 B |
|     PooledStringBuilder3 | 34.37 ns | 0.182 ns | 0.273 ns | 33.92 ns | 34.89 ns | 34.81 ns |  0.61 | 0.0253 |      - |     - |     424 B |
| ValueStringBuilderSimple | 34.72 ns | 0.176 ns | 0.264 ns | 34.42 ns | 35.39 ns | 35.14 ns |  0.61 | 0.0253 |      - |     - |     424 B |
