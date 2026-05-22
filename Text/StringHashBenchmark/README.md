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
| Method   | Job                 | Runtime   | Value            | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       | Code Size | Allocated |
|--------- |-------------------- |---------- |----------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| **XxHash3**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **12345678**         | **0.7760 ns** | **0.0040 ns** | **0.0055 ns** | **0.7771 ns** | **0.7654 ns** | **0.7881 ns** | **0.7812 ns** |     **244 B** |         **-** |
| XxHash3b | MediumRun-.NET 10.0 | .NET 10.0 | 12345678         | 0.7768 ns | 0.0064 ns | 0.0094 ns | 0.7740 ns | 0.7644 ns | 0.7970 ns | 0.7879 ns |     252 B |         - |
| XxHash3  | MediumRun-.NET 8.0  | .NET 8.0  | 12345678         | 0.7569 ns | 0.0045 ns | 0.0067 ns | 0.7558 ns | 0.7475 ns | 0.7733 ns | 0.7640 ns |     236 B |         - |
| XxHash3b | MediumRun-.NET 8.0  | .NET 8.0  | 12345678         | 0.8472 ns | 0.0034 ns | 0.0051 ns | 0.8471 ns | 0.8371 ns | 0.8569 ns | 0.8537 ns |     255 B |         - |
| XxHash3  | MediumRun-.NET 9.0  | .NET 9.0  | 12345678         | 0.8264 ns | 0.0096 ns | 0.0137 ns | 0.8231 ns | 0.8109 ns | 0.8581 ns | 0.8495 ns |     238 B |         - |
| XxHash3b | MediumRun-.NET 9.0  | .NET 9.0  | 12345678         | 0.7771 ns | 0.0048 ns | 0.0071 ns | 0.7758 ns | 0.7659 ns | 0.7914 ns | 0.7846 ns |     252 B |         - |
| **XxHash3**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **Hello world!**     | **2.5623 ns** | **0.0133 ns** | **0.0186 ns** | **2.5570 ns** | **2.5274 ns** | **2.6083 ns** | **2.5866 ns** |     **809 B** |         **-** |
| XxHash3b | MediumRun-.NET 10.0 | .NET 10.0 | Hello world!     | 2.5742 ns | 0.0154 ns | 0.0231 ns | 2.5761 ns | 2.5405 ns | 2.6236 ns | 2.5986 ns |     823 B |         - |
| XxHash3  | MediumRun-.NET 8.0  | .NET 8.0  | Hello world!     | 2.5843 ns | 0.0159 ns | 0.0238 ns | 2.5826 ns | 2.5525 ns | 2.6423 ns | 2.6132 ns |     810 B |         - |
| XxHash3b | MediumRun-.NET 8.0  | .NET 8.0  | Hello world!     | 2.6710 ns | 0.0128 ns | 0.0191 ns | 2.6645 ns | 2.6443 ns | 2.7151 ns | 2.7004 ns |     827 B |         - |
| XxHash3  | MediumRun-.NET 9.0  | .NET 9.0  | Hello world!     | 2.6762 ns | 0.0183 ns | 0.0274 ns | 2.6672 ns | 2.6404 ns | 2.7374 ns | 2.7111 ns |     808 B |         - |
| XxHash3b | MediumRun-.NET 9.0  | .NET 9.0  | Hello world!     | 2.6585 ns | 0.0128 ns | 0.0187 ns | 2.6536 ns | 2.6325 ns | 2.7028 ns | 2.6811 ns |     824 B |         - |
| **XxHash3**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **Id**               | **0.7961 ns** | **0.0021 ns** | **0.0031 ns** | **0.7964 ns** | **0.7910 ns** | **0.8012 ns** | **0.7998 ns** |     **250 B** |         **-** |
| XxHash3b | MediumRun-.NET 10.0 | .NET 10.0 | Id               | 0.7128 ns | 0.0640 ns | 0.0938 ns | 0.7958 ns | 0.6093 ns | 0.8080 ns | 0.8050 ns |     258 B |         - |
| XxHash3  | MediumRun-.NET 8.0  | .NET 8.0  | Id               | 0.4872 ns | 0.0049 ns | 0.0068 ns | 0.4854 ns | 0.4804 ns | 0.5036 ns | 0.4996 ns |     242 B |         - |
| XxHash3b | MediumRun-.NET 8.0  | .NET 8.0  | Id               | 0.6058 ns | 0.0103 ns | 0.0154 ns | 0.6063 ns | 0.5833 ns | 0.6328 ns | 0.6267 ns |     262 B |         - |
| XxHash3  | MediumRun-.NET 9.0  | .NET 9.0  | Id               | 0.8035 ns | 0.0039 ns | 0.0057 ns | 0.8024 ns | 0.7961 ns | 0.8195 ns | 0.8108 ns |     244 B |         - |
| XxHash3b | MediumRun-.NET 9.0  | .NET 9.0  | Id               | 0.8017 ns | 0.0023 ns | 0.0032 ns | 0.8013 ns | 0.7965 ns | 0.8088 ns | 0.8073 ns |     258 B |         - |
| **XxHash3**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **Name**             | **0.7959 ns** | **0.0017 ns** | **0.0024 ns** | **0.7962 ns** | **0.7910 ns** | **0.8017 ns** | **0.7988 ns** |     **250 B** |         **-** |
| XxHash3b | MediumRun-.NET 10.0 | .NET 10.0 | Name             | 0.6877 ns | 0.0864 ns | 0.1239 ns | 0.7963 ns | 0.5502 ns | 0.8117 ns | 0.8039 ns |     258 B |         - |
| XxHash3  | MediumRun-.NET 8.0  | .NET 8.0  | Name             | 0.4889 ns | 0.0046 ns | 0.0066 ns | 0.4866 ns | 0.4803 ns | 0.5047 ns | 0.4988 ns |     242 B |         - |
| XxHash3b | MediumRun-.NET 8.0  | .NET 8.0  | Name             | 0.5932 ns | 0.0062 ns | 0.0091 ns | 0.5891 ns | 0.5829 ns | 0.6198 ns | 0.6032 ns |     262 B |         - |
| XxHash3  | MediumRun-.NET 9.0  | .NET 9.0  | Name             | 0.8036 ns | 0.0033 ns | 0.0049 ns | 0.8037 ns | 0.7970 ns | 0.8132 ns | 0.8109 ns |     244 B |         - |
| XxHash3b | MediumRun-.NET 9.0  | .NET 9.0  | Name             | 0.8026 ns | 0.0025 ns | 0.0037 ns | 0.8022 ns | 0.7968 ns | 0.8113 ns | 0.8071 ns |     258 B |         - |
| **XxHash3**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **XxxxXxxxXxxxXxxx** | **2.5647 ns** | **0.0145 ns** | **0.0212 ns** | **2.5691 ns** | **2.5354 ns** | **2.6025 ns** | **2.5905 ns** |     **809 B** |         **-** |
| XxHash3b | MediumRun-.NET 10.0 | .NET 10.0 | XxxxXxxxXxxxXxxx | 2.5726 ns | 0.0160 ns | 0.0240 ns | 2.5644 ns | 2.5400 ns | 2.6241 ns | 2.6080 ns |     823 B |         - |
| XxHash3  | MediumRun-.NET 8.0  | .NET 8.0  | XxxxXxxxXxxxXxxx | 2.5805 ns | 0.0143 ns | 0.0209 ns | 2.5740 ns | 2.5509 ns | 2.6309 ns | 2.6113 ns |     810 B |         - |
| XxHash3b | MediumRun-.NET 8.0  | .NET 8.0  | XxxxXxxxXxxxXxxx | 2.6732 ns | 0.0169 ns | 0.0252 ns | 2.6786 ns | 2.6367 ns | 2.7396 ns | 2.7062 ns |     827 B |         - |
| XxHash3  | MediumRun-.NET 9.0  | .NET 9.0  | XxxxXxxxXxxxXxxx | 2.6719 ns | 0.0200 ns | 0.0299 ns | 2.6677 ns | 2.6341 ns | 2.7439 ns | 2.7076 ns |     808 B |         - |
| XxHash3b | MediumRun-.NET 9.0  | .NET 9.0  | XxxxXxxxXxxxXxxx | 2.6834 ns | 0.0195 ns | 0.0292 ns | 2.6785 ns | 2.6363 ns | 2.7398 ns | 2.7289 ns |     824 B |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
```
| Method                   | Value            | Mean       | Error     | StdDev    | Median     | Min        | Max        | P90        | Code Size | Allocated |
|------------------------- |----------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
| **XxHash3**                  | **12345678**         |  **1.1910 ns** | **0.0237 ns** | **0.0567 ns** |  **1.1784 ns** |  **1.1093 ns** |  **1.3173 ns** |  **1.2706 ns** |     **238 B** |         **-** |
| DefaultOrdinal           | 12345678         |  5.1780 ns | 0.1030 ns | 0.2527 ns |  5.1360 ns |  4.7985 ns |  5.8264 ns |  5.5148 ns |     369 B |         - |
| DefaultOrdinalIgnoreCase | 12345678         |  6.8484 ns | 0.1328 ns | 0.3052 ns |  6.7929 ns |  6.3960 ns |  7.5870 ns |  7.2796 ns |     347 B |         - |
| CustomOrdinal            | 12345678         |  2.0876 ns | 0.0416 ns | 0.1044 ns |  2.0602 ns |  1.9399 ns |  2.3499 ns |  2.2305 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | 12345678         |  2.3335 ns | 0.0460 ns | 0.1038 ns |  2.3199 ns |  2.1460 ns |  2.6051 ns |  2.4742 ns |     131 B |         - |
| **XxHash3**                  | **Hello world!**     |  **4.2969 ns** | **0.0855 ns** | **0.2192 ns** |  **4.2272 ns** |  **3.9491 ns** |  **4.7820 ns** |  **4.6233 ns** |     **808 B** |         **-** |
| DefaultOrdinal           | Hello world!     |  6.8464 ns | 0.1363 ns | 0.2754 ns |  6.8085 ns |  6.4339 ns |  7.4057 ns |  7.2605 ns |     369 B |         - |
| DefaultOrdinalIgnoreCase | Hello world!     |  9.0526 ns | 0.1782 ns | 0.2499 ns |  9.0880 ns |  8.5743 ns |  9.6161 ns |  9.2855 ns |     347 B |         - |
| CustomOrdinal            | Hello world!     |  3.0704 ns | 0.0614 ns | 0.1241 ns |  3.0526 ns |  2.8682 ns |  3.3024 ns |  3.2499 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | Hello world!     |  3.2437 ns | 0.0627 ns | 0.1030 ns |  3.2501 ns |  3.0543 ns |  3.4195 ns |  3.3880 ns |     131 B |         - |
| **XxHash3**                  | **Id**               |  **0.9511 ns** | **0.0190 ns** | **0.0516 ns** |  **0.9421 ns** |  **0.8796 ns** |  **1.1018 ns** |  **1.0191 ns** |     **244 B** |         **-** |
| DefaultOrdinal           | Id               |  2.8454 ns | 0.0569 ns | 0.1188 ns |  2.8189 ns |  2.6496 ns |  3.1321 ns |  3.0064 ns |     373 B |         - |
| DefaultOrdinalIgnoreCase | Id               |  3.3121 ns | 0.0653 ns | 0.1460 ns |  3.2971 ns |  3.0928 ns |  3.6953 ns |  3.4797 ns |     344 B |         - |
| CustomOrdinal            | Id               |  0.4749 ns | 0.0081 ns | 0.0116 ns |  0.4742 ns |  0.4530 ns |  0.4984 ns |  0.4862 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | Id               |  0.7041 ns | 0.0138 ns | 0.0289 ns |  0.6986 ns |  0.6651 ns |  0.7933 ns |  0.7422 ns |     131 B |         - |
| **XxHash3**                  | **Name**             |  **0.9506 ns** | **0.0189 ns** | **0.0496 ns** |  **0.9387 ns** |  **0.8832 ns** |  **1.0828 ns** |  **1.0258 ns** |     **244 B** |         **-** |
| DefaultOrdinal           | Name             |  3.5617 ns | 0.0691 ns | 0.1643 ns |  3.5188 ns |  3.3297 ns |  3.9222 ns |  3.8451 ns |     369 B |         - |
| DefaultOrdinalIgnoreCase | Name             |  4.4661 ns | 0.0884 ns | 0.1845 ns |  4.4411 ns |  4.2073 ns |  4.9391 ns |  4.7991 ns |     344 B |         - |
| CustomOrdinal            | Name             |  1.1175 ns | 0.0177 ns | 0.0248 ns |  1.1176 ns |  1.0720 ns |  1.1779 ns |  1.1374 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | Name             |  1.2569 ns | 0.0247 ns | 0.0330 ns |  1.2642 ns |  1.1926 ns |  1.3171 ns |  1.2961 ns |     131 B |         - |
| **XxHash3**                  | **XxxxXxxxXxxxXxxx** |  **4.1512 ns** | **0.0724 ns** | **0.0889 ns** |  **4.1418 ns** |  **4.0122 ns** |  **4.3332 ns** |  **4.2595 ns** |     **808 B** |         **-** |
| DefaultOrdinal           | XxxxXxxxXxxxXxxx |  8.7289 ns | 0.1746 ns | 0.3012 ns |  8.6584 ns |  8.2492 ns |  9.4077 ns |  9.2486 ns |     371 B |         - |
| DefaultOrdinalIgnoreCase | XxxxXxxxXxxxXxxx | 11.3418 ns | 0.2194 ns | 0.2052 ns | 11.3884 ns | 10.9919 ns | 11.6822 ns | 11.5393 ns |     347 B |         - |
| CustomOrdinal            | XxxxXxxxXxxxXxxx |  3.9793 ns | 0.0773 ns | 0.1313 ns |  3.9892 ns |  3.7239 ns |  4.2411 ns |  4.1335 ns |      33 B |         - |
| CustomOrdinalIgnoreCase  | XxxxXxxxXxxxXxxx |  4.2359 ns | 0.0845 ns | 0.2198 ns |  4.2096 ns |  3.9070 ns |  4.7198 ns |  4.5717 ns |     131 B |         - |

| Method        | Value            | Mean      | Error     | StdDev    | Min       | Max       | P90       | Code Size | Allocated |
|-------------- |----------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| **XxHash3**       | **A**                | **1.1894 ns** | **0.0238 ns** | **0.0517 ns** | **1.1059 ns** | **1.3154 ns** | **1.2730 ns** |     **241 B** |         **-** |
| CustomOrdinal | A                | 0.3492 ns | 0.0067 ns | 0.0091 ns | 0.3359 ns | 0.3697 ns | 0.3617 ns |      33 B |         - |
| **XxHash3**       | **AB**               | **0.9375 ns** | **0.0186 ns** | **0.0362 ns** | **0.8915 ns** | **1.0204 ns** | **0.9929 ns** |     **244 B** |         **-** |
| CustomOrdinal | AB               | 0.4664 ns | 0.0091 ns | 0.0157 ns | 0.4435 ns | 0.5027 ns | 0.4882 ns |      33 B |         - |
| **XxHash3**       | **ABC**              | **0.9303 ns** | **0.0177 ns** | **0.0174 ns** | **0.8886 ns** | **0.9526 ns** | **0.9469 ns** |     **244 B** |         **-** |
| CustomOrdinal | ABC              | 0.7548 ns | 0.0150 ns | 0.0389 ns | 0.6815 ns | 0.8505 ns | 0.8172 ns |      33 B |         - |
| **XxHash3**       | **ABCD**             | **0.9463 ns** | **0.0186 ns** | **0.0316 ns** | **0.8899 ns** | **1.0225 ns** | **0.9939 ns** |     **244 B** |         **-** |
| CustomOrdinal | ABCD             | 1.1055 ns | 0.0219 ns | 0.0490 ns | 1.0187 ns | 1.2385 ns | 1.1786 ns |      33 B |         - |
| **XxHash3**       | **ABCDE**            | **1.1632 ns** | **0.0226 ns** | **0.0429 ns** | **1.1065 ns** | **1.2604 ns** | **1.2324 ns** |     **238 B** |         **-** |
| CustomOrdinal | ABCDE            | 1.3556 ns | 0.0259 ns | 0.0541 ns | 1.2784 ns | 1.4867 ns | 1.4269 ns |      33 B |         - |
| **XxHash3**       | **ABCDEF**           | **1.1472 ns** | **0.0224 ns** | **0.0230 ns** | **1.1110 ns** | **1.2012 ns** | **1.1686 ns** |     **238 B** |         **-** |
| CustomOrdinal | ABCDEF           | 1.5951 ns | 0.0312 ns | 0.0513 ns | 1.5043 ns | 1.6808 ns | 1.6654 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFG**          | **1.1845 ns** | **0.0236 ns** | **0.0461 ns** | **1.1111 ns** | **1.2812 ns** | **1.2480 ns** |     **238 B** |         **-** |
| CustomOrdinal | ABCDEFG          | 1.7662 ns | 0.0352 ns | 0.0678 ns | 1.6773 ns | 1.9432 ns | 1.8643 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGH**         | **1.1801 ns** | **0.0232 ns** | **0.0361 ns** | **1.1112 ns** | **1.2734 ns** | **1.2251 ns** |     **238 B** |         **-** |
| CustomOrdinal | ABCDEFGH         | 2.0341 ns | 0.0388 ns | 0.0648 ns | 1.9048 ns | 2.2047 ns | 2.0981 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHI**        | **4.0862 ns** | **0.0607 ns** | **0.0538 ns** | **3.9816 ns** | **4.1570 ns** | **4.1458 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHI        | 2.3052 ns | 0.0452 ns | 0.0974 ns | 2.1695 ns | 2.5653 ns | 2.4187 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHIJ**       | **4.1291 ns** | **0.0807 ns** | **0.0674 ns** | **4.0336 ns** | **4.2310 ns** | **4.2186 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHIJ       | 2.5711 ns | 0.0512 ns | 0.1330 ns | 2.3396 ns | 2.9222 ns | 2.7496 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHIJK**      | **4.2035 ns** | **0.0818 ns** | **0.1147 ns** | **3.9869 ns** | **4.4667 ns** | **4.3216 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHIJK      | 2.7908 ns | 0.0558 ns | 0.1140 ns | 2.6222 ns | 3.0876 ns | 2.9486 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHIJKL**     | **4.3287 ns** | **0.0841 ns** | **0.1845 ns** | **4.0396 ns** | **4.8182 ns** | **4.5677 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHIJKL     | 3.0282 ns | 0.0605 ns | 0.1354 ns | 2.8681 ns | 3.3520 ns | 3.2496 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHIJKLM**    | **4.2010 ns** | **0.0833 ns** | **0.1438 ns** | **3.9862 ns** | **4.5352 ns** | **4.3990 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHIJKLM    | 3.2070 ns | 0.0641 ns | 0.1071 ns | 3.0472 ns | 3.4711 ns | 3.3579 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHIJKLMN**   | **4.2275 ns** | **0.0842 ns** | **0.1740 ns** | **3.9645 ns** | **4.6660 ns** | **4.4537 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHIJKLMN   | 3.4561 ns | 0.0688 ns | 0.1051 ns | 3.3214 ns | 3.6810 ns | 3.6236 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHIJKLMNO**  | **4.3039 ns** | **0.0858 ns** | **0.2261 ns** | **3.9629 ns** | **4.8316 ns** | **4.5810 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHIJKLMNO  | 3.7165 ns | 0.0735 ns | 0.1326 ns | 3.4788 ns | 3.9844 ns | 3.8986 ns |      33 B |         - |
| **XxHash3**       | **ABCDEFGHIJKLMNOP** | **4.1655 ns** | **0.0821 ns** | **0.0977 ns** | **3.9908 ns** | **4.3241 ns** | **4.3090 ns** |     **808 B** |         **-** |
| CustomOrdinal | ABCDEFGHIJKLMNOP | 3.9737 ns | 0.0793 ns | 0.1280 ns | 3.7688 ns | 4.2720 ns | 4.1275 ns |      33 B |         - |
