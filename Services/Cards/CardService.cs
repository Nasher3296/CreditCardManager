using CreditCardManager.Models.Cards;
using CreditCardManager.Repositories.Cards;

namespace CreditCardManager.Services.Cards
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> AddCardAsync(Card card)
        {
            await _cardRepository.AddAsync(card);
            await _cardRepository.SaveAsync();
            return card;
        }

        public async Task<Card?> GetCardByIdAsync(int id)
        {
            return await _cardRepository.GetByIdAsync(id);
        }

        public async Task<Card?> GetCardByAliasAsync(string cardAlias)
        {
            return await _cardRepository.GetByAliasAsync(cardAlias);
        }

        public async Task<List<Card>> GetAllCardsAsync()
        {
            return await _cardRepository.GetAllAsync();
        }
    }
}
