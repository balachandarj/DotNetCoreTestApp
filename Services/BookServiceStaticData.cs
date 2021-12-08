using TestApp.Models;

namespace TestApp.Services
{
    public class BookServiceStaticData : IBookService
    {
        static List<Book> books;

        static BookServiceStaticData()
        {
            books = new List<Book>();
            books.Add(new Book() { BookId = 5001, Author = "Author-5001", Title = "Title-5001" });
            books.Add(new Book() { BookId = 5002, Author = "Author-5002", Title = "Title-5002" });
            books.Add(new Book() { BookId = 5003, Author = "Author-5003", Title = "Title-5003" });
            books.Add(new Book() { BookId = 5004, Author = "Author-5004", Title = "Title-5004" });
            books.Add(new Book() { BookId = 5005, Author = "Author-5005", Title = "Title-5005" });

        }
        public void AddBook(Book book)
        {
           books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            var book = books.FirstOrDefault(o=>o.BookId == bookId);
            books.Remove(book);
        }

        public Book? GetBook(int bookId)
        {
            var book = books.FirstOrDefault(o => o.BookId == bookId);
            return book;
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book? UpdateBook(int bookId, Book book)
        {
            var book_db = books.FirstOrDefault(o => o.BookId == bookId);
            if(book_db == null)
                return null;

            book_db.Title = book.Title;
            book_db.Author = book.Author;
            return book_db;

        }
    }
}
