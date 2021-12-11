using AdsCargo.Domain.Entities.RetailCustomer;
using MongoDB.Driver;

namespace AdsCargo.Domain.Context;

public class CargoMongoContext
{
    private string DbName => "AdsCargo";

    public CargoMongoContext(
        IMongoClient mongoClient)
    {
        var db = mongoClient.GetDatabase(DbName);
        this.RetailsCustomers = db.GetCollection<RetailCustomer>("retailCustomers");
    }

    public IMongoCollection<RetailCustomer> RetailsCustomers { get; }
}