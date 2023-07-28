namespace PrizeBot.Domain.Draws;

public class DrawDomainModel : BaseDomainModel
{
    public string Title { get; private set; }
    
    public IEnumerable<Guid> Tickets { get; private set; }
    
    public DateTime DateStart { get; private set; }
    
    public DateTime? DateEnd { get; private set; }

    public DrawDomainModel(string title, List<Guid> tickets, DateTime dateStart, DateTime? dateEnd)
    {
        this.Title = title;
        this.Tickets = tickets;
        this.DateEnd = dateEnd;
        this.DateStart = dateStart;
        
        
    }
}