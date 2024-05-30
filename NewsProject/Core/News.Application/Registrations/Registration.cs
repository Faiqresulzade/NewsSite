using MediatR;
using FluentValidation;
using System.Reflection;
using System.Globalization;
using News.Application.Beheviors;
using News.Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Features.NewsCategory.EventHandler;

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

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            RegisterEventMethod(serviceProvider);
        }

        public static void AddAplication(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        private static void RegisterEventMethod(ServiceProvider serviceProvider)
        {
            var rules = serviceProvider.GetService<CategoryEventHandler>();
            rules?.SubscribeToEvents();
        }
    }
}