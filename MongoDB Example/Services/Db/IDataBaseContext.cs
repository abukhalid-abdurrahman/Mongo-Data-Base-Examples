using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB_Example.Services.Db
{
    public interface IDataBaseContext<T>
    {
        Task Create(T instance, string collection);
        Task<List<T>> Read(string collectionName);
        Task<UpdateResult> Update(BsonDocument filter, BsonDocument instance, string collectionName);
        Task Delete(BsonDocument filter, string collectionName);
        IMongoCollection<T> GetCollection(string collectionName);
    }
}
