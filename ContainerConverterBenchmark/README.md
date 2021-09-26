``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.401
  [Host]   : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  ShortRun : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                         Method | Size |       Mean |       Error |    StdDev |        Min |        Max |        P90 |  Gen 0 | Allocated |
|------------------------------- |----- |-----------:|------------:|----------:|-----------:|-----------:|-----------:|-------:|----------:|
|                   **ArrayToArray** |    **0** |   **4.999 ns** |   **0.3088 ns** | **0.0169 ns** |   **4.983 ns** |   **5.017 ns** |   **5.013 ns** | **0.0014** |      **24 B** |
| ArrayToArrayWithoutSourceCheck |    0 |   5.019 ns |   2.6403 ns | 0.1447 ns |   4.933 ns |   5.187 ns |   5.137 ns | 0.0014 |      24 B |
|                    ListToArray |    0 |   4.900 ns |   0.1310 ns | 0.0072 ns |   4.895 ns |   4.908 ns |   4.905 ns | 0.0014 |      24 B |
|                   ListToArray2 |    0 |   5.378 ns |   0.2416 ns | 0.0132 ns |   5.367 ns |   5.393 ns |   5.389 ns | 0.0014 |      24 B |
|                   IListToArray |    0 |   5.933 ns |   1.6665 ns | 0.0913 ns |   5.829 ns |   6.000 ns |   5.994 ns | 0.0014 |      24 B |
|                  IListToArray2 |    0 |   4.916 ns |   0.3553 ns | 0.0195 ns |   4.900 ns |   4.938 ns |   4.932 ns | 0.0014 |      24 B |
|             IEnumerableToArray |    0 |  46.865 ns |   2.3365 ns | 0.1281 ns |  46.717 ns |  46.946 ns |  46.943 ns | 0.0119 |     200 B |
|            IEnumerableToArray2 |    0 |  19.470 ns |   3.7056 ns | 0.2031 ns |  19.278 ns |  19.683 ns |  19.636 ns | 0.0052 |      88 B |
|                    ArrayToList |    0 |   5.917 ns |   0.2895 ns | 0.0159 ns |   5.905 ns |   5.935 ns |   5.930 ns | 0.0019 |      32 B |
|                     ListToList |    0 |   6.244 ns |   0.5590 ns | 0.0306 ns |   6.220 ns |   6.278 ns |   6.269 ns | 0.0019 |      32 B |
|                    ListToList2 |    0 |   6.143 ns |   0.4022 ns | 0.0220 ns |   6.118 ns |   6.158 ns |   6.157 ns | 0.0019 |      32 B |
|                    IListToList |    0 |   8.069 ns |   1.0639 ns | 0.0583 ns |   8.005 ns |   8.120 ns |   8.112 ns | 0.0019 |      32 B |
|                   IListToList2 |    0 |   7.066 ns |   0.3598 ns | 0.0197 ns |   7.052 ns |   7.088 ns |   7.082 ns | 0.0019 |      32 B |
|              IEnumerableToList |    0 |  43.432 ns |   2.7062 ns | 0.1483 ns |  43.281 ns |  43.577 ns |  43.550 ns | 0.0139 |     232 B |
|             IEnumerableToList2 |    0 |  18.209 ns |   3.0963 ns | 0.1697 ns |  18.039 ns |  18.379 ns |  18.345 ns | 0.0052 |      88 B |
|                   **ArrayToArray** |    **4** |   **9.868 ns** |   **1.0423 ns** | **0.0571 ns** |   **9.822 ns** |   **9.932 ns** |   **9.916 ns** | **0.0024** |      **40 B** |
| ArrayToArrayWithoutSourceCheck |    4 |  10.978 ns |   0.7725 ns | 0.0423 ns |  10.952 ns |  11.027 ns |  11.013 ns | 0.0024 |      40 B |
|                    ListToArray |    4 |  11.499 ns |   6.4828 ns | 0.3553 ns |  11.217 ns |  11.898 ns |  11.794 ns | 0.0024 |      40 B |
|                   ListToArray2 |    4 |  12.193 ns |  14.9047 ns | 0.8170 ns |  11.258 ns |  12.772 ns |  12.727 ns | 0.0024 |      40 B |
|                   IListToArray |    4 |  22.492 ns |   3.9893 ns | 0.2187 ns |  22.268 ns |  22.705 ns |  22.665 ns | 0.0024 |      40 B |
|                  IListToArray2 |    4 |  15.194 ns |   1.6612 ns | 0.0911 ns |  15.134 ns |  15.299 ns |  15.269 ns | 0.0024 |      40 B |
|             IEnumerableToArray |    4 |  85.686 ns |   5.5395 ns | 0.3036 ns |  85.400 ns |  86.004 ns |  85.934 ns | 0.0143 |     240 B |
|            IEnumerableToArray2 |    4 |  57.032 ns |   2.5524 ns | 0.1399 ns |  56.942 ns |  57.193 ns |  57.147 ns | 0.0100 |     168 B |
|                    ArrayToList |    4 |  16.014 ns |  11.0919 ns | 0.6080 ns |  15.320 ns |  16.453 ns |  16.416 ns | 0.0043 |      72 B |
|                     ListToList |    4 |  16.250 ns |   0.5760 ns | 0.0316 ns |  16.230 ns |  16.287 ns |  16.276 ns | 0.0043 |      72 B |
|                    ListToList2 |    4 |  16.619 ns |  13.4661 ns | 0.7381 ns |  15.854 ns |  17.327 ns |  17.197 ns | 0.0043 |      72 B |
|                    IListToList |    4 |  27.673 ns |   3.2064 ns | 0.1758 ns |  27.487 ns |  27.836 ns |  27.808 ns | 0.0043 |      72 B |
|                   IListToList2 |    4 |  20.319 ns |   7.1771 ns | 0.3934 ns |  20.072 ns |  20.772 ns |  20.640 ns | 0.0043 |      72 B |
|              IEnumerableToList |    4 |  80.970 ns |  10.6201 ns | 0.5821 ns |  80.354 ns |  81.511 ns |  81.418 ns | 0.0162 |     272 B |
|             IEnumerableToList2 |    4 |  48.941 ns |   4.0936 ns | 0.2244 ns |  48.761 ns |  49.193 ns |  49.128 ns | 0.0076 |     128 B |
|                   **ArrayToArray** |   **16** |  **32.875 ns** |   **3.1021 ns** | **0.1700 ns** |  **32.753 ns** |  **33.069 ns** |  **33.015 ns** | **0.0052** |      **88 B** |
| ArrayToArrayWithoutSourceCheck |   16 |  32.723 ns |   5.0941 ns | 0.2792 ns |  32.532 ns |  33.044 ns |  32.954 ns | 0.0052 |      88 B |
|                    ListToArray |   16 |  36.788 ns |  27.8398 ns | 1.5260 ns |  35.609 ns |  38.511 ns |  38.057 ns | 0.0052 |      88 B |
|                   ListToArray2 |   16 |  32.493 ns |   1.6838 ns | 0.0923 ns |  32.409 ns |  32.592 ns |  32.569 ns | 0.0052 |      88 B |
|                   IListToArray |   16 |  75.265 ns |  36.6661 ns | 2.0098 ns |  72.959 ns |  76.647 ns |  76.555 ns | 0.0052 |      88 B |
|                  IListToArray2 |   16 |  48.838 ns |   3.7887 ns | 0.2077 ns |  48.687 ns |  49.075 ns |  49.010 ns | 0.0052 |      88 B |
|             IEnumerableToArray |   16 | 211.279 ns |  74.1469 ns | 4.0642 ns | 208.210 ns | 215.888 ns | 214.658 ns | 0.0261 |     440 B |
|            IEnumerableToArray2 |   16 | 149.133 ns |  21.3942 ns | 1.1727 ns | 148.455 ns | 150.487 ns | 150.081 ns | 0.0215 |     360 B |
|                    ArrayToList |   16 |  42.121 ns |  22.2510 ns | 1.2197 ns |  41.060 ns |  43.454 ns |  43.133 ns | 0.0071 |     120 B |
|                     ListToList |   16 |  48.632 ns |  13.7756 ns | 0.7551 ns |  47.771 ns |  49.181 ns |  49.133 ns | 0.0071 |     120 B |
|                    ListToList2 |   16 |  44.953 ns |   4.8554 ns | 0.2661 ns |  44.728 ns |  45.247 ns |  45.174 ns | 0.0071 |     120 B |
|                    IListToList |   16 |  82.552 ns |  32.5334 ns | 1.7833 ns |  81.330 ns |  84.598 ns |  84.024 ns | 0.0071 |     120 B |
|                   IListToList2 |   16 |  59.039 ns |  27.8401 ns | 1.5260 ns |  57.278 ns |  59.976 ns |  59.953 ns | 0.0071 |     120 B |
|              IEnumerableToList |   16 | 194.565 ns |   9.0390 ns | 0.4955 ns | 194.235 ns | 195.134 ns | 194.973 ns | 0.0247 |     416 B |
|             IEnumerableToList2 |   16 | 146.983 ns |   9.1251 ns | 0.5002 ns | 146.693 ns | 147.561 ns | 147.387 ns | 0.0161 |     272 B |
|                   **ArrayToArray** |   **32** |  **62.380 ns** |   **5.2016 ns** | **0.2851 ns** |  **62.119 ns** |  **62.684 ns** |  **62.614 ns** | **0.0090** |     **152 B** |
| ArrayToArrayWithoutSourceCheck |   32 |  56.174 ns |  15.1335 ns | 0.8295 ns |  55.230 ns |  56.785 ns |  56.730 ns | 0.0090 |     152 B |
|                    ListToArray |   32 |  66.054 ns |  30.4948 ns | 1.6715 ns |  65.039 ns |  67.983 ns |  67.414 ns | 0.0090 |     152 B |
|                   ListToArray2 |   32 |  63.094 ns |   3.7424 ns | 0.2051 ns |  62.963 ns |  63.331 ns |  63.263 ns | 0.0090 |     152 B |
|                   IListToArray |   32 | 144.121 ns |  54.4896 ns | 2.9868 ns | 142.196 ns | 147.561 ns | 146.570 ns | 0.0090 |     152 B |
|                  IListToArray2 |   32 |  99.732 ns |  30.8542 ns | 1.6912 ns |  98.103 ns | 101.479 ns | 101.106 ns | 0.0090 |     152 B |
|             IEnumerableToArray |   32 | 345.293 ns |   1.8946 ns | 0.1038 ns | 345.174 ns | 345.366 ns | 345.361 ns | 0.0386 |     648 B |
|            IEnumerableToArray2 |   32 | 256.071 ns |  18.2502 ns | 1.0004 ns | 255.029 ns | 257.024 ns | 256.851 ns | 0.0342 |     576 B |
|                    ArrayToList |   32 |  77.873 ns |  11.7578 ns | 0.6445 ns |  77.133 ns |  78.316 ns |  78.287 ns | 0.0110 |     184 B |
|                     ListToList |   32 |  84.940 ns |  72.1746 ns | 3.9561 ns |  81.137 ns |  89.033 ns |  88.157 ns | 0.0110 |     184 B |
|                    ListToList2 |   32 |  87.642 ns |  75.8831 ns | 4.1594 ns |  82.945 ns |  90.861 ns |  90.513 ns | 0.0110 |     184 B |
|                    IListToList |   32 | 153.405 ns |  22.9846 ns | 1.2599 ns | 152.365 ns | 154.806 ns | 154.453 ns | 0.0110 |     184 B |
|                   IListToList2 |   32 | 105.375 ns |  42.7560 ns | 2.3436 ns | 103.118 ns | 107.796 ns | 107.279 ns | 0.0110 |     184 B |
|              IEnumerableToList |   32 | 314.891 ns |  45.2963 ns | 2.4828 ns | 312.437 ns | 317.401 ns | 316.888 ns | 0.0337 |     568 B |
|             IEnumerableToList2 |   32 | 249.540 ns |  22.9349 ns | 1.2571 ns | 248.091 ns | 250.349 ns | 250.315 ns | 0.0249 |     424 B |
|                   **ArrayToArray** |   **64** | **121.018 ns** |   **5.2063 ns** | **0.2854 ns** | **120.734 ns** | **121.305 ns** | **121.247 ns** | **0.0167** |     **280 B** |
| ArrayToArrayWithoutSourceCheck |   64 | 120.737 ns |   6.3171 ns | 0.3463 ns | 120.425 ns | 121.110 ns | 121.023 ns | 0.0167 |     280 B |
|                    ListToArray |   64 | 150.053 ns | 139.8589 ns | 7.6661 ns | 141.544 ns | 156.421 ns | 155.576 ns | 0.0166 |     280 B |
|                   ListToArray2 |   64 | 121.602 ns |   5.0173 ns | 0.2750 ns | 121.285 ns | 121.784 ns | 121.774 ns | 0.0167 |     280 B |
|                   IListToArray |   64 | 285.807 ns | 131.0007 ns | 7.1806 ns | 277.673 ns | 291.267 ns | 290.710 ns | 0.0166 |     280 B |
|                  IListToArray2 |   64 | 181.454 ns |   4.9485 ns | 0.2712 ns | 181.191 ns | 181.733 ns | 181.674 ns | 0.0166 |     280 B |
|             IEnumerableToArray |   64 | 576.976 ns |  77.7784 ns | 4.2633 ns | 573.442 ns | 581.711 ns | 580.524 ns | 0.0547 |     928 B |
|            IEnumerableToArray2 |   64 | 468.131 ns |  82.7718 ns | 4.5370 ns | 464.327 ns | 473.153 ns | 471.905 ns | 0.0586 |     984 B |
|                    ArrayToList |   64 | 155.783 ns |  46.9989 ns | 2.5762 ns | 152.823 ns | 157.519 ns | 157.417 ns | 0.0186 |     312 B |
|                     ListToList |   64 | 150.017 ns |  59.6607 ns | 3.2702 ns | 147.331 ns | 153.659 ns | 152.739 ns | 0.0186 |     312 B |
|                    ListToList2 |   64 | 166.251 ns |  72.4719 ns | 3.9724 ns | 162.534 ns | 170.438 ns | 169.506 ns | 0.0186 |     312 B |
|                    IListToList |   64 | 319.646 ns | 154.4602 ns | 8.4665 ns | 309.945 ns | 325.547 ns | 325.126 ns | 0.0186 |     312 B |
|                   IListToList2 |   64 | 205.189 ns |  61.9780 ns | 3.3972 ns | 201.393 ns | 207.943 ns | 207.601 ns | 0.0186 |     312 B |
|              IEnumerableToList |   64 | 567.487 ns |  88.6613 ns | 4.8598 ns | 562.119 ns | 571.586 ns | 571.020 ns | 0.0498 |     848 B |
|             IEnumerableToList2 |   64 | 445.642 ns | 175.9313 ns | 9.6434 ns | 436.777 ns | 455.910 ns | 453.576 ns | 0.0420 |     704 B |
