using CreditCardManager.Models.Banks;
using CreditCardManager.Models.Payers;

namespace CreditCardManager.Services.Banks;

public interface IBankService
{
    public Task<Bank> AddBankAsync(Bank bank);
    public Task<Bank> CreateBankAsync(BankRequest request);
    public Task<Bank?> GetBankByIdAsync(int id);
    public Task<Bank?> GetBankByNameAsync(string bankName);
    public Task<List<Bank>> GetAllBanksAsync();
}
