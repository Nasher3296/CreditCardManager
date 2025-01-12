﻿namespace CreditCardManager.Models.Movement
{
    public class MovementRequest
    {
        public int? CardID { get; set; }
        public string? CardAlias { get; set; }
        public decimal Amount { get; set; }
        public int InstallmentsQty { get; set; }
        public string? Date { get; set; }
        public string? Detail { get; set; }
        public int? PayerID { get; set; }
        public string? PayerName { get; set; }
        public string? Observations { get; set; }
    }
}
