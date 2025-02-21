
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
