# DelegateCompareBenchmark

# .NET Core

|             Method |     Mean |     Error |    StdDev | Allocated |
|------------------- |---------:|----------:|----------:|----------:|
|         CallDirect | 1.544 ns | 0.2984 ns | 0.0169 ns |       0 B |
|   CallStaticMethod | 2.379 ns | 0.2048 ns | 0.0116 ns |       0 B |
| CallInstanceMethod | 1.504 ns | 0.3503 ns | 0.0198 ns |       0 B |

# .NET Framework

|             Method |     Mean |     Error |    StdDev | Allocated |
|------------------- |---------:|----------:|----------:|----------:|
|         CallDirect | 1.465 ns | 0.2786 ns | 0.0157 ns |       0 B |
|   CallStaticMethod | 1.891 ns | 0.2470 ns | 0.0140 ns |       0 B |
| CallInstanceMethod | 1.447 ns | 0.1374 ns | 0.0078 ns |       0 B |
