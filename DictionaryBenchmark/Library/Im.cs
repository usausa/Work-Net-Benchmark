namespace DictionaryBenchmark.Library
{
    using System;
    using System.Runtime.CompilerServices;

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

        internal ImTreeMap<TKey, TValue> AddOrUpdate(int hash, TKey key, TValue value)
        {
            return Height == 0 ? new ImTreeMap<TKey, TValue>(hash, key, value, null, Empty, Empty)
                : (hash == Hash ? UpdateValueAndResolveConflicts(key, value)
                    : (hash < Hash
                        ? With(Left.AddOrUpdate(hash, key, value), Right)
                        : With(Left, Right.AddOrUpdate(hash, key, value))).KeepBalanced());
        }

        private ImTreeMap<TKey, TValue> UpdateValueAndResolveConflicts(TKey key, TValue value)
        {
            if (ReferenceEquals(Key, key) || Key.Equals(key))
                return new ImTreeMap<TKey, TValue>(Hash, key, value, Conflicts, Left, Right);

            if (Conflicts == null) // add only if updateOnly is false.
                return new ImTreeMap<TKey, TValue>(Hash, Key, Value, new[] { new KeyValue<TKey, TValue>(key, value) }, Left, Right);

            var found = Conflicts.Length - 1;
            while (found >= 0 && !Equals(Conflicts[found].Key, Key)) --found;

            if (found == -1)
            {
                var newConflicts = new KeyValue<TKey, TValue>[Conflicts.Length + 1];
                Array.Copy(Conflicts, 0, newConflicts, 0, Conflicts.Length);
                newConflicts[Conflicts.Length] = new KeyValue<TKey, TValue>(key, value);
                return new ImTreeMap<TKey, TValue>(Hash, Key, Value, newConflicts, Left, Right);
            }

            var conflicts = new KeyValue<TKey, TValue>[Conflicts.Length];
            Array.Copy(Conflicts, 0, conflicts, 0, Conflicts.Length);
            conflicts[found] = new KeyValue<TKey, TValue>(key, value);
            return new ImTreeMap<TKey, TValue>(Hash, Key, Value, conflicts, Left, Right);
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

        internal TValue GetConflictedValueOrDefault(TKey key, TValue defaultValue)
        {
            if (Conflicts != null)
                for (var i = 0; i < Conflicts.Length; i++)
                    if (Equals(Conflicts[i].Key, key))
                        return Conflicts[i].Value;
            return defaultValue;
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

            tree = tree.AddOrUpdate(hash, key, value);

            var newTrees = new ImTreeMap<TKey, TValue>[NumberOfTrees];
            Array.Copy(trees, 0, newTrees, 0, NumberOfTrees);
            newTrees[treeIndex] = tree;

            return new ImMap<TKey, TValue>(newTrees, Count + 1);
        }
    }
}
