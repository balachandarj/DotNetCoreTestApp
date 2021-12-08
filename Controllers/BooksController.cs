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
        static BookService _bookService;


        static BooksController()
        {           
            _bookService = new BookService();
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [HttpGet("GetBook")]
        public Book GetBook(int bookId)
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
