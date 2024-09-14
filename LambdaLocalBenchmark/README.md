```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

```
| Method         | Mean      | Error     | StdDev    | Median    | Min       | Max       | P90       | Code Size | Allocated |
|--------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| LambdaFunction | 0.1696 ns | 0.0167 ns | 0.0156 ns | 0.1604 ns | 0.1541 ns | 0.1932 ns | 0.1914 ns |     180 B |         - |
| LocalFunction  | 0.0025 ns | 0.0046 ns | 0.0043 ns | 0.0000 ns | 0.0000 ns | 0.0119 ns | 0.0095 ns |       6 B |         - |
