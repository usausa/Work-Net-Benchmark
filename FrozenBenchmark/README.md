```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.7019)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method                              | Job                 | Runtime   | Items | Mean          | Error        | StdDev       | Min           | Max           | P90           | Gen0    | Code Size | Gen1   | Allocated |
|------------------------------------ |-------------------- |---------- |------ |--------------:|-------------:|-------------:|--------------:|--------------:|--------------:|--------:|----------:|-------:|----------:|
| **ConstructDictionary**                 | **MediumRun-.NET 10.0** | **.NET 10.0** | **32**    |     **294.55 ns** |     **4.009 ns** |     **6.001 ns** |     **284.96 ns** |     **310.60 ns** |     **301.21 ns** |  **0.1392** |   **2,300 B** |      **-** |    **1168 B** |
| ConstructReadOnlyDictionary         | MediumRun-.NET 10.0 | .NET 10.0 | 32    |     326.48 ns |     3.751 ns |     5.259 ns |     316.15 ns |     335.75 ns |     333.24 ns |  0.1440 |  18,171 B | 0.0005 |    1208 B |
| ConstructImmutableDictionary        | MediumRun-.NET 10.0 | .NET 10.0 | 32    |   1,847.46 ns |    15.250 ns |    22.825 ns |   1,802.35 ns |   1,894.89 ns |   1,876.80 ns |  0.2518 |  16,166 B | 0.0019 |    2120 B |
| ConstructFrozenDictionary           | MediumRun-.NET 10.0 | .NET 10.0 | 32    |   2,801.48 ns |    32.402 ns |    48.498 ns |   2,726.33 ns |   2,880.20 ns |   2,868.01 ns |  0.7668 |  34,400 B | 0.0076 |    6424 B |
| ConstructDictionary                 | MediumRun-.NET 8.0  | .NET 8.0  | 32    |     359.93 ns |     5.087 ns |     7.295 ns |     343.08 ns |     371.49 ns |     367.72 ns |  0.1392 |   3,773 B |      - |    1168 B |
| ConstructReadOnlyDictionary         | MediumRun-.NET 8.0  | .NET 8.0  | 32    |     371.54 ns |     3.407 ns |     4.886 ns |     361.23 ns |     386.20 ns |     376.88 ns |  0.1440 |   4,459 B |      - |    1208 B |
| ConstructImmutableDictionary        | MediumRun-.NET 8.0  | .NET 8.0  | 32    |   2,383.49 ns |    27.538 ns |    41.217 ns |   2,308.84 ns |   2,457.64 ns |   2,439.79 ns |  0.2518 |   6,488 B |      - |    2120 B |
| ConstructFrozenDictionary           | MediumRun-.NET 8.0  | .NET 8.0  | 32    |   4,524.33 ns |    53.620 ns |    78.596 ns |   4,388.95 ns |   4,697.00 ns |   4,610.92 ns |  0.8621 |  20,006 B | 0.0076 |    7224 B |
| ConstructDictionary                 | MediumRun-.NET 9.0  | .NET 9.0  | 32    |     341.32 ns |     3.326 ns |     4.978 ns |     331.06 ns |     349.42 ns |     346.82 ns |  0.1392 |   3,483 B |      - |    1168 B |
| ConstructReadOnlyDictionary         | MediumRun-.NET 9.0  | .NET 9.0  | 32    |     341.53 ns |     2.812 ns |     4.122 ns |     333.49 ns |     350.01 ns |     345.88 ns |  0.1440 |   5,251 B |      - |    1208 B |
| ConstructImmutableDictionary        | MediumRun-.NET 9.0  | .NET 9.0  | 32    |   2,131.68 ns |    20.102 ns |    28.830 ns |   2,099.68 ns |   2,212.09 ns |   2,165.57 ns |  0.2518 |   6,903 B |      - |    2120 B |
| ConstructFrozenDictionary           | MediumRun-.NET 9.0  | .NET 9.0  | 32    |   3,566.27 ns |    55.129 ns |    82.515 ns |   3,399.56 ns |   3,713.49 ns |   3,670.62 ns |  0.6828 |  22,891 B | 0.0038 |    5736 B |
| **ConstructDictionary**                 | **MediumRun-.NET 10.0** | **.NET 10.0** | **256**   |   **2,523.28 ns** |    **20.315 ns** |    **30.407 ns** |   **2,438.00 ns** |   **2,572.36 ns** |   **2,559.29 ns** |  **0.9956** |   **2,300 B** |      **-** |    **8336 B** |
| ConstructReadOnlyDictionary         | MediumRun-.NET 10.0 | .NET 10.0 | 256   |   3,014.43 ns |    24.405 ns |    35.773 ns |   2,921.03 ns |   3,077.53 ns |   3,060.76 ns |  0.9995 |  17,963 B | 0.0305 |    8376 B |
| ConstructImmutableDictionary        | MediumRun-.NET 10.0 | .NET 10.0 | 256   |  18,222.74 ns |   174.810 ns |   256.235 ns |  17,730.81 ns |  18,618.53 ns |  18,562.52 ns |  1.9531 |  18,579 B | 0.0916 |   16456 B |
| ConstructFrozenDictionary           | MediumRun-.NET 10.0 | .NET 10.0 | 256   |  28,260.67 ns |   813.700 ns | 1,217.908 ns |  26,301.47 ns |  30,017.60 ns |  29,604.68 ns |  6.3477 |  29,116 B | 0.2441 |   53344 B |
| ConstructDictionary                 | MediumRun-.NET 8.0  | .NET 8.0  | 256   |   3,116.04 ns |    23.358 ns |    34.238 ns |   3,042.24 ns |   3,179.72 ns |   3,158.46 ns |  0.9956 |   3,682 B |      - |    8336 B |
| ConstructReadOnlyDictionary         | MediumRun-.NET 8.0  | .NET 8.0  | 256   |   3,149.73 ns |    26.278 ns |    39.332 ns |   3,048.46 ns |   3,243.13 ns |   3,197.87 ns |  0.9995 |   4,459 B |      - |    8376 B |
| ConstructImmutableDictionary        | MediumRun-.NET 8.0  | .NET 8.0  | 256   |  23,440.42 ns |   298.121 ns |   446.214 ns |  22,766.61 ns |  24,271.94 ns |  23,970.22 ns |  1.9531 |   6,477 B | 0.0916 |   16456 B |
| ConstructFrozenDictionary           | MediumRun-.NET 8.0  | .NET 8.0  | 256   |  44,027.78 ns |   335.141 ns |   491.245 ns |  43,261.31 ns |  45,050.12 ns |  44,743.23 ns |  7.0801 |  20,173 B | 0.3052 |   59264 B |
| ConstructDictionary                 | MediumRun-.NET 9.0  | .NET 9.0  | 256   |   2,871.01 ns |    39.531 ns |    57.944 ns |   2,705.59 ns |   2,958.01 ns |   2,945.00 ns |  0.9956 |   3,483 B |      - |    8336 B |
| ConstructReadOnlyDictionary         | MediumRun-.NET 9.0  | .NET 9.0  | 256   |   2,922.88 ns |    26.468 ns |    38.797 ns |   2,847.50 ns |   3,000.65 ns |   2,972.40 ns |  0.9995 |   5,216 B |      - |    8376 B |
| ConstructImmutableDictionary        | MediumRun-.NET 9.0  | .NET 9.0  | 256   |  21,480.62 ns |   194.581 ns |   279.062 ns |  21,028.04 ns |  21,893.18 ns |  21,850.90 ns |  1.9531 |   6,926 B | 0.0916 |   16456 B |
| ConstructFrozenDictionary           | MediumRun-.NET 9.0  | .NET 9.0  | 256   |  44,170.79 ns |   378.305 ns |   566.229 ns |  43,244.54 ns |  45,373.19 ns |  44,890.51 ns |  6.3477 |  22,697 B | 0.3662 |   53376 B |
| **ConstructDictionary**                 | **MediumRun-.NET 10.0** | **.NET 10.0** | **1024**  |  **10,565.08 ns** |    **95.883 ns** |   **140.544 ns** |  **10,269.41 ns** |  **10,911.74 ns** |  **10,712.97 ns** |  **3.6926** |   **2,300 B** |      **-** |   **31016 B** |
| ConstructReadOnlyDictionary         | MediumRun-.NET 10.0 | .NET 10.0 | 1024  |  12,252.54 ns |    99.057 ns |   145.196 ns |  11,809.33 ns |  12,528.43 ns |  12,406.82 ns |  3.6926 |  15,144 B | 0.3662 |   31056 B |
| ConstructImmutableDictionary        | MediumRun-.NET 10.0 | .NET 10.0 | 1024  |  83,256.34 ns |   529.412 ns |   792.399 ns |  81,531.28 ns |  84,897.56 ns |  84,063.28 ns |  7.8125 |  18,580 B | 1.4648 |   65608 B |
| ConstructFrozenDictionary           | MediumRun-.NET 10.0 | .NET 10.0 | 1024  | 165,589.76 ns | 3,699.675 ns | 5,537.500 ns | 157,918.75 ns | 179,444.47 ns | 173,369.58 ns | 22.9492 |  34,830 B | 4.3945 |  193544 B |
| ConstructDictionary                 | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |  12,672.27 ns |    76.439 ns |   112.044 ns |  12,504.62 ns |  12,979.33 ns |  12,803.39 ns |  3.6926 |   3,669 B |      - |   31016 B |
| ConstructReadOnlyDictionary         | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |  13,209.07 ns |    81.170 ns |   118.978 ns |  12,895.42 ns |  13,454.37 ns |  13,359.73 ns |  3.6926 |   4,404 B | 0.3662 |   31056 B |
| ConstructImmutableDictionary        | MediumRun-.NET 8.0  | .NET 8.0  | 1024  | 109,612.38 ns |   998.259 ns | 1,431.674 ns | 107,217.46 ns | 111,557.10 ns | 111,419.20 ns |  7.8125 |   6,447 B | 1.4648 |   65608 B |
| ConstructFrozenDictionary           | MediumRun-.NET 8.0  | .NET 8.0  | 1024  | 289,317.90 ns | 2,839.009 ns | 4,161.383 ns | 282,011.96 ns | 298,113.23 ns | 294,717.83 ns | 22.9492 |  20,243 B | 5.3711 |  193576 B |
| ConstructDictionary                 | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |  12,042.56 ns |   132.159 ns |   197.810 ns |  11,735.16 ns |  12,319.88 ns |  12,302.53 ns |  3.6926 |   3,475 B |      - |   31016 B |
| ConstructReadOnlyDictionary         | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |  11,955.29 ns |    61.854 ns |    86.711 ns |  11,768.67 ns |  12,106.81 ns |  12,065.17 ns |  3.6926 |   5,147 B | 0.3662 |   31056 B |
| ConstructImmutableDictionary        | MediumRun-.NET 9.0  | .NET 9.0  | 1024  | 103,203.23 ns | 1,094.847 ns | 1,534.823 ns | 101,403.52 ns | 106,681.80 ns | 104,992.26 ns |  7.8125 |   6,904 B | 1.4648 |   65608 B |
| ConstructFrozenDictionary           | MediumRun-.NET 9.0  | .NET 9.0  | 1024  | 275,137.82 ns | 2,457.799 ns | 3,678.718 ns | 268,120.14 ns | 282,423.29 ns | 281,109.67 ns | 22.9492 |  22,720 B | 5.3711 |  193576 B |
| **DictionaryTryGetValueFound**          | **MediumRun-.NET 10.0** | **.NET 10.0** | **32**    |     **203.06 ns** |     **1.407 ns** |     **2.017 ns** |     **199.92 ns** |     **207.52 ns** |     **205.43 ns** |       **-** |   **1,048 B** |      **-** |         **-** |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 10.0 | .NET 10.0 | 32    |     211.89 ns |     1.156 ns |     1.730 ns |     208.41 ns |     216.69 ns |     213.82 ns |       - |   1,149 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 10.0 | .NET 10.0 | 32    |     600.09 ns |     3.594 ns |     5.379 ns |     591.27 ns |     614.58 ns |     608.03 ns |       - |     700 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 10.0 | .NET 10.0 | 32    |      95.69 ns |     1.016 ns |     1.489 ns |      93.35 ns |      99.51 ns |      97.27 ns |       - |   1,084 B |      - |         - |
| DictionaryTryGetValueFound          | MediumRun-.NET 8.0  | .NET 8.0  | 32    |     271.92 ns |     4.460 ns |     6.676 ns |     262.26 ns |     282.22 ns |     279.96 ns |       - |     399 B |      - |         - |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 8.0  | .NET 8.0  | 32    |     316.88 ns |     9.491 ns |    14.206 ns |     298.47 ns |     336.30 ns |     332.91 ns |       - |      99 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 8.0  | .NET 8.0  | 32    |     676.19 ns |     4.618 ns |     6.912 ns |     666.11 ns |     690.89 ns |     685.33 ns |       - |     329 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 8.0  | .NET 8.0  | 32    |      96.65 ns |     0.938 ns |     1.375 ns |      94.50 ns |     100.37 ns |      98.39 ns |       - |   1,202 B |      - |         - |
| DictionaryTryGetValueFound          | MediumRun-.NET 9.0  | .NET 9.0  | 32    |     286.02 ns |     4.414 ns |     6.470 ns |     276.20 ns |     298.66 ns |     295.35 ns |       - |     413 B |      - |         - |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 9.0  | .NET 9.0  | 32    |     316.68 ns |     4.847 ns |     7.255 ns |     305.67 ns |     328.43 ns |     325.99 ns |       - |      92 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 9.0  | .NET 9.0  | 32    |     661.59 ns |     4.238 ns |     6.212 ns |     650.89 ns |     676.49 ns |     668.76 ns |       - |     546 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 9.0  | .NET 9.0  | 32    |      95.09 ns |     1.107 ns |     1.623 ns |      92.55 ns |      97.71 ns |      97.01 ns |       - |   1,094 B |      - |         - |
| **DictionaryTryGetValueFound**          | **MediumRun-.NET 10.0** | **.NET 10.0** | **256**   |   **1,716.70 ns** |     **9.941 ns** |    **14.879 ns** |   **1,695.02 ns** |   **1,747.24 ns** |   **1,735.63 ns** |       **-** |   **1,077 B** |      **-** |         **-** |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 10.0 | .NET 10.0 | 256   |   1,749.94 ns |    23.864 ns |    35.719 ns |   1,695.24 ns |   1,809.43 ns |   1,795.56 ns |       - |   1,168 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 10.0 | .NET 10.0 | 256   |   5,158.95 ns |    31.258 ns |    43.819 ns |   5,097.82 ns |   5,244.52 ns |   5,225.43 ns |       - |     721 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 10.0 | .NET 10.0 | 256   |     864.35 ns |     5.853 ns |     8.761 ns |     848.57 ns |     886.21 ns |     874.59 ns |       - |   1,204 B |      - |         - |
| DictionaryTryGetValueFound          | MediumRun-.NET 8.0  | .NET 8.0  | 256   |   2,615.39 ns |    25.203 ns |    36.943 ns |   2,566.29 ns |   2,701.03 ns |   2,669.46 ns |       - |     399 B |      - |         - |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 8.0  | .NET 8.0  | 256   |   3,033.31 ns |    71.057 ns |   106.354 ns |   2,889.78 ns |   3,197.38 ns |   3,159.26 ns |       - |      99 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 8.0  | .NET 8.0  | 256   |   5,706.30 ns |    36.255 ns |    53.143 ns |   5,620.23 ns |   5,835.04 ns |   5,762.70 ns |       - |     329 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 8.0  | .NET 8.0  | 256   |     887.13 ns |     9.890 ns |    13.864 ns |     866.59 ns |     905.82 ns |     902.04 ns |       - |   1,203 B |      - |         - |
| DictionaryTryGetValueFound          | MediumRun-.NET 9.0  | .NET 9.0  | 256   |   2,709.89 ns |    44.427 ns |    65.121 ns |   2,610.64 ns |   2,801.85 ns |   2,786.83 ns |       - |     413 B |      - |         - |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 9.0  | .NET 9.0  | 256   |   3,077.55 ns |    24.692 ns |    36.958 ns |   3,024.10 ns |   3,160.18 ns |   3,124.12 ns |       - |      92 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 9.0  | .NET 9.0  | 256   |   5,538.61 ns |    37.380 ns |    55.948 ns |   5,454.36 ns |   5,657.79 ns |   5,599.78 ns |       - |     549 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 9.0  | .NET 9.0  | 256   |     866.67 ns |     5.853 ns |     8.580 ns |     849.95 ns |     883.40 ns |     877.45 ns |       - |   1,236 B |      - |         - |
| **DictionaryTryGetValueFound**          | **MediumRun-.NET 10.0** | **.NET 10.0** | **1024**  |   **7,746.36 ns** |   **250.375 ns** |   **374.749 ns** |   **7,325.55 ns** |   **8,330.47 ns** |   **8,167.03 ns** |       **-** |   **1,082 B** |      **-** |         **-** |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 10.0 | .NET 10.0 | 1024  |   7,856.61 ns |   205.091 ns |   306.970 ns |   7,485.41 ns |   8,245.90 ns |   8,206.84 ns |       - |   1,162 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 10.0 | .NET 10.0 | 1024  |  21,720.74 ns |   139.467 ns |   200.019 ns |  21,437.05 ns |  22,134.23 ns |  21,982.23 ns |       - |     721 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 10.0 | .NET 10.0 | 1024  |   3,236.88 ns |    22.539 ns |    33.736 ns |   3,167.80 ns |   3,302.54 ns |   3,274.12 ns |       - |   1,218 B |      - |         - |
| DictionaryTryGetValueFound          | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |  13,344.63 ns |    82.416 ns |   120.804 ns |  13,112.32 ns |  13,581.34 ns |  13,510.38 ns |       - |     421 B |      - |         - |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |  14,100.59 ns |   106.645 ns |   156.318 ns |  13,797.99 ns |  14,429.10 ns |  14,260.83 ns |       - |      99 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |  24,803.96 ns |   155.078 ns |   232.113 ns |  24,416.94 ns |  25,414.36 ns |  25,091.79 ns |       - |     577 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |   3,331.45 ns |    27.497 ns |    40.305 ns |   3,262.44 ns |   3,444.69 ns |   3,376.67 ns |       - |   1,210 B |      - |         - |
| DictionaryTryGetValueFound          | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |  11,878.07 ns |    74.886 ns |   109.767 ns |  11,737.99 ns |  12,115.39 ns |  12,023.54 ns |       - |     413 B |      - |         - |
| ReadOnlyDictionaryTryGetValueFound  | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |  14,505.74 ns |    89.462 ns |   133.902 ns |  14,295.32 ns |  14,747.86 ns |  14,694.85 ns |       - |      92 B |      - |         - |
| ImmutableDictionaryTryGetValueFound | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |  23,160.60 ns |   170.672 ns |   255.454 ns |  22,697.29 ns |  23,710.26 ns |  23,469.21 ns |       - |     559 B |      - |         - |
| FrozenDictionaryTryGetValueFound    | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |   3,239.19 ns |    25.720 ns |    38.497 ns |   3,172.48 ns |   3,317.55 ns |   3,285.55 ns |       - |   1,242 B |      - |         - |
| **FrozenDictionaryTryGetValueByType**   | **MediumRun-.NET 10.0** | **.NET 10.0** | **32**    |     **436.03 ns** |     **2.893 ns** |     **4.241 ns** |     **423.66 ns** |     **443.61 ns** |     **441.31 ns** |  **0.0982** |   **1,815 B** |      **-** |     **824 B** |
| HashArrayTryGetValueByType          | MediumRun-.NET 10.0 | .NET 10.0 | 32    |     167.94 ns |     6.595 ns |     9.871 ns |     155.39 ns |     184.94 ns |     179.95 ns |  0.0985 |   2,173 B |      - |     824 B |
| FrozenDictionaryTryGetValueByType   | MediumRun-.NET 8.0  | .NET 8.0  | 32    |     491.58 ns |     5.728 ns |     8.573 ns |     479.18 ns |     509.62 ns |     503.94 ns |  0.0982 |   2,120 B |      - |     824 B |
| HashArrayTryGetValueByType          | MediumRun-.NET 8.0  | .NET 8.0  | 32    |     142.97 ns |     1.847 ns |     2.708 ns |     137.91 ns |     147.36 ns |     146.67 ns |  0.0985 |   2,037 B |      - |     824 B |
| FrozenDictionaryTryGetValueByType   | MediumRun-.NET 9.0  | .NET 9.0  | 32    |     594.39 ns |     4.203 ns |     6.161 ns |     584.48 ns |     606.57 ns |     603.86 ns |  0.0982 |   1,814 B |      - |     824 B |
| HashArrayTryGetValueByType          | MediumRun-.NET 9.0  | .NET 9.0  | 32    |     138.86 ns |     2.067 ns |     3.029 ns |     130.75 ns |     143.64 ns |     143.17 ns |  0.0985 |   2,022 B |      - |     824 B |
| **FrozenDictionaryTryGetValueByType**   | **MediumRun-.NET 10.0** | **.NET 10.0** | **256**   |     **443.83 ns** |     **7.196 ns** |    **10.771 ns** |     **424.80 ns** |     **460.62 ns** |     **457.38 ns** |  **0.0982** |   **1,815 B** |      **-** |     **824 B** |
| HashArrayTryGetValueByType          | MediumRun-.NET 10.0 | .NET 10.0 | 256   |     158.06 ns |     2.389 ns |     3.575 ns |     150.57 ns |     166.80 ns |     162.19 ns |  0.0985 |   2,173 B |      - |     824 B |
| FrozenDictionaryTryGetValueByType   | MediumRun-.NET 8.0  | .NET 8.0  | 256   |     489.94 ns |     4.948 ns |     6.937 ns |     479.54 ns |     505.15 ns |     499.35 ns |  0.0982 |   2,120 B |      - |     824 B |
| HashArrayTryGetValueByType          | MediumRun-.NET 8.0  | .NET 8.0  | 256   |     151.03 ns |     5.364 ns |     8.029 ns |     138.54 ns |     163.98 ns |     160.72 ns |  0.0985 |   2,037 B |      - |     824 B |
| FrozenDictionaryTryGetValueByType   | MediumRun-.NET 9.0  | .NET 9.0  | 256   |     596.53 ns |     5.954 ns |     8.911 ns |     584.47 ns |     617.28 ns |     609.47 ns |  0.0982 |   1,814 B |      - |     824 B |
| HashArrayTryGetValueByType          | MediumRun-.NET 9.0  | .NET 9.0  | 256   |     140.27 ns |     1.649 ns |     2.417 ns |     136.20 ns |     145.42 ns |     142.92 ns |  0.0985 |   2,022 B |      - |     824 B |
| **FrozenDictionaryTryGetValueByType**   | **MediumRun-.NET 10.0** | **.NET 10.0** | **1024**  |     **436.89 ns** |     **3.140 ns** |     **4.602 ns** |     **431.24 ns** |     **447.26 ns** |     **444.37 ns** |  **0.0982** |   **1,815 B** |      **-** |     **824 B** |
| HashArrayTryGetValueByType          | MediumRun-.NET 10.0 | .NET 10.0 | 1024  |     154.48 ns |     3.138 ns |     4.599 ns |     146.78 ns |     163.95 ns |     161.16 ns |  0.0985 |   2,173 B |      - |     824 B |
| FrozenDictionaryTryGetValueByType   | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |     490.40 ns |     5.349 ns |     7.840 ns |     476.52 ns |     504.85 ns |     501.62 ns |  0.0982 |   2,120 B |      - |     824 B |
| HashArrayTryGetValueByType          | MediumRun-.NET 8.0  | .NET 8.0  | 1024  |     143.79 ns |     1.897 ns |     2.839 ns |     136.12 ns |     148.15 ns |     147.25 ns |  0.0985 |   2,037 B |      - |     824 B |
| FrozenDictionaryTryGetValueByType   | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |     597.18 ns |     6.477 ns |     9.695 ns |     583.18 ns |     623.85 ns |     610.43 ns |  0.0982 |   1,814 B |      - |     824 B |
| HashArrayTryGetValueByType          | MediumRun-.NET 9.0  | .NET 9.0  | 1024  |     138.11 ns |     1.802 ns |     2.585 ns |     131.47 ns |     142.70 ns |     141.72 ns |  0.0985 |   2,022 B |      - |     824 B |

NET SDK 8.0.100-rc.1.23463.5
  [Host]    : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method                            | Items | Mean     | Error   | StdDev  | Min      | Max      | P90      | Code Size | Gen0   | Allocated |
|---------------------------------- |------ |---------:|--------:|--------:|---------:|---------:|---------:|----------:|-------:|----------:|
| **FrozenDictionaryTryGetValueByType** | **32**    | **685.2 ns** | **6.32 ns** | **9.46 ns** | **671.9 ns** | **701.1 ns** | **698.0 ns** |   **2,120 B** | **0.0486** |     **824 B** |
| HashArrayTryGetValueByType        | 32    | 205.4 ns | 2.51 ns | 3.69 ns | 201.0 ns | 213.3 ns | 212.3 ns |   2,037 B | 0.0491 |     824 B |
| **FrozenDictionaryTryGetValueByType** | **256**   | **673.5 ns** | **4.65 ns** | **6.82 ns** | **661.1 ns** | **689.3 ns** | **682.2 ns** |   **2,120 B** | **0.0486** |     **824 B** |
| HashArrayTryGetValueByType        | 256   | 204.6 ns | 2.24 ns | 3.22 ns | 200.5 ns | 213.3 ns | 208.9 ns |   2,037 B | 0.0491 |     824 B |
| **FrozenDictionaryTryGetValueByType** | **1024**  | **669.7 ns** | **6.37 ns** | **8.93 ns** | **657.6 ns** | **699.1 ns** | **680.9 ns** |   **2,120 B** | **0.0486** |     **824 B** |
| HashArrayTryGetValueByType        | 1024  | 204.6 ns | 4.02 ns | 5.64 ns | 200.2 ns | 225.1 ns | 212.7 ns |   2,037 B | 0.0491 |     824 B |
