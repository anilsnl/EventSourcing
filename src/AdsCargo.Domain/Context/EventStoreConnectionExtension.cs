using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdsCargo.Domain.Context;

public static class EventStoreConnectionExtension
{

    public static IServiceCollection AddEventSourceConnection(this IServiceCollection services)
    {
        services.AddScoped(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connection = EventStoreConnection.Create(configuration.GetConnectionString("EventSourceDb"));
            connection.ConnectAsync().GetAwaiter().GetResult();
            return connection;
        });
       
        return services;
    }
}