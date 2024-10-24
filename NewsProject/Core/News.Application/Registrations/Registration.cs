using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Bases.Classes.EventHandler;
using News.Application.Bases.Classes.Rules;
using News.Application.Bases.Interfaces.Rules;
using News.Application.Beheviors;
using News.Application.Exceptions;
using News.Application.Features.Auth.EventHandler;
using News.Application.Features.NewsCategory.EventHandler;
using News.Application.Features.NewsModel.EventHandler;
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

            services.AddTransient(typeof(IBaseRule<>), typeof(BaseRules<>));
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
            var baseEvent = serviceProvider.GetService<BaseEventHandler>();
            var categoryEvent = serviceProvider.GetService<CategoryEventHandler>();
            var newsEvent = serviceProvider.GetService<NewsEventHandler>();
            var authEventHandler = serviceProvider.GetService<AuthEventHandler>();

            baseEvent?.SubscribeEventHandler();
            categoryEvent?.SubscribeToEvents();
            authEventHandler?.SubscribeToEvents();
            newsEvent?.SubscripeToEvent();

            //authevent problem var. ihostingenvirment null gelir
        }
    }
}