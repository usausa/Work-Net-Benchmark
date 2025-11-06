```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.7019)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

InvocationCount=1  IterationCount=15  LaunchCount=2  
UnrollFactor=1  WarmupCount=10  
```
| Method      | Job                 | Runtime   | Mean      | Error    | StdDev    | Min        | Max       | P90       | Code Size | Allocated |
|------------ |-------------------- |---------- |----------:|---------:|----------:|-----------:|----------:|----------:|----------:|----------:|
| BySort      | MediumRun-.NET 10.0 | .NET 10.0 |  15.37 μs | 2.710 μs |  3.710 μs |  10.100 μs |  23.60 μs |  19.10 μs |     305 B |         - |
| ByMergeSort | MediumRun-.NET 10.0 | .NET 10.0 | 140.83 μs | 8.608 μs | 12.618 μs | 120.300 μs | 178.80 μs | 156.64 μs |   1,576 B |         - |
| BySort      | MediumRun-.NET 8.0  | .NET 8.0  |  12.44 μs | 2.136 μs |  2.994 μs |   6.200 μs |  18.65 μs |  16.71 μs |     320 B |         - |
| ByMergeSort | MediumRun-.NET 8.0  | .NET 8.0  | 136.11 μs | 5.514 μs |  8.082 μs | 127.100 μs | 156.60 μs | 147.18 μs |   1,679 B |         - |
| BySort      | MediumRun-.NET 9.0  | .NET 9.0  |  15.64 μs | 2.604 μs |  3.734 μs |   7.500 μs |  23.80 μs |  19.91 μs |     306 B |         - |
| ByMergeSort | MediumRun-.NET 9.0  | .NET 9.0  | 138.48 μs | 9.036 μs | 12.667 μs | 118.800 μs | 158.40 μs | 154.34 μs |   1,607 B |         - |
