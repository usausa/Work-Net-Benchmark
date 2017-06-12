namespace DictionaryBenchmark.Library
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public class ConcurrentHashArrayMap<TKey, TValue>
    {
        private static readonly Node[] EmptyNodes = new Node[0];

        private readonly object sync = new object();

        private Table table;

        //--------------------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------------------

        // TODO Auto? 初期数、成長判定ストラテジ？ デフォルトは個数固定？
        // TODO AddRange?

        /// <summary>
        ///
        /// </summary>
        /// <param name="count"></param>
        public ConcurrentHashArrayMap(int count)
        {
            table = CreateClearTable(count);
        }

        //--------------------------------------------------------------------------------
        // Private
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private static int CalculateMask(int count)
        {
            var mask = 0;

            for (var i = 1L; i < count; i *= 2)
            {
                mask = (mask << 1) + 1;
            }

            return mask;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="count"></param>
        private static Table CreateClearTable(int count)
        {
            // TODO Resize?
            var mask = CalculateMask(count);

            var nodes = new Node[mask + 1L][];
            for (var i = 0; i < nodes.Length; i++)
            {
                nodes[i] = EmptyNodes;
            }

            return new Table(mask, nodes, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Table CreateAddTable(Table target, TKey key, TValue value)
        {
            // TODO Resizeと再配置?
            var index = key.GetHashCode() & target.HashMask;

            var newNodes = new Node[target.Nodes.Length][];

            for (var i = 0; i < target.Nodes.Length; i++)
            {
                var oldLength = target.Nodes[i].Length;
                var newLength = oldLength + (i == index ? 1 : 0);
                if (newLength > 0)
                {
                    newNodes[i] = new Node[newLength];
                    if (oldLength > 0)
                    {
                        Array.Copy(target.Nodes[i], 0, newNodes[i], 0, oldLength);
                    }
                }
                else
                {
                    newNodes[i] = EmptyNodes;
                }
            }

            newNodes[index][newNodes[index].Length - 1] = new Node(key, value);

            return new Table(CalculateMask(newNodes.Length), newNodes, target.Count + 1);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetValueInternal(Table table, TKey key, out TValue value)
        {
            var index = key.GetHashCode() & table.HashMask;
            var array = table.Nodes[index];
            for (var i = 0; i < array.Length; i++)
            {
                if (ReferenceEquals(array[i].Key, key) || array[i].Key.Equals(key))
                {
                    value = array[i].Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }

        //--------------------------------------------------------------------------------
        // Public
        //--------------------------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        public int Count => table.Count;

        public void Clear()
        {
            lock (sync)
            {
                var newTable = CreateClearTable(table.Count);
                Interlocked.Exchange(ref table, newTable);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value)
        {
            return TryGetValueInternal(table, key, out value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueFactory"></param>
        /// <returns></returns>
        public TValue AddIfNotExist(TKey key, Func<TKey, TValue> valueFactory)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, key, out TValue currentValue))
                {
                    return currentValue;
                }

                // Rebuild
                var value = valueFactory(key);
                var newTable = CreateAddTable(table, key, value);
                Interlocked.Exchange(ref table, newTable);

                return value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public TValue AddIfNotExist(TKey key, TValue value)
        {
            lock (sync)
            {
                // Double checked locking
                if (TryGetValueInternal(table, key, out TValue currentValue))
                {
                    return currentValue;
                }

                // Rebuild
                var newTable = CreateAddTable(table, key, value);
                Interlocked.Exchange(ref table, newTable);

                return value;
            }
        }

        //--------------------------------------------------------------------------------
        // Helper
        //--------------------------------------------------------------------------------

        public TValue this[TKey key]
        {
            get
            {
                if (!TryGetValue(key, out TValue value))
                {
                    throw new KeyNotFoundException();
                }
                return value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(TKey key)
        {
            return TryGetValue(key, out TValue _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue))
        {
            return TryGetValue(key, out TValue value) ? value : defaultValue;
        }

        //--------------------------------------------------------------------------------
        // Node
        //--------------------------------------------------------------------------------

        private class Node
        {
            public TKey Key { get; }

            public TValue Value { get; }

            public Node(TKey key, TValue value)
            {
                Key = key;
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
