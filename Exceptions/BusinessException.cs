namespace CreditCardManager.Exceptions
{
    public class BusinessException(string message, object? additionalData = null) : CustomException(StatusCodes.Status409Conflict, message, additionalData)
    {
    }
}
