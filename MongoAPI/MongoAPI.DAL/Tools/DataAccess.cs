using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAPI.DAL.Tools
{
    public class DataAccess
    {
        static public IMongoDatabase ConnectDataBase()
        {
            string stringConnection = ConnectionString.GetInstance.GetConnectionString();

            MongoClient mongoClient = new MongoClient(stringConnection);

            var dataBase = mongoClient.GetDatabase("test");

            return dataBase;
        }

        static public IMongoCollection<BsonDocument> GetCollection(IMongoDatabase mongoDatabase, string collection)
        {
            return mongoDatabase.GetCollection<BsonDocument>(collection);
        }

        static public List<BsonDocument> ConnectAndQuery(string collection)
        {
            var _mongoDatabase = ConnectDataBase();

            var mongoCollection = GetCollection(_mongoDatabase, collection);

            var cursor = mongoCollection.Find(new BsonDocument()).ToList();

            return cursor;
        }
    }
}
