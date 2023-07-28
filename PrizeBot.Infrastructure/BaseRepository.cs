using LiteDB;

namespace PrizeBot.Infrastructure;

public class BaseRepository 
{
    protected readonly string pathDb = "bot.db";

    public Guid Add<TEntity>(TEntity entity) where TEntity : IEntity
    {
        using (var database = new LiteDatabase(pathDb))
        {
            var col = database.GetCollection<TEntity>(entity.Table);

            entity.Id = Guid.NewGuid();

            col.Insert(entity);

            return entity.Id;
        }
    }
}