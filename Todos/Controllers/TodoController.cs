using Microsoft.AspNetCore.Mvc;

namespace Todos.Controllers;

public class TodoController : Controller
{
    public IActionResult List()
    {
        return View();
    }
}