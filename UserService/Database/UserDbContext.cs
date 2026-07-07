using Microservices.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Database;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userBuilder = modelBuilder.Entity<User>();
        
        userBuilder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
        userBuilder.Property(x => x.Name).IsRequired();
        userBuilder.Property(x => x.Email).IsRequired();
        userBuilder.Property(x => x.CreatedAt).IsRequired();
        userBuilder.Property(x => x.PasswordHash).IsRequired();
        
        userBuilder.HasKey(x => x.Id);
        
        
    }
}