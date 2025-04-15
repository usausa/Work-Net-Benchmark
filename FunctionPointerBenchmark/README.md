READ```

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
