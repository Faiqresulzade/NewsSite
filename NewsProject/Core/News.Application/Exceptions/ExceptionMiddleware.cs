using FluentValidation;
using Microsoft.AspNetCore.Http;
using News.Application.Bases.Interfaces.DI;
using SendGrid.Helpers.Errors.Model;

namespace News.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware, ITransient
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = GetStatusCode(ex);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            if (ex is ValidationException validationException)
                return context.Response.WriteAsync(new ExceptionModel(
                   errors: validationException.Errors.Select(x => x.ErrorMessage),
                   statusCode: StatusCodes.Status400BadRequest).ToString());

            List<string> errors = new() { ex.Message };

            return context.Response.WriteAsync(new ExceptionModel(errors, statusCode).ToString());
        }


        private static int GetStatusCode(Exception ex) =>
            ex switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

    }
}