using PrizeBot.Domain.Models.Draws;

namespace PrizeBot.Domain.Draws;

public class TicketDomainModel : BaseDomainModel
{
    public Owner Owner { get; set; }
    
    public DateTime CreatedTime { get; set; }

    public TicketDomainModel(string ownerName, long telegramId, DateTime createdTime)
    {
        this.Owner = new Owner() { Name = ownerName, TelegramId = telegramId };
        this.CreatedTime = createdTime;
    }
}