```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.6901)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

InvocationCount=1  IterationCount=15  LaunchCount=2  
UnrollFactor=1  WarmupCount=10  
```
| Method                     | Job                 | Runtime   | Categories | Loop | Mean           | Error         | StdDev        | Median         | Min            | Max            | P90            | Code Size | Allocated |
|--------------------------- |-------------------- |---------- |----------- |----- |---------------:|--------------:|--------------:|---------------:|---------------:|---------------:|---------------:|----------:|----------:|
| **AddDefault**                 | **MediumRun-.NET 10.0** | **.NET 10.0** | **Add**        | **1**    |     **19.2308 ns** |    **35.9046 ns** |    **49.1466 ns** |      **0.0000 ns** |      **0.0000 ns** |    **200.0000 ns** |    **100.0000 ns** |     **280 B** |         **-** |
| AddByReference             | MediumRun-.NET 10.0 | .NET 10.0 | Add        | 1    |    593.1034 ns |   193.7634 ns |   284.0159 ns |    700.0000 ns |      0.0000 ns |  1,000.0000 ns |    840.0000 ns |     298 B |         - |
| AddDefault                 | MediumRun-.NET 8.0  | .NET 8.0  | Add        | 1    |    598.3333 ns |   180.9577 ns |   270.8490 ns |    650.0000 ns |      0.0000 ns |  1,000.0000 ns |    850.0000 ns |     283 B |         - |
| AddByReference             | MediumRun-.NET 8.0  | .NET 8.0  | Add        | 1    |    563.3333 ns |   207.2178 ns |   310.1538 ns |    650.0000 ns |      0.0000 ns |  1,100.0000 ns |    920.0000 ns |     300 B |         - |
| AddDefault                 | MediumRun-.NET 9.0  | .NET 9.0  | Add        | 1    |    491.3793 ns |   188.6218 ns |   276.4795 ns |    650.0000 ns |      0.0000 ns |    950.0000 ns |    750.0000 ns |     280 B |         - |
| AddByReference             | MediumRun-.NET 9.0  | .NET 9.0  | Add        | 1    |    482.7586 ns |   210.5286 ns |   308.5901 ns |    650.0000 ns |      0.0000 ns |  1,000.0000 ns |    750.0000 ns |     300 B |         - |
| **AddDefault**                 | **MediumRun-.NET 10.0** | **.NET 10.0** | **Add**        | **1000** | **17,913.7931 ns** | **1,098.5046 ns** | **1,610.1739 ns** | **17,300.0000 ns** | **15,300.0000 ns** | **21,200.0000 ns** | **20,360.0000 ns** |     **280 B** |         **-** |
| AddByReference             | MediumRun-.NET 10.0 | .NET 10.0 | Add        | 1000 | 18,736.2069 ns | 2,164.3135 ns | 3,172.4229 ns | 18,350.0000 ns | 14,400.0000 ns | 25,150.0000 ns | 23,490.0000 ns |     298 B |         - |
| AddDefault                 | MediumRun-.NET 8.0  | .NET 8.0  | Add        | 1000 | 18,603.5714 ns |   969.4146 ns | 1,390.3056 ns | 18,650.0000 ns | 14,900.0000 ns | 21,600.0000 ns | 20,260.0000 ns |     283 B |         - |
| AddByReference             | MediumRun-.NET 8.0  | .NET 8.0  | Add        | 1000 | 19,822.2222 ns | 1,450.1236 ns | 2,032.8709 ns | 20,300.0000 ns | 15,300.0000 ns | 23,100.0000 ns | 22,140.0000 ns |     300 B |         - |
| AddDefault                 | MediumRun-.NET 9.0  | .NET 9.0  | Add        | 1000 | 16,317.8571 ns | 1,593.7529 ns | 2,285.7130 ns | 16,150.0000 ns | 13,000.0000 ns | 22,000.0000 ns | 19,700.0000 ns |     280 B |         - |
| AddByReference             | MediumRun-.NET 9.0  | .NET 9.0  | Add        | 1000 | 19,082.7586 ns | 1,379.2456 ns | 2,021.6805 ns | 18,500.0000 ns | 15,900.0000 ns | 23,000.0000 ns | 22,400.0000 ns |     300 B |         - |
| **UpdateDefault**              | **MediumRun-.NET 10.0** | **.NET 10.0** | **Update**     | **1**    |     **46.1538 ns** |    **47.2590 ns** |    **64.6886 ns** |      **0.0000 ns** |      **0.0000 ns** |    **200.0000 ns** |    **100.0000 ns** |     **309 B** |         **-** |
| UpdateByReference          | MediumRun-.NET 10.0 | .NET 10.0 | Update     | 1    |     32.0000 ns |    51.7173 ns |    69.0411 ns |      0.0000 ns |      0.0000 ns |    200.0000 ns |    160.0000 ns |     492 B |         - |
| UpdateByReferenceWithCheck | MediumRun-.NET 10.0 | .NET 10.0 | Update     | 1    |    137.0370 ns |   185.7506 ns |   260.3964 ns |    100.0000 ns |      0.0000 ns |  1,000.0000 ns |    400.0000 ns |     514 B |         - |
| UpdateDefault              | MediumRun-.NET 8.0  | .NET 8.0  | Update     | 1    |    265.5172 ns |   258.0355 ns |   378.2250 ns |    100.0000 ns |      0.0000 ns |  1,000.0000 ns |    920.0000 ns |     309 B |         - |
| UpdateByReference          | MediumRun-.NET 8.0  | .NET 8.0  | Update     | 1    |      0.0000 ns |     0.0000 ns |     0.0000 ns |      0.0000 ns |      0.0000 ns |      0.0000 ns |      0.0000 ns |     486 B |         - |
| UpdateByReferenceWithCheck | MediumRun-.NET 8.0  | .NET 8.0  | Update     | 1    |    220.6897 ns |   216.0313 ns |   316.6559 ns |      0.0000 ns |      0.0000 ns |    800.0000 ns |    720.0000 ns |     508 B |         - |
| UpdateDefault              | MediumRun-.NET 9.0  | .NET 9.0  | Update     | 1    |    200.0000 ns |   244.7199 ns |   343.0631 ns |    100.0000 ns |      0.0000 ns |  1,200.0000 ns |    520.0000 ns |     309 B |         - |
| UpdateByReference          | MediumRun-.NET 9.0  | .NET 9.0  | Update     | 1    |    200.0000 ns |   199.9373 ns |   286.7442 ns |    100.0000 ns |      0.0000 ns |    900.0000 ns |    700.0000 ns |     489 B |         - |
| UpdateByReferenceWithCheck | MediumRun-.NET 9.0  | .NET 9.0  | Update     | 1    |    390.7407 ns |   246.1228 ns |   345.0298 ns |    500.0000 ns |      0.0000 ns |  1,000.0000 ns |    800.0000 ns |     511 B |         - |
| **UpdateDefault**              | **MediumRun-.NET 10.0** | **.NET 10.0** | **Update**     | **1000** | **25,680.3571 ns** | **2,172.5870 ns** | **3,115.8596 ns** | **26,625.0000 ns** | **19,900.0000 ns** | **33,000.0000 ns** | **29,240.0000 ns** |     **309 B** |         **-** |
| UpdateByReference          | MediumRun-.NET 10.0 | .NET 10.0 | Update     | 1000 | 17,376.6667 ns | 1,676.8292 ns | 2,509.7992 ns | 16,100.0000 ns | 14,400.0000 ns | 22,300.0000 ns | 20,660.0000 ns |     492 B |         - |
| UpdateByReferenceWithCheck | MediumRun-.NET 10.0 | .NET 10.0 | Update     | 1000 | 20,783.3333 ns | 2,290.0804 ns | 3,427.6848 ns | 19,550.0000 ns | 16,100.0000 ns | 27,200.0000 ns | 25,770.0000 ns |     514 B |         - |
| UpdateDefault              | MediumRun-.NET 8.0  | .NET 8.0  | Update     | 1000 | 26,133.3333 ns | 3,459.0517 ns | 4,849.1078 ns | 26,900.0000 ns | 19,000.0000 ns | 32,700.0000 ns | 31,980.0000 ns |     309 B |         - |
| UpdateByReference          | MediumRun-.NET 8.0  | .NET 8.0  | Update     | 1000 | 17,162.0690 ns | 1,711.4218 ns | 2,508.5801 ns | 17,600.0000 ns | 12,100.0000 ns | 21,700.0000 ns | 20,310.0000 ns |     486 B |         - |
| UpdateByReferenceWithCheck | MediumRun-.NET 8.0  | .NET 8.0  | Update     | 1000 | 20,624.1379 ns | 1,826.3948 ns | 2,677.1060 ns | 19,100.0000 ns | 17,000.0000 ns | 26,100.0000 ns | 24,580.0000 ns |     508 B |         - |
| UpdateDefault              | MediumRun-.NET 9.0  | .NET 9.0  | Update     | 1000 | 24,796.5517 ns | 2,059.1096 ns | 3,018.2165 ns | 24,300.0000 ns | 18,900.0000 ns | 29,400.0000 ns | 28,340.0000 ns |     309 B |         - |
| UpdateByReference          | MediumRun-.NET 9.0  | .NET 9.0  | Update     | 1000 | 18,134.4828 ns | 1,617.5330 ns | 2,370.9591 ns | 18,450.0000 ns | 14,400.0000 ns | 22,250.0000 ns | 20,990.0000 ns |     489 B |         - |
| UpdateByReferenceWithCheck | MediumRun-.NET 9.0  | .NET 9.0  | Update     | 1000 | 20,566.6667 ns | 2,053.1489 ns | 3,073.0568 ns | 19,200.0000 ns | 17,700.0000 ns | 28,800.0000 ns | 25,330.0000 ns |     511 B |         - |


```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4112/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  InvocationCount=1  IterationCount=15  
LaunchCount=2  UnrollFactor=1  WarmupCount=10  
```

| Method                     | Categories | Loop | Mean        | Error       | StdDev     | Min         | Max         | P90         | Code Size | Allocated |
|--------------------------- |----------- |----- |------------:|------------:|-----------:|------------:|------------:|------------:|----------:|----------:|
| **AddDefault**                 | **Add**        | **1**    |    **581.5 ns** |   **175.89 ns** |   **246.6 ns** |    **300.0 ns** |  **1,300.0 ns** |    **940.0 ns** |     **205 B** |     **400 B** |
| AddByReference             | Add        | 1    |    563.0 ns |   187.85 ns |   263.3 ns |    200.0 ns |  1,100.0 ns |    800.0 ns |     300 B |     400 B |
| **AddDefault**                 | **Add**        | **1000** | **17,310.7 ns** | **1,470.13 ns** | **2,108.4 ns** | **14,700.0 ns** | **22,100.0 ns** | **20,830.0 ns** |     **205 B** |     **400 B** |
| AddByReference             | Add        | 1000 | 18,110.7 ns |   806.05 ns | 1,156.0 ns | 16,600.0 ns | 21,750.0 ns | 19,365.0 ns |     300 B |     400 B |
| **UpdateDefault**              | **Update**     | **1**    |    **533.3 ns** |   **131.69 ns** |   **197.1 ns** |    **300.0 ns** |    **900.0 ns** |    **800.0 ns** |     **396 B** |     **400 B** |
| UpdateByReference          | Update     | 1    |    416.7 ns |   103.92 ns |   155.5 ns |    200.0 ns |    700.0 ns |    600.0 ns |     735 B |     400 B |
| UpdateByReferenceWithCheck | Update     | 1    |    346.7 ns |    75.94 ns |   113.7 ns |    200.0 ns |    600.0 ns |    500.0 ns |     757 B |     400 B |
| **UpdateDefault**              | **Update**     | **1000** | **25,917.9 ns** | **1,718.05 ns** | **2,464.0 ns** | **24,000.0 ns** | **32,500.0 ns** | **30,410.0 ns** |     **396 B** |     **400 B** |
| UpdateByReference          | Update     | 1000 | 17,128.6 ns | 1,129.40 ns | 1,619.8 ns | 15,100.0 ns | 22,000.0 ns | 19,500.0 ns |     735 B |     400 B |
| UpdateByReferenceWithCheck | Update     | 1000 | 22,975.9 ns | 2,294.47 ns | 3,363.2 ns | 19,500.0 ns | 31,300.0 ns | 29,600.0 ns |     757 B |     400 B |
