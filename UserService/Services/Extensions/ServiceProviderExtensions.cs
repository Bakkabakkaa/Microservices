using Microservices.Database.Repository;

namespace Microservices.Services.Extensions;

public static class ServiceProviderExtensions
{
    public static void AddPasswordHasher(this IServiceCollection serviceCollection) => 
        serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();

    public static void AddRepository(this IServiceCollection serviceCollection) => 
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
}