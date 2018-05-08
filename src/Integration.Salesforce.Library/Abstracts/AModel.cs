using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Integration.Salesforce.Library.Abstracts
{
    public abstract class AModel
    {
        /// <summary>
        /// This is an ObjectId in MongoDB and string when exposing to API
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ModelId { get; set; }

        public DateTime LastModified { get; set; }
    }
}
