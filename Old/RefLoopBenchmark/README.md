``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1105)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=7.0.102
  [Host]    : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2
  MediumRun : .NET 7.0.2 (7.0.222.60605), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                   Method |  Categories | Size |       Mean |     Error |     StdDev |     Median |        Min |        Max |        P90 | Code Size | Allocated |
|------------------------- |------------ |----- |-----------:|----------:|-----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
|         **ByteCountByIndex** | **Single,Byte** |    **2** |   **2.351 ns** | **0.0103 ns** |  **0.0155 ns** |   **2.350 ns** |   **2.328 ns** |   **2.391 ns** |   **2.369 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |    2 |   1.925 ns | 0.0054 ns |  0.0074 ns |   1.924 ns |   1.913 ns |   1.942 ns |   1.934 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |    2 |   1.916 ns | 0.0037 ns |  0.0055 ns |   1.916 ns |   1.905 ns |   1.926 ns |   1.922 ns |     111 B |         - |
|         **ByteCountByIndex** | **Single,Byte** |    **4** |   **3.596 ns** | **0.0110 ns** |  **0.0161 ns** |   **3.594 ns** |   **3.574 ns** |   **3.628 ns** |   **3.624 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |    4 |   2.872 ns | 0.0768 ns |  0.1101 ns |   2.954 ns |   2.746 ns |   3.002 ns |   2.988 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |    4 |   2.758 ns | 0.0079 ns |  0.0116 ns |   2.757 ns |   2.740 ns |   2.787 ns |   2.770 ns |     111 B |         - |
|         **ByteCountByIndex** | **Single,Byte** |    **8** |   **5.362 ns** | **0.6032 ns** |  **0.8457 ns** |   **6.090 ns** |   **4.425 ns** |   **6.129 ns** |   **6.114 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |    8 |   4.440 ns | 0.0059 ns |  0.0084 ns |   4.442 ns |   4.425 ns |   4.454 ns |   4.450 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |    8 |   4.438 ns | 0.0118 ns |  0.0169 ns |   4.431 ns |   4.415 ns |   4.481 ns |   4.463 ns |     111 B |         - |
|         **ByteCountByIndex** | **Single,Byte** |   **16** |  **11.779 ns** | **0.0371 ns** |  **0.0520 ns** |  **11.758 ns** |  **11.714 ns** |  **11.873 ns** |  **11.845 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |   16 |   8.420 ns | 0.0201 ns |  0.0288 ns |   8.420 ns |   8.371 ns |   8.492 ns |   8.458 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |   16 |   8.432 ns | 0.0254 ns |  0.0365 ns |   8.424 ns |   8.385 ns |   8.537 ns |   8.480 ns |     111 B |         - |
|         **ByteCountByIndex** | **Single,Byte** |   **32** |  **21.832 ns** | **0.0448 ns** |  **0.0627 ns** |  **21.823 ns** |  **21.734 ns** |  **21.989 ns** |  **21.890 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |   32 |  15.279 ns | 0.0768 ns |  0.1102 ns |  15.277 ns |  15.084 ns |  15.498 ns |  15.401 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |   32 |  15.170 ns | 0.0397 ns |  0.0582 ns |  15.181 ns |  15.082 ns |  15.294 ns |  15.235 ns |     111 B |         - |
|         **ByteCountByIndex** | **Single,Byte** |   **64** |  **44.923 ns** | **0.1552 ns** |  **0.2226 ns** |  **44.837 ns** |  **44.696 ns** |  **45.506 ns** |  **45.314 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |   64 |  31.631 ns | 0.0592 ns |  0.0790 ns |  31.622 ns |  31.505 ns |  31.833 ns |  31.739 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |   64 |  31.662 ns | 0.2430 ns |  0.3407 ns |  31.539 ns |  31.341 ns |  32.736 ns |  32.172 ns |     111 B |         - |
|         **ByteCountByIndex** | **Single,Byte** |  **128** |  **85.007 ns** | **0.1308 ns** |  **0.1876 ns** |  **85.034 ns** |  **84.698 ns** |  **85.350 ns** |  **85.229 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |  128 |  58.543 ns | 0.1439 ns |  0.2110 ns |  58.439 ns |  58.311 ns |  59.050 ns |  58.820 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |  128 |  58.323 ns | 0.0722 ns |  0.0964 ns |  58.327 ns |  58.153 ns |  58.486 ns |  58.452 ns |     111 B |         - |
|         **ByteCountByIndex** | **Single,Byte** |  **256** | **165.871 ns** | **0.3569 ns** |  **0.5003 ns** | **165.856 ns** | **164.941 ns** | **167.217 ns** | **166.441 ns** |     **121 B** |         **-** |
|           ByteCountByRef | Single,Byte |  256 | 112.474 ns | 0.2962 ns |  0.4247 ns | 112.398 ns | 111.977 ns | 113.480 ns | 113.148 ns |     132 B |         - |
|     ByteCountByRefLength | Single,Byte |  256 | 112.372 ns | 0.2967 ns |  0.4256 ns | 112.314 ns | 111.749 ns | 113.404 ns | 112.987 ns |     111 B |         - |
|                          |             |      |            |           |            |            |            |            |            |           |           |
|         **CharCountByIndex** | **Single,Char** |    **2** |   **2.339 ns** | **0.0071 ns** |  **0.0104 ns** |   **2.338 ns** |   **2.322 ns** |   **2.362 ns** |   **2.355 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |    2 |   1.921 ns | 0.0033 ns |  0.0048 ns |   1.922 ns |   1.910 ns |   1.929 ns |   1.927 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |    2 |   1.914 ns | 0.0039 ns |  0.0052 ns |   1.913 ns |   1.906 ns |   1.930 ns |   1.920 ns |     113 B |         - |
|         **CharCountByIndex** | **Single,Char** |    **4** |   **3.582 ns** | **0.0049 ns** |  **0.0071 ns** |   **3.581 ns** |   **3.572 ns** |   **3.597 ns** |   **3.594 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |    4 |   2.754 ns | 0.0039 ns |  0.0053 ns |   2.754 ns |   2.746 ns |   2.764 ns |   2.761 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |    4 |   2.752 ns | 0.0059 ns |  0.0086 ns |   2.749 ns |   2.742 ns |   2.774 ns |   2.764 ns |     113 B |         - |
|         **CharCountByIndex** | **Single,Char** |    **8** |   **6.103 ns** | **0.0094 ns** |  **0.0129 ns** |   **6.099 ns** |   **6.085 ns** |   **6.131 ns** |   **6.125 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |    8 |   4.436 ns | 0.0107 ns |  0.0154 ns |   4.433 ns |   4.417 ns |   4.465 ns |   4.460 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |    8 |   4.429 ns | 0.0096 ns |  0.0140 ns |   4.429 ns |   4.410 ns |   4.453 ns |   4.451 ns |     113 B |         - |
|         **CharCountByIndex** | **Single,Char** |   **16** |  **11.743 ns** | **0.0138 ns** |  **0.0202 ns** |  **11.743 ns** |  **11.704 ns** |  **11.782 ns** |  **11.770 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |   16 |   8.409 ns | 0.0136 ns |  0.0195 ns |   8.408 ns |   8.369 ns |   8.448 ns |   8.433 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |   16 |   8.428 ns | 0.0241 ns |  0.0353 ns |   8.424 ns |   8.369 ns |   8.515 ns |   8.473 ns |     113 B |         - |
|         **CharCountByIndex** | **Single,Char** |   **32** |  **21.844 ns** | **0.0490 ns** |  **0.0687 ns** |  **21.854 ns** |  **21.746 ns** |  **22.009 ns** |  **21.915 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |   32 |  15.178 ns | 0.0482 ns |  0.0722 ns |  15.177 ns |  15.058 ns |  15.337 ns |  15.276 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |   32 |  15.145 ns | 0.0223 ns |  0.0298 ns |  15.142 ns |  15.102 ns |  15.234 ns |  15.173 ns |     113 B |         - |
|         **CharCountByIndex** | **Single,Char** |   **64** |  **45.130 ns** | **0.1193 ns** |  **0.1749 ns** |  **45.129 ns** |  **44.807 ns** |  **45.553 ns** |  **45.320 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |   64 |  31.710 ns | 0.0910 ns |  0.1246 ns |  31.703 ns |  31.486 ns |  32.047 ns |  31.852 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |   64 |  31.503 ns | 0.1016 ns |  0.1489 ns |  31.495 ns |  31.309 ns |  31.930 ns |  31.665 ns |     113 B |         - |
|         **CharCountByIndex** | **Single,Char** |  **128** |  **85.287 ns** | **0.1772 ns** |  **0.2484 ns** |  **85.246 ns** |  **84.932 ns** |  **85.996 ns** |  **85.586 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |  128 |  58.611 ns | 0.1330 ns |  0.1991 ns |  58.631 ns |  58.304 ns |  58.958 ns |  58.834 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |  128 |  58.503 ns | 0.1685 ns |  0.2470 ns |  58.436 ns |  58.205 ns |  59.222 ns |  58.802 ns |     113 B |         - |
|         **CharCountByIndex** | **Single,Char** |  **256** | **165.650 ns** | **0.2397 ns** |  **0.3282 ns** | **165.686 ns** | **164.987 ns** | **166.334 ns** | **165.992 ns** |     **122 B** |         **-** |
|           CharCountByRef | Single,Char |  256 | 112.525 ns | 0.3312 ns |  0.4855 ns | 112.558 ns | 111.906 ns | 113.908 ns | 112.946 ns |     134 B |         - |
|     CharCountByRefLength | Single,Char |  256 | 113.058 ns | 0.9415 ns |  1.4092 ns | 112.488 ns | 111.842 ns | 117.474 ns | 115.027 ns |     113 B |         - |
|                          |             |      |            |           |            |            |            |            |            |           |           |
|          **IntCountByIndex** |  **Single,Int** |    **2** |   **2.337 ns** | **0.0068 ns** |  **0.0100 ns** |   **2.337 ns** |   **2.322 ns** |   **2.360 ns** |   **2.348 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |    2 |   1.922 ns | 0.0099 ns |  0.0148 ns |   1.917 ns |   1.912 ns |   1.969 ns |   1.948 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |    2 |   1.913 ns | 0.0022 ns |  0.0031 ns |   1.914 ns |   1.906 ns |   1.919 ns |   1.917 ns |     112 B |         - |
|          **IntCountByIndex** |  **Single,Int** |    **4** |   **3.591 ns** | **0.0136 ns** |  **0.0187 ns** |   **3.585 ns** |   **3.576 ns** |   **3.639 ns** |   **3.624 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |    4 |   2.758 ns | 0.0072 ns |  0.0107 ns |   2.755 ns |   2.746 ns |   2.792 ns |   2.772 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |    4 |   2.757 ns | 0.0066 ns |  0.0098 ns |   2.758 ns |   2.740 ns |   2.777 ns |   2.767 ns |     112 B |         - |
|          **IntCountByIndex** |  **Single,Int** |    **8** |   **6.104 ns** | **0.0174 ns** |  **0.0233 ns** |   **6.097 ns** |   **6.073 ns** |   **6.181 ns** |   **6.129 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |    8 |   4.442 ns | 0.0132 ns |  0.0185 ns |   4.437 ns |   4.423 ns |   4.509 ns |   4.460 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |    8 |   4.431 ns | 0.0099 ns |  0.0139 ns |   4.429 ns |   4.416 ns |   4.481 ns |   4.447 ns |     112 B |         - |
|          **IntCountByIndex** |  **Single,Int** |   **16** |  **11.745 ns** | **0.0158 ns** |  **0.0211 ns** |  **11.748 ns** |  **11.712 ns** |  **11.786 ns** |  **11.773 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |   16 |   8.438 ns | 0.0266 ns |  0.0373 ns |   8.434 ns |   8.387 ns |   8.567 ns |   8.475 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |   16 |   8.466 ns | 0.0577 ns |  0.0828 ns |   8.435 ns |   8.376 ns |   8.699 ns |   8.568 ns |     112 B |         - |
|          **IntCountByIndex** |  **Single,Int** |   **32** |  **21.801 ns** | **0.0259 ns** |  **0.0372 ns** |  **21.797 ns** |  **21.739 ns** |  **21.884 ns** |  **21.842 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |   32 |  15.155 ns | 0.0301 ns |  0.0441 ns |  15.152 ns |  15.077 ns |  15.235 ns |  15.205 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |   32 |  15.107 ns | 0.0200 ns |  0.0267 ns |  15.108 ns |  15.057 ns |  15.152 ns |  15.145 ns |     112 B |         - |
|          **IntCountByIndex** |  **Single,Int** |   **64** |  **44.789 ns** | **0.0680 ns** |  **0.1018 ns** |  **44.775 ns** |  **44.658 ns** |  **45.017 ns** |  **44.936 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |   64 |  31.493 ns | 0.0657 ns |  0.0921 ns |  31.479 ns |  31.346 ns |  31.665 ns |  31.632 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |   64 |  31.273 ns | 0.0969 ns |  0.1420 ns |  31.220 ns |  31.119 ns |  31.714 ns |  31.468 ns |     112 B |         - |
|          **IntCountByIndex** |  **Single,Int** |  **128** |  **85.348 ns** | **0.3106 ns** |  **0.4553 ns** |  **85.244 ns** |  **84.717 ns** |  **86.660 ns** |  **85.941 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |  128 |  58.373 ns | 0.0850 ns |  0.1245 ns |  58.348 ns |  58.210 ns |  58.674 ns |  58.536 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |  128 |  58.250 ns | 0.2201 ns |  0.3294 ns |  58.245 ns |  57.911 ns |  59.049 ns |  58.625 ns |     112 B |         - |
|          **IntCountByIndex** |  **Single,Int** |  **256** | **165.441 ns** | **0.2048 ns** |  **0.2871 ns** | **165.374 ns** | **164.792 ns** | **166.308 ns** | **165.703 ns** |     **121 B** |         **-** |
|            IntCountByRef |  Single,Int |  256 | 111.947 ns | 0.1168 ns |  0.1599 ns | 111.931 ns | 111.684 ns | 112.373 ns | 112.127 ns |     133 B |         - |
|      IntCountByRefLength |  Single,Int |  256 | 111.736 ns | 0.1123 ns |  0.1537 ns | 111.711 ns | 111.488 ns | 112.012 ns | 111.974 ns |     112 B |         - |
|                          |             |      |            |           |            |            |            |            |            |           |           |
|         **LongCountByIndex** | **Single,Long** |    **2** |   **2.334 ns** | **0.0043 ns** |  **0.0062 ns** |   **2.334 ns** |   **2.324 ns** |   **2.346 ns** |   **2.343 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |    2 |   2.347 ns | 0.0117 ns |  0.0175 ns |   2.342 ns |   2.322 ns |   2.390 ns |   2.373 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |    2 |   1.919 ns | 0.0053 ns |  0.0080 ns |   1.917 ns |   1.909 ns |   1.937 ns |   1.929 ns |     113 B |         - |
|         **LongCountByIndex** | **Single,Long** |    **4** |   **3.589 ns** | **0.0089 ns** |  **0.0131 ns** |   **3.589 ns** |   **3.573 ns** |   **3.627 ns** |   **3.604 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |    4 |   3.174 ns | 0.0090 ns |  0.0132 ns |   3.169 ns |   3.160 ns |   3.217 ns |   3.190 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |    4 |   2.756 ns | 0.0054 ns |  0.0077 ns |   2.755 ns |   2.745 ns |   2.776 ns |   2.765 ns |     113 B |         - |
|         **LongCountByIndex** | **Single,Long** |    **8** |   **6.104 ns** | **0.0119 ns** |  **0.0167 ns** |   **6.102 ns** |   **6.081 ns** |   **6.157 ns** |   **6.124 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |    8 |   4.851 ns | 0.0078 ns |  0.0112 ns |   4.850 ns |   4.830 ns |   4.876 ns |   4.865 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |    8 |   4.437 ns | 0.0111 ns |  0.0166 ns |   4.434 ns |   4.405 ns |   4.477 ns |   4.457 ns |     113 B |         - |
|         **LongCountByIndex** | **Single,Long** |   **16** |  **11.767 ns** | **0.0247 ns** |  **0.0354 ns** |  **11.770 ns** |  **11.704 ns** |  **11.881 ns** |  **11.798 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |   16 |   8.813 ns | 0.0137 ns |  0.0201 ns |   8.808 ns |   8.780 ns |   8.858 ns |   8.834 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |   16 |   8.422 ns | 0.0254 ns |  0.0380 ns |   8.427 ns |   8.362 ns |   8.490 ns |   8.467 ns |     113 B |         - |
|         **LongCountByIndex** | **Single,Long** |   **32** |  **21.810 ns** | **0.0439 ns** |  **0.0615 ns** |  **21.798 ns** |  **21.728 ns** |  **21.951 ns** |  **21.898 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |   32 |  15.526 ns | 0.0301 ns |  0.0442 ns |  15.521 ns |  15.466 ns |  15.633 ns |  15.581 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |   32 |  15.106 ns | 0.0190 ns |  0.0273 ns |  15.100 ns |  15.064 ns |  15.165 ns |  15.137 ns |     113 B |         - |
|         **LongCountByIndex** | **Single,Long** |   **64** |  **45.037 ns** | **0.1227 ns** |  **0.1720 ns** |  **45.060 ns** |  **44.710 ns** |  **45.385 ns** |  **45.227 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |   64 |  32.035 ns | 0.0584 ns |  0.0855 ns |  32.033 ns |  31.875 ns |  32.233 ns |  32.142 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |   64 |  31.222 ns | 0.0627 ns |  0.0858 ns |  31.209 ns |  31.062 ns |  31.443 ns |  31.322 ns |     113 B |         - |
|         **LongCountByIndex** | **Single,Long** |  **128** |  **71.551 ns** | **9.0572 ns** | **13.2760 ns** |  **59.383 ns** |  **58.597 ns** |  **85.456 ns** |  **85.296 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |  128 |  59.001 ns | 0.2064 ns |  0.3090 ns |  58.888 ns |  58.600 ns |  59.660 ns |  59.393 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |  128 |  58.060 ns | 0.0862 ns |  0.1208 ns |  58.036 ns |  57.877 ns |  58.418 ns |  58.181 ns |     113 B |         - |
|         **LongCountByIndex** | **Single,Long** |  **256** | **165.783 ns** | **0.4809 ns** |  **0.6741 ns** | **165.714 ns** | **164.728 ns** | **167.273 ns** | **166.898 ns** |     **121 B** |         **-** |
|           LongCountByRef | Single,Long |  256 | 112.589 ns | 0.2145 ns |  0.3076 ns | 112.523 ns | 112.143 ns | 113.272 ns | 113.100 ns |     134 B |         - |
|     LongCountByRefLength | Single,Long |  256 | 119.196 ns | 7.0310 ns | 10.3059 ns | 113.225 ns | 111.462 ns | 150.503 ns | 132.039 ns |     113 B |         - |
|                          |             |      |            |           |            |            |            |            |            |           |           |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |    **2** |   **2.793 ns** | **0.0109 ns** |  **0.0156 ns** |   **2.790 ns** |   **2.771 ns** |   **2.828 ns** |   **2.813 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |    2 |   2.573 ns | 0.0086 ns |  0.0120 ns |   2.572 ns |   2.553 ns |   2.597 ns |   2.590 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |    2 |   2.362 ns | 0.0111 ns |  0.0166 ns |   2.365 ns |   2.340 ns |   2.389 ns |   2.382 ns |     178 B |         - |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |    **4** |   **4.479 ns** | **0.0230 ns** |  **0.0344 ns** |   **4.479 ns** |   **4.434 ns** |   **4.541 ns** |   **4.526 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |    4 |   3.843 ns | 0.0095 ns |  0.0142 ns |   3.845 ns |   3.821 ns |   3.869 ns |   3.864 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |    4 |   3.630 ns | 0.0119 ns |  0.0177 ns |   3.624 ns |   3.607 ns |   3.672 ns |   3.654 ns |     178 B |         - |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |    **8** |   **7.946 ns** | **0.1076 ns** |  **0.1543 ns** |   **7.887 ns** |   **7.819 ns** |   **8.431 ns** |   **8.180 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |    8 |   6.385 ns | 0.0170 ns |  0.0254 ns |   6.376 ns |   6.351 ns |   6.449 ns |   6.415 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |    8 |   6.190 ns | 0.0222 ns |  0.0325 ns |   6.180 ns |   6.152 ns |   6.259 ns |   6.244 ns |     178 B |         - |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |   **16** |  **15.276 ns** | **0.0399 ns** |  **0.0596 ns** |  **15.266 ns** |  **15.184 ns** |  **15.370 ns** |  **15.352 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |   16 |  12.096 ns | 0.0331 ns |  0.0495 ns |  12.079 ns |  12.028 ns |  12.219 ns |  12.146 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |   16 |  11.912 ns | 0.0520 ns |  0.0746 ns |  11.932 ns |  11.791 ns |  12.021 ns |  11.990 ns |     178 B |         - |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |   **32** |  **28.819 ns** | **0.1060 ns** |  **0.1521 ns** |  **28.777 ns** |  **28.588 ns** |  **29.129 ns** |  **29.039 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |   32 |  22.244 ns | 0.0778 ns |  0.1115 ns |  22.221 ns |  22.043 ns |  22.490 ns |  22.401 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |   32 |  22.071 ns | 0.0504 ns |  0.0738 ns |  22.057 ns |  21.969 ns |  22.281 ns |  22.152 ns |     178 B |         - |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |   **64** |  **59.166 ns** | **0.1789 ns** |  **0.2388 ns** |  **59.067 ns** |  **58.773 ns** |  **59.703 ns** |  **59.418 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |   64 |  45.746 ns | 0.1183 ns |  0.1771 ns |  45.708 ns |  45.494 ns |  46.173 ns |  45.934 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |   64 |  45.805 ns | 0.1326 ns |  0.1985 ns |  45.761 ns |  45.526 ns |  46.302 ns |  46.051 ns |     178 B |         - |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |  **128** | **113.421 ns** | **0.2356 ns** |  **0.3225 ns** | **113.321 ns** | **113.023 ns** | **114.067 ns** | **113.911 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |  128 |  86.736 ns | 0.3306 ns |  0.4948 ns |  86.789 ns |  85.734 ns |  87.461 ns |  87.278 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |  128 |  87.167 ns | 0.8121 ns |  1.2155 ns |  86.978 ns |  85.714 ns |  90.694 ns |  88.743 ns |     178 B |         - |
|     **ByteCountByIndexTwin** |   **Twin,Byte** |  **256** | **222.526 ns** | **0.6865 ns** |  **1.0062 ns** | **222.242 ns** | **221.275 ns** | **224.968 ns** | **223.664 ns** |     **203 B** |         **-** |
|       ByteCountByRefTwin |   Twin,Byte |  256 | 168.231 ns | 0.8983 ns |  1.3167 ns | 167.818 ns | 166.696 ns | 171.957 ns | 170.089 ns |     195 B |         - |
| ByteCountByRefLengthTwin |   Twin,Byte |  256 | 168.159 ns | 0.7081 ns |  1.0599 ns | 168.450 ns | 166.643 ns | 169.774 ns | 169.546 ns |     178 B |         - |
|                          |             |      |            |           |            |            |            |            |            |           |           |
|     **CharCountByIndexTwin** |   **Twin,Char** |    **2** |   **2.793 ns** | **0.0100 ns** |  **0.0147 ns** |   **2.786 ns** |   **2.775 ns** |   **2.822 ns** |   **2.816 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |    2 |   2.577 ns | 0.0106 ns |  0.0156 ns |   2.581 ns |   2.553 ns |   2.602 ns |   2.598 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |    2 |   2.369 ns | 0.0102 ns |  0.0153 ns |   2.367 ns |   2.347 ns |   2.392 ns |   2.389 ns |     181 B |         - |
|     **CharCountByIndexTwin** |   **Twin,Char** |    **4** |   **4.500 ns** | **0.0295 ns** |  **0.0442 ns** |   **4.499 ns** |   **4.443 ns** |   **4.600 ns** |   **4.557 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |    4 |   3.852 ns | 0.0164 ns |  0.0245 ns |   3.849 ns |   3.814 ns |   3.906 ns |   3.881 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |    4 |   3.650 ns | 0.0120 ns |  0.0176 ns |   3.652 ns |   3.616 ns |   3.691 ns |   3.667 ns |     181 B |         - |
|     **CharCountByIndexTwin** |   **Twin,Char** |    **8** |   **7.924 ns** | **0.0546 ns** |  **0.0765 ns** |   **7.906 ns** |   **7.824 ns** |   **8.060 ns** |   **8.038 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |    8 |   6.393 ns | 0.0291 ns |  0.0426 ns |   6.404 ns |   6.340 ns |   6.522 ns |   6.438 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |    8 |   6.207 ns | 0.0423 ns |  0.0607 ns |   6.210 ns |   6.128 ns |   6.375 ns |   6.263 ns |     181 B |         - |
|     **CharCountByIndexTwin** |   **Twin,Char** |   **16** |  **15.326 ns** | **0.0817 ns** |  **0.1223 ns** |  **15.347 ns** |  **15.178 ns** |  **15.632 ns** |  **15.452 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |   16 |  12.085 ns | 0.0443 ns |  0.0650 ns |  12.089 ns |  12.008 ns |  12.223 ns |  12.168 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |   16 |  11.922 ns | 0.0447 ns |  0.0670 ns |  11.920 ns |  11.814 ns |  12.060 ns |  12.028 ns |     181 B |         - |
|     **CharCountByIndexTwin** |   **Twin,Char** |   **32** |  **28.900 ns** | **0.1452 ns** |  **0.2128 ns** |  **28.863 ns** |  **28.657 ns** |  **29.447 ns** |  **29.140 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |   32 |  22.282 ns | 0.0953 ns |  0.1427 ns |  22.303 ns |  22.089 ns |  22.639 ns |  22.419 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |   32 |  22.167 ns | 0.0560 ns |  0.0821 ns |  22.145 ns |  22.058 ns |  22.343 ns |  22.282 ns |     181 B |         - |
|     **CharCountByIndexTwin** |   **Twin,Char** |   **64** |  **59.288 ns** | **0.1290 ns** |  **0.1891 ns** |  **59.243 ns** |  **59.004 ns** |  **59.673 ns** |  **59.575 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |   64 |  45.950 ns | 0.1410 ns |  0.2111 ns |  45.867 ns |  45.663 ns |  46.321 ns |  46.267 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |   64 |  46.399 ns | 0.3009 ns |  0.4504 ns |  46.321 ns |  45.640 ns |  47.401 ns |  46.997 ns |     181 B |         - |
|     **CharCountByIndexTwin** |   **Twin,Char** |  **128** | **113.932 ns** | **0.3511 ns** |  **0.5146 ns** | **113.721 ns** | **113.366 ns** | **115.508 ns** | **114.561 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |  128 |  86.928 ns | 0.3952 ns |  0.5793 ns |  86.717 ns |  86.204 ns |  88.088 ns |  87.743 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |  128 |  87.050 ns | 0.3213 ns |  0.4809 ns |  87.074 ns |  86.176 ns |  87.976 ns |  87.646 ns |     181 B |         - |
|     **CharCountByIndexTwin** |   **Twin,Char** |  **256** | **222.672 ns** | **0.5708 ns** |  **0.8366 ns** | **222.379 ns** | **221.421 ns** | **224.037 ns** | **223.844 ns** |     **205 B** |         **-** |
|       CharCountByRefTwin |   Twin,Char |  256 | 169.582 ns | 1.8646 ns |  2.7331 ns | 168.586 ns | 167.655 ns | 177.281 ns | 173.215 ns |     198 B |         - |
| CharCountByRefLengthTwin |   Twin,Char |  256 | 169.229 ns | 0.7180 ns |  1.0524 ns | 168.928 ns | 168.021 ns | 171.693 ns | 170.931 ns |     181 B |         - |
|                          |             |      |            |           |            |            |            |            |            |           |           |
|      **IntCountByIndexTwin** |    **Twin,Int** |    **2** |   **3.015 ns** | **0.0114 ns** |  **0.0167 ns** |   **3.013 ns** |   **2.989 ns** |   **3.068 ns** |   **3.035 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |    2 |   2.998 ns | 0.0129 ns |  0.0188 ns |   2.992 ns |   2.975 ns |   3.054 ns |   3.023 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |    2 |   2.788 ns | 0.0111 ns |  0.0166 ns |   2.788 ns |   2.763 ns |   2.821 ns |   2.809 ns |     179 B |         - |
|      **IntCountByIndexTwin** |    **Twin,Int** |    **4** |   **4.701 ns** | **0.0215 ns** |  **0.0315 ns** |   **4.702 ns** |   **4.657 ns** |   **4.761 ns** |   **4.740 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |    4 |   4.279 ns | 0.0213 ns |  0.0319 ns |   4.280 ns |   4.229 ns |   4.336 ns |   4.316 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |    4 |   4.074 ns | 0.0242 ns |  0.0362 ns |   4.073 ns |   4.023 ns |   4.165 ns |   4.139 ns |     179 B |         - |
|      **IntCountByIndexTwin** |    **Twin,Int** |    **8** |   **8.390 ns** | **0.1698 ns** |  **0.2380 ns** |   **8.332 ns** |   **8.063 ns** |   **8.866 ns** |   **8.691 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |    8 |   6.845 ns | 0.0272 ns |  0.0407 ns |   6.845 ns |   6.794 ns |   6.937 ns |   6.906 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |    8 |   6.658 ns | 0.0485 ns |  0.0712 ns |   6.639 ns |   6.564 ns |   6.851 ns |   6.755 ns |     179 B |         - |
|      **IntCountByIndexTwin** |    **Twin,Int** |   **16** |  **15.557 ns** | **0.1032 ns** |  **0.1544 ns** |  **15.531 ns** |  **15.361 ns** |  **15.834 ns** |  **15.754 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |   16 |  12.545 ns | 0.0631 ns |  0.0944 ns |  12.551 ns |  12.427 ns |  12.711 ns |  12.690 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |   16 |  12.366 ns | 0.0588 ns |  0.0880 ns |  12.374 ns |  12.238 ns |  12.500 ns |  12.475 ns |     179 B |         - |
|      **IntCountByIndexTwin** |    **Twin,Int** |   **32** |  **29.092 ns** | **0.1358 ns** |  **0.2032 ns** |  **28.951 ns** |  **28.887 ns** |  **29.492 ns** |  **29.405 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |   32 |  22.833 ns | 0.1047 ns |  0.1567 ns |  22.843 ns |  22.554 ns |  23.068 ns |  23.025 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |   32 |  22.586 ns | 0.0857 ns |  0.1256 ns |  22.567 ns |  22.373 ns |  22.821 ns |  22.746 ns |     179 B |         - |
|      **IntCountByIndexTwin** |    **Twin,Int** |   **64** |  **59.684 ns** | **0.3187 ns** |  **0.4769 ns** |  **59.718 ns** |  **59.052 ns** |  **60.645 ns** |  **60.221 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |   64 |  46.266 ns | 0.1058 ns |  0.1551 ns |  46.214 ns |  46.073 ns |  46.643 ns |  46.517 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |   64 |  46.446 ns | 0.2143 ns |  0.3208 ns |  46.309 ns |  46.120 ns |  47.372 ns |  46.821 ns |     179 B |         - |
|      **IntCountByIndexTwin** |    **Twin,Int** |  **128** | **113.873 ns** | **0.5553 ns** |  **0.8311 ns** | **113.709 ns** | **112.901 ns** | **115.529 ns** | **114.958 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |  128 |  87.031 ns | 0.3247 ns |  0.4552 ns |  86.956 ns |  86.350 ns |  88.016 ns |  87.698 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |  128 |  87.208 ns | 0.2261 ns |  0.3242 ns |  87.120 ns |  86.753 ns |  87.934 ns |  87.708 ns |     179 B |         - |
|      **IntCountByIndexTwin** |    **Twin,Int** |  **256** | **224.639 ns** | **1.8545 ns** |  **2.6597 ns** | **223.995 ns** | **221.127 ns** | **232.123 ns** | **227.750 ns** |     **203 B** |         **-** |
|        IntCountByRefTwin |    Twin,Int |  256 | 169.096 ns | 0.6723 ns |  1.0062 ns | 169.055 ns | 167.257 ns | 170.970 ns | 170.447 ns |     196 B |         - |
|  IntCountByRefLengthTwin |    Twin,Int |  256 | 169.038 ns | 0.5480 ns |  0.8032 ns | 168.949 ns | 167.426 ns | 170.492 ns | 170.151 ns |     179 B |         - |
|                          |             |      |            |           |            |            |            |            |            |           |           |
|     **LongCountByIndexTwin** |   **Twin,Long** |    **2** |   **3.011 ns** | **0.0044 ns** |  **0.0060 ns** |   **3.010 ns** |   **3.001 ns** |   **3.025 ns** |   **3.018 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |    2 |   2.787 ns | 0.0053 ns |  0.0077 ns |   2.784 ns |   2.774 ns |   2.804 ns |   2.800 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |    2 |   2.582 ns | 0.0125 ns |  0.0170 ns |   2.582 ns |   2.556 ns |   2.623 ns |   2.601 ns |     181 B |         - |
|     **LongCountByIndexTwin** |   **Twin,Long** |    **4** |   **4.709 ns** | **0.0231 ns** |  **0.0346 ns** |   **4.715 ns** |   **4.661 ns** |   **4.771 ns** |   **4.753 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |    4 |   4.081 ns | 0.0204 ns |  0.0300 ns |   4.089 ns |   4.029 ns |   4.135 ns |   4.110 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |    4 |   3.873 ns | 0.0150 ns |  0.0215 ns |   3.877 ns |   3.837 ns |   3.915 ns |   3.900 ns |     181 B |         - |
|     **LongCountByIndexTwin** |   **Twin,Long** |    **8** |   **8.154 ns** | **0.0581 ns** |  **0.0851 ns** |   **8.144 ns** |   **8.032 ns** |   **8.361 ns** |   **8.256 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |    8 |   6.637 ns | 0.0267 ns |  0.0400 ns |   6.639 ns |   6.568 ns |   6.738 ns |   6.685 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |    8 |   6.416 ns | 0.0174 ns |  0.0255 ns |   6.415 ns |   6.376 ns |   6.480 ns |   6.450 ns |     181 B |         - |
|     **LongCountByIndexTwin** |   **Twin,Long** |   **16** |  **15.594 ns** | **0.0839 ns** |  **0.1229 ns** |  **15.620 ns** |  **15.372 ns** |  **15.861 ns** |  **15.723 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |   16 |  12.381 ns | 0.0719 ns |  0.1054 ns |  12.371 ns |  12.251 ns |  12.668 ns |  12.485 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |   16 |  12.162 ns | 0.0381 ns |  0.0571 ns |  12.140 ns |  12.054 ns |  12.281 ns |  12.232 ns |     181 B |         - |
|     **LongCountByIndexTwin** |   **Twin,Long** |   **32** |  **29.484 ns** | **0.2679 ns** |  **0.3756 ns** |  **29.441 ns** |  **28.966 ns** |  **30.321 ns** |  **29.963 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |   32 |  22.665 ns | 0.1241 ns |  0.1780 ns |  22.649 ns |  22.409 ns |  23.041 ns |  22.893 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |   32 |  22.417 ns | 0.0908 ns |  0.1359 ns |  22.448 ns |  22.153 ns |  22.593 ns |  22.580 ns |     181 B |         - |
|     **LongCountByIndexTwin** |   **Twin,Long** |   **64** |  **59.646 ns** | **0.2022 ns** |  **0.2963 ns** |  **59.733 ns** |  **59.117 ns** |  **60.394 ns** |  **59.907 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |   64 |  46.443 ns | 0.1467 ns |  0.2150 ns |  46.446 ns |  46.006 ns |  46.835 ns |  46.721 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |   64 |  46.233 ns | 0.1819 ns |  0.2490 ns |  46.185 ns |  45.928 ns |  47.062 ns |  46.503 ns |     181 B |         - |
|     **LongCountByIndexTwin** |   **Twin,Long** |  **128** | **114.477 ns** | **0.5788 ns** |  **0.8663 ns** | **114.284 ns** | **113.217 ns** | **116.453 ns** | **115.595 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |  128 |  87.424 ns | 0.3152 ns |  0.4620 ns |  87.256 ns |  86.714 ns |  88.558 ns |  88.059 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |  128 |  87.146 ns | 0.2648 ns |  0.3798 ns |  87.092 ns |  86.571 ns |  88.106 ns |  87.644 ns |     181 B |         - |
|     **LongCountByIndexTwin** |   **Twin,Long** |  **256** | **223.409 ns** | **0.8679 ns** |  **1.2722 ns** | **223.478 ns** | **221.430 ns** | **226.470 ns** | **225.362 ns** |     **203 B** |         **-** |
|       LongCountByRefTwin |   Twin,Long |  256 | 168.842 ns | 0.4568 ns |  0.6404 ns | 168.910 ns | 167.753 ns | 170.052 ns | 169.694 ns |     198 B |         - |
| LongCountByRefLengthTwin |   Twin,Long |  256 | 169.065 ns | 0.4317 ns |  0.6328 ns | 169.022 ns | 167.907 ns | 170.402 ns | 170.004 ns |     181 B |         - |
