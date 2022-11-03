``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.402
  [Host]   : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT
  ShortRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT

Job=ShortRun  Jit=RyuJit  Platform=X64  
Runtime=.NET 6.0  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|          Method |        Mean |       Error |     StdDev |         Min |         Max |         P90 | Code Size |  Gen 0 | Allocated |
|---------------- |------------:|------------:|-----------:|------------:|------------:|------------:|----------:|-------:|----------:|
| ByStringBuilder | 8,231.68 ns | 3,386.86 ns | 185.645 ns | 8,108.45 ns | 8,445.20 ns | 8,384.43 ns |   1,193 B | 0.0305 |     584 B |
|          BySpan |    89.69 ns |    14.11 ns |   0.773 ns |    88.97 ns |    90.51 ns |    90.33 ns |     148 B | 0.0019 |      32 B |
