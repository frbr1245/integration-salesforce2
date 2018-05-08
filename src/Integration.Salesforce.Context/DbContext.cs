using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using Integration.Salesforce.Library.Abstracts;
using Integration.Salesforce.Library.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Integration.Salesforce.Context
{
    public class DbContext<TModel> where TModel : AModel
    {
        public const string MongoDbIdName = "_id";

        protected readonly IMongoClient _client;

        protected readonly IMongoDatabase _db;

        protected readonly IMongoCollection<TModel> _collection;

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

            _collection = _db.GetCollection<TModel>("batches");            
        }
         public void UpdateMongoDB(IEnumerable<TModel> dataContacts)
        {
            // Get the contacts in the Person collection, check for existing contacts.
            // If not present, add to collection.
            var mongoContacts = _collection.Find(_ => true).ToList();
            foreach (TModel dataContact in dataContacts)
            {
                var existingContact = mongoContacts.Find(item => dataContact.ModelId == item.ModelId);

                if (existingContact == null)
                {
                    _collection.InsertOne(dataContact);
                }
            }

            // Next, if the contacts in the MongoDB does not exist in the salesforce API data, then
            // remove it from the MongoDB.
            List<TModel> dataContactList = new List<TModel>(dataContacts);
            foreach (var mongoContact in mongoContacts)
            {
                var existingContact = dataContactList.Find(item => mongoContact.ModelId == item.ModelId);
                if (existingContact == null)
                {
                    var builder = Builders<TModel>.Filter;
                    var filter = builder.Eq (x => x.ModelId, mongoContact.ModelId);
                    _collection.DeleteMany(filter);
                }
            }
        }
        public void UpdateContact(IEnumerable<TModel> dataContacts)
        {
            var mongoContacts = _collection.Find(_ => true).ToList();
            foreach (TModel dataContact in dataContacts)
            {
                var existingContact = mongoContacts.Find(item => dataContact.ModelId == item.ModelId);

                if (existingContact != null)
                {
                    var builder = Builders<TModel>.Filter;
                    var filter = builder.Eq (x => x.ModelId, dataContact.ModelId);
                    
                    _collection.DeleteOne(filter);
                    _collection.InsertOne(dataContact);
                }
            }
        }
        public void DeleteContact(IEnumerable<TModel> dataContacts)
        {
            var mongoContacts = _collection.Find(_ => true).ToList();
            foreach (TModel dataContact in dataContacts)
            {
                var existingContact = mongoContacts.Find(item => dataContact.ModelId == item.ModelId);

                if (existingContact != null)
                {
                    var builder = Builders<TModel>.Filter;
                    var filter = builder.Eq (x => x.ModelId, dataContact.ModelId);
                    
                    _collection.DeleteOne(filter);
                }
            }
        }
    }
}