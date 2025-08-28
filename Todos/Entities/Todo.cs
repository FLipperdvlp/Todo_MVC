namespace Todos.Entities;

public class Todo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Text { get; set; }
    public bool IsCompleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ExpiredAt { get; set; }
    
    public User? User { get; set; }
}