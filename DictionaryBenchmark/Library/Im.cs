namespace DictionaryBenchmark.Library
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate TValue Update<TValue>(TValue oldValue, TValue newValue);


    public sealed class ImTreeMap<TKey, TValue>
    {
        public static readonly ImTreeMap<TKey, TValue> Empty = new ImTreeMap<TKey, TValue>();

        public readonly TKey Key;

        public readonly TValue Value;

        public readonly int Hash;

        public readonly KeyValue<TKey, TValue>[] Conflicts;

        public readonly ImTreeMap<TKey, TValue> Left;

        public readonly ImTreeMap<TKey, TValue> Right;

        public readonly int Height;

        public bool IsEmpty => Height == 0;

        public ImTreeMap<TKey, TValue> AddOrUpdate(TKey key, TValue value, Update<TValue> update = null)
        {
            return AddOrUpdate(key.GetHashCode(), key, value, update, updateOnly: false);
        }

        //public ImTreeMap<K, V> Update(K key, V value, Update<V> update = null)
        //{
        //    return AddOrUpdate(key.GetHashCode(), key, value, update, updateOnly: true);
        //}

        //public V GetValueOrDefault(K key, V defaultValue = default(V))
        //{
        //    var t = this;
        //    var hash = key.GetHashCode();
        //    while (t.Height != 0 && t.Hash != hash)
        //        t = hash < t.Hash ? t.Left : t.Right;
        //    return t.Height != 0 && (ReferenceEquals(key, t.Key) || key.Equals(t.Key))
        //        ? t.Value : t.GetConflictedValueOrDefault(key, defaultValue);
        //}

        //public IEnumerable<KeyValue<K, V>> Enumerate()
        //{
        //    if (Height == 0)
        //        yield break;

        //    var parents = new ImTreeMap<K, V>[Height];

        //    var tree = this;
        //    var parentCount = -1;
        //    while (tree.Height != 0 || parentCount != -1)
        //    {
        //        if (tree.Height != 0)
        //        {
        //            parents[++parentCount] = tree;
        //            tree = tree.Left;
        //        }
        //        else
        //        {
        //            tree = parents[parentCount--];
        //            yield return new KeyValue<K, V>(tree.Key, tree.Value);

        //            if (tree.Conflicts != null)
        //                for (var i = 0; i < tree.Conflicts.Length; i++)
        //                    yield return tree.Conflicts[i];

        //            tree = tree.Right;
        //        }
        //    }
        //}

        public ImTreeMap()
        {
        }

        private ImTreeMap(int hash, TKey key, TValue value, KeyValue<TKey, TValue>[] conficts, ImTreeMap<TKey, TValue> left, ImTreeMap<TKey, TValue> right)
        {
            Hash = hash;
            Key = key;
            Value = value;
            Conflicts = conficts;
            Left = left;
            Right = right;
            Height = 1 + (left.Height > right.Height ? left.Height : right.Height);
        }

        internal ImTreeMap<TKey, TValue> AddOrUpdate(int hash, TKey key, TValue value, Update<TValue> update, bool updateOnly)
        {
            return Height == 0 ? (updateOnly ? this : new ImTreeMap<TKey, TValue>(hash, key, value, null, Empty, Empty))
                : (hash == Hash ? UpdateValueAndResolveConflicts(key, value, update, updateOnly)
                    : (hash < Hash
                        ? With(Left.AddOrUpdate(hash, key, value, update, updateOnly), Right)
                        : With(Left, Right.AddOrUpdate(hash, key, value, update, updateOnly))).KeepBalanced());
        }

        private ImTreeMap<TKey, TValue> UpdateValueAndResolveConflicts(TKey key, TValue value, Update<TValue> update, bool updateOnly)
        {
            if (ReferenceEquals(Key, key) || Key.Equals(key))
                return new ImTreeMap<TKey, TValue>(Hash, key, update == null ? value : update(Value, value), Conflicts, Left, Right);

            if (Conflicts == null) // add only if updateOnly is false.
                return updateOnly ? this
                    : new ImTreeMap<TKey, TValue>(Hash, Key, Value, new[] { new KeyValue<TKey, TValue>(key, value) }, Left, Right);

            var found = Conflicts.Length - 1;
            while (found >= 0 && !Equals(Conflicts[found].Key, Key)) --found;
            if (found == -1)
            {
                if (updateOnly) return this;
                var newConflicts = new KeyValue<TKey, TValue>[Conflicts.Length + 1];
                Array.Copy(Conflicts, 0, newConflicts, 0, Conflicts.Length);
                newConflicts[Conflicts.Length] = new KeyValue<TKey, TValue>(key, value);
                return new ImTreeMap<TKey, TValue>(Hash, Key, Value, newConflicts, Left, Right);
            }

            var conflicts = new KeyValue<TKey, TValue>[Conflicts.Length];
            Array.Copy(Conflicts, 0, conflicts, 0, Conflicts.Length);
            conflicts[found] = new KeyValue<TKey, TValue>(key, update == null ? value : update(Conflicts[found].Value, value));
            return new ImTreeMap<TKey, TValue>(Hash, Key, Value, conflicts, Left, Right);
        }

        internal TValue GetConflictedValueOrDefault(TKey key, TValue defaultValue)
        {
            if (Conflicts != null)
                for (var i = 0; i < Conflicts.Length; i++)
                    if (Equals(Conflicts[i].Key, key))
                        return Conflicts[i].Value;
            return defaultValue;
        }

        private ImTreeMap<TKey, TValue> KeepBalanced()
        {
            var delta = Left.Height - Right.Height;
            return delta >= 2 ? With(Left.Right.Height - Left.Left.Height == 1 ? Left.RotateLeft() : Left, Right).RotateRight()
                : (delta <= -2 ? With(Left, Right.Left.Height - Right.Right.Height == 1 ? Right.RotateRight() : Right).RotateLeft()
                    : this);
        }

        private ImTreeMap<TKey, TValue> RotateRight()
        {
            return Left.With(Left.Left, With(Left.Right, Right));
        }

        private ImTreeMap<TKey, TValue> RotateLeft()
        {
            return Right.With(With(Left, Right.Left), Right.Right);
        }

        private ImTreeMap<TKey, TValue> With(ImTreeMap<TKey, TValue> left, ImTreeMap<TKey, TValue> right)
        {
            return left == Left && right == Right ? this : new ImTreeMap<TKey, TValue>(Hash, Key, Value, Conflicts, left, right);
        }
    }

    public sealed class ImMap<TKey, TValue>
    {
        private const int NumberOfTrees = 32;
        private const int HashBitsToTree = NumberOfTrees - 1;  // get last 4 bits, fast (hash % NumberOfTrees)

        public static readonly ImMap<TKey, TValue> Empty = new ImMap<TKey, TValue>(new ImTreeMap<TKey, TValue>[NumberOfTrees], 0);

        public readonly int Count;

        public bool IsEmpty => Count == 0;

        private readonly ImTreeMap<TKey, TValue>[] _trees;

        private ImMap(ImTreeMap<TKey, TValue>[] newTrees, int count)
        {
            _trees = newTrees;
            Count = count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue))
        {
            var hash = key.GetHashCode();

            var t = _trees[hash & HashBitsToTree];
            if (t == null)
                return defaultValue;

            while (t.Height != 0 && t.Hash != hash)
                t = hash < t.Hash ? t.Left : t.Right;

            if (t.Height != 0 && (ReferenceEquals(key, t.Key) || key.Equals(t.Key)))
                return t.Value;

            return t.GetConflictedValueOrDefault(key, defaultValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ImMap<TKey, TValue> AddOrUpdate(TKey key, TValue value)
        {
            var hash = key.GetHashCode();

            var treeIndex = hash & HashBitsToTree;

            var trees = _trees;
            var tree = trees[treeIndex] ?? ImTreeMap<TKey, TValue>.Empty;

            tree = tree.AddOrUpdate(hash, key, value, null, false);

            var newTrees = new ImTreeMap<TKey, TValue>[NumberOfTrees];
            Array.Copy(trees, 0, newTrees, 0, NumberOfTrees);
            newTrees[treeIndex] = tree;

            return new ImMap<TKey, TValue>(newTrees, Count + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ImMap<TKey, TValue> Update(TKey key, TValue value)
        {
            var hash = key.GetHashCode();

            var treeIndex = hash & HashBitsToTree;

            var trees = _trees;
            var tree = trees[treeIndex];
            if (tree == null)
                return this;

            var newTree = tree.AddOrUpdate(hash, key, value, null, true);
            if (newTree == tree)
                return this;

            var newTrees = new ImTreeMap<TKey, TValue>[NumberOfTrees];
            Array.Copy(trees, 0, newTrees, 0, NumberOfTrees);
            newTrees[treeIndex] = newTree;

            return new ImMap<TKey, TValue>(newTrees, Count);
        }
    }
}
