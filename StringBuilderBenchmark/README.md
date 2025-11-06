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
| Method             | Job                 | Runtime   | Mean     | Error    | StdDev   | Median   | Min      | Max      | P90      |
|------------------- |-------------------- |---------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|
| Builder            | MediumRun-.NET 10.0 | .NET 10.0 | 53.42 ns | 0.730 ns | 1.047 ns | 53.44 ns | 50.85 ns | 55.48 ns | 54.52 ns |
| BuilderPrepared    | MediumRun-.NET 10.0 | .NET 10.0 | 19.72 ns | 0.413 ns | 0.606 ns | 19.70 ns | 17.84 ns | 20.92 ns | 20.36 ns |
| Handler            | MediumRun-.NET 10.0 | .NET 10.0 | 18.04 ns | 0.156 ns | 0.233 ns | 18.00 ns | 17.64 ns | 18.45 ns | 18.33 ns |
| HandlerPrepared    | MediumRun-.NET 10.0 | .NET 10.0 | 17.93 ns | 0.226 ns | 0.338 ns | 17.96 ns | 17.36 ns | 18.44 ns | 18.39 ns |
| HandlerStack       | MediumRun-.NET 10.0 | .NET 10.0 | 13.72 ns | 0.347 ns | 0.520 ns | 13.75 ns | 12.66 ns | 14.70 ns | 14.48 ns |
| ValueStringBuilder | MediumRun-.NET 10.0 | .NET 10.0 | 13.40 ns | 0.217 ns | 0.311 ns | 13.40 ns | 12.50 ns | 13.98 ns | 13.74 ns |
| PooledBuilder      | MediumRun-.NET 10.0 | .NET 10.0 | 13.24 ns | 0.135 ns | 0.199 ns | 13.21 ns | 12.95 ns | 13.65 ns | 13.50 ns |
| Builder            | MediumRun-.NET 8.0  | .NET 8.0  | 56.75 ns | 0.675 ns | 0.969 ns | 56.84 ns | 54.09 ns | 58.40 ns | 57.80 ns |
| BuilderPrepared    | MediumRun-.NET 8.0  | .NET 8.0  | 20.21 ns | 0.479 ns | 0.703 ns | 20.28 ns | 18.19 ns | 21.70 ns | 20.92 ns |
| Handler            | MediumRun-.NET 8.0  | .NET 8.0  | 31.45 ns | 0.711 ns | 1.064 ns | 31.63 ns | 29.14 ns | 33.03 ns | 32.67 ns |
| HandlerPrepared    | MediumRun-.NET 8.0  | .NET 8.0  | 29.44 ns | 0.337 ns | 0.495 ns | 29.47 ns | 28.48 ns | 30.42 ns | 30.06 ns |
| HandlerStack       | MediumRun-.NET 8.0  | .NET 8.0  | 16.67 ns | 2.123 ns | 3.111 ns | 14.08 ns | 13.44 ns | 20.08 ns | 19.97 ns |
| ValueStringBuilder | MediumRun-.NET 8.0  | .NET 8.0  | 13.64 ns | 0.240 ns | 0.352 ns | 13.66 ns | 12.93 ns | 14.39 ns | 13.99 ns |
| PooledBuilder      | MediumRun-.NET 8.0  | .NET 8.0  | 13.75 ns | 0.400 ns | 0.599 ns | 13.68 ns | 13.03 ns | 15.01 ns | 14.54 ns |
| Builder            | MediumRun-.NET 9.0  | .NET 9.0  | 56.03 ns | 0.919 ns | 1.347 ns | 56.25 ns | 51.68 ns | 58.13 ns | 57.62 ns |
| BuilderPrepared    | MediumRun-.NET 9.0  | .NET 9.0  | 21.23 ns | 0.498 ns | 0.729 ns | 21.27 ns | 18.92 ns | 22.98 ns | 21.98 ns |
| Handler            | MediumRun-.NET 9.0  | .NET 9.0  | 18.68 ns | 0.199 ns | 0.285 ns | 18.57 ns | 18.34 ns | 19.28 ns | 19.13 ns |
| HandlerPrepared    | MediumRun-.NET 9.0  | .NET 9.0  | 19.59 ns | 0.166 ns | 0.248 ns | 19.54 ns | 19.23 ns | 20.07 ns | 19.95 ns |
| HandlerStack       | MediumRun-.NET 9.0  | .NET 9.0  | 13.53 ns | 0.209 ns | 0.312 ns | 13.53 ns | 13.08 ns | 14.20 ns | 13.99 ns |
| ValueStringBuilder | MediumRun-.NET 9.0  | .NET 9.0  | 13.72 ns | 0.196 ns | 0.287 ns | 13.77 ns | 13.27 ns | 14.36 ns | 13.99 ns |
| PooledBuilder      | MediumRun-.NET 9.0  | .NET 9.0  | 14.51 ns | 0.149 ns | 0.213 ns | 14.42 ns | 14.24 ns | 15.04 ns | 14.81 ns |

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
