using Microservices.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers;

[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public UserModel GetUser(CancellationToken ct)
    {
        return new UserModel()
        {
            Id = Guid.Empty,
            Email = "Email",
            Name = "Artem"
        };
    }

    [HttpPost("Register")]
    public IActionResult Register([FromBody]CreateUserRequest request, CancellationToken ct)
    {
        return Ok();
    }

    [HttpPut("Update")]
    public ActionResult UpdateUser(int id, [FromBody] UpdateUserRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(request);
    }
}