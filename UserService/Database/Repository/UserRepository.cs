using Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Database.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext;

    public UserRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetAsync(Guid id, CancellationToken ct)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, ct);
        return user;
    }

    public async Task<Guid> Register(User user, CancellationToken ct)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(ct);
        return user.Id;
    }

    public async Task Update(User user, CancellationToken ct)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync(ct);
    }
}