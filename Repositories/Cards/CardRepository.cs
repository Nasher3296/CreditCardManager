using CreditCardManager.Data;
using CreditCardManager.Models.Cards;
using CreditCardManager.Repositories.Cards;
using Microsoft.EntityFrameworkCore;

namespace CreditCardManager.Repositories.Cards
{
    public class CardRepository : RepositoryBaseDB<Card>, ICardRepository
    {
        public CardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Card?> GetByAliasAsync(string cardAlias)
        {
            return await _dbContext.Set<Card>().FirstOrDefaultAsync(c => c.Alias.Trim().ToLower() == cardAlias.Trim().ToLower());
        }
    }
}
