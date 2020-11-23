using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace EFWithMongoDB.Persisntence
{
    public interface IBarbershopContext
    {
        IMongoDatabase Database { get; }
        IEnumerable<BsonDocument> Databases { get; }

        /// <summary>
        ///     Get Database
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        IMongoDatabase GetDatabase(String databaseName);

        /// <summary>
        ///     Get Databases
        /// </summary>
        /// <returns></returns>
        IAsyncCursor<BsonDocument> GetDatabases();
    }
}
