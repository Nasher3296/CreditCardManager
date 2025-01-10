using CreditCardManager.Data;
using CreditCardManager.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CreditCardManager.Repositories.Users
{
    public class UserRepository : RepositoryBaseDB<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User?> GetByEmailAsync(string userEmail)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email.Trim().ToLower() == userEmail.Trim().ToLower());
        }
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Username.Trim().ToLower() == username.Trim().ToLower());
        }
    }
}
