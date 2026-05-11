## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Indexer()
       7FFBB04A9FA0 push      r15
       7FFBB04A9FA2 push      r14
       7FFBB04A9FA4 push      r13
       7FFBB04A9FA6 push      r12
       7FFBB04A9FA8 push      rdi
       7FFBB04A9FA9 push      rsi
       7FFBB04A9FAA push      rbp
       7FFBB04A9FAB push      rbx
       7FFBB04A9FAC sub       rsp,28
       7FFBB04A9FB0 mov       rdx,[rcx+8]
       7FFBB04A9FB4 test      rdx,rdx
       7FFBB04A9FB7 je        near ptr M00_L08
       7FFBB04A9FBD lea       rbx,[rdx+10]
       7FFBB04A9FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB04A9FC4 mov       rdx,[rcx+10]
       7FFBB04A9FC8 test      rdx,rdx
       7FFBB04A9FCB je        short M00_L09
       7FFBB04A9FCD lea       rdi,[rdx+10]
       7FFBB04A9FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB04A9FD4 cmp       esi,ebp
       7FFBB04A9FD6 jne       short M00_L07
       7FFBB04A9FD8 xor       r14d,r14d
       7FFBB04A9FDB cmp       r14d,esi
       7FFBB04A9FDE jge       short M00_L05
M00_L02:
       7FFBB04A9FE0 mov       r15,r14
       7FFBB04A9FE3 shl       r15,4
       7FFBB04A9FE7 lea       r13,[rbx+r15]
       7FFBB04A9FEB cmp       r14d,ebp
       7FFBB04A9FEE jae       near ptr M00_L14
       7FFBB04A9FF4 add       r15,rdi
       7FFBB04A9FF7 mov       r12,[r13+8]
       7FFBB04A9FFB mov       rax,[r15+8]
       7FFBB04A9FFF mov       [rsp+20],rax
       7FFBB04AA004 cmp       r12,rax
       7FFBB04AA007 jne       short M00_L10
M00_L03:
       7FFBB04AA009 mov       rcx,[r13]
       7FFBB04AA00D mov       rdx,[r15]
       7FFBB04AA010 cmp       rcx,rdx
       7FFBB04AA013 jne       near ptr M00_L11
M00_L04:
       7FFBB04AA019 inc       r14d
       7FFBB04AA01C cmp       r14d,esi
       7FFBB04AA01F jl        short M00_L02
M00_L05:
       7FFBB04AA021 mov       eax,1
M00_L06:
       7FFBB04AA026 add       rsp,28
       7FFBB04AA02A pop       rbx
       7FFBB04AA02B pop       rbp
       7FFBB04AA02C pop       rsi
       7FFBB04AA02D pop       rdi
       7FFBB04AA02E pop       r12
       7FFBB04AA030 pop       r13
       7FFBB04AA032 pop       r14
       7FFBB04AA034 pop       r15
       7FFBB04AA036 ret
M00_L07:
       7FFBB04AA037 xor       eax,eax
       7FFBB04AA039 jmp       short M00_L06
M00_L08:
       7FFBB04AA03B xor       ebx,ebx
       7FFBB04AA03D xor       esi,esi
       7FFBB04AA03F jmp       short M00_L00
M00_L09:
       7FFBB04AA041 xor       edi,edi
       7FFBB04AA043 xor       ebp,ebp
       7FFBB04AA045 jmp       short M00_L01
M00_L10:
       7FFBB04AA047 test      r12,r12
       7FFBB04AA04A je        short M00_L07
       7FFBB04AA04C test      rax,rax
       7FFBB04AA04F je        short M00_L07
       7FFBB04AA051 mov       rdx,r12
       7FFBB04AA054 mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA05E call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA064 test      rax,rax
       7FFBB04AA067 jne       short M00_L07
       7FFBB04AA069 mov       rdx,[rsp+20]
       7FFBB04AA06E mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA078 call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA07E test      rax,rax
       7FFBB04AA081 jne       short M00_L07
       7FFBB04AA083 mov       rcx,r12
       7FFBB04AA086 mov       rdx,[rsp+20]
       7FFBB04AA08B mov       rax,[r12]
       7FFBB04AA08F mov       rax,[rax+0A8]
       7FFBB04AA096 call      qword ptr [rax+18]
       7FFBB04AA099 test      eax,eax
       7FFBB04AA09B je        short M00_L07
       7FFBB04AA09D jmp       near ptr M00_L03
M00_L11:
       7FFBB04AA0A2 test      rcx,rcx
       7FFBB04AA0A5 je        short M00_L07
       7FFBB04AA0A7 test      rdx,rdx
       7FFBB04AA0AA je        short M00_L07
       7FFBB04AA0AC mov       r8d,[rcx+8]
       7FFBB04AA0B0 cmp       r8d,[rdx+8]
       7FFBB04AA0B4 jne       short M00_L07
       7FFBB04AA0B6 lea       rax,[rcx+0C]
       7FFBB04AA0BA add       rdx,0C
       7FFBB04AA0BE mov       ecx,[rcx+8]
       7FFBB04AA0C1 add       ecx,ecx
       7FFBB04AA0C3 mov       r8d,ecx
       7FFBB04AA0C6 cmp       r8,0A
       7FFBB04AA0CA jne       short M00_L12
       7FFBB04AA0CC mov       rcx,[rax]
       7FFBB04AA0CF mov       rax,[rax+2]
       7FFBB04AA0D3 mov       r8,[rdx]
       7FFBB04AA0D6 xor       rcx,r8
       7FFBB04AA0D9 xor       rax,[rdx+2]
       7FFBB04AA0DD or        rax,rcx
       7FFBB04AA0E0 sete      al
       7FFBB04AA0E3 movzx     eax,al
       7FFBB04AA0E6 jmp       short M00_L13
M00_L12:
       7FFBB04AA0E8 mov       rcx,rax
       7FFBB04AA0EB call      qword ptr [7FFBB043C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04AA0F1 test      eax,eax
       7FFBB04AA0F3 je        near ptr M00_L07
       7FFBB04AA0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB04AA0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB04AA103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04ACC80 test      rdx,rdx
       7FFBB04ACC83 je        short M01_L02
       7FFBB04ACC85 mov       rax,[rdx]
       7FFBB04ACC88 cmp       rax,rcx
       7FFBB04ACC8B je        short M01_L02
       7FFBB04ACC8D mov       rax,[rax+10]
       7FFBB04ACC91 cmp       rax,rcx
       7FFBB04ACC94 je        short M01_L02
M01_L00:
       7FFBB04ACC96 test      rax,rax
       7FFBB04ACC99 je        short M01_L01
       7FFBB04ACC9B mov       rax,[rax+10]
       7FFBB04ACC9F cmp       rax,rcx
       7FFBB04ACCA2 je        short M01_L02
       7FFBB04ACCA4 test      rax,rax
       7FFBB04ACCA7 je        short M01_L01
       7FFBB04ACCA9 mov       rax,[rax+10]
       7FFBB04ACCAD cmp       rax,rcx
       7FFBB04ACCB0 je        short M01_L02
       7FFBB04ACCB2 test      rax,rax
       7FFBB04ACCB5 jne       short M01_L03
M01_L01:
       7FFBB04ACCB7 xor       edx,edx
M01_L02:
       7FFBB04ACCB9 mov       rax,rdx
       7FFBB04ACCBC ret
M01_L03:
       7FFBB04ACCBD mov       rax,[rax+10]
       7FFBB04ACCC1 cmp       rax,rcx
       7FFBB04ACCC4 je        short M01_L02
       7FFBB04ACCC6 test      rax,rax
       7FFBB04ACCC9 je        short M01_L01
       7FFBB04ACCCB mov       rax,[rax+10]
       7FFBB04ACCCF cmp       rax,rcx
       7FFBB04ACCD2 je        short M01_L02
       7FFBB04ACCD4 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Sliced()
       7FFBB0489FA0 push      r15
       7FFBB0489FA2 push      r14
       7FFBB0489FA4 push      r13
       7FFBB0489FA6 push      r12
       7FFBB0489FA8 push      rdi
       7FFBB0489FA9 push      rsi
       7FFBB0489FAA push      rbp
       7FFBB0489FAB push      rbx
       7FFBB0489FAC sub       rsp,28
       7FFBB0489FB0 mov       rdx,[rcx+8]
       7FFBB0489FB4 test      rdx,rdx
       7FFBB0489FB7 je        near ptr M00_L08
       7FFBB0489FBD lea       rbx,[rdx+10]
       7FFBB0489FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB0489FC4 mov       rdx,[rcx+10]
       7FFBB0489FC8 test      rdx,rdx
       7FFBB0489FCB je        short M00_L09
       7FFBB0489FCD lea       rdi,[rdx+10]
       7FFBB0489FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB0489FD4 cmp       esi,ebp
       7FFBB0489FD6 jne       short M00_L07
       7FFBB0489FD8 xor       r14d,r14d
       7FFBB0489FDB cmp       r14d,esi
       7FFBB0489FDE jge       short M00_L05
M00_L02:
       7FFBB0489FE0 mov       r15,r14
       7FFBB0489FE3 shl       r15,4
       7FFBB0489FE7 lea       r13,[rbx+r15]
       7FFBB0489FEB cmp       r14d,ebp
       7FFBB0489FEE jae       near ptr M00_L14
       7FFBB0489FF4 add       r15,rdi
       7FFBB0489FF7 mov       r12,[r13+8]
       7FFBB0489FFB mov       rax,[r15+8]
       7FFBB0489FFF mov       [rsp+20],rax
       7FFBB048A004 cmp       r12,rax
       7FFBB048A007 jne       short M00_L10
M00_L03:
       7FFBB048A009 mov       rcx,[r13]
       7FFBB048A00D mov       rdx,[r15]
       7FFBB048A010 cmp       rcx,rdx
       7FFBB048A013 jne       near ptr M00_L11
M00_L04:
       7FFBB048A019 inc       r14d
       7FFBB048A01C cmp       r14d,esi
       7FFBB048A01F jl        short M00_L02
M00_L05:
       7FFBB048A021 mov       eax,1
M00_L06:
       7FFBB048A026 add       rsp,28
       7FFBB048A02A pop       rbx
       7FFBB048A02B pop       rbp
       7FFBB048A02C pop       rsi
       7FFBB048A02D pop       rdi
       7FFBB048A02E pop       r12
       7FFBB048A030 pop       r13
       7FFBB048A032 pop       r14
       7FFBB048A034 pop       r15
       7FFBB048A036 ret
M00_L07:
       7FFBB048A037 xor       eax,eax
       7FFBB048A039 jmp       short M00_L06
M00_L08:
       7FFBB048A03B xor       ebx,ebx
       7FFBB048A03D xor       esi,esi
       7FFBB048A03F jmp       short M00_L00
M00_L09:
       7FFBB048A041 xor       edi,edi
       7FFBB048A043 xor       ebp,ebp
       7FFBB048A045 jmp       short M00_L01
M00_L10:
       7FFBB048A047 test      r12,r12
       7FFBB048A04A je        short M00_L07
       7FFBB048A04C test      rax,rax
       7FFBB048A04F je        short M00_L07
       7FFBB048A051 mov       rdx,r12
       7FFBB048A054 mov       rcx,offset MT_System.RuntimeType
       7FFBB048A05E call      qword ptr [7FFBB0416850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048A064 test      rax,rax
       7FFBB048A067 jne       short M00_L07
       7FFBB048A069 mov       rdx,[rsp+20]
       7FFBB048A06E mov       rcx,offset MT_System.RuntimeType
       7FFBB048A078 call      qword ptr [7FFBB0416850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048A07E test      rax,rax
       7FFBB048A081 jne       short M00_L07
       7FFBB048A083 mov       rcx,r12
       7FFBB048A086 mov       rdx,[rsp+20]
       7FFBB048A08B mov       rax,[r12]
       7FFBB048A08F mov       rax,[rax+0A8]
       7FFBB048A096 call      qword ptr [rax+18]
       7FFBB048A099 test      eax,eax
       7FFBB048A09B je        short M00_L07
       7FFBB048A09D jmp       near ptr M00_L03
M00_L11:
       7FFBB048A0A2 test      rcx,rcx
       7FFBB048A0A5 je        short M00_L07
       7FFBB048A0A7 test      rdx,rdx
       7FFBB048A0AA je        short M00_L07
       7FFBB048A0AC mov       r8d,[rcx+8]
       7FFBB048A0B0 cmp       r8d,[rdx+8]
       7FFBB048A0B4 jne       short M00_L07
       7FFBB048A0B6 lea       rax,[rcx+0C]
       7FFBB048A0BA add       rdx,0C
       7FFBB048A0BE mov       ecx,[rcx+8]
       7FFBB048A0C1 add       ecx,ecx
       7FFBB048A0C3 mov       r8d,ecx
       7FFBB048A0C6 cmp       r8,0A
       7FFBB048A0CA jne       short M00_L12
       7FFBB048A0CC mov       rcx,[rax]
       7FFBB048A0CF mov       rax,[rax+2]
       7FFBB048A0D3 mov       r8,[rdx]
       7FFBB048A0D6 xor       rcx,r8
       7FFBB048A0D9 xor       rax,[rdx+2]
       7FFBB048A0DD or        rax,rcx
       7FFBB048A0E0 sete      al
       7FFBB048A0E3 movzx     eax,al
       7FFBB048A0E6 jmp       short M00_L13
M00_L12:
       7FFBB048A0E8 mov       rcx,rax
       7FFBB048A0EB call      qword ptr [7FFBB041C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB048A0F1 test      eax,eax
       7FFBB048A0F3 je        near ptr M00_L07
       7FFBB048A0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB048A0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB048A103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048C960 test      rdx,rdx
       7FFBB048C963 je        short M01_L02
       7FFBB048C965 mov       rax,[rdx]
       7FFBB048C968 cmp       rax,rcx
       7FFBB048C96B je        short M01_L02
       7FFBB048C96D mov       rax,[rax+10]
       7FFBB048C971 cmp       rax,rcx
       7FFBB048C974 je        short M01_L02
M01_L00:
       7FFBB048C976 test      rax,rax
       7FFBB048C979 je        short M01_L01
       7FFBB048C97B mov       rax,[rax+10]
       7FFBB048C97F cmp       rax,rcx
       7FFBB048C982 je        short M01_L02
       7FFBB048C984 test      rax,rax
       7FFBB048C987 je        short M01_L01
       7FFBB048C989 mov       rax,[rax+10]
       7FFBB048C98D cmp       rax,rcx
       7FFBB048C990 je        short M01_L02
       7FFBB048C992 test      rax,rax
       7FFBB048C995 jne       short M01_L03
M01_L01:
       7FFBB048C997 xor       edx,edx
M01_L02:
       7FFBB048C999 mov       rax,rdx
       7FFBB048C99C ret
M01_L03:
       7FFBB048C99D mov       rax,[rax+10]
       7FFBB048C9A1 cmp       rax,rcx
       7FFBB048C9A4 je        short M01_L02
       7FFBB048C9A6 test      rax,rax
       7FFBB048C9A9 je        short M01_L01
       7FFBB048C9AB mov       rax,[rax+10]
       7FFBB048C9AF cmp       rax,rcx
       7FFBB048C9B2 je        short M01_L02
       7FFBB048C9B4 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.GetRef()
       7FFBB0489FA0 push      r15
       7FFBB0489FA2 push      r14
       7FFBB0489FA4 push      r13
       7FFBB0489FA6 push      r12
       7FFBB0489FA8 push      rdi
       7FFBB0489FA9 push      rsi
       7FFBB0489FAA push      rbp
       7FFBB0489FAB push      rbx
       7FFBB0489FAC sub       rsp,28
       7FFBB0489FB0 mov       rdx,[rcx+8]
       7FFBB0489FB4 test      rdx,rdx
       7FFBB0489FB7 je        short M00_L08
       7FFBB0489FB9 lea       rbx,[rdx+10]
       7FFBB0489FBD mov       esi,[rdx+8]
M00_L00:
       7FFBB0489FC0 mov       rdx,[rcx+10]
       7FFBB0489FC4 test      rdx,rdx
       7FFBB0489FC7 je        short M00_L09
       7FFBB0489FC9 lea       rdi,[rdx+10]
       7FFBB0489FCD mov       edx,[rdx+8]
M00_L01:
       7FFBB0489FD0 cmp       esi,edx
       7FFBB0489FD2 jne       short M00_L07
       7FFBB0489FD4 xor       ebp,ebp
       7FFBB0489FD6 cmp       ebp,esi
       7FFBB0489FD8 jge       short M00_L05
M00_L02:
       7FFBB0489FDA movsxd    r14,ebp
       7FFBB0489FDD shl       r14,4
       7FFBB0489FE1 lea       r15,[rbx+r14]
       7FFBB0489FE5 add       r14,rdi
       7FFBB0489FE8 mov       r13,[r15+8]
       7FFBB0489FEC mov       r12,[r14+8]
       7FFBB0489FF0 cmp       r13,r12
       7FFBB0489FF3 jne       short M00_L10
M00_L03:
       7FFBB0489FF5 mov       rcx,[r15]
       7FFBB0489FF8 mov       rdx,[r14]
       7FFBB0489FFB cmp       rcx,rdx
       7FFBB0489FFE jne       near ptr M00_L11
M00_L04:
       7FFBB048A004 inc       ebp
       7FFBB048A006 cmp       ebp,esi
       7FFBB048A008 jl        short M00_L02
M00_L05:
       7FFBB048A00A mov       eax,1
M00_L06:
       7FFBB048A00F add       rsp,28
       7FFBB048A013 pop       rbx
       7FFBB048A014 pop       rbp
       7FFBB048A015 pop       rsi
       7FFBB048A016 pop       rdi
       7FFBB048A017 pop       r12
       7FFBB048A019 pop       r13
       7FFBB048A01B pop       r14
       7FFBB048A01D pop       r15
       7FFBB048A01F ret
M00_L07:
       7FFBB048A020 xor       eax,eax
       7FFBB048A022 jmp       short M00_L06
M00_L08:
       7FFBB048A024 xor       ebx,ebx
       7FFBB048A026 xor       esi,esi
       7FFBB048A028 jmp       short M00_L00
M00_L09:
       7FFBB048A02A xor       edi,edi
       7FFBB048A02C xor       edx,edx
       7FFBB048A02E jmp       short M00_L01
M00_L10:
       7FFBB048A030 test      r13,r13
       7FFBB048A033 je        short M00_L07
       7FFBB048A035 test      r12,r12
       7FFBB048A038 je        short M00_L07
       7FFBB048A03A mov       rdx,r13
       7FFBB048A03D mov       rcx,offset MT_System.RuntimeType
       7FFBB048A047 call      qword ptr [7FFBB0416850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048A04D test      rax,rax
       7FFBB048A050 jne       short M00_L07
       7FFBB048A052 mov       rdx,r12
       7FFBB048A055 mov       rcx,offset MT_System.RuntimeType
       7FFBB048A05F call      qword ptr [7FFBB0416850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048A065 test      rax,rax
       7FFBB048A068 jne       short M00_L07
       7FFBB048A06A mov       rcx,r13
       7FFBB048A06D mov       rdx,r12
       7FFBB048A070 mov       rax,[r13]
       7FFBB048A074 mov       rax,[rax+0A8]
       7FFBB048A07B call      qword ptr [rax+18]
       7FFBB048A07E test      eax,eax
       7FFBB048A080 je        short M00_L07
       7FFBB048A082 jmp       near ptr M00_L03
M00_L11:
       7FFBB048A087 test      rcx,rcx
       7FFBB048A08A je        short M00_L07
       7FFBB048A08C test      rdx,rdx
       7FFBB048A08F je        short M00_L07
       7FFBB048A091 mov       r8d,[rcx+8]
       7FFBB048A095 cmp       r8d,[rdx+8]
       7FFBB048A099 jne       short M00_L07
       7FFBB048A09B lea       rax,[rcx+0C]
       7FFBB048A09F add       rdx,0C
       7FFBB048A0A3 mov       ecx,[rcx+8]
       7FFBB048A0A6 add       ecx,ecx
       7FFBB048A0A8 mov       r8d,ecx
       7FFBB048A0AB cmp       r8,0A
       7FFBB048A0AF jne       short M00_L12
       7FFBB048A0B1 mov       rcx,[rax]
       7FFBB048A0B4 mov       rax,[rax+2]
       7FFBB048A0B8 mov       r8,[rdx]
       7FFBB048A0BB xor       rcx,r8
       7FFBB048A0BE xor       rax,[rdx+2]
       7FFBB048A0C2 or        rax,rcx
       7FFBB048A0C5 sete      al
       7FFBB048A0C8 movzx     eax,al
       7FFBB048A0CB jmp       short M00_L13
M00_L12:
       7FFBB048A0CD mov       rcx,rax
       7FFBB048A0D0 call      qword ptr [7FFBB041C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB048A0D6 test      eax,eax
       7FFBB048A0D8 je        near ptr M00_L07
       7FFBB048A0DE jmp       near ptr M00_L04
; Total bytes of code 323
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048C940 test      rdx,rdx
       7FFBB048C943 je        short M01_L02
       7FFBB048C945 mov       rax,[rdx]
       7FFBB048C948 cmp       rax,rcx
       7FFBB048C94B je        short M01_L02
       7FFBB048C94D mov       rax,[rax+10]
       7FFBB048C951 cmp       rax,rcx
       7FFBB048C954 je        short M01_L02
M01_L00:
       7FFBB048C956 test      rax,rax
       7FFBB048C959 je        short M01_L01
       7FFBB048C95B mov       rax,[rax+10]
       7FFBB048C95F cmp       rax,rcx
       7FFBB048C962 je        short M01_L02
       7FFBB048C964 test      rax,rax
       7FFBB048C967 je        short M01_L01
       7FFBB048C969 mov       rax,[rax+10]
       7FFBB048C96D cmp       rax,rcx
       7FFBB048C970 je        short M01_L02
       7FFBB048C972 test      rax,rax
       7FFBB048C975 jne       short M01_L03
M01_L01:
       7FFBB048C977 xor       edx,edx
M01_L02:
       7FFBB048C979 mov       rax,rdx
       7FFBB048C97C ret
M01_L03:
       7FFBB048C97D mov       rax,[rax+10]
       7FFBB048C981 cmp       rax,rcx
       7FFBB048C984 je        short M01_L02
       7FFBB048C986 test      rax,rax
       7FFBB048C989 je        short M01_L01
       7FFBB048C98B mov       rax,[rax+10]
       7FFBB048C98F cmp       rax,rcx
       7FFBB048C992 je        short M01_L02
       7FFBB048C994 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Indexer()
       7FFBB04A9FA0 push      r15
       7FFBB04A9FA2 push      r14
       7FFBB04A9FA4 push      r13
       7FFBB04A9FA6 push      r12
       7FFBB04A9FA8 push      rdi
       7FFBB04A9FA9 push      rsi
       7FFBB04A9FAA push      rbp
       7FFBB04A9FAB push      rbx
       7FFBB04A9FAC sub       rsp,28
       7FFBB04A9FB0 mov       rdx,[rcx+8]
       7FFBB04A9FB4 test      rdx,rdx
       7FFBB04A9FB7 je        near ptr M00_L08
       7FFBB04A9FBD lea       rbx,[rdx+10]
       7FFBB04A9FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB04A9FC4 mov       rdx,[rcx+10]
       7FFBB04A9FC8 test      rdx,rdx
       7FFBB04A9FCB je        short M00_L09
       7FFBB04A9FCD lea       rdi,[rdx+10]
       7FFBB04A9FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB04A9FD4 cmp       esi,ebp
       7FFBB04A9FD6 jne       short M00_L07
       7FFBB04A9FD8 xor       r14d,r14d
       7FFBB04A9FDB cmp       r14d,esi
       7FFBB04A9FDE jge       short M00_L05
M00_L02:
       7FFBB04A9FE0 mov       r15,r14
       7FFBB04A9FE3 shl       r15,4
       7FFBB04A9FE7 lea       r13,[rbx+r15]
       7FFBB04A9FEB cmp       r14d,ebp
       7FFBB04A9FEE jae       near ptr M00_L14
       7FFBB04A9FF4 add       r15,rdi
       7FFBB04A9FF7 mov       r12,[r13+8]
       7FFBB04A9FFB mov       rax,[r15+8]
       7FFBB04A9FFF mov       [rsp+20],rax
       7FFBB04AA004 cmp       r12,rax
       7FFBB04AA007 jne       short M00_L10
M00_L03:
       7FFBB04AA009 mov       rcx,[r13]
       7FFBB04AA00D mov       rdx,[r15]
       7FFBB04AA010 cmp       rcx,rdx
       7FFBB04AA013 jne       near ptr M00_L11
M00_L04:
       7FFBB04AA019 inc       r14d
       7FFBB04AA01C cmp       r14d,esi
       7FFBB04AA01F jl        short M00_L02
M00_L05:
       7FFBB04AA021 mov       eax,1
M00_L06:
       7FFBB04AA026 add       rsp,28
       7FFBB04AA02A pop       rbx
       7FFBB04AA02B pop       rbp
       7FFBB04AA02C pop       rsi
       7FFBB04AA02D pop       rdi
       7FFBB04AA02E pop       r12
       7FFBB04AA030 pop       r13
       7FFBB04AA032 pop       r14
       7FFBB04AA034 pop       r15
       7FFBB04AA036 ret
M00_L07:
       7FFBB04AA037 xor       eax,eax
       7FFBB04AA039 jmp       short M00_L06
M00_L08:
       7FFBB04AA03B xor       ebx,ebx
       7FFBB04AA03D xor       esi,esi
       7FFBB04AA03F jmp       short M00_L00
M00_L09:
       7FFBB04AA041 xor       edi,edi
       7FFBB04AA043 xor       ebp,ebp
       7FFBB04AA045 jmp       short M00_L01
M00_L10:
       7FFBB04AA047 test      r12,r12
       7FFBB04AA04A je        short M00_L07
       7FFBB04AA04C test      rax,rax
       7FFBB04AA04F je        short M00_L07
       7FFBB04AA051 mov       rdx,r12
       7FFBB04AA054 mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA05E call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA064 test      rax,rax
       7FFBB04AA067 jne       short M00_L07
       7FFBB04AA069 mov       rdx,[rsp+20]
       7FFBB04AA06E mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA078 call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA07E test      rax,rax
       7FFBB04AA081 jne       short M00_L07
       7FFBB04AA083 mov       rcx,r12
       7FFBB04AA086 mov       rdx,[rsp+20]
       7FFBB04AA08B mov       rax,[r12]
       7FFBB04AA08F mov       rax,[rax+0A8]
       7FFBB04AA096 call      qword ptr [rax+18]
       7FFBB04AA099 test      eax,eax
       7FFBB04AA09B je        short M00_L07
       7FFBB04AA09D jmp       near ptr M00_L03
M00_L11:
       7FFBB04AA0A2 test      rcx,rcx
       7FFBB04AA0A5 je        short M00_L07
       7FFBB04AA0A7 test      rdx,rdx
       7FFBB04AA0AA je        short M00_L07
       7FFBB04AA0AC mov       r8d,[rcx+8]
       7FFBB04AA0B0 cmp       r8d,[rdx+8]
       7FFBB04AA0B4 jne       short M00_L07
       7FFBB04AA0B6 lea       rax,[rcx+0C]
       7FFBB04AA0BA add       rdx,0C
       7FFBB04AA0BE mov       ecx,[rcx+8]
       7FFBB04AA0C1 add       ecx,ecx
       7FFBB04AA0C3 mov       r8d,ecx
       7FFBB04AA0C6 cmp       r8,0A
       7FFBB04AA0CA jne       short M00_L12
       7FFBB04AA0CC mov       rcx,[rax]
       7FFBB04AA0CF mov       rax,[rax+2]
       7FFBB04AA0D3 mov       r8,[rdx]
       7FFBB04AA0D6 xor       rcx,r8
       7FFBB04AA0D9 xor       rax,[rdx+2]
       7FFBB04AA0DD or        rax,rcx
       7FFBB04AA0E0 sete      al
       7FFBB04AA0E3 movzx     eax,al
       7FFBB04AA0E6 jmp       short M00_L13
M00_L12:
       7FFBB04AA0E8 mov       rcx,rax
       7FFBB04AA0EB call      qword ptr [7FFBB043C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04AA0F1 test      eax,eax
       7FFBB04AA0F3 je        near ptr M00_L07
       7FFBB04AA0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB04AA0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB04AA103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04ACC80 test      rdx,rdx
       7FFBB04ACC83 je        short M01_L02
       7FFBB04ACC85 mov       rax,[rdx]
       7FFBB04ACC88 cmp       rax,rcx
       7FFBB04ACC8B je        short M01_L02
       7FFBB04ACC8D mov       rax,[rax+10]
       7FFBB04ACC91 cmp       rax,rcx
       7FFBB04ACC94 je        short M01_L02
M01_L00:
       7FFBB04ACC96 test      rax,rax
       7FFBB04ACC99 je        short M01_L01
       7FFBB04ACC9B mov       rax,[rax+10]
       7FFBB04ACC9F cmp       rax,rcx
       7FFBB04ACCA2 je        short M01_L02
       7FFBB04ACCA4 test      rax,rax
       7FFBB04ACCA7 je        short M01_L01
       7FFBB04ACCA9 mov       rax,[rax+10]
       7FFBB04ACCAD cmp       rax,rcx
       7FFBB04ACCB0 je        short M01_L02
       7FFBB04ACCB2 test      rax,rax
       7FFBB04ACCB5 jne       short M01_L03
M01_L01:
       7FFBB04ACCB7 xor       edx,edx
M01_L02:
       7FFBB04ACCB9 mov       rax,rdx
       7FFBB04ACCBC ret
M01_L03:
       7FFBB04ACCBD mov       rax,[rax+10]
       7FFBB04ACCC1 cmp       rax,rcx
       7FFBB04ACCC4 je        short M01_L02
       7FFBB04ACCC6 test      rax,rax
       7FFBB04ACCC9 je        short M01_L01
       7FFBB04ACCCB mov       rax,[rax+10]
       7FFBB04ACCCF cmp       rax,rcx
       7FFBB04ACCD2 je        short M01_L02
       7FFBB04ACCD4 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Sliced()
       7FFBB0499FA0 push      r15
       7FFBB0499FA2 push      r14
       7FFBB0499FA4 push      r13
       7FFBB0499FA6 push      r12
       7FFBB0499FA8 push      rdi
       7FFBB0499FA9 push      rsi
       7FFBB0499FAA push      rbp
       7FFBB0499FAB push      rbx
       7FFBB0499FAC sub       rsp,28
       7FFBB0499FB0 mov       rdx,[rcx+8]
       7FFBB0499FB4 test      rdx,rdx
       7FFBB0499FB7 je        near ptr M00_L08
       7FFBB0499FBD lea       rbx,[rdx+10]
       7FFBB0499FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB0499FC4 mov       rdx,[rcx+10]
       7FFBB0499FC8 test      rdx,rdx
       7FFBB0499FCB je        short M00_L09
       7FFBB0499FCD lea       rdi,[rdx+10]
       7FFBB0499FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB0499FD4 cmp       esi,ebp
       7FFBB0499FD6 jne       short M00_L07
       7FFBB0499FD8 xor       r14d,r14d
       7FFBB0499FDB cmp       r14d,esi
       7FFBB0499FDE jge       short M00_L05
M00_L02:
       7FFBB0499FE0 mov       r15,r14
       7FFBB0499FE3 shl       r15,4
       7FFBB0499FE7 lea       r13,[rbx+r15]
       7FFBB0499FEB cmp       r14d,ebp
       7FFBB0499FEE jae       near ptr M00_L14
       7FFBB0499FF4 add       r15,rdi
       7FFBB0499FF7 mov       r12,[r13+8]
       7FFBB0499FFB mov       rax,[r15+8]
       7FFBB0499FFF mov       [rsp+20],rax
       7FFBB049A004 cmp       r12,rax
       7FFBB049A007 jne       short M00_L10
M00_L03:
       7FFBB049A009 mov       rcx,[r13]
       7FFBB049A00D mov       rdx,[r15]
       7FFBB049A010 cmp       rcx,rdx
       7FFBB049A013 jne       near ptr M00_L11
M00_L04:
       7FFBB049A019 inc       r14d
       7FFBB049A01C cmp       r14d,esi
       7FFBB049A01F jl        short M00_L02
M00_L05:
       7FFBB049A021 mov       eax,1
M00_L06:
       7FFBB049A026 add       rsp,28
       7FFBB049A02A pop       rbx
       7FFBB049A02B pop       rbp
       7FFBB049A02C pop       rsi
       7FFBB049A02D pop       rdi
       7FFBB049A02E pop       r12
       7FFBB049A030 pop       r13
       7FFBB049A032 pop       r14
       7FFBB049A034 pop       r15
       7FFBB049A036 ret
M00_L07:
       7FFBB049A037 xor       eax,eax
       7FFBB049A039 jmp       short M00_L06
M00_L08:
       7FFBB049A03B xor       ebx,ebx
       7FFBB049A03D xor       esi,esi
       7FFBB049A03F jmp       short M00_L00
M00_L09:
       7FFBB049A041 xor       edi,edi
       7FFBB049A043 xor       ebp,ebp
       7FFBB049A045 jmp       short M00_L01
M00_L10:
       7FFBB049A047 test      r12,r12
       7FFBB049A04A je        short M00_L07
       7FFBB049A04C test      rax,rax
       7FFBB049A04F je        short M00_L07
       7FFBB049A051 mov       rdx,r12
       7FFBB049A054 mov       rcx,offset MT_System.RuntimeType
       7FFBB049A05E call      qword ptr [7FFBB0426850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB049A064 test      rax,rax
       7FFBB049A067 jne       short M00_L07
       7FFBB049A069 mov       rdx,[rsp+20]
       7FFBB049A06E mov       rcx,offset MT_System.RuntimeType
       7FFBB049A078 call      qword ptr [7FFBB0426850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB049A07E test      rax,rax
       7FFBB049A081 jne       short M00_L07
       7FFBB049A083 mov       rcx,r12
       7FFBB049A086 mov       rdx,[rsp+20]
       7FFBB049A08B mov       rax,[r12]
       7FFBB049A08F mov       rax,[rax+0A8]
       7FFBB049A096 call      qword ptr [rax+18]
       7FFBB049A099 test      eax,eax
       7FFBB049A09B je        short M00_L07
       7FFBB049A09D jmp       near ptr M00_L03
M00_L11:
       7FFBB049A0A2 test      rcx,rcx
       7FFBB049A0A5 je        short M00_L07
       7FFBB049A0A7 test      rdx,rdx
       7FFBB049A0AA je        short M00_L07
       7FFBB049A0AC mov       r8d,[rcx+8]
       7FFBB049A0B0 cmp       r8d,[rdx+8]
       7FFBB049A0B4 jne       short M00_L07
       7FFBB049A0B6 lea       rax,[rcx+0C]
       7FFBB049A0BA add       rdx,0C
       7FFBB049A0BE mov       ecx,[rcx+8]
       7FFBB049A0C1 add       ecx,ecx
       7FFBB049A0C3 mov       r8d,ecx
       7FFBB049A0C6 cmp       r8,0A
       7FFBB049A0CA jne       short M00_L12
       7FFBB049A0CC mov       rcx,[rax]
       7FFBB049A0CF mov       rax,[rax+2]
       7FFBB049A0D3 mov       r8,[rdx]
       7FFBB049A0D6 xor       rcx,r8
       7FFBB049A0D9 xor       rax,[rdx+2]
       7FFBB049A0DD or        rax,rcx
       7FFBB049A0E0 sete      al
       7FFBB049A0E3 movzx     eax,al
       7FFBB049A0E6 jmp       short M00_L13
M00_L12:
       7FFBB049A0E8 mov       rcx,rax
       7FFBB049A0EB call      qword ptr [7FFBB042C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB049A0F1 test      eax,eax
       7FFBB049A0F3 je        near ptr M00_L07
       7FFBB049A0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB049A0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB049A103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB049CD80 test      rdx,rdx
       7FFBB049CD83 je        short M01_L02
       7FFBB049CD85 mov       rax,[rdx]
       7FFBB049CD88 cmp       rax,rcx
       7FFBB049CD8B je        short M01_L02
       7FFBB049CD8D mov       rax,[rax+10]
       7FFBB049CD91 cmp       rax,rcx
       7FFBB049CD94 je        short M01_L02
M01_L00:
       7FFBB049CD96 test      rax,rax
       7FFBB049CD99 je        short M01_L01
       7FFBB049CD9B mov       rax,[rax+10]
       7FFBB049CD9F cmp       rax,rcx
       7FFBB049CDA2 je        short M01_L02
       7FFBB049CDA4 test      rax,rax
       7FFBB049CDA7 je        short M01_L01
       7FFBB049CDA9 mov       rax,[rax+10]
       7FFBB049CDAD cmp       rax,rcx
       7FFBB049CDB0 je        short M01_L02
       7FFBB049CDB2 test      rax,rax
       7FFBB049CDB5 jne       short M01_L03
M01_L01:
       7FFBB049CDB7 xor       edx,edx
M01_L02:
       7FFBB049CDB9 mov       rax,rdx
       7FFBB049CDBC ret
M01_L03:
       7FFBB049CDBD mov       rax,[rax+10]
       7FFBB049CDC1 cmp       rax,rcx
       7FFBB049CDC4 je        short M01_L02
       7FFBB049CDC6 test      rax,rax
       7FFBB049CDC9 je        short M01_L01
       7FFBB049CDCB mov       rax,[rax+10]
       7FFBB049CDCF cmp       rax,rcx
       7FFBB049CDD2 je        short M01_L02
       7FFBB049CDD4 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.GetRef()
       7FFBB04A9FA0 push      r15
       7FFBB04A9FA2 push      r14
       7FFBB04A9FA4 push      r13
       7FFBB04A9FA6 push      r12
       7FFBB04A9FA8 push      rdi
       7FFBB04A9FA9 push      rsi
       7FFBB04A9FAA push      rbp
       7FFBB04A9FAB push      rbx
       7FFBB04A9FAC sub       rsp,28
       7FFBB04A9FB0 mov       rdx,[rcx+8]
       7FFBB04A9FB4 test      rdx,rdx
       7FFBB04A9FB7 je        short M00_L08
       7FFBB04A9FB9 lea       rbx,[rdx+10]
       7FFBB04A9FBD mov       esi,[rdx+8]
M00_L00:
       7FFBB04A9FC0 mov       rdx,[rcx+10]
       7FFBB04A9FC4 test      rdx,rdx
       7FFBB04A9FC7 je        short M00_L09
       7FFBB04A9FC9 lea       rdi,[rdx+10]
       7FFBB04A9FCD mov       edx,[rdx+8]
M00_L01:
       7FFBB04A9FD0 cmp       esi,edx
       7FFBB04A9FD2 jne       short M00_L07
       7FFBB04A9FD4 xor       ebp,ebp
       7FFBB04A9FD6 cmp       ebp,esi
       7FFBB04A9FD8 jge       short M00_L05
M00_L02:
       7FFBB04A9FDA movsxd    r14,ebp
       7FFBB04A9FDD shl       r14,4
       7FFBB04A9FE1 lea       r15,[rbx+r14]
       7FFBB04A9FE5 add       r14,rdi
       7FFBB04A9FE8 mov       r13,[r15+8]
       7FFBB04A9FEC mov       r12,[r14+8]
       7FFBB04A9FF0 cmp       r13,r12
       7FFBB04A9FF3 jne       short M00_L10
M00_L03:
       7FFBB04A9FF5 mov       rcx,[r15]
       7FFBB04A9FF8 mov       rdx,[r14]
       7FFBB04A9FFB cmp       rcx,rdx
       7FFBB04A9FFE jne       near ptr M00_L11
M00_L04:
       7FFBB04AA004 inc       ebp
       7FFBB04AA006 cmp       ebp,esi
       7FFBB04AA008 jl        short M00_L02
M00_L05:
       7FFBB04AA00A mov       eax,1
M00_L06:
       7FFBB04AA00F add       rsp,28
       7FFBB04AA013 pop       rbx
       7FFBB04AA014 pop       rbp
       7FFBB04AA015 pop       rsi
       7FFBB04AA016 pop       rdi
       7FFBB04AA017 pop       r12
       7FFBB04AA019 pop       r13
       7FFBB04AA01B pop       r14
       7FFBB04AA01D pop       r15
       7FFBB04AA01F ret
M00_L07:
       7FFBB04AA020 xor       eax,eax
       7FFBB04AA022 jmp       short M00_L06
M00_L08:
       7FFBB04AA024 xor       ebx,ebx
       7FFBB04AA026 xor       esi,esi
       7FFBB04AA028 jmp       short M00_L00
M00_L09:
       7FFBB04AA02A xor       edi,edi
       7FFBB04AA02C xor       edx,edx
       7FFBB04AA02E jmp       short M00_L01
M00_L10:
       7FFBB04AA030 test      r13,r13
       7FFBB04AA033 je        short M00_L07
       7FFBB04AA035 test      r12,r12
       7FFBB04AA038 je        short M00_L07
       7FFBB04AA03A mov       rdx,r13
       7FFBB04AA03D mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA047 call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA04D test      rax,rax
       7FFBB04AA050 jne       short M00_L07
       7FFBB04AA052 mov       rdx,r12
       7FFBB04AA055 mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA05F call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA065 test      rax,rax
       7FFBB04AA068 jne       short M00_L07
       7FFBB04AA06A mov       rcx,r13
       7FFBB04AA06D mov       rdx,r12
       7FFBB04AA070 mov       rax,[r13]
       7FFBB04AA074 mov       rax,[rax+0A8]
       7FFBB04AA07B call      qword ptr [rax+18]
       7FFBB04AA07E test      eax,eax
       7FFBB04AA080 je        short M00_L07
       7FFBB04AA082 jmp       near ptr M00_L03
M00_L11:
       7FFBB04AA087 test      rcx,rcx
       7FFBB04AA08A je        short M00_L07
       7FFBB04AA08C test      rdx,rdx
       7FFBB04AA08F je        short M00_L07
       7FFBB04AA091 mov       r8d,[rcx+8]
       7FFBB04AA095 cmp       r8d,[rdx+8]
       7FFBB04AA099 jne       short M00_L07
       7FFBB04AA09B lea       rax,[rcx+0C]
       7FFBB04AA09F add       rdx,0C
       7FFBB04AA0A3 mov       ecx,[rcx+8]
       7FFBB04AA0A6 add       ecx,ecx
       7FFBB04AA0A8 mov       r8d,ecx
       7FFBB04AA0AB cmp       r8,0A
       7FFBB04AA0AF jne       short M00_L12
       7FFBB04AA0B1 mov       rcx,[rax]
       7FFBB04AA0B4 mov       rax,[rax+2]
       7FFBB04AA0B8 mov       r8,[rdx]
       7FFBB04AA0BB xor       rcx,r8
       7FFBB04AA0BE xor       rax,[rdx+2]
       7FFBB04AA0C2 or        rax,rcx
       7FFBB04AA0C5 sete      al
       7FFBB04AA0C8 movzx     eax,al
       7FFBB04AA0CB jmp       short M00_L13
M00_L12:
       7FFBB04AA0CD mov       rcx,rax
       7FFBB04AA0D0 call      qword ptr [7FFBB043C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04AA0D6 test      eax,eax
       7FFBB04AA0D8 je        near ptr M00_L07
       7FFBB04AA0DE jmp       near ptr M00_L04
; Total bytes of code 323
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04ACC60 test      rdx,rdx
       7FFBB04ACC63 je        short M01_L02
       7FFBB04ACC65 mov       rax,[rdx]
       7FFBB04ACC68 cmp       rax,rcx
       7FFBB04ACC6B je        short M01_L02
       7FFBB04ACC6D mov       rax,[rax+10]
       7FFBB04ACC71 cmp       rax,rcx
       7FFBB04ACC74 je        short M01_L02
M01_L00:
       7FFBB04ACC76 test      rax,rax
       7FFBB04ACC79 je        short M01_L01
       7FFBB04ACC7B mov       rax,[rax+10]
       7FFBB04ACC7F cmp       rax,rcx
       7FFBB04ACC82 je        short M01_L02
       7FFBB04ACC84 test      rax,rax
       7FFBB04ACC87 je        short M01_L01
       7FFBB04ACC89 mov       rax,[rax+10]
       7FFBB04ACC8D cmp       rax,rcx
       7FFBB04ACC90 je        short M01_L02
       7FFBB04ACC92 test      rax,rax
       7FFBB04ACC95 jne       short M01_L03
M01_L01:
       7FFBB04ACC97 xor       edx,edx
M01_L02:
       7FFBB04ACC99 mov       rax,rdx
       7FFBB04ACC9C ret
M01_L03:
       7FFBB04ACC9D mov       rax,[rax+10]
       7FFBB04ACCA1 cmp       rax,rcx
       7FFBB04ACCA4 je        short M01_L02
       7FFBB04ACCA6 test      rax,rax
       7FFBB04ACCA9 je        short M01_L01
       7FFBB04ACCAB mov       rax,[rax+10]
       7FFBB04ACCAF cmp       rax,rcx
       7FFBB04ACCB2 je        short M01_L02
       7FFBB04ACCB4 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Indexer()
       7FFBB04A9FA0 push      r15
       7FFBB04A9FA2 push      r14
       7FFBB04A9FA4 push      r13
       7FFBB04A9FA6 push      r12
       7FFBB04A9FA8 push      rdi
       7FFBB04A9FA9 push      rsi
       7FFBB04A9FAA push      rbp
       7FFBB04A9FAB push      rbx
       7FFBB04A9FAC sub       rsp,28
       7FFBB04A9FB0 mov       rdx,[rcx+8]
       7FFBB04A9FB4 test      rdx,rdx
       7FFBB04A9FB7 je        near ptr M00_L08
       7FFBB04A9FBD lea       rbx,[rdx+10]
       7FFBB04A9FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB04A9FC4 mov       rdx,[rcx+10]
       7FFBB04A9FC8 test      rdx,rdx
       7FFBB04A9FCB je        short M00_L09
       7FFBB04A9FCD lea       rdi,[rdx+10]
       7FFBB04A9FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB04A9FD4 cmp       esi,ebp
       7FFBB04A9FD6 jne       short M00_L07
       7FFBB04A9FD8 xor       r14d,r14d
       7FFBB04A9FDB cmp       r14d,esi
       7FFBB04A9FDE jge       short M00_L05
M00_L02:
       7FFBB04A9FE0 mov       r15,r14
       7FFBB04A9FE3 shl       r15,4
       7FFBB04A9FE7 lea       r13,[rbx+r15]
       7FFBB04A9FEB cmp       r14d,ebp
       7FFBB04A9FEE jae       near ptr M00_L14
       7FFBB04A9FF4 add       r15,rdi
       7FFBB04A9FF7 mov       r12,[r13+8]
       7FFBB04A9FFB mov       rax,[r15+8]
       7FFBB04A9FFF mov       [rsp+20],rax
       7FFBB04AA004 cmp       r12,rax
       7FFBB04AA007 jne       short M00_L10
M00_L03:
       7FFBB04AA009 mov       rcx,[r13]
       7FFBB04AA00D mov       rdx,[r15]
       7FFBB04AA010 cmp       rcx,rdx
       7FFBB04AA013 jne       near ptr M00_L11
M00_L04:
       7FFBB04AA019 inc       r14d
       7FFBB04AA01C cmp       r14d,esi
       7FFBB04AA01F jl        short M00_L02
M00_L05:
       7FFBB04AA021 mov       eax,1
M00_L06:
       7FFBB04AA026 add       rsp,28
       7FFBB04AA02A pop       rbx
       7FFBB04AA02B pop       rbp
       7FFBB04AA02C pop       rsi
       7FFBB04AA02D pop       rdi
       7FFBB04AA02E pop       r12
       7FFBB04AA030 pop       r13
       7FFBB04AA032 pop       r14
       7FFBB04AA034 pop       r15
       7FFBB04AA036 ret
M00_L07:
       7FFBB04AA037 xor       eax,eax
       7FFBB04AA039 jmp       short M00_L06
M00_L08:
       7FFBB04AA03B xor       ebx,ebx
       7FFBB04AA03D xor       esi,esi
       7FFBB04AA03F jmp       short M00_L00
M00_L09:
       7FFBB04AA041 xor       edi,edi
       7FFBB04AA043 xor       ebp,ebp
       7FFBB04AA045 jmp       short M00_L01
M00_L10:
       7FFBB04AA047 test      r12,r12
       7FFBB04AA04A je        short M00_L07
       7FFBB04AA04C test      rax,rax
       7FFBB04AA04F je        short M00_L07
       7FFBB04AA051 mov       rdx,r12
       7FFBB04AA054 mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA05E call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA064 test      rax,rax
       7FFBB04AA067 jne       short M00_L07
       7FFBB04AA069 mov       rdx,[rsp+20]
       7FFBB04AA06E mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA078 call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA07E test      rax,rax
       7FFBB04AA081 jne       short M00_L07
       7FFBB04AA083 mov       rcx,r12
       7FFBB04AA086 mov       rdx,[rsp+20]
       7FFBB04AA08B mov       rax,[r12]
       7FFBB04AA08F mov       rax,[rax+0A8]
       7FFBB04AA096 call      qword ptr [rax+18]
       7FFBB04AA099 test      eax,eax
       7FFBB04AA09B je        short M00_L07
       7FFBB04AA09D jmp       near ptr M00_L03
M00_L11:
       7FFBB04AA0A2 test      rcx,rcx
       7FFBB04AA0A5 je        short M00_L07
       7FFBB04AA0A7 test      rdx,rdx
       7FFBB04AA0AA je        short M00_L07
       7FFBB04AA0AC mov       r8d,[rcx+8]
       7FFBB04AA0B0 cmp       r8d,[rdx+8]
       7FFBB04AA0B4 jne       short M00_L07
       7FFBB04AA0B6 lea       rax,[rcx+0C]
       7FFBB04AA0BA add       rdx,0C
       7FFBB04AA0BE mov       ecx,[rcx+8]
       7FFBB04AA0C1 add       ecx,ecx
       7FFBB04AA0C3 mov       r8d,ecx
       7FFBB04AA0C6 cmp       r8,0A
       7FFBB04AA0CA jne       short M00_L12
       7FFBB04AA0CC mov       rcx,[rax]
       7FFBB04AA0CF mov       rax,[rax+2]
       7FFBB04AA0D3 mov       r8,[rdx]
       7FFBB04AA0D6 xor       rcx,r8
       7FFBB04AA0D9 xor       rax,[rdx+2]
       7FFBB04AA0DD or        rax,rcx
       7FFBB04AA0E0 sete      al
       7FFBB04AA0E3 movzx     eax,al
       7FFBB04AA0E6 jmp       short M00_L13
M00_L12:
       7FFBB04AA0E8 mov       rcx,rax
       7FFBB04AA0EB call      qword ptr [7FFBB043C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04AA0F1 test      eax,eax
       7FFBB04AA0F3 je        near ptr M00_L07
       7FFBB04AA0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB04AA0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB04AA103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04ACD20 test      rdx,rdx
       7FFBB04ACD23 je        short M01_L02
       7FFBB04ACD25 mov       rax,[rdx]
       7FFBB04ACD28 cmp       rax,rcx
       7FFBB04ACD2B je        short M01_L02
       7FFBB04ACD2D mov       rax,[rax+10]
       7FFBB04ACD31 cmp       rax,rcx
       7FFBB04ACD34 je        short M01_L02
M01_L00:
       7FFBB04ACD36 test      rax,rax
       7FFBB04ACD39 je        short M01_L01
       7FFBB04ACD3B mov       rax,[rax+10]
       7FFBB04ACD3F cmp       rax,rcx
       7FFBB04ACD42 je        short M01_L02
       7FFBB04ACD44 test      rax,rax
       7FFBB04ACD47 je        short M01_L01
       7FFBB04ACD49 mov       rax,[rax+10]
       7FFBB04ACD4D cmp       rax,rcx
       7FFBB04ACD50 je        short M01_L02
       7FFBB04ACD52 test      rax,rax
       7FFBB04ACD55 jne       short M01_L03
M01_L01:
       7FFBB04ACD57 xor       edx,edx
M01_L02:
       7FFBB04ACD59 mov       rax,rdx
       7FFBB04ACD5C ret
M01_L03:
       7FFBB04ACD5D mov       rax,[rax+10]
       7FFBB04ACD61 cmp       rax,rcx
       7FFBB04ACD64 je        short M01_L02
       7FFBB04ACD66 test      rax,rax
       7FFBB04ACD69 je        short M01_L01
       7FFBB04ACD6B mov       rax,[rax+10]
       7FFBB04ACD6F cmp       rax,rcx
       7FFBB04ACD72 je        short M01_L02
       7FFBB04ACD74 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Sliced()
       7FFBB0489FA0 push      r15
       7FFBB0489FA2 push      r14
       7FFBB0489FA4 push      r13
       7FFBB0489FA6 push      r12
       7FFBB0489FA8 push      rdi
       7FFBB0489FA9 push      rsi
       7FFBB0489FAA push      rbp
       7FFBB0489FAB push      rbx
       7FFBB0489FAC sub       rsp,28
       7FFBB0489FB0 mov       rdx,[rcx+8]
       7FFBB0489FB4 test      rdx,rdx
       7FFBB0489FB7 je        near ptr M00_L08
       7FFBB0489FBD lea       rbx,[rdx+10]
       7FFBB0489FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB0489FC4 mov       rdx,[rcx+10]
       7FFBB0489FC8 test      rdx,rdx
       7FFBB0489FCB je        short M00_L09
       7FFBB0489FCD lea       rdi,[rdx+10]
       7FFBB0489FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB0489FD4 cmp       esi,ebp
       7FFBB0489FD6 jne       short M00_L07
       7FFBB0489FD8 xor       r14d,r14d
       7FFBB0489FDB cmp       r14d,esi
       7FFBB0489FDE jge       short M00_L05
M00_L02:
       7FFBB0489FE0 mov       r15,r14
       7FFBB0489FE3 shl       r15,4
       7FFBB0489FE7 lea       r13,[rbx+r15]
       7FFBB0489FEB cmp       r14d,ebp
       7FFBB0489FEE jae       near ptr M00_L14
       7FFBB0489FF4 add       r15,rdi
       7FFBB0489FF7 mov       r12,[r13+8]
       7FFBB0489FFB mov       rax,[r15+8]
       7FFBB0489FFF mov       [rsp+20],rax
       7FFBB048A004 cmp       r12,rax
       7FFBB048A007 jne       short M00_L10
M00_L03:
       7FFBB048A009 mov       rcx,[r13]
       7FFBB048A00D mov       rdx,[r15]
       7FFBB048A010 cmp       rcx,rdx
       7FFBB048A013 jne       near ptr M00_L11
M00_L04:
       7FFBB048A019 inc       r14d
       7FFBB048A01C cmp       r14d,esi
       7FFBB048A01F jl        short M00_L02
M00_L05:
       7FFBB048A021 mov       eax,1
M00_L06:
       7FFBB048A026 add       rsp,28
       7FFBB048A02A pop       rbx
       7FFBB048A02B pop       rbp
       7FFBB048A02C pop       rsi
       7FFBB048A02D pop       rdi
       7FFBB048A02E pop       r12
       7FFBB048A030 pop       r13
       7FFBB048A032 pop       r14
       7FFBB048A034 pop       r15
       7FFBB048A036 ret
M00_L07:
       7FFBB048A037 xor       eax,eax
       7FFBB048A039 jmp       short M00_L06
M00_L08:
       7FFBB048A03B xor       ebx,ebx
       7FFBB048A03D xor       esi,esi
       7FFBB048A03F jmp       short M00_L00
M00_L09:
       7FFBB048A041 xor       edi,edi
       7FFBB048A043 xor       ebp,ebp
       7FFBB048A045 jmp       short M00_L01
M00_L10:
       7FFBB048A047 test      r12,r12
       7FFBB048A04A je        short M00_L07
       7FFBB048A04C test      rax,rax
       7FFBB048A04F je        short M00_L07
       7FFBB048A051 mov       rdx,r12
       7FFBB048A054 mov       rcx,offset MT_System.RuntimeType
       7FFBB048A05E call      qword ptr [7FFBB0416850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048A064 test      rax,rax
       7FFBB048A067 jne       short M00_L07
       7FFBB048A069 mov       rdx,[rsp+20]
       7FFBB048A06E mov       rcx,offset MT_System.RuntimeType
       7FFBB048A078 call      qword ptr [7FFBB0416850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048A07E test      rax,rax
       7FFBB048A081 jne       short M00_L07
       7FFBB048A083 mov       rcx,r12
       7FFBB048A086 mov       rdx,[rsp+20]
       7FFBB048A08B mov       rax,[r12]
       7FFBB048A08F mov       rax,[rax+0A8]
       7FFBB048A096 call      qword ptr [rax+18]
       7FFBB048A099 test      eax,eax
       7FFBB048A09B je        short M00_L07
       7FFBB048A09D jmp       near ptr M00_L03
M00_L11:
       7FFBB048A0A2 test      rcx,rcx
       7FFBB048A0A5 je        short M00_L07
       7FFBB048A0A7 test      rdx,rdx
       7FFBB048A0AA je        short M00_L07
       7FFBB048A0AC mov       r8d,[rcx+8]
       7FFBB048A0B0 cmp       r8d,[rdx+8]
       7FFBB048A0B4 jne       short M00_L07
       7FFBB048A0B6 lea       rax,[rcx+0C]
       7FFBB048A0BA add       rdx,0C
       7FFBB048A0BE mov       ecx,[rcx+8]
       7FFBB048A0C1 add       ecx,ecx
       7FFBB048A0C3 mov       r8d,ecx
       7FFBB048A0C6 cmp       r8,0A
       7FFBB048A0CA jne       short M00_L12
       7FFBB048A0CC mov       rcx,[rax]
       7FFBB048A0CF mov       rax,[rax+2]
       7FFBB048A0D3 mov       r8,[rdx]
       7FFBB048A0D6 xor       rcx,r8
       7FFBB048A0D9 xor       rax,[rdx+2]
       7FFBB048A0DD or        rax,rcx
       7FFBB048A0E0 sete      al
       7FFBB048A0E3 movzx     eax,al
       7FFBB048A0E6 jmp       short M00_L13
M00_L12:
       7FFBB048A0E8 mov       rcx,rax
       7FFBB048A0EB call      qword ptr [7FFBB041C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB048A0F1 test      eax,eax
       7FFBB048A0F3 je        near ptr M00_L07
       7FFBB048A0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB048A0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB048A103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB048CD40 test      rdx,rdx
       7FFBB048CD43 je        short M01_L02
       7FFBB048CD45 mov       rax,[rdx]
       7FFBB048CD48 cmp       rax,rcx
       7FFBB048CD4B je        short M01_L02
       7FFBB048CD4D mov       rax,[rax+10]
       7FFBB048CD51 cmp       rax,rcx
       7FFBB048CD54 je        short M01_L02
M01_L00:
       7FFBB048CD56 test      rax,rax
       7FFBB048CD59 je        short M01_L01
       7FFBB048CD5B mov       rax,[rax+10]
       7FFBB048CD5F cmp       rax,rcx
       7FFBB048CD62 je        short M01_L02
       7FFBB048CD64 test      rax,rax
       7FFBB048CD67 je        short M01_L01
       7FFBB048CD69 mov       rax,[rax+10]
       7FFBB048CD6D cmp       rax,rcx
       7FFBB048CD70 je        short M01_L02
       7FFBB048CD72 test      rax,rax
       7FFBB048CD75 jne       short M01_L03
M01_L01:
       7FFBB048CD77 xor       edx,edx
M01_L02:
       7FFBB048CD79 mov       rax,rdx
       7FFBB048CD7C ret
M01_L03:
       7FFBB048CD7D mov       rax,[rax+10]
       7FFBB048CD81 cmp       rax,rcx
       7FFBB048CD84 je        short M01_L02
       7FFBB048CD86 test      rax,rax
       7FFBB048CD89 je        short M01_L01
       7FFBB048CD8B mov       rax,[rax+10]
       7FFBB048CD8F cmp       rax,rcx
       7FFBB048CD92 je        short M01_L02
       7FFBB048CD94 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.GetRef()
       7FFBB04C9FA0 push      r15
       7FFBB04C9FA2 push      r14
       7FFBB04C9FA4 push      r13
       7FFBB04C9FA6 push      r12
       7FFBB04C9FA8 push      rdi
       7FFBB04C9FA9 push      rsi
       7FFBB04C9FAA push      rbp
       7FFBB04C9FAB push      rbx
       7FFBB04C9FAC sub       rsp,28
       7FFBB04C9FB0 mov       rdx,[rcx+8]
       7FFBB04C9FB4 test      rdx,rdx
       7FFBB04C9FB7 je        short M00_L08
       7FFBB04C9FB9 lea       rbx,[rdx+10]
       7FFBB04C9FBD mov       esi,[rdx+8]
M00_L00:
       7FFBB04C9FC0 mov       rdx,[rcx+10]
       7FFBB04C9FC4 test      rdx,rdx
       7FFBB04C9FC7 je        short M00_L09
       7FFBB04C9FC9 lea       rdi,[rdx+10]
       7FFBB04C9FCD mov       edx,[rdx+8]
M00_L01:
       7FFBB04C9FD0 cmp       esi,edx
       7FFBB04C9FD2 jne       short M00_L07
       7FFBB04C9FD4 xor       ebp,ebp
       7FFBB04C9FD6 cmp       ebp,esi
       7FFBB04C9FD8 jge       short M00_L05
M00_L02:
       7FFBB04C9FDA movsxd    r14,ebp
       7FFBB04C9FDD shl       r14,4
       7FFBB04C9FE1 lea       r15,[rbx+r14]
       7FFBB04C9FE5 add       r14,rdi
       7FFBB04C9FE8 mov       r13,[r15+8]
       7FFBB04C9FEC mov       r12,[r14+8]
       7FFBB04C9FF0 cmp       r13,r12
       7FFBB04C9FF3 jne       short M00_L10
M00_L03:
       7FFBB04C9FF5 mov       rcx,[r15]
       7FFBB04C9FF8 mov       rdx,[r14]
       7FFBB04C9FFB cmp       rcx,rdx
       7FFBB04C9FFE jne       near ptr M00_L11
M00_L04:
       7FFBB04CA004 inc       ebp
       7FFBB04CA006 cmp       ebp,esi
       7FFBB04CA008 jl        short M00_L02
M00_L05:
       7FFBB04CA00A mov       eax,1
M00_L06:
       7FFBB04CA00F add       rsp,28
       7FFBB04CA013 pop       rbx
       7FFBB04CA014 pop       rbp
       7FFBB04CA015 pop       rsi
       7FFBB04CA016 pop       rdi
       7FFBB04CA017 pop       r12
       7FFBB04CA019 pop       r13
       7FFBB04CA01B pop       r14
       7FFBB04CA01D pop       r15
       7FFBB04CA01F ret
M00_L07:
       7FFBB04CA020 xor       eax,eax
       7FFBB04CA022 jmp       short M00_L06
M00_L08:
       7FFBB04CA024 xor       ebx,ebx
       7FFBB04CA026 xor       esi,esi
       7FFBB04CA028 jmp       short M00_L00
M00_L09:
       7FFBB04CA02A xor       edi,edi
       7FFBB04CA02C xor       edx,edx
       7FFBB04CA02E jmp       short M00_L01
M00_L10:
       7FFBB04CA030 test      r13,r13
       7FFBB04CA033 je        short M00_L07
       7FFBB04CA035 test      r12,r12
       7FFBB04CA038 je        short M00_L07
       7FFBB04CA03A mov       rdx,r13
       7FFBB04CA03D mov       rcx,offset MT_System.RuntimeType
       7FFBB04CA047 call      qword ptr [7FFBB0456850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04CA04D test      rax,rax
       7FFBB04CA050 jne       short M00_L07
       7FFBB04CA052 mov       rdx,r12
       7FFBB04CA055 mov       rcx,offset MT_System.RuntimeType
       7FFBB04CA05F call      qword ptr [7FFBB0456850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04CA065 test      rax,rax
       7FFBB04CA068 jne       short M00_L07
       7FFBB04CA06A mov       rcx,r13
       7FFBB04CA06D mov       rdx,r12
       7FFBB04CA070 mov       rax,[r13]
       7FFBB04CA074 mov       rax,[rax+0A8]
       7FFBB04CA07B call      qword ptr [rax+18]
       7FFBB04CA07E test      eax,eax
       7FFBB04CA080 je        short M00_L07
       7FFBB04CA082 jmp       near ptr M00_L03
M00_L11:
       7FFBB04CA087 test      rcx,rcx
       7FFBB04CA08A je        short M00_L07
       7FFBB04CA08C test      rdx,rdx
       7FFBB04CA08F je        short M00_L07
       7FFBB04CA091 mov       r8d,[rcx+8]
       7FFBB04CA095 cmp       r8d,[rdx+8]
       7FFBB04CA099 jne       short M00_L07
       7FFBB04CA09B lea       rax,[rcx+0C]
       7FFBB04CA09F add       rdx,0C
       7FFBB04CA0A3 mov       ecx,[rcx+8]
       7FFBB04CA0A6 add       ecx,ecx
       7FFBB04CA0A8 mov       r8d,ecx
       7FFBB04CA0AB cmp       r8,0A
       7FFBB04CA0AF jne       short M00_L12
       7FFBB04CA0B1 mov       rcx,[rax]
       7FFBB04CA0B4 mov       rax,[rax+2]
       7FFBB04CA0B8 mov       r8,[rdx]
       7FFBB04CA0BB xor       rcx,r8
       7FFBB04CA0BE xor       rax,[rdx+2]
       7FFBB04CA0C2 or        rax,rcx
       7FFBB04CA0C5 sete      al
       7FFBB04CA0C8 movzx     eax,al
       7FFBB04CA0CB jmp       short M00_L13
M00_L12:
       7FFBB04CA0CD mov       rcx,rax
       7FFBB04CA0D0 call      qword ptr [7FFBB045C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04CA0D6 test      eax,eax
       7FFBB04CA0D8 je        near ptr M00_L07
       7FFBB04CA0DE jmp       near ptr M00_L04
; Total bytes of code 323
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04CCA80 test      rdx,rdx
       7FFBB04CCA83 je        short M01_L02
       7FFBB04CCA85 mov       rax,[rdx]
       7FFBB04CCA88 cmp       rax,rcx
       7FFBB04CCA8B je        short M01_L02
       7FFBB04CCA8D mov       rax,[rax+10]
       7FFBB04CCA91 cmp       rax,rcx
       7FFBB04CCA94 je        short M01_L02
M01_L00:
       7FFBB04CCA96 test      rax,rax
       7FFBB04CCA99 je        short M01_L01
       7FFBB04CCA9B mov       rax,[rax+10]
       7FFBB04CCA9F cmp       rax,rcx
       7FFBB04CCAA2 je        short M01_L02
       7FFBB04CCAA4 test      rax,rax
       7FFBB04CCAA7 je        short M01_L01
       7FFBB04CCAA9 mov       rax,[rax+10]
       7FFBB04CCAAD cmp       rax,rcx
       7FFBB04CCAB0 je        short M01_L02
       7FFBB04CCAB2 test      rax,rax
       7FFBB04CCAB5 jne       short M01_L03
M01_L01:
       7FFBB04CCAB7 xor       edx,edx
M01_L02:
       7FFBB04CCAB9 mov       rax,rdx
       7FFBB04CCABC ret
M01_L03:
       7FFBB04CCABD mov       rax,[rax+10]
       7FFBB04CCAC1 cmp       rax,rcx
       7FFBB04CCAC4 je        short M01_L02
       7FFBB04CCAC6 test      rax,rax
       7FFBB04CCAC9 je        short M01_L01
       7FFBB04CCACB mov       rax,[rax+10]
       7FFBB04CCACF cmp       rax,rcx
       7FFBB04CCAD2 je        short M01_L02
       7FFBB04CCAD4 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Indexer()
       7FFBB0499FA0 push      r15
       7FFBB0499FA2 push      r14
       7FFBB0499FA4 push      r13
       7FFBB0499FA6 push      r12
       7FFBB0499FA8 push      rdi
       7FFBB0499FA9 push      rsi
       7FFBB0499FAA push      rbp
       7FFBB0499FAB push      rbx
       7FFBB0499FAC sub       rsp,28
       7FFBB0499FB0 mov       rdx,[rcx+8]
       7FFBB0499FB4 test      rdx,rdx
       7FFBB0499FB7 je        near ptr M00_L08
       7FFBB0499FBD lea       rbx,[rdx+10]
       7FFBB0499FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB0499FC4 mov       rdx,[rcx+10]
       7FFBB0499FC8 test      rdx,rdx
       7FFBB0499FCB je        short M00_L09
       7FFBB0499FCD lea       rdi,[rdx+10]
       7FFBB0499FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB0499FD4 cmp       esi,ebp
       7FFBB0499FD6 jne       short M00_L07
       7FFBB0499FD8 xor       r14d,r14d
       7FFBB0499FDB cmp       r14d,esi
       7FFBB0499FDE jge       short M00_L05
M00_L02:
       7FFBB0499FE0 mov       r15,r14
       7FFBB0499FE3 shl       r15,4
       7FFBB0499FE7 lea       r13,[rbx+r15]
       7FFBB0499FEB cmp       r14d,ebp
       7FFBB0499FEE jae       near ptr M00_L14
       7FFBB0499FF4 add       r15,rdi
       7FFBB0499FF7 mov       r12,[r13+8]
       7FFBB0499FFB mov       rax,[r15+8]
       7FFBB0499FFF mov       [rsp+20],rax
       7FFBB049A004 cmp       r12,rax
       7FFBB049A007 jne       short M00_L10
M00_L03:
       7FFBB049A009 mov       rcx,[r13]
       7FFBB049A00D mov       rdx,[r15]
       7FFBB049A010 cmp       rcx,rdx
       7FFBB049A013 jne       near ptr M00_L11
M00_L04:
       7FFBB049A019 inc       r14d
       7FFBB049A01C cmp       r14d,esi
       7FFBB049A01F jl        short M00_L02
M00_L05:
       7FFBB049A021 mov       eax,1
M00_L06:
       7FFBB049A026 add       rsp,28
       7FFBB049A02A pop       rbx
       7FFBB049A02B pop       rbp
       7FFBB049A02C pop       rsi
       7FFBB049A02D pop       rdi
       7FFBB049A02E pop       r12
       7FFBB049A030 pop       r13
       7FFBB049A032 pop       r14
       7FFBB049A034 pop       r15
       7FFBB049A036 ret
M00_L07:
       7FFBB049A037 xor       eax,eax
       7FFBB049A039 jmp       short M00_L06
M00_L08:
       7FFBB049A03B xor       ebx,ebx
       7FFBB049A03D xor       esi,esi
       7FFBB049A03F jmp       short M00_L00
M00_L09:
       7FFBB049A041 xor       edi,edi
       7FFBB049A043 xor       ebp,ebp
       7FFBB049A045 jmp       short M00_L01
M00_L10:
       7FFBB049A047 test      r12,r12
       7FFBB049A04A je        short M00_L07
       7FFBB049A04C test      rax,rax
       7FFBB049A04F je        short M00_L07
       7FFBB049A051 mov       rdx,r12
       7FFBB049A054 mov       rcx,offset MT_System.RuntimeType
       7FFBB049A05E call      qword ptr [7FFBB0426850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB049A064 test      rax,rax
       7FFBB049A067 jne       short M00_L07
       7FFBB049A069 mov       rdx,[rsp+20]
       7FFBB049A06E mov       rcx,offset MT_System.RuntimeType
       7FFBB049A078 call      qword ptr [7FFBB0426850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB049A07E test      rax,rax
       7FFBB049A081 jne       short M00_L07
       7FFBB049A083 mov       rcx,r12
       7FFBB049A086 mov       rdx,[rsp+20]
       7FFBB049A08B mov       rax,[r12]
       7FFBB049A08F mov       rax,[rax+0A8]
       7FFBB049A096 call      qword ptr [rax+18]
       7FFBB049A099 test      eax,eax
       7FFBB049A09B je        short M00_L07
       7FFBB049A09D jmp       near ptr M00_L03
M00_L11:
       7FFBB049A0A2 test      rcx,rcx
       7FFBB049A0A5 je        short M00_L07
       7FFBB049A0A7 test      rdx,rdx
       7FFBB049A0AA je        short M00_L07
       7FFBB049A0AC mov       r8d,[rcx+8]
       7FFBB049A0B0 cmp       r8d,[rdx+8]
       7FFBB049A0B4 jne       short M00_L07
       7FFBB049A0B6 lea       rax,[rcx+0C]
       7FFBB049A0BA add       rdx,0C
       7FFBB049A0BE mov       ecx,[rcx+8]
       7FFBB049A0C1 add       ecx,ecx
       7FFBB049A0C3 mov       r8d,ecx
       7FFBB049A0C6 cmp       r8,0A
       7FFBB049A0CA jne       short M00_L12
       7FFBB049A0CC mov       rcx,[rax]
       7FFBB049A0CF mov       rax,[rax+2]
       7FFBB049A0D3 mov       r8,[rdx]
       7FFBB049A0D6 xor       rcx,r8
       7FFBB049A0D9 xor       rax,[rdx+2]
       7FFBB049A0DD or        rax,rcx
       7FFBB049A0E0 sete      al
       7FFBB049A0E3 movzx     eax,al
       7FFBB049A0E6 jmp       short M00_L13
M00_L12:
       7FFBB049A0E8 mov       rcx,rax
       7FFBB049A0EB call      qword ptr [7FFBB042C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB049A0F1 test      eax,eax
       7FFBB049A0F3 je        near ptr M00_L07
       7FFBB049A0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB049A0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB049A103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB049CD40 test      rdx,rdx
       7FFBB049CD43 je        short M01_L02
       7FFBB049CD45 mov       rax,[rdx]
       7FFBB049CD48 cmp       rax,rcx
       7FFBB049CD4B je        short M01_L02
       7FFBB049CD4D mov       rax,[rax+10]
       7FFBB049CD51 cmp       rax,rcx
       7FFBB049CD54 je        short M01_L02
M01_L00:
       7FFBB049CD56 test      rax,rax
       7FFBB049CD59 je        short M01_L01
       7FFBB049CD5B mov       rax,[rax+10]
       7FFBB049CD5F cmp       rax,rcx
       7FFBB049CD62 je        short M01_L02
       7FFBB049CD64 test      rax,rax
       7FFBB049CD67 je        short M01_L01
       7FFBB049CD69 mov       rax,[rax+10]
       7FFBB049CD6D cmp       rax,rcx
       7FFBB049CD70 je        short M01_L02
       7FFBB049CD72 test      rax,rax
       7FFBB049CD75 jne       short M01_L03
M01_L01:
       7FFBB049CD77 xor       edx,edx
M01_L02:
       7FFBB049CD79 mov       rax,rdx
       7FFBB049CD7C ret
M01_L03:
       7FFBB049CD7D mov       rax,[rax+10]
       7FFBB049CD81 cmp       rax,rcx
       7FFBB049CD84 je        short M01_L02
       7FFBB049CD86 test      rax,rax
       7FFBB049CD89 je        short M01_L01
       7FFBB049CD8B mov       rax,[rax+10]
       7FFBB049CD8F cmp       rax,rcx
       7FFBB049CD92 je        short M01_L02
       7FFBB049CD94 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Sliced()
       7FFBB04B9FA0 push      r15
       7FFBB04B9FA2 push      r14
       7FFBB04B9FA4 push      r13
       7FFBB04B9FA6 push      r12
       7FFBB04B9FA8 push      rdi
       7FFBB04B9FA9 push      rsi
       7FFBB04B9FAA push      rbp
       7FFBB04B9FAB push      rbx
       7FFBB04B9FAC sub       rsp,28
       7FFBB04B9FB0 mov       rdx,[rcx+8]
       7FFBB04B9FB4 test      rdx,rdx
       7FFBB04B9FB7 je        near ptr M00_L08
       7FFBB04B9FBD lea       rbx,[rdx+10]
       7FFBB04B9FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB04B9FC4 mov       rdx,[rcx+10]
       7FFBB04B9FC8 test      rdx,rdx
       7FFBB04B9FCB je        short M00_L09
       7FFBB04B9FCD lea       rdi,[rdx+10]
       7FFBB04B9FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB04B9FD4 cmp       esi,ebp
       7FFBB04B9FD6 jne       short M00_L07
       7FFBB04B9FD8 xor       r14d,r14d
       7FFBB04B9FDB cmp       r14d,esi
       7FFBB04B9FDE jge       short M00_L05
M00_L02:
       7FFBB04B9FE0 mov       r15,r14
       7FFBB04B9FE3 shl       r15,4
       7FFBB04B9FE7 lea       r13,[rbx+r15]
       7FFBB04B9FEB cmp       r14d,ebp
       7FFBB04B9FEE jae       near ptr M00_L14
       7FFBB04B9FF4 add       r15,rdi
       7FFBB04B9FF7 mov       r12,[r13+8]
       7FFBB04B9FFB mov       rax,[r15+8]
       7FFBB04B9FFF mov       [rsp+20],rax
       7FFBB04BA004 cmp       r12,rax
       7FFBB04BA007 jne       short M00_L10
M00_L03:
       7FFBB04BA009 mov       rcx,[r13]
       7FFBB04BA00D mov       rdx,[r15]
       7FFBB04BA010 cmp       rcx,rdx
       7FFBB04BA013 jne       near ptr M00_L11
M00_L04:
       7FFBB04BA019 inc       r14d
       7FFBB04BA01C cmp       r14d,esi
       7FFBB04BA01F jl        short M00_L02
M00_L05:
       7FFBB04BA021 mov       eax,1
M00_L06:
       7FFBB04BA026 add       rsp,28
       7FFBB04BA02A pop       rbx
       7FFBB04BA02B pop       rbp
       7FFBB04BA02C pop       rsi
       7FFBB04BA02D pop       rdi
       7FFBB04BA02E pop       r12
       7FFBB04BA030 pop       r13
       7FFBB04BA032 pop       r14
       7FFBB04BA034 pop       r15
       7FFBB04BA036 ret
M00_L07:
       7FFBB04BA037 xor       eax,eax
       7FFBB04BA039 jmp       short M00_L06
M00_L08:
       7FFBB04BA03B xor       ebx,ebx
       7FFBB04BA03D xor       esi,esi
       7FFBB04BA03F jmp       short M00_L00
M00_L09:
       7FFBB04BA041 xor       edi,edi
       7FFBB04BA043 xor       ebp,ebp
       7FFBB04BA045 jmp       short M00_L01
M00_L10:
       7FFBB04BA047 test      r12,r12
       7FFBB04BA04A je        short M00_L07
       7FFBB04BA04C test      rax,rax
       7FFBB04BA04F je        short M00_L07
       7FFBB04BA051 mov       rdx,r12
       7FFBB04BA054 mov       rcx,offset MT_System.RuntimeType
       7FFBB04BA05E call      qword ptr [7FFBB0446850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04BA064 test      rax,rax
       7FFBB04BA067 jne       short M00_L07
       7FFBB04BA069 mov       rdx,[rsp+20]
       7FFBB04BA06E mov       rcx,offset MT_System.RuntimeType
       7FFBB04BA078 call      qword ptr [7FFBB0446850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04BA07E test      rax,rax
       7FFBB04BA081 jne       short M00_L07
       7FFBB04BA083 mov       rcx,r12
       7FFBB04BA086 mov       rdx,[rsp+20]
       7FFBB04BA08B mov       rax,[r12]
       7FFBB04BA08F mov       rax,[rax+0A8]
       7FFBB04BA096 call      qword ptr [rax+18]
       7FFBB04BA099 test      eax,eax
       7FFBB04BA09B je        short M00_L07
       7FFBB04BA09D jmp       near ptr M00_L03
M00_L11:
       7FFBB04BA0A2 test      rcx,rcx
       7FFBB04BA0A5 je        short M00_L07
       7FFBB04BA0A7 test      rdx,rdx
       7FFBB04BA0AA je        short M00_L07
       7FFBB04BA0AC mov       r8d,[rcx+8]
       7FFBB04BA0B0 cmp       r8d,[rdx+8]
       7FFBB04BA0B4 jne       short M00_L07
       7FFBB04BA0B6 lea       rax,[rcx+0C]
       7FFBB04BA0BA add       rdx,0C
       7FFBB04BA0BE mov       ecx,[rcx+8]
       7FFBB04BA0C1 add       ecx,ecx
       7FFBB04BA0C3 mov       r8d,ecx
       7FFBB04BA0C6 cmp       r8,0A
       7FFBB04BA0CA jne       short M00_L12
       7FFBB04BA0CC mov       rcx,[rax]
       7FFBB04BA0CF mov       rax,[rax+2]
       7FFBB04BA0D3 mov       r8,[rdx]
       7FFBB04BA0D6 xor       rcx,r8
       7FFBB04BA0D9 xor       rax,[rdx+2]
       7FFBB04BA0DD or        rax,rcx
       7FFBB04BA0E0 sete      al
       7FFBB04BA0E3 movzx     eax,al
       7FFBB04BA0E6 jmp       short M00_L13
M00_L12:
       7FFBB04BA0E8 mov       rcx,rax
       7FFBB04BA0EB call      qword ptr [7FFBB044C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04BA0F1 test      eax,eax
       7FFBB04BA0F3 je        near ptr M00_L07
       7FFBB04BA0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB04BA0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB04BA103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04BCD40 test      rdx,rdx
       7FFBB04BCD43 je        short M01_L02
       7FFBB04BCD45 mov       rax,[rdx]
       7FFBB04BCD48 cmp       rax,rcx
       7FFBB04BCD4B je        short M01_L02
       7FFBB04BCD4D mov       rax,[rax+10]
       7FFBB04BCD51 cmp       rax,rcx
       7FFBB04BCD54 je        short M01_L02
M01_L00:
       7FFBB04BCD56 test      rax,rax
       7FFBB04BCD59 je        short M01_L01
       7FFBB04BCD5B mov       rax,[rax+10]
       7FFBB04BCD5F cmp       rax,rcx
       7FFBB04BCD62 je        short M01_L02
       7FFBB04BCD64 test      rax,rax
       7FFBB04BCD67 je        short M01_L01
       7FFBB04BCD69 mov       rax,[rax+10]
       7FFBB04BCD6D cmp       rax,rcx
       7FFBB04BCD70 je        short M01_L02
       7FFBB04BCD72 test      rax,rax
       7FFBB04BCD75 jne       short M01_L03
M01_L01:
       7FFBB04BCD77 xor       edx,edx
M01_L02:
       7FFBB04BCD79 mov       rax,rdx
       7FFBB04BCD7C ret
M01_L03:
       7FFBB04BCD7D mov       rax,[rax+10]
       7FFBB04BCD81 cmp       rax,rcx
       7FFBB04BCD84 je        short M01_L02
       7FFBB04BCD86 test      rax,rax
       7FFBB04BCD89 je        short M01_L01
       7FFBB04BCD8B mov       rax,[rax+10]
       7FFBB04BCD8F cmp       rax,rcx
       7FFBB04BCD92 je        short M01_L02
       7FFBB04BCD94 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.GetRef()
       7FFBB04C9FA0 push      r15
       7FFBB04C9FA2 push      r14
       7FFBB04C9FA4 push      r13
       7FFBB04C9FA6 push      r12
       7FFBB04C9FA8 push      rdi
       7FFBB04C9FA9 push      rsi
       7FFBB04C9FAA push      rbp
       7FFBB04C9FAB push      rbx
       7FFBB04C9FAC sub       rsp,28
       7FFBB04C9FB0 mov       rdx,[rcx+8]
       7FFBB04C9FB4 test      rdx,rdx
       7FFBB04C9FB7 je        short M00_L08
       7FFBB04C9FB9 lea       rbx,[rdx+10]
       7FFBB04C9FBD mov       esi,[rdx+8]
M00_L00:
       7FFBB04C9FC0 mov       rdx,[rcx+10]
       7FFBB04C9FC4 test      rdx,rdx
       7FFBB04C9FC7 je        short M00_L09
       7FFBB04C9FC9 lea       rdi,[rdx+10]
       7FFBB04C9FCD mov       edx,[rdx+8]
M00_L01:
       7FFBB04C9FD0 cmp       esi,edx
       7FFBB04C9FD2 jne       short M00_L07
       7FFBB04C9FD4 xor       ebp,ebp
       7FFBB04C9FD6 cmp       ebp,esi
       7FFBB04C9FD8 jge       short M00_L05
M00_L02:
       7FFBB04C9FDA movsxd    r14,ebp
       7FFBB04C9FDD shl       r14,4
       7FFBB04C9FE1 lea       r15,[rbx+r14]
       7FFBB04C9FE5 add       r14,rdi
       7FFBB04C9FE8 mov       r13,[r15+8]
       7FFBB04C9FEC mov       r12,[r14+8]
       7FFBB04C9FF0 cmp       r13,r12
       7FFBB04C9FF3 jne       short M00_L10
M00_L03:
       7FFBB04C9FF5 mov       rcx,[r15]
       7FFBB04C9FF8 mov       rdx,[r14]
       7FFBB04C9FFB cmp       rcx,rdx
       7FFBB04C9FFE jne       near ptr M00_L11
M00_L04:
       7FFBB04CA004 inc       ebp
       7FFBB04CA006 cmp       ebp,esi
       7FFBB04CA008 jl        short M00_L02
M00_L05:
       7FFBB04CA00A mov       eax,1
M00_L06:
       7FFBB04CA00F add       rsp,28
       7FFBB04CA013 pop       rbx
       7FFBB04CA014 pop       rbp
       7FFBB04CA015 pop       rsi
       7FFBB04CA016 pop       rdi
       7FFBB04CA017 pop       r12
       7FFBB04CA019 pop       r13
       7FFBB04CA01B pop       r14
       7FFBB04CA01D pop       r15
       7FFBB04CA01F ret
M00_L07:
       7FFBB04CA020 xor       eax,eax
       7FFBB04CA022 jmp       short M00_L06
M00_L08:
       7FFBB04CA024 xor       ebx,ebx
       7FFBB04CA026 xor       esi,esi
       7FFBB04CA028 jmp       short M00_L00
M00_L09:
       7FFBB04CA02A xor       edi,edi
       7FFBB04CA02C xor       edx,edx
       7FFBB04CA02E jmp       short M00_L01
M00_L10:
       7FFBB04CA030 test      r13,r13
       7FFBB04CA033 je        short M00_L07
       7FFBB04CA035 test      r12,r12
       7FFBB04CA038 je        short M00_L07
       7FFBB04CA03A mov       rdx,r13
       7FFBB04CA03D mov       rcx,offset MT_System.RuntimeType
       7FFBB04CA047 call      qword ptr [7FFBB0456850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04CA04D test      rax,rax
       7FFBB04CA050 jne       short M00_L07
       7FFBB04CA052 mov       rdx,r12
       7FFBB04CA055 mov       rcx,offset MT_System.RuntimeType
       7FFBB04CA05F call      qword ptr [7FFBB0456850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04CA065 test      rax,rax
       7FFBB04CA068 jne       short M00_L07
       7FFBB04CA06A mov       rcx,r13
       7FFBB04CA06D mov       rdx,r12
       7FFBB04CA070 mov       rax,[r13]
       7FFBB04CA074 mov       rax,[rax+0A8]
       7FFBB04CA07B call      qword ptr [rax+18]
       7FFBB04CA07E test      eax,eax
       7FFBB04CA080 je        short M00_L07
       7FFBB04CA082 jmp       near ptr M00_L03
M00_L11:
       7FFBB04CA087 test      rcx,rcx
       7FFBB04CA08A je        short M00_L07
       7FFBB04CA08C test      rdx,rdx
       7FFBB04CA08F je        short M00_L07
       7FFBB04CA091 mov       r8d,[rcx+8]
       7FFBB04CA095 cmp       r8d,[rdx+8]
       7FFBB04CA099 jne       short M00_L07
       7FFBB04CA09B lea       rax,[rcx+0C]
       7FFBB04CA09F add       rdx,0C
       7FFBB04CA0A3 mov       ecx,[rcx+8]
       7FFBB04CA0A6 add       ecx,ecx
       7FFBB04CA0A8 mov       r8d,ecx
       7FFBB04CA0AB cmp       r8,0A
       7FFBB04CA0AF jne       short M00_L12
       7FFBB04CA0B1 mov       rcx,[rax]
       7FFBB04CA0B4 mov       rax,[rax+2]
       7FFBB04CA0B8 mov       r8,[rdx]
       7FFBB04CA0BB xor       rcx,r8
       7FFBB04CA0BE xor       rax,[rdx+2]
       7FFBB04CA0C2 or        rax,rcx
       7FFBB04CA0C5 sete      al
       7FFBB04CA0C8 movzx     eax,al
       7FFBB04CA0CB jmp       short M00_L13
M00_L12:
       7FFBB04CA0CD mov       rcx,rax
       7FFBB04CA0D0 call      qword ptr [7FFBB045C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04CA0D6 test      eax,eax
       7FFBB04CA0D8 je        near ptr M00_L07
       7FFBB04CA0DE jmp       near ptr M00_L04
; Total bytes of code 323
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04CCC20 test      rdx,rdx
       7FFBB04CCC23 je        short M01_L02
       7FFBB04CCC25 mov       rax,[rdx]
       7FFBB04CCC28 cmp       rax,rcx
       7FFBB04CCC2B je        short M01_L02
       7FFBB04CCC2D mov       rax,[rax+10]
       7FFBB04CCC31 cmp       rax,rcx
       7FFBB04CCC34 je        short M01_L02
M01_L00:
       7FFBB04CCC36 test      rax,rax
       7FFBB04CCC39 je        short M01_L01
       7FFBB04CCC3B mov       rax,[rax+10]
       7FFBB04CCC3F cmp       rax,rcx
       7FFBB04CCC42 je        short M01_L02
       7FFBB04CCC44 test      rax,rax
       7FFBB04CCC47 je        short M01_L01
       7FFBB04CCC49 mov       rax,[rax+10]
       7FFBB04CCC4D cmp       rax,rcx
       7FFBB04CCC50 je        short M01_L02
       7FFBB04CCC52 test      rax,rax
       7FFBB04CCC55 jne       short M01_L03
M01_L01:
       7FFBB04CCC57 xor       edx,edx
M01_L02:
       7FFBB04CCC59 mov       rax,rdx
       7FFBB04CCC5C ret
M01_L03:
       7FFBB04CCC5D mov       rax,[rax+10]
       7FFBB04CCC61 cmp       rax,rcx
       7FFBB04CCC64 je        short M01_L02
       7FFBB04CCC66 test      rax,rax
       7FFBB04CCC69 je        short M01_L01
       7FFBB04CCC6B mov       rax,[rax+10]
       7FFBB04CCC6F cmp       rax,rcx
       7FFBB04CCC72 je        short M01_L02
       7FFBB04CCC74 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Indexer()
       7FFBB04B9FA0 push      r15
       7FFBB04B9FA2 push      r14
       7FFBB04B9FA4 push      r13
       7FFBB04B9FA6 push      r12
       7FFBB04B9FA8 push      rdi
       7FFBB04B9FA9 push      rsi
       7FFBB04B9FAA push      rbp
       7FFBB04B9FAB push      rbx
       7FFBB04B9FAC sub       rsp,28
       7FFBB04B9FB0 mov       rdx,[rcx+8]
       7FFBB04B9FB4 test      rdx,rdx
       7FFBB04B9FB7 je        near ptr M00_L08
       7FFBB04B9FBD lea       rbx,[rdx+10]
       7FFBB04B9FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB04B9FC4 mov       rdx,[rcx+10]
       7FFBB04B9FC8 test      rdx,rdx
       7FFBB04B9FCB je        short M00_L09
       7FFBB04B9FCD lea       rdi,[rdx+10]
       7FFBB04B9FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB04B9FD4 cmp       esi,ebp
       7FFBB04B9FD6 jne       short M00_L07
       7FFBB04B9FD8 xor       r14d,r14d
       7FFBB04B9FDB cmp       r14d,esi
       7FFBB04B9FDE jge       short M00_L05
M00_L02:
       7FFBB04B9FE0 mov       r15,r14
       7FFBB04B9FE3 shl       r15,4
       7FFBB04B9FE7 lea       r13,[rbx+r15]
       7FFBB04B9FEB cmp       r14d,ebp
       7FFBB04B9FEE jae       near ptr M00_L14
       7FFBB04B9FF4 add       r15,rdi
       7FFBB04B9FF7 mov       r12,[r13+8]
       7FFBB04B9FFB mov       rax,[r15+8]
       7FFBB04B9FFF mov       [rsp+20],rax
       7FFBB04BA004 cmp       r12,rax
       7FFBB04BA007 jne       short M00_L10
M00_L03:
       7FFBB04BA009 mov       rcx,[r13]
       7FFBB04BA00D mov       rdx,[r15]
       7FFBB04BA010 cmp       rcx,rdx
       7FFBB04BA013 jne       near ptr M00_L11
M00_L04:
       7FFBB04BA019 inc       r14d
       7FFBB04BA01C cmp       r14d,esi
       7FFBB04BA01F jl        short M00_L02
M00_L05:
       7FFBB04BA021 mov       eax,1
M00_L06:
       7FFBB04BA026 add       rsp,28
       7FFBB04BA02A pop       rbx
       7FFBB04BA02B pop       rbp
       7FFBB04BA02C pop       rsi
       7FFBB04BA02D pop       rdi
       7FFBB04BA02E pop       r12
       7FFBB04BA030 pop       r13
       7FFBB04BA032 pop       r14
       7FFBB04BA034 pop       r15
       7FFBB04BA036 ret
M00_L07:
       7FFBB04BA037 xor       eax,eax
       7FFBB04BA039 jmp       short M00_L06
M00_L08:
       7FFBB04BA03B xor       ebx,ebx
       7FFBB04BA03D xor       esi,esi
       7FFBB04BA03F jmp       short M00_L00
M00_L09:
       7FFBB04BA041 xor       edi,edi
       7FFBB04BA043 xor       ebp,ebp
       7FFBB04BA045 jmp       short M00_L01
M00_L10:
       7FFBB04BA047 test      r12,r12
       7FFBB04BA04A je        short M00_L07
       7FFBB04BA04C test      rax,rax
       7FFBB04BA04F je        short M00_L07
       7FFBB04BA051 mov       rdx,r12
       7FFBB04BA054 mov       rcx,offset MT_System.RuntimeType
       7FFBB04BA05E call      qword ptr [7FFBB0446850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04BA064 test      rax,rax
       7FFBB04BA067 jne       short M00_L07
       7FFBB04BA069 mov       rdx,[rsp+20]
       7FFBB04BA06E mov       rcx,offset MT_System.RuntimeType
       7FFBB04BA078 call      qword ptr [7FFBB0446850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04BA07E test      rax,rax
       7FFBB04BA081 jne       short M00_L07
       7FFBB04BA083 mov       rcx,r12
       7FFBB04BA086 mov       rdx,[rsp+20]
       7FFBB04BA08B mov       rax,[r12]
       7FFBB04BA08F mov       rax,[rax+0A8]
       7FFBB04BA096 call      qword ptr [rax+18]
       7FFBB04BA099 test      eax,eax
       7FFBB04BA09B je        short M00_L07
       7FFBB04BA09D jmp       near ptr M00_L03
M00_L11:
       7FFBB04BA0A2 test      rcx,rcx
       7FFBB04BA0A5 je        short M00_L07
       7FFBB04BA0A7 test      rdx,rdx
       7FFBB04BA0AA je        short M00_L07
       7FFBB04BA0AC mov       r8d,[rcx+8]
       7FFBB04BA0B0 cmp       r8d,[rdx+8]
       7FFBB04BA0B4 jne       short M00_L07
       7FFBB04BA0B6 lea       rax,[rcx+0C]
       7FFBB04BA0BA add       rdx,0C
       7FFBB04BA0BE mov       ecx,[rcx+8]
       7FFBB04BA0C1 add       ecx,ecx
       7FFBB04BA0C3 mov       r8d,ecx
       7FFBB04BA0C6 cmp       r8,0A
       7FFBB04BA0CA jne       short M00_L12
       7FFBB04BA0CC mov       rcx,[rax]
       7FFBB04BA0CF mov       rax,[rax+2]
       7FFBB04BA0D3 mov       r8,[rdx]
       7FFBB04BA0D6 xor       rcx,r8
       7FFBB04BA0D9 xor       rax,[rdx+2]
       7FFBB04BA0DD or        rax,rcx
       7FFBB04BA0E0 sete      al
       7FFBB04BA0E3 movzx     eax,al
       7FFBB04BA0E6 jmp       short M00_L13
M00_L12:
       7FFBB04BA0E8 mov       rcx,rax
       7FFBB04BA0EB call      qword ptr [7FFBB044C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04BA0F1 test      eax,eax
       7FFBB04BA0F3 je        near ptr M00_L07
       7FFBB04BA0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB04BA0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB04BA103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04BCD20 test      rdx,rdx
       7FFBB04BCD23 je        short M01_L02
       7FFBB04BCD25 mov       rax,[rdx]
       7FFBB04BCD28 cmp       rax,rcx
       7FFBB04BCD2B je        short M01_L02
       7FFBB04BCD2D mov       rax,[rax+10]
       7FFBB04BCD31 cmp       rax,rcx
       7FFBB04BCD34 je        short M01_L02
M01_L00:
       7FFBB04BCD36 test      rax,rax
       7FFBB04BCD39 je        short M01_L01
       7FFBB04BCD3B mov       rax,[rax+10]
       7FFBB04BCD3F cmp       rax,rcx
       7FFBB04BCD42 je        short M01_L02
       7FFBB04BCD44 test      rax,rax
       7FFBB04BCD47 je        short M01_L01
       7FFBB04BCD49 mov       rax,[rax+10]
       7FFBB04BCD4D cmp       rax,rcx
       7FFBB04BCD50 je        short M01_L02
       7FFBB04BCD52 test      rax,rax
       7FFBB04BCD55 jne       short M01_L03
M01_L01:
       7FFBB04BCD57 xor       edx,edx
M01_L02:
       7FFBB04BCD59 mov       rax,rdx
       7FFBB04BCD5C ret
M01_L03:
       7FFBB04BCD5D mov       rax,[rax+10]
       7FFBB04BCD61 cmp       rax,rcx
       7FFBB04BCD64 je        short M01_L02
       7FFBB04BCD66 test      rax,rax
       7FFBB04BCD69 je        short M01_L01
       7FFBB04BCD6B mov       rax,[rax+10]
       7FFBB04BCD6F cmp       rax,rcx
       7FFBB04BCD72 je        short M01_L02
       7FFBB04BCD74 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.Sliced()
       7FFBB04A9FA0 push      r15
       7FFBB04A9FA2 push      r14
       7FFBB04A9FA4 push      r13
       7FFBB04A9FA6 push      r12
       7FFBB04A9FA8 push      rdi
       7FFBB04A9FA9 push      rsi
       7FFBB04A9FAA push      rbp
       7FFBB04A9FAB push      rbx
       7FFBB04A9FAC sub       rsp,28
       7FFBB04A9FB0 mov       rdx,[rcx+8]
       7FFBB04A9FB4 test      rdx,rdx
       7FFBB04A9FB7 je        near ptr M00_L08
       7FFBB04A9FBD lea       rbx,[rdx+10]
       7FFBB04A9FC1 mov       esi,[rdx+8]
M00_L00:
       7FFBB04A9FC4 mov       rdx,[rcx+10]
       7FFBB04A9FC8 test      rdx,rdx
       7FFBB04A9FCB je        short M00_L09
       7FFBB04A9FCD lea       rdi,[rdx+10]
       7FFBB04A9FD1 mov       ebp,[rdx+8]
M00_L01:
       7FFBB04A9FD4 cmp       esi,ebp
       7FFBB04A9FD6 jne       short M00_L07
       7FFBB04A9FD8 xor       r14d,r14d
       7FFBB04A9FDB cmp       r14d,esi
       7FFBB04A9FDE jge       short M00_L05
M00_L02:
       7FFBB04A9FE0 mov       r15,r14
       7FFBB04A9FE3 shl       r15,4
       7FFBB04A9FE7 lea       r13,[rbx+r15]
       7FFBB04A9FEB cmp       r14d,ebp
       7FFBB04A9FEE jae       near ptr M00_L14
       7FFBB04A9FF4 add       r15,rdi
       7FFBB04A9FF7 mov       r12,[r13+8]
       7FFBB04A9FFB mov       rax,[r15+8]
       7FFBB04A9FFF mov       [rsp+20],rax
       7FFBB04AA004 cmp       r12,rax
       7FFBB04AA007 jne       short M00_L10
M00_L03:
       7FFBB04AA009 mov       rcx,[r13]
       7FFBB04AA00D mov       rdx,[r15]
       7FFBB04AA010 cmp       rcx,rdx
       7FFBB04AA013 jne       near ptr M00_L11
M00_L04:
       7FFBB04AA019 inc       r14d
       7FFBB04AA01C cmp       r14d,esi
       7FFBB04AA01F jl        short M00_L02
M00_L05:
       7FFBB04AA021 mov       eax,1
M00_L06:
       7FFBB04AA026 add       rsp,28
       7FFBB04AA02A pop       rbx
       7FFBB04AA02B pop       rbp
       7FFBB04AA02C pop       rsi
       7FFBB04AA02D pop       rdi
       7FFBB04AA02E pop       r12
       7FFBB04AA030 pop       r13
       7FFBB04AA032 pop       r14
       7FFBB04AA034 pop       r15
       7FFBB04AA036 ret
M00_L07:
       7FFBB04AA037 xor       eax,eax
       7FFBB04AA039 jmp       short M00_L06
M00_L08:
       7FFBB04AA03B xor       ebx,ebx
       7FFBB04AA03D xor       esi,esi
       7FFBB04AA03F jmp       short M00_L00
M00_L09:
       7FFBB04AA041 xor       edi,edi
       7FFBB04AA043 xor       ebp,ebp
       7FFBB04AA045 jmp       short M00_L01
M00_L10:
       7FFBB04AA047 test      r12,r12
       7FFBB04AA04A je        short M00_L07
       7FFBB04AA04C test      rax,rax
       7FFBB04AA04F je        short M00_L07
       7FFBB04AA051 mov       rdx,r12
       7FFBB04AA054 mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA05E call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA064 test      rax,rax
       7FFBB04AA067 jne       short M00_L07
       7FFBB04AA069 mov       rdx,[rsp+20]
       7FFBB04AA06E mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA078 call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA07E test      rax,rax
       7FFBB04AA081 jne       short M00_L07
       7FFBB04AA083 mov       rcx,r12
       7FFBB04AA086 mov       rdx,[rsp+20]
       7FFBB04AA08B mov       rax,[r12]
       7FFBB04AA08F mov       rax,[rax+0A8]
       7FFBB04AA096 call      qword ptr [rax+18]
       7FFBB04AA099 test      eax,eax
       7FFBB04AA09B je        short M00_L07
       7FFBB04AA09D jmp       near ptr M00_L03
M00_L11:
       7FFBB04AA0A2 test      rcx,rcx
       7FFBB04AA0A5 je        short M00_L07
       7FFBB04AA0A7 test      rdx,rdx
       7FFBB04AA0AA je        short M00_L07
       7FFBB04AA0AC mov       r8d,[rcx+8]
       7FFBB04AA0B0 cmp       r8d,[rdx+8]
       7FFBB04AA0B4 jne       short M00_L07
       7FFBB04AA0B6 lea       rax,[rcx+0C]
       7FFBB04AA0BA add       rdx,0C
       7FFBB04AA0BE mov       ecx,[rcx+8]
       7FFBB04AA0C1 add       ecx,ecx
       7FFBB04AA0C3 mov       r8d,ecx
       7FFBB04AA0C6 cmp       r8,0A
       7FFBB04AA0CA jne       short M00_L12
       7FFBB04AA0CC mov       rcx,[rax]
       7FFBB04AA0CF mov       rax,[rax+2]
       7FFBB04AA0D3 mov       r8,[rdx]
       7FFBB04AA0D6 xor       rcx,r8
       7FFBB04AA0D9 xor       rax,[rdx+2]
       7FFBB04AA0DD or        rax,rcx
       7FFBB04AA0E0 sete      al
       7FFBB04AA0E3 movzx     eax,al
       7FFBB04AA0E6 jmp       short M00_L13
M00_L12:
       7FFBB04AA0E8 mov       rcx,rax
       7FFBB04AA0EB call      qword ptr [7FFBB043C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04AA0F1 test      eax,eax
       7FFBB04AA0F3 je        near ptr M00_L07
       7FFBB04AA0F9 jmp       near ptr M00_L04
M00_L14:
       7FFBB04AA0FE call      CORINFO_HELP_RNGCHKFAIL
       7FFBB04AA103 int       3
; Total bytes of code 356
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04ACD00 test      rdx,rdx
       7FFBB04ACD03 je        short M01_L02
       7FFBB04ACD05 mov       rax,[rdx]
       7FFBB04ACD08 cmp       rax,rcx
       7FFBB04ACD0B je        short M01_L02
       7FFBB04ACD0D mov       rax,[rax+10]
       7FFBB04ACD11 cmp       rax,rcx
       7FFBB04ACD14 je        short M01_L02
M01_L00:
       7FFBB04ACD16 test      rax,rax
       7FFBB04ACD19 je        short M01_L01
       7FFBB04ACD1B mov       rax,[rax+10]
       7FFBB04ACD1F cmp       rax,rcx
       7FFBB04ACD22 je        short M01_L02
       7FFBB04ACD24 test      rax,rax
       7FFBB04ACD27 je        short M01_L01
       7FFBB04ACD29 mov       rax,[rax+10]
       7FFBB04ACD2D cmp       rax,rcx
       7FFBB04ACD30 je        short M01_L02
       7FFBB04ACD32 test      rax,rax
       7FFBB04ACD35 jne       short M01_L03
M01_L01:
       7FFBB04ACD37 xor       edx,edx
M01_L02:
       7FFBB04ACD39 mov       rax,rdx
       7FFBB04ACD3C ret
M01_L03:
       7FFBB04ACD3D mov       rax,[rax+10]
       7FFBB04ACD41 cmp       rax,rcx
       7FFBB04ACD44 je        short M01_L02
       7FFBB04ACD46 test      rax,rax
       7FFBB04ACD49 je        short M01_L01
       7FFBB04ACD4B mov       rax,[rax+10]
       7FFBB04ACD4F cmp       rax,rcx
       7FFBB04ACD52 je        short M01_L02
       7FFBB04ACD54 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

## .NET 10.0.6 (10.0.6, 10.0.626.17701), X64 RyuJIT x86-64-v4 (Job: DefaultJob)

```assembly
; DataSpanBenchmark.IsMatchColumnBenchmark.GetRef()
       7FFBB04A9FA0 push      r15
       7FFBB04A9FA2 push      r14
       7FFBB04A9FA4 push      r13
       7FFBB04A9FA6 push      r12
       7FFBB04A9FA8 push      rdi
       7FFBB04A9FA9 push      rsi
       7FFBB04A9FAA push      rbp
       7FFBB04A9FAB push      rbx
       7FFBB04A9FAC sub       rsp,28
       7FFBB04A9FB0 mov       rdx,[rcx+8]
       7FFBB04A9FB4 test      rdx,rdx
       7FFBB04A9FB7 je        short M00_L08
       7FFBB04A9FB9 lea       rbx,[rdx+10]
       7FFBB04A9FBD mov       esi,[rdx+8]
M00_L00:
       7FFBB04A9FC0 mov       rdx,[rcx+10]
       7FFBB04A9FC4 test      rdx,rdx
       7FFBB04A9FC7 je        short M00_L09
       7FFBB04A9FC9 lea       rdi,[rdx+10]
       7FFBB04A9FCD mov       edx,[rdx+8]
M00_L01:
       7FFBB04A9FD0 cmp       esi,edx
       7FFBB04A9FD2 jne       short M00_L07
       7FFBB04A9FD4 xor       ebp,ebp
       7FFBB04A9FD6 cmp       ebp,esi
       7FFBB04A9FD8 jge       short M00_L05
M00_L02:
       7FFBB04A9FDA movsxd    r14,ebp
       7FFBB04A9FDD shl       r14,4
       7FFBB04A9FE1 lea       r15,[rbx+r14]
       7FFBB04A9FE5 add       r14,rdi
       7FFBB04A9FE8 mov       r13,[r15+8]
       7FFBB04A9FEC mov       r12,[r14+8]
       7FFBB04A9FF0 cmp       r13,r12
       7FFBB04A9FF3 jne       short M00_L10
M00_L03:
       7FFBB04A9FF5 mov       rcx,[r15]
       7FFBB04A9FF8 mov       rdx,[r14]
       7FFBB04A9FFB cmp       rcx,rdx
       7FFBB04A9FFE jne       near ptr M00_L11
M00_L04:
       7FFBB04AA004 inc       ebp
       7FFBB04AA006 cmp       ebp,esi
       7FFBB04AA008 jl        short M00_L02
M00_L05:
       7FFBB04AA00A mov       eax,1
M00_L06:
       7FFBB04AA00F add       rsp,28
       7FFBB04AA013 pop       rbx
       7FFBB04AA014 pop       rbp
       7FFBB04AA015 pop       rsi
       7FFBB04AA016 pop       rdi
       7FFBB04AA017 pop       r12
       7FFBB04AA019 pop       r13
       7FFBB04AA01B pop       r14
       7FFBB04AA01D pop       r15
       7FFBB04AA01F ret
M00_L07:
       7FFBB04AA020 xor       eax,eax
       7FFBB04AA022 jmp       short M00_L06
M00_L08:
       7FFBB04AA024 xor       ebx,ebx
       7FFBB04AA026 xor       esi,esi
       7FFBB04AA028 jmp       short M00_L00
M00_L09:
       7FFBB04AA02A xor       edi,edi
       7FFBB04AA02C xor       edx,edx
       7FFBB04AA02E jmp       short M00_L01
M00_L10:
       7FFBB04AA030 test      r13,r13
       7FFBB04AA033 je        short M00_L07
       7FFBB04AA035 test      r12,r12
       7FFBB04AA038 je        short M00_L07
       7FFBB04AA03A mov       rdx,r13
       7FFBB04AA03D mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA047 call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA04D test      rax,rax
       7FFBB04AA050 jne       short M00_L07
       7FFBB04AA052 mov       rdx,r12
       7FFBB04AA055 mov       rcx,offset MT_System.RuntimeType
       7FFBB04AA05F call      qword ptr [7FFBB0436850]; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04AA065 test      rax,rax
       7FFBB04AA068 jne       short M00_L07
       7FFBB04AA06A mov       rcx,r13
       7FFBB04AA06D mov       rdx,r12
       7FFBB04AA070 mov       rax,[r13]
       7FFBB04AA074 mov       rax,[rax+0A8]
       7FFBB04AA07B call      qword ptr [rax+18]
       7FFBB04AA07E test      eax,eax
       7FFBB04AA080 je        short M00_L07
       7FFBB04AA082 jmp       near ptr M00_L03
M00_L11:
       7FFBB04AA087 test      rcx,rcx
       7FFBB04AA08A je        short M00_L07
       7FFBB04AA08C test      rdx,rdx
       7FFBB04AA08F je        short M00_L07
       7FFBB04AA091 mov       r8d,[rcx+8]
       7FFBB04AA095 cmp       r8d,[rdx+8]
       7FFBB04AA099 jne       short M00_L07
       7FFBB04AA09B lea       rax,[rcx+0C]
       7FFBB04AA09F add       rdx,0C
       7FFBB04AA0A3 mov       ecx,[rcx+8]
       7FFBB04AA0A6 add       ecx,ecx
       7FFBB04AA0A8 mov       r8d,ecx
       7FFBB04AA0AB cmp       r8,0A
       7FFBB04AA0AF jne       short M00_L12
       7FFBB04AA0B1 mov       rcx,[rax]
       7FFBB04AA0B4 mov       rax,[rax+2]
       7FFBB04AA0B8 mov       r8,[rdx]
       7FFBB04AA0BB xor       rcx,r8
       7FFBB04AA0BE xor       rax,[rdx+2]
       7FFBB04AA0C2 or        rax,rcx
       7FFBB04AA0C5 sete      al
       7FFBB04AA0C8 movzx     eax,al
       7FFBB04AA0CB jmp       short M00_L13
M00_L12:
       7FFBB04AA0CD mov       rcx,rax
       7FFBB04AA0D0 call      qword ptr [7FFBB043C330]; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
M00_L13:
       7FFBB04AA0D6 test      eax,eax
       7FFBB04AA0D8 je        near ptr M00_L07
       7FFBB04AA0DE jmp       near ptr M00_L04
; Total bytes of code 323
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.IsInstanceOfClass(Void*, System.Object)
       7FFBB04ACCE0 test      rdx,rdx
       7FFBB04ACCE3 je        short M01_L02
       7FFBB04ACCE5 mov       rax,[rdx]
       7FFBB04ACCE8 cmp       rax,rcx
       7FFBB04ACCEB je        short M01_L02
       7FFBB04ACCED mov       rax,[rax+10]
       7FFBB04ACCF1 cmp       rax,rcx
       7FFBB04ACCF4 je        short M01_L02
M01_L00:
       7FFBB04ACCF6 test      rax,rax
       7FFBB04ACCF9 je        short M01_L01
       7FFBB04ACCFB mov       rax,[rax+10]
       7FFBB04ACCFF cmp       rax,rcx
       7FFBB04ACD02 je        short M01_L02
       7FFBB04ACD04 test      rax,rax
       7FFBB04ACD07 je        short M01_L01
       7FFBB04ACD09 mov       rax,[rax+10]
       7FFBB04ACD0D cmp       rax,rcx
       7FFBB04ACD10 je        short M01_L02
       7FFBB04ACD12 test      rax,rax
       7FFBB04ACD15 jne       short M01_L03
M01_L01:
       7FFBB04ACD17 xor       edx,edx
M01_L02:
       7FFBB04ACD19 mov       rax,rdx
       7FFBB04ACD1C ret
M01_L03:
       7FFBB04ACD1D mov       rax,[rax+10]
       7FFBB04ACD21 cmp       rax,rcx
       7FFBB04ACD24 je        short M01_L02
       7FFBB04ACD26 test      rax,rax
       7FFBB04ACD29 je        short M01_L01
       7FFBB04ACD2B mov       rax,[rax+10]
       7FFBB04ACD2F cmp       rax,rcx
       7FFBB04ACD32 je        short M01_L02
       7FFBB04ACD34 jmp       short M01_L00
; Total bytes of code 86
```
```assembly
; System.SpanHelpers.SequenceEqual(Byte ByRef, Byte ByRef, UIntPtr)
       7FFB6099D560 cmp       r8,8
       7FFB6099D564 jb        short M02_L06
       7FFB6099D566 cmp       rcx,rdx
       7FFB6099D569 je        short M02_L04
       7FFB6099D56B cmp       r8,10
       7FFB6099D56F jae       short M02_L01
       7FFB6099D571 add       r8,0FFFFFFFFFFFFFFF8
       7FFB6099D575 mov       rax,[rcx]
       7FFB6099D578 sub       rax,[rdx]
       7FFB6099D57B mov       rcx,[rcx+r8]
       7FFB6099D57F sub       rcx,[rdx+r8]
       7FFB6099D583 or        rax,rcx
       7FFB6099D586 sete      al
       7FFB6099D589 movzx     eax,al
M02_L00:
       7FFB6099D58C ret
M02_L01:
       7FFB6099D58D xor       eax,eax
       7FFB6099D58F add       r8,0FFFFFFFFFFFFFFF0
       7FFB6099D593 je        short M02_L03
       7FFB6099D595 movups    xmm0,[rcx]
       7FFB6099D598 movups    xmm1,[rdx]
       7FFB6099D59B pcmpeqb   xmm0,xmm1
       7FFB6099D59F pmovmskb  r10d,xmm0
       7FFB6099D5A4 cmp       r10d,0FFFF
       7FFB6099D5AB jne       short M02_L05
M02_L02:
       7FFB6099D5AD add       rax,10
       7FFB6099D5B1 cmp       r8,rax
       7FFB6099D5B4 ja        short M02_L10
M02_L03:
       7FFB6099D5B6 movups    xmm0,[rcx+r8]
       7FFB6099D5BB movups    xmm1,[rdx+r8]
       7FFB6099D5C0 pcmpeqb   xmm0,xmm1
       7FFB6099D5C4 pmovmskb  eax,xmm0
       7FFB6099D5C8 cmp       eax,0FFFF
       7FFB6099D5CD jne       short M02_L05
M02_L04:
       7FFB6099D5CF mov       eax,1
       7FFB6099D5D4 ret
M02_L05:
       7FFB6099D5D5 xor       eax,eax
       7FFB6099D5D7 ret
M02_L06:
       7FFB6099D5D8 cmp       r8,4
       7FFB6099D5DC jb        short M02_L07
       7FFB6099D5DE add       r8,0FFFFFFFFFFFFFFFC
       7FFB6099D5E2 mov       eax,[rcx]
       7FFB6099D5E4 sub       eax,[rdx]
       7FFB6099D5E6 mov       ecx,[rcx+r8]
       7FFB6099D5EA sub       ecx,[rdx+r8]
       7FFB6099D5EE or        eax,ecx
       7FFB6099D5F0 sete      al
       7FFB6099D5F3 movzx     eax,al
       7FFB6099D5F6 jmp       short M02_L00
M02_L07:
       7FFB6099D5F8 xor       eax,eax
       7FFB6099D5FA mov       r10,r8
       7FFB6099D5FD and       r10,2
       7FFB6099D601 je        short M02_L08
       7FFB6099D603 movzx     eax,word ptr [rcx]
       7FFB6099D606 movzx     r9d,word ptr [rdx]
       7FFB6099D60A sub       eax,r9d
M02_L08:
       7FFB6099D60D test      r8b,1
       7FFB6099D611 je        short M02_L09
       7FFB6099D613 movzx     ecx,byte ptr [rcx+r10]
       7FFB6099D618 movzx     edx,byte ptr [rdx+r10]
       7FFB6099D61D sub       ecx,edx
       7FFB6099D61F or        eax,ecx
M02_L09:
       7FFB6099D621 test      eax,eax
       7FFB6099D623 sete      al
       7FFB6099D626 movzx     eax,al
       7FFB6099D629 jmp       near ptr M02_L00
M02_L10:
       7FFB6099D62E movups    xmm0,[rcx+rax]
       7FFB6099D632 movups    xmm1,[rdx+rax]
       7FFB6099D636 pcmpeqb   xmm0,xmm1
       7FFB6099D63A pmovmskb  r10d,xmm0
       7FFB6099D63F cmp       r10d,0FFFF
       7FFB6099D646 jne       short M02_L05
       7FFB6099D648 jmp       near ptr M02_L02
; Total bytes of code 237
```

