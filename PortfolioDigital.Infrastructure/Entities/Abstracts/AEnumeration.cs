namespace PortfolioDigital.Infrastructure.Entities
{
    public abstract class AEnumeration : IEquatable<AEnumeration>
    {
        public int Id { get; }
        public string Name { get; }

        protected AEnumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public bool Equals(AEnumeration? other) => other != null && Id == other.Id;

        public override bool Equals(object? obj) => obj is AEnumeration other && Equals(other);

        public override int GetHashCode() => Id.GetHashCode();
    }
}