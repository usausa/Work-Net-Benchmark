```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3958/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]             : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun-.NET 6.0 : .NET 6.0.33 (6.0.3324.36610), X64 RyuJIT AVX2
  MediumRun-.NET 8.0 : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method            | Job                | Runtime  | Mean       | Error     | StdDev    | Median     | Min        | Max        | P90        | Code Size | Allocated |
|------------------ |------------------- |--------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
| ActionLambda      | MediumRun-.NET 6.0 | .NET 6.0 | 1,322.4 μs |  15.44 μs |  23.12 μs | 1,322.9 μs | 1,289.8 μs | 1,379.6 μs | 1,349.7 μs |      39 B |       1 B |
| ActionStatic      | MediumRun-.NET 6.0 | .NET 6.0 | 1,732.0 μs |   8.92 μs |  13.08 μs | 1,727.4 μs | 1,717.2 μs | 1,765.3 μs | 1,752.4 μs |      39 B |       1 B |
| ActionCurry       | MediumRun-.NET 6.0 | .NET 6.0 | 1,463.8 μs | 149.78 μs | 219.55 μs | 1,307.4 μs | 1,285.3 μs | 1,856.5 μs | 1,812.2 μs |      39 B |       1 B |
| ActionInterface   | MediumRun-.NET 6.0 | .NET 6.0 | 1,324.2 μs |  39.50 μs |  59.12 μs | 1,301.2 μs | 1,283.0 μs | 1,477.5 μs | 1,421.2 μs |      48 B |       1 B |
| ActionAbstract    | MediumRun-.NET 6.0 | .NET 6.0 | 1,292.3 μs |   6.67 μs |   9.35 μs | 1,292.6 μs | 1,277.4 μs | 1,313.8 μs | 1,303.9 μs |      44 B |       1 B |
| ActionLambda      | MediumRun-.NET 8.0 | .NET 8.0 |   215.1 μs |   1.22 μs |   1.67 μs |   214.6 μs |   213.4 μs |   220.0 μs |   217.1 μs |      87 B |         - |
| ActionStatic      | MediumRun-.NET 8.0 | .NET 8.0 | 1,513.3 μs |   3.82 μs |   5.47 μs | 1,512.7 μs | 1,504.8 μs | 1,525.5 μs | 1,521.3 μs |      36 B |       1 B |
| ActionCurry       | MediumRun-.NET 8.0 | .NET 8.0 | 1,296.5 μs |   6.71 μs |   9.63 μs | 1,293.6 μs | 1,284.1 μs | 1,318.3 μs | 1,311.3 μs |      36 B |       1 B |
| ActionInterface   | MediumRun-.NET 8.0 | .NET 8.0 |   214.0 μs |   0.64 μs |   0.88 μs |   213.9 μs |   212.2 μs |   215.8 μs |   215.2 μs |      94 B |         - |
| ActionAbstract    | MediumRun-.NET 8.0 | .NET 8.0 |   215.7 μs |   1.53 μs |   2.29 μs |   215.6 μs |   212.1 μs |   220.3 μs |   219.4 μs |      91 B |         - |
| FunctionLambda    | MediumRun-.NET 6.0 | .NET 6.0 | 1,298.5 μs |   5.68 μs |   8.50 μs | 1,295.6 μs | 1,286.6 μs | 1,316.3 μs | 1,309.5 μs |      41 B |       1 B |
| FunctionStatic    | MediumRun-.NET 6.0 | .NET 6.0 | 1,512.7 μs |   7.26 μs |  10.65 μs | 1,509.6 μs | 1,498.4 μs | 1,543.2 μs | 1,525.8 μs |      41 B |       1 B |
| FunctionCurry     | MediumRun-.NET 6.0 | .NET 6.0 | 1,293.8 μs |   6.00 μs |   8.21 μs | 1,292.3 μs | 1,282.4 μs | 1,309.6 μs | 1,304.8 μs |      41 B |       1 B |
| FunctionInterface | MediumRun-.NET 6.0 | .NET 6.0 | 1,295.0 μs |   5.14 μs |   7.54 μs | 1,295.8 μs | 1,283.8 μs | 1,310.3 μs | 1,303.7 μs |      50 B |       1 B |
| FunctionAbstract  | MediumRun-.NET 6.0 | .NET 6.0 | 1,072.0 μs |   5.04 μs |   7.06 μs | 1,070.8 μs | 1,063.5 μs | 1,095.5 μs | 1,079.1 μs |      46 B |       1 B |
| FunctionLambda    | MediumRun-.NET 8.0 | .NET 8.0 |   215.2 μs |   2.34 μs |   3.50 μs |   214.0 μs |   211.1 μs |   225.3 μs |   219.2 μs |      89 B |         - |
| FunctionStatic    | MediumRun-.NET 8.0 | .NET 8.0 | 1,527.5 μs |  37.02 μs |  53.10 μs | 1,510.1 μs | 1,500.4 μs | 1,737.9 μs | 1,557.0 μs |      38 B |       1 B |
| FunctionCurry     | MediumRun-.NET 8.0 | .NET 8.0 | 1,295.4 μs |   6.17 μs |   9.04 μs | 1,293.2 μs | 1,282.8 μs | 1,319.6 μs | 1,308.1 μs |      38 B |       1 B |
| FunctionInterface | MediumRun-.NET 8.0 | .NET 8.0 |   214.4 μs |   1.28 μs |   1.88 μs |   214.3 μs |   211.2 μs |   218.3 μs |   216.4 μs |      96 B |         - |
| FunctionAbstract  | MediumRun-.NET 8.0 | .NET 8.0 |   215.2 μs |   1.43 μs |   2.05 μs |   214.5 μs |   212.0 μs |   219.4 μs |   218.1 μs |      93 B |         - |
