using MongoDB.Bson;

namespace TestApp.Models
{
    public class Book
    {
        public ObjectId Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }

        public string Author { get; set; } 

    }
}
