namespace ResultMapperCacheBenchmark
{
    using System;

    public struct StructPropertyColumnInfo : IEquatable<StructPropertyColumnInfo>
    {
        public string Name { get; }

        public Type Type { get; }

        public StructPropertyColumnInfo(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification = "Ignore")]
        public override int GetHashCode() => Name.GetHashCode(StringComparison.OrdinalIgnoreCase) ^ Type.GetHashCode();

        public override bool Equals(object obj) => obj is StructPropertyColumnInfo other && Equals(other);

        public bool Equals(StructPropertyColumnInfo other) => Name == other.Name && Type == other.Type;

        public static bool operator ==(StructPropertyColumnInfo x, StructPropertyColumnInfo y) => x.Equals(y);

        public static bool operator !=(StructPropertyColumnInfo x, StructPropertyColumnInfo y) => !x.Equals(y);
    }
}
