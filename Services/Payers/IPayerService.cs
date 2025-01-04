using CreditCardManager.Models.Payers;

namespace CreditCardManager.Services.Payers
{
    public interface IPayerService
    {
        public Task<Payer> AddPayerAsync(Payer payer);
        public Task<Payer> CreatePayerAsync(PayerRequest request);
        public Task<Payer?> GetPayerByIdAsync(int id);
        public Task<Payer?> GetPayerByNameAsync(string payerName);
        public Task<List<Payer>> GetAllPayersAsync();
    }
}
