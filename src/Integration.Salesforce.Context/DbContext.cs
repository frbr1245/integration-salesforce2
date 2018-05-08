using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using Housing.Foundation.Library.Abstracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Integration.Salesforce.Context
{
    public class DbContext
    {
        public const string MongoDbIdName = "_id";

        protected readonly IMongoClient _client;

        protected readonly IMongoDatabase _db;

        protected readonly IMongoCollection<BsonDocument> _collection;

        protected readonly TimeSpan CacheExpiration;

        public DbContext()
        {
            //connection string
            string connectionString = 
            @"mongodb://d215ccd9-0ee0-4-231-b9ee:GFX6ZSDkrc2xPukTVYwBbWc9RRRN5iUDhde0lIHI4xBTjGrhHmZnwY0tEl0DiLwW4oMtb86ThLRqnVo6EGVzmA==@d215ccd9-0ee0-4-231-b9ee.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            
            MongoClientSettings settings = MongoClientSettings.FromUrl(
            new MongoUrl(connectionString)
            );
            
            settings.SslSettings = 
            new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            _client = new MongoClient(settings);

            _db = _client.GetDatabase("housingdb");

            _collection = _db.GetCollection<BsonDocument>("batches");            
        }
    }
}