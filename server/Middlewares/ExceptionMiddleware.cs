using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Hangfire.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace RecoCms6.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    [Inject]
    protected SecurityService Security { get; set; }

    public ExceptionMiddleware(RequestDelegate next)
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
            string name = string.Empty;
            if (Security != null)
            {
                name = Security.User.Name;
            }
            Log.Error("Message: {0}.\nEndpoint: {1} {2}.\nStack Trace: {3}.\nUser: {4}\n.",
                ex.Message,
                context.Request.Method,
                context.Request.Path,
                ex.StackTrace,
                name);

            context.Response.ContentType = MediaTypeNames.Text.Plain;
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.Redirect("/Error");
        }
    }
}