using Todos.Entities;

namespace Todos.Models;

public class TodoViewModel
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } =  DateTime.Now;
    public DateTime ExpiresAt { get; set; }

    public TodoViewModel()
    {
        
    }

    public TodoViewModel(Todo todo)
    {
        Id = todo.Id;
        Text = todo.Text;
        IsCompleted = todo.IsCompleted;
        CreatedAt = todo.CreatedAt;
        ExpiresAt = todo.ExpiredAt;
    }
}