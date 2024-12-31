using CreditCardManager.Models.Movement;
using CreditCardManager.Repositories.Movements;

namespace CreditCardManager.Services.Movements
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;

        public MovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
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
