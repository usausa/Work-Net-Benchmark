```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
```
| Method          | Value    | Mean         | Error      | StdDev     | Min          | Max          | P90          | Gen0   | Code Size | Allocated |
|---------------- |--------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------:|----------:|----------:|
| **ParseByTryParse** | **0**        |     **4.206 ns** |  **0.0816 ns** |  **0.1221 ns** |     **4.064 ns** |     **4.471 ns** |     **4.379 ns** |      **-** |     **356 B** |         **-** |
| ParseByParse    | 0        |     8.926 ns |  0.1772 ns |  0.2041 ns |     8.657 ns |     9.237 ns |     9.217 ns |      - |     582 B |         - |
| **ParseByTryParse** | **1234**     |     **5.742 ns** |  **0.1120 ns** |  **0.1245 ns** |     **5.540 ns** |     **6.035 ns** |     **5.880 ns** |      **-** |     **356 B** |         **-** |
| ParseByParse    | 1234     |    11.202 ns |  0.2218 ns |  0.1966 ns |    10.869 ns |    11.531 ns |    11.460 ns |      - |     582 B |         - |
| **ParseByTryParse** | **12345678** |     **7.816 ns** |  **0.1558 ns** |  **0.2283 ns** |     **7.462 ns** |     **8.196 ns** |     **8.124 ns** |      **-** |     **356 B** |         **-** |
| ParseByParse    | 12345678 |    15.004 ns |  0.2899 ns |  0.2570 ns |    14.525 ns |    15.217 ns |    15.209 ns |      - |     582 B |         - |
| **ParseByTryParse** | **x**        |     **4.171 ns** |  **0.0817 ns** |  **0.1222 ns** |     **4.040 ns** |     **4.441 ns** |     **4.324 ns** |      **-** |     **356 B** |         **-** |
| ParseByParse    | x        | 2,232.649 ns | 44.5117 ns | 41.6362 ns | 2,182.967 ns | 2,330.828 ns | 2,271.522 ns | 0.0273 |     582 B |     464 B |
