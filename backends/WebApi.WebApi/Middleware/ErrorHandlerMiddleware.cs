using Microsoft.EntityFrameworkCore;
using WebApi.Business.Src.Shared;

namespace WebApi.WebApi.Middleware
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CustomException e)
            {
                context.Response.StatusCode = e.StatusCode;
                await context.Response.WriteAsJsonAsync(e.ErrorMessage);
            }
            catch (DbUpdateException e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(e.InnerException!.Message);
            }
            catch (Exception e)
            {
                var errorResponse = new { ErrorMessage = "An error occurred." + e.Message };
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}