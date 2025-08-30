using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Todos.Models;

public class CreateRequestModel
{
    [Required, MinLength(1)]
    public string Text { get; set; } = null!;
    [Required]
    public DateTime ExpiresAt { get; set; }
}