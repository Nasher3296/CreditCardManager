using CreditCardManager.Data;
using CreditCardManager.Models.Movement;
using Microsoft.EntityFrameworkCore;
namespace CreditCardManager.Repositories.Movements
{
    public class MovementRepository(ApplicationDbContext dbContext) : RepositoryBaseDB<Movement>(dbContext), IMovementRepository
    {
    }
}
