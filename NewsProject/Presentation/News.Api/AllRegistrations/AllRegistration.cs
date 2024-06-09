using News.Persistence.Registrations;
using News.Application.Registrations;
using News.Infrastructure.Registrations;
using News.Application.Bases.Interfaces.DI;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace News.Api.AllRegistrations
{
    /// <summary>
    /// Class responsible for registering all dependencies and Swagger configuration.
    /// </summary>
    public static class AllRegistration
    {
        /// <summary>
        /// Registers all dependencies in the service collection.
        /// </summary>
        public static void RegisterAllDI(WebApplicationBuilder builder)
        {
            RegisterImplementationsOf<IScoped>(builder.Services, ServiceLifetime.Scoped);
            RegisterImplementationsOf<ITransient>(builder.Services, ServiceLifetime.Transient);

            builder.Services.AddSwagger();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
        }

        /// <summary>
        /// Adds Swagger configuration to the service collection.
        /// </summary>
        /// <param name="services">The service collection to add Swagger configuration.</param>
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

        /// <summary>
        /// Registers implementations of the specified interface types in the service collection.
        /// </summary>
        /// <typeparam name="TInterface">The interface type to be registered.</typeparam>
        /// <param name="services">The service collection to register the implementations.</param>
        /// <param name="lifetime">The service lifetime of the registered implementations.</param>
        private static void RegisterImplementationsOf<TInterface>(IServiceCollection services, ServiceLifetime lifetime)
        {
            foreach (Assembly assembly in AssemblyHelper.GetProjectAssemblies())
            {
                var typesToRegister = assembly.GetTypes()
                    .Where(type => typeof(TInterface).IsAssignableFrom(type) && type != typeof(TInterface));

                foreach (Type type in typesToRegister)
                {
                    Type? interfaceType = type.GetInterfaces().FirstOrDefault(x => typeof(IDependencyInjections).IsAssignableFrom(x));

                    if (interfaceType is null)
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

        /// <summary>
        /// Helper class for working with assemblies.
        /// </summary>
        private static class AssemblyHelper
        {
            private const string projectAssemblyPrefix = "News";

            /// <summary>
            /// Gets the assemblies that belong to the project.
            /// </summary>
            /// <returns>An array of project assemblies.</returns>
            public static Assembly[] GetProjectAssemblies()
            {
                Assembly[] allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

                Assembly[] projectAssemblies = allAssemblies
                    .Where(assembly => assembly.FullName.StartsWith(projectAssemblyPrefix))
                    .ToArray();

                return projectAssemblies;
            }
        }
    }
}