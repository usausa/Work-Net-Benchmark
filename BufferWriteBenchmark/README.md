```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3958/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
```
| Method                | Loop | Mean        | Error     | StdDev    | Min         | Max         | P90         | Code Size | Allocated |
|---------------------- |----- |------------:|----------:|----------:|------------:|------------:|------------:|----------:|----------:|
| **WriteBinaryPrimitive**  | **1**    |   **1.0060 ns** | **0.0424 ns** | **0.0580 ns** |   **0.9336 ns** |   **1.1036 ns** |   **1.0963 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 1    |   0.3945 ns | 0.0238 ns | 0.0244 ns |   0.3766 ns |   0.4612 ns |   0.4259 ns |      87 B |         - |
| WriteMemoryMarshal    | 1    |   0.9896 ns | 0.0370 ns | 0.0346 ns |   0.9473 ns |   1.0704 ns |   1.0241 ns |     132 B |         - |
| WriteMemoryMarshal2   | 1    |   0.2352 ns | 0.0252 ns | 0.0236 ns |   0.2030 ns |   0.2682 ns |   0.2621 ns |      81 B |         - |
| WriteUnsafe           | 1    |   0.2111 ns | 0.0243 ns | 0.0227 ns |   0.1826 ns |   0.2466 ns |   0.2403 ns |      42 B |         - |
| WriteUnsafe2          | 1    |   0.2154 ns | 0.0228 ns | 0.0213 ns |   0.1857 ns |   0.2481 ns |   0.2451 ns |      42 B |         - |
| WritePointer          | 1    |   0.6703 ns | 0.0356 ns | 0.0316 ns |   0.6236 ns |   0.7250 ns |   0.7068 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **4**    |   **3.2514 ns** | **0.0759 ns** | **0.0710 ns** |   **3.1641 ns** |   **3.4202 ns** |   **3.3316 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 4    |   1.5305 ns | 0.0431 ns | 0.0403 ns |   1.4796 ns |   1.6149 ns |   1.5890 ns |      88 B |         - |
| WriteMemoryMarshal    | 4    |   3.1099 ns | 0.0730 ns | 0.0683 ns |   3.0077 ns |   3.2393 ns |   3.1646 ns |     132 B |         - |
| WriteMemoryMarshal2   | 4    |   1.4019 ns | 0.0467 ns | 0.0437 ns |   1.3535 ns |   1.5059 ns |   1.4459 ns |      82 B |         - |
| WriteUnsafe           | 4    |   0.8126 ns | 0.0242 ns | 0.0215 ns |   0.7737 ns |   0.8549 ns |   0.8396 ns |      50 B |         - |
| WriteUnsafe2          | 4    |   0.8041 ns | 0.0338 ns | 0.0317 ns |   0.7468 ns |   0.8591 ns |   0.8494 ns |      42 B |         - |
| WritePointer          | 4    |   1.2631 ns | 0.0376 ns | 0.0333 ns |   1.2255 ns |   1.3308 ns |   1.3125 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **64**   |  **42.7789 ns** | **0.8664 ns** | **1.7502 ns** |  **39.0179 ns** |  **46.7851 ns** |  **44.9371 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 64   |  27.9993 ns | 0.5822 ns | 0.5161 ns |  27.5647 ns |  29.0773 ns |  28.8928 ns |      88 B |         - |
| WriteMemoryMarshal    | 64   |  39.0198 ns | 0.7906 ns | 1.1834 ns |  36.7691 ns |  40.9295 ns |  40.0437 ns |     132 B |         - |
| WriteMemoryMarshal2   | 64   |  28.1374 ns | 0.4709 ns | 0.4405 ns |  27.4579 ns |  28.6759 ns |  28.6458 ns |      82 B |         - |
| WriteUnsafe           | 64   |  14.9488 ns | 0.2374 ns | 0.2104 ns |  14.6396 ns |  15.2955 ns |  15.2502 ns |      50 B |         - |
| WriteUnsafe2          | 64   |  15.2457 ns | 0.3272 ns | 0.3061 ns |  14.7301 ns |  15.8479 ns |  15.6234 ns |      50 B |         - |
| WritePointer          | 64   |  16.1589 ns | 0.3447 ns | 0.3385 ns |  15.6231 ns |  16.9079 ns |  16.5373 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **256**  | **160.4883 ns** | **2.5222 ns** | **2.3593 ns** | **156.8146 ns** | **164.3575 ns** | **163.3050 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 256  | 116.6475 ns | 2.3440 ns | 2.1926 ns | 113.9860 ns | 120.4243 ns | 119.8031 ns |      88 B |         - |
| WriteMemoryMarshal    | 256  | 147.6488 ns | 2.9073 ns | 2.8554 ns | 144.3859 ns | 152.4102 ns | 151.4242 ns |     132 B |         - |
| WriteMemoryMarshal2   | 256  | 116.9340 ns | 2.3539 ns | 2.3118 ns | 114.3158 ns | 120.6539 ns | 120.0774 ns |      82 B |         - |
| WriteUnsafe           | 256  |  61.3442 ns | 1.0409 ns | 0.9736 ns |  60.1629 ns |  63.6522 ns |  62.4169 ns |      50 B |         - |
| WriteUnsafe2          | 256  |  61.5637 ns | 1.2451 ns | 1.6190 ns |  59.9485 ns |  65.6981 ns |  63.4379 ns |      50 B |         - |
| WritePointer          | 256  |  63.7674 ns | 1.2606 ns | 1.5942 ns |  61.6459 ns |  66.9896 ns |  66.1297 ns |      77 B |         - |
