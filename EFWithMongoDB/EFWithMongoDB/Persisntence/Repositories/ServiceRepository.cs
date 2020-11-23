using EFWithMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFWithMongoDB.Persisntence.Repositories
{
    public class ServiceRepository : BaseRepository<BsonDocument>, IServiceRepository
    {
        #region Constructor
        public ServiceRepository(IBarbershopContext context)
            : base(context, "Services")
        {

        }
        #endregion Constructor

        /// <summary>
        ///     Create Service
        /// </summary>
        /// <param name="service"></param>
        public Service Create(Service service)
        {
            //BsonElement element = new BsonElement("Id", MongoDB.Bson.ObjectId.GenerateNewId().ToString());
            //var document = new BsonDocument { { "Id", GuidGenerator ObjectId.GenerateNewId().ToString() }, { "Name", service.Name } };

            var document = service.ToBsonDocument();

            _collection.InsertOne(document);

            return BsonSerializer.Deserialize<Service>(document);
        }

        /// <summary>
        ///     Create Service
        /// </summary>
        /// <param name="service"></param>
        public async Task<Service> CreateAsync(Service service)
        {
            var document = service.ToBsonDocument();

            await _collection.InsertOneAsync(document);

            return BsonSerializer.Deserialize<Service>(document);
        }
        
        /// <summary>
        ///     Update Service
        /// </summary>
        /// <param name="service"></param>
        public Service Update(Service service)
        {
            BsonClassMap.RegisterClassMap<MyClass>();

            var filter = Builders<BsonDocument>.Filter.Eq("_id", service._id);

            var update = Builders<BsonDocument>.Update.Set("name", service.Name);

            var result = _collection.UpdateOne(filter, update);

            return result.ToBsonDocument<Service>();
        }

        /// <summary>
        ///     Update Service
        /// </summary>
        /// <param name="service"></param>
        public async Task<Service> UpdateAsync(Service service)
        {
            var document = service.ToBsonDocument();

            var updated = await _collection.UpdateOneAsync(document);

            return BsonSerializer.Deserialize<Service>(updated);
        }

        /// <summary>
        ///     Delete Service
        /// </summary>
        /// <param name="service"></param>
        public Service Delete(Service service)
        {
            var document = service.ToBsonDocument();

            _collection.DeleteOne(document);

            return BsonSerializer.Deserialize<Service>(document);
        }

        /// <summary>
        ///     Delete Service
        /// </summary>
        /// <param name="service"></param>
        public async Task<Service> DeleteAsync(Service service)
        {
            var document = service.ToBsonDocument();

            await _collection.DeleteOneAsync(document);

            return BsonSerializer.Deserialize<Service>(document);
        }

        /// <summary>
        ///     Get Service By Id
        /// </summary>
        /// <param name="service"></param>
        public Service GetById(Guid id)
        {
            var documents = await _collection.Find(_ => true).Result.ToListAsync();

            return BsonSerializer.Deserialize<Service>(documents);
        }

        /// <summary>
        ///     Get Service By Id
        /// </summary>
        /// <param name="service"></param>
        public async Task<Service> GetByIdAsync(Guid id)
        {
            //var documents = await _collection.FindAsync(Builders<Service>.Filter.Empty).ToListAsync();

            var documents = await _collection.FindAsync(_ => true).Result.ToListAsync();

            return BsonSerializer.Deserialize<List<Service>>(documents);
        }

        /// <summary>
        ///     Get Services
        /// </summary>
        /// <param name="service"></param>
        public List<Service> Gets()
        {
            //var documents =  _collection.AsQueryable().ToListAsync();
            var documents = _collection.Find(_ => true).ToListAsync();
//            var documents = await SpeCollection.Find(new BsonDocument()).ToListAsync();

            return BsonSerializer.Deserialize<List<Service>>((MongoDB.Bson.IO.IBsonReader)documents);
        }

        /// <summary>
        ///     Get Services
        /// </summary>
        /// <param name="service"></param>
        public async Task<List<Service>> GetsAsync()
        {
            //var documents = await _collection.FindAsync(Builders<Service>.Filter.Empty).ToListAsync();

            var documents = await _collection.FindAsync(_ => true).Result.ToListAsync();

            return BsonSerializer.Deserialize<List<Service>>(documents);
        }
    }
}
