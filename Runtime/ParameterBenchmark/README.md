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
| Method                 | Job                 | Runtime   | Mean     | Error     | StdDev    | Median   | Min      | Max      | P90      | Code Size | Gen0   | Allocated |
|----------------------- |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|----------:|-------:|----------:|
| CallReadonlyStruct     | MediumRun-.NET 10.0 | .NET 10.0 | 1.328 μs | 0.0361 μs | 0.0541 μs | 1.338 μs | 1.197 μs | 1.391 μs | 1.387 μs |     107 B | 0.0019 |      24 B |
| CallReadonlyStruct2    | MediumRun-.NET 10.0 | .NET 10.0 | 1.307 μs | 0.0416 μs | 0.0623 μs | 1.321 μs | 1.113 μs | 1.385 μs | 1.372 μs |     107 B | 0.0019 |      24 B |
| CallReadonlyRefStruct  | MediumRun-.NET 10.0 | .NET 10.0 | 1.202 μs | 0.0043 μs | 0.0063 μs | 1.201 μs | 1.192 μs | 1.218 μs | 1.211 μs |     107 B | 0.0019 |      24 B |
| CallReadonlyRefStruct2 | MediumRun-.NET 10.0 | .NET 10.0 | 1.196 μs | 0.0036 μs | 0.0050 μs | 1.196 μs | 1.186 μs | 1.207 μs | 1.200 μs |     107 B | 0.0019 |      24 B |
| CallReadonlyStruct     | MediumRun-.NET 8.0  | .NET 8.0  | 1.318 μs | 0.0382 μs | 0.0571 μs | 1.330 μs | 1.128 μs | 1.393 μs | 1.373 μs |     110 B | 0.0019 |      24 B |
| CallReadonlyStruct2    | MediumRun-.NET 8.0  | .NET 8.0  | 1.256 μs | 0.0462 μs | 0.0692 μs | 1.211 μs | 1.189 μs | 1.379 μs | 1.352 μs |     110 B | 0.0019 |      24 B |
| CallReadonlyRefStruct  | MediumRun-.NET 8.0  | .NET 8.0  | 1.319 μs | 0.0378 μs | 0.0565 μs | 1.322 μs | 1.166 μs | 1.391 μs | 1.379 μs |     110 B | 0.0019 |      24 B |
| CallReadonlyRefStruct2 | MediumRun-.NET 8.0  | .NET 8.0  | 1.202 μs | 0.0037 μs | 0.0056 μs | 1.200 μs | 1.193 μs | 1.212 μs | 1.210 μs |     110 B | 0.0019 |      24 B |
| CallReadonlyStruct     | MediumRun-.NET 9.0  | .NET 9.0  | 1.316 μs | 0.0354 μs | 0.0530 μs | 1.326 μs | 1.177 μs | 1.385 μs | 1.370 μs |     107 B | 0.0019 |      24 B |
| CallReadonlyStruct2    | MediumRun-.NET 9.0  | .NET 9.0  | 1.324 μs | 0.0348 μs | 0.0521 μs | 1.343 μs | 1.185 μs | 1.398 μs | 1.379 μs |     107 B | 0.0019 |      24 B |
| CallReadonlyRefStruct  | MediumRun-.NET 9.0  | .NET 9.0  | 1.199 μs | 0.0032 μs | 0.0047 μs | 1.200 μs | 1.192 μs | 1.207 μs | 1.206 μs |     107 B | 0.0019 |      24 B |
| CallReadonlyRefStruct2 | MediumRun-.NET 9.0  | .NET 9.0  | 1.200 μs | 0.0048 μs | 0.0071 μs | 1.200 μs | 1.171 μs | 1.210 μs | 1.207 μs |     107 B | 0.0019 |      24 B |
