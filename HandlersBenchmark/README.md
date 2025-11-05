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
| Method         | Job                 | Runtime   | Mean     | Error     | StdDev    | Median   | Min      | Max      | P90      | Code Size | Allocated |
|--------------- |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|----------:|----------:|
| ByArrayHandler | MediumRun-.NET 10.0 | .NET 10.0 | 1.304 ns | 0.0066 ns | 0.0096 ns | 1.303 ns | 1.286 ns | 1.322 ns | 1.318 ns |      80 B |         - |
| ByLinkHandler  | MediumRun-.NET 10.0 | .NET 10.0 | 2.120 ns | 0.0113 ns | 0.0169 ns | 2.118 ns | 2.096 ns | 2.149 ns | 2.147 ns |      74 B |         - |
| ByArrayHandler | MediumRun-.NET 8.0  | .NET 8.0  | 1.369 ns | 0.0097 ns | 0.0145 ns | 1.362 ns | 1.348 ns | 1.394 ns | 1.389 ns |      82 B |         - |
| ByLinkHandler  | MediumRun-.NET 8.0  | .NET 8.0  | 2.184 ns | 0.0108 ns | 0.0162 ns | 2.185 ns | 2.160 ns | 2.218 ns | 2.203 ns |      74 B |         - |
| ByArrayHandler | MediumRun-.NET 9.0  | .NET 9.0  | 1.462 ns | 0.0448 ns | 0.0643 ns | 1.460 ns | 1.303 ns | 1.623 ns | 1.530 ns |      80 B |         - |
| ByLinkHandler  | MediumRun-.NET 9.0  | .NET 9.0  | 2.182 ns | 0.0667 ns | 0.0998 ns | 2.151 ns | 2.089 ns | 2.430 ns | 2.306 ns |      74 B |         - |
