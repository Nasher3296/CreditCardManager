using CreditCardManager.Models.Banks;

namespace CreditCardManager.Models.Cards
{
    public class CardRequest
    {
        public required string Alias;
        public int? BankID { get; set; }
        public string? BankName { get; set; }
        public required string Company;
    }
}
