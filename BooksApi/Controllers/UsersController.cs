using BooksApi.Context;
using BooksApi.Models;
using BooksApi.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BookDbContext _dbContext;

        public UsersController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        [HttpGet("getByIdUser")]
        public IActionResult getUser(int id)
        {
            if (id==0)
            {
                return BadRequest("Id is required");
            }
            //var user= _dbContext.Users.SingleOrDefault(x => x.Id == id);
            var user=_dbContext.Users.Where(x=>x.Id == id).FirstOrDefault();
            if (user==null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost("createUser")]
        public IActionResult addUser(CreateUserViewModel model)
        {

            var newModel = new User
            {
                Name=model.Name,
                Email=model.Email,
                Surname=model.Surname,
                Phone= model.Phone
            };
            _dbContext.Users.Add(newModel);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("updateUser")]
        public IActionResult updateUser(User model) 
        { 
            var user=_dbContext.Users.Where(x=>x.Id==model.Id).FirstOrDefault();
            if (user == null) 
            {
                return NotFound("User not found");
            }
            else
            {
                user.Name=model.Name;
                user.Surname=model.Surname;
                user.Email=model.Email;
                user.Phone=model.Phone;
                _dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return Ok("User updated");
            }
        }

        [HttpDelete("deleteUser")]
        public IActionResult deleteUser(int id)
        {
            var user=_dbContext.Users.Where(x=>x.Id==id).FirstOrDefault();
            if (user == null)
            {
                return NotFound("User not found");
            }
            else
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return Ok("User deleted");
            }
            
        }
    }
}
