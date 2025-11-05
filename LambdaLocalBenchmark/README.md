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
| Method         | Job                 | Runtime   | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       | Code Size | Allocated |
|--------------- |-------------------- |---------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| LambdaFunction | MediumRun-.NET 10.0 | .NET 10.0 | 0.0236 ns | 0.0095 ns | 0.0139 ns | 0.0250 ns | 0.0000 ns | 0.0541 ns | 0.0399 ns |     185 B |         - |
| LocalFunction  | MediumRun-.NET 10.0 | .NET 10.0 | 0.0057 ns | 0.0052 ns | 0.0078 ns | 0.0000 ns | 0.0000 ns | 0.0249 ns | 0.0171 ns |       6 B |         - |
| LambdaFunction | MediumRun-.NET 8.0  | .NET 8.0  | 0.0141 ns | 0.0085 ns | 0.0125 ns | 0.0147 ns | 0.0000 ns | 0.0425 ns | 0.0328 ns |     185 B |         - |
| LocalFunction  | MediumRun-.NET 8.0  | .NET 8.0  | 0.0062 ns | 0.0060 ns | 0.0088 ns | 0.0012 ns | 0.0000 ns | 0.0288 ns | 0.0182 ns |       6 B |         - |
| LambdaFunction | MediumRun-.NET 9.0  | .NET 9.0  | 0.0337 ns | 0.0069 ns | 0.0102 ns | 0.0312 ns | 0.0182 ns | 0.0522 ns | 0.0474 ns |     185 B |         - |
| LocalFunction  | MediumRun-.NET 9.0  | .NET 9.0  | 0.0027 ns | 0.0047 ns | 0.0069 ns | 0.0000 ns | 0.0000 ns | 0.0289 ns | 0.0063 ns |       6 B |         - |

```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

```
| Method         | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       | Code Size | Allocated |
|--------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| LambdaFunction | 0.1696 ns | 0.0167 ns | 0.0156 ns | 0.1604 ns | 0.1541 ns | 0.1932 ns | 0.1914 ns |     180 B |         - |
| LocalFunction  | 0.0025 ns | 0.0046 ns | 0.0043 ns | 0.0000 ns | 0.0000 ns | 0.0119 ns | 0.0095 ns |       6 B |         - |
