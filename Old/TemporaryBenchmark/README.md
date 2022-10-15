``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.202
  [Host]    : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  MediumRun : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                Method | Size |         Mean |      Error |     StdDev |       Median |          Min |          Max |          P90 |  Gen 0 | Allocated |
|---------------------- |----- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------------:|-------:|----------:|
|    **WithTemporaryFill1** |   **16** |    **12.231 ns** |  **0.2150 ns** |  **0.3151 ns** |    **12.435 ns** |    **11.870 ns** |    **12.597 ns** |    **12.572 ns** |      **-** |         **-** |
| WithoutTemporaryFill1 |   16 |     6.819 ns |  0.0206 ns |  0.0289 ns |     6.818 ns |     6.770 ns |     6.890 ns |     6.858 ns |      - |         - |
|    WithTemporaryFill2 |   16 |    12.349 ns |  0.0447 ns |  0.0670 ns |    12.332 ns |    12.234 ns |    12.462 ns |    12.447 ns |      - |         - |
| WithoutTemporaryFill2 |   16 |     6.899 ns |  0.1150 ns |  0.1686 ns |     6.833 ns |     6.793 ns |     7.438 ns |     7.222 ns |      - |         - |
|    WithTemporaryFill3 |   16 |    13.378 ns |  0.0728 ns |  0.1067 ns |    13.384 ns |    13.192 ns |    13.523 ns |    13.499 ns |      - |         - |
| WithoutTemporaryFill3 |   16 |     6.926 ns |  0.0920 ns |  0.1290 ns |     6.834 ns |     6.777 ns |     7.146 ns |     7.061 ns |      - |         - |
|    **WithTemporaryFill1** |   **64** |    **22.328 ns** |  **0.1938 ns** |  **0.2840 ns** |    **22.191 ns** |    **21.956 ns** |    **22.886 ns** |    **22.681 ns** |      **-** |         **-** |
| WithoutTemporaryFill1 |   64 |    19.281 ns |  0.0700 ns |  0.1026 ns |    19.303 ns |    19.093 ns |    19.413 ns |    19.406 ns |      - |         - |
|    WithTemporaryFill2 |   64 |    22.514 ns |  0.1183 ns |  0.1734 ns |    22.533 ns |    22.137 ns |    22.984 ns |    22.734 ns |      - |         - |
| WithoutTemporaryFill2 |   64 |    19.435 ns |  0.1014 ns |  0.1421 ns |    19.385 ns |    19.212 ns |    19.712 ns |    19.660 ns |      - |         - |
|    WithTemporaryFill3 |   64 |    24.728 ns |  0.1209 ns |  0.1695 ns |    24.733 ns |    24.368 ns |    25.097 ns |    24.967 ns |      - |         - |
| WithoutTemporaryFill3 |   64 |    19.493 ns |  0.0803 ns |  0.1178 ns |    19.488 ns |    19.306 ns |    19.726 ns |    19.644 ns |      - |         - |
|    **WithTemporaryFill1** |  **256** |    **78.240 ns** |  **0.2688 ns** |  **0.4023 ns** |    **78.273 ns** |    **77.406 ns** |    **78.878 ns** |    **78.704 ns** |      **-** |         **-** |
| WithoutTemporaryFill1 |  256 |    72.640 ns |  0.3235 ns |  0.4842 ns |    72.496 ns |    71.723 ns |    73.889 ns |    73.290 ns |      - |         - |
|    WithTemporaryFill2 |  256 |    78.756 ns |  0.3407 ns |  0.4994 ns |    78.881 ns |    78.030 ns |    79.831 ns |    79.297 ns |      - |         - |
| WithoutTemporaryFill2 |  256 |    72.641 ns |  0.2248 ns |  0.3296 ns |    72.659 ns |    71.708 ns |    73.276 ns |    73.028 ns |      - |         - |
|    WithTemporaryFill3 |  256 |    77.854 ns |  0.4247 ns |  0.6226 ns |    77.937 ns |    76.730 ns |    79.392 ns |    78.537 ns |      - |         - |
| WithoutTemporaryFill3 |  256 |    72.861 ns |  0.3875 ns |  0.5680 ns |    72.903 ns |    71.725 ns |    74.266 ns |    73.330 ns |      - |         - |
|    **WithTemporaryFill1** |  **512** |   **147.781 ns** |  **1.1931 ns** |  **1.7489 ns** |   **147.506 ns** |   **145.245 ns** |   **151.116 ns** |   **150.340 ns** |      **-** |         **-** |
| WithoutTemporaryFill1 |  512 |   153.076 ns |  1.2830 ns |  1.8400 ns |   152.454 ns |   150.436 ns |   157.752 ns |   155.870 ns | 0.0625 |   1,048 B |
|    WithTemporaryFill2 |  512 |   148.559 ns |  0.6938 ns |  1.0169 ns |   148.691 ns |   146.177 ns |   150.265 ns |   149.855 ns |      - |         - |
| WithoutTemporaryFill2 |  512 |   153.974 ns |  0.8784 ns |  1.3148 ns |   154.436 ns |   151.175 ns |   156.201 ns |   155.340 ns | 0.0625 |   1,048 B |
|    WithTemporaryFill3 |  512 |   148.494 ns |  0.4966 ns |  0.7279 ns |   148.425 ns |   147.324 ns |   150.375 ns |   149.545 ns |      - |         - |
| WithoutTemporaryFill3 |  512 |   151.071 ns |  0.7026 ns |  1.0077 ns |   150.984 ns |   148.566 ns |   152.944 ns |   152.330 ns | 0.0625 |   1,048 B |
|    **WithTemporaryFill1** | **1024** |   **258.043 ns** |  **0.7732 ns** |  **1.1089 ns** |   **257.769 ns** |   **256.510 ns** |   **261.118 ns** |   **259.385 ns** |      **-** |         **-** |
| WithoutTemporaryFill1 | 1024 |   292.687 ns |  1.9521 ns |  2.9219 ns |   291.617 ns |   287.979 ns |   298.393 ns |   296.571 ns | 0.1235 |   2,072 B |
|    WithTemporaryFill2 | 1024 |   260.375 ns |  0.7960 ns |  1.1667 ns |   260.043 ns |   258.820 ns |   263.378 ns |   261.949 ns |      - |         - |
| WithoutTemporaryFill2 | 1024 |   291.011 ns |  2.3366 ns |  3.3510 ns |   290.987 ns |   286.439 ns |   302.023 ns |   294.300 ns | 0.1235 |   2,072 B |
|    WithTemporaryFill3 | 1024 |   260.752 ns |  0.8720 ns |  1.2782 ns |   260.920 ns |   258.558 ns |   262.768 ns |   262.395 ns |      - |         - |
| WithoutTemporaryFill3 | 1024 |   293.239 ns |  2.4119 ns |  3.6100 ns |   293.448 ns |   285.867 ns |   300.588 ns |   297.880 ns | 0.1235 |   2,072 B |
|    **WithTemporaryFill1** | **4096** |   **932.163 ns** |  **1.7720 ns** |  **2.4255 ns** |   **932.392 ns** |   **926.036 ns** |   **935.571 ns** |   **934.937 ns** |      **-** |         **-** |
| WithoutTemporaryFill1 | 4096 | 1,106.349 ns |  6.1736 ns |  8.6545 ns | 1,106.077 ns | 1,091.791 ns | 1,128.959 ns | 1,117.844 ns | 0.4902 |   8,216 B |
|    WithTemporaryFill2 | 4096 |   933.419 ns |  1.3922 ns |  1.9967 ns |   933.467 ns |   929.114 ns |   937.353 ns |   935.625 ns |      - |         - |
| WithoutTemporaryFill2 | 4096 | 1,123.937 ns | 12.4481 ns | 18.6317 ns | 1,128.346 ns | 1,094.363 ns | 1,160.002 ns | 1,147.945 ns | 0.4902 |   8,216 B |
|    WithTemporaryFill3 | 4096 |   939.567 ns |  2.4785 ns |  3.4745 ns |   939.704 ns |   934.058 ns |   948.915 ns |   943.812 ns |      - |         - |
| WithoutTemporaryFill3 | 4096 | 1,111.028 ns |  8.8701 ns | 13.2764 ns | 1,109.025 ns | 1,091.277 ns | 1,148.722 ns | 1,130.649 ns | 0.4902 |   8,216 B |
