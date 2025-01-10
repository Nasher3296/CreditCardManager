using CreditCardManager.Data;
using CreditCardManager.Models.Movement;
using Microsoft.EntityFrameworkCore;

namespace CreditCardManager.Repositories
{
    public abstract class RepositoryBaseDB<T>(ApplicationDbContext dbContext) : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext = dbContext;
        protected readonly DbSet<T> _dbSet = dbContext.Set<T>();

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
