```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8328/25H2/2025Update/HudsonValley2)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.202
  [Host]     : .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4
```
| Method                    | Mean      | Error     | StdDev    | Min       | Max       | P90       | Ratio | RatioSD | Code Size | Allocated | Alloc Ratio |
|-------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|------:|--------:|----------:|----------:|------------:|
| HitFirstClassNode         | 0.8374 ns | 0.0150 ns | 0.0133 ns | 0.8212 ns | 0.8638 ns | 0.8564 ns |  1.00 |    0.02 |     505 B |         - |          NA |
| HitFirstStructSlot        | 0.8303 ns | 0.0057 ns | 0.0051 ns | 0.8219 ns | 0.8396 ns | 0.8361 ns |  0.99 |    0.02 |     659 B |         - |          NA |
| HitFirstStructSlotUnsafe  | 0.8328 ns | 0.0089 ns | 0.0084 ns | 0.8205 ns | 0.8491 ns | 0.8439 ns |  0.99 |    0.02 |     651 B |         - |          NA |
| HitSecondClassNode        | 1.0967 ns | 0.0139 ns | 0.0130 ns | 1.0773 ns | 1.1172 ns | 1.1147 ns |  1.31 |    0.02 |     412 B |         - |          NA |
| HitSecondStructSlot       | 1.0394 ns | 0.0066 ns | 0.0058 ns | 1.0293 ns | 1.0478 ns | 1.0451 ns |  1.24 |    0.02 |     517 B |         - |          NA |
| HitSecondStructSlotUnsafe | 1.0482 ns | 0.0116 ns | 0.0103 ns | 1.0335 ns | 1.0659 ns | 1.0632 ns |  1.25 |    0.02 |     509 B |         - |          NA |

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8328/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 5900X 3.70GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.203
  [Host]     : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
```
| Method                    | Mean     | Error     | StdDev    | Min      | Max      | P90      | Ratio | RatioSD | Code Size | Allocated | Alloc Ratio |
|-------------------------- |---------:|----------:|----------:|---------:|---------:|---------:|------:|--------:|----------:|----------:|------------:|
| HitFirstClassNode         | 1.425 ns | 0.0470 ns | 0.0689 ns | 1.316 ns | 1.573 ns | 1.513 ns |  1.00 |    0.07 |     505 B |         - |          NA |
| HitFirstStructSlot        | 1.452 ns | 0.0485 ns | 0.0664 ns | 1.362 ns | 1.620 ns | 1.539 ns |  1.02 |    0.07 |     659 B |         - |          NA |
| HitFirstStructSlotUnsafe  | 1.216 ns | 0.0323 ns | 0.0286 ns | 1.184 ns | 1.290 ns | 1.250 ns |  0.86 |    0.04 |     651 B |         - |          NA |
| HitSecondClassNode        | 2.228 ns | 0.0708 ns | 0.0921 ns | 2.104 ns | 2.414 ns | 2.344 ns |  1.57 |    0.10 |     412 B |         - |          NA |
| HitSecondStructSlot       | 1.970 ns | 0.0654 ns | 0.0978 ns | 1.839 ns | 2.126 ns | 2.094 ns |  1.39 |    0.09 |     517 B |         - |          NA |
| HitSecondStructSlotUnsafe | 1.955 ns | 0.0641 ns | 0.0855 ns | 1.842 ns | 2.099 ns | 2.078 ns |  1.37 |    0.09 |     509 B |         - |          NA |

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8328/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 5900X 3.70GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.203
  [Host]     : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.7 (10.0.7, 10.0.726.21808), X64 RyuJIT x86-64-v3
```
| Method                    | Mean     | Error     | StdDev    | Min      | Max      | P90      | Ratio | RatioSD | Code Size | Allocated | Alloc Ratio |
|-------------------------- |---------:|----------:|----------:|---------:|---------:|---------:|------:|--------:|----------:|----------:|------------:|
| HitFirstClassNode         | 1.372 ns | 0.0535 ns | 0.0695 ns | 1.266 ns | 1.534 ns | 1.461 ns |  1.00 |    0.07 |     505 B |         - |          NA |
| HitFirstStructSlot        | 1.421 ns | 0.0524 ns | 0.0663 ns | 1.338 ns | 1.527 ns | 1.518 ns |  1.04 |    0.07 |     659 B |         - |          NA |
| HitFirstStructSlotUnsafe  | 1.286 ns | 0.0505 ns | 0.0757 ns | 1.179 ns | 1.481 ns | 1.381 ns |  0.94 |    0.07 |     651 B |         - |          NA |
| HitSecondClassNode        | 2.049 ns | 0.0655 ns | 0.0897 ns | 1.955 ns | 2.238 ns | 2.184 ns |  1.50 |    0.10 |     412 B |         - |          NA |
| HitSecondStructSlot       | 1.875 ns | 0.0629 ns | 0.0618 ns | 1.794 ns | 1.985 ns | 1.966 ns |  1.37 |    0.08 |     517 B |         - |          NA |
| HitSecondStructSlotUnsafe | 1.948 ns | 0.0575 ns | 0.0538 ns | 1.890 ns | 2.083 ns | 2.002 ns |  1.42 |    0.08 |     509 B |         - |          NA |
