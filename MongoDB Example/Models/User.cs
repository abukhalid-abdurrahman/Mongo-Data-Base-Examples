using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDB_Example.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string UserId { get; set; }
        [BsonIgnore]
        public int UserExternalId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        public int Age { get; set; }
        [BsonIgnoreIfNull]
        public List<string> Languages { get; set; }
    }
}
