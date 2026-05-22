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
| Method           | Job                 | Runtime   | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Gen0   | Allocated |
|----------------- |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|-------:|----------:|
| Mapping          | MediumRun-.NET 10.0 | .NET 10.0 | 3.308 ns | 0.0356 ns | 0.0511 ns | 3.230 ns | 3.405 ns | 3.373 ns |     109 B | 0.0057 |      48 B |
| MappingInterface | MediumRun-.NET 10.0 | .NET 10.0 | 3.351 ns | 0.0640 ns | 0.0918 ns | 3.234 ns | 3.536 ns | 3.485 ns |     217 B | 0.0057 |      48 B |
| ProjectClass     | MediumRun-.NET 10.0 | .NET 10.0 | 3.024 ns | 0.0561 ns | 0.0840 ns | 2.931 ns | 3.200 ns | 3.154 ns |     221 B | 0.0029 |      24 B |
| ProjectStruct    | MediumRun-.NET 10.0 | .NET 10.0 | 3.149 ns | 0.0222 ns | 0.0303 ns | 3.065 ns | 3.232 ns | 3.175 ns |     213 B | 0.0029 |      24 B |
| Mapping          | MediumRun-.NET 8.0  | .NET 8.0  | 3.270 ns | 0.0315 ns | 0.0442 ns | 3.213 ns | 3.390 ns | 3.336 ns |     110 B | 0.0057 |      48 B |
| MappingInterface | MediumRun-.NET 8.0  | .NET 8.0  | 3.282 ns | 0.0380 ns | 0.0557 ns | 3.187 ns | 3.442 ns | 3.368 ns |     217 B | 0.0057 |      48 B |
| ProjectClass     | MediumRun-.NET 8.0  | .NET 8.0  | 3.026 ns | 0.0257 ns | 0.0361 ns | 2.980 ns | 3.110 ns | 3.069 ns |     197 B | 0.0029 |      24 B |
| ProjectStruct    | MediumRun-.NET 8.0  | .NET 8.0  | 3.029 ns | 0.0449 ns | 0.0629 ns | 2.947 ns | 3.189 ns | 3.131 ns |     189 B | 0.0029 |      24 B |
| Mapping          | MediumRun-.NET 9.0  | .NET 9.0  | 3.273 ns | 0.0319 ns | 0.0457 ns | 3.206 ns | 3.371 ns | 3.341 ns |     110 B | 0.0057 |      48 B |
| MappingInterface | MediumRun-.NET 9.0  | .NET 9.0  | 3.319 ns | 0.0475 ns | 0.0711 ns | 3.226 ns | 3.482 ns | 3.425 ns |     217 B | 0.0057 |      48 B |
| ProjectClass     | MediumRun-.NET 9.0  | .NET 9.0  | 3.057 ns | 0.0713 ns | 0.1045 ns | 2.939 ns | 3.321 ns | 3.204 ns |     197 B | 0.0029 |      24 B |
| ProjectStruct    | MediumRun-.NET 9.0  | .NET 9.0  | 3.144 ns | 0.0417 ns | 0.0611 ns | 3.051 ns | 3.253 ns | 3.231 ns |     189 B | 0.0029 |      24 B |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]    : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  
```
| Method           | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Gen0   | Allocated |
|----------------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|-------:|----------:|
| Mapping          | 4.673 ns | 0.0948 ns | 0.1298 ns | 4.500 ns | 5.049 ns | 4.798 ns |     110 B | 0.0029 |      48 B |
| MappingInterface | 4.849 ns | 0.1355 ns | 0.2028 ns | 4.646 ns | 5.352 ns | 5.104 ns |     217 B | 0.0029 |      48 B |
| ProjectClass     | 4.130 ns | 0.1445 ns | 0.2163 ns | 3.856 ns | 4.647 ns | 4.468 ns |     197 B | 0.0014 |      24 B |
| ProjectStruct    | 4.565 ns | 0.1399 ns | 0.2094 ns | 4.230 ns | 4.976 ns | 4.892 ns |     189 B | 0.0014 |      24 B |
