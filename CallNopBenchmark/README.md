```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3007/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.101
  [Host]             : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
  MediumRun-.NET 6.0 : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT AVX2
  MediumRun-.NET 8.0 : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method    | Job                | Runtime  | Mean       | Error    | StdDev    | Min        | Max        | P90        | Code Size | Allocated |
|---------- |------------------- |--------- |-----------:|---------:|----------:|-----------:|-----------:|-----------:|----------:|----------:|
| Lambda    | MediumRun-.NET 6.0 | .NET 6.0 | 1,590.7 μs | 21.16 μs |  31.68 μs | 1,537.3 μs | 1,653.1 μs | 1,623.1 μs |      48 B |      12 B |
| Static    | MediumRun-.NET 6.0 | .NET 6.0 | 1,683.1 μs | 74.78 μs | 109.62 μs | 1,536.4 μs | 1,826.8 μs | 1,813.6 μs |      48 B |      13 B |
| Curry     | MediumRun-.NET 6.0 | .NET 6.0 | 1,562.7 μs | 12.16 μs |  18.19 μs | 1,533.4 μs | 1,600.2 μs | 1,591.4 μs |      48 B |      12 B |
| Interface | MediumRun-.NET 6.0 | .NET 6.0 | 1,390.3 μs | 57.04 μs |  83.61 μs | 1,309.7 μs | 1,537.3 μs | 1,523.8 μs |      48 B |      12 B |
| Abstract  | MediumRun-.NET 6.0 | .NET 6.0 | 1,109.3 μs |  9.27 μs |  13.58 μs | 1,091.3 μs | 1,143.6 μs | 1,124.2 μs |      44 B |      12 B |
| Lambda    | MediumRun-.NET 8.0 | .NET 8.0 |   223.2 μs |  1.80 μs |   2.64 μs |   219.9 μs |   228.9 μs |   226.9 μs |      95 B |       2 B |
| Static    | MediumRun-.NET 8.0 | .NET 8.0 | 1,785.3 μs | 14.03 μs |  20.57 μs | 1,752.5 μs | 1,824.4 μs | 1,808.9 μs |      45 B |      12 B |
| Curry     | MediumRun-.NET 8.0 | .NET 8.0 | 1,556.6 μs | 15.70 μs |  23.01 μs | 1,527.2 μs | 1,609.6 μs | 1,591.5 μs |      45 B |       2 B |
| Interface | MediumRun-.NET 8.0 | .NET 8.0 |   224.9 μs |  3.04 μs |   4.46 μs |   220.2 μs |   234.4 μs |   232.0 μs |      94 B |       2 B |
| Abstract  | MediumRun-.NET 8.0 | .NET 8.0 |   224.8 μs |  2.08 μs |   3.11 μs |   219.8 μs |   230.5 μs |   229.0 μs |      91 B |         - |
