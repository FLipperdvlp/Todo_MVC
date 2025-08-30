using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todos.Interfaces;
using Todos.Models.Login;
using Todos.Models.Register;

namespace Todos.Controllers;

public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    //TODO: ===============   Register   ===============
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
    
    //TODO: ===============   Login   ===============
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);
        
        var user = await _userService.GetUserByCredentialsAsync(model.Email, model.Password)!;

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (user  == null)
        {
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
        
        return RedirectToAction("List", "Todo");
    }
}