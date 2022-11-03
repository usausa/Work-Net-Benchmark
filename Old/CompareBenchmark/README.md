``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.402
  [Host]    : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT
  MediumRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT

Job=MediumRun  Jit=RyuJit  Platform=X64  
Runtime=.NET 6.0  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|       Method |     Mean |   Error |   StdDev |      Min |      Max |      P90 | Code Size |  Gen 0 | Allocated |
|------------- |---------:|--------:|---------:|---------:|---------:|---------:|----------:|-------:|----------:|
| ByComparable | 600.2 ns | 3.59 ns |  5.03 ns | 590.2 ns | 611.9 ns | 606.8 ns |     142 B |      - |         - |
|   ByComparer | 600.8 ns | 8.26 ns | 12.36 ns | 581.1 ns | 631.2 ns | 613.4 ns |     376 B | 0.0049 |      88 B |
|   ByDelegate | 617.2 ns | 6.15 ns |  8.82 ns | 606.2 ns | 636.3 ns | 634.2 ns |   2,014 B | 0.0029 |      64 B |
|  ByDelegate2 | 571.1 ns | 8.76 ns | 12.56 ns | 560.5 ns | 603.3 ns | 592.7 ns |   2,065 B |      - |         - |
