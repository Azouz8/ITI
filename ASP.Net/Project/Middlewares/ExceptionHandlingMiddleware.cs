public class ExceptionHandlingMiddleware
{
    RequestDelegate _next;
    ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            _logger.LogInformation($"Request => {context.Request.Path}");
            await _next(context);
            _logger.LogInformation($"Response => {context.Response.StatusCode}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Exception => {ex.Message}");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            await context.Response.WriteAsync("{\"message\": \"Internal Server Error\"}");
        }
    }
}