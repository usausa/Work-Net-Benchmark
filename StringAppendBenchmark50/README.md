``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.388 (2004/?/20H1)
Intel Core i5-9500 CPU 3.00GHz, 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]    : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  MediumRun : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                        Method |      Mean |    Error |   StdDev |    Median |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------------ |----------:|---------:|---------:|----------:|-------:|-------:|------:|----------:|
|               StringLen32Add1 |  14.47 ns | 0.145 ns | 0.208 ns |  14.53 ns | 0.0187 |      - |     - |      88 B |
|        StringBuilderLen32Add1 |  31.18 ns | 0.154 ns | 0.230 ns |  31.20 ns | 0.0475 |      - |     - |     224 B |
|           PoolBufferLen32Add1 |  37.54 ns | 0.583 ns | 0.854 ns |  38.08 ns | 0.0187 |      - |     - |      88 B |
|   ThreadStaticBufferLen32Add1 |  18.76 ns | 0.076 ns | 0.114 ns |  18.74 ns | 0.0187 |      - |     - |      88 B |
|               StringLen64Add1 |  16.82 ns | 0.349 ns | 0.500 ns |  17.08 ns | 0.0306 |      - |     - |     144 B |
|        StringBuilderLen64Add1 |  36.53 ns | 0.182 ns | 0.260 ns |  36.55 ns | 0.0731 |      - |     - |     344 B |
|           PoolBufferLen64Add1 |  40.25 ns | 0.180 ns | 0.264 ns |  40.27 ns | 0.0306 |      - |     - |     144 B |
|   ThreadStaticBufferLen64Add1 |  22.65 ns | 0.211 ns | 0.281 ns |  22.57 ns | 0.0306 |      - |     - |     144 B |
|              StringLen128Add2 |  35.25 ns | 0.158 ns | 0.227 ns |  35.26 ns | 0.0663 |      - |     - |     312 B |
|       StringBuilderLen128Add2 |  46.73 ns | 0.630 ns | 0.923 ns |  46.50 ns | 0.1054 | 0.0001 |     - |     496 B |
|          PoolBufferLen128Add2 |  46.45 ns | 0.162 ns | 0.233 ns |  46.44 ns | 0.0357 |      - |     - |     168 B |
|  ThreadStaticBufferLen128Add2 |  28.35 ns | 0.525 ns | 0.770 ns |  28.88 ns | 0.0357 |      - |     - |     168 B |
|              StringLen128Add5 |  96.25 ns | 1.521 ns | 2.230 ns |  95.41 ns | 0.1971 | 0.0001 |     - |     928 B |
|       StringBuilderLen128Add5 |  66.49 ns | 1.002 ns | 1.438 ns |  67.08 ns | 0.1173 | 0.0002 |     - |     552 B |
|          PoolBufferLen128Add5 |  63.03 ns | 0.931 ns | 1.274 ns |  63.29 ns | 0.0476 |      - |     - |     224 B |
|  ThreadStaticBufferLen128Add5 |  44.51 ns | 0.137 ns | 0.201 ns |  44.49 ns | 0.0476 |      - |     - |     224 B |
|             StringLen1024Add2 | 152.90 ns | 0.766 ns | 1.023 ns | 153.26 ns | 0.5627 | 0.0029 |     - |    2648 B |
|      StringBuilderLen1024Add2 | 218.54 ns | 1.299 ns | 1.863 ns | 218.12 ns | 0.7529 | 0.0039 |     - |    3544 B |
|         PoolBufferLen1024Add2 | 133.92 ns | 2.353 ns | 3.449 ns | 133.69 ns | 0.3025 | 0.0015 |     - |    1424 B |
| ThreadStaticBufferLen1024Add2 | 113.29 ns | 2.588 ns | 3.874 ns | 115.06 ns | 0.3026 | 0.0016 |     - |    1424 B |
|             StringLen1024Add5 | 463.66 ns | 2.800 ns | 4.104 ns | 464.18 ns | 1.7256 | 0.0181 |     - |    8120 B |
|      StringBuilderLen1024Add5 | 286.59 ns | 1.834 ns | 2.688 ns | 286.42 ns | 0.8804 | 0.0137 |     - |    4144 B |
|         PoolBufferLen1024Add5 | 190.50 ns | 1.324 ns | 1.899 ns | 190.22 ns | 0.4299 | 0.0032 |     - |    2024 B |
| ThreadStaticBufferLen1024Add5 | 175.87 ns | 2.482 ns | 3.638 ns | 174.81 ns | 0.4299 | 0.0032 |     - |    2024 B |
