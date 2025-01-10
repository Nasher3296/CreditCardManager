using CreditCardManager.Data;
using CreditCardManager.Models.Payers;
using Microsoft.EntityFrameworkCore;

namespace CreditCardManager.Repositories.Payers
{
    public class PayerRepository(ApplicationDbContext dbContext) : RepositoryBaseDB<Payer>(dbContext), IPayerRepository
    {
        public async Task<Payer?> GetByNameAsync(string payerName)
        {
            return await _dbContext.Set<Payer>().FirstOrDefaultAsync(p => p.Name.Trim().ToLower() == payerName.Trim().ToLower());
        }
    }
}
