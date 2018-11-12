using Microsoft.AspNetCore.Mvc;
using SimpleAdmin.Models;
using SimpleAdmin.Services.Contracts;
using SimpleAdmin.Services.Models;
using SimpleAdmin.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAdmin.Controllers
{
    [Route("api/v1")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var response = await _userService.CreateUser(user);
            return Ok(response);
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(long id)
        {
            var response = await _userService.GetUser(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] RequestParams requestParams)
        {
            if (requestParams == null)
            {
                return BadRequest();
            }

            var response = Enumerable.Empty<User>();

            if (requestParams.Ids != null)
            {
                response = await _userService.GetUsers(requestParams.Ids);
            }
            else
            {
                var users = await _userService.GetUsers(
                    requestParams.Filter,
                    requestParams.PageSize,
                    requestParams.PageNumber);

                response = users.Item1;
                ControllerUtils.AddContentRangeHeader(Request.HttpContext.Response, users.Item2);
            }

            return Ok(response);
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _userService.UpdateUser(id, user);
            return Ok();
        }
    }
}
