using PrizeBot.Application;
using PrizeBot.Application.Abstractions;
using PrizeBot.Application.Handlers;
using PrizeBot.Application.Handlers.Commands;
using PrizeBot.Application.Services;
using PrizeBot.Application.Services.Telegram;
using Telegram.Bot;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHttpClient("telegram-bot-client").AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
        {
            TelegramBotClientOptions options = new("TOKEN");
            return new TelegramBotClient(options, httpClient);
        });

        //other services
        services.AddScoped<SenderService>();
        
        //command handlers
        services.AddScoped<ICommandHandler, StartHandler>();
        
        //command processors
        services.AddSingleton<ICommandProcessor, CommandProcessor>();
        
        //telegram type update handlers
        services.AddScoped<ITelegramUpdateTypeHandler, MessageHandler>();
        
        //Telegram handlers
        services.AddScoped<UpdateHandler>();
        services.AddScoped<ReceiverService>();
        services.AddHostedService<PollingService>();
    })
    .Build();

host.Run();