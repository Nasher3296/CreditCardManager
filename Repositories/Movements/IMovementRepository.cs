using CreditCardManager.Models.Movement;

namespace CreditCardManager.Repositories.Movements
{
    public interface IMovementRepository
    {
        Task<Movement?> GetByIdAsync(int id);
        Task<List<Movement>> GetAllAsync();
        Task AddAsync(Movement movement);
        Task SaveAsync();
    }
}
