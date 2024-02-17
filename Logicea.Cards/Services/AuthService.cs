using Logicea.Cards.Data;
using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;
using Logicea.Cards.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Logicea.Cards.Services
{
    public class AuthService : IAuthService
    {
        private readonly LogiceaDbContext _dbContext;

        public AuthService(LogiceaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNewUser(User user)
        {
            if (user != null)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> EmailAddressIsTaken(string email)
        {
            var item = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return item != null;
        }

        public async Task<LoginModel?> Login(string email)
        {
            var item = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (item is null)
                return null;

            return new LoginModel
            {
                Email = email,
                PasswordHash = item.PasswordHash,
                UserID = item.UserId
            };
        }
    }
}
