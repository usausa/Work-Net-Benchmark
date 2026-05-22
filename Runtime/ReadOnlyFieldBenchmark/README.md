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
| Method    | Job                 | Runtime   | Mean      | Error     | StdDev    | Median    | Min    | Max       | P90       | Code Size | Allocated |
|---------- |-------------------- |---------- |----------:|----------:|----------:|----------:|-------:|----------:|----------:|----------:|----------:|
| ReadOnly  | MediumRun-.NET 10.0 | .NET 10.0 | 0.0062 ns | 0.0055 ns | 0.0081 ns | 0.0013 ns | 0.0 ns | 0.0253 ns | 0.0190 ns |       7 B |         - |
| Public    | MediumRun-.NET 10.0 | .NET 10.0 | 0.0079 ns | 0.0068 ns | 0.0102 ns | 0.0005 ns | 0.0 ns | 0.0348 ns | 0.0208 ns |       7 B |         - |
| ReadOnly4 | MediumRun-.NET 10.0 | .NET 10.0 | 0.0109 ns | 0.0075 ns | 0.0109 ns | 0.0095 ns | 0.0 ns | 0.0416 ns | 0.0226 ns |       7 B |         - |
| Public4   | MediumRun-.NET 10.0 | .NET 10.0 | 0.0102 ns | 0.0089 ns | 0.0128 ns | 0.0035 ns | 0.0 ns | 0.0408 ns | 0.0285 ns |       7 B |         - |
| ReadOnly  | MediumRun-.NET 8.0  | .NET 8.0  | 0.0066 ns | 0.0068 ns | 0.0100 ns | 0.0000 ns | 0.0 ns | 0.0332 ns | 0.0210 ns |       8 B |         - |
| Public    | MediumRun-.NET 8.0  | .NET 8.0  | 0.0091 ns | 0.0123 ns | 0.0172 ns | 0.0000 ns | 0.0 ns | 0.0790 ns | 0.0206 ns |       8 B |         - |
| ReadOnly4 | MediumRun-.NET 8.0  | .NET 8.0  | 0.0156 ns | 0.0107 ns | 0.0150 ns | 0.0128 ns | 0.0 ns | 0.0528 ns | 0.0347 ns |       8 B |         - |
| Public4   | MediumRun-.NET 8.0  | .NET 8.0  | 0.0043 ns | 0.0049 ns | 0.0074 ns | 0.0000 ns | 0.0 ns | 0.0265 ns | 0.0139 ns |       8 B |         - |
| ReadOnly  | MediumRun-.NET 9.0  | .NET 9.0  | 0.0065 ns | 0.0060 ns | 0.0087 ns | 0.0000 ns | 0.0 ns | 0.0230 ns | 0.0204 ns |       8 B |         - |
| Public    | MediumRun-.NET 9.0  | .NET 9.0  | 0.0148 ns | 0.0150 ns | 0.0215 ns | 0.0091 ns | 0.0 ns | 0.0858 ns | 0.0402 ns |       8 B |         - |
| ReadOnly4 | MediumRun-.NET 9.0  | .NET 9.0  | 0.0085 ns | 0.0088 ns | 0.0115 ns | 0.0022 ns | 0.0 ns | 0.0432 ns | 0.0241 ns |       8 B |         - |
| Public4   | MediumRun-.NET 9.0  | .NET 9.0  | 0.0086 ns | 0.0063 ns | 0.0091 ns | 0.0045 ns | 0.0 ns | 0.0306 ns | 0.0209 ns |       8 B |         - |
