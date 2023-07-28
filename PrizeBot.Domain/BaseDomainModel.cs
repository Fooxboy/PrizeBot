using PrizeBot.Domain.Models.Draws;

namespace PrizeBot.Domain;

public class BaseDomainModel
{
    public Guid Id { get; private set; }

    public List<DomainEvent> Events { get; } = new();

    public void AddEvent(DomainEvent @event)
    {
        Events.Add(@event);
    }
    
    public void RemoveEvent(DomainEvent @event)
    {
        Events.Remove(@event);
    }
    
    public void RemoveEvent(Guid eventId)
    {
        var domainEvent = Events.FirstOrDefault(x => x.Id == eventId);

        if (domainEvent is null) return;

        Events.Remove(domainEvent);
    }
}