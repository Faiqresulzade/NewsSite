using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;

namespace News.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				next(context);
			}
			catch (Exception ex)
			{

			}
        }
		private static Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			int statusCode=GetStatusCode(ex);
			context.Response.StatusCode = statusCode;
			context.Response.ContentType = "application/json";
		}
		private static int GetStatusCode(Exception ex) =>
			ex switch
			{
				BadRequestException=>StatusCodes.Status400BadRequest,
				NotFoundException=>StatusCodes.Status404NotFound,
				ValidationException=>StatusCodes.Status422UnprocessableEntity,
				_=>StatusCodes.Status500InternalServerError
			};

    }
}
