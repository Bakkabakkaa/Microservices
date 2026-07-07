using Microservices.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers;

[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public UserModel GetUser()
    {
        return new UserModel()
        {
            Id = Guid.Empty,
            Email = "Email",
            Name = "Artem"
        };
    }

    [HttpPost("Register")]
    public IActionResult Register([FromBody]CreateUserRequest request)
    {
        return Ok();
    }

    [HttpPut("Update")]
    public ActionResult UpdateUser(int id, [FromBody] UpdateUserRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(request);
    }
}