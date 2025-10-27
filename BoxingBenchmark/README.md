```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.305
  [Host]     : .NET 9.0.9 (9.0.925.41916), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.9 (9.0.925.41916), X64 RyuJIT AVX2
```

| Method       | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       |
|------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| NoBoxing     | 0.0294 ns | 0.0231 ns | 0.0227 ns | 0.0219 ns | 0.0031 ns | 0.0676 ns | 0.0622 ns |
| BoxedToHeap  | 3.2831 ns | 0.1093 ns | 0.1826 ns | 3.2771 ns | 2.9865 ns | 3.6667 ns | 3.4880 ns |
| BoxedToStack | 0.0040 ns | 0.0113 ns | 0.0105 ns | 0.0000 ns | 0.0000 ns | 0.0393 ns | 0.0109 ns |
