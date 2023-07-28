using PrizeBot.Application.Abstractions;
using PrizeBot.Application.Handlers;
using PrizeBot.Application.Handlers.Commands;
using PrizeBot.Application.Services;
using PrizeBot.Application.Services.Telegram;
using PrizeBot.Infrastructure.Draws;
using Telegram.Bot;
using Telegram.Bot.Polling;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient("telegram-bot-client").AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
        {
            TelegramBotClientOptions options = new("TOKEN");
            return new TelegramBotClient(options, httpClient);
        });

        //other services
        services.AddScoped<SenderService>();
        
        //repos
        services.AddScoped<DrawsRepository>();
        
        //command handlers
        services.AddScoped<ICommandHandler, StartHandler>();
        services.AddScoped<ICommandHandler, CreateDrawHandler>();
        
        //command processors
        services.AddSingleton<ICommandProcessor, CommandProcessor>();
        
        //telegram type update handlers
        services.AddScoped<ITelegramUpdateTypeHandler, MessageHandler>();
        
        //Telegram handlers
        services.AddScoped<IUpdateHandler, UpdateHandler>();
        services.AddScoped<ReceiverService>();
        services.AddHostedService<PollingService>();
    })
    .Build();

host.Run();