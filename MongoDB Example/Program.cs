using MongoDB.Bson;
using MongoDB_Example.Services;
using MongoDB_Example.Services.Db;

namespace MongoDB_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //Little Example
            IDataBaseContext<BsonDocument> dbContext = new DataBaseContext<BsonDocument>(new Options.MongoSettings 
            { 
                ConnectionString = "mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false",
                DataBaseName = "library"
            });
            dbContext.Create(new BsonDocument("bookName", "C# For Teaports!"), "books").GetAwaiter().GetResult();
        }
    }
}
