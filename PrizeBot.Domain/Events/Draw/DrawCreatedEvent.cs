using PrizeBot.Domain.Draws;
using PrizeBot.Domain.Models.Draws;

namespace PrizeBot.Domain.Events.Draw;

public class DrawCreatedEvent : DomainEvent
{
    public DrawDomainModel DrawDomainModel { get; set; } 
}