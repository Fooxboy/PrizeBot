namespace PrizeBot.Domain.Models.Draws;

public abstract class DomainEvent
{
    public Guid Id { get; set; }
}