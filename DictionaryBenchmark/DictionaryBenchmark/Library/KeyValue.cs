﻿namespace DictionaryBenchmark.Library
{
    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; }

        public TValue Value { get; }

        public KeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
