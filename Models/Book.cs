using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiTest.Models
{
    public class Book
    {
        // 使用 [BsonId] 进行批注，以将此属性指定为文档的主键
        [BsonId]
        // 使用 [BsonRepresentation(BsonType.ObjectId)] 进行批注，以允许将参数作为类型 string 而非 ObjectId 结构传递。 Mongo 处理从 string 到 ObjectId 的转换。
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}