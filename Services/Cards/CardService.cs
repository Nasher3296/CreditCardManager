using Azure.Core;
using CreditCardManager.Exceptions;
using CreditCardManager.Models.Banks;
using CreditCardManager.Models.Cards;
using CreditCardManager.Models.Movement;
using CreditCardManager.Models.Payers;
using CreditCardManager.Repositories.Cards;
using CreditCardManager.Services.Banks;

namespace CreditCardManager.Services.Cards
{
    public class CardService(ICardRepository cardRepository, IBankService bankService) : ICardService
    {
        private readonly ICardRepository _cardRepository = cardRepository;
        private readonly IBankService _bankService = bankService;

        public async Task<Card> CreateCardAsync(CardRequest request)
        {
            Bank? bank = await getRequestBank(request);

            var card = new Card
            {
                Alias = request.Alias,
                Bank = bank,
                Company = request.Company
            };

            return await AddCardAsync(card);
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

        private async Task<Bank?> getRequestBank(CardRequest request)
        {
            Bank? bank = null;

            if (request.BankID.HasValue)
            {
                bank = await _bankService.GetBankByIdAsync(request.BankID.Value);
                if (!(bank == null)) return bank;

                throw new NotFoundException($"Bank with ID {request.BankID.Value} not found.");
            }

            if (!string.IsNullOrEmpty(request.BankName))
            {
                bank = await _bankService.GetBankByNameAsync(request.BankName);

                if (!(bank == null)) return bank;

                //Autocreate bank using the bankname

                bank = await _bankService.AddBankAsync(new Bank { Name = request.BankName });
                if (!(bank == null)) return bank;

                //TODO: I haven't thought about this case yet. Might throw an exception.
            }

            return bank;
        }
}
}
