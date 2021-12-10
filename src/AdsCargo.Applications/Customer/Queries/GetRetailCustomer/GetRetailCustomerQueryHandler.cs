using AdsCargo.Abstraction.Responses.Customer;
using MediatR;

namespace AdsCargo.Applications.Customer.Queries.GetRetailCustomer;

public class GetRetailCustomerQueryHandler : IRequestHandler<GetRetailCustomerQuery,RetailCustomerDto>
{
    public Task<RetailCustomerDto> Handle(
        GetRetailCustomerQuery request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}