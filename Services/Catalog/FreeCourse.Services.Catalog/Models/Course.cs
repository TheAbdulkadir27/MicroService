namespace FreeCourse.Services.Catalog.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Decription { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Picture { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreationDate { get; set; }
        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}
