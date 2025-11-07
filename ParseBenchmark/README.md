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
| Method          | Job                 | Runtime   | Value    | Mean         | Error      | StdDev     | Median       | Min          | Max          | P90          | Code Size | Gen0   | Allocated |
|---------------- |-------------------- |---------- |--------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------------:|----------:|-------:|----------:|
| **ParseByTryParse** | **MediumRun-.NET 10.0** | **.NET 10.0** | **0**        |     **2.461 ns** |  **0.0276 ns** |  **0.0413 ns** |     **2.449 ns** |     **2.411 ns** |     **2.584 ns** |     **2.511 ns** |   **1,683 B** |      **-** |         **-** |
| ParseByParse    | MediumRun-.NET 10.0 | .NET 10.0 | 0        |     6.582 ns |  0.0153 ns |  0.0229 ns |     6.579 ns |     6.549 ns |     6.626 ns |     6.619 ns |   1,780 B |      - |         - |
| ParseByTryParse | MediumRun-.NET 8.0  | .NET 8.0  | 0        |     3.028 ns |  0.0138 ns |  0.0206 ns |     3.026 ns |     2.991 ns |     3.068 ns |     3.051 ns |   1,714 B |      - |         - |
| ParseByParse    | MediumRun-.NET 8.0  | .NET 8.0  | 0        |     7.213 ns |  0.4699 ns |  0.6887 ns |     6.588 ns |     6.522 ns |     7.965 ns |     7.933 ns |   1,841 B |      - |         - |
| ParseByTryParse | MediumRun-.NET 9.0  | .NET 9.0  | 0        |     2.472 ns |  0.0236 ns |  0.0352 ns |     2.457 ns |     2.435 ns |     2.578 ns |     2.514 ns |   1,721 B |      - |         - |
| ParseByParse    | MediumRun-.NET 9.0  | .NET 9.0  | 0        |     6.785 ns |  0.0139 ns |  0.0194 ns |     6.787 ns |     6.748 ns |     6.834 ns |     6.808 ns |   1,859 B |      - |         - |
| **ParseByTryParse** | **MediumRun-.NET 10.0** | **.NET 10.0** | **1234**     |     **3.296 ns** |  **0.0292 ns** |  **0.0428 ns** |     **3.296 ns** |     **3.231 ns** |     **3.403 ns** |     **3.355 ns** |   **1,678 B** |      **-** |         **-** |
| ParseByParse    | MediumRun-.NET 10.0 | .NET 10.0 | 1234     |     9.006 ns |  0.0182 ns |  0.0266 ns |     9.001 ns |     8.972 ns |     9.057 ns |     9.043 ns |   1,775 B |      - |         - |
| ParseByTryParse | MediumRun-.NET 8.0  | .NET 8.0  | 1234     |     4.164 ns |  0.0467 ns |  0.0684 ns |     4.144 ns |     4.074 ns |     4.378 ns |     4.243 ns |   1,735 B |      - |         - |
| ParseByParse    | MediumRun-.NET 8.0  | .NET 8.0  | 1234     |     8.777 ns |  0.0818 ns |  0.1225 ns |     8.786 ns |     8.612 ns |     9.010 ns |     8.948 ns |   1,862 B |      - |         - |
| ParseByTryParse | MediumRun-.NET 9.0  | .NET 9.0  | 1234     |     3.912 ns |  0.0347 ns |  0.0519 ns |     3.904 ns |     3.837 ns |     4.028 ns |     3.986 ns |   1,733 B |      - |         - |
| ParseByParse    | MediumRun-.NET 9.0  | .NET 9.0  | 1234     |     9.250 ns |  0.0235 ns |  0.0337 ns |     9.243 ns |     9.197 ns |     9.342 ns |     9.292 ns |   1,871 B |      - |         - |
| **ParseByTryParse** | **MediumRun-.NET 10.0** | **.NET 10.0** | **12345678** |     **5.105 ns** |  **0.0389 ns** |  **0.0570 ns** |     **5.080 ns** |     **5.037 ns** |     **5.232 ns** |     **5.199 ns** |   **1,680 B** |      **-** |         **-** |
| ParseByParse    | MediumRun-.NET 10.0 | .NET 10.0 | 12345678 |    12.254 ns |  0.0384 ns |  0.0562 ns |    12.259 ns |    12.156 ns |    12.358 ns |    12.328 ns |   1,777 B |      - |         - |
| ParseByTryParse | MediumRun-.NET 8.0  | .NET 8.0  | 12345678 |     5.383 ns |  0.0439 ns |  0.0657 ns |     5.377 ns |     5.294 ns |     5.497 ns |     5.478 ns |   1,735 B |      - |         - |
| ParseByParse    | MediumRun-.NET 8.0  | .NET 8.0  | 12345678 |    11.899 ns |  0.0349 ns |  0.0511 ns |    11.891 ns |    11.827 ns |    12.031 ns |    11.957 ns |   1,843 B |      - |         - |
| ParseByTryParse | MediumRun-.NET 9.0  | .NET 9.0  | 12345678 |     5.126 ns |  0.0373 ns |  0.0522 ns |     5.116 ns |     5.061 ns |     5.240 ns |     5.195 ns |   1,733 B |      - |         - |
| ParseByParse    | MediumRun-.NET 9.0  | .NET 9.0  | 12345678 |    12.440 ns |  0.0283 ns |  0.0414 ns |    12.437 ns |    12.384 ns |    12.556 ns |    12.492 ns |   1,871 B |      - |         - |
| **ParseByTryParse** | **MediumRun-.NET 10.0** | **.NET 10.0** | **x**        |     **2.268 ns** |  **0.0165 ns** |  **0.0247 ns** |     **2.264 ns** |     **2.237 ns** |     **2.318 ns** |     **2.303 ns** |   **1,658 B** |      **-** |         **-** |
| ParseByParse    | MediumRun-.NET 10.0 | .NET 10.0 | x        | 1,222.429 ns |  8.6081 ns | 12.3455 ns | 1,219.194 ns | 1,204.864 ns | 1,244.902 ns | 1,239.081 ns |   4,855 B | 0.0547 |     464 B |
| ParseByTryParse | MediumRun-.NET 8.0  | .NET 8.0  | x        |     2.455 ns |  0.1249 ns |  0.1869 ns |     2.472 ns |     2.247 ns |     2.688 ns |     2.657 ns |   1,662 B |      - |         - |
| ParseByParse    | MediumRun-.NET 8.0  | .NET 8.0  | x        | 3,254.832 ns | 28.5144 ns | 42.6790 ns | 3,238.083 ns | 3,200.513 ns | 3,359.141 ns | 3,314.465 ns |   2,226 B | 0.0547 |     488 B |
| ParseByTryParse | MediumRun-.NET 9.0  | .NET 9.0  | x        |     2.277 ns |  0.0208 ns |  0.0312 ns |     2.269 ns |     2.239 ns |     2.350 ns |     2.313 ns |   1,709 B |      - |         - |
| ParseByParse    | MediumRun-.NET 9.0  | .NET 9.0  | x        | 1,676.813 ns | 13.3948 ns | 20.0487 ns | 1,675.275 ns | 1,645.879 ns | 1,723.910 ns | 1,699.954 ns |   2,474 B | 0.0547 |     464 B |

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
