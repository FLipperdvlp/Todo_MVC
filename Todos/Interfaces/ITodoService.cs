using Todos.Entities;

namespace Todos.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetTodosByUserId(int userId);
    Task<Todo> CreateTodo(int userId, string text, DateTime expiresAt);
    
    Task<Todo> ToggleTodo(int todoId, int userId);
    
    Task<bool> DeleteTodo(int todoId, int userId);
}