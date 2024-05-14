using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Application.Bases.Interfaces.DI;
using News.Persistence.Context;
using News.Persistence.Factories;
using News.Persistence.Repositories;
using News.Persistence.UnitOfWorks;
using System.Reflection;

namespace News.Persistence.Registrations
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("Default")));
            services.Add(new ServiceDescriptor(typeof(IReadRepository<>), typeof(ReadRepository<>), ServiceLifetime.Scoped));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<ICategoryFactory, CategoryFactory>();
        }
    }
}