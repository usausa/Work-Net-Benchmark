namespace DictionaryBenchmark.Library
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class HashListLookupTable<TKey, TValue>
    {
        private readonly int hashCount;

        private readonly List<KeyValue<TKey, TValue>>[] tables;

        public HashListLookupTable(int hashCount)
        {
            this.hashCount = hashCount;
            tables = new List<KeyValue<TKey, TValue>>[hashCount];
            for (var i = 0; i < hashCount; i++)
            {
                tables[i] = new List<KeyValue<TKey, TValue>>();
            }
        }

        public void Add(TKey key, TValue value)
        {
            var index = key.GetHashCode() % hashCount;
            tables[index].Add(new KeyValue<TKey, TValue>(key, value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = key.GetHashCode() % hashCount;

            var list = tables[index];
            var length = list.Count;
            for (var i = 0; i < length; i++)
            {
                if (list[i].Key.Equals(key))
                {
                    value = list[i].Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }
    }
}
