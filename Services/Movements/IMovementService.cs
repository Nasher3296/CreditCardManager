using CreditCardManager.Models.Movement;

namespace CreditCardManager.Services.Movements
{
    public interface IMovementService
    {
        public Task<Movement> AddMovementAsync(Movement movement);
        public Task<Movement?> GetMovementByIdAsync(int id);
        public Task<List<Movement>> GetAllMovementsAsync();
    }
}
