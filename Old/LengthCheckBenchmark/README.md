``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.963)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=7.0.101
  [Host]    : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  MediumRun : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2

Job=MediumRun  Jit=RyuJit  Platform=X64  
IterationCount=15  LaunchCount=2  WarmupCount=10  

```
|                    Method |  Runtime |   Categories |     Mean |     Error |    StdDev |   Median |      Min |      Max |      P90 | Code Size | Allocated |
|-------------------------- |--------- |------------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|----------:|----------:|
| GraterThanZeroWithoutCast | .NET 6.0 |   GraterThan | 1.401 μs | 0.0775 μs | 0.1161 μs | 1.397 μs | 1.278 μs | 1.559 μs | 1.546 μs |      72 B |         - |
|    GraterThanZeroWithCast | .NET 6.0 |   GraterThan | 1.285 μs | 0.0022 μs | 0.0030 μs | 1.285 μs | 1.279 μs | 1.291 μs | 1.289 μs |      72 B |         - |
| GraterThanZeroWithoutCast | .NET 7.0 |   GraterThan | 1.287 μs | 0.0056 μs | 0.0082 μs | 1.285 μs | 1.277 μs | 1.310 μs | 1.299 μs |      57 B |         - |
|    GraterThanZeroWithCast | .NET 7.0 |   GraterThan | 1.284 μs | 0.0038 μs | 0.0053 μs | 1.283 μs | 1.277 μs | 1.300 μs | 1.291 μs |      57 B |         - |
|                           |          |              |          |           |           |          |          |          |          |           |           |
|       LessThanWithoutCast | .NET 6.0 |     LessThan | 1.396 μs | 0.0763 μs | 0.1094 μs | 1.394 μs | 1.281 μs | 1.522 μs | 1.508 μs |      75 B |         - |
|          LessThanWithCast | .NET 6.0 |     LessThan | 1.288 μs | 0.0041 μs | 0.0059 μs | 1.286 μs | 1.280 μs | 1.304 μs | 1.296 μs |      75 B |         - |
|       LessThanWithoutCast | .NET 7.0 |     LessThan | 1.283 μs | 0.0040 μs | 0.0057 μs | 1.282 μs | 1.275 μs | 1.302 μs | 1.289 μs |      60 B |         - |
|          LessThanWithCast | .NET 7.0 |     LessThan | 1.284 μs | 0.0048 μs | 0.0067 μs | 1.282 μs | 1.276 μs | 1.308 μs | 1.292 μs |      60 B |         - |
|                           |          |              |          |           |           |          |          |          |          |           |           |
|          MinusWithoutCast | .NET 6.0 |        Minus | 1.288 μs | 0.0060 μs | 0.0086 μs | 1.285 μs | 1.277 μs | 1.310 μs | 1.300 μs |      75 B |         - |
|             MinusWithCast | .NET 6.0 |        Minus | 1.397 μs | 0.0808 μs | 0.1133 μs | 1.488 μs | 1.278 μs | 1.538 μs | 1.511 μs |      75 B |         - |
|          MinusWithoutCast | .NET 7.0 |        Minus | 1.073 μs | 0.0057 μs | 0.0080 μs | 1.071 μs | 1.066 μs | 1.104 μs | 1.079 μs |      60 B |         - |
|             MinusWithCast | .NET 7.0 |        Minus | 1.071 μs | 0.0021 μs | 0.0028 μs | 1.070 μs | 1.066 μs | 1.076 μs | 1.074 μs |      60 B |         - |
|                           |          |              |          |           |           |          |          |          |          |           |           |
|   NotEqualZeroWithoutCast | .NET 6.0 | NotEqualZero | 1.387 μs | 0.0750 μs | 0.1075 μs | 1.388 μs | 1.277 μs | 1.500 μs | 1.495 μs |      72 B |         - |
|      NotEqualZeroWithCast | .NET 6.0 | NotEqualZero | 1.393 μs | 0.0749 μs | 0.1075 μs | 1.394 μs | 1.280 μs | 1.510 μs | 1.507 μs |      72 B |         - |
|   NotEqualZeroWithoutCast | .NET 7.0 | NotEqualZero | 1.286 μs | 0.0045 μs | 0.0065 μs | 1.284 μs | 1.278 μs | 1.309 μs | 1.293 μs |      57 B |         - |
|      NotEqualZeroWithCast | .NET 7.0 | NotEqualZero | 1.283 μs | 0.0026 μs | 0.0037 μs | 1.283 μs | 1.277 μs | 1.293 μs | 1.286 μs |      57 B |         - |
|                           |          |              |          |           |           |          |          |          |          |           |           |
|          ArrayWithoutCast | .NET 6.0 |       Simple | 1.392 μs | 0.0825 μs | 0.1073 μs | 1.395 μs | 1.282 μs | 1.502 μs | 1.500 μs |      73 B |         - |
|             ArrayWithCast | .NET 6.0 |       Simple | 1.393 μs | 0.0740 μs | 0.1037 μs | 1.483 μs | 1.279 μs | 1.499 μs | 1.495 μs |      73 B |         - |
|      ArraySpanWithoutCast | .NET 6.0 |       Simple | 1.720 μs | 0.0049 μs | 0.0071 μs | 1.719 μs | 1.711 μs | 1.736 μs | 1.730 μs |     117 B |         - |
|         ArraySpanWithCast | .NET 6.0 |       Simple | 1.721 μs | 0.0066 μs | 0.0094 μs | 1.719 μs | 1.709 μs | 1.750 μs | 1.731 μs |     117 B |         - |
|           SpanWithoutCast | .NET 6.0 |       Simple | 1.397 μs | 0.0730 μs | 0.1070 μs | 1.488 μs | 1.278 μs | 1.511 μs | 1.504 μs |     121 B |         - |
|          ArrayWithoutCast | .NET 7.0 |       Simple | 1.071 μs | 0.0027 μs | 0.0039 μs | 1.070 μs | 1.066 μs | 1.083 μs | 1.077 μs |      58 B |         - |
|             ArrayWithCast | .NET 7.0 |       Simple | 1.070 μs | 0.0022 μs | 0.0030 μs | 1.070 μs | 1.064 μs | 1.074 μs | 1.073 μs |      58 B |         - |
|      ArraySpanWithoutCast | .NET 7.0 |       Simple | 1.290 μs | 0.0020 μs | 0.0027 μs | 1.290 μs | 1.285 μs | 1.295 μs | 1.294 μs |      91 B |         - |
|         ArraySpanWithCast | .NET 7.0 |       Simple | 1.294 μs | 0.0058 μs | 0.0085 μs | 1.291 μs | 1.285 μs | 1.317 μs | 1.306 μs |      91 B |         - |
|           SpanWithoutCast | .NET 7.0 |       Simple | 1.287 μs | 0.0035 μs | 0.0052 μs | 1.285 μs | 1.281 μs | 1.301 μs | 1.294 μs |      90 B |         - |
