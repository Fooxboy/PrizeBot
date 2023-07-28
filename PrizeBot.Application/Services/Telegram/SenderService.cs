using PrizeBot.Application.Models;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Services.Telegram;

public class SenderService
{
    private readonly ITelegramBotClient _telegramBotClient;
    
    public SenderService(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }
    
    public Task<Message> Send(CommandResponse commandResponse, long recipient)
    {
        //todo: build message.
        //now only text

        var message = _telegramBotClient.SendTextMessageAsync(recipient, commandResponse.Text);

        return message;
    }
}