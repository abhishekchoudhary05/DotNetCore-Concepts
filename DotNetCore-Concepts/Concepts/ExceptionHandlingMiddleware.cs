using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace InterviewPrepration.Concepts;

/// <summary>Demonstrates wrapping a request delegate with exception handling.</summary>
internal class ExceptionHandlingMiddleware
{
    private readonly Func<object, Task> _next;

    /// <summary>Creates the wrapper around the next delegate in the pipeline.</summary>
    public ExceptionHandlingMiddleware(Func<object, Task> next)
    {
        _next = next;
    }

    /// <summary>Invokes the next delegate and catches exceptions from its execution.</summary>
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
