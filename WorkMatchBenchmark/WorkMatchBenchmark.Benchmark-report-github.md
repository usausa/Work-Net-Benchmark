```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.7019)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]     : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  Job-CNUJVU : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4

InvocationCount=1  UnrollFactor=1  
```
| Method                 | Mean     | Error    | StdDev   | Median   | Min      | Max      | P90      | Code Size | Allocated |
|----------------------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|----------:|----------:|
| ByThreadStaticUnsafe   | 26.80 ns | 0.665 ns | 1.785 ns | 25.87 ns | 25.09 ns | 32.51 ns | 29.27 ns |   1,553 B |         - |
| ByThreadStaticUnsafe2  | 30.62 ns | 1.417 ns | 4.021 ns | 29.24 ns | 26.24 ns | 41.68 ns | 36.09 ns |   1,538 B |         - |
| ByThreadStaticRefLoop  | 26.65 ns | 0.879 ns | 2.493 ns | 25.43 ns | 23.87 ns | 34.17 ns | 30.91 ns |   1,071 B |         - |
| ByThreadStaticRefLoop2 | 25.61 ns | 1.302 ns | 3.565 ns | 24.68 ns | 22.09 ns | 37.17 ns | 32.21 ns |   1,071 B |         - |

```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.7019)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]     : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  Job-CNUJVU : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4

InvocationCount=1  UnrollFactor=1  
```
| Method                 | Mean     | Error    | StdDev   | Median   | Min      | Max      | P90      | Code Size | Allocated |
|----------------------- |---------:|---------:|---------:|---------:|---------:|---------:|---------:|----------:|----------:|
| ByThreadStaticUnsafe   | 26.80 ns | 0.665 ns | 1.785 ns | 25.87 ns | 25.09 ns | 32.51 ns | 29.27 ns |   1,553 B |         - |
| ByThreadStaticUnsafe2  | 30.62 ns | 1.417 ns | 4.021 ns | 29.24 ns | 26.24 ns | 41.68 ns | 36.09 ns |   1,538 B |         - |
| ByThreadStaticRefLoop  | 26.65 ns | 0.879 ns | 2.493 ns | 25.43 ns | 23.87 ns | 34.17 ns | 30.91 ns |   1,071 B |         - |
| ByThreadStaticRefLoop2 | 25.61 ns | 1.302 ns | 3.565 ns | 24.68 ns | 22.09 ns | 37.17 ns | 32.21 ns |   1,071 B |         - |
