namespace PrizeBot.Application.Models;

public class CommandResponse
{
    public bool IsSuccessful => Error is null;
    
    public ErrorResponse? Error { get; set; }
    
    public string Text { get; set; }
}