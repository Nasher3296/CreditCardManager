namespace CreditCardManager.Models.Auth
{
    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public required string Password { get; set; }
    }
}
