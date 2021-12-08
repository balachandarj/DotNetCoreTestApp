using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TestApp.Models;
using TestApp.Services;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("api/Books/")]
    public class BooksController : ControllerBase
    {
        static IBookService _bookService;


        static BooksController()
        {    
            // Connect Mongo DB
            //_bookService = new BookService();


            // Use static Data
            _bookService = new BookServiceStaticData();
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [HttpGet("GetBook")]
        public Book? GetBook(int bookId)
        {
            return _bookService.GetBook(bookId);
        }

        [HttpPost]
        public IActionResult AddBooks(Book book)
        {
             _bookService.AddBook(book);
            return Ok("Added New Book");
        }

        [HttpPut]
        public IActionResult UpdateBooks(int bookId,Book book)
        {
            var updatedBook = _bookService.UpdateBook(bookId,book);
            return Ok(updatedBook);
        }

        [HttpDelete]
        public IActionResult DeleteBooks(int bookId)
        {
            _bookService.DeleteBook(bookId);
            return Ok("Deleted");

        }

    }
}
