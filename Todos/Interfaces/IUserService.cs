using Todos.Entities;

namespace Todos.Interfaces;

public interface IUserService
{
    Task<User>? GetUserByCredentialsAsync(string email, string password);

    string GetJwtToken(int userId);
    
    Task CreateUser(string email, string password);
}