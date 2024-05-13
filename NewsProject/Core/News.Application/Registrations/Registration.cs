using Microsoft.Extensions.DependencyInjection;
using News.Application.Abstraction.Interfaces.AutoMapper;
using News.Application.AutoMapper;
using System.Reflection;

namespace News.Application.Registrations
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            //services.AddSingleton<IMapper, Mapper>();
        }
    }
}
