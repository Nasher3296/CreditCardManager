namespace CreditCardManager.Models.Movement
{
    public class MovementRequest
    {
        public string Card { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentsQty { get; set; }
        public string Date { get; set; }
        public string Detail { get; set; }
        public string Payer { get; set; }
        public string Observations { get; set; }
    }
}
