``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.100
  [Host]    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  MediumRun : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|         Method |      Mean |     Error |    StdDev |       Min |       Max |       P90 |  Gen 0 | Allocated |
|--------------- |----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| ByData0Factory |  2.375 ns | 0.0252 ns | 0.0369 ns |  2.314 ns |  2.426 ns |  2.416 ns | 0.0014 |      24 B |
| ByData1Factory |  5.023 ns | 0.0152 ns | 0.0213 ns |  4.980 ns |  5.064 ns |  5.047 ns | 0.0029 |      48 B |
| ByData2Factory | 13.411 ns | 0.0889 ns | 0.1275 ns | 13.207 ns | 13.631 ns | 13.564 ns | 0.0062 |     104 B |
|    ByData0Func |  2.884 ns | 0.0084 ns | 0.0125 ns |  2.862 ns |  2.909 ns |  2.896 ns | 0.0014 |      24 B |
|    ByData1Func |  7.508 ns | 0.0403 ns | 0.0591 ns |  7.380 ns |  7.626 ns |  7.567 ns | 0.0029 |      48 B |
|    ByData2Func | 15.790 ns | 0.1128 ns | 0.1617 ns | 15.452 ns | 16.029 ns | 15.958 ns | 0.0062 |     104 B |
