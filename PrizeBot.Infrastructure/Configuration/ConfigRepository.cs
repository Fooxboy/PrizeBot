using LiteDB;

namespace PrizeBot.Infrastructure.Configuration;

public class ConfigRepository
{
    private readonly string pathDb = "bot.db";
    
    public BotConfig GetConfig()
    {
        using (var db = new LiteDatabase(pathDb))
        {
            return db.GetCollection<BotConfig>("config").Query().FirstOrDefault();
        }
    } 
}