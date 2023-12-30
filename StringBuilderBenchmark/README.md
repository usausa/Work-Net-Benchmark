```

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2715/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.100
  [Host]    : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method             | Mean     | Error    | StdDev   | Min      | Max      | P90      |
|------------------- |---------:|---------:|---------:|---------:|---------:|---------:|
| Builder            | 84.54 ns | 4.329 ns | 6.479 ns | 75.06 ns | 98.47 ns | 92.88 ns |
| BuilderPrepared    | 35.37 ns | 0.530 ns | 0.759 ns | 33.62 ns | 36.83 ns | 36.41 ns |
| Handler            | 47.57 ns | 0.325 ns | 0.445 ns | 46.75 ns | 49.01 ns | 47.94 ns |
| HandlerPrepared    | 26.35 ns | 1.017 ns | 1.459 ns | 24.41 ns | 28.81 ns | 28.15 ns |
| ValueStringBuilder | 28.09 ns | 0.469 ns | 0.672 ns | 26.99 ns | 29.91 ns | 29.01 ns |
| PooledBuilder      | 23.93 ns | 0.251 ns | 0.352 ns | 23.05 ns | 24.87 ns | 24.30 ns |
