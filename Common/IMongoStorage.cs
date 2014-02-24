using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace Commmon
{
    public interface IMongoStorage
    {
        MongoCollection<BsonDocument> GetCollection(String collectionName);
        MongoCollection<T> GetCollection<T>(String collectionName);
    }

    public  class MongoStorage : IMongoStorage
    {
        public MongoCollection<BsonDocument> GetCollection(String collectionName)
        {
            return this.GetCollection<BsonDocument>(collectionName);
        }

        public MongoCollection<T> GetCollection<T>(String collectionName)
        {
            var url = new MongoUrl("mongodb://localhost/cdays14");

            var client = new MongoClient(url);
            var server = client.GetServer();
            var database = server.GetDatabase(url.DatabaseName);

            return database.GetCollection<T>(collectionName);
        }
    }
}
