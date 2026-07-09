using System.Security.Cryptography;
using System.Text;

namespace Microservices.Services;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string input)
    {
        using SHA256 sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }
}