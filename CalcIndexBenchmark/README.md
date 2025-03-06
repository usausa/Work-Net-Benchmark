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
