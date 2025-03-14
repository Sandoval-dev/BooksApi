using BooksApi.Context;
using BooksApi.Models;
using BooksApi.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedBooksController : ControllerBase
    {
        private readonly BookDbContext _dbContext;

        public RentedBooksController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllRentedBooks")]
        public IActionResult GetAllRentedBooks()
        {
            var rentedBooks = _dbContext.RentedBooks.ToList();

            foreach (var book in rentedBooks)
            {
                book.User = _dbContext.Users.Find(book.UserId);
                book.Book = _dbContext.Books.Find(book.BookId);
            }
            return Ok(rentedBooks);
        }

        [HttpGet("getByIdRentedBook")]
        public IActionResult GeyByIdRentedBook(int id)
        {
            if (id==0)
            {
                return BadRequest("Id is required");
            }
            var rentedBook=_dbContext.RentedBooks.SingleOrDefault(x=>x.Id == id);
            if (rentedBook==null)
            {
                return BadRequest("Rented Book not found");
            }
            rentedBook.User = _dbContext.Users.Find(rentedBook.UserId);
            rentedBook.Book = _dbContext.Books.Find(rentedBook.BookId);
            return Ok(rentedBook);
        }

        [HttpPost("createRentedBook")]
        public IActionResult CreateRentedBook(CreateRentedBookViewModel model)
        {
            var book = _dbContext.Books.Find(model.BookId);
            if (book?.Stock>0)
            {
                var newModel = new RentedBook
                {
                    UserId=model.UserId,
                    User=null,
                    BookId=model.BookId,
                    Book=null,
                    StartDate=DateTime.Now,
                    EndDate=null
                };
                //model.StartDate = DateTime.Now;
                _dbContext.RentedBooks.Add(newModel);
                //stock
                book.Stock -= 1;
                _dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("No Stock");
            }
     
            return Ok("Book rented");
        }

        [HttpPut("updateRentedBook")]
        public IActionResult UpdateRentedBook(UpdateRentedBookViewModel model)
        {
            var rentedBook=_dbContext.RentedBooks.Find(model.Id);
            if (rentedBook==null)
            {
                return BadRequest("Rented book not found");
            }
    
            rentedBook.UserId = model.UserId;

            if (rentedBook.BookId != model.BookId)
            {
             
                var bookData= _dbContext.Books.Find(rentedBook.BookId);
                bookData.Stock += 1;
                rentedBook.BookId = model.BookId;
                var bookModel=_dbContext.Books.Find(model.BookId);
                bookModel.Stock -= 1;

            }
            rentedBook.StartDate = DateTime.Now;
            _dbContext.RentedBooks.Update(rentedBook);
            _dbContext.SaveChanges();
            return Ok("Rented book updated");

        }

        [HttpDelete("deleteByIdRentedBook")]
        public IActionResult DeleteRentedBook(int id)
        {
            var rentedBook=_dbContext.RentedBooks.SingleOrDefault(x=>x.Id==id);
            if (rentedBook == null)
            {
                return BadRequest("Rented Book not found");
            }
            else
            {
                _dbContext.RentedBooks.Remove(rentedBook);
                _dbContext.SaveChanges();
                return Ok("Rented Book deleted");
            }
        }
    }
}
