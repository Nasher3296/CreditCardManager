namespace CreditCardManager.Exceptions
{
    public class BusinessException : CustomException
    {
        public BusinessException(string message, object? additionalData = null)
            : base(StatusCodes.Status409Conflict, message, additionalData)
        {
        }
    }
}
