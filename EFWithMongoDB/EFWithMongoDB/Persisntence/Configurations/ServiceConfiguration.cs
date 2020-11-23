using EFWithMongoDB.Models;
using MongoDB.Bson.Serialization;
using System;

namespace EFWithMongoDB.Persisntence.Configurations
{
    public class ServiceConfiguration
    {
        public ServiceConfiguration()
        {
            BsonClassMap.RegisterClassMap<Service>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetDefaultValue(Guid.NewGuid());
                cm.MapMember(c => c.Name).SetDefaultValue("");
            });
        }
    }
}
