``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.400
  [Host]    : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  MediumRun : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|          Method |      Mean |     Error |    StdDev |       Min |       Max |       P90 | Allocated |
|---------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| InvokerCallVirt | 0.2147 ns | 0.0004 ns | 0.0006 ns | 0.2138 ns | 0.2162 ns | 0.2154 ns |         - |
|     InvokerCall | 0.2139 ns | 0.0003 ns | 0.0004 ns | 0.2134 ns | 0.2149 ns | 0.2144 ns |         - |
