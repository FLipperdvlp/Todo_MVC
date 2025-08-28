using Microsoft.AspNetCore.Mvc;
using Todos.Interfaces;
using Todos.Models.Register;

namespace Todos.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _userService.CreateUser(model.Email, model.Password);

        return RedirectToAction("Login");
    }
}