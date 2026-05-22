namespace DataSpanBenchmark;

using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddExporter(MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default, new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(maxDepth: 3, printSource: true, printInstructionAddresses: true, exportDiff: true)));
    }
}

[Config(typeof(BenchmarkConfig))]
public class Benchmark
{
    private const int TableSize = 4;

    private ClassNodeMap<object?> classMap = default!;
    private StructSlotMap<object?> structMap = default!;
    private StructSlotMapUnsafe<object?> structMapUnsafe = default!;
    private StructSlotMapFlatRef<object?> structMapFlatRef = default!;
    private StructSlotMapFlatUnsafe<object?> structMapFlatUnsafe = default!;
    private StructSlotMapFlatSeq<object?> structMapFlatSeq = default!;

    private Type firstKey = default!;   // hits at first position
    private Type secondKey = default!;  // hits at second position (forces chain traversal)

    [GlobalSetup]
    public void Setup()
    {
        classMap = new ClassNodeMap<object?>(TableSize);
        structMap = new StructSlotMap<object?>(TableSize);
        structMapUnsafe = new StructSlotMapUnsafe<object?>(TableSize);
        structMapFlatRef = new StructSlotMapFlatRef<object?>(TableSize);
        structMapFlatUnsafe = new StructSlotMapFlatUnsafe<object?>(TableSize);
        structMapFlatSeq = new StructSlotMapFlatSeq<object?>(TableSize);

        var allTypes = new[]
        {
            typeof(int), typeof(long), typeof(string), typeof(double), typeof(float),
            typeof(byte), typeof(short), typeof(uint), typeof(ulong), typeof(char),
            typeof(bool), typeof(decimal), typeof(object), typeof(DateTime), typeof(Guid),
            typeof(TimeSpan), typeof(DateTimeOffset), typeof(Uri), typeof(Version), typeof(Exception),
        };

        var groups = allTypes
            .GroupBy(t => t.GetHashCode() & (TableSize - 1))
            .FirstOrDefault(g => g.Count() >= 2) ?? throw new InvalidOperationException("No collision found. Increase allTypes.");

        var grouped = groups.ToArray();
        firstKey = grouped[0];
        secondKey = grouped[1];

        classMap.Add(firstKey, firstKey);
        classMap.Add(secondKey, secondKey);
        structMap.Add(firstKey, firstKey);
        structMap.Add(secondKey, secondKey);
        structMapUnsafe.Add(firstKey, firstKey);
        structMapUnsafe.Add(secondKey, secondKey);
        structMapFlatRef.Add(firstKey, firstKey);
        structMapFlatRef.Add(secondKey, secondKey);
        structMapFlatUnsafe.Add(firstKey, firstKey);
        structMapFlatUnsafe.Add(secondKey, secondKey);
        structMapFlatSeq.Add(firstKey, firstKey);
        structMapFlatSeq.Add(secondKey, secondKey);

        // Validate correctness
#pragma warning disable SA1503
#pragma warning disable CA2201
        if (!classMap.TryGetValue(firstKey, out _)) throw new Exception("ClassMap: firstKey not found");
        if (!classMap.TryGetValue(secondKey, out _)) throw new Exception("ClassMap: secondKey not found");
        if (!structMap.TryGetValue(firstKey, out _)) throw new Exception("StructMap: firstKey not found");
        if (!structMap.TryGetValue(secondKey, out _)) throw new Exception("StructMap: secondKey not found");
        if (!structMapUnsafe.TryGetValue(firstKey, out _)) throw new Exception("StructMapUnsafe: firstKey not found");
        if (!structMapUnsafe.TryGetValue(secondKey, out _)) throw new Exception("StructMapUnsafe: secondKey not found");
        if (!structMapFlatRef.TryGetValue(firstKey, out _)) throw new Exception("StructMapFlatRef: firstKey not found");
        if (!structMapFlatRef.TryGetValue(secondKey, out _)) throw new Exception("StructMapFlatRef: secondKey not found");
        if (!structMapFlatUnsafe.TryGetValue(firstKey, out _)) throw new Exception("StructMapFlatUnsafe: firstKey not found");
        if (!structMapFlatUnsafe.TryGetValue(secondKey, out _)) throw new Exception("StructMapFlatUnsafe: secondKey not found");
        if (!structMapFlatSeq.TryGetValue(firstKey, out _)) throw new Exception("StructMapFlatSeq: firstKey not found");
        if (!structMapFlatSeq.TryGetValue(secondKey, out _)) throw new Exception("StructMapFlatSeq: secondKey not found");
#pragma warning disable CA2201
#pragma warning restore SA1503
    }

    // ---------------------------------------------------------------------------
    // Hit at first node / first slot
    // ---------------------------------------------------------------------------

    [Benchmark(Baseline = true)]
    public bool HitFirstClassNode() => classMap.TryGetValue(firstKey, out _);

    [Benchmark]
    public bool HitFirstStructSlot() => structMap.TryGetValue(firstKey, out _);

    [Benchmark]
    public bool HitFirstStructSlotUnsafe() => structMapUnsafe.TryGetValue(firstKey, out _);

    [Benchmark]
    public bool HitFirstStructSlotFlatRef() => structMapFlatRef.TryGetValue(firstKey, out _);

    [Benchmark]
    public bool HitFirstStructSlotFlatUnsafe() => structMapFlatUnsafe.TryGetValue(firstKey, out _);

    [Benchmark]
    public bool HitFirstStructSlotFlatSeq() => structMapFlatSeq.TryGetValue(firstKey, out _);

    // ---------------------------------------------------------------------------
    // Hit at second node / second slot
    // ---------------------------------------------------------------------------

    [Benchmark]
    public bool HitSecondClassNode() => classMap.TryGetValue(secondKey, out _);

    [Benchmark]
    public bool HitSecondStructSlot() => structMap.TryGetValue(secondKey, out _);

    [Benchmark]
    public bool HitSecondStructSlotUnsafe() => structMapUnsafe.TryGetValue(secondKey, out _);

    [Benchmark]
    public bool HitSecondStructSlotFlatRef() => structMapFlatRef.TryGetValue(secondKey, out _);

    [Benchmark]
    public bool HitSecondStructSlotFlatUnsafe() => structMapFlatUnsafe.TryGetValue(secondKey, out _);

    [Benchmark]
    public bool HitSecondStructSlotFlatSeq() => structMapFlatSeq.TryGetValue(secondKey, out _);
}

// ---------------------------------------------------------------------------
// Implementation A: Class-node linked list
// ---------------------------------------------------------------------------

internal sealed class ClassNodeMap<TValue>
{
    private static readonly ClassNode EmptyNode = new(typeof(void), default!);

    private readonly ClassNode[] nodes;
    private readonly int mask;

    public ClassNodeMap(int tableSize)
    {
        var size = (int)BitOperations.RoundUpToPowerOf2((uint)tableSize);
        mask = size - 1;
        nodes = new ClassNode[size];
        nodes.AsSpan().Fill(EmptyNode);
    }

    public void Add(Type key, TValue value)
    {
        var index = key.GetHashCode() & mask;
        var head = nodes[index];
        if (head == EmptyNode)
        {
            nodes[index] = new ClassNode(key, value);
        }
        else
        {
            var last = head;
            while (last.Next is not null)
            {
                last = last.Next;
            }
            last.Next = new ClassNode(key, value);
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out TValue value)
    {
        var node = nodes[key.GetHashCode() & mask];
        do
        {
            if (node.Key == key)
            {
                value = node.Value;
                return true;
            }
            node = node.Next;
        }
        while (node is not null);

        value = default;
        return false;
    }

#pragma warning disable SA1401
    private sealed class ClassNode(Type key, TValue value)
    {
        public readonly Type Key = key;
        public readonly TValue Value = value;
        public ClassNode? Next;
    }
#pragma warning restore SA1401
}

// ---------------------------------------------------------------------------
// Implementation B: Struct-slot with inline first element
// ---------------------------------------------------------------------------
internal sealed class StructSlotMap<TValue>
{
    private readonly StructSlot<TValue>[] slots;
    private readonly int mask;

    public StructSlotMap(int tableSize)
    {
        var size = (int)BitOperations.RoundUpToPowerOf2((uint)tableSize);
        mask = size - 1;
        slots = new StructSlot<TValue>[size];
        // default: Key == null → empty
    }

    public void Add(Type key, TValue value)
    {
        var index = key.GetHashCode() & mask;
        ref var slot = ref slots[index];
        if (slot.Key is null)
        {
            // First element stored inline in the struct
            slot.Key = key;
            slot.Value = value;
        }
        else
        {
            // Overflow: append to class-node chain
            if (slot.Next is null)
            {
                slot.Next = new OverflowNode<TValue>(key, value);
            }
            else
            {
                var last = slot.Next;
                while (last.Next is not null)
                {
                    last = last.Next;
                }
                last.Next = new OverflowNode<TValue>(key, value);
            }
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out TValue value)
    {
        // ref access: struct is inline in the array → no pointer dereference for first element
        ref var slot = ref slots[key.GetHashCode() & mask];

        if (slot.Key == key)
        {
            value = slot.Value;
            return true;
        }

        // Overflow chain (class nodes, pointer chase — same as current for second+ elements)
        var node = slot.Next;
        while (node is not null)
        {
            if (node.Key == key)
            {
                value = node.Value;
                return true;
            }
            node = node.Next;
        }

        value = default;
        return false;
    }
}

// ---------------------------------------------------------------------------
// Implementation C: Struct-slot with MemoryMarshal.GetReference + Unsafe.Add
// ---------------------------------------------------------------------------
internal sealed class StructSlotMapUnsafe<TValue>
{
    private readonly StructSlot<TValue>[] slots;
    private readonly int mask;

    public StructSlotMapUnsafe(int tableSize)
    {
        var size = (int)BitOperations.RoundUpToPowerOf2((uint)tableSize);
        mask = size - 1;
        slots = new StructSlot<TValue>[size];
    }

    public void Add(Type key, TValue value)
    {
        var index = key.GetHashCode() & mask;
        ref var slot = ref slots[index];
        if (slot.Key is null)
        {
            slot.Key = key;
            slot.Value = value;
        }
        else
        {
            if (slot.Next is null)
            {
                slot.Next = new OverflowNode<TValue>(key, value);
            }
            else
            {
                var last = slot.Next;
                while (last.Next is not null)
                {
                    last = last.Next;
                }
                last.Next = new OverflowNode<TValue>(key, value);
            }
        }
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out TValue value)
    {
        // MemoryMarshal.GetArrayDataReference → base ref of array, no bounds check
        // Unsafe.Add → offset arithmetic without bounds check
        ref var slot = ref Unsafe.Add(
            ref MemoryMarshal.GetArrayDataReference(slots),
            key.GetHashCode() & mask);

        if (slot.Key == key)
        {
            value = slot.Value;
            return true;
        }

        var node = slot.Next;
        while (node is not null)
        {
            if (node.Key == key)
            {
                value = node.Value;
                return true;
            }
            node = node.Next;
        }

        value = default;
        return false;
    }
}

internal struct StructSlot<TValue>
{
    public Type? Key;
    public TValue Value;
    public OverflowNode<TValue>? Next; // null if no overflow
}

#pragma warning disable SA1401
internal sealed class OverflowNode<TValue>(Type key, TValue value)
{
    public readonly Type Key = key;
    public readonly TValue Value = value;
    public OverflowNode<TValue>? Next;
}
#pragma warning restore SA1401

// ---------------------------------------------------------------------------
// FlatSlot: struct array without class-node overflow; HasNext flag; Unsafe.Add stride
// ---------------------------------------------------------------------------

// Flat slot stored in array; overflow goes to next slot via Unsafe.Add stride.
internal struct FlatSlot<TValue>
{
    public Type? Key;
    public TValue Value;
    public bool HasNext; // true → overflow entry exists at [base + stride]
}

// Sequential-layout flat slot for StructLayout comparison.
[StructLayout(LayoutKind.Sequential)]
internal struct FlatSlotSeq<TValue>
{
    public Type? Key;
    public TValue Value;
    public bool HasNext;
}

// ---------------------------------------------------------------------------
// Implementation D: FlatSlot – ref-indexed array access, Unsafe.Add stride
// ---------------------------------------------------------------------------
internal sealed class StructSlotMapFlatRef<TValue>
{
    // Extra capacity: tableSize slots for primaries + tableSize for overflow chain → 2x
    private readonly FlatSlot<TValue>[] slots;
    private readonly int mask;
    private readonly int tableSize;
    private int overflowTop; // next free overflow index (starts at tableSize)

    public StructSlotMapFlatRef(int tableSize)
    {
        var size = (int)BitOperations.RoundUpToPowerOf2((uint)tableSize);
        this.tableSize = size;
        mask = size - 1;
        slots = new FlatSlot<TValue>[size * 2]; // 2x: primary + overflow area
        overflowTop = size;
    }

    public void Add(Type key, TValue value)
    {
        var index = key.GetHashCode() & mask;
        ref var slot = ref slots[index];
        if (slot.Key is null)
        {
            slot.Key = key;
            slot.Value = value;
            return;
        }
        // Walk to last slot in overflow chain
        var cur = index;
        while (slots[cur].HasNext)
        {
            cur += tableSize; // stride = tableSize
        }
        slots[cur].HasNext = true;
        var next = cur + tableSize;
        slots[next].Key = key;
        slots[next].Value = value;
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out TValue value)
    {
        ref var slot = ref slots[key.GetHashCode() & mask];

        while (true)
        {
            if (slot.Key == key)
            {
                value = slot.Value;
                return true;
            }
            if (!slot.HasNext)
            {
                break;
            }
            slot = ref Unsafe.Add(ref slot, tableSize);
        }

        value = default;
        return false;
    }
}

// ---------------------------------------------------------------------------
// Implementation E: FlatSlot – MemoryMarshal.GetArrayDataReference + Unsafe.Add
// ---------------------------------------------------------------------------
internal sealed class StructSlotMapFlatUnsafe<TValue>
{
    private readonly FlatSlot<TValue>[] slots;
    private readonly int mask;
    private readonly int tableSize;

    public StructSlotMapFlatUnsafe(int tableSize)
    {
        var size = (int)BitOperations.RoundUpToPowerOf2((uint)tableSize);
        this.tableSize = size;
        mask = size - 1;
        slots = new FlatSlot<TValue>[size * 2];
    }

    public void Add(Type key, TValue value)
    {
        var index = key.GetHashCode() & mask;
        ref var slot = ref slots[index];
        if (slot.Key is null)
        {
            slot.Key = key;
            slot.Value = value;
            return;
        }
        var cur = index;
        while (slots[cur].HasNext)
        {
            cur += tableSize;
        }
        slots[cur].HasNext = true;
        var next = cur + tableSize;
        slots[next].Key = key;
        slots[next].Value = value;
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out TValue value)
    {
        ref var slot = ref Unsafe.Add(
            ref MemoryMarshal.GetArrayDataReference(slots),
            key.GetHashCode() & mask);

        while (true)
        {
            if (slot.Key == key)
            {
                value = slot.Value;
                return true;
            }
            if (!slot.HasNext)
            {
                break;
            }
            slot = ref Unsafe.Add(ref slot, tableSize);
        }

        value = default;
        return false;
    }
}

// ---------------------------------------------------------------------------
// Implementation F: FlatSlotSeq (LayoutKind.Sequential) + GetArrayDataReference
// ---------------------------------------------------------------------------
internal sealed class StructSlotMapFlatSeq<TValue>
{
    private readonly FlatSlotSeq<TValue>[] slots;
    private readonly int mask;
    private readonly int tableSize;

    public StructSlotMapFlatSeq(int tableSize)
    {
        var size = (int)BitOperations.RoundUpToPowerOf2((uint)tableSize);
        this.tableSize = size;
        mask = size - 1;
        slots = new FlatSlotSeq<TValue>[size * 2];
    }

    public void Add(Type key, TValue value)
    {
        var index = key.GetHashCode() & mask;
        ref var slot = ref slots[index];
        if (slot.Key is null)
        {
            slot.Key = key;
            slot.Value = value;
            return;
        }
        var cur = index;
        while (slots[cur].HasNext)
        {
            cur += tableSize;
        }
        slots[cur].HasNext = true;
        var next = cur + tableSize;
        slots[next].Key = key;
        slots[next].Value = value;
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out TValue value)
    {
        ref var slot = ref Unsafe.Add(
            ref MemoryMarshal.GetArrayDataReference(slots),
            key.GetHashCode() & mask);

        while (true)
        {
            if (slot.Key == key)
            {
                value = slot.Value;
                return true;
            }
            if (!slot.HasNext)
            {
                break;
            }
            slot = ref Unsafe.Add(ref slot, tableSize);
        }

        value = default;
        return false;
    }
}
