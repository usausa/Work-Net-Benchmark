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
| Method         | Job                 | Runtime   | Mean      | Error     | StdDev    | Min       | Max       | P90       | Code Size | Allocated |
|--------------- |-------------------- |---------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| UseSpan        | MediumRun-.NET 10.0 | .NET 10.0 | 0.8854 ns | 0.0201 ns | 0.0301 ns | 0.8486 ns | 0.9629 ns | 0.9201 ns |     792 B |         - |
| UseSearchValue | MediumRun-.NET 10.0 | .NET 10.0 | 1.4943 ns | 0.0234 ns | 0.0351 ns | 1.4409 ns | 1.5760 ns | 1.5441 ns |     880 B |         - |
| UseSpan        | MediumRun-.NET 8.0  | .NET 8.0  | 1.6364 ns | 0.0189 ns | 0.0278 ns | 1.5891 ns | 1.6886 ns | 1.6723 ns |     867 B |         - |
| UseSearchValue | MediumRun-.NET 8.0  | .NET 8.0  | 2.1664 ns | 0.0239 ns | 0.0350 ns | 2.1254 ns | 2.2582 ns | 2.2039 ns |      80 B |         - |
| UseSpan        | MediumRun-.NET 9.0  | .NET 9.0  | 1.4531 ns | 0.0238 ns | 0.0355 ns | 1.3936 ns | 1.5324 ns | 1.5018 ns |     899 B |         - |
| UseSearchValue | MediumRun-.NET 9.0  | .NET 9.0  | 1.6652 ns | 0.0203 ns | 0.0303 ns | 1.6231 ns | 1.7230 ns | 1.7044 ns |     977 B |         - |
