using BooksApi.Context;
using BooksApi.Models;
using BooksApi.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _dbContext;

        public BooksController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _dbContext.Books.ToList();
            return Ok(books);
        }

        [HttpGet("getBook")]
        public IActionResult getBook(int id)
        {
            if (id==0)
            {
                return BadRequest("Id is required");
            }
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id==id);
            if (book==null)
            {
                return BadRequest("Book not found");
            }
            return Ok(book);
        }

        [HttpPost("createBook")]
        public IActionResult CreateBook(CreateBookViewModel model)
        {
            if (model.Title == null || model.Title == "" || model.Title.IsNullOrEmpty())
            {
                return BadRequest("Title is required");
            }
            if (model.Author == null || model.Author == "" || model.Author.IsNullOrEmpty())
            {
                return BadRequest("Author is required");
            }
            var newModel = new Book
            {
                Author = model.Author,
                Title = model.Title,
                Stock = model.Stock,
            };
            _dbContext.Books.Add(newModel);
            _dbContext.SaveChanges();
            return Ok();
            
        }

        [HttpPut("updateBook")]
        public IActionResult UpdateBook(Book model)
        {
            var book=_dbContext.Books.SingleOrDefault(x=>x.Id== model.Id);
            if (book==null)
            {
                return BadRequest("Book not found");
            }
            book.Title=model.Title;
            book.Author=model.Author;
            book.Stock = model.Stock;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return Ok("Book updated");
        }

        [HttpDelete("deleteBook")]
        public IActionResult DeleteBook(int id)
        {
            var book=_dbContext.Books.Where(x=>x.Id == id).FirstOrDefault();
            if (book==null)
            {
                return BadRequest("Book not found");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return Ok("Book deleted");
        }
    }
}
