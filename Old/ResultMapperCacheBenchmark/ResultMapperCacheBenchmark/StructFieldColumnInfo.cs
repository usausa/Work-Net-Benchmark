namespace ResultMapperCacheBenchmark
{
    using System;

    public struct StructFieldColumnInfo : IEquatable<StructFieldColumnInfo>
    {
        public readonly string Name;

        public readonly Type Type;

        public StructFieldColumnInfo(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification = "Ignore")]
        public override int GetHashCode() => Name.GetHashCode(StringComparison.OrdinalIgnoreCase) ^ Type.GetHashCode();

        public override bool Equals(object obj) => obj is StructFieldColumnInfo other && Equals(other);

        public bool Equals(StructFieldColumnInfo other) => Name == other.Name && Type == other.Type;

        public static bool operator ==(StructFieldColumnInfo x, StructFieldColumnInfo y) => x.Equals(y);

        public static bool operator !=(StructFieldColumnInfo x, StructFieldColumnInfo y) => !x.Equals(y);
    }
}
