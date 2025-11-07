```

BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.7019)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method   | Job                 | Runtime   | Value    | Mean         | Error      | StdDev      | Min          | Max          | P90          | Code Size | Gen0   | Allocated |
|--------- |-------------------- |---------- |--------- |-------------:|-----------:|------------:|-------------:|-------------:|-------------:|----------:|-------:|----------:|
| **OnDemand** | **MediumRun-.NET 10.0** | **.NET 10.0** | **0**        |    **36.276 ns** |  **0.7974 ns** |   **1.1688 ns** |    **34.354 ns** |    **37.930 ns** |    **37.640 ns** |  **10,878 B** | **0.0029** |      **24 B** |
| Cached   | MediumRun-.NET 10.0 | .NET 10.0 | 0        |     7.957 ns |  0.0694 ns |   0.1039 ns |     7.794 ns |     8.216 ns |     8.065 ns |   3,523 B | 0.0029 |      24 B |
| OnDemand | MediumRun-.NET 8.0  | .NET 8.0  | 0        |    48.780 ns |  0.3821 ns |   0.5481 ns |    47.825 ns |    49.796 ns |    49.348 ns |   5,675 B | 0.0029 |      24 B |
| Cached   | MediumRun-.NET 8.0  | .NET 8.0  | 0        |     8.538 ns |  0.0749 ns |   0.1098 ns |     8.358 ns |     8.769 ns |     8.706 ns |   3,583 B | 0.0029 |      24 B |
| OnDemand | MediumRun-.NET 9.0  | .NET 9.0  | 0        |    47.087 ns |  0.3335 ns |   0.4991 ns |    46.261 ns |    48.113 ns |    47.666 ns |   5,525 B | 0.0029 |      24 B |
| Cached   | MediumRun-.NET 9.0  | .NET 9.0  | 0        |     8.970 ns |  0.1014 ns |   0.1518 ns |     8.775 ns |     9.333 ns |     9.189 ns |   3,539 B | 0.0029 |      24 B |
| **OnDemand** | **MediumRun-.NET 10.0** | **.NET 10.0** | **12345678** |    **37.215 ns** |  **0.4364 ns** |   **0.6258 ns** |    **36.181 ns** |    **38.602 ns** |    **38.028 ns** |  **10,750 B** | **0.0029** |      **24 B** |
| Cached   | MediumRun-.NET 10.0 | .NET 10.0 | 12345678 |    10.757 ns |  0.1086 ns |   0.1592 ns |    10.498 ns |    11.150 ns |    10.977 ns |   3,520 B | 0.0029 |      24 B |
| OnDemand | MediumRun-.NET 8.0  | .NET 8.0  | 12345678 |    52.312 ns |  0.4194 ns |   0.6147 ns |    51.271 ns |    53.813 ns |    53.035 ns |   5,671 B | 0.0029 |      24 B |
| Cached   | MediumRun-.NET 8.0  | .NET 8.0  | 12345678 |    12.077 ns |  0.1733 ns |   0.2540 ns |    11.697 ns |    12.532 ns |    12.349 ns |   3,585 B | 0.0029 |      24 B |
| OnDemand | MediumRun-.NET 9.0  | .NET 9.0  | 12345678 |    49.755 ns |  0.4739 ns |   0.7093 ns |    48.604 ns |    51.202 ns |    50.801 ns |   5,525 B | 0.0029 |      24 B |
| Cached   | MediumRun-.NET 9.0  | .NET 9.0  | 12345678 |    11.571 ns |  0.1123 ns |   0.1681 ns |    11.367 ns |    11.895 ns |    11.817 ns |   3,551 B | 0.0029 |      24 B |
| **OnDemand** | **MediumRun-.NET 10.0** | **.NET 10.0** | **X**        | **2,859.721 ns** | **36.5400 ns** |  **53.5598 ns** | **2,785.972 ns** | **2,996.354 ns** | **2,933.059 ns** |  **13,803 B** | **0.1016** |     **880 B** |
| Cached   | MediumRun-.NET 10.0 | .NET 10.0 | X        | 2,750.352 ns | 27.0546 ns |  40.4940 ns | 2,698.540 ns | 2,854.649 ns | 2,804.892 ns |   4,032 B | 0.1016 |     880 B |
| OnDemand | MediumRun-.NET 8.0  | .NET 8.0  | X        | 7,681.059 ns | 55.6350 ns |  83.2719 ns | 7,547.868 ns | 7,846.171 ns | 7,769.048 ns |   2,434 B | 0.1094 |     928 B |
| Cached   | MediumRun-.NET 8.0  | .NET 8.0  | X        | 7,583.010 ns | 96.6141 ns | 141.6157 ns | 7,409.706 ns | 7,839.225 ns | 7,811.390 ns |   3,702 B | 0.1094 |     928 B |
| OnDemand | MediumRun-.NET 9.0  | .NET 9.0  | X        | 4,186.873 ns | 43.5576 ns |  65.1950 ns | 4,115.786 ns | 4,326.588 ns | 4,276.205 ns |   5,604 B | 0.1016 |     880 B |
| Cached   | MediumRun-.NET 9.0  | .NET 9.0  | X        | 4,132.485 ns | 47.6197 ns |  68.2947 ns | 4,062.248 ns | 4,321.352 ns | 4,230.099 ns |   3,649 B | 0.1016 |     880 B |
