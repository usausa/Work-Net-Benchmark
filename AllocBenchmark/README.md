``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.302
  [Host]    : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT
  MediumRun : .NET 6.0.7 (6.0.722.32202), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|              Method |          Mean |       Error |        StdDev |           Min |           Max |           P90 |    Gen 0 |    Gen 1 |    Gen 2 |     Allocated |
|-------------------- |--------------:|------------:|--------------:|--------------:|--------------:|--------------:|---------:|---------:|---------:|--------------:|
|        AllocManaged |    394.899 μs |   3.6820 μs |     5.3970 μs |    386.841 μs |    405.990 μs |    403.018 μs | 999.0000 | 999.0000 | 999.0000 | 102,400,395 B |
|      AllocUnmanaged |      6.945 μs |   0.2677 μs |     0.4007 μs |      6.463 μs |      7.490 μs |      7.378 μs |        - |        - |        - |             - |
|   AllocManagedCount | 57,638.475 μs | 815.0269 μs | 1,219.8939 μs | 55,458.356 μs | 60,261.578 μs | 59,591.583 μs | 888.8889 | 888.8889 | 888.8889 | 102,400,376 B |
| AllocUnmanagedCount | 63,788.396 μs | 565.4923 μs |   828.8913 μs | 62,443.988 μs | 65,711.762 μs | 64,680.522 μs |        - |        - |        - |          60 B |
