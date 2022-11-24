``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.819)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=7.0.100
  [Host]    : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  MediumRun : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2

Job=MediumRun  Jit=RyuJit  Platform=X64  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
|     Method |  Runtime |     Mean |     Error |    StdDev |   Median |      Min |      Max |      P90 | Code Size | Allocated |
|----------- |--------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|----------:|----------:|
|  Interface | .NET 6.0 | 1.392 ns | 0.0701 ns | 0.1049 ns | 1.395 ns | 1.282 ns | 1.506 ns | 1.501 ns |      48 B |         - |
|   Abstract | .NET 6.0 | 1.070 ns | 0.0019 ns | 0.0028 ns | 1.070 ns | 1.065 ns | 1.075 ns | 1.073 ns |      42 B |         - |
|  Abstract2 | .NET 6.0 | 1.071 ns | 0.0023 ns | 0.0032 ns | 1.072 ns | 1.066 ns | 1.078 ns | 1.075 ns |      42 B |         - |
|       Func | .NET 6.0 | 1.282 ns | 0.0047 ns | 0.0068 ns | 1.281 ns | 1.274 ns | 1.302 ns | 1.290 ns |      39 B |         - |
| Interface4 | .NET 6.0 | 5.794 ns | 0.0302 ns | 0.0433 ns | 5.789 ns | 5.750 ns | 5.915 ns | 5.855 ns |      48 B |         - |
|  Abstract4 | .NET 6.0 | 4.485 ns | 0.0082 ns | 0.0121 ns | 4.484 ns | 4.465 ns | 4.511 ns | 4.499 ns |      44 B |         - |
|      Func4 | .NET 6.0 | 5.649 ns | 0.0781 ns | 0.1094 ns | 5.722 ns | 5.518 ns | 5.813 ns | 5.770 ns |      39 B |         - |
|  Interface | .NET 7.0 | 1.494 ns | 0.0038 ns | 0.0056 ns | 1.496 ns | 1.486 ns | 1.506 ns | 1.501 ns |      45 B |         - |
|   Abstract | .NET 7.0 | 1.070 ns | 0.0017 ns | 0.0025 ns | 1.070 ns | 1.066 ns | 1.075 ns | 1.073 ns |      42 B |         - |
|  Abstract2 | .NET 7.0 | 1.069 ns | 0.0018 ns | 0.0027 ns | 1.070 ns | 1.064 ns | 1.074 ns | 1.073 ns |      42 B |         - |
|       Func | .NET 7.0 | 1.282 ns | 0.0037 ns | 0.0050 ns | 1.283 ns | 1.275 ns | 1.296 ns | 1.286 ns |      39 B |         - |
| Interface4 | .NET 7.0 | 6.104 ns | 0.0757 ns | 0.1086 ns | 6.176 ns | 5.963 ns | 6.247 ns | 6.216 ns |      45 B |         - |
|  Abstract4 | .NET 7.0 | 4.902 ns | 0.0075 ns | 0.0112 ns | 4.898 ns | 4.886 ns | 4.924 ns | 4.918 ns |      44 B |         - |
|      Func4 | .NET 7.0 | 5.764 ns | 0.0096 ns | 0.0138 ns | 5.762 ns | 5.742 ns | 5.791 ns | 5.781 ns |      36 B |         - |
