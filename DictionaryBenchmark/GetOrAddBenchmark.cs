namespace DictionaryBenchmark
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using BenchmarkDotNet.Attributes;

    public class GetOrAddBenchmark
    {
        private const int Loop = 1000;

        [Benchmark]
        public void Dictionary()
        {
            var table = new Dictionary<Type, object>();

            for (var count = 0; count < Loop; count++)
            {
                for (var i = 0; i < Classes.Types.Length; i++)
                {
                    var key = Classes.Types[i];
                    if (!table.TryGetValue(key, out object _))
                    {
                        table[key] = new object();
                    }
                }
            }
        }

        [Benchmark]
        public void DictionaryWithLock()
        {
            var sync = new object();
            var table = new Dictionary<Type, object>();

            for (var count = 0; count < Loop; count++)
            {
                for (var i = 0; i < Classes.Types.Length; i++)
                {
                    lock (sync)
                    {
                        var key = Classes.Types[i];
                        if (!table.TryGetValue(key, out object _))
                        {
                            table[key] = new object();
                        }
                    }
                }
            }
        }

        [Benchmark]
        public void ConcurrentDictionary()
        {
            var table = new ConcurrentDictionary<Type, object>();

            for (var count = 0; count < Loop; count++)
            {
                for (var i = 0; i < Classes.Types.Length; i++)
                {
                    var key = Classes.Types[i];
                    if (!table.TryGetValue(key, out object _))
                    {
                        table[key] = new object();
                    }
                }
            }
        }
    }
}
