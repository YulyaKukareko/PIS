using Lab_APSNETCORE.Models;
using Lab_APSNETCORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab_APSNETCORE.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersApiController : Controller
    {
        private readonly UsersService _usersService;
        public UsersApiController(UsersService usersService) => _usersService = usersService;
        [HttpGet]
        public IActionResult GetAllUsers() => Ok(_usersService.Read());
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id) => Ok(_usersService.Read(id));
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(user == null ? null : _usersService.Add(user));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(user == null ? null : _usersService.Update(user));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) => Ok(_usersService.Delete(id));
    }
}