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
