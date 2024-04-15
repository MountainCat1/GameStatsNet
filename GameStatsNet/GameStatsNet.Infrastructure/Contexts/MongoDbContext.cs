using GameStatsNet.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase("mydatabase");
        
        BsonClassMap.RegisterClassMap<GameMatch>(cm =>
        {
            cm.AutoMap();
            cm.SetIgnoreExtraElements(true);
            cm.MapIdMember(c => c.Id).SetSerializer(new MongoDB.Bson.Serialization.Serializers.GuidSerializer(BsonType.String));
            cm.MapMember(c => c.FinishedAt).SetElementName("finished_at");
            cm.MapMember(c => c.StartedAt).SetElementName("started_at");
        });
    }

    public IMongoCollection<GameMatch> GetGameMatches() => _database.GetCollection<GameMatch>("gameMatches");
 
}