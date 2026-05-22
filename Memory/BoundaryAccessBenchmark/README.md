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
| Method                  | Job                 | Runtime   | Size | Mean        | Error     | StdDev    | Median      | Min         | Max         | P90         | Code Size | Allocated |
|------------------------ |-------------------- |---------- |----- |------------:|----------:|----------:|------------:|------------:|------------:|------------:|----------:|----------:|
| **Calc**                    | **MediumRun-.NET 10.0** | **.NET 10.0** | **1**    |   **0.8022 ns** | **0.0083 ns** | **0.0122 ns** |   **0.8022 ns** |   **0.7850 ns** |   **0.8361 ns** |   **0.8170 ns** |      **44 B** |         **-** |
| CalcByLength            | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.8015 ns | 0.0085 ns | 0.0127 ns |   0.7994 ns |   0.7863 ns |   0.8396 ns |   0.8166 ns |      95 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.7998 ns | 0.0053 ns | 0.0079 ns |   0.7980 ns |   0.7870 ns |   0.8230 ns |   0.8111 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.8033 ns | 0.0073 ns | 0.0109 ns |   0.8027 ns |   0.7880 ns |   0.8267 ns |   0.8213 ns |     138 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.7991 ns | 0.0055 ns | 0.0081 ns |   0.7993 ns |   0.7865 ns |   0.8196 ns |   0.8083 ns |     101 B |         - |
| Calc                    | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.7977 ns | 0.0058 ns | 0.0087 ns |   0.7961 ns |   0.7816 ns |   0.8180 ns |   0.8086 ns |      49 B |         - |
| CalcByLength            | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.9937 ns | 0.0066 ns | 0.0099 ns |   0.9961 ns |   0.9757 ns |   1.0128 ns |   1.0049 ns |      97 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.8005 ns | 0.0042 ns | 0.0057 ns |   0.7993 ns |   0.7919 ns |   0.8138 ns |   0.8084 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.8075 ns | 0.0042 ns | 0.0063 ns |   0.8063 ns |   0.7941 ns |   0.8222 ns |   0.8167 ns |     139 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.8121 ns | 0.0085 ns | 0.0120 ns |   0.8068 ns |   0.7957 ns |   0.8417 ns |   0.8310 ns |     103 B |         - |
| Calc                    | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.8955 ns | 0.0725 ns | 0.1017 ns |   0.9696 ns |   0.7845 ns |   1.0190 ns |   0.9976 ns |      44 B |         - |
| CalcByLength            | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   1.0048 ns | 0.0117 ns | 0.0171 ns |   1.0031 ns |   0.9800 ns |   1.0434 ns |   1.0288 ns |      97 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.8014 ns | 0.0038 ns | 0.0054 ns |   0.8001 ns |   0.7878 ns |   0.8149 ns |   0.8080 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   1.0107 ns | 0.0124 ns | 0.0185 ns |   1.0073 ns |   0.9824 ns |   1.0438 ns |   1.0425 ns |     138 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.8938 ns | 0.0685 ns | 0.0982 ns |   0.8881 ns |   0.7860 ns |   1.0319 ns |   1.0041 ns |     103 B |         - |
| **Calc**                    | **MediumRun-.NET 10.0** | **.NET 10.0** | **4**    |   **1.3244 ns** | **0.0234 ns** | **0.0350 ns** |   **1.3292 ns** |   **1.2226 ns** |   **1.3645 ns** |   **1.3590 ns** |      **44 B** |         **-** |
| CalcByLength            | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   1.1681 ns | 0.0263 ns | 0.0393 ns |   1.1749 ns |   1.0069 ns |   1.2215 ns |   1.1978 ns |     100 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   1.2890 ns | 0.0300 ns | 0.0449 ns |   1.2941 ns |   1.1701 ns |   1.3616 ns |   1.3416 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   1.1823 ns | 0.0284 ns | 0.0425 ns |   1.1911 ns |   1.0778 ns |   1.2525 ns |   1.2240 ns |     140 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   1.1833 ns | 0.0259 ns | 0.0388 ns |   1.1947 ns |   1.0953 ns |   1.2409 ns |   1.2242 ns |     101 B |         - |
| Calc                    | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   1.2815 ns | 0.0260 ns | 0.0388 ns |   1.2817 ns |   1.1568 ns |   1.3402 ns |   1.3192 ns |      49 B |         - |
| CalcByLength            | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   1.5411 ns | 0.0461 ns | 0.0690 ns |   1.5644 ns |   1.3921 ns |   1.6319 ns |   1.6100 ns |      97 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   1.3511 ns | 0.0217 ns | 0.0319 ns |   1.3548 ns |   1.2793 ns |   1.4006 ns |   1.3926 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   1.5045 ns | 0.0815 ns | 0.1142 ns |   1.5883 ns |   1.2862 ns |   1.6357 ns |   1.6178 ns |     139 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   1.6094 ns | 0.0108 ns | 0.0148 ns |   1.6119 ns |   1.5806 ns |   1.6363 ns |   1.6285 ns |     103 B |         - |
| Calc                    | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.3105 ns | 0.0361 ns | 0.0541 ns |   1.3215 ns |   1.1657 ns |   1.4061 ns |   1.3634 ns |      44 B |         - |
| CalcByLength            | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.1943 ns | 0.0211 ns | 0.0316 ns |   1.1989 ns |   1.1315 ns |   1.2654 ns |   1.2243 ns |     100 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.3111 ns | 0.0259 ns | 0.0387 ns |   1.3118 ns |   1.2278 ns |   1.3811 ns |   1.3597 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.1719 ns | 0.0251 ns | 0.0360 ns |   1.1635 ns |   1.1134 ns |   1.2511 ns |   1.2157 ns |     136 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.1813 ns | 0.0221 ns | 0.0317 ns |   1.1917 ns |   1.0874 ns |   1.2196 ns |   1.2067 ns |     101 B |         - |
| **Calc**                    | **MediumRun-.NET 10.0** | **.NET 10.0** | **8**    |   **1.8038 ns** | **0.0256 ns** | **0.0376 ns** |   **1.8109 ns** |   **1.7118 ns** |   **1.8555 ns** |   **1.8456 ns** |      **44 B** |         **-** |
| CalcByLength            | MediumRun-.NET 10.0 | .NET 10.0 | 8    |   1.7677 ns | 0.0258 ns | 0.0370 ns |   1.7723 ns |   1.6535 ns |   1.8409 ns |   1.8030 ns |     100 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 10.0 | .NET 10.0 | 8    |   1.7864 ns | 0.0251 ns | 0.0375 ns |   1.7849 ns |   1.6854 ns |   1.8638 ns |   1.8293 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 10.0 | .NET 10.0 | 8    |   1.7901 ns | 0.0360 ns | 0.0527 ns |   1.8030 ns |   1.6706 ns |   1.8706 ns |   1.8484 ns |     140 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 10.0 | .NET 10.0 | 8    |   1.7617 ns | 0.0297 ns | 0.0436 ns |   1.7657 ns |   1.6759 ns |   1.8303 ns |   1.8203 ns |     101 B |         - |
| Calc                    | MediumRun-.NET 8.0  | .NET 8.0  | 8    |   1.7970 ns | 0.0326 ns | 0.0488 ns |   1.8042 ns |   1.6841 ns |   1.8836 ns |   1.8583 ns |      49 B |         - |
| CalcByLength            | MediumRun-.NET 8.0  | .NET 8.0  | 8    |   1.7841 ns | 0.0293 ns | 0.0439 ns |   1.7909 ns |   1.7191 ns |   1.8996 ns |   1.8284 ns |     106 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 8.0  | .NET 8.0  | 8    |   1.8736 ns | 0.0291 ns | 0.0436 ns |   1.8783 ns |   1.7747 ns |   1.9535 ns |   1.9277 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 8.0  | .NET 8.0  | 8    |   1.8978 ns | 0.0427 ns | 0.0640 ns |   1.9030 ns |   1.7562 ns |   2.0197 ns |   1.9604 ns |     145 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 8.0  | .NET 8.0  | 8    |   1.8392 ns | 0.0377 ns | 0.0553 ns |   1.8493 ns |   1.7338 ns |   1.9498 ns |   1.9070 ns |     105 B |         - |
| Calc                    | MediumRun-.NET 9.0  | .NET 9.0  | 8    |   1.7884 ns | 0.0319 ns | 0.0478 ns |   1.8031 ns |   1.6719 ns |   1.8598 ns |   1.8329 ns |      44 B |         - |
| CalcByLength            | MediumRun-.NET 9.0  | .NET 9.0  | 8    |   1.7881 ns | 0.0242 ns | 0.0355 ns |   1.7949 ns |   1.7083 ns |   1.8397 ns |   1.8266 ns |     100 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 9.0  | .NET 9.0  | 8    |   1.8301 ns | 0.0269 ns | 0.0394 ns |   1.8381 ns |   1.7171 ns |   1.9046 ns |   1.8658 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 9.0  | .NET 9.0  | 8    |   1.7938 ns | 0.0252 ns | 0.0377 ns |   1.7904 ns |   1.7306 ns |   1.8558 ns |   1.8464 ns |     136 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 9.0  | .NET 9.0  | 8    |   1.7645 ns | 0.0333 ns | 0.0499 ns |   1.7629 ns |   1.6264 ns |   1.8652 ns |   1.8238 ns |     101 B |         - |
| **Calc**                    | **MediumRun-.NET 10.0** | **.NET 10.0** | **64**   |  **11.3496 ns** | **0.0510 ns** | **0.0763 ns** |  **11.3479 ns** |  **11.1745 ns** |  **11.4872 ns** |  **11.4458 ns** |      **44 B** |         **-** |
| CalcByLength            | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  11.5806 ns | 0.0550 ns | 0.0807 ns |  11.5812 ns |  11.4655 ns |  11.7742 ns |  11.6981 ns |     103 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  10.4081 ns | 0.0597 ns | 0.0894 ns |  10.4210 ns |  10.2709 ns |  10.5767 ns |  10.5169 ns |     101 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  11.9108 ns | 0.0628 ns | 0.0920 ns |  11.9161 ns |  11.7422 ns |  12.1099 ns |  12.0121 ns |     140 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  11.5371 ns | 0.0449 ns | 0.0672 ns |  11.5230 ns |  11.4440 ns |  11.6876 ns |  11.6317 ns |     101 B |         - |
| Calc                    | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  10.7778 ns | 0.0518 ns | 0.0743 ns |  10.8011 ns |  10.6511 ns |  10.9449 ns |  10.8453 ns |      49 B |         - |
| CalcByLength            | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  11.4993 ns | 0.1211 ns | 0.1737 ns |  11.5555 ns |  11.1886 ns |  11.7740 ns |  11.6770 ns |     106 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  10.4800 ns | 0.0424 ns | 0.0622 ns |  10.4904 ns |  10.3500 ns |  10.5941 ns |  10.5619 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  11.4308 ns | 0.0398 ns | 0.0558 ns |  11.4449 ns |  11.3297 ns |  11.5507 ns |  11.4873 ns |     145 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  11.1601 ns | 0.0623 ns | 0.0913 ns |  11.1423 ns |  10.9635 ns |  11.3378 ns |  11.2638 ns |     105 B |         - |
| Calc                    | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  11.3478 ns | 0.0514 ns | 0.0754 ns |  11.3504 ns |  11.1735 ns |  11.5040 ns |  11.4376 ns |      44 B |         - |
| CalcByLength            | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  11.5693 ns | 0.0452 ns | 0.0663 ns |  11.5848 ns |  11.4332 ns |  11.7227 ns |  11.6378 ns |     103 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  10.4083 ns | 0.0734 ns | 0.1099 ns |  10.4166 ns |  10.2217 ns |  10.6849 ns |  10.5188 ns |     101 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  11.8326 ns | 0.0547 ns | 0.0802 ns |  11.8044 ns |  11.7153 ns |  12.0584 ns |  11.9361 ns |     136 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  11.5784 ns | 0.0445 ns | 0.0666 ns |  11.5778 ns |  11.4466 ns |  11.7016 ns |  11.6710 ns |     101 B |         - |
| **Calc**                    | **MediumRun-.NET 10.0** | **.NET 10.0** | **1024** | **209.9698 ns** | **0.6071 ns** | **0.8898 ns** | **209.7207 ns** | **208.6999 ns** | **212.8328 ns** | **210.9405 ns** |      **44 B** |         **-** |
| CalcByLength            | MediumRun-.NET 10.0 | .NET 10.0 | 1024 | 209.8134 ns | 0.6226 ns | 0.9127 ns | 209.7100 ns | 208.5227 ns | 212.2227 ns | 210.9462 ns |     103 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 10.0 | .NET 10.0 | 1024 | 209.9344 ns | 0.3443 ns | 0.4826 ns | 209.8474 ns | 209.0603 ns | 210.9306 ns | 210.4943 ns |     101 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 10.0 | .NET 10.0 | 1024 | 210.6340 ns | 0.5498 ns | 0.8059 ns | 210.6251 ns | 209.4280 ns | 212.0218 ns | 211.5397 ns |     140 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 10.0 | .NET 10.0 | 1024 | 209.6141 ns | 0.5500 ns | 0.7529 ns | 209.5463 ns | 208.0698 ns | 210.9939 ns | 210.6655 ns |     101 B |         - |
| Calc                    | MediumRun-.NET 8.0  | .NET 8.0  | 1024 | 210.7190 ns | 1.2206 ns | 1.7892 ns | 210.7246 ns | 207.7114 ns | 214.6818 ns | 212.7707 ns |      49 B |         - |
| CalcByLength            | MediumRun-.NET 8.0  | .NET 8.0  | 1024 | 209.6827 ns | 0.9419 ns | 1.4098 ns | 209.5329 ns | 207.5838 ns | 213.0388 ns | 211.8298 ns |     106 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 8.0  | .NET 8.0  | 1024 | 210.0716 ns | 0.6068 ns | 0.8703 ns | 209.9864 ns | 208.7204 ns | 212.2134 ns | 211.2401 ns |      85 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 8.0  | .NET 8.0  | 1024 | 208.9272 ns | 0.5526 ns | 0.7925 ns | 208.8028 ns | 207.1290 ns | 210.5129 ns | 209.9930 ns |     145 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 8.0  | .NET 8.0  | 1024 | 209.0387 ns | 0.5739 ns | 0.8412 ns | 208.9528 ns | 207.7219 ns | 210.9128 ns | 210.3012 ns |     105 B |         - |
| Calc                    | MediumRun-.NET 9.0  | .NET 9.0  | 1024 | 210.2996 ns | 0.7061 ns | 1.0568 ns | 209.8175 ns | 208.6246 ns | 212.7195 ns | 211.6818 ns |      44 B |         - |
| CalcByLength            | MediumRun-.NET 9.0  | .NET 9.0  | 1024 | 210.1998 ns | 0.5986 ns | 0.8960 ns | 209.9942 ns | 208.7590 ns | 212.1723 ns | 211.3402 ns |     103 B |         - |
| CalcByLengthReverse     | MediumRun-.NET 9.0  | .NET 9.0  | 1024 | 210.1523 ns | 0.4705 ns | 0.6748 ns | 209.9907 ns | 209.2246 ns | 211.6740 ns | 211.0394 ns |     101 B |         - |
| CalcByLengthWithAccess  | MediumRun-.NET 9.0  | .NET 9.0  | 1024 | 210.1202 ns | 0.5904 ns | 0.8653 ns | 209.8855 ns | 208.9944 ns | 212.3311 ns | 211.6057 ns |     136 B |         - |
| CalcByLengthWithAccess2 | MediumRun-.NET 9.0  | .NET 9.0  | 1024 | 210.4362 ns | 0.7450 ns | 1.0684 ns | 210.3640 ns | 208.7772 ns | 212.4446 ns | 212.1903 ns |     101 B |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]    : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  
```
| Method                  | Size | Mean       | Error     | StdDev     | Min        | Max        | P90        | Code Size | Allocated |
|------------------------ |----- |-----------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
| **Calc**                    | **1**    |   **1.336 ns** | **0.0511 ns** |  **0.0732 ns** |   **1.251 ns** |   **1.524 ns** |   **1.452 ns** |      **46 B** |         **-** |
| CalcByLength            | 1    |   1.375 ns | 0.0448 ns |  0.0642 ns |   1.302 ns |   1.507 ns |   1.484 ns |      97 B |         - |
| CalcByLengthReverse     | 1    |   1.314 ns | 0.0219 ns |  0.0315 ns |   1.278 ns |   1.381 ns |   1.356 ns |      87 B |         - |
| CalcByLengthWithAccess  | 1    |   1.448 ns | 0.1083 ns |  0.1518 ns |   1.265 ns |   1.713 ns |   1.631 ns |     138 B |         - |
| CalcByLengthWithAccess2 | 1    |   1.595 ns | 0.0558 ns |  0.0836 ns |   1.512 ns |   1.801 ns |   1.723 ns |     103 B |         - |
| **Calc**                    | **4**    |   **1.597 ns** | **0.0557 ns** |  **0.0781 ns** |   **1.517 ns** |   **1.832 ns** |   **1.697 ns** |      **44 B** |         **-** |
| CalcByLength            | 4    |   1.650 ns | 0.0535 ns |  0.0801 ns |   1.576 ns |   1.825 ns |   1.780 ns |     100 B |         - |
| CalcByLengthReverse     | 4    |   1.600 ns | 0.0168 ns |  0.0231 ns |   1.579 ns |   1.662 ns |   1.630 ns |      85 B |         - |
| CalcByLengthWithAccess  | 4    |   1.929 ns | 0.0666 ns |  0.0976 ns |   1.793 ns |   2.171 ns |   2.035 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 4    |   1.818 ns | 0.0620 ns |  0.0889 ns |   1.747 ns |   2.070 ns |   1.975 ns |     101 B |         - |
| **Calc**                    | **8**    |   **2.539 ns** | **0.0799 ns** |  **0.1197 ns** |   **2.419 ns** |   **2.820 ns** |   **2.693 ns** |      **44 B** |         **-** |
| CalcByLength            | 8    |   2.568 ns | 0.0829 ns |  0.1240 ns |   2.418 ns |   2.829 ns |   2.705 ns |     100 B |         - |
| CalcByLengthReverse     | 8    |   2.556 ns | 0.0852 ns |  0.1275 ns |   2.419 ns |   2.880 ns |   2.723 ns |      85 B |         - |
| CalcByLengthWithAccess  | 8    |   2.820 ns | 0.0778 ns |  0.1165 ns |   2.631 ns |   2.992 ns |   2.952 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 8    |   2.804 ns | 0.0839 ns |  0.1256 ns |   2.645 ns |   3.192 ns |   2.932 ns |     101 B |         - |
| **Calc**                    | **64**   |  **16.664 ns** | **0.4345 ns** |  **0.6504 ns** |  **15.887 ns** |  **18.459 ns** |  **17.287 ns** |      **44 B** |         **-** |
| CalcByLength            | 64   |  16.874 ns | 0.3825 ns |  0.5725 ns |  16.172 ns |  17.919 ns |  17.519 ns |     103 B |         - |
| CalcByLengthReverse     | 64   |  16.894 ns | 0.3897 ns |  0.5833 ns |  16.061 ns |  17.948 ns |  17.565 ns |     101 B |         - |
| CalcByLengthWithAccess  | 64   |  17.146 ns | 0.4246 ns |  0.6355 ns |  16.369 ns |  18.598 ns |  17.883 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 64   |  16.914 ns | 0.2987 ns |  0.4378 ns |  16.385 ns |  17.646 ns |  17.536 ns |     101 B |         - |
| **Calc**                    | **1024** | **267.107 ns** | **8.9328 ns** | **13.3701 ns** | **251.265 ns** | **291.690 ns** | **290.225 ns** |      **44 B** |         **-** |
| CalcByLength            | 1024 | 260.457 ns | 5.4836 ns |  8.2075 ns | 250.994 ns | 271.626 ns | 271.015 ns |     103 B |         - |
| CalcByLengthReverse     | 1024 | 258.798 ns | 8.1868 ns | 11.7412 ns | 247.485 ns | 285.390 ns | 275.594 ns |     101 B |         - |
| CalcByLengthWithAccess  | 1024 | 269.434 ns | 9.4628 ns | 14.1634 ns | 251.615 ns | 300.726 ns | 291.291 ns |     136 B |         - |
| CalcByLengthWithAccess2 | 1024 | 261.378 ns | 6.3897 ns |  9.5638 ns | 251.524 ns | 281.695 ns | 273.777 ns |     101 B |         - |
