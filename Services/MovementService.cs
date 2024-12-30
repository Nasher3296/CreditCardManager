using CreditCardManager.Models.Movement;
using CreditCardManager.Repositories;

namespace CreditCardManager.Services
{
    public class MovementService
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

        public async Task<Movement> GetMovementByIdAsync(int id)
        {
            return await _movementRepository.GetByIdAsync(id);
        }

        public async Task<List<Movement>> GetAllMovementsAsync()
        {
            return await _movementRepository.GetAllAsync();
        }
    }
}
