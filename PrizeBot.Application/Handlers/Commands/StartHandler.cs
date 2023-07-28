using PrizeBot.Application.Abstractions;
using PrizeBot.Application.Models;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Handlers.Commands;

public class StartHandler : ICommandHandler
{
    public string[] Triggers => new[] {"start", "начать"};
    
    public async Task<CommandResponse> InvokeAsync(Message msg)
    {
        return new() { Text = "Привет-привет!" };
    }
}