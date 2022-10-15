using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SmallLookupBenchmark
{
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public sealed class MetadataHashArray
    {
        private const int InitialSize = 256;

        private const double Factor = 2;

        private static readonly Node[] EmptyNodes = new Node[0];

        private readonly object sync = new object();

        private Table table;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        public MetadataHashArray()
        {
            table = CreateInitialTable();
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CalculateHash(int slot, Type type)
        {
            unchecked
            {
                //return type.GetHashCode() ^ (slot * 397);
                return type.GetHashCode() + slot;
            }
        }

        private static uint CalculateSize(int count)
        {
            uint size = 0;

            for (var i = 1L; i < count; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return size + 1;
        }

        private Table CreateInitialTable()
        {
            var mask = InitialSize - 1;
            var nodes = new Node[InitialSize][];

            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = EmptyNodes;
            }

            return new Table(mask, nodes, 0);
        }

        private static Node[] AddNode(Node[] nodes, Node addNode)
        {
            if (nodes == null)
            {
                return new[] { addNode };
            }

            var newNodes = new Node[nodes.Length + 1];
            Array.Copy(nodes, 0, newNodes, 0, nodes.Length);
            newNodes[nodes.Length] = addNode;

            return newNodes;
        }

        private static void RelocateNodes(Node[][] nodes, Node[][] oldNodes, int mask)
        {
            for (var i = 0; i < oldNodes.Length; i++)
            {
                for (var j = 0; j < oldNodes[i].Length; j++)
                {
                    var node = oldNodes[i][j];
                    var relocateIndex = CalculateHash(node.Slot, node.Type) & mask;
                    nodes[relocateIndex] = AddNode(nodes[relocateIndex], node);
                }
            }
        }

        private static void FillEmptyIfNull(Node[][] nodes)
        {
            for (var i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == null)
                {
                    nodes[i] = EmptyNodes;
                }
            }
        }

        private Table CreateAddTable(Table oldTable, Node node)
        {
            var requestSize = Math.Max(InitialSize, (int)Math.Ceiling((oldTable.Count + 1) * Factor));

            var size = CalculateSize(requestSize);
            var mask = (int)(size - 1);
            var newNodes = new Node[size][];

            RelocateNodes(newNodes, oldTable.Nodes, mask);

            var index = CalculateHash(node.Slot, node.Type) & mask;
            newNodes[index] = AddNode(newNodes[index], node);

            FillEmptyIfNull(newNodes);

            return new Table(mask, newNodes, oldTable.Count + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetValueInternal(Table targetTable, int slot, Type type, out object value)
        {
            var index = CalculateHash(slot, type) & targetTable.HashMask;
            var array = targetTable.Nodes[index];
            for (var i = 0; i < array.Length; i++)
            {
                var node = array[i];
                if ((node.Slot == slot) && (node.Type == type))
                {
                    value = node.Value;
                    return true;
                }
            }

            value = null;
            return false;
        }

        //--------------------------------------------------------------------------------
        // Public
        //--------------------------------------------------------------------------------

        public int Count => table.Count;

        public void Clear()
        {
            lock (sync)
            {
                var newTable = CreateInitialTable();
                Interlocked.MemoryBarrier();
                table = newTable;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(int slot, Type type, out object value)
        {
            return TryGetValueInternal(table, slot, type, out value);
        }

        public object AddIfNotExist(int slot, Type type, Func<Type, object> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, slot, type, out var currentValue))
                {
                    return currentValue;
                }

                var value = valueFactory(type);

                // Check if added by recursive
                if (TryGetValueInternal(table, slot, type, out currentValue))
                {
                    return currentValue;
                }

                // Rebuild
                var newTable = CreateAddTable(table, new Node(slot, type, value));
                Interlocked.MemoryBarrier();
                table = newTable;

                return value;
            }
        }
        //--------------------------------------------------------------------------------
        // Inner
        //--------------------------------------------------------------------------------

        private class Node
        {
            public int Slot { get; }

            public Type Type { get; }

            public object Value { get; }

            public Node(int slot, Type type, object value)
            {
                Slot = slot;
                Type = type;
                Value = value;
            }
        }

        private class Table
        {
            public int HashMask { get; }

            public Node[][] Nodes { get; }

            public int Count { get; }

            public Table(int hashMask, Node[][] nodes, int count)
            {
                HashMask = hashMask;
                Nodes = nodes;
                Count = count;
            }
        }
    }
}
