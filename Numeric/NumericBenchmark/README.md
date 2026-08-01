## Benchmark

```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8894/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 5900X 3.70GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.302
  [Host]              : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 8.0  : .NET 8.0.29 (8.0.29, 8.0.2926.32403), X64 RyuJIT x86-64-v3
  MediumRun-.NET 9.0  : .NET 9.0.18 (9.0.18, 9.0.1826.31522), X64 RyuJIT x86-64-v3

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method          | Job                 | Runtime   | Mean       | Error     | StdDev    | Min        | Max        | P90        | Code Size | Gen0   | Allocated |
|---------------- |-------------------- |---------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|----------:|-------:|----------:|
| IntMul9         | MediumRun-.NET 10.0 | .NET 10.0 |   1.836 ns | 0.0545 ns | 0.0764 ns |   1.758 ns |   2.062 ns |   1.942 ns |      20 B |      - |         - |
| LongMul9        | MediumRun-.NET 10.0 | .NET 10.0 |   1.995 ns | 0.0223 ns | 0.0333 ns |   1.947 ns |   2.068 ns |   2.034 ns |      22 B |      - |         - |
| BigIntegerMul9  | MediumRun-.NET 10.0 | .NET 10.0 |  14.835 ns | 0.1833 ns | 0.2743 ns |  14.491 ns |  15.483 ns |  15.160 ns |     420 B |      - |         - |
| IntDiv9         | MediumRun-.NET 10.0 | .NET 10.0 |   3.055 ns | 0.0359 ns | 0.0537 ns |   2.978 ns |   3.193 ns |   3.110 ns |      30 B |      - |         - |
| LongDiv9        | MediumRun-.NET 10.0 | .NET 10.0 |   3.925 ns | 0.0384 ns | 0.0575 ns |   3.845 ns |   4.078 ns |   3.987 ns |      40 B |      - |         - |
| BigIntegerDiv9  | MediumRun-.NET 10.0 | .NET 10.0 |  89.512 ns | 5.0662 ns | 7.5829 ns |  80.987 ns |  98.560 ns |  97.703 ns |   1,247 B |      - |         - |
| LongMul19       | MediumRun-.NET 10.0 | .NET 10.0 |   4.265 ns | 0.0581 ns | 0.0852 ns |   4.140 ns |   4.486 ns |   4.386 ns |      22 B |      - |         - |
| BigIntegerMul19 | MediumRun-.NET 10.0 | .NET 10.0 | 145.927 ns | 2.2663 ns | 3.3922 ns | 139.612 ns | 152.259 ns | 150.950 ns |   3,397 B | 0.0191 |     320 B |
| LongDiv19       | MediumRun-.NET 10.0 | .NET 10.0 |   9.377 ns | 0.0733 ns | 0.1074 ns |   9.199 ns |   9.599 ns |   9.518 ns |      40 B |      - |         - |
| BigIntegerDiv19 | MediumRun-.NET 10.0 | .NET 10.0 | 291.993 ns | 2.0764 ns | 3.1079 ns | 288.653 ns | 298.676 ns | 296.304 ns |   2,220 B | 0.0172 |     288 B |
| IntMul9         | MediumRun-.NET 8.0  | .NET 8.0  |   1.794 ns | 0.0235 ns | 0.0344 ns |   1.750 ns |   1.892 ns |   1.842 ns |      20 B |      - |         - |
| LongMul9        | MediumRun-.NET 8.0  | .NET 8.0  |   1.808 ns | 0.0320 ns | 0.0470 ns |   1.760 ns |   1.905 ns |   1.884 ns |      22 B |      - |         - |
| BigIntegerMul9  | MediumRun-.NET 8.0  | .NET 8.0  |  76.826 ns | 4.7509 ns | 7.1109 ns |  69.191 ns |  85.834 ns |  84.646 ns |     593 B |      - |         - |
| IntDiv9         | MediumRun-.NET 8.0  | .NET 8.0  |   2.401 ns | 0.0359 ns | 0.0537 ns |   2.335 ns |   2.550 ns |   2.467 ns |      30 B |      - |         - |
| LongDiv9        | MediumRun-.NET 8.0  | .NET 8.0  |   3.752 ns | 0.0277 ns | 0.0415 ns |   3.694 ns |   3.870 ns |   3.790 ns |      44 B |      - |         - |
| BigIntegerDiv9  | MediumRun-.NET 8.0  | .NET 8.0  |  97.244 ns | 0.9504 ns | 1.3930 ns |  95.175 ns | 100.399 ns |  98.774 ns |   1,311 B |      - |         - |
| LongMul19       | MediumRun-.NET 8.0  | .NET 8.0  |   4.339 ns | 0.0888 ns | 0.1274 ns |   4.161 ns |   4.634 ns |   4.499 ns |      22 B |      - |         - |
| BigIntegerMul19 | MediumRun-.NET 8.0  | .NET 8.0  | 226.891 ns | 5.0029 ns | 7.3332 ns | 215.760 ns | 236.951 ns | 236.076 ns |   2,919 B | 0.0191 |     320 B |
| LongDiv19       | MediumRun-.NET 8.0  | .NET 8.0  |   9.484 ns | 0.1214 ns | 0.1780 ns |   9.264 ns |   9.918 ns |   9.737 ns |      44 B |      - |         - |
| BigIntegerDiv19 | MediumRun-.NET 8.0  | .NET 8.0  | 321.076 ns | 4.8586 ns | 7.2721 ns | 310.559 ns | 344.347 ns | 329.632 ns |   1,962 B | 0.0172 |     288 B |
| IntMul9         | MediumRun-.NET 9.0  | .NET 9.0  |   1.792 ns | 0.0246 ns | 0.0361 ns |   1.729 ns |   1.879 ns |   1.827 ns |      20 B |      - |         - |
| LongMul9        | MediumRun-.NET 9.0  | .NET 9.0  |   1.784 ns | 0.0139 ns | 0.0203 ns |   1.753 ns |   1.821 ns |   1.814 ns |      22 B |      - |         - |
| BigIntegerMul9  | MediumRun-.NET 9.0  | .NET 9.0  |  26.540 ns | 0.9025 ns | 1.3508 ns |  25.069 ns |  28.519 ns |  28.231 ns |     572 B |      - |         - |
| IntDiv9         | MediumRun-.NET 9.0  | .NET 9.0  |   3.014 ns | 0.0178 ns | 0.0261 ns |   2.975 ns |   3.073 ns |   3.050 ns |      30 B |      - |         - |
| LongDiv9        | MediumRun-.NET 9.0  | .NET 9.0  |   3.761 ns | 0.0277 ns | 0.0370 ns |   3.697 ns |   3.856 ns |   3.801 ns |      41 B |      - |         - |
| BigIntegerDiv9  | MediumRun-.NET 9.0  | .NET 9.0  | 102.853 ns | 0.6165 ns | 0.9037 ns | 101.820 ns | 105.015 ns | 104.270 ns |   1,261 B |      - |         - |
| LongMul19       | MediumRun-.NET 9.0  | .NET 9.0  |   4.245 ns | 0.0622 ns | 0.0930 ns |   4.088 ns |   4.516 ns |   4.353 ns |      22 B |      - |         - |
| BigIntegerMul19 | MediumRun-.NET 9.0  | .NET 9.0  | 174.358 ns | 3.4041 ns | 4.9897 ns | 168.144 ns | 189.202 ns | 183.487 ns |   3,187 B | 0.0191 |     320 B |
| LongDiv19       | MediumRun-.NET 9.0  | .NET 9.0  |   9.460 ns | 0.0953 ns | 0.1367 ns |   9.223 ns |   9.697 ns |   9.627 ns |      41 B |      - |         - |
| BigIntegerDiv19 | MediumRun-.NET 9.0  | .NET 9.0  | 318.103 ns | 4.0052 ns | 5.9948 ns | 312.253 ns | 334.590 ns | 326.711 ns |   1,991 B | 0.0172 |     288 B |

## DecimalBitsBenchmark

```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8894/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 5900X 3.70GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.302
  [Host]              : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 8.0  : .NET 8.0.29 (8.0.29, 8.0.2926.32403), X64 RyuJIT x86-64-v3
  MediumRun-.NET 9.0  : .NET 9.0.18 (9.0.18, 9.0.1826.31522), X64 RyuJIT x86-64-v3

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method                   | Job                 | Runtime   | Mean      | Error     | StdDev    | Min       | Max       | P90       | Ratio | RatioSD | Code Size | Gen0   | Allocated | Alloc Ratio |
|------------------------- |-------------------- |---------- |----------:|----------:|----------:|----------:|----------:|----------:|------:|--------:|----------:|-------:|----------:|------------:|
| GetBitsDefault           | MediumRun-.NET 10.0 | .NET 10.0 | 7.2619 ns | 0.1553 ns | 0.2228 ns | 6.9852 ns | 7.8956 ns | 7.5254 ns |  1.00 |    0.04 |     481 B | 0.0024 |      40 B |        1.00 |
| GetBitsUnsafe            | MediumRun-.NET 10.0 | .NET 10.0 | 3.1901 ns | 0.0498 ns | 0.0746 ns | 3.0647 ns | 3.3494 ns | 3.2945 ns |  0.44 |    0.02 |     199 B | 0.0019 |      32 B |        0.80 |
| GetBitsUnsafeWithoutCopy | MediumRun-.NET 10.0 | .NET 10.0 | 0.2285 ns | 0.0034 ns | 0.0049 ns | 0.2205 ns | 0.2412 ns | 0.2351 ns |  0.03 |    0.00 |      19 B |      - |         - |        0.00 |
| GetBitsUnsafeCopy        | MediumRun-.NET 10.0 | .NET 10.0 | 0.7593 ns | 0.0103 ns | 0.0144 ns | 0.7372 ns | 0.7965 ns | 0.7780 ns |  0.10 |    0.00 |      65 B |      - |         - |        0.00 |
|                          |                     |           |           |           |           |           |           |           |       |         |           |        |           |             |
| GetBitsDefault           | MediumRun-.NET 8.0  | .NET 8.0  | 7.9330 ns | 0.1636 ns | 0.2347 ns | 7.5781 ns | 8.4448 ns | 8.2969 ns |  1.00 |    0.04 |     479 B | 0.0024 |      40 B |        1.00 |
| GetBitsUnsafe            | MediumRun-.NET 8.0  | .NET 8.0  | 3.4322 ns | 0.0484 ns | 0.0694 ns | 3.2759 ns | 3.5922 ns | 3.5192 ns |  0.43 |    0.02 |     147 B | 0.0019 |      32 B |        0.80 |
| GetBitsUnsafeWithoutCopy | MediumRun-.NET 8.0  | .NET 8.0  | 3.6957 ns | 0.0539 ns | 0.0755 ns | 3.5922 ns | 3.8805 ns | 3.8068 ns |  0.47 |    0.02 |      71 B | 0.0019 |      32 B |        0.80 |
| GetBitsUnsafeCopy        | MediumRun-.NET 8.0  | .NET 8.0  | 0.5669 ns | 0.0038 ns | 0.0056 ns | 0.5589 ns | 0.5817 ns | 0.5738 ns |  0.07 |    0.00 |      73 B |      - |         - |        0.00 |
|                          |                     |           |           |           |           |           |           |           |       |         |           |        |           |             |
| GetBitsDefault           | MediumRun-.NET 9.0  | .NET 9.0  | 7.6281 ns | 0.0903 ns | 0.1352 ns | 7.4367 ns | 7.9950 ns | 7.7627 ns |  1.00 |    0.02 |     484 B | 0.0024 |      40 B |        1.00 |
| GetBitsUnsafe            | MediumRun-.NET 9.0  | .NET 9.0  | 3.2156 ns | 0.1391 ns | 0.1995 ns | 2.9679 ns | 3.7860 ns | 3.4440 ns |  0.42 |    0.03 |     140 B | 0.0019 |      32 B |        0.80 |
| GetBitsUnsafeWithoutCopy | MediumRun-.NET 9.0  | .NET 9.0  | 0.2221 ns | 0.0044 ns | 0.0067 ns | 0.2144 ns | 0.2345 ns | 0.2310 ns |  0.03 |    0.00 |      19 B |      - |         - |        0.00 |
| GetBitsUnsafeCopy        | MediumRun-.NET 9.0  | .NET 9.0  | 0.6602 ns | 0.0039 ns | 0.0058 ns | 0.6513 ns | 0.6701 ns | 0.6679 ns |  0.09 |    0.00 |      68 B |      - |         - |        0.00 |
