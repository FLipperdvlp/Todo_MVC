using Microsoft.EntityFrameworkCore;
using Todos.Database;
using Todos.Interfaces;
using Todos.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite("Data source = todos.db");
    });

    builder.Services.AddScoped<ITodoService, TodoService>();
    builder.Services.AddScoped<IUserService, UserService>();
}

var app = builder.Build();
{
    app.UseStaticFiles();
    app.MapControllerRoute("default", "{controller=Todo}/{action=List}/{id?}");
    app.Run();
}