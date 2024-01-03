using System.Reflection;
using MongoDB.Driver;

namespace game_center_backend_cs.Infrastructure.Db;

public abstract class DalModel<T>
{
    private static string GetCollectionName()
    {
        var type = typeof(T);
        var attribute = type.GetCustomAttribute<CollectionNameAttribute>();

        if (attribute != null) return attribute.Name;

        throw new Exception("Collection name attribute not found");
    }

    public static IMongoCollection<T> Query()
    {
        var database = MongoDatabaseManager.GetDatabase();
        return database.GetCollection<T>(GetCollectionName());
    }

    public static T Create(T model)
    {
        Query().InsertOne(model);
        return model;
    }
}