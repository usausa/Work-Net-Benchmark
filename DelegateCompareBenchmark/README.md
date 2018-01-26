# DelegateCompareBenchmark

# .NET Core

|             Method |     Mean |     Error |    StdDev | Allocated |
|------------------- |---------:|----------:|----------:|----------:|
|         CallDirect | 1.787 ns | 0.2376 ns | 0.0134 ns |       0 B |
|   CallStaticMethod | 2.369 ns | 0.2570 ns | 0.0145 ns |       0 B |
| CallInstanceMethod | 1.540 ns | 0.2750 ns | 0.0155 ns |       0 B |
|        CallDynamic | 1.403 ns | 0.7042 ns | 0.0398 ns |       0 B |

# .NET Framework

|             Method |     Mean |     Error |    StdDev | Allocated |
|------------------- |---------:|----------:|----------:|----------:|
|         CallDirect | 1.736 ns | 0.1731 ns | 0.0098 ns |       0 B |
|   CallStaticMethod | 1.884 ns | 0.1907 ns | 0.0108 ns |       0 B |
| CallInstanceMethod | 1.715 ns | 0.3316 ns | 0.0187 ns |       0 B |
|        CallDynamic | 1.093 ns | 0.3110 ns | 0.0176 ns |       0 B |
