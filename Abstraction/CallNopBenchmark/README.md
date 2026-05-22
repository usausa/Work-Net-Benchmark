```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.6901)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method            | Job                 | Runtime   | Mean       | Error    | StdDev   | Min        | Max        | P90        | Code Size | Allocated |
|------------------ |-------------------- |---------- |-----------:|---------:|---------:|-----------:|-----------:|-----------:|----------:|----------:|
| ActionLambda      | MediumRun-.NET 10.0 | .NET 10.0 |   196.7 μs |  0.46 μs |  0.64 μs |   195.6 μs |   198.1 μs |   197.8 μs |      92 B |         - |
| ActionStatic      | MediumRun-.NET 10.0 | .NET 10.0 | 1,574.9 μs | 16.49 μs | 23.65 μs | 1,554.6 μs | 1,664.5 μs | 1,585.9 μs |      33 B |         - |
| ActionCurry       | MediumRun-.NET 10.0 | .NET 10.0 | 1,359.7 μs |  8.72 μs | 13.06 μs | 1,327.7 μs | 1,383.7 μs | 1,373.8 μs |      33 B |         - |
| ActionInterface   | MediumRun-.NET 10.0 | .NET 10.0 |   196.0 μs |  0.18 μs |  0.25 μs |   195.4 μs |   196.7 μs |   196.2 μs |     100 B |         - |
| ActionAbstract    | MediumRun-.NET 10.0 | .NET 10.0 |   196.1 μs |  0.15 μs |  0.20 μs |   195.5 μs |   196.4 μs |   196.3 μs |      94 B |         - |
| ActionLambda      | MediumRun-.NET 8.0  | .NET 8.0  |   196.4 μs |  0.36 μs |  0.51 μs |   195.8 μs |   198.0 μs |   196.9 μs |      88 B |         - |
| ActionStatic      | MediumRun-.NET 8.0  | .NET 8.0  | 1,567.6 μs |  7.21 μs | 10.11 μs | 1,536.7 μs | 1,583.0 μs | 1,576.2 μs |      36 B |         - |
| ActionCurry       | MediumRun-.NET 8.0  | .NET 8.0  | 1,367.4 μs | 13.12 μs | 19.64 μs | 1,344.2 μs | 1,429.5 μs | 1,392.0 μs |      36 B |         - |
| ActionInterface   | MediumRun-.NET 8.0  | .NET 8.0  |   196.2 μs |  0.29 μs |  0.43 μs |   195.4 μs |   197.1 μs |   196.7 μs |      94 B |         - |
| ActionAbstract    | MediumRun-.NET 8.0  | .NET 8.0  |   196.8 μs |  0.72 μs |  1.01 μs |   195.8 μs |   199.6 μs |   197.9 μs |      91 B |         - |
| FunctionLambda    | MediumRun-.NET 10.0 | .NET 10.0 |   196.5 μs |  0.34 μs |  0.48 μs |   195.7 μs |   197.7 μs |   197.0 μs |      97 B |         - |
| FunctionStatic    | MediumRun-.NET 10.0 | .NET 10.0 | 1,564.1 μs |  7.42 μs | 10.40 μs | 1,539.3 μs | 1,584.9 μs | 1,574.5 μs |      35 B |         - |
| FunctionCurry     | MediumRun-.NET 10.0 | .NET 10.0 | 1,356.1 μs | 11.00 μs | 16.46 μs | 1,307.8 μs | 1,380.6 μs | 1,375.5 μs |      35 B |         - |
| FunctionInterface | MediumRun-.NET 10.0 | .NET 10.0 |   196.2 μs |  0.25 μs |  0.36 μs |   195.4 μs |   197.1 μs |   196.5 μs |     102 B |         - |
| FunctionAbstract  | MediumRun-.NET 10.0 | .NET 10.0 |   196.4 μs |  0.39 μs |  0.57 μs |   195.8 μs |   198.1 μs |   197.0 μs |      96 B |         - |
| FunctionLambda    | MediumRun-.NET 8.0  | .NET 8.0  |   196.4 μs |  0.29 μs |  0.42 μs |   195.8 μs |   197.2 μs |   197.0 μs |      93 B |         - |
| FunctionStatic    | MediumRun-.NET 8.0  | .NET 8.0  | 1,568.4 μs |  7.14 μs | 10.24 μs | 1,536.1 μs | 1,585.1 μs | 1,578.8 μs |      38 B |         - |
| FunctionCurry     | MediumRun-.NET 8.0  | .NET 8.0  | 1,351.4 μs | 11.04 μs | 16.52 μs | 1,320.3 μs | 1,379.6 μs | 1,373.7 μs |      38 B |         - |
| FunctionInterface | MediumRun-.NET 8.0  | .NET 8.0  |   196.8 μs |  0.67 μs |  0.93 μs |   195.9 μs |   199.5 μs |   197.8 μs |      96 B |         - |
| FunctionAbstract  | MediumRun-.NET 8.0  | .NET 8.0  |   197.1 μs |  2.13 μs |  2.84 μs |   195.4 μs |   208.4 μs |   199.2 μs |      93 B |         - |

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
