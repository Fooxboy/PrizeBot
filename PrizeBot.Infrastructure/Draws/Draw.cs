using System.ComponentModel.DataAnnotations;

namespace PrizeBot.Infrastructure.Draws;

public class Draw : BaseEntity
{
    public string Title { get; set; }
    
    public List<Guid> Tickets { get; set; }
    
    public DateTime DateStart { get;  set; }
    
    public DateTime? DateEnd { get; set; }

    public override string Table => "draws";
}