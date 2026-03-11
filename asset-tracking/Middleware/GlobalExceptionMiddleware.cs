namespace Asset_Tracking_Api.Middleware
{
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using System.Text.Json;

    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            var problem = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = exception.Message,
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = problem.Status.Value;
            context.Response.ContentType = "application/json";

            var json = JsonSerializer.Serialize(problem);

            await context.Response.WriteAsync(json);
        }
    }


}
