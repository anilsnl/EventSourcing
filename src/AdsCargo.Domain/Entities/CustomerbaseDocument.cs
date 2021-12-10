using AdsCargo.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdsCargo.Domain.Entities;

public class CustomerBaseDocument
{
    public CustomerBaseDocument()
    {
        this.Id = ObjectId.GenerateNewId().ToString();
    }
    
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; protected set; }
    
    [BsonElement("type")] 
    [BsonRepresentation(BsonType.String)]
    public CustomerType Type { get; protected set; }
    
    [BsonElement("status")] 
    [BsonRepresentation(BsonType.String)]
    public CustomerStatus Status { get; protected set; }
}
