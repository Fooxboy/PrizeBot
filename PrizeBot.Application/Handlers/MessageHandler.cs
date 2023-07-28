using PrizeBot.Application.Abstractions;
using PrizeBot.Application.Models;
using PrizeBot.Application.Services;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Handlers;

public class MessageHandler : ITelegramUpdateTypeHandler
{
    private readonly ICommandProcessor _commandProcessor;
    
    public MessageHandler(ICommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }
    
    public TelegramUpdateType UpdateType => TelegramUpdateType.Message;
    
    public async Task<CommandResponse> HandleAsync(Update update)
    {
        var message = update.Message;

        if (message is null) return new() { Error = new ErrorResponse("Сообщение было null", ErrorCode.MessageIsNull) };
        
        if (message.Text == null) return new() { Error = new ErrorResponse("Текст сообщения был null", ErrorCode.TextIsNull), };
        
        if (!message.Text.StartsWith("/")) return new() { Error = new ErrorResponse("Это не команда", ErrorCode.Unknown) };

        var response = await _commandProcessor.ProcessMessageAsync(message);

        return response;
    }
}