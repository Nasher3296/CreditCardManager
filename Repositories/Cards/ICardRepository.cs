using CreditCardManager.Models.Cards;

namespace CreditCardManager.Repositories.Cards
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<Card?> GetByAliasAsync(string cardAlias);
    }
}
