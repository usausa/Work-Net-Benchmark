```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3037)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2


```
| Method | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Allocated |
|------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|----------:|
| ByCast | 4.267 ns | 0.0907 ns | 0.0849 ns | 4.147 ns | 4.430 ns | 4.368 ns |     255 B |         - |
| ByAs   | 3.453 ns | 0.0866 ns | 0.0963 ns | 3.299 ns | 3.659 ns | 3.559 ns |      66 B |         - |
