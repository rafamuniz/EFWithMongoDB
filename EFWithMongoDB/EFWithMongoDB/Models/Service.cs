using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace EFWithMongoDB.Models
{

    public class Service //: IKey<ObjectId>, IMongoDBKey
    {
        public Service()
        {
            //Id = Guid.NewGuid();
        }

        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        //[BsonId(IdGenerator = typeof(GuidGenerator)), BsonRepresentation(BsonType.String)]

        [BsonElement("Name")]
        public String Name { get; set; }
    }
}
