REA```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.201
  [Host]    : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method      | Mean     | Error    | StdDev   | Min      | Max      | P90      | Code Size | Allocated |
|------------ |---------:|---------:|---------:|---------:|---------:|---------:|----------:|----------:|
| ByStructRef | 257.7 μs |  6.79 μs | 10.16 μs | 243.4 μs | 285.5 μs | 268.8 μs |     244 B |     216 B |
| ByClass     | 397.9 μs | 17.87 μs | 26.20 μs | 367.9 μs | 453.8 μs | 441.4 μs |     272 B |     408 B |
