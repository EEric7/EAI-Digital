namespace PortfolioDigital.Infrastructure.Entities
{
    public abstract class AEntityInt : AggregateRoot
    {
        public int Id { get; protected set; } = default;
    }
}