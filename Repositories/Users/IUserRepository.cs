using CreditCardManager.Models.Users;

namespace CreditCardManager.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string userEmail);
        Task<User?> GetByUsernameAsync(string username);
    }
}
