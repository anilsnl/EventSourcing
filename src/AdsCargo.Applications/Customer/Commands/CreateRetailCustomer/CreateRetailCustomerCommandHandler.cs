using AdsCargo.Abstraction.Responses.Customer;
using AdsCargo.Domain.Context;
using AdsCargo.Domain.Entities.RetailCustomer;
using MediatR;
using MongoDB.Driver;

namespace AdsCargo.Applications.Customer.Commands.CreateRetailCustomer;

public class CreateRetailCustomerCommandHandler : IRequestHandler<CreateRetailCustomerCommand, RetailCustomerDto>
{
    private readonly CargoMongoContext _cargoMongoContext;

    public CreateRetailCustomerCommandHandler(
        CargoMongoContext cargoMongoContext)
    {
        _cargoMongoContext = cargoMongoContext;
    }

    public async Task<RetailCustomerDto> Handle(
        CreateRetailCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = RetailCustomer.CreateCustomer(
            request.FirstName,
            request.LastName,
            request.PhoneNumber);
       
        await _cargoMongoContext.RetailsCustomers.InsertOneAsync(customer, cancellationToken: cancellationToken);
        return new RetailCustomerDto()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.Id
        };
    }
}