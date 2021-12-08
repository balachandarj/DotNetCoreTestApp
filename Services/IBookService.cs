using TestApp.Models;

namespace TestApp.Services
{
    public interface IBookService
    {
        public List<Book> GetBooks();

        public Book? GetBook(int bookId);

        public void AddBook(Book book);

        public Book? UpdateBook(int bookId, Book book);

        public void DeleteBook(int bookId);
    }
}
