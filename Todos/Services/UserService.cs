using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Todos.Database;
using Todos.Entities;
using Todos.Interfaces;

namespace Todos.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByCredentialsAsync(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user is null)
                return null;

            var hash = HashPassword(password);
            if (user.PasswordHash != hash)
                return null;

            return user;
        }

        public async Task CreateUser(string email, string password)
        {
            if (await _dbContext.Users.AnyAsync(u => u.Email == email))
                throw new Exception("User with this email already exists");

            var user = new User
            {
                Email = email,
                PasswordHash = HashPassword(password)
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public string GetJwtToken(int userId)
        {
            throw new NotImplementedException();
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}