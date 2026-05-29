```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.6901)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method             | Job                 | Runtime   | Mean       | Error     | StdDev    | Min        | Max        | P90        | Code Size | Allocated |
|------------------- |-------------------- |---------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|----------:|----------:|
| CallInstance       | MediumRun-.NET 10.0 | .NET 10.0 |   195.0 μs |   0.26 μs |   0.37 μs |   194.8 μs |   196.1 μs |   195.6 μs |      16 B |         - |
| CallAction         | MediumRun-.NET 10.0 | .NET 10.0 |   195.1 μs |   0.14 μs |   0.21 μs |   194.8 μs |   195.5 μs |   195.3 μs |     105 B |         - |
| CallHandler        | MediumRun-.NET 10.0 | .NET 10.0 |   194.9 μs |   0.09 μs |   0.12 μs |   194.8 μs |   195.1 μs |   195.1 μs |     109 B |         - |
| CallHandler2       | MediumRun-.NET 10.0 | .NET 10.0 | 3,851.4 μs |  84.50 μs | 126.48 μs | 3,575.3 μs | 3,976.1 μs | 3,965.5 μs |      53 B |         - |
| CallHandler4       | MediumRun-.NET 10.0 | .NET 10.0 | 7,237.7 μs |  37.68 μs |  54.03 μs | 7,144.3 μs | 7,371.8 μs | 7,303.1 μs |      53 B |         - |
| CallDelegate       | MediumRun-.NET 10.0 | .NET 10.0 |   196.8 μs |   0.93 μs |   1.30 μs |   194.8 μs |   199.2 μs |   198.3 μs |     105 B |         - |
| CallDelegate2      | MediumRun-.NET 10.0 | .NET 10.0 | 3,830.9 μs | 102.14 μs | 149.72 μs | 3,369.5 μs | 4,064.3 μs | 3,961.1 μs |      51 B |         - |
| CallDelegate4      | MediumRun-.NET 10.0 | .NET 10.0 | 7,125.7 μs |  53.03 μs |  77.73 μs | 7,010.2 μs | 7,269.4 μs | 7,252.9 μs |      51 B |         - |
| CallCustomHandler  | MediumRun-.NET 10.0 | .NET 10.0 |   587.2 μs |   0.83 μs |   1.24 μs |   585.4 μs |   589.9 μs |   588.7 μs |     116 B |         - |
| CallCustomHandler2 | MediumRun-.NET 10.0 | .NET 10.0 |   657.1 μs |   7.59 μs |  11.37 μs |   620.8 μs |   674.8 μs |   670.3 μs |     116 B |         - |
| CallCustomHandler4 | MediumRun-.NET 10.0 | .NET 10.0 | 1,087.5 μs |   8.99 μs |  13.45 μs | 1,062.9 μs | 1,119.9 μs | 1,104.1 μs |     116 B |         - |
| LockObject         | MediumRun-.NET 10.0 | .NET 10.0 | 8,249.8 μs |   4.00 μs |   5.47 μs | 8,244.4 μs | 8,270.1 μs | 8,254.7 μs |     179 B |         - |
| LockLock           | MediumRun-.NET 10.0 | .NET 10.0 | 8,665.2 μs |   4.86 μs |   7.13 μs | 8,650.9 μs | 8,680.7 μs | 8,673.7 μs |   2,549 B |         - |
| LockVolatileRead   | MediumRun-.NET 10.0 | .NET 10.0 |   197.6 μs |   0.31 μs |   0.44 μs |   196.8 μs |   198.6 μs |   198.1 μs |      13 B |         - |
| CallInstance       | MediumRun-.NET 9.0  | .NET 9.0  |   197.7 μs |   0.32 μs |   0.47 μs |   196.8 μs |   198.7 μs |   198.1 μs |      16 B |         - |
| CallAction         | MediumRun-.NET 9.0  | .NET 9.0  |   197.4 μs |   0.34 μs |   0.50 μs |   196.7 μs |   198.4 μs |   198.0 μs |     105 B |         - |
| CallHandler        | MediumRun-.NET 9.0  | .NET 9.0  |   197.9 μs |   0.43 μs |   0.64 μs |   196.9 μs |   199.4 μs |   198.8 μs |     109 B |         - |
| CallHandler2       | MediumRun-.NET 9.0  | .NET 9.0  | 3,849.8 μs |   8.71 μs |  12.49 μs | 3,826.3 μs | 3,878.1 μs | 3,866.8 μs |      53 B |         - |
| CallHandler4       | MediumRun-.NET 9.0  | .NET 9.0  | 7,084.8 μs |  22.42 μs |  33.55 μs | 7,015.2 μs | 7,142.2 μs | 7,130.5 μs |      53 B |         - |
| CallDelegate       | MediumRun-.NET 9.0  | .NET 9.0  |   197.6 μs |   0.31 μs |   0.44 μs |   196.9 μs |   198.8 μs |   198.2 μs |     105 B |         - |
| CallDelegate2      | MediumRun-.NET 9.0  | .NET 9.0  | 3,783.5 μs |  86.52 μs | 124.08 μs | 3,368.6 μs | 3,867.9 μs | 3,862.8 μs |      51 B |         - |
| CallDelegate4      | MediumRun-.NET 9.0  | .NET 9.0  | 6,919.9 μs |  12.26 μs |  17.19 μs | 6,891.6 μs | 6,946.1 μs | 6,941.5 μs |      51 B |         - |
| CallCustomHandler  | MediumRun-.NET 9.0  | .NET 9.0  |   395.6 μs |   0.58 μs |   0.87 μs |   394.2 μs |   397.8 μs |   396.8 μs |     114 B |         - |
| CallCustomHandler2 | MediumRun-.NET 9.0  | .NET 9.0  |   593.1 μs |   0.77 μs |   1.12 μs |   591.0 μs |   594.8 μs |   594.6 μs |     112 B |         - |
| CallCustomHandler4 | MediumRun-.NET 9.0  | .NET 9.0  | 1,002.1 μs |   6.00 μs |   8.41 μs |   992.2 μs | 1,022.7 μs | 1,017.4 μs |     112 B |         - |
| LockObject         | MediumRun-.NET 9.0  | .NET 9.0  | 8,394.9 μs |   5.81 μs |   8.70 μs | 8,379.7 μs | 8,415.4 μs | 8,405.7 μs |     142 B |         - |
| LockLock           | MediumRun-.NET 9.0  | .NET 9.0  | 8,656.6 μs |   9.62 μs |  14.39 μs | 8,638.6 μs | 8,685.3 μs | 8,676.8 μs |   2,676 B |         - |
| LockVolatileRead   | MediumRun-.NET 9.0  | .NET 9.0  |   195.1 μs |   0.13 μs |   0.19 μs |   194.8 μs |   195.6 μs |   195.3 μs |      13 B |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3037)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.2 (9.0.225.6610), X64 RyuJIT AVX2

```
| Method             | Mean        | Error     | StdDev    | Min        | Max         | P90         | Code Size | Allocated |
|------------------- |------------:|----------:|----------:|-----------:|------------:|------------:|----------:|----------:|
| CallInstance       |    222.2 μs |   4.40 μs |   6.45 μs |   213.1 μs |    238.3 μs |    228.1 μs |      16 B |         - |
| CallAction         |    220.0 μs |   3.78 μs |   5.77 μs |   212.2 μs |    232.3 μs |    226.2 μs |     104 B |         - |
| CallHandler        |    220.0 μs |   4.32 μs |   6.06 μs |   211.9 μs |    231.4 μs |    228.1 μs |     108 B |         - |
| CallHandler2       |  5,688.7 μs | 111.73 μs | 149.15 μs | 5,427.0 μs |  5,963.8 μs |  5,851.5 μs |      53 B |       1 B |
| CallHandler4       | 10,343.5 μs | 204.55 μs | 318.46 μs | 9,841.2 μs | 11,039.5 μs | 10,777.1 μs |      53 B |       6 B |
| CallDelegate       |    221.3 μs |   4.40 μs |   7.36 μs |   209.9 μs |    237.1 μs |    231.0 μs |     104 B |         - |
| CallDelegate2      |  5,300.4 μs | 101.65 μs | 104.39 μs | 5,149.6 μs |  5,463.6 μs |  5,428.7 μs |      51 B |       3 B |
| CallDelegate4      |  9,515.0 μs | 188.47 μs | 293.43 μs | 8,989.9 μs | 10,172.2 μs |  9,857.1 μs |      51 B |       6 B |
| CallCustomHandler  |    885.2 μs |  17.69 μs |  23.62 μs |   855.4 μs |    940.2 μs |    914.0 μs |     113 B |         - |
| CallCustomHandler2 |    892.5 μs |  17.28 μs |  18.49 μs |   863.4 μs |    925.4 μs |    919.5 μs |     111 B |         - |
| CallCustomHandler4 |  1,773.4 μs |  35.24 μs |  40.58 μs | 1,717.0 μs |  1,845.0 μs |  1,831.3 μs |     111 B |       1 B |
| LockObject         |  5,630.1 μs | 107.11 μs | 110.00 μs | 5,432.3 μs |  5,816.4 μs |  5,756.8 μs |     142 B |       3 B |
| LockLock           |  4,062.4 μs |  77.91 μs |  69.06 μs | 3,939.4 μs |  4,204.4 μs |  4,116.4 μs |   2,588 B |       3 B |
| LockVolatileRead   |    219.6 μs |   4.31 μs |   7.08 μs |   210.6 μs |    237.4 μs |    228.7 μs |      13 B |       3 B |
