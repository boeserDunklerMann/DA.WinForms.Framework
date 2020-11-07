using DA.WinForms.Framework.Attributes;
using DA.WinForms.Framework.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Bookstore.Model
{
	public class Book : DataClassBase
	{
		[BsonId]    // used for MongoDB
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]	// used for MongoDB
		public string Id { get; set; }

		[BsonElement("Name")]   // used for MongoDB
		[Newtonsoft.Json.JsonProperty("Name")]  // used for MongoDB
		public string BookName { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
		public bool IsHardcover { get; set; }

		[ValidValues("Science", "Technology", "Novel", "Computers")]
		public string Category { get; set; }
	}
}
