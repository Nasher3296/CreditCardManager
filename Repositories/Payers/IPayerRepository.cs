using CreditCardManager.Models.Payers;

namespace CreditCardManager.Repositories.Payers
{
    public interface IPayerRepository : IRepository<Payer>
    {
        Task<Payer?> GetByNameAsync(string payerName);
    }
}
