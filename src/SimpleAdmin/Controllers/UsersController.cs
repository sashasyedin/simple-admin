using Microsoft.AspNetCore.Mvc;
using SimpleAdmin.Models;
using SimpleAdmin.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAdmin.Controllers
{
    [Route("api/v1")]
    public class UsersController : Controller
    {
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            return Ok();
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var user = new User { Id = id, Name = $"Name{id}" };

            if (user == null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };

            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] RequestParams requestParams)
        {
            if (requestParams == null)
            {
                return BadRequest();
            }

            var response = new List<UserDto>
            {
                new UserDto { Id = 1, Name = "Name1"},
                new UserDto { Id = 2, Name = "Name2"},
                new UserDto { Id = 3, Name = "Name3"}
            };

            ControllerUtils.AddContentRangeHeader(Request.HttpContext.Response, 3);
            return Ok(response.OrderBy(x => x.Id));
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }

    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
