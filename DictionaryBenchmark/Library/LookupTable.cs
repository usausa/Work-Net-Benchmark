using System;

namespace DictionaryBenchmark.Library
{
    using System.Runtime.CompilerServices;

    public class LookupTable<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get; }

            public TValue Value { get; }

            public Node Next { get; set; }

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly int hashCount;

        private readonly Node[] tables;

        public LookupTable(int hashCount)
        {
            this.hashCount = hashCount;
            tables = new Node[hashCount];
        }

        public void Add(TKey key, TValue value)
        {
            var index = key.GetHashCode() % hashCount;

            var node = tables[index];
            if (node == null)
            {
                tables[index] = new Node(key, value);
                return;
            }

            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(key, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue GetOrAdd(TKey key, Func<TKey, TValue> factory)
        {
            var index = key.GetHashCode() % hashCount;

            var node = tables[index];
            while (node != null)
            {
                if (key.Equals(node.Key))
                {
                    return node.Value;
                }

                node = node.Next;
            }

            var value = factory(key);
            tables[index] = new Node(key, value);
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = key.GetHashCode() % hashCount;

            var node = tables[index];
            while (node != null)
            {
                if (key.Equals(node.Key))
                {
                    value = node.Value;
                    return true;
                }

                node = node.Next;
            }

            value = default(TValue);
            return false;
        }
    }
}
