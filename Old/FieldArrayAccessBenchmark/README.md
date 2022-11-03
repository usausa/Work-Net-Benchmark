``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=5.0.202
  [Host]    : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT
  MediumRun : .NET Core 5.0.5 (CoreCLR 5.0.521.16609, CoreFX 5.0.521.16609), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|       Method | Size |          Mean |      Error |     StdDev |        Median |           Min |           Max |           P90 | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------- |----- |--------------:|-----------:|-----------:|--------------:|--------------:|--------------:|--------------:|------:|------:|------:|----------:|
| **ValueNoLocal** |    **0** |     **0.4348 ns** |  **0.0018 ns** |  **0.0026 ns** |     **0.4344 ns** |     **0.4304 ns** |     **0.4404 ns** |     **0.4383 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |    0 |     0.5445 ns |  0.0784 ns |  0.1099 ns |     0.6443 ns |     0.4311 ns |     0.6546 ns |     0.6515 ns |     - |     - |     - |         - |
| ClassNoLocal |    0 |     0.4347 ns |  0.0017 ns |  0.0025 ns |     0.4340 ns |     0.4316 ns |     0.4406 ns |     0.4383 ns |     - |     - |     - |         - |
|   ClassLocal |    0 |     0.6486 ns |  0.0029 ns |  0.0042 ns |     0.6479 ns |     0.6432 ns |     0.6593 ns |     0.6544 ns |     - |     - |     - |         - |
| **ValueNoLocal** |    **1** |     **0.6501 ns** |  **0.0023 ns** |  **0.0033 ns** |     **0.6487 ns** |     **0.6462 ns** |     **0.6577 ns** |     **0.6554 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |    1 |     0.5099 ns |  0.0084 ns |  0.0122 ns |     0.5046 ns |     0.5002 ns |     0.5390 ns |     0.5326 ns |     - |     - |     - |         - |
| ClassNoLocal |    1 |     3.5642 ns |  0.0738 ns |  0.1058 ns |     3.5006 ns |     3.4413 ns |     3.6960 ns |     3.6812 ns |     - |     - |     - |         - |
|   ClassLocal |    1 |     3.4557 ns |  0.0148 ns |  0.0217 ns |     3.4475 ns |     3.4319 ns |     3.5156 ns |     3.4891 ns |     - |     - |     - |         - |
| **ValueNoLocal** |    **2** |     **1.1145 ns** |  **0.0154 ns** |  **0.0225 ns** |     **1.1233 ns** |     **1.0737 ns** |     **1.1560 ns** |     **1.1321 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |    2 |     0.8081 ns |  0.0119 ns |  0.0174 ns |     0.7970 ns |     0.7888 ns |     0.8304 ns |     0.8283 ns |     - |     - |     - |         - |
| ClassNoLocal |    2 |     7.3122 ns |  0.0261 ns |  0.0357 ns |     7.3103 ns |     7.1843 ns |     7.3865 ns |     7.3462 ns |     - |     - |     - |         - |
|   ClassLocal |    2 |     6.8879 ns |  0.0183 ns |  0.0257 ns |     6.8835 ns |     6.8491 ns |     6.9490 ns |     6.9226 ns |     - |     - |     - |         - |
| **ValueNoLocal** |    **4** |     **1.9411 ns** |  **0.0054 ns** |  **0.0079 ns** |     **1.9398 ns** |     **1.9303 ns** |     **1.9630 ns** |     **1.9512 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |    4 |     1.3968 ns |  0.0030 ns |  0.0042 ns |     1.3967 ns |     1.3912 ns |     1.4075 ns |     1.4019 ns |     - |     - |     - |         - |
| ClassNoLocal |    4 |    14.6038 ns |  0.0368 ns |  0.0527 ns |    14.6127 ns |    14.4446 ns |    14.7257 ns |    14.6453 ns |     - |     - |     - |         - |
|   ClassLocal |    4 |    13.7375 ns |  0.0295 ns |  0.0424 ns |    13.7321 ns |    13.6821 ns |    13.8284 ns |    13.7968 ns |     - |     - |     - |         - |
| **ValueNoLocal** |    **8** |     **3.6517 ns** |  **0.0060 ns** |  **0.0086 ns** |     **3.6503 ns** |     **3.6394 ns** |     **3.6706 ns** |     **3.6627 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |    8 |     2.6822 ns |  0.0060 ns |  0.0086 ns |     2.6812 ns |     2.6700 ns |     2.7025 ns |     2.6943 ns |     - |     - |     - |         - |
| ClassNoLocal |    8 |    29.4074 ns |  0.9098 ns |  1.3336 ns |    29.3743 ns |    27.9686 ns |    31.6718 ns |    31.3383 ns |     - |     - |     - |         - |
|   ClassLocal |    8 |    27.5519 ns |  0.0795 ns |  0.1166 ns |    27.5373 ns |    27.3509 ns |    27.8492 ns |    27.6905 ns |     - |     - |     - |         - |
| **ValueNoLocal** |   **16** |     **7.1948 ns** |  **0.0989 ns** |  **0.1449 ns** |     **7.1171 ns** |     **7.0652 ns** |     **7.4908 ns** |     **7.4058 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |   16 |     5.5096 ns |  0.0169 ns |  0.0247 ns |     5.5075 ns |     5.4684 ns |     5.5595 ns |     5.5404 ns |     - |     - |     - |         - |
| ClassNoLocal |   16 |    55.0358 ns |  0.8171 ns |  1.1976 ns |    55.2394 ns |    53.5996 ns |    56.4882 ns |    56.3707 ns |     - |     - |     - |         - |
|   ClassLocal |   16 |    53.1152 ns |  0.1231 ns |  0.1765 ns |    53.0868 ns |    52.8438 ns |    53.5570 ns |    53.3149 ns |     - |     - |     - |         - |
| **ValueNoLocal** |   **32** |    **13.9651 ns** |  **0.0418 ns** |  **0.0599 ns** |    **13.9557 ns** |    **13.8935 ns** |    **14.1790 ns** |    **14.0415 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |   32 |    12.1347 ns |  0.0368 ns |  0.0528 ns |    12.1227 ns |    12.0792 ns |    12.2912 ns |    12.1968 ns |     - |     - |     - |         - |
| ClassNoLocal |   32 |   111.2285 ns |  1.4568 ns |  2.1805 ns |   110.1706 ns |   109.2744 ns |   117.5887 ns |   114.3802 ns |     - |     - |     - |         - |
|   ClassLocal |   32 |   106.7692 ns |  1.2207 ns |  1.7507 ns |   107.0273 ns |   103.7728 ns |   109.0563 ns |   108.8047 ns |     - |     - |     - |         - |
| **ValueNoLocal** |   **64** |    **31.8685 ns** |  **0.3756 ns** |  **0.5622 ns** |    **32.0949 ns** |    **30.8816 ns** |    **33.0194 ns** |    **32.3617 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |   64 |    25.7786 ns |  0.0526 ns |  0.0787 ns |    25.7596 ns |    25.6640 ns |    25.9749 ns |    25.8889 ns |     - |     - |     - |         - |
| ClassNoLocal |   64 |   227.6439 ns |  1.7927 ns |  2.6833 ns |   228.7809 ns |   221.8519 ns |   232.3305 ns |   230.0427 ns |     - |     - |     - |         - |
|   ClassLocal |   64 |   209.0941 ns |  1.9504 ns |  2.8589 ns |   209.0394 ns |   204.4640 ns |   215.6148 ns |   214.0754 ns |     - |     - |     - |         - |
| **ValueNoLocal** |  **256** |   **114.5259 ns** |  **0.2626 ns** |  **0.3849 ns** |   **114.4851 ns** |   **114.0489 ns** |   **115.3196 ns** |   **115.0939 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal |  256 |   114.9164 ns |  0.3767 ns |  0.5521 ns |   114.9871 ns |   113.0741 ns |   115.7914 ns |   115.6774 ns |     - |     - |     - |         - |
| ClassNoLocal |  256 |   909.7067 ns |  5.6392 ns |  7.7190 ns |   911.5525 ns |   900.3350 ns |   926.1655 ns |   919.3140 ns |     - |     - |     - |         - |
|   ClassLocal |  256 |   840.9860 ns |  6.7876 ns |  9.5152 ns |   843.0358 ns |   828.1718 ns |   855.0079 ns |   852.0020 ns |     - |     - |     - |         - |
| **ValueNoLocal** | **1024** |   **443.9348 ns** |  **0.9606 ns** |  **1.3777 ns** |   **443.5400 ns** |   **442.2691 ns** |   **448.2554 ns** |   **445.6193 ns** |     **-** |     **-** |     **-** |         **-** |
|   ValueLocal | 1024 |   436.0869 ns |  0.7541 ns |  1.0322 ns |   436.1297 ns |   434.6276 ns |   437.8353 ns |   437.4616 ns |     - |     - |     - |         - |
| ClassNoLocal | 1024 | 3,687.2206 ns | 56.5299 ns | 84.6112 ns | 3,710.7738 ns | 3,575.4230 ns | 3,795.4996 ns | 3,776.5295 ns |     - |     - |     - |         - |
|   ClassLocal | 1024 | 3,419.9483 ns | 45.2410 ns | 67.7146 ns | 3,427.9049 ns | 3,336.6184 ns | 3,508.9484 ns | 3,495.6104 ns |     - |     - |     - |         - |