```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3775)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.201
  [Host]    : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method            | Size | Mean      | Error     | StdDev    | Median    | Min      | Max       | P90       | Code Size | Gen0   | Allocated |
|------------------ |----- |----------:|----------:|----------:|----------:|---------:|----------:|----------:|----------:|-------:|----------:|
| **Class**             | **4**    |  **18.02 ns** |  **0.522 ns** |  **0.781 ns** |  **17.90 ns** | **16.84 ns** |  **19.57 ns** |  **19.06 ns** |     **420 B** | **0.0110** |     **184 B** |
| PooledClassPooled | 4    |  36.43 ns |  3.610 ns |  5.404 ns |  36.73 ns | 30.09 ns |  44.73 ns |  42.87 ns |   2,796 B | 0.0076 |     128 B |
| PooledStruct      | 4    |  15.63 ns |  0.341 ns |  0.500 ns |  15.67 ns | 14.54 ns |  16.35 ns |  16.17 ns |   3,814 B |      - |         - |
| **Class**             | **8**    |  **34.93 ns** |  **1.077 ns** |  **1.612 ns** |  **34.74 ns** | **32.54 ns** |  **37.30 ns** |  **37.15 ns** |     **420 B** | **0.0206** |     **344 B** |
| PooledClassPooled | 8    |  55.07 ns |  1.304 ns |  1.911 ns |  54.64 ns | 52.24 ns |  59.06 ns |  58.11 ns |   2,799 B | 0.0153 |     256 B |
| PooledStruct      | 8    |  17.31 ns |  0.523 ns |  0.782 ns |  17.50 ns | 16.24 ns |  18.63 ns |  18.35 ns |   3,852 B |      - |         - |
| **Class**             | **16**   |  **68.25 ns** |  **2.478 ns** |  **3.709 ns** |  **68.23 ns** | **62.13 ns** |  **74.45 ns** |  **73.31 ns** |     **420 B** | **0.0396** |     **664 B** |
| PooledClassPooled | 16   | 122.21 ns | 13.529 ns | 19.831 ns | 110.26 ns | 98.07 ns | 150.89 ns | 144.28 ns |   2,799 B | 0.0305 |     512 B |
| PooledStruct      | 16   |  19.35 ns |  0.408 ns |  0.599 ns |  19.31 ns | 18.55 ns |  20.86 ns |  20.23 ns |   3,809 B |      - |         - |
