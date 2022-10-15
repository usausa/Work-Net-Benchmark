``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.101
  [Host]    : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  MediumRun : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|   Method |      Mean |     Error |    StdDev |       Min |       Max |       P90 |  Gen 0 | Allocated |
|--------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
|  Default | 15.182 ns | 0.0970 ns | 0.1422 ns | 14.936 ns | 15.501 ns | 15.343 ns | 0.0014 |      24 B |
| Delegate |  7.946 ns | 0.0395 ns | 0.0592 ns |  7.865 ns |  8.041 ns |  8.025 ns |      - |         - |
