``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.201
  [Host]    : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  MediumRun : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|   Method |      Mean |     Error |    StdDev |       Min |       Max |       P90 |  Gen 0 | Allocated |
|--------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
|  Default | 3.0324 ns | 0.0138 ns | 0.0203 ns | 2.9814 ns | 3.0716 ns | 3.0585 ns | 0.0014 |      24 B |
|   Struct | 0.2206 ns | 0.0007 ns | 0.0011 ns | 0.2191 ns | 0.2232 ns | 0.2220 ns |      - |         - |
