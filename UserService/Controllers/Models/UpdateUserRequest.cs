namespace Microservices.Controllers.Models;

public class UpdateUserRequest
{
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string Password { get; set; }
}