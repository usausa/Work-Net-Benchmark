# Core 2.2

|              Method |       Mean |      Error |    StdDev |     Median | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|-------------------- |-----------:|-----------:|----------:|-----------:|------------:|------------:|------------:|--------------------:|
|    GenerativeGetter |   1.704 ns |  0.1783 ns | 0.0098 ns |   1.699 ns |           - |           - |           - |                   - |
| DynamicMethodGetter |   3.846 ns |  1.7503 ns | 0.0959 ns |   3.892 ns |           - |           - |           - |                   - |
|    ExpressionGetter |   4.347 ns |  0.6707 ns | 0.0368 ns |   4.355 ns |           - |           - |           - |                   - |
|      DelegateGetter |   7.753 ns | 71.0039 ns | 3.8920 ns |   5.525 ns |           - |           - |           - |                   - |
|    ReflectionGetter |  87.169 ns | 15.7476 ns | 0.8632 ns |  86.724 ns |           - |           - |           - |                   - |
|    GenerativeSetter |   4.369 ns |  0.4919 ns | 0.0270 ns |   4.365 ns |           - |           - |           - |                   - |
| DynamicMethodSetter |   6.424 ns | 30.3755 ns | 1.6650 ns |   5.472 ns |           - |           - |           - |                   - |
|    ExpressionSetter |   8.045 ns |  1.3113 ns | 0.0719 ns |   8.027 ns |           - |           - |           - |                   - |
|      DelegateSetter |   9.225 ns |  1.5450 ns | 0.0847 ns |   9.178 ns |           - |           - |           - |                   - |
|    ReflectionSetter | 167.743 ns |  3.5123 ns | 0.1925 ns | 167.762 ns |      0.0150 |           - |           - |                64 B |

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
