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
| Method      | Job                 | Runtime   | Mean     | Error    | StdDev   | Min      | Max      | P90      | Code Size | Allocated |
|------------ |-------------------- |---------- |---------:|---------:|---------:|---------:|---------:|---------:|----------:|----------:|
| ByStructRef | MediumRun-.NET 10.0 | .NET 10.0 | 214.4 μs |  2.64 μs |  3.87 μs | 208.6 μs | 224.9 μs | 219.6 μs |     298 B |         - |
| ByClass     | MediumRun-.NET 10.0 | .NET 10.0 | 325.7 μs |  2.89 μs |  4.24 μs | 320.2 μs | 338.7 μs | 330.7 μs |     319 B |     320 B |
| ByStructRef | MediumRun-.NET 8.0  | .NET 8.0  | 182.6 μs |  1.73 μs |  2.58 μs | 179.1 μs | 189.3 μs | 185.5 μs |     256 B |     216 B |
| ByClass     | MediumRun-.NET 8.0  | .NET 8.0  | 254.1 μs | 47.35 μs | 70.87 μs | 180.5 μs | 330.1 μs | 328.2 μs |     274 B |     408 B |
| ByStructRef | MediumRun-.NET 9.0  | .NET 9.0  | 185.6 μs |  2.12 μs |  3.04 μs | 182.5 μs | 193.8 μs | 188.7 μs |     245 B |     216 B |
| ByClass     | MediumRun-.NET 9.0  | .NET 9.0  | 195.5 μs |  3.02 μs |  4.53 μs | 190.0 μs | 207.6 μs | 201.6 μs |     273 B |     408 B |

```
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
