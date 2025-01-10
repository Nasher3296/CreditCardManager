namespace CreditCardManager.Exceptions
{
    public class NotFoundException(string message, object? additionalData = null) : CustomException(StatusCodes.Status404NotFound, message, additionalData)
    {
    }
}
