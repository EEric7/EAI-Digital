namespace PortfolioDigital.Infrastructure.Entities
{
    public abstract class AEntityString : AggregateRoot
    {
        public string Id { get; protected set; } = Guid.NewGuid().ToString();
    }
}