﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Abstraction.Interfaces.Factories;
using News.Application.Abstraction.Interfaces.Repositories;
using News.Application.Abstraction.Interfaces.UnitOfWorks;
using News.Domain.Entities;
using News.Persistence.Context;
using News.Persistence.Implementations.Factories;
using News.Persistence.Implementations.Repositories;
using News.Persistence.Implementations.UnitOfWorks;
using System.Reflection;

namespace News.Persistence.Registrations
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("Default")));
            services.Add(new ServiceDescriptor(typeof(IReadRepository<>), typeof(ReadRepository<>), ServiceLifetime.Scoped));
            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}