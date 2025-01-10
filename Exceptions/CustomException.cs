namespace CreditCardManager.Exceptions
{
    public abstract class CustomException(int statusCode, string message, object? additionalData = null) : Exception(message)
    {
        public int StatusCode { get; } = statusCode;
        public object? AdditionalData { get; } = additionalData;
    }

}
