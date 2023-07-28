using PrizeBot.Application.Abstractions;
using PrizeBot.Application.Helpers;
using PrizeBot.Application.Models;
using PrizeBot.Application.Models.Arguments.Commands;
using PrizeBot.Domain.Draws;
using PrizeBot.Infrastructure.Draws;
using Telegram.Bot.Types;

namespace PrizeBot.Application.Handlers.Commands;

public class CreateDrawHandler : ICommandHandler
{
    private readonly DrawsRepository _drawsRepository;

    public CreateDrawHandler(DrawsRepository drawsRepository)
    {
        this._drawsRepository = drawsRepository;
    }
    
    public string[] Triggers => new[] {"create"};
    
    public async Task<CommandResponse> InvokeAsync(Message msg)
    {
        var args = ArgumentsParser.Parse<CreateDrawArgs>(msg.Text!);

        var response = new CommandResponse();

        if (args.Title is null)
        {
            response.Text = "❌ Вы не указали название. Название должно быть одним словом. Пример: /create НАЗВАНИЕ";

            return response;
        }

        var drawDomainModel = new DrawDomainModel(args.Title, DateTime.Now, null);

        var drawEntity = SimpleMapper.Map<Draw>(drawDomainModel);

        var id = _drawsRepository.Add(drawEntity);
        
        response.Text = $"✅ Ты создал новый розыгрыш с ID: {id}";

        return response;
    }
}