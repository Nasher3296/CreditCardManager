using CreditCardManager.Models.Users;
using System.Security.Claims;

namespace CreditCardManager.Services.JWTs
{
    public interface IJwtService
    {
        public string GenerateToken(User user);
        public ClaimsPrincipal ValidateToken(string token);
    }
}
