using CreditCardManager.Data;
using CreditCardManager.Models.Cards;
using CreditCardManager.Repositories.Cards;
using Microsoft.EntityFrameworkCore;

namespace CreditCardManager.Repositories.Cards
{
    public class CardRepository(ApplicationDbContext dbContext) : RepositoryBaseDB<Card>(dbContext), ICardRepository
    {
        public async Task<Card?> GetByAliasAsync(string cardAlias)
        {
            return await _dbContext.Set<Card>().FirstOrDefaultAsync(c => c.Alias.Trim().ToLower() == cardAlias.Trim().ToLower());
        }
    }
}
