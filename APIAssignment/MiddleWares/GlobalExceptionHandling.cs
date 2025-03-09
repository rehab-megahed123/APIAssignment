using System.Net;

namespace APIAssignment.MiddleWares
{
    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandling> _logger;

        public GlobalExceptionHandling(RequestDelegate next, ILogger<GlobalExceptionHandling> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Your Application
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleException(context, ex);
            }
        }

        public async Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var errorResponse = new ApiResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Description = "An Internal Error occured. Please try again later",
                Message = ex.Message
            };

            context.Response.WriteAsJsonAsync(errorResponse);
        }

        public class ApiResponse
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public string Description { get; set; }
        }
    }
}
