using System.ComponentModel.DataAnnotations;
using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            _logger.LogError(ex, "Unhandled exception");

            context.Response.ContentType = "application/json";
            int statusCode = GetStatusCode(ex);
            context.Response.StatusCode = statusCode;
            
            var response = ApiResponse<string>.Fail(statusCode, GetMessage(ex));

            await context.Response.WriteAsJsonAsync(response);
        }
    }

    private int GetStatusCode(Exception ex)
    {
        return ex switch
        {
            ArgumentNullException => (int)HttpStatusCode.BadRequest,       
            ArgumentException => (int)HttpStatusCode.BadRequest,           
            KeyNotFoundException => (int)HttpStatusCode.NotFound,          
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            _ => (int)HttpStatusCode.InternalServerError                  
        };
    }

    private string GetMessage(Exception ex)
    {
        // Tùy vào môi trường Dev/Prod có thể trả message khác
        #if DEBUG
            return ex.Message;
        #else
        // Không muốn lộ lỗi chi tiết cho user
            return context.Response.StatusCode == 500 ? "Internal Server Error" : ex.Message;
        #endif
    }
}