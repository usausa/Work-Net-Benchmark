```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
```
| Method                   | Value            | Mean       | Error     | StdDev    | Min        | Max        | P90        | Code Size | Allocated |
|------------------------- |----------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|----------:|----------:|
| **DefaultOrdinal**           | **Id**               |  **2.7011 ns** | **0.0531 ns** | **0.0545 ns** |  **2.6181 ns** |  **2.8127 ns** |  **2.7743 ns** |     **373 B** |         **-** |
| DefaultOrdinalIgnoreCase | Id               |  3.1296 ns | 0.0604 ns | 0.0886 ns |  3.0325 ns |  3.3181 ns |  3.2694 ns |     353 B |         - |
| CustomOrdinal            | Id               |  0.4515 ns | 0.0091 ns | 0.0130 ns |  0.4365 ns |  0.4791 ns |  0.4688 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | Id               |  0.6811 ns | 0.0134 ns | 0.0178 ns |  0.6572 ns |  0.7195 ns |  0.7072 ns |     131 B |         - |
| **DefaultOrdinal**           | **Name**             |  **3.3903 ns** | **0.0670 ns** | **0.0872 ns** |  **3.2869 ns** |  **3.5636 ns** |  **3.5173 ns** |     **369 B** |         **-** |
| DefaultOrdinalIgnoreCase | Name             |  4.2501 ns | 0.0843 ns | 0.1287 ns |  4.1029 ns |  4.4959 ns |  4.4203 ns |     344 B |         - |
| CustomOrdinal            | Name             |  1.0440 ns | 0.0208 ns | 0.0285 ns |  1.0033 ns |  1.1001 ns |  1.0837 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | Name             |  1.2179 ns | 0.0243 ns | 0.0486 ns |  1.1432 ns |  1.3120 ns |  1.2854 ns |     131 B |         - |
| **DefaultOrdinal**           | **XxxxXxxx**         |  **4.8506 ns** | **0.0956 ns** | **0.1243 ns** |  **4.6756 ns** |  **5.1701 ns** |  **4.9953 ns** |     **369 B** |         **-** |
| DefaultOrdinalIgnoreCase | XxxxXxxx         |  6.6178 ns | 0.0368 ns | 0.0307 ns |  6.5776 ns |  6.6814 ns |  6.6493 ns |     347 B |         - |
| CustomOrdinal            | XxxxXxxx         |  2.0589 ns | 0.0407 ns | 0.0795 ns |  1.8833 ns |  2.2143 ns |  2.1493 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | XxxxXxxx         |  2.3264 ns | 0.0455 ns | 0.0797 ns |  2.2159 ns |  2.4565 ns |  2.4343 ns |     131 B |         - |
| **DefaultOrdinal**           | **XxxxXxxxXxxxXxxx** |  **8.7190 ns** | **0.1704 ns** | **0.2602 ns** |  **8.4158 ns** |  **9.2720 ns** |  **9.0832 ns** |     **371 B** |         **-** |
| DefaultOrdinalIgnoreCase | XxxxXxxxXxxxXxxx | 11.7677 ns | 0.2323 ns | 0.3256 ns | 11.3033 ns | 12.4248 ns | 12.2141 ns |     347 B |         - |
| CustomOrdinal            | XxxxXxxxXxxxXxxx |  4.0192 ns | 0.0801 ns | 0.1200 ns |  3.8197 ns |  4.2884 ns |  4.1449 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | XxxxXxxxXxxxXxxx |  4.2307 ns | 0.0833 ns | 0.1321 ns |  3.9848 ns |  4.4931 ns |  4.3971 ns |     131 B |         - |
