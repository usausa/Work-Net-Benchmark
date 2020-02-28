namespace Benchmarks
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [DebuggerDisplay("{" + nameof(count) + "}")]
    internal sealed class TypeHashArrayMap<TValue>
    {
        private static readonly Node EmptyNode = new Node(typeof(EmptyKey), default);

        private const int InitialSize = 64;

        private const int Factor = 3;

        private readonly object sync = new object();

        private Node[] nodes;

        private int count;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        public TypeHashArrayMap()
        {
            nodes = CreateInitialTable();
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        private static int CalculateSize(int requestSize)
        {
            uint size = 0;

            for (var i = 1L; i < requestSize; i *= 2)
            {
                size = (size << 1) + 1;
            }

            return (int)(size + 1);
        }

        private static int CalculateCount(Node[] targetNodes)
        {
            var count = 0;
            for (var i = 0; i < targetNodes.Length; i++)
            {
                var node = targetNodes[i];
                if (node != EmptyNode)
                {
                    do
                    {
                        count++;
                        node = node.Next;
                    }
                    while (node != null);
                }
            }

            return count;
        }

        private Node[] CreateInitialTable()
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

                    UpdateLink(ref nodes[node.Key.GetHashCode() & (nodes.Length - 1)], node);

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

                UpdateLink(ref newNodes[node.Key.GetHashCode() & (newNodes.Length - 1)], node);

                Interlocked.MemoryBarrier();

                nodes = newNodes;
                count = CalculateCount(newNodes);
            }
            else
            {
                Interlocked.MemoryBarrier();

                UpdateLink(ref nodes[node.Key.GetHashCode() & (nodes.Length - 1)], node);

                count++;
            }
        }

        //--------------------------------------------------------------------------------
        // Public
        //--------------------------------------------------------------------------------

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Performance")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(Type key, out TValue value)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            var copy = nodes;
            var node = copy[key.GetHashCode() & (copy.Length - 1)];
            do
            {
                if (node.Key == key)
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

        public TValue AddIfNotExist(Type key, TValue value)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValue(key, out var currentValue))
                {
                    return currentValue;
                }

                AddNode(new Node(key, value));

                return value;
            }
        }

        public TValue AddIfNotExist(Type key, Func<Type, TValue> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValue(key, out var currentValue))
                {
                    return currentValue;
                }

                var value = valueFactory(key);

                // Check if added by recursive
                if (TryGetValue(key, out currentValue))
                {
                    return currentValue;
                }

                AddNode(new Node(key, value));

                return value;
            }
        }

        //--------------------------------------------------------------------------------
        // Inner
        //--------------------------------------------------------------------------------

        private sealed class EmptyKey
        {
        }

        private sealed class Node
        {
            public readonly Type Key;

            public readonly TValue Value;

            public Node Next;

            public Node(Type key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
