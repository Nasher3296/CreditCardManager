namespace CreditCardManager.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message, object? additionalData = null)
            : base(StatusCodes.Status404NotFound, message, additionalData)
        {
        }
    }
}
