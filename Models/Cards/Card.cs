namespace CreditCardManager.Models.Cards
{
    public class Card
    {
        public int Id { get; set; }
        public required string Alias { get; set; }
        public string? Bank { get; set; }
        public string? Company { get; set; }
    }
}
