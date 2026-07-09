using Microservices.Controllers.Models;
using Microservices.Database.Repository;
using Microservices.Models;
using Microservices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers;

[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserController(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
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
            PasswordHash = _passwordHasher.HashPassword(request.Password)
        };

        var id = await _userRepository.Register(user, ct);
            
        return Ok(id);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute]Guid id, [FromBody] UpdateUserRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var newUser = new User()
        {
            Id = id,
            Name = request.Name,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.Update(newUser, ct);

        return Ok(request);
    }
}