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
| Method   | Job                 | Runtime   | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Allocated |
|--------- |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|----------:|
| Func     | MediumRun-.NET 10.0 | .NET 10.0 | 1.386 ms | 0.0024 ms | 0.0033 ms | 1.379 ms | 1.391 ms | 1.389 ms |      36 B |         - |
| Pointer  | MediumRun-.NET 10.0 | .NET 10.0 | 1.359 ms | 0.0167 ms | 0.0249 ms | 1.293 ms | 1.382 ms | 1.378 ms |      28 B |         - |
| Pointer2 | MediumRun-.NET 10.0 | .NET 10.0 | 1.349 ms | 0.0292 ms | 0.0438 ms | 1.197 ms | 1.379 ms | 1.375 ms |      28 B |         - |
| Pointer3 | MediumRun-.NET 10.0 | .NET 10.0 | 1.359 ms | 0.0133 ms | 0.0199 ms | 1.309 ms | 1.381 ms | 1.378 ms |      28 B |         - |
| Pointer4 | MediumRun-.NET 10.0 | .NET 10.0 | 1.365 ms | 0.0138 ms | 0.0207 ms | 1.281 ms | 1.384 ms | 1.377 ms |      28 B |         - |
| Pointer5 | MediumRun-.NET 10.0 | .NET 10.0 | 1.362 ms | 0.0135 ms | 0.0203 ms | 1.306 ms | 1.382 ms | 1.378 ms |      28 B |         - |
| Func     | MediumRun-.NET 8.0  | .NET 8.0  | 1.595 ms | 0.0156 ms | 0.0234 ms | 1.550 ms | 1.631 ms | 1.622 ms |      39 B |         - |
| Pointer  | MediumRun-.NET 8.0  | .NET 8.0  | 1.227 ms | 0.0077 ms | 0.0113 ms | 1.211 ms | 1.248 ms | 1.244 ms |      31 B |         - |
| Pointer2 | MediumRun-.NET 8.0  | .NET 8.0  | 1.370 ms | 0.0130 ms | 0.0190 ms | 1.317 ms | 1.407 ms | 1.391 ms |      31 B |         - |
| Pointer3 | MediumRun-.NET 8.0  | .NET 8.0  | 1.378 ms | 0.0096 ms | 0.0141 ms | 1.349 ms | 1.401 ms | 1.394 ms |      31 B |         - |
| Pointer4 | MediumRun-.NET 8.0  | .NET 8.0  | 1.399 ms | 0.0059 ms | 0.0087 ms | 1.378 ms | 1.417 ms | 1.409 ms |      31 B |         - |
| Pointer5 | MediumRun-.NET 8.0  | .NET 8.0  | 1.402 ms | 0.0084 ms | 0.0125 ms | 1.377 ms | 1.425 ms | 1.419 ms |      31 B |         - |
| Func     | MediumRun-.NET 9.0  | .NET 9.0  | 1.618 ms | 0.0083 ms | 0.0122 ms | 1.601 ms | 1.645 ms | 1.633 ms |      36 B |         - |
| Pointer  | MediumRun-.NET 9.0  | .NET 9.0  | 1.391 ms | 0.0098 ms | 0.0144 ms | 1.351 ms | 1.418 ms | 1.410 ms |      28 B |         - |
| Pointer2 | MediumRun-.NET 9.0  | .NET 9.0  | 1.394 ms | 0.0127 ms | 0.0183 ms | 1.364 ms | 1.439 ms | 1.418 ms |      28 B |         - |
| Pointer3 | MediumRun-.NET 9.0  | .NET 9.0  | 1.352 ms | 0.0190 ms | 0.0285 ms | 1.287 ms | 1.377 ms | 1.375 ms |      28 B |         - |
| Pointer4 | MediumRun-.NET 9.0  | .NET 9.0  | 1.358 ms | 0.0173 ms | 0.0260 ms | 1.302 ms | 1.382 ms | 1.381 ms |      28 B |         - |
| Pointer5 | MediumRun-.NET 9.0  | .NET 9.0  | 1.359 ms | 0.0130 ms | 0.0194 ms | 1.302 ms | 1.379 ms | 1.378 ms |      28 B |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3775)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.201
  [Host]    : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  
```
| Method   | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Allocated |
|--------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|----------:|
| Func     | 1.529 ms | 0.0058 ms | 0.0077 ms | 1.517 ms | 1.545 ms | 1.540 ms |      36 B |         - |
| Pointer  | 1.301 ms | 0.0129 ms | 0.0188 ms | 1.286 ms | 1.346 ms | 1.334 ms |      28 B |         - |
| Pointer2 | 1.296 ms | 0.0060 ms | 0.0087 ms | 1.285 ms | 1.328 ms | 1.302 ms |      28 B |         - |
| Pointer3 | 1.303 ms | 0.0153 ms | 0.0220 ms | 1.284 ms | 1.360 ms | 1.348 ms |      28 B |         - |
| Pointer4 | 1.295 ms | 0.0045 ms | 0.0060 ms | 1.283 ms | 1.314 ms | 1.300 ms |      28 B |       1 B |
| Pointer5 | 1.296 ms | 0.0045 ms | 0.0063 ms | 1.287 ms | 1.308 ms | 1.304 ms |      28 B |       1 B |
