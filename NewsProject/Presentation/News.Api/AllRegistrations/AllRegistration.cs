using News.Persistence.Registrations;
using News.Application.Registrations;
using News.Application.Bases.Interfaces.DI;
using System.Reflection;

namespace News.Api.AllRegistrations
{
    public static class AllRegistration
    {
        public static void RegisterAllDI(WebApplicationBuilder builder)
        {
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();

            //builder.Services.Scan();
            //ServiceCollectionExtensions

            RegisterImplementationsOf<IScoped>(builder.Services, ServiceLifetime.Scoped);
            RegisterImplementationsOf<ITransient>(builder.Services, ServiceLifetime.Transient);

        }

        private static void RegisterImplementationsOf<TInterface>(IServiceCollection services, ServiceLifetime lifetime)
        {
            foreach (Assembly assembly in AssemblyHelper.GetProjectAssemblies())
            {
                var typesToRegister = assembly.GetTypes()
                    .Where(t => typeof(TInterface).IsAssignableFrom(t));

                foreach (Type type in typesToRegister)
                {
                    Type? interfaceType = type.GetInterfaces().FirstOrDefault(x => typeof(IDependencyInjections).IsAssignableFrom(x));

                    if (interfaceType == null)
                        break;

                    if (interfaceType.IsGenericType)
                    {
                        try
                        {
                            Type closedGenericType = interfaceType.MakeGenericType(type.GetGenericArguments());
                            services.Add(new ServiceDescriptor(closedGenericType, type, lifetime));
                        }
                        catch (Exception)
                        {}
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