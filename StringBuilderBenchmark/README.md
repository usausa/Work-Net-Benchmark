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
| Builder            | 78.46 ns | 1.732 ns | 2.539 ns | 73.81 ns | 83.58 ns | 82.06 ns |
| BuilderPrepared    | 36.10 ns | 0.512 ns | 0.750 ns | 34.30 ns | 37.48 ns | 36.89 ns |
| Handler            | 49.19 ns | 1.389 ns | 1.992 ns | 46.48 ns | 52.36 ns | 51.30 ns |
| HandlerPrepared    | 46.09 ns | 0.542 ns | 0.760 ns | 45.11 ns | 48.05 ns | 47.09 ns |
| HandlerStack       | 27.21 ns | 0.972 ns | 1.455 ns | 25.22 ns | 30.26 ns | 29.03 ns |
| ValueStringBuilder | 27.36 ns | 0.630 ns | 0.924 ns | 25.65 ns | 29.12 ns | 28.31 ns |
| PooledBuilder      | 23.47 ns | 0.283 ns | 0.415 ns | 22.46 ns | 24.35 ns | 23.98 ns |
