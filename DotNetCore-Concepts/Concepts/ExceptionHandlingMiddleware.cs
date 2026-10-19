using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace InterviewPrepration.Concepts;

internal class ExceptionHandlingMiddleware
{
    private readonly Func<object, Task> _next;

    public ExceptionHandlingMiddleware(Func<object, Task> next)
    {
        _next = next;
    }

    public async Task InvokeAsync(object context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception)
        {
            // No HTTP context available in this simplified environment; swallow the exception
            // or log it when a logger is available.
        }
    }
}
