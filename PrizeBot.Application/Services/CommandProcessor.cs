using PrizeBot.Application.Abstractions;
using PrizeBot.Application.Models;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Services;

public class CommandProcessor : ICommandProcessor
{
    private readonly IEnumerable<ICommandHandler> _commandHandlers;

    public CommandProcessor(IEnumerable<ICommandHandler> commandHandlers)
    {
        _commandHandlers = commandHandlers;
    }
    
    public async Task<CommandResponse> ProcessMessageAsync(Message message)
    {
        var command = message.Text!.Split(" ")[0]
            .Replace("/", string.Empty);
        
        foreach (var commandHandler in _commandHandlers)
        {
            if (commandHandler.Triggers.Contains(command.ToLower()))
            {
                return await commandHandler.InvokeAsync(message);
            }
        }

        return new() { Error = new ErrorResponse($"Не найдена команда '{command}'", ErrorCode.CommandNotFound) };
    }
}