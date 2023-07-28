using PrizeBot.Application.Models;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Abstractions;

public interface ICommandProcessor
{
    public Task<CommandResponse> ProcessMessageAsync(Message message);
}