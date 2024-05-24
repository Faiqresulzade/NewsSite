using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Beheviors;
using News.Application.Exceptions;
using System.Globalization;
using System.Reflection;

namespace News.Application.Registrations
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");

        }

        public static void AddAplication(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}