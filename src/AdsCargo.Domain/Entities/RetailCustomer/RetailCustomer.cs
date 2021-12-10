
using AdsCargo.Domain.Enums;

namespace AdsCargo.Domain.Entities.RetailCustomer;

public partial class RetailCustomer
{
    public static RetailCustomer CreateCustomer(
        string firstName,
        string lastName,
        string phoneNumber)
    {
        var customer = new RetailCustomer
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Status = CustomerStatus.Active,
            Type = CustomerType.RetailCustomer
        };

        return customer;
    }
}