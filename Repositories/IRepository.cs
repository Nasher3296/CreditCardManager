using CreditCardManager.Models.Movement;

namespace CreditCardManager.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task SaveAsync();
    }
}
