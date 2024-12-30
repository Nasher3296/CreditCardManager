using CreditCardManager.Data;
using CreditCardManager.Models.Movement;
using Microsoft.EntityFrameworkCore;
namespace CreditCardManager.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movement> GetByIdAsync(int id)
        {
            return await _dbContext.Movements.FindAsync(id);
        }

        public async Task<List<Movement>> GetAllAsync()
        {
            return await _dbContext.Movements.ToListAsync();
        }

        public async Task AddAsync(Movement movement)
        {
            await _dbContext.Movements.AddAsync(movement);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
