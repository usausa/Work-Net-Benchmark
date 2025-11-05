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
| Method               | Job                 | Runtime   | Mean     | Error    | StdDev   | Min      | Max      | P90      | Ratio | RatioSD |
|--------------------- |-------------------- |---------- |---------:|---------:|---------:|---------:|---------:|---------:|------:|--------:|
| Format               | MediumRun-.NET 10.0 | .NET 10.0 | 31.74 ns | 0.498 ns | 0.730 ns | 30.72 ns | 33.34 ns | 32.82 ns |  1.00 |    0.03 |
| FormatByUtfFormatter | MediumRun-.NET 10.0 | .NET 10.0 | 23.01 ns | 0.185 ns | 0.277 ns | 22.67 ns | 23.71 ns | 23.45 ns |  0.73 |    0.02 |
| FormatCustom         | MediumRun-.NET 10.0 | .NET 10.0 | 13.79 ns | 0.074 ns | 0.111 ns | 13.62 ns | 14.05 ns | 13.90 ns |  0.43 |    0.01 |
| FormatCustom2        | MediumRun-.NET 10.0 | .NET 10.0 | 10.87 ns | 0.102 ns | 0.152 ns | 10.67 ns | 11.18 ns | 11.11 ns |  0.34 |    0.01 |
|                      |                     |           |          |          |          |          |          |          |       |         |
| Format               | MediumRun-.NET 8.0  | .NET 8.0  | 39.86 ns | 0.428 ns | 0.641 ns | 39.03 ns | 41.15 ns | 40.88 ns |  1.00 |    0.02 |
| FormatByUtfFormatter | MediumRun-.NET 8.0  | .NET 8.0  | 25.21 ns | 0.193 ns | 0.265 ns | 24.91 ns | 25.96 ns | 25.50 ns |  0.63 |    0.01 |
| FormatCustom         | MediumRun-.NET 8.0  | .NET 8.0  | 14.18 ns | 0.056 ns | 0.082 ns | 14.05 ns | 14.32 ns | 14.31 ns |  0.36 |    0.01 |
| FormatCustom2        | MediumRun-.NET 8.0  | .NET 8.0  | 10.89 ns | 0.066 ns | 0.099 ns | 10.73 ns | 11.09 ns | 11.02 ns |  0.27 |    0.00 |
|                      |                     |           |          |          |          |          |          |          |       |         |
| Format               | MediumRun-.NET 9.0  | .NET 9.0  | 38.10 ns | 0.474 ns | 0.709 ns | 37.19 ns | 40.30 ns | 38.98 ns |  1.00 |    0.03 |
| FormatByUtfFormatter | MediumRun-.NET 9.0  | .NET 9.0  | 23.90 ns | 0.120 ns | 0.173 ns | 23.64 ns | 24.36 ns | 24.12 ns |  0.63 |    0.01 |
| FormatCustom         | MediumRun-.NET 9.0  | .NET 9.0  | 13.78 ns | 0.085 ns | 0.121 ns | 13.62 ns | 14.11 ns | 13.90 ns |  0.36 |    0.01 |
| FormatCustom2        | MediumRun-.NET 9.0  | .NET 9.0  | 10.53 ns | 0.050 ns | 0.073 ns | 10.38 ns | 10.67 ns | 10.61 ns |  0.28 |    0.01 |

```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.100-rc.1.23463.5
  [Host]   : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2

```
|               Method |      Job |  Runtime |      Mean |    Error |   StdDev |       Min |       Max |       P90 | Ratio | RatioSD |
|--------------------- |--------- |--------- |----------:|---------:|---------:|----------:|----------:|----------:|------:|--------:|
|               Format | .NET 8.0 | .NET 8.0 |  58.38 ns | 0.610 ns | 0.571 ns |  57.51 ns |  59.57 ns |  59.12 ns |  1.00 |    0.00 |
| FormatByUtfFormatter | .NET 8.0 | .NET 8.0 |  34.68 ns | 0.681 ns | 0.669 ns |  34.07 ns |  36.39 ns |  35.38 ns |  0.59 |    0.01 |
|         FormatCustom | .NET 8.0 | .NET 8.0 |  20.01 ns | 0.233 ns | 0.218 ns |  19.77 ns |  20.38 ns |  20.31 ns |  0.34 |    0.00 |
|        FormatCustom2 | .NET 8.0 | .NET 8.0 |  15.21 ns | 0.159 ns | 0.141 ns |  15.03 ns |  15.42 ns |  15.39 ns |  0.26 |    0.00 |
