using CreditCardManager.Data;
using CreditCardManager.Models.Banks;
using Microsoft.EntityFrameworkCore;

namespace CreditCardManager.Repositories.Banks
{
    public class BankRepository : RepositoryBaseDB<Bank>, IBankRepository
    {
        public BankRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Bank?> GetByNameAsync(string bankName)
        { 
            return await _dbContext.Set<Bank>().FirstOrDefaultAsync(b => b.Name.Trim().ToLower() == bankName.Trim().ToLower());
        }
    }
}
