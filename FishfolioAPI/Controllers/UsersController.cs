using FishfolioAPI.DAL;
using FishfolioAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FishfolioAPI.Controllers
{
    [ApiController]
    [Route("api/fishfolio")]
    public class UsersController : Controller
    {
       private FishfolioDbContext _dbContext;

        public UsersController(FishfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Route("users")]
        public IActionResult Get()
        {
            var drivers = this._dbContext.Users
                .Select(p => new UserDTO()
                {
                    Id = p.Id,
                    Username = p.Username,
                    Password = p.Password,
                    UserType = p.UserType,
                    Email = p.Email,
                    FirstName = p.FirstName,
                    LastName = p.LastName

                }).AsQueryable();


            return Ok(drivers);
        }


        [Route("users/{username}")]
        public IActionResult Get(string username)
        {
            var user = this._dbContext.Users
                   .Where(p => p.Username == username)
                   .Select(p => new UserDTO()
                   {
                       Id = p.Id,
                       Username = p.Username,
                       Password = p.Password,
                       UserType = p.UserType,
                       Email = p.Email,
                       FirstName = p.FirstName,
                       LastName = p.LastName
                   }).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [HttpPost]
        [Route("users")]
        public IActionResult Post(UserDTO user)
        {
            this._dbContext.Add(new User()
            {
                FirstName = user.FirstName,
                LastName= user.LastName,
                Email = user.Email,
                UserType = user.UserType,
                Username = user.Username,
                Password= user.Password
            });

            this._dbContext.SaveChanges();

            return Ok();
        } 

        [HttpPut]
        [Route("users/{username}")]
        public IActionResult Put(string username, [FromBody] UserDTO user)
        {
            var userDB = this._dbContext.Users.First(p => p.Username == username);

            userDB.FirstName = user.FirstName;
            userDB.LastName = user.LastName;
            userDB.Email = user.Email;
            userDB.UserType = user.UserType;
            userDB.Username = user.Username;
            userDB.Password = user.Password;

            this._dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("users/{username}")]
        public IActionResult Delete(string username)
        {
            var user = this._dbContext.Users.First(p =>p.Username == username);
            this._dbContext.Users.Remove(user); 
        
            this._dbContext.SaveChanges();

            return Ok();
        
        }
        
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }

        public int UserType { get; set; }
    }
}