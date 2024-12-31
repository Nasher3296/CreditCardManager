namespace CreditCardManager.Exceptions
{
    public class JwtException : CustomException
    {
        public JwtException(int statusCode, string message, object? additionalData = null)
            : base(StatusCodes.Status401Unauthorized, message, additionalData)
        {
        }

        public static JwtException TokenMissing() =>
        new JwtException(StatusCodes.Status401Unauthorized, "JWT token is missing.");

        public static JwtException TokenInvalid() =>
            new JwtException(StatusCodes.Status401Unauthorized, "Invalid JWT token.");

        public static JwtException TokenExpired() =>
            new JwtException(StatusCodes.Status401Unauthorized, "JWT token has expired.");

        public static JwtException TokenFormatError() =>
            new JwtException(StatusCodes.Status400BadRequest, "Invalid JWT token format.");

        public static JwtException Forbidden() =>
            new JwtException(StatusCodes.Status403Forbidden, "Access to the resource is forbidden.");
    }
}
