using CreditCardManager.Models.Banks;

namespace CreditCardManager.Repositories.Banks
{
    public interface IBankRepository : IRepository<Bank>
    {
        Task<Bank?> GetByNameAsync(string bankName);
    }
}
