```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3958/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

```
| Method                | Loop | Mean       | Error     | StdDev    | Min        | Max       | P90        | Code Size | Allocated |
|---------------------- |----- |-----------:|----------:|----------:|-----------:|----------:|-----------:|----------:|----------:|
| **WriteBinaryPrimitive**  | **1**    |  **1.6008 ns** | **0.0539 ns** | **0.0840 ns** |  **1.5013 ns** |  **1.755 ns** |  **1.7231 ns** |     **202 B** |         **-** |
| WriteBinaryPrimitive2 | 1    |  1.1287 ns | 0.0388 ns | 0.0416 ns |  1.0973 ns |  1.216 ns |  1.2025 ns |     155 B |         - |
| WriteMemoryMarshal    | 1    |  1.5785 ns | 0.0532 ns | 0.0729 ns |  1.4798 ns |  1.693 ns |  1.6630 ns |     198 B |         - |
| WriteMemoryMarshal2   | 1    |  1.1066 ns | 0.0428 ns | 0.0458 ns |  1.0562 ns |  1.208 ns |  1.1713 ns |     159 B |         - |
| WriteUnsafe           | 1    |  0.9253 ns | 0.0408 ns | 0.0485 ns |  0.8648 ns |  1.014 ns |  0.9709 ns |     131 B |         - |
| **WriteBinaryPrimitive**  | **4**    |  **3.9459 ns** | **0.1011 ns** | **0.1482 ns** |  **3.7458 ns** |  **4.201 ns** |  **4.1389 ns** |     **202 B** |         **-** |
| WriteBinaryPrimitive2 | 4    |  2.2792 ns | 0.0661 ns | 0.0860 ns |  2.1822 ns |  2.431 ns |  2.4052 ns |     155 B |         - |
| WriteMemoryMarshal    | 4    |  3.8665 ns | 0.1003 ns | 0.1470 ns |  3.6216 ns |  4.142 ns |  4.0338 ns |     198 B |         - |
| WriteMemoryMarshal2   | 4    |  2.1160 ns | 0.0442 ns | 0.0369 ns |  2.0665 ns |  2.192 ns |  2.1674 ns |     159 B |         - |
| WriteUnsafe           | 4    |  1.5508 ns | 0.0529 ns | 0.0630 ns |  1.4929 ns |  1.701 ns |  1.6226 ns |     131 B |         - |
| **WriteBinaryPrimitive**  | **64**   | **53.0233 ns** | **0.9665 ns** | **0.8071 ns** | **50.8778 ns** | **54.319 ns** | **53.5892 ns** |     **202 B** |         **-** |
| WriteBinaryPrimitive2 | 64   | 38.6030 ns | 0.6387 ns | 0.5975 ns | 37.4562 ns | 39.665 ns | 39.2378 ns |     155 B |         - |
| WriteMemoryMarshal    | 64   | 51.6207 ns | 1.0486 ns | 1.1220 ns | 49.7895 ns | 53.497 ns | 53.1315 ns |     198 B |         - |
| WriteMemoryMarshal2   | 64   | 34.4517 ns | 0.5516 ns | 0.4606 ns | 33.9090 ns | 35.434 ns | 35.0502 ns |     159 B |         - |
| WriteUnsafe           | 64   | 18.9657 ns | 0.3960 ns | 0.5008 ns | 18.3755 ns | 19.870 ns | 19.5955 ns |     131 B |         - |
