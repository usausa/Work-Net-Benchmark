|                      Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------------------- |---------:|----------:|----------:|-------:|----------:|
|                         Raw | 2.242 ns | 0.0545 ns | 0.0782 ns | 0.0057 |      24 B |
|       DirectInstanceFactory | 2.485 ns | 0.0678 ns | 0.0972 ns | 0.0057 |      24 B |
| DirectInstanceFactoryInline | 2.339 ns | 0.0416 ns | 0.0609 ns | 0.0057 |      24 B |
|         DirectStaticFactory | 2.379 ns | 0.0249 ns | 0.0349 ns | 0.0057 |      24 B |
|   DirectStaticFactoryInline | 2.244 ns | 0.0431 ns | 0.0646 ns | 0.0057 |      24 B |
|             InstanceFactory | 3.735 ns | 0.0373 ns | 0.0547 ns | 0.0057 |      24 B |
|       InstanceFactoryInline | 3.542 ns | 0.0384 ns | 0.0562 ns | 0.0057 |      24 B |
|               StaticFactory | 4.173 ns | 0.1528 ns | 0.2143 ns | 0.0057 |      24 B |
|         StaticFactoryInline | 3.974 ns | 0.0523 ns | 0.0750 ns | 0.0057 |      24 B |
|            DelegateFactory1 | 3.176 ns | 0.0491 ns | 0.0735 ns | 0.0057 |      24 B |
|            DelegateFactory2 | 2.878 ns | 0.0380 ns | 0.0568 ns | 0.0057 |      24 B |
|    DelegateFactory1WithCast | 4.251 ns | 0.0478 ns | 0.0685 ns | 0.0057 |      24 B |
|    DelegateFactory2WithCast | 4.259 ns | 0.0679 ns | 0.1016 ns | 0.0057 |      24 B |
