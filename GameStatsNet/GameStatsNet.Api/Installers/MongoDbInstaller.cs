using MongoDB.Driver;

namespace GameStatsNet.Api.Installers;

public static class MongoDbInstaller
{
    public static IServiceCollection InstallMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMongoClient>(sp =>
        {
            var mongoConfigConnection = configuration.GetConnectionString("MongoDb");
            return new MongoClient(mongoConfigConnection);
        });
        
        services.AddSingleton<IMongoDatabase>(sp =>
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var mongoUrl = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUrl);
            return client.GetDatabase(mongoUrl.DatabaseName);
        });

        return services;
    }
}