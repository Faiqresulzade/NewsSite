using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace News.Application.Registrations
{
    internal static class Registration
    {
        internal static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
