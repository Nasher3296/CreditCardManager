using CreditCardManager.Data;
using CreditCardManager.Models.Movement;
using Microsoft.EntityFrameworkCore;
namespace CreditCardManager.Repositories.Movements
{
    public class MovementRepository : RepositoryBaseDB<Movement>, IMovementRepository
    {
        public MovementRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
