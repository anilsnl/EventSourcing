using AdsCargo.Abstraction.Responses.Customer;
using MediatR;

namespace AdsCargo.Applications.Customer.Commands.CreateRetailCustomer;

public class CreateRetailCustomerCommand : IRequest<RetailCustomerDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}