using Microsoft.EntityFrameworkCore;
using Todos.Entities;

namespace Todos.Database;

public class AppDbContext : DbContext
{
    public System.Data.Entity.DbSet<User> Users { get; set; } = null!;
    public System.Data.Entity.DbSet<Todo> Todos { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}