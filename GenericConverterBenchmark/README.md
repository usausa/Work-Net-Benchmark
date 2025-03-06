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
