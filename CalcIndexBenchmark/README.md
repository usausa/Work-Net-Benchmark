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
| Method       | Job                 | Runtime   | Mean      | Error     | StdDev    | Min       | Max       | P90       | Code Size | Allocated |
|------------- |-------------------- |---------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| IntKey       | MediumRun-.NET 10.0 | .NET 10.0 | 0.2040 ns | 0.0007 ns | 0.0009 ns | 0.2029 ns | 0.2068 ns | 0.2052 ns |      66 B |         - |
| UIntKey      | MediumRun-.NET 10.0 | .NET 10.0 | 0.2092 ns | 0.0008 ns | 0.0011 ns | 0.2075 ns | 0.2109 ns | 0.2107 ns |      72 B |         - |
| UIntToIntKey | MediumRun-.NET 10.0 | .NET 10.0 | 0.2039 ns | 0.0005 ns | 0.0007 ns | 0.2029 ns | 0.2054 ns | 0.2048 ns |      66 B |         - |
| IntToUIntKey | MediumRun-.NET 10.0 | .NET 10.0 | 0.2083 ns | 0.0006 ns | 0.0008 ns | 0.2073 ns | 0.2103 ns | 0.2096 ns |      72 B |         - |
| IntKey       | MediumRun-.NET 8.0  | .NET 8.0  | 0.2086 ns | 0.0021 ns | 0.0031 ns | 0.2047 ns | 0.2152 ns | 0.2138 ns |      74 B |         - |
| UIntKey      | MediumRun-.NET 8.0  | .NET 8.0  | 0.3971 ns | 0.0004 ns | 0.0006 ns | 0.3963 ns | 0.3981 ns | 0.3980 ns |      79 B |         - |
| UIntToIntKey | MediumRun-.NET 8.0  | .NET 8.0  | 0.2915 ns | 0.0577 ns | 0.0846 ns | 0.2052 ns | 0.3982 ns | 0.3917 ns |      74 B |         - |
| IntToUIntKey | MediumRun-.NET 8.0  | .NET 8.0  | 0.5209 ns | 0.0356 ns | 0.0533 ns | 0.4313 ns | 0.6281 ns | 0.5944 ns |      79 B |         - |
| IntKey       | MediumRun-.NET 9.0  | .NET 9.0  | 0.2935 ns | 0.0090 ns | 0.0134 ns | 0.2626 ns | 0.3101 ns | 0.3078 ns |      66 B |         - |
| UIntKey      | MediumRun-.NET 9.0  | .NET 9.0  | 0.3538 ns | 0.0374 ns | 0.0561 ns | 0.2315 ns | 0.4185 ns | 0.4135 ns |      72 B |         - |
| UIntToIntKey | MediumRun-.NET 9.0  | .NET 9.0  | 0.2971 ns | 0.0117 ns | 0.0168 ns | 0.2493 ns | 0.3184 ns | 0.3094 ns |      66 B |         - |
| IntToUIntKey | MediumRun-.NET 9.0  | .NET 9.0  | 0.3503 ns | 0.0376 ns | 0.0563 ns | 0.2353 ns | 0.4181 ns | 0.4038 ns |      72 B |         - |
```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
```
| Method       | Mean      | Error     | StdDev    | Min       | Max       | P90       | Code Size | Allocated |
|------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| IntKey       | 0.2768 ns | 0.0054 ns | 0.0060 ns | 0.2667 ns | 0.2893 ns | 0.2829 ns |      66 B |         - |
| UIntKey      | 0.3014 ns | 0.0059 ns | 0.0073 ns | 0.2926 ns | 0.3160 ns | 0.3102 ns |      72 B |         - |
| UIntToIntKey | 0.2718 ns | 0.0047 ns | 0.0056 ns | 0.2632 ns | 0.2822 ns | 0.2809 ns |      66 B |         - |
| IntToUIntKey | 0.3001 ns | 0.0060 ns | 0.0078 ns | 0.2920 ns | 0.3209 ns | 0.3103 ns |      72 B |         - |
