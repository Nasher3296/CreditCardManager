using CreditCardManager.Models.Banks;

namespace CreditCardManager.Models.Cards
{
    public class CardRequest
    {
        public required string Alias { get; set; }
        public int? BankID { get; set; }
        public string? BankName { get; set; }
        public required string Company { get; set; }
    }
}
