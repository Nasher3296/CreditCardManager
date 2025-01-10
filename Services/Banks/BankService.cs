using CreditCardManager.Exceptions;
using CreditCardManager.Models.Banks;
using CreditCardManager.Repositories.Banks;

namespace CreditCardManager.Services.Banks
{
    public class BankService(IBankRepository bankRepository) : IBankService
    {
        private readonly IBankRepository _bankRepository = bankRepository;

        public async Task<Bank> AddBankAsync(Bank bank)
        {
            await _bankRepository.AddAsync(bank);
            await _bankRepository.SaveAsync();
            return bank;
        }

        public async Task<Bank> CreateBankAsync(BankRequest request)
        {
            var existingBank = await _bankRepository.GetByNameAsync(request.Name);

            if(existingBank != null) 
            {
                throw new BusinessException($"A bank with the name '{request.Name}' already exists.", new { existingBank.Id, existingBank.Name });
            }

            var bank = new Bank
            {
                Name = request.Name
            };

            return await AddBankAsync(bank);
        }

        public async Task<Bank?> GetBankByIdAsync(int id)
        {
            return await _bankRepository.GetByIdAsync(id);
        }

        public async Task<Bank?> GetBankByNameAsync(string bankName)
        {
            return await _bankRepository.GetByNameAsync(bankName);
        }

        public async Task<List<Bank>> GetAllBanksAsync()
        {
            return await _bankRepository.GetAllAsync();
        }
    }
}
