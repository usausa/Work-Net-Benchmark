@echo off
setlocal enabledelayedexpansion

REM =====================================================================
REM  run_all_benchmarks.bat
REM
REM  1. Performs a clean Release build of the entire solution.
REM  2. Runs every benchmark project sequentially.
REM
REM  Progress is appended to benchmark_run.log in the same directory.
REM  Each line shows a timestamp so you can see elapsed time per step.
REM
REM  A benchmark failure is logged but does NOT abort the remaining run.
REM  A build failure aborts immediately.
REM =====================================================================

set "ROOT=%~dp0"
set "LOG=%ROOT%benchmark_run.log"
set "SOLUTION=%ROOT%Benchmark.slnx"

call :LOG "================================================================"
call :LOG "SESSION START"
call :LOG "  Machine  : %COMPUTERNAME%"
call :LOG "  Solution : Benchmark.slnx"
call :LOG "================================================================"

REM ── Step 1: Clean Release build ──────────────────────────────────────

call :LOG "[BUILD] begin  Benchmark.slnx -c Release"

dotnet build "%SOLUTION%" -c Release --nologo -v q

if errorlevel 1 (
    call :LOG "[BUILD] FAILED -- aborting session"
    exit /b 1
)

call :LOG "[BUILD] done   Benchmark.slnx -c Release"

REM ── Step 2: Run benchmarks ────────────────────────────────────────────
REM
REM  Each project is run from its own directory so that BenchmarkDotNet
REM  places artifacts (BenchmarkDotNet.Artifacts\) under that directory.
REM  --no-build uses the binaries produced by Step 1.
REM  --framework net10.0 selects the host process; BenchmarkDotNet's
REM  [MediumRunJob] attributes handle launching the net8/9/10 child jobs.

REM /Abstraction/
call :RUN Abstraction\CallAbstractionBenchmark
call :RUN Abstraction\CallNopBenchmark
call :RUN Abstraction\FactoryEntryBenchmark
call :RUN Abstraction\FunctionPointerBenchmark
call :RUN Abstraction\LambdaLocalBenchmark
call :RUN Abstraction\SealedDispatchBenchmark
call :RUN Abstraction\SwitchBenchmark
call :RUN Abstraction\DelegateBenchmark

REM /Async/
call :RUN Async\BasicBenchmark
call :RUN Async\ValueTaskBenchmark

REM /Collections/
call :RUN Collections\DictionaryMarshalBenchmark
call :RUN Collections\EntryBenchmark
call :RUN Collections\EnumerableImplementBenchmark
call :RUN Collections\FindEntryBenchmark
call :RUN Collections\FrozenBenchmark
call :RUN Collections\HandlersBenchmark
call :RUN Collections\ListBenchmark
call :RUN Collections\LoopListBenchmark
call :RUN Collections\StructSlotMapBenchmark

REM /Loop/
call :RUN Loop\ForBenchmark
call :RUN Loop\WorkArrayBenchmark
call :RUN Loop\WorkMatchBenchmark

REM /Memory/
call :RUN Memory\BoundaryAccessBenchmark
call :RUN Memory\BoxingBenchmark
call :RUN Memory\BufferWriteBenchmark
call :RUN Memory\DataSpanBenchmark
call :RUN Memory\UnsafeReferenceBenchmark
call :RUN Memory\CopyBenchmark
call :RUN Memory\SpanAccessBenchmark
call :RUN Memory\BufferAllocBenchmark

REM /Misc/
call :RUN Misc\DisposableBenchmark

REM /Numeric/
call :RUN Numeric\CalcIndexBenchmark
call :RUN Numeric\NumericBenchmark
call :RUN Numeric\SortBenchmark

REM /Runtime/
call :RUN Runtime\CastBenchmark
call :RUN Runtime\GenericConverterBenchmark
call :RUN Runtime\ParameterBenchmark
call :RUN Runtime\ProjectionBenchmark
call :RUN Runtime\ReadOnlyFieldBenchmark
call :RUN Runtime\TypeConvertBenchmark
call :RUN Runtime\TypeOfBenchmark
call :RUN Runtime\InlineBenchmark
call :RUN Runtime\MemberAccessBenchmark
call :RUN Runtime\ConverterBenchmark
call :RUN Runtime\ContainerConverterBenchmark

REM /Text/
call :RUN Text\CharConvertBenchmark
call :RUN Text\FormatBenchmark
call :RUN Text\HexBenchmark
call :RUN Text\IndexOfAnyBenchmark
call :RUN Text\ParseBenchmark
call :RUN Text\StringAppendBenchmark
call :RUN Text\StringBuilderBenchmark
call :RUN Text\StringHashBenchmark
call :RUN Text\TextConvertBenchmark

call :LOG "================================================================"
call :LOG "SESSION COMPLETE"
call :LOG "================================================================"
goto :EOF

REM =====================================================================
REM  :RUN <ProjectName>
REM    Enters the project directory, executes the benchmark, exits.
REM    Logs [RUN ] begin / done / FAILED with timestamps.
REM =====================================================================
:RUN
set "_PROJ=%~1"
call :LOG "[RUN ] begin  %_PROJ%"
pushd "%ROOT%%_PROJ%"
dotnet run -c Release --framework net10.0 --no-build
set "_RC=%ERRORLEVEL%"
popd
if %_RC% neq 0 (
    call :LOG "[RUN ] FAILED %_PROJ%  (exit=%_RC%)"
) else (
    call :LOG "[RUN ] done   %_PROJ%"
)
goto :EOF

REM =====================================================================
REM  :LOG <message>
REM    Writes a timestamped line to stdout and appends it to %LOG%.
REM =====================================================================
:LOG
for /f "tokens=*" %%T in ('powershell -NoProfile -Command "[datetime]::Now.ToString(\"yyyy-MM-dd HH:mm:ss\")"') do set "_TS=%%T"
echo [%_TS%] %~1
echo [%_TS%] %~1>>"%LOG%"
goto :EOF
