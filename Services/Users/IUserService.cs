using CreditCardManager.Models.Auth;
using CreditCardManager.Models.Users;

namespace CreditCardManager.Services.Users
{
    public interface IUserService
    {
        Task<User?> RegisterUserAsync(RegisterRequest request);
        Task<User?> AuthenticateAsync(LoginRequest request);
    }
}
