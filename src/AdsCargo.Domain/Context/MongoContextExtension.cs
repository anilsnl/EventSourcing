using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace AdsCargo.Domain.Context;

public static class MongoContextExtension
{
    public static IServiceCollection AddMongo(
        this IServiceCollection services)
    {
        services.AddScoped<CargoMongoContext>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var client = new MongoClient(configuration.GetConnectionString("Mongo"));

            return new CargoMongoContext(client);
        });
        return services;
    }
}