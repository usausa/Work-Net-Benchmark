REA```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]    : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method                  | Size | Mean       | Error     | StdDev     | Min        | Max        | P90        | Code Size | Allocated |
|------------------------ |----- |-----------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
| **Calc**                    | **1**    |   **1.336 ns** | **0.0511 ns** |  **0.0732 ns** |   **1.251 ns** |   **1.524 ns** |   **1.452 ns** |      **46 B** |         **-** |
| CalcByLength            | 1    |   1.375 ns | 0.0448 ns |  0.0642 ns |   1.302 ns |   1.507 ns |   1.484 ns |      97 B |         - |
| CalcByLengthReverse     | 1    |   1.314 ns | 0.0219 ns |  0.0315 ns |   1.278 ns |   1.381 ns |   1.356 ns |      87 B |         - |
| CalcByLengthWithAccess  | 1    |   1.448 ns | 0.1083 ns |  0.1518 ns |   1.265 ns |   1.713 ns |   1.631 ns |     138 B |         - |
| CalcByLengthWithAccess2 | 1    |   1.595 ns | 0.0558 ns |  0.0836 ns |   1.512 ns |   1.801 ns |   1.723 ns |     103 B |         - |
| **Calc**                    | **4**    |   **1.597 ns** | **0.0557 ns** |  **0.0781 ns** |   **1.517 ns** |   **1.832 ns** |   **1.697 ns** |      **44 B** |         **-** |
| CalcByLength            | 4    |   1.650 ns | 0.0535 ns |  0.0801 ns |   1.576 ns |   1.825 ns |   1.780 ns |     100 B |         - |
| CalcByLengthReverse     | 4    |   1.600 ns | 0.0168 ns |  0.0231 ns |   1.579 ns |   1.662 ns |   1.630 ns |      85 B |         - |
| CalcByLengthWithAccess  | 4    |   1.929 ns | 0.0666 ns |  0.0976 ns |   1.793 ns |   2.171 ns |   2.035 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 4    |   1.818 ns | 0.0620 ns |  0.0889 ns |   1.747 ns |   2.070 ns |   1.975 ns |     101 B |         - |
| **Calc**                    | **8**    |   **2.539 ns** | **0.0799 ns** |  **0.1197 ns** |   **2.419 ns** |   **2.820 ns** |   **2.693 ns** |      **44 B** |         **-** |
| CalcByLength            | 8    |   2.568 ns | 0.0829 ns |  0.1240 ns |   2.418 ns |   2.829 ns |   2.705 ns |     100 B |         - |
| CalcByLengthReverse     | 8    |   2.556 ns | 0.0852 ns |  0.1275 ns |   2.419 ns |   2.880 ns |   2.723 ns |      85 B |         - |
| CalcByLengthWithAccess  | 8    |   2.820 ns | 0.0778 ns |  0.1165 ns |   2.631 ns |   2.992 ns |   2.952 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 8    |   2.804 ns | 0.0839 ns |  0.1256 ns |   2.645 ns |   3.192 ns |   2.932 ns |     101 B |         - |
| **Calc**                    | **64**   |  **16.664 ns** | **0.4345 ns** |  **0.6504 ns** |  **15.887 ns** |  **18.459 ns** |  **17.287 ns** |      **44 B** |         **-** |
| CalcByLength            | 64   |  16.874 ns | 0.3825 ns |  0.5725 ns |  16.172 ns |  17.919 ns |  17.519 ns |     103 B |         - |
| CalcByLengthReverse     | 64   |  16.894 ns | 0.3897 ns |  0.5833 ns |  16.061 ns |  17.948 ns |  17.565 ns |     101 B |         - |
| CalcByLengthWithAccess  | 64   |  17.146 ns | 0.4246 ns |  0.6355 ns |  16.369 ns |  18.598 ns |  17.883 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 64   |  16.914 ns | 0.2987 ns |  0.4378 ns |  16.385 ns |  17.646 ns |  17.536 ns |     101 B |         - |
| **Calc**                    | **1024** | **267.107 ns** | **8.9328 ns** | **13.3701 ns** | **251.265 ns** | **291.690 ns** | **290.225 ns** |      **44 B** |         **-** |
| CalcByLength            | 1024 | 260.457 ns | 5.4836 ns |  8.2075 ns | 250.994 ns | 271.626 ns | 271.015 ns |     103 B |         - |
| CalcByLengthReverse     | 1024 | 258.798 ns | 8.1868 ns | 11.7412 ns | 247.485 ns | 285.390 ns | 275.594 ns |     101 B |         - |
| CalcByLengthWithAccess  | 1024 | 269.434 ns | 9.4628 ns | 14.1634 ns | 251.615 ns | 300.726 ns | 291.291 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 1024 | 261.378 ns | 6.3897 ns |  9.5638 ns | 251.524 ns | 281.695 ns | 273.777 ns |     101 B |         - |
