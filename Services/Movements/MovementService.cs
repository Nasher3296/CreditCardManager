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
            Payer? payer = null;

            if (request.Payer.HasValue)
            {
                payer = await _payerService.GetPayerByIdAsync(request.Payer.Value);
                if (payer == null)
                {
                    throw new NotFoundException($"Payer with ID {request.Payer.Value} not found.");
                }
            }

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
    }
}
