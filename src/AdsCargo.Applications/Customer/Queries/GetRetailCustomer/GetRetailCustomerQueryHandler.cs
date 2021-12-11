using AdsCargo.Abstraction.Responses.Customer;
using AdsCargo.Domain.Context;
using MediatR;
using MongoDB.Driver;

namespace AdsCargo.Applications.Customer.Queries.GetRetailCustomer;

public class GetRetailCustomerQueryHandler : IRequestHandler<GetRetailCustomerQuery,RetailCustomerDto>
{
    private readonly CargoMongoContext _cargoMongoContext;

    public GetRetailCustomerQueryHandler(
        CargoMongoContext cargoMongoContext)
    {
        _cargoMongoContext = cargoMongoContext;
    }

    public async Task<RetailCustomerDto> Handle(
        GetRetailCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var customerCursor = await _cargoMongoContext.RetailsCustomers.FindAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (!await customerCursor.AnyAsync(cancellationToken:cancellationToken))
        {
            return null;
        }

        var customer = await customerCursor.SingleAsync(cancellationToken: cancellationToken);
        return new RetailCustomerDto()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber
        };
    }
}