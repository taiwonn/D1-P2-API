using Microsoft.AspNetCore.Mvc;

namespace UserController.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Cette liste simule une base de données en mémoire
        private static List<User> Users = new List<User>
        {
            new User { Id = 1, FirstName = "John", LastName = "Doe", Username = "johndoe", Password = "password123" },
            new User { Id = 2, FirstName = "Jane", LastName = "Smith", Username = "janesmith", Password = "password456" }
        };

        // GET: api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🔍 Users retrieved successfully");
            Console.ResetColor();
            return Ok(Users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🔍 User retrieved successfully");
            Console.ResetColor();
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            user.Id = Users.Count + 1;
            Users.Add(user);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("👤 User created successfully");
            Console.ResetColor();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("👤 User updated successfully");
            Console.ResetColor();
            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            Users.Remove(user);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("👤 User deleted successfully");
            Console.ResetColor();
            return NoContent();
        }
    }
}
