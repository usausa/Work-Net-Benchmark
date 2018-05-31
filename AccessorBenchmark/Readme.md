# Core 2.0

 |              Method |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
 |-------------------- |-----------:|-----------:|----------:|-------:|----------:|
 |    GenerativeGetter |   1.804 ns |  0.5555 ns | 0.0314 ns |      - |       0 B |
 | DynamicMethodGetter |   3.325 ns |  0.7644 ns | 0.0432 ns |      - |       0 B |
 |    ExpressionGetter |   4.849 ns |  0.5750 ns | 0.0325 ns |      - |       0 B |
 |      DelegateGetter |   5.700 ns |  1.8796 ns | 0.1062 ns |      - |       0 B |
 |    ReflectionGetter |  92.836 ns |  5.1161 ns | 0.2891 ns |      - |       0 B |
 |    GenerativeSetter |   3.946 ns |  1.0345 ns | 0.0584 ns |      - |       0 B |
 | DynamicMethodSetter |   5.162 ns |  0.2599 ns | 0.0147 ns |      - |       0 B |
 |    ExpressionSetter |   7.896 ns |  3.5855 ns | 0.2026 ns |      - |       0 B |
 |      DelegateSetter |   8.918 ns |  0.8807 ns | 0.0498 ns |      - |       0 B |
 |    ReflectionSetter | 169.669 ns | 38.6117 ns | 2.1816 ns | 0.0150 |      64 B |
