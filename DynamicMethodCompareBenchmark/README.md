# DynamicMethodBenchmark

# .NET Core

|          Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------- |---------:|----------:|----------:|-------:|----------:|
|   ByTypeBuilder | 4.579 ns | 0.8055 ns | 0.0455 ns | 0.0057 |      24 B |
| ByDynamicMethod | 3.730 ns | 0.8363 ns | 0.0473 ns | 0.0057 |      24 B |

# .NET Framework

|          Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------- |---------:|----------:|----------:|-------:|----------:|
|   ByTypeBuilder | 3.376 ns | 0.4733 ns | 0.0267 ns | 0.0029 |      12 B |
| ByDynamicMethod | 9.859 ns | 0.3344 ns | 0.0189 ns | 0.0028 |      12 B |
