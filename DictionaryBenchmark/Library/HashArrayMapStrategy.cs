namespace DictionaryBenchmark.Library
{
    using System;

    public interface IHashArrayMapResizeContext
    {
        int Width { get; }

        int Growth { get; }

        int Count { get; }
    }

    public interface IHashArrayMapStrategy
    {
        int CalcInitialSize();

        int CalcRequestSize(IHashArrayMapResizeContext context);
    }

    public class FixedSizeHashArrayMapStrategy : IHashArrayMapStrategy
    {
        private readonly int size;

        public FixedSizeHashArrayMapStrategy(int size)
        {
            this.size = size;
        }

        public int CalcInitialSize()
        {
            return size;
        }

        public int CalcRequestSize(IHashArrayMapResizeContext context)
        {
            return size;
        }
    }

    public class GrowthHashArrayMapStrategy : IHashArrayMapStrategy
    {
        private readonly int initialSize;

        private readonly double factor;

        public GrowthHashArrayMapStrategy(int initialSize, double factor = 1.0)
        {
            this.initialSize = initialSize;
            this.factor = factor;
        }

        public int CalcInitialSize()
        {
            return initialSize;
        }

        public int CalcRequestSize(IHashArrayMapResizeContext context)
        {
            return (int)Math.Ceiling((context.Count + context.Growth) * factor);
        }
    }
}
