namespace ColumnMetadataLookupBenchmark;

using System;
using System.Runtime.CompilerServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class ReconcileBenchmark
{
    private const int N = 10_000;

    private const int MaxColumns = 32;

    private string[] readerNames = default!;

    private int columnCount;

    [Params(32)]
    public int Columns { get; set; }

    [Params(ReaderShape.InOrder, ReaderShape.Reversed, ReaderShape.WideSubset)]
    public ReaderShape Shape { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        readerNames = ReaderBuilder.Build(KeySets.NoCollision, Columns, Shape);
        columnCount = Columns;
    }

    [Benchmark(Baseline = true, OperationsPerInvoke = N)]
    public int DirectOld()
    {
        var total = 0;
        for (var i = 0; i < N; i++)
        {
            total += columnCount <= 8 ? 0 : ResolveDirectLarge();
        }

        return total;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int DirectOldBothTargets()
    {
        var total = 0;
        for (var i = 0; i < N; i++)
        {
            total += columnCount <= 8 ? ResolveDirectSmall() : ResolveDirectLarge();
        }

        return total;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int DirectNew() => SweepDispatch.Direct(readerNames, Columns, N);

    [Benchmark(OperationsPerInvoke = N)]
    public int SwitchOld()
    {
        var total = 0;
        for (var i = 0; i < N; i++)
        {
            total += columnCount <= 8 ? 0 : ResolveSwitchLarge();
        }

        return total;
    }

    [Benchmark(OperationsPerInvoke = N)]
    public int SwitchNew() => SweepDispatch.Switch(readerNames, Columns, N);

    //--------------------------------------------------------------------------------
    // Previous
    //--------------------------------------------------------------------------------

    private int ResolveSwitchLarge()
    {
        Span<int> ordinals = stackalloc int[MaxColumns];
        ordinals.Fill(-1);

        var resolved = 0;
        var names = readerNames;
        for (var i = 0; i < names.Length; i++)
        {
            var index = Matchers.SwitchFixed_NC_32(names[i]);
            if ((index >= 0) && (ordinals[index] < 0))
            {
                ordinals[index] = i;
                resolved++;
                if (resolved == 32)
                {
                    break;
                }
            }
        }

        return Sum(ordinals);
    }

#pragma warning disable SA1503
#pragma warning disable IDE0011
    private int ResolveDirectSmall()
    {
        var o0 = -1; var o1 = -1; var o2 = -1; var o3 = -1; var o4 = -1; var o5 = -1; var o6 = -1; var o7 = -1;
        var resolved = 0;
        var names = readerNames;
        for (var i = 0; i < names.Length; i++)
        {
            var name = names[i];
            if ((o0 < 0) && String.Equals(name, "id", StringComparison.OrdinalIgnoreCase)) { o0 = i; resolved++; }
            else if ((o1 < 0) && String.Equals(name, "user_name", StringComparison.OrdinalIgnoreCase)) { o1 = i; resolved++; }
            else if ((o2 < 0) && String.Equals(name, "email", StringComparison.OrdinalIgnoreCase)) { o2 = i; resolved++; }
            else if ((o3 < 0) && String.Equals(name, "age", StringComparison.OrdinalIgnoreCase)) { o3 = i; resolved++; }
            else if ((o4 < 0) && String.Equals(name, "is_active", StringComparison.OrdinalIgnoreCase)) { o4 = i; resolved++; }
            else if ((o5 < 0) && String.Equals(name, "created_at", StringComparison.OrdinalIgnoreCase)) { o5 = i; resolved++; }
            else if ((o6 < 0) && String.Equals(name, "updated_at", StringComparison.OrdinalIgnoreCase)) { o6 = i; resolved++; }
            else if ((o7 < 0) && String.Equals(name, "version", StringComparison.OrdinalIgnoreCase)) { o7 = i; resolved++; }
            if (resolved == 8) break;
        }

        return o0 + o1 + o2 + o3 + o4 + o5 + o6 + o7;
    }
#pragma warning restore IDE0011
#pragma warning restore SA1503

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int Sum(ReadOnlySpan<int> values)
    {
        var sum = 0;
        for (var i = 0; i < values.Length; i++)
        {
            sum += values[i];
        }

        return sum;
    }

#pragma warning disable SA1503
#pragma warning disable IDE0011
    private int ResolveDirectLarge()
    {
        var o0 = -1; var o1 = -1; var o2 = -1; var o3 = -1; var o4 = -1; var o5 = -1; var o6 = -1; var o7 = -1;
        var o8 = -1; var o9 = -1; var o10 = -1; var o11 = -1; var o12 = -1; var o13 = -1; var o14 = -1; var o15 = -1;
        var o16 = -1; var o17 = -1; var o18 = -1; var o19 = -1; var o20 = -1; var o21 = -1; var o22 = -1; var o23 = -1;
        var o24 = -1; var o25 = -1; var o26 = -1; var o27 = -1; var o28 = -1; var o29 = -1; var o30 = -1; var o31 = -1;
        var resolved = 0;
        var names = readerNames;
        for (var i = 0; i < names.Length; i++)
        {
            var name = names[i];
            if ((o0 < 0) && String.Equals(name, "id", StringComparison.OrdinalIgnoreCase)) { o0 = i; resolved++; }
            else if ((o1 < 0) && String.Equals(name, "tenant_id", StringComparison.OrdinalIgnoreCase)) { o1 = i; resolved++; }
            else if ((o2 < 0) && String.Equals(name, "user_name", StringComparison.OrdinalIgnoreCase)) { o2 = i; resolved++; }
            else if ((o3 < 0) && String.Equals(name, "display_name", StringComparison.OrdinalIgnoreCase)) { o3 = i; resolved++; }
            else if ((o4 < 0) && String.Equals(name, "email", StringComparison.OrdinalIgnoreCase)) { o4 = i; resolved++; }
            else if ((o5 < 0) && String.Equals(name, "phone_number", StringComparison.OrdinalIgnoreCase)) { o5 = i; resolved++; }
            else if ((o6 < 0) && String.Equals(name, "age", StringComparison.OrdinalIgnoreCase)) { o6 = i; resolved++; }
            else if ((o7 < 0) && String.Equals(name, "birth_date", StringComparison.OrdinalIgnoreCase)) { o7 = i; resolved++; }
            else if ((o8 < 0) && String.Equals(name, "is_active", StringComparison.OrdinalIgnoreCase)) { o8 = i; resolved++; }
            else if ((o9 < 0) && String.Equals(name, "is_deleted", StringComparison.OrdinalIgnoreCase)) { o9 = i; resolved++; }
            else if ((o10 < 0) && String.Equals(name, "status_code", StringComparison.OrdinalIgnoreCase)) { o10 = i; resolved++; }
            else if ((o11 < 0) && String.Equals(name, "role_id", StringComparison.OrdinalIgnoreCase)) { o11 = i; resolved++; }
            else if ((o12 < 0) && String.Equals(name, "department_id", StringComparison.OrdinalIgnoreCase)) { o12 = i; resolved++; }
            else if ((o13 < 0) && String.Equals(name, "manager_id", StringComparison.OrdinalIgnoreCase)) { o13 = i; resolved++; }
            else if ((o14 < 0) && String.Equals(name, "salary", StringComparison.OrdinalIgnoreCase)) { o14 = i; resolved++; }
            else if ((o15 < 0) && String.Equals(name, "bonus", StringComparison.OrdinalIgnoreCase)) { o15 = i; resolved++; }
            else if ((o16 < 0) && String.Equals(name, "address_line1", StringComparison.OrdinalIgnoreCase)) { o16 = i; resolved++; }
            else if ((o17 < 0) && String.Equals(name, "address_line2", StringComparison.OrdinalIgnoreCase)) { o17 = i; resolved++; }
            else if ((o18 < 0) && String.Equals(name, "city", StringComparison.OrdinalIgnoreCase)) { o18 = i; resolved++; }
            else if ((o19 < 0) && String.Equals(name, "state", StringComparison.OrdinalIgnoreCase)) { o19 = i; resolved++; }
            else if ((o20 < 0) && String.Equals(name, "postal_code", StringComparison.OrdinalIgnoreCase)) { o20 = i; resolved++; }
            else if ((o21 < 0) && String.Equals(name, "country_code", StringComparison.OrdinalIgnoreCase)) { o21 = i; resolved++; }
            else if ((o22 < 0) && String.Equals(name, "note", StringComparison.OrdinalIgnoreCase)) { o22 = i; resolved++; }
            else if ((o23 < 0) && String.Equals(name, "tags", StringComparison.OrdinalIgnoreCase)) { o23 = i; resolved++; }
            else if ((o24 < 0) && String.Equals(name, "created_at", StringComparison.OrdinalIgnoreCase)) { o24 = i; resolved++; }
            else if ((o25 < 0) && String.Equals(name, "created_by", StringComparison.OrdinalIgnoreCase)) { o25 = i; resolved++; }
            else if ((o26 < 0) && String.Equals(name, "updated_at", StringComparison.OrdinalIgnoreCase)) { o26 = i; resolved++; }
            else if ((o27 < 0) && String.Equals(name, "updated_by", StringComparison.OrdinalIgnoreCase)) { o27 = i; resolved++; }
            else if ((o28 < 0) && String.Equals(name, "deleted_at", StringComparison.OrdinalIgnoreCase)) { o28 = i; resolved++; }
            else if ((o29 < 0) && String.Equals(name, "deleted_by", StringComparison.OrdinalIgnoreCase)) { o29 = i; resolved++; }
            else if ((o30 < 0) && String.Equals(name, "version", StringComparison.OrdinalIgnoreCase)) { o30 = i; resolved++; }
            else if ((o31 < 0) && String.Equals(name, "row_hash", StringComparison.OrdinalIgnoreCase)) { o31 = i; resolved++; }
            if (resolved == 32) break;
        }

        return o0 + o1 + o2 + o3 + o4 + o5 + o6 + o7 + o8 + o9 + o10 + o11 + o12 + o13 + o14 + o15 +
               o16 + o17 + o18 + o19 + o20 + o21 + o22 + o23 + o24 + o25 + o26 + o27 + o28 + o29 + o30 + o31;
    }
#pragma warning restore IDE0011
#pragma warning restore SA1503
}
#pragma warning restore CA1822
