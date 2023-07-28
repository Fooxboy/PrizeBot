using System.ComponentModel.DataAnnotations;

namespace PrizeBot.Infrastructure;

public class BaseEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public virtual string Table { get; }
}