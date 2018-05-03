using System.Security.Authentication;
using MongoDB.Driver;

namespace Integration.Salesforce.Context
{
    public class DbContext
    {
        public void MongoConnection()
        {
            //connection string
            string connectionString = 
            @"mongodb://d215ccd9-0ee0-4-231-b9ee:GFX6ZSDkrc2xPukTVYwBbWc9RRRN5iUDhde0lIHI4xBTjGrhHmZnwY0tEl0DiLwW4oMtb86ThLRqnVo6EGVzmA==@d215ccd9-0ee0-4-231-b9ee.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            
            MongoClientSettings settings = MongoClientSettings.FromUrl(
            new MongoUrl(connectionString)
            );
            
            settings.SslSettings = 
            new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
        }
    }
}