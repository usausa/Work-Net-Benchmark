# Work-Net-Benchmark

BenchmarkDotNet benchmarks for .NET performance verification. This repository is a **workbench for verification**; the canonical source of confirmed knowledge (patterns, measurements, rejected techniques) is the [dotnet-performance](../dotnet-performance/README.md) repository.

## Relationship with dotnet-performance

| Repository | Role |
|---|---|
| **dotnet-performance** | Canonical. Pattern catalog, sample implementations, confirmed measurements, rejected-technique records |
| Work-Net-Benchmark (this) | Verification workbench. Prototyping hypotheses, experiments tied to generated code, measurements not yet migrated |

Once a finding is confirmed it is reflected into the dotnet-performance catalog, and the project here is kept as OBSOLETE for history.

Projects whose content has been migrated carry a warning banner in their own README, pointing to the pattern ID and measurement record on the migration target.

See [README.ja.md](README.ja.md) for the full project list (Japanese).
