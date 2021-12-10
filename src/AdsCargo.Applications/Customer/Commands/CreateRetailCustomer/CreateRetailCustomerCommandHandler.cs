using AdsCargo.Abstraction.Responses.Customer;
using AdsCargo.Domain.Entities.RetailCustomer;
using MediatR;
using MongoDB.Driver;

namespace AdsCargo.Applications.Customer.Commands.CreateRetailCustomer;

public class CreateRetailCustomerCommandHandler : IRequestHandler<CreateRetailCustomerCommand, RetailCustomerDto>
{
    private readonly IMongoClient _mongoClient;

    public CreateRetailCustomerCommandHandler(
        IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public async Task<RetailCustomerDto> Handle(
        CreateRetailCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = RetailCustomer.CreateCustomer(
            request.FirstName,
            request.LastName,
            request.PhoneNumber);
        
        var database  = _mongoClient.GetDatabase("AdsCargo");
        var collection =  database.GetCollection<RetailCustomer>("retailCustomers");
        await collection.InsertOneAsync(customer, cancellationToken: cancellationToken);
        return new RetailCustomerDto()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.Id
        };
    }
}