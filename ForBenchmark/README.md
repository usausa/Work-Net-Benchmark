```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.305
  [Host]     : .NET 9.0.9 (9.0.925.41916), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.9 (9.0.925.41916), X64 RyuJIT AVX2


```
| Method       | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       |
|------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| NoBoxing     | 0.0288 ns | 0.0219 ns | 0.0225 ns | 0.0273 ns | 0.0000 ns | 0.0683 ns | 0.0554 ns |
| BoxedToHeap  | 3.2418 ns | 0.1095 ns | 0.2029 ns | 3.2441 ns | 2.9035 ns | 3.6517 ns | 3.5347 ns |
| BoxedToStack | 0.0289 ns | 0.0224 ns | 0.0267 ns | 0.0192 ns | 0.0000 ns | 0.1036 ns | 0.0538 ns |
