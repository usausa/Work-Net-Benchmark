```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3775)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
```
| Method                         | Mean       | Error   | StdDev  | Min        | Max        | P90        | Code Size | Allocated |
|------------------------------- |-----------:|--------:|--------:|-----------:|-----------:|-----------:|----------:|----------:|
| Func                           |   439.1 μs | 3.10 μs | 2.90 μs |   434.9 μs |   444.5 μs |   443.3 μs |      62 B |         - |
| Delegate                       |   435.3 μs | 1.28 μs | 1.07 μs |   434.0 μs |   437.9 μs |   436.6 μs |      62 B |         - |
| FactoryImplement               |   266.1 μs | 1.45 μs | 1.21 μs |   264.3 μs |   268.4 μs |   267.8 μs |      65 B |         - |
| SealedFactoryImplement         |   267.3 μs | 2.28 μs | 2.13 μs |   263.9 μs |   270.8 μs |   269.8 μs |      65 B |         - |
| AbstractFactoryImplement       |   259.6 μs | 0.98 μs | 0.82 μs |   258.5 μs |   261.2 μs |   260.8 μs |      62 B |         - |
| SealedAbstractFactoryImplement |   264.0 μs | 5.06 μs | 5.82 μs |   258.9 μs |   274.9 μs |   272.4 μs |      62 B |         - |
| StaticDirect                   |   214.3 μs | 0.85 μs | 0.80 μs |   213.2 μs |   216.0 μs |   215.3 μs |      29 B |         - |
| StaticPointer                  | 1,302.8 μs | 4.48 μs | 3.97 μs | 1,297.0 μs | 1,309.4 μs | 1,308.9 μs |      28 B |       1 B |
