``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.401
  [Host]    : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT
  MediumRun : .NET 5.0.10 (5.0.1021.41214), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                         Method | Size |       Mean |     Error |     StdDev |     Median |        Min |        Max |        P90 |  Gen 0 | Allocated |
|------------------------------- |----- |-----------:|----------:|-----------:|-----------:|-----------:|-----------:|-----------:|-------:|----------:|
|                   **ArrayToArray** |    **0** |   **4.910 ns** | **0.0705 ns** |  **0.1011 ns** |   **4.917 ns** |   **4.772 ns** |   **5.046 ns** |   **5.015 ns** | **0.0014** |      **24 B** |
| ArrayToArrayWithoutSourceCheck |    0 |   4.911 ns | 0.0136 ns |  0.0204 ns |   4.907 ns |   4.886 ns |   4.974 ns |   4.935 ns | 0.0014 |      24 B |
|                    ListToArray |    0 |   4.925 ns | 0.0367 ns |  0.0537 ns |   4.903 ns |   4.860 ns |   5.021 ns |   4.993 ns | 0.0014 |      24 B |
|                   ListToArray2 |    0 |   5.377 ns | 0.0099 ns |  0.0145 ns |   5.375 ns |   5.352 ns |   5.412 ns |   5.399 ns | 0.0014 |      24 B |
|                   IListToArray |    0 |   5.615 ns | 0.0798 ns |  0.1169 ns |   5.534 ns |   5.486 ns |   5.759 ns |   5.744 ns | 0.0014 |      24 B |
|                  IListToArray2 |    0 |   4.609 ns | 0.0173 ns |  0.0249 ns |   4.607 ns |   4.572 ns |   4.669 ns |   4.638 ns | 0.0014 |      24 B |
|             IEnumerableToArray |    0 |  29.401 ns | 0.2577 ns |  0.3777 ns |  29.262 ns |  28.875 ns |  30.023 ns |  29.843 ns | 0.0096 |     160 B |
|            IEnumerableToArray2 |    0 |  16.588 ns | 0.1023 ns |  0.1499 ns |  16.612 ns |  16.304 ns |  16.854 ns |  16.757 ns | 0.0043 |      72 B |
|                    ArrayToList |    0 |   5.843 ns | 0.1433 ns |  0.2055 ns |   5.690 ns |   5.622 ns |   6.083 ns |   6.065 ns | 0.0019 |      32 B |
|                     ListToList |    0 |   5.760 ns | 0.0773 ns |  0.1133 ns |   5.699 ns |   5.621 ns |   5.917 ns |   5.891 ns | 0.0019 |      32 B |
|                    ListToList2 |    0 |   6.073 ns | 0.0125 ns |  0.0179 ns |   6.070 ns |   6.044 ns |   6.108 ns |   6.098 ns | 0.0019 |      32 B |
|                    IListToList |    0 |   8.399 ns | 0.0932 ns |  0.1395 ns |   8.343 ns |   8.260 ns |   8.713 ns |   8.632 ns | 0.0019 |      32 B |
|                   IListToList2 |    0 |   7.139 ns | 0.0150 ns |  0.0215 ns |   7.142 ns |   7.108 ns |   7.192 ns |   7.167 ns | 0.0019 |      32 B |
|              IEnumerableToList |    0 |  32.471 ns | 0.3234 ns |  0.4534 ns |  32.354 ns |  31.820 ns |  33.079 ns |  33.040 ns | 0.0115 |     192 B |
|             IEnumerableToList2 |    0 |  15.472 ns | 0.0628 ns |  0.0940 ns |  15.448 ns |  15.349 ns |  15.648 ns |  15.609 ns | 0.0043 |      72 B |
|                   **ArrayToArray** |    **4** |  **12.145 ns** | **1.0349 ns** |  **1.5170 ns** |  **13.397 ns** |  **10.391 ns** |  **13.782 ns** |  **13.695 ns** | **0.0024** |      **40 B** |
| ArrayToArrayWithoutSourceCheck |    4 |  10.307 ns | 0.3000 ns |  0.4491 ns |  10.235 ns |   9.762 ns |  11.508 ns |  11.017 ns | 0.0024 |      40 B |
|                    ListToArray |    4 |  11.129 ns | 0.2849 ns |  0.3994 ns |  11.070 ns |  10.403 ns |  11.814 ns |  11.657 ns | 0.0024 |      40 B |
|                   ListToArray2 |    4 |  10.743 ns | 0.1763 ns |  0.2584 ns |  10.807 ns |  10.279 ns |  11.119 ns |  11.021 ns | 0.0024 |      40 B |
|                   IListToArray |    4 |  21.555 ns | 0.3325 ns |  0.4768 ns |  21.812 ns |  20.908 ns |  22.128 ns |  22.064 ns | 0.0024 |      40 B |
|                  IListToArray2 |    4 |  16.416 ns | 0.3535 ns |  0.4956 ns |  16.738 ns |  15.742 ns |  16.937 ns |  16.914 ns | 0.0024 |      40 B |
|             IEnumerableToArray |    4 |  41.096 ns | 0.1505 ns |  0.2206 ns |  41.031 ns |  40.741 ns |  41.590 ns |  41.365 ns | 0.0119 |     200 B |
|            IEnumerableToArray2 |    4 |  54.777 ns | 0.7651 ns |  1.0725 ns |  55.077 ns |  52.919 ns |  56.403 ns |  55.982 ns | 0.0090 |     152 B |
|                    ArrayToList |    4 |  16.366 ns | 0.4286 ns |  0.6416 ns |  16.296 ns |  15.430 ns |  17.859 ns |  17.359 ns | 0.0043 |      72 B |
|                     ListToList |    4 |  17.173 ns | 0.3265 ns |  0.4886 ns |  17.291 ns |  16.019 ns |  17.961 ns |  17.669 ns | 0.0043 |      72 B |
|                    ListToList2 |    4 |  16.334 ns | 0.2590 ns |  0.3797 ns |  16.317 ns |  15.628 ns |  17.286 ns |  16.837 ns | 0.0043 |      72 B |
|                    IListToList |    4 |  27.574 ns | 0.1675 ns |  0.2455 ns |  27.548 ns |  27.165 ns |  28.107 ns |  27.879 ns | 0.0043 |      72 B |
|                   IListToList2 |    4 |  20.527 ns | 0.2232 ns |  0.3272 ns |  20.570 ns |  19.903 ns |  21.331 ns |  20.855 ns | 0.0043 |      72 B |
|              IEnumerableToList |    4 |  47.520 ns | 0.2251 ns |  0.3299 ns |  47.452 ns |  47.078 ns |  48.361 ns |  47.941 ns | 0.0139 |     232 B |
|             IEnumerableToList2 |    4 |  46.562 ns | 0.4848 ns |  0.6953 ns |  46.456 ns |  45.611 ns |  47.769 ns |  47.398 ns | 0.0067 |     112 B |
|                   **ArrayToArray** |   **16** |  **32.053 ns** | **0.1072 ns** |  **0.1503 ns** |  **32.071 ns** |  **31.813 ns** |  **32.382 ns** |  **32.225 ns** | **0.0052** |      **88 B** |
| ArrayToArrayWithoutSourceCheck |   16 |  30.627 ns | 1.2358 ns |  1.7325 ns |  31.884 ns |  28.701 ns |  33.129 ns |  32.512 ns | 0.0052 |      88 B |
|                    ListToArray |   16 |  35.516 ns | 0.6462 ns |  0.9672 ns |  35.706 ns |  32.528 ns |  36.897 ns |  36.506 ns | 0.0052 |      88 B |
|                   ListToArray2 |   16 |  31.300 ns | 1.0025 ns |  1.4054 ns |  32.245 ns |  29.314 ns |  32.694 ns |  32.620 ns | 0.0052 |      88 B |
|                   IListToArray |   16 |  71.451 ns | 1.2455 ns |  1.7460 ns |  72.722 ns |  69.312 ns |  73.361 ns |  73.216 ns | 0.0052 |      88 B |
|                  IListToArray2 |   16 |  51.438 ns | 0.8531 ns |  1.2505 ns |  51.023 ns |  50.311 ns |  54.551 ns |  53.228 ns | 0.0052 |      88 B |
|             IEnumerableToArray |   16 |  78.009 ns | 0.5313 ns |  0.7952 ns |  77.904 ns |  76.221 ns |  80.114 ns |  78.752 ns | 0.0148 |     248 B |
|            IEnumerableToArray2 |   16 | 158.486 ns | 1.0714 ns |  1.6036 ns | 158.529 ns | 155.242 ns | 161.611 ns | 160.517 ns | 0.0205 |     344 B |
|                    ArrayToList |   16 |  46.202 ns | 1.1936 ns |  1.7865 ns |  46.697 ns |  41.502 ns |  49.193 ns |  47.969 ns | 0.0071 |     120 B |
|                     ListToList |   16 |  47.770 ns | 1.1881 ns |  1.7415 ns |  47.557 ns |  44.593 ns |  52.207 ns |  49.981 ns | 0.0071 |     120 B |
|                    ListToList2 |   16 |  46.111 ns | 1.0162 ns |  1.5210 ns |  45.572 ns |  43.964 ns |  49.336 ns |  48.323 ns | 0.0071 |     120 B |
|                    IListToList |   16 |  82.694 ns | 1.3583 ns |  1.9909 ns |  81.866 ns |  80.415 ns |  86.007 ns |  85.506 ns | 0.0071 |     120 B |
|                   IListToList2 |   16 |  59.749 ns | 0.8095 ns |  1.2117 ns |  59.787 ns |  56.172 ns |  62.078 ns |  60.793 ns | 0.0071 |     120 B |
|              IEnumerableToList |   16 |  86.427 ns | 0.5358 ns |  0.7853 ns |  86.210 ns |  85.359 ns |  87.891 ns |  87.675 ns | 0.0167 |     280 B |
|             IEnumerableToList2 |   16 | 147.515 ns | 1.1475 ns |  1.6821 ns | 147.756 ns | 144.424 ns | 149.833 ns | 149.393 ns | 0.0151 |     256 B |
|                   **ArrayToArray** |   **32** |  **58.291 ns** | **2.3298 ns** |  **3.4150 ns** |  **55.505 ns** |  **54.720 ns** |  **62.724 ns** |  **61.960 ns** | **0.0090** |     **152 B** |
| ArrayToArrayWithoutSourceCheck |   32 |  61.676 ns | 0.1557 ns |  0.2330 ns |  61.673 ns |  61.367 ns |  62.183 ns |  62.020 ns | 0.0090 |     152 B |
|                    ListToArray |   32 |  63.725 ns | 1.0685 ns |  1.5993 ns |  63.762 ns |  61.384 ns |  66.593 ns |  65.666 ns | 0.0090 |     152 B |
|                   ListToArray2 |   32 |  59.262 ns | 2.3131 ns |  3.2427 ns |  61.789 ns |  55.297 ns |  62.760 ns |  62.594 ns | 0.0090 |     152 B |
|                   IListToArray |   32 | 138.266 ns | 2.2501 ns |  3.3678 ns | 138.527 ns | 132.607 ns | 145.784 ns | 142.565 ns | 0.0090 |     152 B |
|                  IListToArray2 |   32 | 103.360 ns | 1.5193 ns |  2.2739 ns | 104.193 ns |  97.120 ns | 105.040 ns | 104.678 ns | 0.0090 |     152 B |
|             IEnumerableToArray |   32 | 121.897 ns | 2.0231 ns |  2.9015 ns | 122.012 ns | 117.426 ns | 125.805 ns | 125.066 ns | 0.0186 |     312 B |
|            IEnumerableToArray2 |   32 | 270.645 ns | 2.5820 ns |  3.8646 ns | 271.542 ns | 264.663 ns | 276.975 ns | 275.383 ns | 0.0332 |     560 B |
|                    ArrayToList |   32 |  80.016 ns | 2.0539 ns |  2.9456 ns |  80.620 ns |  75.154 ns |  87.472 ns |  83.657 ns | 0.0110 |     184 B |
|                     ListToList |   32 |  87.874 ns | 4.3820 ns |  6.5588 ns |  88.195 ns |  75.731 ns |  98.965 ns |  96.862 ns | 0.0110 |     184 B |
|                    ListToList2 |   32 |  84.878 ns | 1.7840 ns |  2.6149 ns |  84.303 ns |  79.836 ns |  90.376 ns |  88.509 ns | 0.0110 |     184 B |
|                    IListToList |   32 | 156.979 ns | 2.7273 ns |  4.0821 ns | 156.115 ns | 151.202 ns | 163.366 ns | 163.091 ns | 0.0110 |     184 B |
|                   IListToList2 |   32 | 104.896 ns | 1.9761 ns |  2.9577 ns | 104.385 ns | 101.761 ns | 110.619 ns | 108.990 ns | 0.0110 |     184 B |
|              IEnumerableToList |   32 | 135.368 ns | 0.4261 ns |  0.6378 ns | 135.357 ns | 134.295 ns | 137.063 ns | 136.095 ns | 0.0205 |     344 B |
|             IEnumerableToList2 |   32 | 261.906 ns | 2.9579 ns |  4.4273 ns | 263.375 ns | 250.753 ns | 267.796 ns | 265.957 ns | 0.0239 |     408 B |
|                   **ArrayToArray** |   **64** | **113.135 ns** | **4.6068 ns** |  **6.7526 ns** | **119.175 ns** | **105.703 ns** | **119.987 ns** | **119.816 ns** | **0.0167** |     **280 B** |
| ArrayToArrayWithoutSourceCheck |   64 | 106.078 ns | 0.1980 ns |  0.2903 ns | 106.055 ns | 105.601 ns | 106.705 ns | 106.495 ns | 0.0167 |     280 B |
|                    ListToArray |   64 | 135.834 ns | 8.5800 ns | 12.5765 ns | 136.744 ns | 122.664 ns | 150.615 ns | 149.788 ns | 0.0166 |     280 B |
|                   ListToArray2 |   64 | 113.491 ns | 8.3515 ns | 11.9775 ns | 106.462 ns | 105.854 ns | 135.993 ns | 135.896 ns | 0.0167 |     280 B |
|                   IListToArray |   64 | 275.105 ns | 2.8965 ns |  4.3353 ns | 276.600 ns | 265.484 ns | 284.263 ns | 278.375 ns | 0.0166 |     280 B |
|                  IListToArray2 |   64 | 191.703 ns | 1.6117 ns |  2.3114 ns | 190.711 ns | 189.022 ns | 197.466 ns | 194.640 ns | 0.0166 |     280 B |
|             IEnumerableToArray |   64 | 211.563 ns | 3.4294 ns |  4.9183 ns | 212.343 ns | 203.350 ns | 218.422 ns | 216.791 ns | 0.0261 |     440 B |
|            IEnumerableToArray2 |   64 | 498.146 ns | 4.0287 ns |  6.0300 ns | 496.214 ns | 490.104 ns | 514.513 ns | 508.726 ns | 0.0576 |     968 B |
|                    ArrayToList |   64 | 148.555 ns | 2.3717 ns |  3.4764 ns | 148.271 ns | 140.965 ns | 156.433 ns | 152.496 ns | 0.0186 |     312 B |
|                     ListToList |   64 | 176.962 ns | 5.6366 ns |  8.4366 ns | 176.981 ns | 158.187 ns | 192.793 ns | 187.908 ns | 0.0186 |     312 B |
|                    ListToList2 |   64 | 157.476 ns | 4.1331 ns |  5.9276 ns | 158.910 ns | 144.628 ns | 166.011 ns | 163.227 ns | 0.0186 |     312 B |
|                    IListToList |   64 | 317.688 ns | 5.3104 ns |  7.7839 ns | 319.018 ns | 303.480 ns | 330.140 ns | 328.725 ns | 0.0186 |     312 B |
|                   IListToList2 |   64 | 204.770 ns | 3.8547 ns |  5.6502 ns | 204.902 ns | 195.087 ns | 216.463 ns | 211.786 ns | 0.0186 |     312 B |
|              IEnumerableToList |   64 | 236.661 ns | 1.1467 ns |  1.7163 ns | 236.211 ns | 234.879 ns | 240.653 ns | 239.393 ns | 0.0281 |     472 B |
|             IEnumerableToList2 |   64 | 487.078 ns | 1.6436 ns |  2.3571 ns | 487.360 ns | 481.456 ns | 490.628 ns | 489.419 ns | 0.0410 |     688 B |
