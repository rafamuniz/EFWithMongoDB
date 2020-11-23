using MongoDB.Driver;
using System;

namespace EFWithMongoDB.Persisntence.Repositories
{
    public abstract class BaseRepository<TDocument> : IBaseRepository<TDocument>
    {
        protected readonly IBarbershopContext _context;
        protected readonly IMongoCollection<TDocument> _collection;

        public BaseRepository(IBarbershopContext context, String collectionName)
        {
            _context = context;
            _collection = String.IsNullOrEmpty(collectionName) ? throw new ArgumentNullException(nameof(collectionName)) : context.Database.GetCollection<TDocument>(collectionName);
        }
    }
}
