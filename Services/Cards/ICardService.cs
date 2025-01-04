using CreditCardManager.Models.Cards;

namespace CreditCardManager.Services.Cards
{
    public interface ICardService
    {
        public Task<Card> AddCardAsync(Card payer);
        public Task<Card> CreateCardAsync(CardRequest request);
        public Task<Card?> GetCardByIdAsync(int id);
        public Task<Card?> GetCardByAliasAsync(string cardAlias);
        public Task<List<Card>> GetAllCardsAsync();
    }
}
