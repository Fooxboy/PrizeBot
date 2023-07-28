namespace PrizeBot.Domain.Draws;

public class DrawDomainModel : BaseDomainModel
{
    public string Title { get; private set; }
    
    public IEnumerable<Guid> Tickets { get; private set; }
    
    public DateTime DateStart { get; private set; }
    
    public DateTime? DateEnd { get; private set; }

    public DrawDomainModel(string title, DateTime dateStart, DateTime? dateEnd, IEnumerable<Guid>? tickets = null)
    {
        this.Title = title;
        this.DateEnd = dateEnd;
        this.DateStart = dateStart;

        if (tickets is null)
        {
            this.Tickets = new List<Guid>();
        }
        else
        {
            this.Tickets = tickets;
        }
    }
}