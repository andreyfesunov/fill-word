﻿using MongoDB.Driver;

namespace game_center_backend_cs.Infrastructure.Utils;

public static class MongoDatabaseManager
{
    private const string ConnectionString = Config.DatabaseConnectionString;
    private const string DatabaseName = Config.DatabaseName;
    private static IMongoDatabase? _database;
    private static readonly object Padlock = new();

    public static IMongoDatabase GetDatabase()
    {
        if (_database == null)
            lock (Padlock)
            {
                if (_database != null) return _database;
                var client = new MongoClient(ConnectionString);
                _database = client.GetDatabase(DatabaseName);
            }

        return _database;
    }
}