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
| Method | Job                 | Runtime   | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Allocated |
|------- |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|----------:|
| ByCast | MediumRun-.NET 10.0 | .NET 10.0 | 3.434 ns | 0.0663 ns | 0.0930 ns | 3.351 ns | 3.729 ns | 3.526 ns |     498 B |         - |
| ByAs   | MediumRun-.NET 10.0 | .NET 10.0 | 1.586 ns | 0.0061 ns | 0.0086 ns | 1.567 ns | 1.607 ns | 1.596 ns |      67 B |         - |
| ByCast | MediumRun-.NET 8.0  | .NET 8.0  | 3.176 ns | 0.0257 ns | 0.0368 ns | 3.084 ns | 3.274 ns | 3.203 ns |     280 B |         - |
| ByAs   | MediumRun-.NET 8.0  | .NET 8.0  | 1.242 ns | 0.0257 ns | 0.0369 ns | 1.213 ns | 1.351 ns | 1.305 ns |      69 B |         - |
| ByCast | MediumRun-.NET 9.0  | .NET 9.0  | 3.267 ns | 0.0063 ns | 0.0088 ns | 3.245 ns | 3.281 ns | 3.278 ns |     256 B |         - |
| ByAs   | MediumRun-.NET 9.0  | .NET 9.0  | 1.601 ns | 0.0247 ns | 0.0346 ns | 1.572 ns | 1.713 ns | 1.640 ns |      67 B |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3037)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

```
| Method | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Allocated |
|------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|----------:|
| ByCast | 4.267 ns | 0.0907 ns | 0.0849 ns | 4.147 ns | 4.430 ns | 4.368 ns |     255 B |         - |
| ByAs   | 3.453 ns | 0.0866 ns | 0.0963 ns | 3.299 ns | 3.659 ns | 3.559 ns |      66 B |         - |
