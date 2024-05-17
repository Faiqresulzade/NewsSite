using News.Persistence.Registrations;
using News.Application.Registrations;
using News.Infrastructure.Registrations;
using News.Application.Bases.Interfaces.DI;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace News.Api.AllRegistrations
{
    public static class AllRegistration
    {
        public static void RegisterAllDI(WebApplicationBuilder builder)
        {
            RegisterImplementationsOf<IScoped>(builder.Services, ServiceLifetime.Scoped);
            RegisterImplementationsOf<ITransient>(builder.Services, ServiceLifetime.Transient);

            builder.Services.AddSwagger();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "News-Site", Version = "v1", Description = "News api swagger client." });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "'Bearer ' yazdiqdan sonra tokeni daxil edin \r\n\r meselen: \" Bearer ksncdlkancsoasnonaco23y7823t67xx"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        private static void RegisterImplementationsOf<TInterface>(IServiceCollection services, ServiceLifetime lifetime)
        {
            foreach (Assembly assembly in AssemblyHelper.GetProjectAssemblies())
            {
                var typesToRegister = assembly.GetTypes()
                    .Where(t => typeof(TInterface).IsAssignableFrom(t) && t != typeof(TInterface));

                foreach (Type type in typesToRegister)
                {
                    Type? interfaceType = type.GetInterfaces().FirstOrDefault(x => typeof(IDependencyInjections).IsAssignableFrom(x));

                    if (interfaceType == null)
                    {
                        services.Add(new ServiceDescriptor(type, type, lifetime));
                        continue;
                    }

                    if (interfaceType.IsGenericType)
                    {
                        try
                        {
                            Type closedGenericType = interfaceType.MakeGenericType(type.GetGenericArguments());
                            services.Add(new ServiceDescriptor(closedGenericType, type, lifetime));
                        }
                        catch (Exception)
                        { }
                    }
                    else
                        services.Add(new ServiceDescriptor(interfaceType, type, lifetime));
                }
            }
        }

        private static class AssemblyHelper
        {
            public static Assembly[] GetProjectAssemblies()
            {
                Assembly[] allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

                string projectAssemblyPrefix = "News";

                Assembly[] projectAssemblies = allAssemblies
                    .Where(assembly => assembly.FullName.StartsWith(projectAssemblyPrefix))
                    .ToArray();

                return projectAssemblies;
            }
        }
    }
}