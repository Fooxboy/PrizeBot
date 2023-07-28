using PrizeBot.Application.Models;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Abstractions;

public interface ITelegramUpdateTypeHandler
{
    public TelegramUpdateType UpdateType { get; }

    public Task<CommandResponse> HandleAsync(Update update);
}