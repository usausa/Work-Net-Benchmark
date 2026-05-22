```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.6901)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method                         | Job                 | Runtime   | Mean       | Error    | StdDev    | Min        | Max        | P90        | Code Size | Allocated |
|------------------------------- |-------------------- |---------- |-----------:|---------:|----------:|-----------:|-----------:|-----------:|----------:|----------:|
| Func                           | MediumRun-.NET 10.0 | .NET 10.0 |   235.9 μs |  2.63 μs |   3.94 μs |   227.9 μs |   244.0 μs |   239.8 μs |      67 B |         - |
| Delegate                       | MediumRun-.NET 10.0 | .NET 10.0 |   227.2 μs |  2.31 μs |   3.46 μs |   219.4 μs |   232.0 μs |   231.2 μs |      67 B |         - |
| FactoryImplement               | MediumRun-.NET 10.0 | .NET 10.0 |   197.6 μs |  0.15 μs |   0.23 μs |   197.1 μs |   197.8 μs |   197.8 μs |      65 B |         - |
| SealedFactoryImplement         | MediumRun-.NET 10.0 | .NET 10.0 |   197.3 μs |  0.21 μs |   0.31 μs |   196.8 μs |   197.9 μs |   197.7 μs |      65 B |         - |
| AbstractFactoryImplement       | MediumRun-.NET 10.0 | .NET 10.0 |   222.9 μs | 16.63 μs |  24.88 μs |   198.3 μs |   254.0 μs |   251.0 μs |      62 B |         - |
| SealedAbstractFactoryImplement | MediumRun-.NET 10.0 | .NET 10.0 |   246.7 μs |  3.74 μs |   5.59 μs |   236.5 μs |   258.2 μs |   254.1 μs |      62 B |         - |
| StaticDirect                   | MediumRun-.NET 10.0 | .NET 10.0 |   226.8 μs |  2.00 μs |   2.99 μs |   221.1 μs |   231.5 μs |   231.0 μs |      29 B |         - |
| StaticPointer                  | MediumRun-.NET 10.0 | .NET 10.0 | 1,720.6 μs | 30.49 μs |  45.63 μs | 1,602.2 μs | 1,774.6 μs | 1,766.6 μs |      28 B |         - |
| Func                           | MediumRun-.NET 8.0  | .NET 8.0  |   486.2 μs | 25.24 μs |  37.77 μs |   396.1 μs |   531.2 μs |   527.9 μs |      70 B |         - |
| Delegate                       | MediumRun-.NET 8.0  | .NET 8.0  |   488.2 μs | 30.03 μs |  44.95 μs |   353.0 μs |   534.7 μs |   528.2 μs |      70 B |         - |
| FactoryImplement               | MediumRun-.NET 8.0  | .NET 8.0  |   352.2 μs | 67.83 μs | 101.53 μs |   222.6 μs |   495.7 μs |   493.9 μs |      68 B |         - |
| SealedFactoryImplement         | MediumRun-.NET 8.0  | .NET 8.0  |   420.1 μs | 50.10 μs |  74.98 μs |   236.4 μs |   504.0 μs |   491.0 μs |      68 B |         - |
| AbstractFactoryImplement       | MediumRun-.NET 8.0  | .NET 8.0  |   337.8 μs | 95.02 μs | 136.27 μs |   197.0 μs |   498.2 μs |   494.0 μs |      65 B |         - |
| SealedAbstractFactoryImplement | MediumRun-.NET 8.0  | .NET 8.0  |   197.4 μs |  0.22 μs |   0.33 μs |   196.9 μs |   198.2 μs |   197.8 μs |      65 B |         - |
| StaticDirect                   | MediumRun-.NET 8.0  | .NET 8.0  |   196.4 μs |  0.04 μs |   0.05 μs |   196.3 μs |   196.5 μs |   196.5 μs |      31 B |         - |
| StaticPointer                  | MediumRun-.NET 8.0  | .NET 8.0  | 1,330.5 μs | 39.51 μs |  59.14 μs | 1,184.5 μs | 1,383.4 μs | 1,380.6 μs |      31 B |         - |
| Func                           | MediumRun-.NET 9.0  | .NET 9.0  |   223.5 μs |  1.90 μs |   2.85 μs |   218.0 μs |   229.6 μs |   226.8 μs |      67 B |         - |
| Delegate                       | MediumRun-.NET 9.0  | .NET 9.0  |   223.8 μs |  1.12 μs |   1.68 μs |   220.4 μs |   226.7 μs |   225.6 μs |      67 B |         - |
| FactoryImplement               | MediumRun-.NET 9.0  | .NET 9.0  |   196.8 μs |  0.19 μs |   0.28 μs |   196.4 μs |   197.3 μs |   197.2 μs |      65 B |         - |
| SealedFactoryImplement         | MediumRun-.NET 9.0  | .NET 9.0  |   197.6 μs |  1.07 μs |   1.60 μs |   196.2 μs |   200.5 μs |   200.4 μs |      65 B |         - |
| AbstractFactoryImplement       | MediumRun-.NET 9.0  | .NET 9.0  |   196.7 μs |  0.14 μs |   0.20 μs |   196.4 μs |   197.0 μs |   197.0 μs |      62 B |         - |
| SealedAbstractFactoryImplement | MediumRun-.NET 9.0  | .NET 9.0  |   206.3 μs |  0.99 μs |   1.41 μs |   204.5 μs |   209.4 μs |   208.3 μs |      62 B |         - |
| StaticDirect                   | MediumRun-.NET 9.0  | .NET 9.0  |   218.9 μs |  5.11 μs |   7.49 μs |   199.3 μs |   229.7 μs |   227.6 μs |      29 B |         - |
| StaticPointer                  | MediumRun-.NET 9.0  | .NET 9.0  | 1,677.4 μs | 48.41 μs |  72.46 μs | 1,492.2 μs | 1,767.3 μs | 1,751.6 μs |      28 B |         - |

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
