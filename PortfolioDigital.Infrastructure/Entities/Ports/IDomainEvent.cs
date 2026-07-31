namespace PortfolioDigital.Infrastructure.Entities
{
    public interface IDomainEvent
    {
        DateTime OccurredAtUtc { get; }
    }
}