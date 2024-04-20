using News.Persistence.Registrations;
using News.Application.Registrations;
using News.Mapper.Registrations;
namespace News.Api.AllRegistrations
{
    public static class AllRegistration
    {
        public static void RegisterAllDI(WebApplicationBuilder builder)
        {
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddMapper();
        }
    }
}
