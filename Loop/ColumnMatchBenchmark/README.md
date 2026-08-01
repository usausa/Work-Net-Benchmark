```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8894/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 5900X 3.70GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.302
  [Host]              : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 8.0  : .NET 8.0.29 (8.0.29, 8.0.2926.32403), X64 RyuJIT x86-64-v3
  MediumRun-.NET 9.0  : .NET 9.0.18 (9.0.18, 9.0.1826.31522), X64 RyuJIT x86-64-v3

InvocationCount=1  IterationCount=15  LaunchCount=2  
UnrollFactor=1  WarmupCount=10  

```
| Method                 | Job                 | Runtime   | Mean     | Error    | StdDev   | Min      | Max      | P90      | Code Size | Allocated |
|----------------------- |-------------------- |---------- |---------:|---------:|---------:|---------:|---------:|---------:|----------:|----------:|
| ByThreadStaticUnsafe   | MediumRun-.NET 10.0 | .NET 10.0 | 42.22 ns | 1.036 ns | 1.519 ns | 39.42 ns | 45.28 ns | 43.79 ns |   1,495 B |         - |
| ByThreadStaticUnsafe2  | MediumRun-.NET 10.0 | .NET 10.0 | 42.90 ns | 1.541 ns | 2.306 ns | 40.02 ns | 48.23 ns | 47.22 ns |   1,506 B |         - |
| ByThreadStaticRefLoop  | MediumRun-.NET 10.0 | .NET 10.0 | 44.48 ns | 3.634 ns | 5.439 ns | 36.79 ns | 52.09 ns | 50.99 ns |   1,473 B |         - |
| ByThreadStaticRefLoop2 | MediumRun-.NET 10.0 | .NET 10.0 | 43.24 ns | 0.989 ns | 1.387 ns | 40.70 ns | 45.76 ns | 44.83 ns |   1,473 B |         - |
| ByThreadStaticUnsafe   | MediumRun-.NET 8.0  | .NET 8.0  | 40.71 ns | 1.420 ns | 2.126 ns | 37.63 ns | 45.52 ns | 43.45 ns |   1,372 B |         - |
| ByThreadStaticUnsafe2  | MediumRun-.NET 8.0  | .NET 8.0  | 46.36 ns | 1.301 ns | 1.907 ns | 43.14 ns | 49.25 ns | 48.54 ns |   1,381 B |         - |
| ByThreadStaticRefLoop  | MediumRun-.NET 8.0  | .NET 8.0  | 41.65 ns | 1.277 ns | 1.911 ns | 38.50 ns | 45.95 ns | 43.70 ns |   1,339 B |         - |
| ByThreadStaticRefLoop2 | MediumRun-.NET 8.0  | .NET 8.0  | 48.09 ns | 1.764 ns | 2.640 ns | 43.43 ns | 55.48 ns | 51.17 ns |   1,353 B |         - |
| ByThreadStaticUnsafe   | MediumRun-.NET 9.0  | .NET 9.0  | 35.93 ns | 0.872 ns | 1.305 ns | 33.07 ns | 37.69 ns | 37.47 ns |   1,162 B |         - |
| ByThreadStaticUnsafe2  | MediumRun-.NET 9.0  | .NET 9.0  | 35.69 ns | 1.141 ns | 1.707 ns | 32.39 ns | 39.31 ns | 37.63 ns |   1,383 B |         - |
| ByThreadStaticRefLoop  | MediumRun-.NET 9.0  | .NET 9.0  | 38.99 ns | 2.223 ns | 3.258 ns | 34.34 ns | 44.10 ns | 42.88 ns |   1,351 B |         - |
| ByThreadStaticRefLoop2 | MediumRun-.NET 9.0  | .NET 9.0  | 42.25 ns | 0.968 ns | 1.449 ns | 39.88 ns | 46.11 ns | 43.52 ns |   1,353 B |         - |
