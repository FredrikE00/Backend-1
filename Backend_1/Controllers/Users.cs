using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private static List<Users> users = new List<Users>
        {
                new Users {
                    Id = 1,
                    FirstName ="Fredrik",
                    LastName="Eriksson",
                    Email="Fredrike0006@gmail.com"
                },
                new Users { 
                    Id=2,
                    FirstName="Alfred",
                    LastName="Modig",
                    Email ="AlfredM@gmail.com",
                },
                new Users {
                    Id=3,
                    FirstName="Rocky",
                    LastName="Eriksson",
                    Email ="Rockyhund@outlook.se",
                },
                new Users {
                    Id=4,
                    FirstName="Erik",
                    LastName="Hedberg",
                    Email ="ErikH@gmail.com",
                }
        };
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }
        //get
        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        //get returnera om användare inte hittas
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Users>>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found.");
            return Ok(user);
        }
        //add
        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
        //ändra spara
        [HttpPut]
        public async Task<ActionResult<List<Users>>> UpdateUser(Users request)
        {
            var dbUser = await _context.Users.FindAsync(request.Id);
            if (dbUser == null)
                return BadRequest("User not found.");

            dbUser.FirstName = request.FirstName;
            dbUser.LastName = request.LastName;
            dbUser.Email = request.Email;

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
        //delete användare
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Users>>> Delete(int id)
        {
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
                return BadRequest("User not found.");

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }


    }
}
