using MongoDB.Bson;

namespace EFWithMongoDB.Models
{
    public interface IMongoDBKey
    {
        BsonObjectId _Id { get; set; }
    }
}
