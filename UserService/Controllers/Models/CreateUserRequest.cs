using System.ComponentModel.DataAnnotations;

namespace Microservices.Controllers.Models;

public class CreateUserRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your email")]
    public string Email { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your name")]
    public string Name { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your password")]
    public string Password { get; set; }
}