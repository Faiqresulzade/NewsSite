using News.Persistence.Registrations;
using News.Application.Registrations;
using News.Mapper.Registrations;
namespace News.Api.AllRegistrations
{
    internal static class AllRegistration
    {
        internal static void RegisterAllDI(WebApplicationBuilder builder)
        {
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddMapper();
        }
    }
}
