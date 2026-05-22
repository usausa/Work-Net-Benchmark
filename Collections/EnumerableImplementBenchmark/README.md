```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.6901)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method      | Job                 | Runtime   | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       | Code Size | Gen0   | Allocated |
|------------ |-------------------- |---------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| Net73Struct | MediumRun-.NET 10.0 | .NET 10.0 |  1.398 ns | 0.1450 ns | 0.2080 ns |  1.318 ns |  1.176 ns |  1.791 ns |  1.760 ns |      19 B |      - |         - |
| Struct      | MediumRun-.NET 10.0 | .NET 10.0 |  2.879 ns | 0.1300 ns | 0.1945 ns |  2.852 ns |  2.553 ns |  3.330 ns |  3.121 ns |      74 B | 0.0029 |      24 B |
| Class       | MediumRun-.NET 10.0 | .NET 10.0 |  2.922 ns | 0.1138 ns | 0.1703 ns |  2.878 ns |  2.626 ns |  3.262 ns |  3.086 ns |      74 B | 0.0029 |      24 B |
| Yield       | MediumRun-.NET 10.0 | .NET 10.0 | 14.359 ns | 0.0472 ns | 0.0706 ns | 14.355 ns | 14.168 ns | 14.494 ns | 14.465 ns |     717 B | 0.0067 |      56 B |
| Net73Struct | MediumRun-.NET 8.0  | .NET 8.0  |  2.132 ns | 0.0245 ns | 0.0359 ns |  2.151 ns |  2.036 ns |  2.169 ns |  2.158 ns |      23 B |      - |         - |
| Struct      | MediumRun-.NET 8.0  | .NET 8.0  |  3.598 ns | 0.0928 ns | 0.1360 ns |  3.504 ns |  3.448 ns |  3.845 ns |  3.814 ns |      73 B | 0.0029 |      24 B |
| Class       | MediumRun-.NET 8.0  | .NET 8.0  |  3.638 ns | 0.0325 ns | 0.0455 ns |  3.646 ns |  3.485 ns |  3.702 ns |  3.669 ns |      73 B | 0.0029 |      24 B |
| Yield       | MediumRun-.NET 8.0  | .NET 8.0  | 12.840 ns | 0.0550 ns | 0.0788 ns | 12.844 ns | 12.639 ns | 13.016 ns | 12.915 ns |     737 B | 0.0067 |      56 B |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]    : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  
```
| Method      | Mean      | Error     | StdDev    | Min       | Max       | P90       | Code Size | Gen0   | Allocated |
|------------ |----------:|----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| Net73Struct |  2.593 ns | 0.0303 ns | 0.0444 ns |  2.525 ns |  2.698 ns |  2.646 ns |      19 B |      - |         - |
| Struct      |  4.366 ns | 0.0393 ns | 0.0551 ns |  4.261 ns |  4.518 ns |  4.426 ns |      72 B | 0.0014 |      24 B |
| Class       |  4.623 ns | 0.1442 ns | 0.2068 ns |  4.247 ns |  4.916 ns |  4.846 ns |      72 B | 0.0014 |      24 B |
| Yield       | 26.647 ns | 0.1985 ns | 0.2717 ns | 26.264 ns | 27.406 ns | 27.033 ns |     560 B | 0.0033 |      56 B |
