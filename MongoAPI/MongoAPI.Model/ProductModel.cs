using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAPI.Model
{
    public class ProductModel
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("nombre")]
        public string Name { get; set; }

        [BsonElement("cantidad")]
        public int Count { get; set; }

        [BsonElement("precio")]
        public float Price { get; set; }
    }
}
