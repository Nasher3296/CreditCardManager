using CreditCardManager.Models.Cards;
using CreditCardManager.Models.Payers;

namespace CreditCardManager.Models.Movement
{
    public class Movement
    {
        public int Id { get; set; }
        public Card? Card { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentsQty { get; set; }
        public DateOnly Date { get; set; }
        public string? Detail { get; set; }
        public Payer? Payer { get; set; }
        public string? Observations { get; set; }

    }
}
