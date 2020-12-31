``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=5.0.101
  [Host]     : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  DefaultJob : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT


```
|          Method |      Mean |     Error |    StdDev |
|---------------- |----------:|----------:|----------:|
|          Static | 1.1932 ns | 0.0161 ns | 0.0143 ns |
|        Instance | 0.4095 ns | 0.0192 ns | 0.0179 ns |
|   DynamicStatic | 0.5756 ns | 0.0090 ns | 0.0084 ns |
| DynamicInstance | 0.0378 ns | 0.0102 ns | 0.0090 ns |
|         Pointer | 0.6114 ns | 0.0233 ns | 0.0218 ns |
