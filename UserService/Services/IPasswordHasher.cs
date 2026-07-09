namespace Microservices.Services;

public interface IPasswordHasher
{
    string HashPassword(string input);
}