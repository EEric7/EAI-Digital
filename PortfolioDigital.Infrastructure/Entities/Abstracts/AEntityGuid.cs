namespace PortfolioDigital.Infrastructure.Entities
{
    public abstract class AEntityGuid : AggregateRoot
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
    }
}