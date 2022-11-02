## .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT
```assembly
; DisassemblyBenchmark.Benchmark.MinInline()
       7FFF0B82BB40 mov       eax,[rcx+8]
       7FFF0B82BB43 mov       edx,[rcx+0C]
       7FFF0B82BB46 cmp       eax,edx
       7FFF0B82BB48 jg        short M00_L00
       7FFF0B82BB4A jmp       short M00_L01
M00_L00:
       7FFF0B82BB4C mov       eax,edx
M00_L01:
       7FFF0B82BB4E ret
; Total bytes of code 15
```

## .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT
```assembly
; DisassemblyBenchmark.Benchmark.MinNoinline()
       7FFF0B82BC40 mov       [rsp+8],rcx
       7FFF0B82BC45 mov       ecx,[rcx+8]
       7FFF0B82BC48 mov       rdx,[rsp+8]
       7FFF0B82BC4D mov       edx,[rdx+0C]
       7FFF0B82BC50 jmp       near ptr DisassemblyBenchmark.Functions.MinNoinline(Int32, Int32)
; Total bytes of code 21
```
```assembly
; DisassemblyBenchmark.Functions.MinNoinline(Int32, Int32)
       7FFF0B82BC70 cmp       ecx,edx
       7FFF0B82BC72 jg        short M01_L00
       7FFF0B82BC74 mov       eax,ecx
       7FFF0B82BC76 ret
M01_L00:
       7FFF0B82BC77 mov       eax,edx
       7FFF0B82BC79 ret
; Total bytes of code 10
```

