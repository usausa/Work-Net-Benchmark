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
