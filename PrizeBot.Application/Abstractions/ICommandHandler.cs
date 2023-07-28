using PrizeBot.Application.Models;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Abstractions;

public interface ICommandHandler
{
    public string[] Triggers { get; }

    public Task<CommandResponse> InvokeAsync(Message msg);
}