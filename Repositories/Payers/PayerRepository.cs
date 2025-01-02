using CreditCardManager.Data;
using CreditCardManager.Models.Movement;
using CreditCardManager.Models.Payers;
using CreditCardManager.Repositories.Movements;

namespace CreditCardManager.Repositories.Payers
{
    public class PayerRepository : RepositoryBaseDB<Payer>, IPayerRepository
    {
        public PayerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
