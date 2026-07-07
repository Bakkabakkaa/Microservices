using Microservices.Models;

namespace Microservices.Database.Repository;

public interface IUserRepository
{
    public Task<User?> GetAsync(Guid id, CancellationToken ct);
    public Task<Guid> Register(User user, CancellationToken ct);
    public Task Update(User user, CancellationToken ct);
}