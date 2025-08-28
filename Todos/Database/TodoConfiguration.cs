using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todos.Entities;

namespace Todos.Database;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(t => t.User)
            .WithMany(u => u.Todos)
            .HasForeignKey(t => t.UserId);

        builder.HasData(
            new Todo
            {
                Id = 1,
                UserId = 1,
                Text = "Wash the dishes",
                ExpiredAt = DateTime.Now.AddDays(1)
            },
            new Todo
            {
                Id = 2,
                UserId = 1,
                Text = "Touch the grass",
                ExpiredAt = DateTime.Now.AddDays(2)
            },
            new Todo
            {
                Id = 3,
                UserId = 1,
                IsCompleted = true,
                Text = "Love programming",
                ExpiredAt = DateTime.Now.AddDays(3)
            });
    }
}