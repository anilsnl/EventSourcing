using AdsCargo.Abstraction.Responses.Customer;
using MediatR;

namespace AdsCargo.Applications.Customer.Queries.GetRetailCustomer;

public class GetRetailCustomerQuery : IRequest<RetailCustomerDto>
{
    public GetRetailCustomerQuery(
        string id)
    {
        Id = id;
    }
    public string Id { get; set; }
}