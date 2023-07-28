using PrizeBot.Application.Abstractions;
using PrizeBot.Application.Models;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Services.Telegram;

public class UpdateHandler : IUpdateHandler
{
    private readonly IEnumerable<ITelegramUpdateTypeHandler> _handlers;

    private readonly SenderService _senderService;

    public UpdateHandler(IEnumerable<ITelegramUpdateTypeHandler> handlers, SenderService senderService)
    {
        _handlers = handlers;
        _senderService = senderService;
    }
    
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var updateData = update switch
        {
            { Message: { } message } => new TelegramUpdateData( _handlers.FirstOrDefault(h => h.UpdateType == TelegramUpdateType.Message), message?.Chat.Id),
        };

        if (updateData?.Handler is null) return;
        
        var response = await updateData.Handler.HandleAsync(update);

        if (!response.IsSuccessful)
        {
            //todo: logging or generate new answer
        }

        if (updateData.Recipient is null) return;

        var msg = await _senderService.Send(response, updateData.Recipient.Value);
        
        //todo: proceess msg variable
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        
    }
}