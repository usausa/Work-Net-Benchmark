REA```

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
