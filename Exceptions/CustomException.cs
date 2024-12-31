namespace CreditCardManager.Exceptions
{
    public abstract class CustomException : Exception
    {
        public int StatusCode { get; }
        public object? AdditionalData { get; }

        protected CustomException(int statusCode, string message, object? additionalData = null)
            : base(message)
        {
            StatusCode = statusCode;
            AdditionalData = additionalData;
        }
    }

}
