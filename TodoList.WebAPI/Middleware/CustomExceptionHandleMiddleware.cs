using FluentValidation;
using System.Net;
using System.Text.Json;
using TodoList.Application.Common.Exceptions;

namespace TodoList.WebAPI.Middleware
{
    public class CustomExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandleMiddleware(RequestDelegate next) =>
           _next = next;
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
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.BadRequest;
            var result = string.Empty;
            switch (ex)
            {
                case ValidationException ve:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(ve.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = ex.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
