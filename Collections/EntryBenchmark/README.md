```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.6901)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method            | Job                 | Runtime   | Size | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       | Code Size | Gen0   | Gen1   | Allocated |
|------------------ |-------------------- |---------- |----- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|-------:|-------:|----------:|
| **Class**             | **MediumRun-.NET 10.0** | **.NET 10.0** | **4**    | **13.836 ns** | **0.1477 ns** | **0.2165 ns** | **13.753 ns** | **13.554 ns** | **14.263 ns** | **14.202 ns** |     **396 B** | **0.0220** |      **-** |     **184 B** |
| PooledClassPooled | MediumRun-.NET 10.0 | .NET 10.0 | 4    | 16.936 ns | 0.2954 ns | 0.4236 ns | 16.731 ns | 16.472 ns | 18.034 ns | 17.522 ns |   3,175 B | 0.0153 |      - |     128 B |
| PooledStruct      | MediumRun-.NET 10.0 | .NET 10.0 | 4    | 10.243 ns | 0.4596 ns | 0.6591 ns | 10.763 ns |  9.433 ns | 10.914 ns | 10.903 ns |   7,422 B |      - |      - |         - |
| Class             | MediumRun-.NET 8.0  | .NET 8.0  | 4    | 18.213 ns | 0.1720 ns | 0.2521 ns | 18.163 ns | 17.740 ns | 18.835 ns | 18.474 ns |     160 B | 0.0249 |      - |     208 B |
| PooledClassPooled | MediumRun-.NET 8.0  | .NET 8.0  | 4    | 31.661 ns | 0.5556 ns | 0.8317 ns | 31.603 ns | 30.239 ns | 33.652 ns | 32.791 ns |   2,262 B | 0.0181 |      - |     152 B |
| PooledStruct      | MediumRun-.NET 8.0  | .NET 8.0  | 4    | 26.950 ns | 0.3395 ns | 0.4977 ns | 26.874 ns | 26.317 ns | 28.259 ns | 27.565 ns |   3,503 B | 0.0029 |      - |      24 B |
| Class             | MediumRun-.NET 9.0  | .NET 9.0  | 4    | 13.945 ns | 0.1124 ns | 0.1648 ns | 13.889 ns | 13.686 ns | 14.440 ns | 14.158 ns |     420 B | 0.0220 |      - |     184 B |
| PooledClassPooled | MediumRun-.NET 9.0  | .NET 9.0  | 4    | 19.080 ns | 0.5926 ns | 0.8499 ns | 19.177 ns | 17.655 ns | 21.203 ns | 20.146 ns |   2,707 B | 0.0153 |      - |     128 B |
| PooledStruct      | MediumRun-.NET 9.0  | .NET 9.0  | 4    |  9.433 ns | 0.0658 ns | 0.0984 ns |  9.424 ns |  9.268 ns |  9.646 ns |  9.554 ns |   3,215 B |      - |      - |         - |
| **Class**             | **MediumRun-.NET 10.0** | **.NET 10.0** | **8**    | **26.717 ns** | **0.2983 ns** | **0.4182 ns** | **26.628 ns** | **26.286 ns** | **28.149 ns** | **27.082 ns** |     **396 B** | **0.0411** | **0.0000** |     **344 B** |
| PooledClassPooled | MediumRun-.NET 10.0 | .NET 10.0 | 8    | 33.259 ns | 0.5647 ns | 0.8278 ns | 33.216 ns | 31.702 ns | 35.060 ns | 34.275 ns |   3,232 B | 0.0306 |      - |     256 B |
| PooledStruct      | MediumRun-.NET 10.0 | .NET 10.0 | 8    | 10.050 ns | 0.0625 ns | 0.0916 ns | 10.037 ns |  9.915 ns | 10.211 ns | 10.197 ns |   7,422 B |      - |      - |         - |
| Class             | MediumRun-.NET 8.0  | .NET 8.0  | 8    | 35.525 ns | 0.4451 ns | 0.6239 ns | 35.487 ns | 34.376 ns | 37.181 ns | 36.089 ns |     160 B | 0.0440 | 0.0001 |     368 B |
| PooledClassPooled | MediumRun-.NET 8.0  | .NET 8.0  | 8    | 50.293 ns | 0.5785 ns | 0.8659 ns | 50.187 ns | 48.824 ns | 51.768 ns | 51.398 ns |   2,262 B | 0.0334 |      - |     280 B |
| PooledStruct      | MediumRun-.NET 8.0  | .NET 8.0  | 8    | 31.395 ns | 0.9961 ns | 1.4601 ns | 30.766 ns | 30.297 ns | 36.000 ns | 32.923 ns |   3,465 B | 0.0029 |      - |      24 B |
| Class             | MediumRun-.NET 9.0  | .NET 9.0  | 8    | 26.508 ns | 0.2278 ns | 0.3194 ns | 26.502 ns | 26.058 ns | 27.279 ns | 26.992 ns |     420 B | 0.0411 | 0.0000 |     344 B |
| PooledClassPooled | MediumRun-.NET 9.0  | .NET 9.0  | 8    | 32.432 ns | 0.5170 ns | 0.7415 ns | 32.704 ns | 31.240 ns | 33.587 ns | 33.201 ns |   2,707 B | 0.0306 |      - |     256 B |
| PooledStruct      | MediumRun-.NET 9.0  | .NET 9.0  | 8    |  9.708 ns | 0.0786 ns | 0.1127 ns |  9.661 ns |  9.598 ns |  9.968 ns |  9.896 ns |   3,241 B |      - |      - |         - |
| **Class**             | **MediumRun-.NET 10.0** | **.NET 10.0** | **16**   | **63.583 ns** | **0.9599 ns** | **1.4071 ns** | **63.782 ns** | **59.720 ns** | **65.773 ns** | **64.912 ns** |     **396 B** | **0.0793** | **0.0001** |     **664 B** |
| PooledClassPooled | MediumRun-.NET 10.0 | .NET 10.0 | 16   | 68.052 ns | 0.7448 ns | 1.1148 ns | 67.696 ns | 65.862 ns | 70.484 ns | 69.581 ns |   3,232 B | 0.0612 |      - |     512 B |
| PooledStruct      | MediumRun-.NET 10.0 | .NET 10.0 | 16   |  9.769 ns | 0.0903 ns | 0.1351 ns |  9.727 ns |  9.574 ns | 10.036 ns |  9.958 ns |   7,451 B |      - |      - |         - |
| Class             | MediumRun-.NET 8.0  | .NET 8.0  | 16   | 78.942 ns | 1.3614 ns | 1.9524 ns | 78.837 ns | 75.441 ns | 82.821 ns | 81.215 ns |     160 B | 0.0823 | 0.0001 |     688 B |
| PooledClassPooled | MediumRun-.NET 8.0  | .NET 8.0  | 16   | 94.318 ns | 0.9312 ns | 1.2747 ns | 94.397 ns | 91.853 ns | 97.050 ns | 96.153 ns |   2,268 B | 0.0640 |      - |     536 B |
| PooledStruct      | MediumRun-.NET 8.0  | .NET 8.0  | 16   | 41.180 ns | 0.3327 ns | 0.4980 ns | 41.151 ns | 40.174 ns | 42.186 ns | 41.787 ns |   3,503 B | 0.0029 |      - |      24 B |
| Class             | MediumRun-.NET 9.0  | .NET 9.0  | 16   | 54.511 ns | 0.8108 ns | 1.1366 ns | 54.507 ns | 51.240 ns | 56.811 ns | 55.408 ns |     420 B | 0.0793 | 0.0002 |     664 B |
| PooledClassPooled | MediumRun-.NET 9.0  | .NET 9.0  | 16   | 69.115 ns | 2.3117 ns | 3.3884 ns | 69.207 ns | 63.013 ns | 74.245 ns | 73.024 ns |   2,710 B | 0.0612 |      - |     512 B |
| PooledStruct      | MediumRun-.NET 9.0  | .NET 9.0  | 16   | 12.207 ns | 0.1216 ns | 0.1704 ns | 12.189 ns | 11.933 ns | 12.548 ns | 12.394 ns |   3,218 B |      - |      - |         - |

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
