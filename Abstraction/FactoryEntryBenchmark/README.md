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
| Method      | Job                 | Runtime   | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       | Code Size | Allocated |
|------------ |-------------------- |---------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| Type1Object | MediumRun-.NET 10.0 | .NET 10.0 | 0.3313 ns | 0.0026 ns | 0.0039 ns | 0.3294 ns | 0.3269 ns | 0.3400 ns | 0.3377 ns |      84 B |         - |
| Type2Object | MediumRun-.NET 10.0 | .NET 10.0 | 0.3294 ns | 0.0027 ns | 0.0040 ns | 0.3281 ns | 0.3251 ns | 0.3417 ns | 0.3340 ns |      84 B |         - |
| Type1Object | MediumRun-.NET 8.0  | .NET 8.0  | 0.3489 ns | 0.0366 ns | 0.0537 ns | 0.3055 ns | 0.2894 ns | 0.4087 ns | 0.4058 ns |      88 B |         - |
| Type2Object | MediumRun-.NET 8.0  | .NET 8.0  | 0.4040 ns | 0.0024 ns | 0.0036 ns | 0.4026 ns | 0.3993 ns | 0.4124 ns | 0.4082 ns |      88 B |         - |
| Type1Object | MediumRun-.NET 9.0  | .NET 9.0  | 0.3307 ns | 0.0025 ns | 0.0036 ns | 0.3296 ns | 0.3251 ns | 0.3393 ns | 0.3351 ns |      85 B |         - |
| Type2Object | MediumRun-.NET 9.0  | .NET 9.0  | 0.3326 ns | 0.0026 ns | 0.0037 ns | 0.3322 ns | 0.3280 ns | 0.3437 ns | 0.3369 ns |      85 B |         - |
| Type1Typed  | MediumRun-.NET 10.0 | .NET 10.0 | 0.5410 ns | 0.0039 ns | 0.0058 ns | 0.5397 ns | 0.5305 ns | 0.5560 ns | 0.5488 ns |     320 B |         - |
| Type2Typed  | MediumRun-.NET 10.0 | .NET 10.0 | 0.3218 ns | 0.0016 ns | 0.0023 ns | 0.3210 ns | 0.3190 ns | 0.3283 ns | 0.3247 ns |      84 B |         - |
| Type1Typed  | MediumRun-.NET 8.0  | .NET 8.0  | 0.5247 ns | 0.0032 ns | 0.0047 ns | 0.5240 ns | 0.5154 ns | 0.5330 ns | 0.5312 ns |     283 B |         - |
| Type2Typed  | MediumRun-.NET 8.0  | .NET 8.0  | 0.3533 ns | 0.0364 ns | 0.0534 ns | 0.3999 ns | 0.2944 ns | 0.4132 ns | 0.4077 ns |      88 B |         - |
| Type1Typed  | MediumRun-.NET 9.0  | .NET 9.0  | 0.5487 ns | 0.0025 ns | 0.0038 ns | 0.5472 ns | 0.5438 ns | 0.5560 ns | 0.5543 ns |     303 B |         - |
| Type2Typed  | MediumRun-.NET 9.0  | .NET 9.0  | 0.3386 ns | 0.0030 ns | 0.0046 ns | 0.3368 ns | 0.3336 ns | 0.3479 ns | 0.3440 ns |      85 B |         - |
