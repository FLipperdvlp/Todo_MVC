using Microsoft.EntityFrameworkCore;
using Todos.Database;
using Todos.Entities;
using Todos.Interfaces;

namespace Todos.Services;

public class TodoService(AppDbContext dbContext) : ITodoService
{
    public async Task<IEnumerable<Todo>> GetTodosByUserId(int userId)
    {
        return await dbContext.Todos.Where(t => t.UserId == userId).ToListAsync();
    }

    public async Task<Todo> CreateTodo(int userId, string text, DateTime expiresAt)
    {
        var newTodo = new Todo
        {
            UserId = userId,
            Text = text,
            ExpiredAt = expiresAt,
            CreatedAt = DateTime.Now,
            IsCompleted = false
        };
        
        dbContext.Todos.Add(newTodo);
        await dbContext.SaveChangesAsync();
        
        return newTodo;
    }
    
    public async Task<Todo> ToggleTodo(int todoId, int userId)
    {
        var todo = await dbContext.Todos.FirstOrDefaultAsync(t => t.Id == todoId && t.UserId == userId);
        
        if(todo is null)
            throw new Exception("Todo not found");

        todo.IsCompleted = !todo.IsCompleted;
        await dbContext.SaveChangesAsync();

        return todo;
    }

    public async Task<bool> DeleteTodo(int todoId, int userId)
    {
        var todo = await dbContext.Todos.FirstOrDefaultAsync(t => t.Id == todoId && t.UserId == userId);
        
        if(todo is null)
            throw new Exception("Todo not found");

        dbContext.Todos.Remove(todo);
        await dbContext.SaveChangesAsync();

        return true;
    }
}