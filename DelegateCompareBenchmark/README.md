# DelegateCompareBenchmark

# .NET Core

|             Method |     Mean |     Error |    StdDev | Allocated |
|------------------- |---------:|----------:|----------:|----------:|
|   CallStaticMethod | 2.348 ns | 1.2581 ns | 0.0711 ns |       0 B |
| CallInstanceMethod | 1.545 ns | 0.8498 ns | 0.0480 ns |       0 B |

# .NET Framework

|             Method |     Mean |     Error |    StdDev | Allocated |
|------------------- |---------:|----------:|----------:|----------:|
|   CallStaticMethod | 1.919 ns | 0.7542 ns | 0.0426 ns |       0 B |
| CallInstanceMethod | 1.769 ns | 0.3297 ns | 0.0186 ns |       0 B |
