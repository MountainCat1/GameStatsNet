using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["ConnectionStrings:MongoDb"]);
        _database = client.GetDatabase("mydatabase");
    }

    // JUST AN EXAMPLE, remove it later pleaseeee
    // public IMongoCollection<Book> Books => _database.GetCollection<Book>("books");
}