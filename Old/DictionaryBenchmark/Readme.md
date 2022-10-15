# Get

|                Method |      Mean |      Error |    StdDev |    Gen 0 | Allocated |
|---------------------- |----------:|-----------:|----------:|---------:|----------:|
|            Dictionary | 218.38 us |  23.081 us | 1.3041 us |        - |       0 B |
|    DictionaryWithLock | 343.96 us |  64.851 us | 3.6642 us |        - |       0 B |
|  ConcurrentDictionary | 305.99 us | 104.315 us | 5.8940 us | 152.3438 |  640000 B |
|               AvlTree |  51.67 us |   5.081 us | 0.2871 us |        - |       0 B |
| ConcurrentHashArryMap |  38.68 us |   3.713 us | 0.2098 us |        - |       0 B |

# Add

|                     Method |       Mean |      Error |    StdDev |   Gen 0 | Allocated |
|--------------------------- |-----------:|-----------:|----------:|--------:|----------:|
|                 Dictionary |   5.542 us |  0.3663 us | 0.0207 us |  3.1891 |   13.1 KB |
|         DictionaryWithLock |   6.732 us |  0.6365 us | 0.0360 us |  3.1967 |  13.13 KB |
|       ConcurrentDictionary |  19.628 us |  2.6342 us | 0.1488 us |  6.5308 |  26.81 KB |
|                    AvlTree |  12.953 us |  0.9205 us | 0.0520 us | 11.9019 |  48.77 KB |
|     ConcurrentHashArrayMap | 209.691 us | 56.3827 us | 3.1857 us | 60.3027 | 247.22 KB |
| ConcurrentHashArrayMapBulk |  15.282 us |  6.1599 us | 0.3480 us |  4.6387 |  19.04 KB |
