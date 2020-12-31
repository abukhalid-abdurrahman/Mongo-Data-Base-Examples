using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_Example.Options;
using MongoDB_Example.Services.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_Example.Services
{
    public class DataBaseContext<T> : IDataBaseContext<T>
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public DataBaseContext(MongoSettings mongoSettings)
        {
            _mongoClient = new MongoClient(mongoSettings.ConnectionString);
            _db = _mongoClient.GetDatabase(mongoSettings.DataBaseName);
        }

        public async Task Create(T instance, string collection) => await InsertDocument(instance, collection);

        public async Task<List<T>> Read(string collectionName) => await GetDocuments(collectionName);

        public async Task<UpdateResult> Update(BsonDocument filter, BsonDocument instance, string collectionName) => await UpdateDocument(filter, instance, collectionName);

        public async Task Delete(BsonDocument filter, string collectionName) => await RemoveDocument(filter, collectionName);

        public IMongoCollection<T> GetCollection(string collectionName) => GetDocumentsCollection(collectionName);
        
        private async Task InsertDocument(T instance, string collectionName)
        {
            var _collection = _db.GetCollection<T>(collectionName);
            await _collection.InsertOneAsync(instance);
        }

        private async Task<List<T>> GetDocuments(string collectionName)
        {
            return await _db.GetCollection<T>(collectionName).Find(new BsonDocument()).ToListAsync();
        }

        private async Task<UpdateResult> UpdateDocument(BsonDocument filter, BsonDocument instance, string collectionName)
        {
            var _collection = _db.GetCollection<T>(collectionName);
            return await _collection.UpdateOneAsync(filter, instance);
        }
        private async Task RemoveDocument(BsonDocument filter, string collectionName)
        {
            var _collection = _db.GetCollection<T>(collectionName);
            await _collection.DeleteOneAsync(filter);
        }

        private IMongoCollection<T> GetDocumentsCollection(string collectionName)
        {
            return _db.GetCollection<T>(collectionName);
        }
    }
}
