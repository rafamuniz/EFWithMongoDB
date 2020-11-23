using EFWithMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace EFWithMongoDB.Persisntence
{
    public class BarbershopContext : IBarbershopContext
    {
        private readonly DatabaseSettings _settings;
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IEnumerable<BsonDocument> _databases;

        public IMongoDatabase Database
        {
            get
            {
                return _database;
            }
        }

        public IEnumerable<BsonDocument> Databases
        {
            get
            {
                return _databases;
            }
        }

        public BarbershopContext(String connectionString, String database)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            MongoDefaults.GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard;
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            _client = new MongoClient(connectionString);
            _database = GetDatabase(database);

            _databases = _client.ListDatabases().Current;
        }

        public BarbershopContext(DatabaseSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));

            _client = new MongoClient(settings.Name);
            _database = GetDatabase(settings.Database);
        }

        /// <summary>
        ///     Get Database
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public IMongoDatabase GetDatabase(String databaseName)
        {
            return _client.GetDatabase(databaseName);
        }

        /// <summary>
        ///     Get Databases
        /// </summary>
        /// <returns></returns>
        public IAsyncCursor<BsonDocument> GetDatabases()
        {
            return _client.ListDatabases();
        }
    }
}
