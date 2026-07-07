using Microservices.Controllers.Models;
using Microservices.Database.Repository;
using Microservices.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers;

[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
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
    public async Task<IActionResult> Register([FromBody]CreateUserRequest request, CancellationToken ct)
    {
        var user = new User
        {
            Id = Guid.Empty,
            Email = request.Email,
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            PasswordHash = request.Password
        };

        var id = await _userRepository.Register(user, ct);
            
        return Ok(id);
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