using MongoDB.Bson;
using MongoDB.Driver;
using TestApp.Models;

namespace TestApp.Services
{
    public class BookService:IBookService
    {
        IMongoDatabase _database;

        public BookService()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            _database = client.GetDatabase("BookStoreDB");

        }
        public List<Book> GetBooks()
        {
            var books = _database.GetCollection<Book>("Books").Aggregate().ToList();

            return books;
        }

        public Book? GetBook(int bookId)
        {
            var book = _database.GetCollection<Book>("Books").Find(o=>o.BookId == bookId).FirstOrDefault();

            return book;
        }


        public  void AddBook(Book book)
        {
            var collection = _database.GetCollection<Book>("Books");
            collection.InsertOne(book);

        }

        public Book? UpdateBook(int bookId, Book book)
        {
            var collection = _database.GetCollection<Book>("Books");

            var updatedBook = collection.FindOneAndUpdate(Builders<Book>.Filter.Eq("BookId", bookId), 
                Builders<Book>.Update.Set("Author", book.Author).Set("Title",book.Title));
            return GetBook(bookId);

        }


        public void DeleteBook(int bookId)
        {
            var collection = _database.GetCollection<Book>("Books");
            collection.FindOneAndDelete(Builders<Book>.Filter.Eq("BookId", bookId));
        }

    }
}
