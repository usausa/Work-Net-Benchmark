# DynamicMethodBenchmark

|          Method |  Job | Runtime |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------- |----- |-------- |---------:|----------:|----------:|-------:|----------:|
|   ByTypeBuilder |  Clr |     Clr | 3.551 ns | 0.0433 ns | 0.0405 ns | 0.0057 |      24 B |
| ByDynamicMethod |  Clr |     Clr | 8.733 ns | 0.0345 ns | 0.0269 ns | 0.0057 |      24 B |
|   ByTypeBuilder | Core |    Core | 4.555 ns | 0.0421 ns | 0.0374 ns | 0.0057 |      24 B |
| ByDynamicMethod | Core |    Core | 4.134 ns | 0.0517 ns | 0.0459 ns | 0.0057 |      24 B |
