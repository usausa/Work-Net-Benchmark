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
| Method            | Job                 | Runtime   | Mean     | Error     | StdDev    | Median   | Min      | Max      | P90      | Code Size | Gen0   | Allocated |
|------------------ |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|----------:|-------:|----------:|
| Default           | MediumRun-.NET 10.0 | .NET 10.0 | 3.390 ns | 0.0596 ns | 0.0892 ns | 3.376 ns | 3.238 ns | 3.549 ns | 3.527 ns |   1,730 B | 0.0029 |      24 B |
| DelegateConverter | MediumRun-.NET 10.0 | .NET 10.0 | 2.392 ns | 0.0032 ns | 0.0048 ns | 2.392 ns | 2.384 ns | 2.402 ns | 2.397 ns |   2,135 B |      - |         - |
| Generic           | MediumRun-.NET 10.0 | .NET 10.0 | 2.195 ns | 0.0019 ns | 0.0028 ns | 2.194 ns | 2.189 ns | 2.200 ns | 2.199 ns |   1,704 B |      - |         - |
| Generic2          | MediumRun-.NET 10.0 | .NET 10.0 | 2.382 ns | 0.0046 ns | 0.0069 ns | 2.381 ns | 2.369 ns | 2.396 ns | 2.391 ns |   1,704 B |      - |         - |
| Default           | MediumRun-.NET 8.0  | .NET 8.0  | 7.038 ns | 0.0579 ns | 0.0867 ns | 7.028 ns | 6.898 ns | 7.207 ns | 7.152 ns |   3,832 B | 0.0029 |      24 B |
| DelegateConverter | MediumRun-.NET 8.0  | .NET 8.0  | 2.423 ns | 0.0193 ns | 0.0283 ns | 2.407 ns | 2.382 ns | 2.469 ns | 2.456 ns |   2,242 B |      - |         - |
| Generic           | MediumRun-.NET 8.0  | .NET 8.0  | 2.247 ns | 0.0061 ns | 0.0089 ns | 2.245 ns | 2.232 ns | 2.272 ns | 2.258 ns |   1,740 B |      - |         - |
| Generic2          | MediumRun-.NET 8.0  | .NET 8.0  | 2.803 ns | 0.0057 ns | 0.0082 ns | 2.801 ns | 2.791 ns | 2.830 ns | 2.813 ns |   1,731 B |      - |         - |
| Default           | MediumRun-.NET 9.0  | .NET 9.0  | 6.187 ns | 0.0277 ns | 0.0415 ns | 6.190 ns | 6.022 ns | 6.264 ns | 6.218 ns |   3,898 B | 0.0029 |      24 B |
| DelegateConverter | MediumRun-.NET 9.0  | .NET 9.0  | 3.010 ns | 0.0046 ns | 0.0067 ns | 3.010 ns | 2.996 ns | 3.022 ns | 3.020 ns |   2,265 B |      - |         - |
| Generic           | MediumRun-.NET 9.0  | .NET 9.0  | 2.438 ns | 0.0060 ns | 0.0090 ns | 2.439 ns | 2.419 ns | 2.454 ns | 2.450 ns |   1,746 B |      - |         - |
| Generic2          | MediumRun-.NET 9.0  | .NET 9.0  | 2.816 ns | 0.0092 ns | 0.0137 ns | 2.814 ns | 2.795 ns | 2.851 ns | 2.834 ns |   1,746 B |      - |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
```
| Method            | Mean      | Error     | StdDev    | Min       | Max       | P90       | Gen0   | Code Size | Allocated |
|------------------ |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|----------:|
| Default           | 10.731 ns | 0.2029 ns | 0.1799 ns | 10.330 ns | 10.980 ns | 10.933 ns | 0.0014 |   2,621 B |      24 B |
| DelegateConverter |  4.203 ns | 0.0822 ns | 0.0880 ns |  4.078 ns |  4.315 ns |  4.303 ns |      - |     436 B |         - |
| Generic           |  3.963 ns | 0.0776 ns | 0.1062 ns |  3.857 ns |  4.186 ns |  4.110 ns |      - |     381 B |         - |
| Generic2          |  3.764 ns | 0.0741 ns | 0.1015 ns |  3.646 ns |  3.962 ns |  3.907 ns |      - |     381 B |         - |
