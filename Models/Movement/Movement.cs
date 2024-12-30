namespace CreditCardManager.Models.Movement
{
    public class Movement
    {
        public int Id { get; set; }
        public string Card { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentsQty { get; set; }
        public DateOnly Date { get; set; }
        public string Detail { get; set; }
        public string Payer { get; set; }
        public string Observations { get; set; }

    }
}
