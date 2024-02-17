
using Logicea.Cards.Data.Entities;
using Logicea.Cards.Data.Models;

namespace Logicea.Cards.Services.Contracts
{
    public interface IAuthService
    {
        Task CreateNewUser(User user);
        Task<bool> EmailAddressIsTaken(string email);
        Task<LoginModel?> Login(string userName);
    }
}
