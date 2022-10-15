namespace ResultMapperCacheBenchmark
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal sealed class StructPropertyResultMapperCache
    {
        private static readonly Node EmptyNode = new Node(typeof(EmptyKey), Array.Empty<StructPropertyColumnInfo>(), default);

        private const int InitialSize = 64;

        private const int Factor = 3;

        private readonly object sync = new object();

        private Node[] nodes;

        private int depth;

        private int count;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        public StructPropertyResultMapperCache()
        {
            nodes = CreateInitialTable();
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CalculateHash(Type targetType, Span<StructPropertyColumnInfo> columns)
        {
            unchecked
            {
                var hash = targetType.GetHashCode();
                for (var i = 0; i < columns.Length; i++)
                {
                    hash = (hash * 31) + (columns[i].Name.GetHashCode(StringComparison.OrdinalIgnoreCase) ^ columns[i].Type.GetHashCode());
                }
                return hash;
            }
        }

        private static int CalculateDepth(Node node)
        {
            var length = 0;

            do
            {
                length++;
                node = node.Next;
            }
            while (node != null);

            return length;
        }

        private static int CalculateDepth(Node[] targetNodes)
        {
            var depth = 0;

            for (var i = 0; i < targetNodes.Length; i++)
            {
                var node = targetNodes[i];
                if (node != EmptyNode)
                {
                    depth = Math.Max(CalculateDepth(node), depth);
                }
            }

            return depth;
        }

        private static int CalculateSize(int requestSize)
        {
            uint size = 0;

            for (var i = 1L; i < requestSize; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return (int)(size + 1);
        }

        private static Node[] CreateInitialTable()
        {
            var newNodes = new Node[InitialSize];

            for (var i = 0; i < newNodes.Length; i++)
            {
                newNodes[i] = EmptyNode;
            }

            return newNodes;
        }

        private static Node FindLastNode(Node node)
        {
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }

        private static void UpdateLink(ref Node node, Node addNode)
        {
            if (node == EmptyNode)
            {
                node = addNode;
            }
            else
            {
                var last = FindLastNode(node);
                last.Next = addNode;
            }
        }

        private static void RelocateNodes(Node[] nodes, Node[] oldNodes)
        {
            for (var i = 0; i < oldNodes.Length; i++)
            {
                var node = oldNodes[i];
                if (node == EmptyNode)
                {
                    continue;
                }

                do
                {
                    var next = node.Next;
                    node.Next = null;

                    UpdateLink(ref nodes[CalculateHash(node.TargetType, node.Columns) & (nodes.Length - 1)], node);

                    node = next;
                }
                while (node != null);
            }
        }

        private void AddNode(Node node)
        {
            var requestSize = Math.Max(InitialSize, (count + 1) * Factor);
            var size = CalculateSize(requestSize);
            if (size > nodes.Length)
            {
                var newNodes = new Node[size];
                for (var i = 0; i < newNodes.Length; i++)
                {
                    newNodes[i] = EmptyNode;
                }

                RelocateNodes(newNodes, nodes);

                UpdateLink(ref newNodes[CalculateHash(node.TargetType, node.Columns) & (newNodes.Length - 1)], node);

                Interlocked.MemoryBarrier();

                nodes = newNodes;
                depth = CalculateDepth(newNodes);
                count++;
            }
            else
            {
                Interlocked.MemoryBarrier();

                var hash = CalculateHash(node.TargetType, node.Columns);

                UpdateLink(ref nodes[hash & (nodes.Length - 1)], node);

                depth = Math.Max(CalculateDepth(nodes[hash & (nodes.Length - 1)]), depth);
                count++;
            }
        }

        //--------------------------------------------------------------------------------
        // Public
        //--------------------------------------------------------------------------------

        public void Clear()
        {
            lock (sync)
            {
                var newNodes = CreateInitialTable();

                Interlocked.MemoryBarrier();

                nodes = newNodes;
                depth = 0;
                count = 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsMatchColumn(StructPropertyColumnInfo[] columns1, Span<StructPropertyColumnInfo> columns2)
        {
            if (columns1.Length != columns2.Length)
            {
                return false;
            }

            for (var i = 0; i < columns1.Length; i++)
            {
                var column1 = columns1[i];
                var column2 = columns2[i];

                if (column1.Type != column2.Type)
                {
                    return false;
                }

                if (String.Compare(column1.Name, column2.Name, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(Type targetType, Span<StructPropertyColumnInfo> columns, out object value)
        {
            var temp = nodes;
            var node = temp[CalculateHash(targetType, columns) & (temp.Length - 1)];
            do
            {
                if (node.TargetType == targetType && IsMatchColumn(node.Columns, columns))
                {
                    value = node.Value;
                    return true;
                }
                node = node.Next;
            }
            while (node != null);

            value = default;
            return false;
        }

        public object AddIfNotExist(Type targetType, Span<StructPropertyColumnInfo> columns, Func<Type, StructPropertyColumnInfo[], object> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValue(targetType, columns, out var currentValue))
                {
                    return currentValue;
                }

                var copyColumns = new StructPropertyColumnInfo[columns.Length];
                columns.CopyTo(new Span<StructPropertyColumnInfo>(copyColumns));

                var value = valueFactory(targetType, copyColumns);

                // Check if added by recursive
                if (TryGetValue(targetType, columns, out currentValue))
                {
                    return currentValue;
                }

                AddNode(new Node(targetType, copyColumns, value));

                return value;
            }
        }

        //--------------------------------------------------------------------------------
        // Inner
        //--------------------------------------------------------------------------------

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Framework only")]
        private sealed class EmptyKey
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Performance")]
        private sealed class Node
        {
            public Type TargetType { get; }

            public StructPropertyColumnInfo[] Columns { get; }

            public object Value { get; }

            public Node Next { get; set; }

            public Node(Type targetType, StructPropertyColumnInfo[] columns, object value)
            {
                TargetType = targetType;
                Columns = columns;
                Value = value;
            }
        }
    }
}
