using CreditCardManager.Exceptions;
using CreditCardManager.Models.Payers;
using CreditCardManager.Repositories.Payers;

namespace CreditCardManager.Services.Payers
{
    public class PayerService : IPayerService
    {
        private readonly IPayerRepository _payerRepository;
        public PayerService(IPayerRepository payerRepository)
        {
            _payerRepository = payerRepository;
        }

        public async Task<Payer> CreatePayerAsync(PayerRequest request)
        {
            var existingPayer = await _payerRepository.GetByNameAsync(request.Name);

            if (existingPayer != null)
            {
                throw new BusinessException($"A payer with the name '{request.Name}' already exists.", new { existingPayer.Id, existingPayer.Name });
            }

            var payer = new Payer
            {
                Name = request.Name
            };

            return await AddPayerAsync(payer);
        }
        public async Task<Payer> AddPayerAsync(Payer payer)
        {
            await _payerRepository.AddAsync(payer);
            await _payerRepository.SaveAsync();
            return payer;
        }

        public async Task<Payer?> GetPayerByIdAsync(int id)
        {
            return await _payerRepository.GetByIdAsync(id);
        }

        public async Task<Payer?> GetPayerByNameAsync(string payerName)
        {
            return await _payerRepository.GetByNameAsync(payerName);
        }

        public async Task<List<Payer>> GetAllPayersAsync()
        {
            return await _payerRepository.GetAllAsync();
        }
    }
}
