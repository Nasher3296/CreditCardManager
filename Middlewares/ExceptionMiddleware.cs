using CreditCardManager.Exceptions;

namespace CreditCardManager.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode;
            object response;

            if (exception is CustomException customException)
            {
                statusCode = customException.StatusCode;
                response = new
                {
                    message = customException.Message,
                    data = customException.AdditionalData
                };
            }
            else
            {
                // Default: Internal Server Error
                statusCode = StatusCodes.Status500InternalServerError;
                response = new
                {
                    message = "An unexpected error occurred.",
                    error = exception.Message,
                    line = exception.StackTrace
                };
            }

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsJsonAsync(response);
        }
    }

}
