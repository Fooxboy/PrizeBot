using PrizeBot.Application.Abstractions;

namespace PrizeBot.Application.Models;

public record TelegramUpdateData(ITelegramUpdateTypeHandler? Handler, long? Recipient);