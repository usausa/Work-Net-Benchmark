# DelegateCompareBenchmark

|             Method |  Job | Runtime |      Mean |     Error |    StdDev | Allocated |
|------------------- |----- |-------- |----------:|----------:|----------:|----------:|
|         CallDirect |  Clr |     Clr | 1.1138 ns | 0.0183 ns | 0.0171 ns |       0 B |
|   CallStaticMethod |  Clr |     Clr | 1.9434 ns | 0.0129 ns | 0.0121 ns |       0 B |
| CallInstanceMethod |  Clr |     Clr | 1.0833 ns | 0.0138 ns | 0.0122 ns |       0 B |
|        CallDynamic |  Clr |     Clr | 0.8433 ns | 0.0153 ns | 0.0143 ns |       0 B |
|         CallDirect | Core |    Core | 1.4681 ns | 0.0152 ns | 0.0135 ns |       0 B |
|   CallStaticMethod | Core |    Core | 1.9953 ns | 0.0267 ns | 0.0250 ns |       0 B |
| CallInstanceMethod | Core |    Core | 1.7633 ns | 0.0218 ns | 0.0204 ns |       0 B |
|        CallDynamic | Core |    Core | 1.1209 ns | 0.0130 ns | 0.0115 ns |       0 B |
