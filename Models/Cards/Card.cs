using CreditCardManager.Models.Banks;

namespace CreditCardManager.Models.Cards
{
    public class Card
    {
        public int Id { get; set; }
        public required string Alias { get; set; }
        public Bank? Bank { get; set; }
        public string? Company { get; set; }
    }
}
