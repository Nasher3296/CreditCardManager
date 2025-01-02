using CreditCardManager.Exceptions;
using CreditCardManager.Models.Movement;
using CreditCardManager.Models.Payers;
using CreditCardManager.Repositories.Movements;
using CreditCardManager.Services.Payers;

namespace CreditCardManager.Services.Movements
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IPayerService _payerService;

        public MovementService(IMovementRepository movementRepository, IPayerService payerService)
        {
            _movementRepository = movementRepository;
            _payerService = payerService;
        }

        public async Task<Movement> CreateMovementAsync(MovementRequest request)
        {
            Payer? payer = await getRequestPayer(request);

            var movement = new Movement
            {
                Card = request.Card ?? string.Empty,
                Amount = request.Amount,
                InstallmentsQty = request.InstallmentsQty,
                Date = DateOnly.TryParse(request.Date, out var parsedDate) ? parsedDate : DateOnly.FromDateTime(DateTime.Now),
                Detail = request.Detail ?? string.Empty,
                Payer = payer,
                Observations = request.Observations ?? string.Empty
            };

            return await AddMovementAsync(movement);
        }

        public async Task<Movement> AddMovementAsync(Movement movement)
        {
            await _movementRepository.AddAsync(movement);
            await _movementRepository.SaveAsync();
            return movement;
        }

        public async Task<Movement?> GetMovementByIdAsync(int id)
        {
            return await _movementRepository.GetByIdAsync(id);
        }

        public async Task<List<Movement>> GetAllMovementsAsync()
        {
            return await _movementRepository.GetAllAsync();
        }

        /*---------*/
        private async Task<Payer> getRequestPayer(MovementRequest request) {
            Payer? payer = null;

            if (request.PayerID.HasValue)
            {
                payer = await _payerService.GetPayerByIdAsync(request.PayerID.Value);
                if (!(payer == null)) return payer;

                throw new NotFoundException($"Payer with ID {request.PayerID.Value} not found.");
            }
            
            if (!string.IsNullOrEmpty(request.PayerName))
            {
                payer = await _payerService.GetPayerByNameAsync(request.PayerName);

                if (!(payer == null)) return payer;

                //Autocreate payer using the payername

                payer = await _payerService.AddPayerAsync(new Payer { Name = request.PayerName });
                if (!(payer == null)) return payer;

                // I haven't thought about this case yet. Might throw an exception.
            }

            return payer;
        }
    }
}
