using System.ComponentModel.DataAnnotations;

namespace PrizeBot.Infrastructure;

public interface IEntity
{
    [Key]
    public Guid Id { get; set; }
    
    internal string Table { get; }
}