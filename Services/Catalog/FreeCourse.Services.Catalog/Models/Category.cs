namespace FreeCourse.Services.Catalog.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }
    }
}
