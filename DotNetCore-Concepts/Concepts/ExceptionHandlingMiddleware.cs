using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace InterviewPrepration.Concepts;

internal class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var payload = new
            {
                statusCode = 500,
                message = "An unexpected error occurred."
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(payload));
        }
    }
}
