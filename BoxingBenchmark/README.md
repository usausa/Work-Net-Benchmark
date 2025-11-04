```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.7019)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method       | Job                 | Runtime   | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       |
|------------- |-------------------- |---------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| NoBoxing     | MediumRun-.NET 10.0 | .NET 10.0 | 0.0018 ns | 0.0021 ns | 0.0029 ns | 0.0003 ns | 0.0000 ns | 0.0116 ns | 0.0054 ns |
| BoxedToHeap  | MediumRun-.NET 10.0 | .NET 10.0 | 1.7308 ns | 0.0137 ns | 0.0196 ns | 1.7312 ns | 1.6866 ns | 1.7631 ns | 1.7573 ns |
| BoxedToStack | MediumRun-.NET 10.0 | .NET 10.0 | 0.0040 ns | 0.0041 ns | 0.0060 ns | 0.0019 ns | 0.0000 ns | 0.0207 ns | 0.0123 ns |
| NoBoxing     | MediumRun-.NET 8.0  | .NET 8.0  | 0.0028 ns | 0.0034 ns | 0.0050 ns | 0.0000 ns | 0.0000 ns | 0.0179 ns | 0.0108 ns |
| BoxedToHeap  | MediumRun-.NET 8.0  | .NET 8.0  | 1.7642 ns | 0.0160 ns | 0.0240 ns | 1.7625 ns | 1.7196 ns | 1.8280 ns | 1.7922 ns |
| BoxedToStack | MediumRun-.NET 8.0  | .NET 8.0  | 0.0031 ns | 0.0034 ns | 0.0050 ns | 0.0000 ns | 0.0000 ns | 0.0192 ns | 0.0095 ns |
| NoBoxing     | MediumRun-.NET 9.0  | .NET 9.0  | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |
| BoxedToHeap  | MediumRun-.NET 9.0  | .NET 9.0  | 1.7791 ns | 0.0249 ns | 0.0373 ns | 1.7765 ns | 1.7224 ns | 1.8645 ns | 1.8270 ns |
| BoxedToStack | MediumRun-.NET 9.0  | .NET 9.0  | 0.0007 ns | 0.0018 ns | 0.0026 ns | 0.0000 ns | 0.0000 ns | 0.0113 ns | 0.0000 ns |

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
