using LiteDB;

namespace PrizeBot.Infrastructure.Configuration;

public class ConfigRepository : BaseRepository
{
    
    public BotConfig GetConfig()
    {
        using (var db = new LiteDatabase(pathDb))
        {
            return db.GetCollection<BotConfig>("config").Query().FirstOrDefault();
        }
    } 
}