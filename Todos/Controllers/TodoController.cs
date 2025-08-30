using Microsoft.AspNetCore.Mvc;
using Todos.Interfaces;
using Todos.Models;

namespace Todos.Controllers;

public class TodoController(ITodoService service) : Controller
{
    private int UserId => 1;
    
    public async Task<IActionResult> List()
    {
        var todos = await service.GetTodosByUserId(UserId);

        return View(todos.Select(todo => new TodoViewModel(todo)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRequestModel model)
    {
        await service.CreateTodo(UserId, model.Text, model.ExpiresAt);
        
        return RedirectToAction(nameof(List));
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await service.DeleteTodo(id, UserId);

        return RedirectToAction(nameof(List));
    }
    
    [HttpPost]
    public async Task<IActionResult> Toggle(int id)
    {
        await service.ToggleTodo(id, UserId);
        
        return RedirectToAction(nameof(List));
    }
}