using PrizeBot.Application.Attributes;

namespace PrizeBot.Application.Models.Arguments.Commands;

public class CreateDrawArgs
{
    [StringPosition(1)]
    public string? Title { get; set; }
}