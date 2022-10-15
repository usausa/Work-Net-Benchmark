``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.101
  [Host]    : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  MediumRun : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method |     Mean |     Error |    StdDev |      Min |      Max |      P90 |  Gen 0 |  Gen 1 | Allocated |
|------- |---------:|----------:|----------:|---------:|---------:|---------:|-------:|-------:|----------:|
| Single | 1.498 μs | 0.0755 μs | 0.1130 μs | 1.307 μs | 1.696 μs | 1.629 μs | 0.3796 | 0.0935 |      6 KB |
| Multi8 | 2.044 μs | 0.0990 μs | 0.1482 μs | 1.820 μs | 2.289 μs | 2.223 μs | 0.4692 | 0.1163 |      8 KB |
