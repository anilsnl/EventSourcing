using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdsCargo.Domain.Entities.RetailCustomer;

public partial class RetailCustomer : CustomerBaseDocument
{
    [BsonElement("firstName")]
    public string FirstName { get; protected set; }
    
    [BsonElement("lastName")]
    public string LastName { get; protected set; }
    
    [BsonElement("phoneNumber")]
    public string PhoneNumber { get; protected set; }
}